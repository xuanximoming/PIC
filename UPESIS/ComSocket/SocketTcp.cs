using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;//��ɾ
using System.ComponentModel;
using System;

namespace ComSocket
{
    public partial class SocketTcp : Component
    {
        #region ����
        private string _Type;//���͵�ʱ������ R1M R11 �ȣ����յ������޸ģ�����ԭֵ
        private string _isSend;
        private string _serverType;
        private string _sourceIP;
        private int _sequence;
        private string _cmdHead;
        private int _tag;
        private int _msgLength;
        private byte[] _msgBuffer;
        private int _stopFlag;

        //private byte[] _msgbody;
        private string _reserve;//�����ֶ�
        /// <summary>
        /// ���͵�ʱ������ R1M R11 �ȣ����յ������޸ģ�����ԭֵ
        /// </summary>
        public string Type
        {
            set { this._Type = value; }
            get { return this._Type; }
        }
        /// <summary>
        /// ���͵�ʱ�����á�0��,��1�������յ�ʱ���շ��������ؽ������
        /// </summary>
        public string IsSend
        {
            set { this._isSend = value; }
            get { return this._isSend; }
        }
        public string ServerType
        {
            set { this._serverType = value; }
            get { return this._serverType; }
        }
        public string SourceIP
        {
            set { this._sourceIP = value; }
            get { return this._sourceIP; }
        }
        public int Sequence
        {
            set { this._sequence = value; }
            get { return this._sequence; }
        }
        public string CmdHead
        {
            set { this._cmdHead = value; }
            get { return this._cmdHead; }
        }
        public int Tag
        {
            set { this._tag = value; }
            get { return this._tag; }
        }
        public int MsgLength
        {
            set { this._msgLength = value; }
            get { return this._msgLength; }
        }
        public byte[] MsgBuffer
        {
            set { this._msgBuffer = value; }
            get { return this._msgBuffer; }
        }
        public int StopFlag
        {
            set { this._stopFlag = value; }
            get { return this._stopFlag; }
        }

        //public byte[] MsgBody
        //{
        //    set { this._msgbody = value; }
        //    get { return this._msgbody; }
        //}
        //�����ֶ�
        public string Reserve
        {
            set { this._reserve = value; }
            get { return this._reserve; }
        }
        #endregion ����


        #region ���з���
        /// <summary>
        /// ��ʼ�����������׽���
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <param name="Port"></param>
        public void InitConnect(string IpAddress, int Port)
        {
            try
            {
                _Server = new IPEndPoint(Dns.GetHostEntry(IpAddress).AddressList[0], Port);//�����IP/Port
                //IPEndPoint server = new IPEndPoint(Host, Port);
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerSocket.Connect(_Server);
                //if (Oncennected != null)
                //{
                //    Oncennected();
                //}
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
        }
        /// <summary>
        /// һ��һ����
        /// </summary>
        public void SendOne()
        {
            TcpPackage tp = new TcpPackage("YCCOM1.0", "R11", this.IsSend, this.ServerType, this.SourceIP, this.Sequence, this.CmdHead, this.Tag, this.MsgLength, this.Reserve, this.MsgBuffer);
            //this.Send(_Server.Address, _Server.Port, new clsDataConvert().SerializeBinary(tp).ToArray());
            //System.IO.FileStream fs = new System.IO.FileStream("D:\\send.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //byte[] SendData = tp.CreateBuffer();
            //fs.Write(SendData,0,SendData.Length);
            //fs.Close();
            this.Send(_Server.Address, _Server.Port, tp.CreateBuffer());
        }
        /// <summary>
        /// һ�Զ�
        /// </summary>
        /// <param name="data"></param>
        public void SendMany()
        {
            // TcpPackage tp = new TcpPackage("YCCOM1.0", "R1M","0", "DB", Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(), 0, "REGSAV", 4, data.Length, "reserve", data);
            TcpPackage tp = new TcpPackage("YCCOM1.0", "R1M", this.IsSend, this.ServerType, this.SourceIP, this.Sequence, this.CmdHead, this.Tag, this.MsgLength, this.Reserve, this.MsgBuffer);

            this.Send(_Server.Address, _Server.Port, tp.CreateBuffer());
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        public void SendBuffer()
        {
            TcpPackage tp = new TcpPackage("YCCOM1.0", "RM1", this.IsSend, this.ServerType, this.SourceIP, this.Sequence, this.CmdHead, this.Tag, this.MsgLength, this.Reserve, this.MsgBuffer);

            this.Send(_Server.Address, _Server.Port, tp.CreateBuffer());
        }

        /// <summary>
        /// ͬ����ʽ��ֱ�ӷ��ͺͽ���һ��Ӧ�����Ӧ��������ĳ���
        /// </summary>
        public void SendAndRcv()
        {

        }
        #endregion ���з���


        #region �¼�
        public delegate void OncennectedEventHandler();
        public event OncennectedEventHandler Oncennected;

        public delegate void OnrcvOneEventHandler(byte[] data);
        public event OnrcvOneEventHandler OnrcvOne;

        public delegate void OnrcvManyEventHandler(byte[] data);
        public event OnrcvManyEventHandler OnrcvMany;

        public delegate void OnSendMoreEventHandler(byte[] data);
        public event OnSendMoreEventHandler OnSendMore;

        public delegate void OnsckErrorEventHandler(byte[] data);
        public event OnsckErrorEventHandler OnsckError;
        #endregion �¼�
        private Thread ThreadListener;//�����߳�
        private Socket SocketListener;//������������
        private Socket ServerSocket;//��������������
        private Socket ReceiveSocket;//������ϢSOCKET

        public SocketTcp()
        {
            InitializeComponent();
        }

        public SocketTcp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        private IPEndPoint _Server = new IPEndPoint(Dns.GetHostEntry("127.0.0.1").AddressList[0], 8001);//�����IP/Port
        public delegate void DataArrivalEventHandler(byte[] Data, IPAddress Ip, int Port);//ί����Ϣ�����¼�
        public event DataArrivalEventHandler DataArrival;
        public delegate void Sock_ErrorEventHandler(string ErrString);//ί�д����¼�
        public event Sock_ErrorEventHandler Sock_Error;

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="Host"></param>
        /// <param name="Port"></param>
        /// <param name="Data"></param>
        public void Send(System.Net.IPAddress Host, int Port, byte[] Data)
        {
            try
            {
                if (!ServerSocket.Connected)
                {
                    InitConnect(_Server.Address.ToString(), _Server.Port);
                }
                // IPEndPoint server = new IPEndPoint(Host, Port);
                // ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //ServerSocket.Connect(server);
                ServerSocket.Send(Data);
                // ServerSocket.Send(Data, 0, Data.Length, SocketFlags.None);
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
            finally
            {
                //ServerSocket.Close();
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="Port"></param>
        public void Listen(int Port)
        {
            ThreadListener = new Thread(new ThreadStart(StartListen));
            ThreadListener.Start();//�¿�һ���̣߳����ڽ��տͻ��˵�����
            ThreadListener.IsBackground = true;
        }
        /// <summary>
        /// ����
        /// </summary>
        private void StartListen()//��ʼ����������ͻ�������
        {
            try
            {
                SocketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//����������������
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 8001);//��ָ���˿��Ͻ�����������˵㣬�����κ�IP����

                SocketListener.Bind(remoteEP);
                SocketListener.Listen(1024);
                do
                {
                    ReceiveSocket = SocketListener.Accept();//��ʼ������������   
                    //if (ServerSocket != null) ServerSocket.Close();//ֻ����һ��IP����
                    Thread thread = new Thread(new ThreadStart(ServerReceive));
                    thread.IsBackground = true;
                    thread.Start();//��������ʼ������Ϣ
                }
                while (true);
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
        }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        private void ServerReceive()//��������ʼ������Ϣ
        {
            try
            {
                Byte[] rData = new byte[1024 * 1024];
                int Len = 0;
                while ((Len = ReceiveSocket.Receive(rData,512086,SocketFlags.None)) > 0)//���յ���Ϣ
                {
                    string msg = Encoding.Default.GetString(rData,0,Len);
                    byte[] RData=new byte[Len];
                    Array.Copy(rData, RData, Len);
                    TcpPackage tp = new TcpPackage();
                    tp.DeTcpPackage(RData);
                   // TcpPackage tp = new clsDataConvert().DeSerializeBinary((new System.IO.MemoryStream(RData))) as TcpPackage;
                    switch (tp.Type)
                    {
                        case "E11"://һ��һ����
                            if (OnrcvOne != null)
                            {
                                OnrcvOne(RData);
                            }
                            break;
                        case " E1M"://һ�Զ෵��

                            if (OnrcvMany != null)
                            {
                                OnrcvMany(RData);
                            }
                            if (tp.Isend == "0")
                            {
                                CallSendNext(tp);//����������˷���һ�¸���
                            }
                            break;
                        case "RM1"://���һ����
                            if (OnSendMore != null)
                            {
                                OnSendMore(RData);
                                //if (tp.CmdHead.ToLower() == "@next")//�յ�������һ��ָ��
                                //{
                                // SendBuffer();
                                //}
                            }
                            break;
                        default:
                            break;
                    }
                    if (DataArrival != null)
                    {
                        DataArrival(RData, _Server.Address, _Server.Port);
                    }
                }
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
            finally { }
        }
        #region ˽�з���
        /// <summary>
        /// һ�Զ�ʱ�յ����������˷�����һ��
        /// </summary>
        private void CallSendNext(TcpPackage tp)
        {
            TcpPackage tpNext = new TcpPackage("YCCOM1.0", "R1M", "0", tp.ServerType, tp.SourceIP, tp.Sequence + 1, "@NEXT", tp.Tag, 0, this.Reserve,null);
            this.Send(_Server.Address, _Server.Port, tp.CreateBuffer());
        }
        #endregion ˽�з���
        /// <summary>
        /// �Ͽ���������
        /// </summary>

        public void SocketClost()
        {
            Thread.Sleep(30);
            try
            {
                ServerSocket.Close();
                // thdTcp.Abort();
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
        }
    }
}
