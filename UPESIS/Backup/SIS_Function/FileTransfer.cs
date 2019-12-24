using System;
using System.Collections.Generic;
using System.Text;
using ComSocket;
using System.Windows.Forms;
using System.IO;

namespace SIS_Function
{
    /// <summary>
    /// 文件传输
    /// </summary>
    public class FileTransfer
    {
        /// <summary>
        /// 图片传输（传至LINUX）
        /// </summary>
        private ComSocket.TcpSock Tcpsock = null;
        private string ServerIp;
        private int Port;
        public FileTransfer(string IP, int port)
        {
            this.ServerIp = IP;
            this.Port = port;
            this.Tcpsock = new TcpSock();
            //if (!this.Tcpsock.InitConnect(ServerIp, Port))//IP跟PORT由配置文件取得。
            //    MessageBox.Show("连接服务器出错，请检查网络连接情况！");
        }
        /// <summary>
        /// 建立与服务器的连接
        /// </summary>
        /// <returns></returns>
        public bool ConnServer()
        {
            return this.Tcpsock.InitConnect(this.ServerIp, this.Port);
        }
        /// <summary>
        /// 文件上传 1:上传成功：小于0为上传失败
        /// </summary>
        /// <param name="Serverpath"></param>
        /// <param name="Localpath"></param>
        /// <returns>1:上传成功：小于0为上传失败</returns>
        public int FileUpLoad(string Serverpath, string Localpath)
        {
            ////跟踪坏图
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
            //跟踪坏图
            try
            {
                this.Tcpsock.InitConnect(this.ServerIp, this.Port);//2010-0205添加
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
        /// 文件下载
        /// </summary>
        /// <param name="Serverpath"></param>
        /// <param name="Localpath"></param>
        /// <returns>-1为下载失败</returns>
        public int FileDown(string Serverpath, string Localpath)
        {
            try
            {
                //this.Tcpsock.InitConnect(this.ServerIp, this.Port);//2010-0205添加
                return this.Tcpsock.DownFile(Serverpath, Localpath);
            }
            catch(Exception ex)
            {
                //MessageBox.Show("下载图片出错，原因：网络连接出错或此图片不存在！"+ex.ToString());
                this.Tcpsock.InitConnect(this.ServerIp, this.Port);
                return -1;
            }
        }

        /// <summary>
        /// 查询申请单，返回null为查询出错
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns>返回null为查询出错</returns>
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
       /// 传送报告至慧通HIS：返回1成功，返回其它值为发送不成功
       /// </summary>
       /// <param name="instance_uid">Study_Instance_Uid</param>
        /// <returns>返回1成功，返回其它值为发送不成功</returns>
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
