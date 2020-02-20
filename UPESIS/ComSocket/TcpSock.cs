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
        #region ����
        private string _Type = "R1M";//���͵�ʱ������ R1M R11 �ȣ����յ������޸ģ�����ԭֵ
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
        private string _reserve = "00000000000000000000000000000000000000000000000000";//�����ֶ�
        /// <summary>
        /// ���͵�ʱ������ R1M R11 �ȣ����յ������޸ģ�����ԭֵ
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
        /// ���͵�ʱ�����á�0��,��1�������յ�ʱ���շ��������ؽ������
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
        public bool InitConnect(string IpAddress, int Port)
        {
            try
            {
                client = new TcpClientHelper(IpAddress, Port);
                client.Start();
                if (Oncennected != null)
                {
                    Oncennected();//�����ӻص�
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
        /// һ��һ����
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
        /// һ�Զ�
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
            //MsgToSockCtl(tp);//  �յ����ݰ�������ؼ�����
            //if (OnrcvMany != null)
            //{
            //    OnrcvMany(tp);
            //}
        }
        /// <summary>
        /// �����ļ�
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
        /// ������Ϣ��Ȼ����ݽ��յ�����Ϣ���е�Type�����ص��ĸ�������E11,E1M��EM1
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
                    OnError("�����������������ݰ���");
                    break;
            }
        }
        /// <summary>
        /// ����ʱ�ش����¼�OnSckError
        /// </summary>
        /// <param name="Error">������Ϣ</param>
        private void OnError(string Error)
        {
            if (OnsckError != null)
            {
                OnsckError(Error);
            }
        }
        /// <summary>
        /// ͬ����ʽ��ֱ�ӷ��ͺͽ���һ��Ӧ�����Ӧ��������ĳ���
        /// </summary>
        public void SendAndRcv()
        {

        }
        /// <summary>
        /// �յ����ݰ�����¿ؼ�����
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
        /// �����ļ�:-1Ϊ�ļ������ڣ�1���سɹ���-2Ϊ�����ع��̳��ִ���
        /// </summary>
        /// <param name="serverpath"></param>
        /// <param name="localpath"></param>
        /// <returns>-1Ϊ�ļ������ڣ�1���سɹ���-2Ϊ�����ع��̳��ִ���</returns>
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
                    if (tp.CmdHead == "E00001")//���������޴��ļ�,ɾ�����ؿ��ļ�������-1
                    {
                        fs.Close();
                        File.Delete(localpath);
                        return -1;
                        break;
                    }
                    fs.Write(tp.MsgBuffer, 0, tp.MsgLength);
                    if (tp.Isend == "1")
                    {
                        break;//����
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
        /// ���ر���:-1Ϊ�ļ������ڣ�1���سɹ���-2Ϊ�����ع��̳��ִ���
        /// </summary>
        /// <param name="serverpath"></param>
        /// <param name="localpath"></param>
        /// <returns>-1Ϊ�ļ������ڣ�1���سɹ���-2Ϊ�����ع��̳��ִ���</returns>
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
            tp.ServerType = "DP";//ֻ����PACS
            tp.MsgLength = btPath.Length;
            tp.MsgBuffer = btPath;
            client.SendMessage(tp);
            FileStream fs = new FileStream(localpath, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                while (true)
                {
                    tp = client.ReadMessage();
                    if (tp.CmdHead == "E00001")//���������޴��ļ�,ɾ�����ؿ��ļ�������-1
                    {
                        fs.Close();
                        File.Delete(localpath);
                        return -1;
                        break;
                    }
                    fs.Write(tp.MsgBuffer, 0, tp.MsgLength);
                    if (tp.Isend == "1")
                    {
                        break;//����
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
        /// ��¼������־
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
        /// �ϴ��ļ�:����1Ϊ�ϴ��ɹ�,-2Ϊ�ϴ������г��ִ����籾���ļ�������,�����жϵ��쳣����
        /// </summary>
        /// <param name="serverpath"></param>
        /// <param name="localpath"></param>
        /// <returns></returns>
        public int UpLoadFile(string serverpath, string localpath)
        {
            FileInfo finfo = new FileInfo(localpath);
            if (!finfo.Exists)
            {
                WriteLog(localpath + "������\r\n");
                return -2;
            }
            if (finfo.Length <= 0)
            {
                WriteLog(localpath + "��С��" + finfo.Length.ToString() + "\r\n");
            }
            //if (!File.Exists(localpath))//����ǰ�жϱ����ļ��Ƿ����
            //{
            //    WriteLog(localpath + "������\r\n");
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
        /// ��ѯ���뵥,����ֵnullΪ��ѯ����byte[0]Ϊ������
        /// </summary>
        /// <param name="data">��ѯ����</param>
        /// <returns>��ѯ�����nullΪ��ѯ����</returns>
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
                    if (tp.CmdHead == "E00001")//���������޴��ļ�,ɾ�����ؿ��ļ�������-1
                    {
                        return new byte[0];
                        break;
                    }
                    RcvData = clsDataConvert.Concat(tp.MsgBuffer, RcvData);
                    if (tp.Isend == "1")
                    {
                        break;//����
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
        /// ֪ͨ����˸��¸�Instance_uid�ļ�¼
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
                    if (tp.CmdHead == "E00001")//���������޴��ļ�,ɾ�����ؿ��ļ�������-1
                    {
                        // return new byte[0];
                        return -1;
                        break;
                    }
                    //  RcvData = clsDataConvert.Concat(tp.MsgBuffer, RcvData);
                    if (tp.Isend == "1")
                    {
                        break;//����
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
        #endregion ���з���



        #region �¼�
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
        #endregion �¼�
    }
}
