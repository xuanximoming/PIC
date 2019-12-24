using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;//可删
using System.ComponentModel;
using System;

namespace ComSocket
{
    public partial class SocketTcp : Component
    {
        #region 属性
        private string _Type;//发送的时候设置 R1M R11 等，接收到包不修改，保持原值
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
        private string _reserve;//保留字段
        /// <summary>
        /// 发送的时候设置 R1M R11 等，接收到包不修改，保持原值
        /// </summary>
        public string Type
        {
            set { this._Type = value; }
            get { return this._Type; }
        }
        /// <summary>
        /// 发送的时候设置’0’,’1’，接收的时候按照服务器返回结果设置
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
        //保留字段
        public string Reserve
        {
            set { this._reserve = value; }
            get { return this._reserve; }
        }
        #endregion 属性


        #region 公有方法
        /// <summary>
        /// 初始化主机连接套接字
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <param name="Port"></param>
        public void InitConnect(string IpAddress, int Port)
        {
            try
            {
                _Server = new IPEndPoint(Dns.GetHostEntry(IpAddress).AddressList[0], Port);//服务端IP/Port
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
        /// 一对一发送
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
        /// 一对多
        /// </summary>
        /// <param name="data"></param>
        public void SendMany()
        {
            // TcpPackage tp = new TcpPackage("YCCOM1.0", "R1M","0", "DB", Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(), 0, "REGSAV", 4, data.Length, "reserve", data);
            TcpPackage tp = new TcpPackage("YCCOM1.0", "R1M", this.IsSend, this.ServerType, this.SourceIP, this.Sequence, this.CmdHead, this.Tag, this.MsgLength, this.Reserve, this.MsgBuffer);

            this.Send(_Server.Address, _Server.Port, tp.CreateBuffer());
        }
        /// <summary>
        /// 发送文件
        /// </summary>
        public void SendBuffer()
        {
            TcpPackage tp = new TcpPackage("YCCOM1.0", "RM1", this.IsSend, this.ServerType, this.SourceIP, this.Sequence, this.CmdHead, this.Tag, this.MsgLength, this.Reserve, this.MsgBuffer);

            this.Send(_Server.Address, _Server.Port, tp.CreateBuffer());
        }

        /// <summary>
        /// 同步方式，直接发送和接收一个应答包，应用在特殊的场合
        /// </summary>
        public void SendAndRcv()
        {

        }
        #endregion 公有方法


        #region 事件
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
        #endregion 事件
        private Thread ThreadListener;//侦听线程
        private Socket SocketListener;//网络连接侦听
        private Socket ServerSocket;//服务器网络连接
        private Socket ReceiveSocket;//接收信息SOCKET

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
        private IPEndPoint _Server = new IPEndPoint(Dns.GetHostEntry("127.0.0.1").AddressList[0], 8001);//服务端IP/Port
        public delegate void DataArrivalEventHandler(byte[] Data, IPAddress Ip, int Port);//委托消息到达事件
        public event DataArrivalEventHandler DataArrival;
        public delegate void Sock_ErrorEventHandler(string ErrString);//委托错误事件
        public event Sock_ErrorEventHandler Sock_Error;

        /// <summary>
        /// 发送消息
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
        /// 启动侦听
        /// </summary>
        /// <param name="Port"></param>
        public void Listen(int Port)
        {
            ThreadListener = new Thread(new ThreadStart(StartListen));
            ThreadListener.Start();//新开一个线程，用于接收客户端的连接
            ThreadListener.IsBackground = true;
        }
        /// <summary>
        /// 侦听
        /// </summary>
        private void StartListen()//开始侦听，允许客户端连接
        {
            try
            {
                SocketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//定义网络连接侦听
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 8001);//在指定端口上建立接收网络端点，允许任何IP连接

                SocketListener.Bind(remoteEP);
                SocketListener.Listen(1024);
                do
                {
                    ReceiveSocket = SocketListener.Accept();//开始侦听网络连接   
                    //if (ServerSocket != null) ServerSocket.Close();//只允许一个IP连接
                    Thread thread = new Thread(new ThreadStart(ServerReceive));
                    thread.IsBackground = true;
                    thread.Start();//服务器开始接收信息
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
        /// 接收信息
        /// </summary>
        private void ServerReceive()//服务器开始接收信息
        {
            try
            {
                Byte[] rData = new byte[1024 * 1024];
                int Len = 0;
                while ((Len = ReceiveSocket.Receive(rData,512086,SocketFlags.None)) > 0)//接收到信息
                {
                    string msg = Encoding.Default.GetString(rData,0,Len);
                    byte[] RData=new byte[Len];
                    Array.Copy(rData, RData, Len);
                    TcpPackage tp = new TcpPackage();
                    tp.DeTcpPackage(RData);
                   // TcpPackage tp = new clsDataConvert().DeSerializeBinary((new System.IO.MemoryStream(RData))) as TcpPackage;
                    switch (tp.Type)
                    {
                        case "E11"://一对一返回
                            if (OnrcvOne != null)
                            {
                                OnrcvOne(RData);
                            }
                            break;
                        case " E1M"://一对多返回

                            if (OnrcvMany != null)
                            {
                                OnrcvMany(RData);
                            }
                            if (tp.Isend == "0")
                            {
                                CallSendNext(tp);//申请服务器端发送一下个包
                            }
                            break;
                        case "RM1"://多对一返回
                            if (OnSendMore != null)
                            {
                                OnSendMore(RData);
                                //if (tp.CmdHead.ToLower() == "@next")//收到发送下一个指令
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
        #region 私有方法
        /// <summary>
        /// 一对多时收到后申请服务端发送下一个
        /// </summary>
        private void CallSendNext(TcpPackage tp)
        {
            TcpPackage tpNext = new TcpPackage("YCCOM1.0", "R1M", "0", tp.ServerType, tp.SourceIP, tp.Sequence + 1, "@NEXT", tp.Tag, 0, this.Reserve,null);
            this.Send(_Server.Address, _Server.Port, tp.CreateBuffer());
        }
        #endregion 私有方法
        /// <summary>
        /// 断开网络连接
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
