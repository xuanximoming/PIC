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
                //MessageBox.Show("�Ŷӽк�ϵͳ�������´���" + ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #region �ɰ汾
        //    public CallPatient()
        //    {

        //    }
        //    private TcpClient tcpClient;			//	�������������
        //    private NetworkStream Stream;				//	����������ݽ�������ͨ��
        //    private bool stopFlag = true;				//	�رձ��(����)
        //    private string state = CLOSED;			//  ����״̬
        //    private static string CLOSED = "closed";			//	�ͻ��˵�״̬
        //    private static string CONNECTED = "connected";		//	����״̬
        //    private int ConnectTime = 0;
        //    #region ����
        //    //ServerResponse()�������ڽ��մӷ��������ص���Ϣ��
        //    //���ݲ�ͬ�����ִ����Ӧ�Ĳ���
        //    private void ServerResponse()
        //    {
        //        //����һ��byte���飬���ڽ��մӷ������˷����������ݣ�
        //        //ÿ�����ܽ��յ����ݰ�����󳤶�Ϊ1024���ֽ�
        //        byte[] buff = new byte[1024];
        //        string msg;
        //        int len;

        //        try
        //        {
        //            // ��������ɶ������˳�
        //            if (!Stream.CanRead)
        //            {
        //                return;
        //            }

        //            stopFlag = false;
        //            while (!stopFlag)
        //            {
        //                //�����еõ����ݣ������뵽buff�ַ�������
        //                len = Stream.Read(buff, 0, buff.Length);

        //                // ����С��1 
        //                if (len < 1)
        //                {
        //                    Thread.Sleep(200);
        //                    continue;
        //                }

        //                //���ַ�����ת��Ϊ�ַ���
        //                msg = System.Text.Encoding.Default.GetString(buff, 0, len);
        //                msg.Trim();
        //                string[] tokens = msg.Split(new Char[] { '|' });
        //                //tokens[0]�б����������־����LIST��JOIN��QUIT��

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
        //                    this.state = CONNECTED;  // ��ʾ���ӳɹ�
        //                }
        //                else if (tokens[0] == "QUIT")
        //                {

        //                }
        //                else
        //                {

        //                }
        //            }
        //            //�ر�����
        //            tcpClient.Close();
        //        }
        //        catch
        //        {

        //        }
        //    }

        //    /// <summary>
        //    /// ������Ϣ
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
        //                //MessageBox.Show("����ͨ�ŷ������󣡴�����Ϣ��" + ex.ToString() ,"��ʾ");
        //            }

        //        }
        //    }
        //    //������������ʾ������
        //    private void ConnectServerService()
        //    {
        //        if (state == CONNECTED)
        //        {
        //            return;
        //        }
        //        try
        //        {
        //            //����һ���ͻ����׽��֣�����Login��һ���������ԣ�
        //            //�������ݸ�ChatClient����
        //            tcpClient = new TcpClient();
        //            //��ָ����IP��ַ�ķ�����������������
        //            tcpClient.Connect(IPAddress.Parse("127.0.0.1"),8001);
        //            //�������������ݽ�������ͨ����NetworkStream)
        //            Stream = tcpClient.GetStream();
        //            //����һ���µ��̣߳�ִ�з���this.ServerResponse()��
        //            //�Ա�����Ӧ�ӷ��������ص���Ϣ
        //            Thread thread = new Thread(new ThreadStart(this.ServerResponse));
        //            thread.IsBackground = true;
        //            thread.Start();
        //            string cmd = "CONN|" ;
        //            //���ַ���ת��Ϊ�ַ�����
        //            Byte[] outbytes = System.Text.Encoding.Default.GetBytes(cmd.ToCharArray());
        //            Stream.Write(outbytes, 0, outbytes.Length);

        //            this.state = CONNECTED;
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Console.Write(ex.StackTrace);
        //            MessageBox.Show("����������/��������ʾ����δ��������֪ͨϵͳ����Ա��", "��ʾ");
        //        }
        //    }
        //    #endregion ����

        //}
        //struct CallInfo
        //{
        //    public string PatientName;
        //    public string OrderNo;
        //    public string Group;
        //}
        #endregion �ɰ汾
    }
    public class InfoGetter
    {
        public CallInfo GetInfo(string msg)
        {
            //��Ϊ����������\n������\n�û�ID\n�ͻ���IP\n����ID\n��������\n
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
    /// ������Ϣ
    /// </summary>
    public class CallInfo
    {
        private string userdept = "";
        public string UserDept
        {
            set { this.userdept = value; }
            get { return this.userdept; }
        }
        private string userID = "";//�û�ID
        public string UserID
        {
            set { this.userID = value; }
            get { return this.userID; }
        }
        private string conntype = "";//��Ϣ����
        public string ConnType
        {
            set { this.conntype = value; }
            get { return this.conntype; }
        }
        private string sender_ip = "";   //  ������IP


        private string patientid = "";
        private string patientname = "";
        private string cliniclabel = "";
        private string diagdept = "";
        private double serialno;
        private double nextserialno;
        private string doctor_name = ""; //  ���е�ҽʦ
        private string dept_name = "";   //  ҽʦ���ڿ���
        private string call_room = "";
        private string office = "";					//  ��N���Һ���
        private string queue_name = "";		// ������
        private string nextpatientname = ""; //��һλ��������
        private string rowno = "";			//�к�
        private string passed = "";        //���ű��
        /// <summary>
        /// ���ű��
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
        /// ��ʾ���к�
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
        /// ������
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
        /// ��һλ��������
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
        /// ��N���Һ���
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
        /// ��Ͽ���
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
        /// ��λ���˾����
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
        /// ����ID
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
        /// ��������
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
        /// ��Ͽ�������
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
        /// ��ˮ��
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
        /// ����ҽʦ
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
        /// ����ҽʦ���ڿ�����
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
        /// ���ж�IP
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
        /// ������Ϣ�����ĸ�����
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
        /// ����������ת��Ϊ�ַ���
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // ����ID|��������|�ű�|��ˮ��|ҽʦ��|ҽʦ���ڿ���|������IP
            string temp = this.patientid + "|" + this.patientname + "|" + this.cliniclabel + "|" + this.serialno + "|" + this.doctor_name + "|" + this.dept_name + "|" + this.sender_ip + "|";
            return temp;
        }

    }
}
