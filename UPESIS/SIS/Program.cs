using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SIS
{
    static class Program
    {
        /// <summary>
        /// 应用程序入口，同步锁机制，只允许一个应用程序运行
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool runone;
            Mutex run = new Mutex(true, "SIS", out runone);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (runone) //启动进程时获得互斥体，当前系统没有运行该应用程序进程
            {
                run.ReleaseMutex();//释放互斥体
                ClearTemp();//清除临时文件
                Application.Run(new frmLogin());
            }
            else
            {
                //判断窗体是否在任务栏中，如果不在，先进行杀死进程；再打开登录窗口
                SIS.WinTask winTask = new WinTask();
                if (!winTask.ProcIsIntask("SIS"))
                {
                    winTask.KillProc("SIS");
                    Application.Run(new frmLogin());
                }
                else
                {
                    if (DialogResult.OK == MessageBoxEx.Show("影像工作站已启动,同时开启两个工作站将导致系统某些功能无法正常使用,是否想同时开启两个工作站!",
                        "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        Application.Run(new frmLogin());
                    }
                }
            }
        }

        /// <summary>
        /// 清除所有临时文件
        /// </summary>
        private static void ClearTemp()
        {
            try
            {
                if (System.IO.Directory.Exists(Application.StartupPath + "\\BCIMAGES"))
                    new SIS.FileOperator().DelBakImg(Application.StartupPath + "\\BCIMAGES", DateTime.Now.AddMonths(-1));
                if (System.IO.Directory.Exists(Application.StartupPath + "\\PacsTemp"))
                    Directory.Delete(Application.StartupPath + "\\PacsTemp", true);
                if (System.IO.Directory.Exists(Application.StartupPath + "\\temp"))
                    Directory.Delete(Application.StartupPath + "\\temp", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除临时文件失败!");
            }
        }
    }
}