using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ComSocket
{
    public class TcpListenerHelper
    {
        private string _strServerIP = "";
        private int _serverPort = 0;

        TcpListener server;
        TcpClient client;
        NetworkStream netstream;
        IAsyncResult asyncResult;
        TcpCommon tcpCommon = new TcpCommon();

        ManualResetEvent listenConnected = new ManualResetEvent(false);

        bool _active = false;

        public TcpListenerHelper(string strServerIP, int serverPort)
        {
            _strServerIP = strServerIP;
            _serverPort = serverPort;
            server = new TcpListener(IPAddress.Parse(strServerIP), serverPort);
            server.Server.ReceiveTimeout = 6000;
            server.Server.SendTimeout = 6000;
        }

        /// <summary>
        /// ����
        /// </summary>
        public void Start()
        {
            try
            {
                _active = true;
                server.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ֹͣ
        /// </summary>
        public void Stop()
        {
            try
            {
                _active = false;
                if (client != null)
                {
                    client.Close();
                }

                if (netstream != null)
                {
                    netstream.Close();
                }
                server.Stop();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Listen()
        {
            Start();//����
            listenConnected.Reset();
            asyncResult = server.BeginAcceptTcpClient(new AsyncCallback(AsyncCall), server);
        }

        public void AsyncCall(IAsyncResult ar)
        {
            try
            {
                TcpListener tlistener = (TcpListener)ar.AsyncState;

                if (_active)
                {
                    client = tlistener.EndAcceptTcpClient(ar);
                    netstream = client.GetStream();
                }
                else
                {
                    client = null;
                    netstream = null;
                }
                listenConnected.Set();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool WaitForConnect()
        {
            listenConnected.WaitOne();

            if (client != null && netstream != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region TcpCommon���з���
        /// <summary>
        /// �����ļ���hashֵ 
        /// </summary>
        public string CalcFileHash(string FilePath)
        {
            return tcpCommon.CalcFileHash(FilePath);
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool SendFile(string filePath)
        {
            return tcpCommon.SendFile(filePath, netstream);
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ReceiveFile(string filePath)
        {
            return tcpCommon.ReceiveFile(filePath, netstream);
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendMessage(TcpPackage tp )
        {
            return tcpCommon.SendMessage(tp, netstream);
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <returns></returns>
        public TcpPackage ReadMessage()
        {
            return tcpCommon.ReadMessage(netstream);
        }
        #endregion

        #region IDisposable ��Ա

        public void Dispose()
        {
            Stop();
        }

        #endregion

    }
}

    

