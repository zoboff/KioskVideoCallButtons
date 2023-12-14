using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace VideoSDK
{
    //public delegate void VideoSDKEventHandler(object source, string response);

    [Serializable]
    public class VideoSDKException : Exception
    {
        public VideoSDKException(string message)
            : base(message) { }
    }
    public class AppStateChangedEventArgs : EventArgs
    {
        public int NewState { get; set; }
        public int OldState { get; set; }
    }

    internal class VideoSDK 
    {
        public const double QUEUE_INTERVAL = 50.0; // ms
        public const int CANCEL_DELAY = 2000; // ms
        private const int RECEIVE_CHUNK_SIZE = 10240;

        private string m_ip = "127.0.0.1";
        private int m_port = 0;
        private string m_pin = "";
        private int m_wsPort = 0;
        private int m_httpPort = 0;
        private bool m_debug = false;

        private string m_AuthToken = "";

        private bool m_IsSocketConnected = false;
        private bool m_IsAPIConnected = false;

        private int m_AppState = 0;
        private int m_OldAppState = 0;

        private ConcurrentQueue<string> m_Queue = new ConcurrentQueue<string>();
        private System.Timers.Timer m_QueueTimer;
        private readonly SynchronizationContext m_SyncContext;

        private VideoSDKMethods_V1 m_Methods;
        private VideoSDKEvents_V1 m_Events;

        // Error Event
        private event EventHandler<string> m_OnError;  
        public event EventHandler<string> OnError {
            add     { m_OnError += value; }
            remove  { m_OnError -= value; }
        }

        // Error Event
        private event EventHandler<AppStateChangedEventArgs> m_AppStateChanged;
        public event EventHandler<AppStateChangedEventArgs> OnAppStateChanged
        {
            add { m_AppStateChanged += value; }
            remove { m_AppStateChanged -= value; }
        }

        private ClientWebSocket m_webSocket;

        public bool IsSocketConnected
        {
            get { return m_IsSocketConnected; }
        }

        public bool IsAPIConnected
        {
            get { return m_IsAPIConnected; }
        }

        public int AppState
        {
            get { return m_AppState; } 
        }

        public int PreviousAppState
        {
            get { return m_OldAppState; } 
        }

        public VideoSDKMethods_V1 Methods
        {
            get { return m_Methods; }
        }

        public VideoSDKEvents_V1 Events
        {
            get { return m_Events; }
        }

        public VideoSDK(bool debug = false)
        {
            m_webSocket = new ClientWebSocket();
            m_SyncContext = AsyncOperationManager.SynchronizationContext;

            m_debug = debug;

            m_Methods = new Methods(this);
            m_Events = new Events(this);

            // Set Queue Timer
            m_QueueTimer = new System.Timers.Timer(QUEUE_INTERVAL);
            m_QueueTimer.Elapsed += OnQueueTimedEvent;

            //Connect($"ws://{this.m_ip}:{this.m_wsPort}").Wait();
        }

        ~VideoSDK()
        {
            if (m_IsSocketConnected)
                CloseSession();
        }

        public bool OpenSession(string ip, int port, string pin)
        {
            m_ip = ip;
            m_port = port;
            m_pin = pin;

            // Init port numbers
            try
            {
                getPorts();
            }
            catch (Exception ex)
            {
                throw new VideoSDKException("Error VideoSDK ports reading. Check the IP and PORT parameters in OpenSession().");
            }
            // Connect to websockets
            WS_Connect($"ws://{this.m_ip}:{this.m_wsPort}");

            // Processing 
            RunProcess();

            if (m_debug)
                Console.WriteLine("Session opened.");

            return true;
        }

        public void CloseSession()
        {
            m_AuthToken = "";
            m_IsSocketConnected = false;
            m_IsAPIConnected = false;

            m_QueueTimer.Stop();
            m_Queue.Clear();

            m_webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).Wait();

            if (m_debug)
                Console.WriteLine("Session closed.");
        }

        // Just add in the queue. Don't send any data
        public void Send(string data)
        {
            // Check JSON
            try 
            { 
                JToken.Parse(data);
                m_Queue.Enqueue(data); //WS_SendAsync(data).Wait();
            }
            catch (JsonReaderException e_json)
            {
                m_OnError?.Invoke(this, "Wrong JSON data: " + data + "\n" + e_json.Message);
            }
            catch (Exception e)
            {
                m_OnError?.Invoke(this, "Send data error: " + data + "\n" + e.Message);
            }

        }

        // ==============================================================================
        // Private members
        // ==============================================================================

        private void OnQueueTimedEvent(Object source, ElapsedEventArgs eventArgs)
        {
            string data;

            if(m_Queue.TryDequeue(out data))
            {
                try
                {
                    //WS_Send(data);
                    Thread t = new Thread(() => WS_Send(data));
                    t.Start();
                }
                catch(Exception e)
                {
                    if (m_debug)
                        Console.WriteLine($"Error queue processing: {e.Message}");
                }
            }
        }

        private void RunProcess()
        {
            // Send queue
            m_QueueTimer.Start();
            // Process receive 
            Task.Run(() => WS_ReceiveAsync());
        }

        private void getPorts()
        {
            string config_json_url = $"http://{m_ip}:{m_port}/public/default/config.json";

            // ToDo: have to processing exeptions
            var webRequest = (HttpWebRequest)HttpWebRequest.Create(config_json_url);
            webRequest.UserAgent = "videosdk";

            var response = webRequest.GetResponse();
            var content = response.GetResponseStream();

            using (var reader = new StreamReader(content))
            {
                string strContent = reader.ReadToEnd();

                if (m_debug)
                    Console.WriteLine("Complete config.json: {0}", strContent);

                // ToDo: have to processing exeptions
                var json = JObject.Parse(strContent);

                // ToDo: have to processing exeptions
                // Read ports
                m_wsPort = (int)json["config"]["websocket"]["port"];
                m_httpPort = (int)json["config"]["http"]["port"];
            }
        }

        private void WS_Connect(string url)
        {
            Uri uri = new Uri(url);
            try
            {
                var source = new CancellationTokenSource();
                source.CancelAfter(CANCEL_DELAY);

                m_webSocket.ConnectAsync(uri, source.Token).Wait();

                m_IsSocketConnected = (m_webSocket.State == WebSocketState.Open);

                if (m_IsSocketConnected)
                {
                    if (m_debug)
                        Console.WriteLine("Socket connection successfully.");

                   DoAuth();
                }
                else
                {
                    throw new VideoSDKException("WebSocket not opened.");
                }

            }
            catch (Exception e)
            {
                string msg = $"Error connecting to VideoSDK. The application is probably not running. {e.Message}";

                if (m_debug)
                    Console.WriteLine($"WS_Connect error: {msg}");

                throw new VideoSDKException(msg);
            }
        }

        private void DoError(string response)
        {
            m_OnError?.Invoke(this, response);
        }

        private void DoAppStateChanged(AppStateChangedEventArgs appStateChangedEventArgs)
        {
            m_AppStateChanged?.Invoke(this, appStateChangedEventArgs);
        }

        public async Task WS_SendAsync(string data)
        {
            if (m_webSocket.State == WebSocketState.Open)
            {
                ArraySegment<byte> bytesToSend;
                var source = new CancellationTokenSource();
                source.CancelAfter(CANCEL_DELAY);

                bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(data));

                if (m_debug)
                    Console.WriteLine("Sending: {0}", data);

                await m_webSocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, source.Token);
            }
            else
                throw new Exception($"WS_SendAsync error: WebSocket is not opened.");
        }

        private void WS_Send(string data)
        {
            lock (m_webSocket)
            {
                if (m_webSocket.State == WebSocketState.Open)
                {
                    ArraySegment<byte> bytesToSend;

                    bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(data));                    

                    var source = new CancellationTokenSource();
                    source.CancelAfter(CANCEL_DELAY);

                    m_webSocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, source.Token).Wait();

                    if (m_debug)
                        Console.WriteLine("Sending: {0}", data);
                }
                else
                    throw new Exception($"WS_Send error: WebSocket is not opened.");
            }
        }

        private void DoAuth()
        {
            string data;

            if (m_pin == "")
                data = "{\"method\": \"auth\", \"type\": \"unsecured\"}";
            else
                data = "{\"method\": \"auth\", \"type\": \"secured\", \"credentials\": \"" + this.m_pin + "\"}";

            Send(data); 
        }

        private void DoGetAppState()
        {
            string data;

            data = "{\"method\": \"getAppState\"}";

            Send(data);
        }

        private void PreprocessResponse(JObject json) 
        {
            // Auth - success -> get a current app state
            if ((String.Compare("auth", (string)json["method"], true) == 0) && ((bool)json["result"] == true))
            {
                DoGetAppState();
            }
            // Store the current application state
            else if (
                        ((String.Compare("getAppState", (string)json["method"], true) == 0) && ((bool)json["result"] == true))
                        ||
                        ((String.Compare("event", (string)json["method"], true) == 0) && (String.Compare("appStateChanged", (string)json["event"], true) == 0))
                    )
            {
                int newState = (int)json["appState"];

                if (newState != m_AppState)
                {
                    int oldState = m_AppState;

                    Interlocked.Exchange(ref m_AppState, newState);
                    Interlocked.Exchange(ref m_OldAppState, oldState);

                    var args = new AppStateChangedEventArgs
                    {
                        OldState = m_OldAppState,
                        NewState = m_AppState
                    };

                    m_SyncContext.Post(e => DoAppStateChanged((AppStateChangedEventArgs)e), args);
                }
            }

        }

        private async Task WS_ReceiveAsync()
        {
            byte[] buffer = new byte[RECEIVE_CHUNK_SIZE];
            while (m_webSocket.State == WebSocketState.Open)
            {
                var result = await m_webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await m_webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    // ToDo: have to processing exeptions
                    var json = JObject.Parse(response);

                    // Preprocess
                    PreprocessResponse(json);

                    //  "method": "event"
                    if (String.Compare("event", (string)json["method"], true) == 0)
                    {
                        //((Events)m_Events).ProcessResponse(response);
                        m_SyncContext.Post(e => ((Events)m_Events).ProcessResponse((string)e), response);
                    }
                    else
                    {
                        // result = false -> Error
                        if ((bool)json["result"] == false) 
                        {
                            // m_OnError?.Invoke(this, response);
                            m_SyncContext.Post(e => DoError((string)e), response);
                        }
                        // ((Methods)m_Methods).ProcessResponse(response);
                        m_SyncContext.Post(e => ((Methods)m_Methods).ProcessResponse((string)e), response);
                    }

                    if (m_debug)
                        Console.WriteLine("Complete receive: {0}", response);
                }
            }
        }
    }
}
