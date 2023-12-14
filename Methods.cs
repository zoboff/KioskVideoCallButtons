using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VideoSDK
{
    class Methods : VideoSDKMethods_V1
    {
        private VideoSDK m_VideoSDK;

        public Methods(VideoSDK sdk)
        {
            m_VideoSDK = sdk;
        }

        public event EventHandler<string> OnMethodResponse;

        public void ProcessResponse(string response)
        {
            OnMethodResponse?.Invoke(this, response);
        }

        public void call(string trueconf_id)
        {
            string command = "{\"method\": \"call\", \"peerId\": \"" + trueconf_id + "\"}";
            m_VideoSDK.Send(command);
        }

        public void accept()
        {
            string command = "{\"method\": \"accept\"}";
            m_VideoSDK.Send(command);
        }

        public void hangUp(bool forAll = false)
        {
            string command = "{\"method\":\"hangUp\",\"forAll\":" + forAll.ToString().ToLower() + "}";
            m_VideoSDK.Send(command); 
        }

        public void login(string callId, string password)
        {
            string command = "{\"method\" : \"login\", \"login\":\"" + callId + "\", \"password\": \"" + password + "\", \"encryptPassword\": true}";
            m_VideoSDK.Send(command); 
        }

        public void logout()
        {
            string command = "{\"method\": \"logout\"}";
            m_VideoSDK.Send(command);
        }

        public void connectToServer(string server, int port = 4307)
        {
            string command = "{\"method\": \"connectToServer\", \"server\": \"" + server + "\", \"port\": " + port + "}";
            m_VideoSDK.Send(command);
        }
    }
}
