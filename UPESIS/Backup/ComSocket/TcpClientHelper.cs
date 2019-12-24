using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace ComSocket
{
    public class TcpClientHelper:IDisposable
    {
        TcpClient client;
        NetworkStream netstream;
        string _serverip = "127.0.0.1";
        int _port = 8080;

        TcpCommon tcpCommon = new TcpCommon();

        #region TcpClientHelper constructor
        public TcpClientHelper(string strServerIP, int serverPort)
        {
            _serverip = strServerIP;
            _port = serverPort;

        }
        #endregion

        public void Start()
        {
            client = new TcpClient(_serverip, _port);
            netstream = client.GetStream();
        }

        public void Stop()
        {
            if (netstream != null)
            {
                netstream.Close();
            }

            if (client != null)
            {
                client.Close();
            }
        }

        #region TcpCommon���з���
        public string CalcFileHash(string FilePath)
        {
            return tcpCommon.CalcFileHash(FilePath);
        }

        public bool SendFile(string filePath)
        {
            return tcpCommon.SendFile(filePath, netstream);
        }


        public bool ReceiveFile(string filePath)
        {
            return tcpCommon.ReceiveFile(filePath, netstream);
        }


        public bool SendMessage(TcpPackage tp)
        {
            return tcpCommon.SendMessage(tp, netstream);
        }

        public TcpPackage ReadMessage()
        {
            return tcpCommon.ReadMessage(netstream);
        }
        #endregion

        #region IDisposable ��Ա

        public void Dispose()
        {
            if (netstream != null)
            {
                netstream.Close();
            }

            if (client != null)
            {
                client.Close();
            }
        }

        #endregion
    }
}
