using VideoSDK;
using System.Net.NetworkInformation;
using static VideoSDK.VideoSDKEvents_V1;

namespace ThreeVideoCallButtons
{
    public partial class VideoCall : Form
    {
        public static readonly string VIDEOSDK_IP = "127.0.0.1";
        public static readonly int VIDEOSDK_PORT = 8080;
        public static readonly string VIDEOSDK_PIN = "";

        public static readonly string TRUECONF_SERVER = "server.trueconf.com";
        public static readonly string MY_ID = "kiosk";
        public static readonly string MY_PASSWORD = "***";

        // TrueConf IDs
        public static readonly string UserID1 = "operator1";
        public static readonly string UserID2 = "operator2";
        public static readonly string UserID3 = "operator3";

        VideoSDK.VideoSDK sdk;

        int CurrentAppState = -1;

        public VideoCall()
        {
            InitializeComponent();

            sdk = new VideoSDK.VideoSDK(true);
        }

        private void VideoCall_Load(object sender, EventArgs e)
        {
            InitSDK();
        }

        private void VideoCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            sdk.CloseSession();
        }

        private void VideoCall_Shown(object sender, EventArgs e)
        {
            BackColor = Color.Lime;
            TransparencyKey = Color.Lime;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void InitSDK()
        {
            sdk.OnAppStateChanged += OnStateChange;
            sdk.Events.On_incomingChatMessage += OnEvent;
            sdk.Methods.OnMethodResponse += OnMethod;
            sdk.OnError += OnError;

            // Connect to the VideoSDK instance trough Socket API
            sdk.OpenSession(VIDEOSDK_IP, VIDEOSDK_PORT, VIDEOSDK_PIN);
            Thread.Sleep(1000); // <<== It is just for this example. Don't do this anymore

            sdk.Methods.connectToServer(TRUECONF_SERVER);
            Thread.Sleep(1000); // <<== It is just for this example. Don't do this anymore

            sdk.Methods.login(MY_ID, MY_PASSWORD);
            Thread.Sleep(1000); // <<== It is just for this example. Don't do this anymore
        }

        private void OnStateChange(object source, AppStateChangedEventArgs appStateChangedEventArgs)
        {
            // Store the app state
            CurrentAppState = appStateChangedEventArgs.NewState;

            // Show the current application state
            labelAppState.Text = AppStates.GetHint(appStateChangedEventArgs.NewState);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentAppState == AppStates.Conference.State || CurrentAppState == AppStates.Wait.State)
                sdk.Methods.hangUp();
            else
                sdk.Methods.call(UserID1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentAppState == AppStates.Conference.State || CurrentAppState == AppStates.Wait.State)
                sdk.Methods.hangUp();
            else
                sdk.Methods.call(UserID2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurrentAppState == AppStates.Conference.State || CurrentAppState == AppStates.Wait.State)
                sdk.Methods.hangUp();
            else
                sdk.Methods.call(UserID3);
        }

        static void OnEvent(object source, string response)
        {
            var clr = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("OnEvent: {0}", response);
            Console.ForegroundColor = clr;
        }
        static void OnMethod(object source, string response)
        {
            var clr = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("OnMethod: {0}", response);
            Console.ForegroundColor = clr;
        }
        static void OnError(object source, string message)
        {
            var clr = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OnError: {0}", message);
            Console.ForegroundColor = clr;
        }
    }
}