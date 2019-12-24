using System;
using System.Collections.Generic;
using System.Text;
using ComSocket;
using System.Windows.Forms;
using System.IO;

namespace SIS_Function
{
    /// <summary>
    /// �ļ�����
    /// </summary>
    public class FileTransfer
    {
        /// <summary>
        /// ͼƬ���䣨����LINUX��
        /// </summary>
        private ComSocket.TcpSock Tcpsock = null;
        private string ServerIp;
        private int Port;
        public FileTransfer(string IP, int port)
        {
            this.ServerIp = IP;
            this.Port = port;
            this.Tcpsock = new TcpSock();
            //if (!this.Tcpsock.InitConnect(ServerIp, Port))//IP��PORT�������ļ�ȡ�á�
            //    MessageBox.Show("���ӷ��������������������������");
        }
        /// <summary>
        /// �����������������
        /// </summary>
        /// <returns></returns>
        public bool ConnServer()
        {
            return this.Tcpsock.InitConnect(this.ServerIp, this.Port);
        }
        /// <summary>
        /// �ļ��ϴ� 1:�ϴ��ɹ���С��0Ϊ�ϴ�ʧ��
        /// </summary>
        /// <param name="Serverpath"></param>
        /// <param name="Localpath"></param>
        /// <returns>1:�ϴ��ɹ���С��0Ϊ�ϴ�ʧ��</returns>
        public int FileUpLoad(string Serverpath, string Localpath)
        {
            ////���ٻ�ͼ
            //try
            //{
            //    System.IO.FileInfo f = new System.IO.FileInfo(Localpath);
            //    if (!f.Exists || f.Length < 100)
            //    {
            //        WriteLog(Localpath +"Exist:"+f.Exists.ToString()+";length:"+f.Length.ToString()+ "\r\n");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    WriteLog(ex.Message.ToString() + "\r\n");
            //}
            //���ٻ�ͼ
            try
            {
                this.Tcpsock.InitConnect(this.ServerIp, this.Port);//2010-0205���
                return this.Tcpsock.UpLoadFile(Serverpath, Localpath);
            }
            catch
            {
                return -1;
            }
        }
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
        /// �ļ�����
        /// </summary>
        /// <param name="Serverpath"></param>
        /// <param name="Localpath"></param>
        /// <returns>-1Ϊ����ʧ��</returns>
        public int FileDown(string Serverpath, string Localpath)
        {
            try
            {
                //this.Tcpsock.InitConnect(this.ServerIp, this.Port);//2010-0205���
                return this.Tcpsock.DownFile(Serverpath, Localpath);
            }
            catch(Exception ex)
            {
                //MessageBox.Show("����ͼƬ����ԭ���������ӳ�����ͼƬ�����ڣ�"+ex.ToString());
                this.Tcpsock.InitConnect(this.ServerIp, this.Port);
                return -1;
            }
        }

        /// <summary>
        /// ��ѯ���뵥������nullΪ��ѯ����
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns>����nullΪ��ѯ����</returns>
        public byte[] QPInfo(byte[] Condition)
        {
            try
            {
                this.Tcpsock.InitConnect(this.ServerIp, this.Port);
                return Tcpsock.QPInfo(Condition);
            }
            catch
            {
                return null;
            }
        }
       /// <summary>
       /// ���ͱ�������ͨHIS������1�ɹ�����������ֵΪ���Ͳ��ɹ�
       /// </summary>
       /// <param name="instance_uid">Study_Instance_Uid</param>
        /// <returns>����1�ɹ�����������ֵΪ���Ͳ��ɹ�</returns>
        public int CmtRpt(string instance_uid)
        {
            try
            {
                if (instance_uid == "")
                    return -1;
                this.Tcpsock.InitConnect(this.ServerIp, this.Port);
                return Tcpsock.CmtRpt(instance_uid);
            }
            catch
            {
                return -1;
            }
        }
    }
}
