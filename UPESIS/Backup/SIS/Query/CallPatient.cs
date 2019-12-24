using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using TcpHelper;
using System.Windows.Forms;

namespace SIS
{
    public class CallPatient
    {
        public CallPatient()
        {
            
        }
        public int Send(IModel iQinfo)
        {
            return SendMessage(CreateMsg(iQinfo));
        }
        private string CreateMsg(IModel iQinfo)
        {
            if (ILL.GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MQueueInfo mQinfo = (SIS_Model.MQueueInfo)iQinfo;
                CallInfo info = new CallInfo();
                info.ConnType = "CONTENT";
                info.QueueName = mQinfo.QUEUE_NAME;
                info.UserID = System.Environment.MachineName.ToString();
                info.SenderIp = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
                info.PatientID = mQinfo.PATIENT_ID;
                info.PatientName = mQinfo.PATIENT_NAME; ;
                info.Office = "";
                info.CallRoom = "";
                info.ClinicLabel = mQinfo.CLINIC_LABLE;
                info.NextPatientName = "";
                info.Passed = mQinfo.PASSED.ToString();
                return (new InfoGetter().SetInfo(info));

            }
            else
            {
                PACS_Model.MQueueInfo mQinfo = (PACS_Model.MQueueInfo)iQinfo;
                CallInfo info = new CallInfo();
                info.ConnType = "CONTENT";
                info.QueueName = mQinfo.QUEUE_NAME;
                info.UserID = System.Environment.MachineName.ToString();
                info.SenderIp = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
                info.PatientID = mQinfo.PATIENT_ID;
                info.PatientName = mQinfo.PATIENT_NAME; ;
                info.Office = "";
                info.CallRoom = "";
                info.ClinicLabel = mQinfo.CLINIC_LABLE;
                info.NextPatientName = "";
                info.Passed = mQinfo.PASSED.ToString();
                return (new InfoGetter().SetInfo(info));
            }

            //string msg = "";
            //msg += mQinfo.EXAM_ACCESSION_NUM + "|";
            //msg += mQinfo.PATIENT_NAME + "|";
            //msg += mQinfo.QUEUE_NAME;
            //return msg;
        }
        public int SendMessage(string Msg)
        {
            TcpClientHelper client = new TcpClientHelper(ILL.GetConfig.CallServIp, ILL.GetConfig.CallServPort);
            try
            {
                client.Start();
                client.SendMessage(Msg);
                return 1;
            }
            catch 
            {
                return -1;
                //MessageBox.Show("排队叫号系统出现如下错误：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #region 旧版本
        //    public CallPatient()
        //    {

        //    }
        //    private TcpClient tcpClient;			//	与服务器的连接
        //    private NetworkStream Stream;				//	与服务器数据交互的流通道
        //    private bool stopFlag = true;				//	关闭标记(连接)
        //    private string state = CLOSED;			//  连接状态
        //    private static string CLOSED = "closed";			//	客户端的状态
        //    private static string CONNECTED = "connected";		//	连接状态
        //    private int ConnectTime = 0;
        //    #region 服务
        //    //ServerResponse()方法用于接收从服务器发回的信息，
        //    //根据不同的命令，执行相应的操作
        //    private void ServerResponse()
        //    {
        //        //定义一个byte数组，用于接收从服务器端发送来的数据，
        //        //每次所能接收的数据包的最大长度为1024个字节
        //        byte[] buff = new byte[1024];
        //        string msg;
        //        int len;

        //        try
        //        {
        //            // 如果流不可读，就退出
        //            if (!Stream.CanRead)
        //            {
        //                return;
        //            }

        //            stopFlag = false;
        //            while (!stopFlag)
        //            {
        //                //从流中得到数据，并存入到buff字符数组中
        //                len = Stream.Read(buff, 0, buff.Length);

        //                // 内容小于1 
        //                if (len < 1)
        //                {
        //                    Thread.Sleep(200);
        //                    continue;
        //                }

        //                //将字符数组转化为字符串
        //                msg = System.Text.Encoding.Default.GetString(buff, 0, len);
        //                msg.Trim();
        //                string[] tokens = msg.Split(new Char[] { '|' });
        //                //tokens[0]中保存了命令标志符（LIST或JOIN或QUIT）

        //                if (tokens[0].ToUpper() == "OK")
        //                {
        //                    this.state = CONNECTED;
        //                }
        //                else if (tokens[0].ToUpper() == "ERR")
        //                {
        //                }
        //                else if (tokens[0].ToUpper() == "ISREG")
        //                {
        //                    this.state = CONNECTED;
        //                }
        //                else if (tokens[0] == "JOIN")
        //                {
        //                    this.state = CONNECTED;  // 表示连接成功
        //                }
        //                else if (tokens[0] == "QUIT")
        //                {

        //                }
        //                else
        //                {

        //                }
        //            }
        //            //关闭连接
        //            tcpClient.Close();
        //        }
        //        catch
        //        {

        //        }
        //    }

        //    /// <summary>
        //    /// 发送信息
        //    /// </summary>
        //    private void SendMessage()
        //    {
        //        try
        //        {
        //           // if (curpatient == null) return;
        //            string message = "CONTENT|";
        //            Byte[] outbytes = System.Text.Encoding.Default.GetBytes(message.ToCharArray());
        //           // this.backcall = curpatient;
        //            Stream.Write(outbytes, 0, outbytes.Length);

        //        }
        //        catch (Exception ex)
        //        {
        //            if (ConnectTime < 1)
        //            {
        //                ConnectTime++;
        //                this.state = CLOSED;
        //                ConnectServerService();
        //                SendMessage();
        //                //MessageBox.Show("网络通信发生错误！错误信息：" + ex.ToString() ,"提示");
        //            }

        //        }
        //    }
        //    //连接语音及显示服务器
        //    private void ConnectServerService()
        //    {
        //        if (state == CONNECTED)
        //        {
        //            return;
        //        }
        //        try
        //        {
        //            //创建一个客户端套接字，它是Login的一个公共属性，
        //            //将被传递给ChatClient窗体
        //            tcpClient = new TcpClient();
        //            //向指定的IP地址的服务器发出连接请求
        //            tcpClient.Connect(IPAddress.Parse("127.0.0.1"),8001);
        //            //获得与服务器数据交互的流通道（NetworkStream)
        //            Stream = tcpClient.GetStream();
        //            //启动一个新的线程，执行方法this.ServerResponse()，
        //            //以便来响应从服务器发回的信息
        //            Thread thread = new Thread(new ThreadStart(this.ServerResponse));
        //            thread.IsBackground = true;
        //            thread.Start();
        //            string cmd = "CONN|" ;
        //            //将字符串转化为字符数组
        //            Byte[] outbytes = System.Text.Encoding.Default.GetBytes(cmd.ToCharArray());
        //            Stream.Write(outbytes, 0, outbytes.Length);

        //            this.state = CONNECTED;
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Console.Write(ex.StackTrace);
        //            MessageBox.Show("服务器语音/等离子显示服务未启动，请通知系统管理员！", "提示");
        //        }
        //    }
        //    #endregion 服务

        //}
        //struct CallInfo
        //{
        //    public string PatientName;
        //    public string OrderNo;
        //    public string Group;
        //}
        #endregion 旧版本
    }
    public class InfoGetter
    {
        public CallInfo GetInfo(string msg)
        {
            //串为：连接类型\n队列名\n用户ID\n客户端IP\n病人ID\n病人姓名\n
            CallInfo info = new CallInfo();
            string[] Field = msg.Split('\n');
            info.ConnType = Field[0];
            info.QueueName = Field[1];
            info.UserID = Field[2];
            info.SenderIp = Field[3];
            info.PatientID = Field[4];
            info.PatientName = Field[5];
            info.Office = Field[6];
            info.CallRoom = Field[7];
            info.ClinicLabel = Field[8];
            info.NextPatientName = Field[9];
            info.Passed = Field[10];
            //info.
            return info;
        }
        public string SetInfo(CallInfo info)
        {
            string Msg = "";
            string SplitChar = "\n";
            Msg += info.ConnType + SplitChar;
            Msg += info.QueueName + SplitChar;
            Msg += info.UserID + SplitChar;
            Msg += info.SenderIp + SplitChar;
            Msg += info.PatientID + SplitChar;
            Msg += info.PatientName + SplitChar;
            Msg += info.Office + SplitChar;
            Msg += info.CallRoom + SplitChar;
            Msg += info.ClinicLabel + SplitChar;
            Msg += info.NextPatientName + SplitChar;
            Msg += info.Passed + SplitChar;
            return Msg;
        }
    }
    /// <summary>
    /// 病人信息
    /// </summary>
    public class CallInfo
    {
        private string userdept = "";
        public string UserDept
        {
            set { this.userdept = value; }
            get { return this.userdept; }
        }
        private string userID = "";//用户ID
        public string UserID
        {
            set { this.userID = value; }
            get { return this.userID; }
        }
        private string conntype = "";//消息类型
        public string ConnType
        {
            set { this.conntype = value; }
            get { return this.conntype; }
        }
        private string sender_ip = "";   //  发送者IP


        private string patientid = "";
        private string patientname = "";
        private string cliniclabel = "";
        private string diagdept = "";
        private double serialno;
        private double nextserialno;
        private string doctor_name = ""; //  呼叫的医师
        private string dept_name = "";   //  医师所在科室
        private string call_room = "";
        private string office = "";					//  第N诊室呼叫
        private string queue_name = "";		// 队列名
        private string nextpatientname = ""; //下一位病人姓名
        private string rowno = "";			//行号
        private string passed = "";        //过号标记
        /// <summary>
        /// 过号标记
        /// </summary>
        public string Passed
        {
            get
            {
                return this.passed;
            }
            set
            {
                this.passed = value;
            }
        }


        /// <summary>
        /// 显示的行号
        /// </summary>
        public string Row_No
        {
            get
            {
                return this.rowno;
            }
            set
            {
                this.rowno = value;
            }
        }


        /// <summary>
        /// 队列名
        /// </summary>
        public string QueueName
        {
            get
            {
                return this.queue_name;
            }
            set
            {
                this.queue_name = value;
            }
        }
        /// <summary>
        /// 下一位病人姓名
        /// </summary>
        public string NextPatientName
        {
            get
            {
                return this.nextpatientname;
            }
            set
            {
                this.nextpatientname = value;
            }
        }

        /// <summary>
        /// 第N诊室呼叫
        /// </summary>
        public string Office
        {
            get
            {
                return this.office;
            }
            set
            {
                this.office = value;
            }
        }

        /// <summary>
        /// 诊断科室
        /// </summary>
        public string DiagDept
        {
            get
            {
                return this.diagdept;
            }
            set
            {
                this.diagdept = value;
            }
        }

        /// <summary>
        /// 下位病人就诊号
        /// </summary>
        public double NextSerialNo
        {
            get
            {
                return this.nextserialno;
            }
            set
            {
                this.nextserialno = value;
            }
        }

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID
        {
            get
            {
                return this.patientid;
            }
            set
            {
                this.patientid = value;
            }
        }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get
            {
                return this.patientname;
            }
            set
            {
                this.patientname = value;
            }
        }

        /// <summary>
        /// 诊断科室名称
        /// </summary>
        public string ClinicLabel
        {
            get
            {
                return this.cliniclabel;
            }
            set
            {
                this.cliniclabel = value;
            }
        }

        /// <summary>
        /// 流水号
        /// </summary>
        public double SerialNo
        {
            get
            {
                return this.serialno;
            }
            set
            {
                this.serialno = value;
            }
        }

        /// <summary>
        /// 呼叫医师
        /// </summary>
        public string DoctorName
        {
            get
            {
                return this.doctor_name;
            }
            set
            {
                this.doctor_name = value;
            }
        }

        /// <summary>
        /// 呼叫医师所在科室名
        /// </summary>
        public string DeptName
        {
            get
            {
                return this.dept_name;
            }
            set
            {
                this.dept_name = value;
            }
        }

        /// <summary>
        /// 呼叫端IP
        /// </summary>
        public string SenderIp
        {
            get
            {
                return this.sender_ip;
            }
            set
            {
                this.sender_ip = value;
            }
        }

        /// <summary>
        /// 呼叫信息来自哪个房间
        /// </summary>
        public string CallRoom
        {
            get
            {
                return this.call_room;
            }
            set
            {
                this.call_room = value;
            }
        }



        /// <summary>
        /// 把所有内容转化为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // 病人ID|病人姓名|号别|流水号|医师名|医师所在科室|发送者IP
            string temp = this.patientid + "|" + this.patientname + "|" + this.cliniclabel + "|" + this.serialno + "|" + this.doctor_name + "|" + this.dept_name + "|" + this.sender_ip + "|";
            return temp;
        }

    }
}
