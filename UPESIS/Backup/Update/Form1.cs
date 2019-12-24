using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Update
{
    public partial class Form1 : Form
    {
        private static string  UpdateIniPath = Application.StartupPath + "\\Update.ini";
        private ClsIni ini;
        private DBControl DBC = new DBControl(new DBGetter().getDatabase());
        private string Program = "PROGRAM";
        private string StartExe = "StartExe";
        private bool Finish = false;
        private string Log = "";

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckIniExist();
            //DBControl DBC = new DBControl(new DBGetter().getDatabase());
            //DataTable dt = new DataTable();
            //dt = DBC.getDataSet("select * from paxdb.PROGRAM_AUTO_UPDATE").Tables[0];
            Thread thd = new Thread(new ThreadStart(RunUpdate));
            thd.IsBackground = true;
            thd.Start();
        }
        private void CheckIniExist()
        {
            //ini.IniWriteValue("File", "File", "file1");
            if (!File.Exists(UpdateIniPath))
            {
                FileStream fs = new FileStream(UpdateIniPath, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();
               // File.Create(UpdateIniPath);
            }
            ini = new ClsIni(UpdateIniPath);
            if (ini.IniReadValue("StartProgram", StartExe) == "" || ini.IniReadValue("StartProgram", StartExe) == null)
            {
                ini.IniWriteValue("Start", StartExe, "SIS.exe");
            }
            if (ini.IniReadValue("UpdateProgram", "ProgramName") == "" || ini.IniReadValue("UpdateProgram", "ProgramName") == null)
            {
                ini.IniWriteValue("UpdateProgram", "ProgramName", "SIS工作站");
            }
        }
        private DataTable GetNewFiles()
        {
            string sql = "select ITEM_NAME,PRODUCT_SERIAL_NUM,FILE_NAME,ITEM_VER,UPDATE_DATE,PATH,ID from PROGRAM_AUTO_UPDATE where ITEM_NAME='" +
                ini.IniReadValue("UpdateProgram", "ProgramName") + "'";
            //string sql = "select ITEM_NAME,PRODUCT_SERIAL_NUM,FILE_NAME,ITEM_VER,UPDATE_DATE,PATH,ID from PROGRAM_AUTO_UPDATE ";

            DataTable dt = DBC.getDataSet(sql).Tables[0];
            return dt;
        }
        private void RunUpdate()
        {
            try
            {
                DataTable dt = GetNewFiles();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string Version = ini.IniReadValue(Program, dt.Rows[i]["FILE_NAME"].ToString());
                        if (Version == "" || Version == null || decimal.Parse(dt.Rows[i]["ITEM_VER"].ToString()) > decimal.Parse(Version))
                        {
                            DownFile(dt.Rows[i]);
                            ini.IniWriteValue(Program, dt.Rows[i]["FILE_NAME"].ToString(), dt.Rows[i]["ITEM_VER"].ToString());
                            string path = Application.StartupPath + "\\" + dt.Rows[i]["PATH"].ToString();
                            string singleLog = string.Format("{0}：文件{1}下载至目录{2}成功", DateTime.Now.ToString(), dt.Rows[i]["FILE_NAME"].ToString(), path);
                            singleLog += System.Environment.NewLine;
                            this.rtb_Info.Text += singleLog;
                            Log += singleLog;
                            
                        }
                    }
                    catch(Exception exx)
                    {
                        string path = Application.StartupPath + "\\" + dt.Rows[i]["PATH"].ToString();
                        string singleLog = string.Format("！{0}：文件{1}下载至目录{2}失败", DateTime.Now.ToString(), dt.Rows[i]["FILE_NAME"].ToString(), path);
                        singleLog+="错误原因：" + exx.ToString() + System.Environment.NewLine;

                        this.rtb_Info.Text += singleLog;
                        Log += singleLog;
                        //this.rtb_Info.Text +=DateTime.Now.ToString()+"：文件" "\r\n";
                        continue;
                    }
                }
            }
            catch(Exception ex)
            {
                string singleLog = string.Format("更新出错：{0}\r\n", ex.ToString());
                this.rtb_Info.Text += singleLog;
                Log += singleLog;
            }
            WriteLog(Log);
            Finish = true;
            this.Close();
            this.Dispose();
        }

        private void WriteLog(string p)
        {
            if (p != "")
            {
                p = DateTime.Now.ToString() + "：更新成功！" + Environment.NewLine;
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\update.log", true, Encoding.Default);
                sw.Write(p);
                sw.Close();
            }
        }

        private void DownFile(DataRow dw)
        {
            string sql = "select PROGRAM from PROGRAM_AUTO_UPDATE where ID="+dw["ID"];
            byte[] bt = (byte[])(DBC.getDataSet(sql).Tables[0].Rows[0][0]);
            string DownPath=Application.StartupPath + "\\" + dw["PATH"].ToString();
            if (!Directory.Exists(DownPath))
            {
                Directory.CreateDirectory(DownPath);
            }
            FileStream fs = new FileStream(DownPath +"\\"+ dw["FILE_NAME"].ToString(), FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(bt,0, bt.Length);
            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Finish)
            {
                string ProName = ini.IniReadValue("Start", StartExe).ToString();
                try
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\" + ProName);
                }
                catch
                {
                    MessageBox.Show("找不文件" + ProName, "提示");
                }
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }

            //MessageBox.Show("");
        }
    }
}