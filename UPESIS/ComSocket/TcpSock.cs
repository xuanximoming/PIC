using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;

namespace ComSocket
{
    public partial class TcpSock : Component
    {
        private static readonly int _blockLength = 1024 * 1024;
        private TcpClientHelper client;
        private Thread thdExec = null;
        public TcpSock()
        {

            InitializeComponent();
            tp = new TcpPackage("YCCOM1.0", Type, Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);

        }

        public TcpSock(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            tp = new TcpPackage("YCCOM1.0", Type, Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);


        }
        #region 属性
        private string _Type = "R1M";//发送的时候设置 R1M R11 等，接收到包不修改，保持原值
        private string _isend = "0";
        private string _serverType = "FL";
        private string _sourceIP = "127.0.0.1";
        private int _sequence = 0;
        private string _cmdHead = "DownFL";
        private int _tag = 0;
        private int _msgLength = 0;
        private byte[] _msgBuffer;
        private int _stopFlag;

        //private byte[] _msgbody;
        private string _reserve = "00000000000000000000000000000000000000000000000000";//保留字段
        /// <summary>
        /// 发送的时候设置 R1M R11 等，接收到包不修改，保持原值
        /// </summary>
        public string Type
        {
            set { this._Type = value; }
            get
            {
                if (this._Type == null)
                {
                    return "R1M";
                }
                else
                {
                    return this._Type;
                }
            }
        }
        /// <summary>
        /// 发送的时候设置’0’,’1’，接收的时候按照服务器返回结果设置
        /// </summary>
        public string Isend
        {
            set { this._isend = value; }
            get { return this._isend; }
        }
        public string ServerType
        {
            set { this._serverType = value; }
            get
            { return this._serverType; }
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
        public bool InitConnect(string IpAddress, int Port)
        {
            try
            {
                client = new TcpClientHelper(IpAddress, Port);
                client.Start();
                if (Oncennected != null)
                {
                    Oncennected();//已连接回调
                }
                return true;
            }
            catch (Exception ex)
            {
                OnError(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 一对一发送
        /// </summary>
        public void SendOne()
        {
            thdExec = new Thread(new ThreadStart(Sendone));
            thdExec.IsBackground = true;
            thdExec.Start();
        }
        private void Sendone()
        {
            tp = new TcpPackage("YCCOM1.0", "R11", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);
            client.SendMessage(tp);
            ReceiveMsg();
            //tp= client.ReadMessage();
            //if (OnrcvOne != null)
            //{
            //    OnrcvOne(tp);
            //}
        }
        /// <summary>
        /// 一对多
        /// </summary>
        /// <param name="data"></param>
        public void SendMany()
        {
            thdExec = new Thread(new ThreadStart(Sendmany));
            thdExec.IsBackground = true;
            thdExec.Start();
        }
        private void Sendmany()
        {
            tp = new TcpPackage("YCCOM1.0", "R1M", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);
            client.SendMessage(tp);
            ReceiveMsg();
            //tp = client.ReadMessage();
            //MsgToSockCtl(tp);//  收到数据包后重设控件属性
            //if (OnrcvMany != null)
            //{
            //    OnrcvMany(tp);
            //}
        }
        /// <summary>
        /// 发送文件
        /// </summary>
        public void SendBuffer()
        {
            thdExec = new Thread(new ThreadStart(Sendbuffer));
            thdExec.IsBackground = true;
            thdExec.Start();
        }
        private void Sendbuffer()
        {
            tp = new TcpPackage("YCCOM1.0", "RM1", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);
            client.SendMessage(tp);
            ReceiveMsg();
            //tp = client.ReadMessage();
            //if (OnSendMore != null)
            //{
            //    OnSendMore(tp);
            //}
        }
        /// <summary>
        /// 接收消息，然后根据接收到的消息包中的Type决定回调哪个函数：E11,E1M，EM1
        /// </summary>
        private void ReceiveMsg()
        {
            tp = client.ReadMessage();
            MsgToSockCtl(tp);
            switch (tp.Type)
            {
                case "E11":
                    if (OnrcvOne != null)
                    {
                        OnrcvOne(tp);
                    }
                    break;
                case "E1M":
                    if (OnrcvMany != null)
                    {

                        OnrcvMany(tp);
                        if (tp.Isend != "1")
                        {
                            this.Sequence++;
                            this.CmdHead = "@NEXT0";
                            this.MsgBuffer = new byte[0];
                            this.MsgLength = 0;
                            Sendmany();
                        }
                    }
                    break;
                case "EM1":
                    if (OnSendMore != null)
                    {
                        OnSendMore(tp);
                    }
                    break;
                default:
                    OnError("收来来历不明的数据包！");
                    break;
            }
        }
        /// <summary>
        /// 出错时回错误事件OnSckError
        /// </summary>
        /// <param name="Error">错误信息</param>
        private void OnError(string Error)
        {
            if (OnsckError != null)
            {
                OnsckError(Error);
            }
        }
        /// <summary>
        /// 同步方式，直接发送和接收一个应答包，应用在特殊的场合
        /// </summary>
        public void SendAndRcv()
        {

        }
        /// <summary>
        /// 收到数据包后更新控件属性
        /// </summary>
        /// <param name="tp"></param>
        private void MsgToSockCtl(TcpPackage tp)
        {
            this.Type = tp.Type;
            this.CmdHead = tp.CmdHead;
            this.Isend = tp.Isend;
            this.Sequence = tp.Sequence;
            this.MsgBuffer = tp.MsgBuffer;
            this.MsgLength = tp.MsgLength;
            this.Tag = tp.Tag;
            this.ServerType = tp.ServerType;
            this.SourceIP = tp.SourceIP;

        }
        public TcpPackage tp = new TcpPackage();
        /// <summary>
        /// 下载文件:-1为文件不存在；1下载成功；-2为出下载过程出现错误
        /// </summary>
        /// <param name="serverpath"></param>
        /// <param name="localpath"></param>
        /// <returns>-1为文件不存在；1下载成功；-2为出下载过程出现错误</returns>
        public int DownFile(string serverpath, string localpath)
        {
            //try
            //{
            tp = new TcpPackage("DCCOM1.0", "R1M", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);


            //try
            //{
            byte[] btPath = Encoding.Default.GetBytes(serverpath);
            //TcpClientHelper client = new TcpClientHelper("172.18.92.116", 1999);
            //client.Start();
            tp.MsgLength = btPath.Length;
            tp.MsgBuffer = btPath;
            client.SendMessage(tp);
            FileStream fs = new FileStream(localpath, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                while (true)
                {
                    tp = client.ReadMessage();
                    if (tp.CmdHead == "E00001")//服务器上无此文件,删除本地空文件并返回-1
                    {
                        fs.Close();
                        File.Delete(localpath);
                        return -1;
                        break;
                    }
                    fs.Write(tp.MsgBuffer, 0, tp.MsgLength);
                    if (tp.Isend == "1")
                    {
                        break;//收完
                    }
                    tp.CmdHead = "@NEXT0";
                    tp.Sequence++;
                    tp.Type = "R1M";
                    tp.MsgBuffer = new byte[0];
                    client.SendMessage(tp);
                }
                fs.Close();
                return 1;
            }
            catch
            {
                fs.Close();
                return -2;
            }
            //}
            //catch
            //{
            //    fs.Close();
            //    return 0;
            //}
            //}
            //catch
            //{
            //    return 2;
            //}
        }

        /// <summary>
        /// 下载报告:-1为文件不存在；1下载成功；-2为出下载过程出现错误
        /// </summary>
        /// <param name="serverpath"></param>
        /// <param name="localpath"></param>
        /// <returns>-1为文件不存在；1下载成功；-2为出下载过程出现错误</returns>
        public int DownReport(string instance_uid, string localpath)
        {
            //try
            //{
            tp = new TcpPackage("YCCOM1.0", "R1M", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);


            //try
            //{
            byte[] btPath = Encoding.Default.GetBytes(instance_uid);
            //TcpClientHelper client = new TcpClientHelper("172.18.92.116", 1999);
            //client.Start();
            tp.CmdHead = "DownRP";
            tp.ServerType = "DP";//只连接PACS
            tp.MsgLength = btPath.Length;
            tp.MsgBuffer = btPath;
            client.SendMessage(tp);
            FileStream fs = new FileStream(localpath, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                while (true)
                {
                    tp = client.ReadMessage();
                    if (tp.CmdHead == "E00001")//服务器上无此文件,删除本地空文件并返回-1
                    {
                        fs.Close();
                        File.Delete(localpath);
                        return -1;
                        break;
                    }
                    fs.Write(tp.MsgBuffer, 0, tp.MsgLength);
                    if (tp.Isend == "1")
                    {
                        break;//收完
                    }
                    tp.CmdHead = "@NEXT0";
                    tp.Sequence++;
                    tp.Type = "R1M";
                    tp.MsgBuffer = new byte[0];
                    client.SendMessage(tp);
                }
                fs.Close();
                return 1;
            }
            catch
            {
                fs.Close();
                return -2;
            }
            //}
            //catch
            //{
            //    fs.Close();
            //    return 0;
            //}
            //}
            //catch
            //{
            //    return 2;
            //}
        }
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="logMsg"></param>
        private void WriteLog(string logMsg)
        {
            try
            {
                if (!Directory.Exists("log"))
                    Directory.CreateDirectory("log");
                StreamWriter sw = new StreamWriter("log\\" + DateTime.Now.ToString("yyyyMMdd") + ".log", true, Encoding.Default);
                sw.Write(logMsg);
                sw.Close();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 上传文件:返回1为上传成功,-2为上传过程中出现错误：如本地文件不存在,传输中断等异常引起
        /// </summary>
        /// <param name="serverpath"></param>
        /// <param name="localpath"></param>
        /// <returns></returns>
        public int UpLoadFile(string serverpath, string localpath)
        {
            FileInfo finfo = new FileInfo(localpath);
            if (!finfo.Exists)
            {
                WriteLog(localpath + "不存在\r\n");
                return -2;
            }
            if (finfo.Length <= 0)
            {
                WriteLog(localpath + "大小：" + finfo.Length.ToString() + "\r\n");
            }
            //if (!File.Exists(localpath))//传输前判断本地文件是否存在
            //{
            //    WriteLog(localpath + "不存在\r\n");
            //    return -2;
            //}
            FileStream fs = new FileStream(localpath, FileMode.Open, FileAccess.Read);
            tp = new TcpPackage("YCCOM1.0", "RM1", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);
            // client.Start();
            tp.CmdHead = "UpFile";
            tp.MsgBuffer = Encoding.Default.GetBytes(serverpath);
            tp.MsgLength = Encoding.Default.GetBytes(serverpath).Length;
            client.SendMessage(tp);
            tp = client.ReadMessage();
            int len = 0;
            byte[] buff = new byte[1024 * 1024];
            //FileStream fs = new FileStream(localpath, FileMode.Open, FileAccess.Read);
            try
            {
                while ((len = fs.Read(buff, 0, 1024 * 1024)) != 0 && tp.CmdHead == "@NEXT0")
                {

                    tp.MsgBuffer = new byte[len];
                    Array.Copy(buff, 0, tp.MsgBuffer, 0, len);
                    tp.MsgLength = len;
                    if (len < _blockLength)
                    {
                        tp.Isend = "1";
                    }
                    client.SendMessage(tp);
                    tp = client.ReadMessage();
                }
                fs.Close();
                return 1;
            }
            catch (Exception ex)
            {
                fs.Close();
                WriteLog(ex.Message.ToString() + "\r\n");
                return -2;
            }
        }
        /// <summary>
        /// 查询申请单,返回值null为查询出错：byte[0]为不存在
        /// </summary>
        /// <param name="data">查询条件</param>
        /// <returns>查询结果，null为查询出错</returns>
        public byte[] QPInfo(byte[] data)
        {
            tp = new TcpPackage("YCCOM1.0", "R1M", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);
            tp.ServerType = "DH";
            byte[] btPath = data;
            tp.MsgLength = btPath.Length;
            tp.MsgBuffer = btPath;
            tp.CmdHead = "QPInfo";
            client.SendMessage(tp);
            byte[] RcvData = new byte[0];
            try
            {
                while (true)
                {
                    tp = client.ReadMessage();
                    if (tp.CmdHead == "E00001")//服务器上无此文件,删除本地空文件并返回-1
                    {
                        return new byte[0];
                        break;
                    }
                    RcvData = clsDataConvert.Concat(tp.MsgBuffer, RcvData);
                    if (tp.Isend == "1")
                    {
                        break;//收完
                    }
                    tp.CmdHead = "@NEXT0";
                    tp.Sequence++;
                    tp.Type = "R1M";
                    tp.MsgBuffer = new byte[0];
                    client.SendMessage(tp);
                }
                return RcvData;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 通知服务端更新该Instance_uid的记录
        /// </summary>
        /// <param name="instance_uid"></param>
        /// <returns></returns>
        public int CmtRpt(string instance_uid)
        {

            tp = new TcpPackage("YCCOM1.0", "R1M", Isend, ServerType, SourceIP, Sequence, CmdHead, Tag, MsgLength, Reserve, MsgBuffer);
            tp.ServerType = "DA";
            byte[] btPath = Encoding.Default.GetBytes(instance_uid);
            tp.MsgLength = btPath.Length;
            tp.MsgBuffer = btPath;
            tp.CmdHead = "CmtRpt";
            client.SendMessage(tp);
            // byte[] RcvData = new byte[0];
            try
            {
                while (true)
                {
                    tp = client.ReadMessage();
                    if (tp.CmdHead == "E00001")//服务器上无此文件,删除本地空文件并返回-1
                    {
                        // return new byte[0];
                        return -1;
                        break;
                    }
                    //  RcvData = clsDataConvert.Concat(tp.MsgBuffer, RcvData);
                    if (tp.Isend == "1")
                    {
                        break;//收完
                    }
                    tp.CmdHead = "@NEXT0";
                    tp.Sequence++;
                    tp.Type = "R1M";
                    tp.MsgBuffer = new byte[0];
                    client.SendMessage(tp);
                }
                // return RcvData;
                return 1;
            }
            catch
            {
                // return null;
                return -1;
            }
        }
        #endregion 公有方法



        #region 事件
        public delegate void OncennectedEventHandler();
        public event OncennectedEventHandler Oncennected;

        public delegate void OnrcvOneEventHandler(TcpPackage tp);
        public event OnrcvOneEventHandler OnrcvOne;

        public delegate void OnrcvManyEventHandler(TcpPackage tp);
        public event OnrcvManyEventHandler OnrcvMany;

        public delegate void OnSendMoreEventHandler(TcpPackage tp);
        public event OnSendMoreEventHandler OnSendMore;

        public delegate void OnsckErrorEventHandler(string Error);
        public event OnsckErrorEventHandler OnsckError;
        #endregion 事件
    }
}
