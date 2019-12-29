using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SIS
{
    static class Program
    {
        /// <summary>
        /// Ӧ�ó�����ڣ�ͬ�������ƣ�ֻ����һ��Ӧ�ó�������
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool runone;
            Mutex run = new Mutex(true, "SIS", out runone);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (runone) //��������ʱ��û����壬��ǰϵͳû�����и�Ӧ�ó������
            {
                run.ReleaseMutex();//�ͷŻ�����
                ClearTemp();//�����ʱ�ļ�
                Application.Run(new frmLogin());
            }
            else
            {
                //�жϴ����Ƿ����������У�������ڣ��Ƚ���ɱ�����̣��ٴ򿪵�¼����
                SIS.WinTask winTask = new WinTask();
                if (!winTask.ProcIsIntask("SIS"))
                {
                    winTask.KillProc("SIS");
                    Application.Run(new frmLogin());
                }
                else
                {
                    if (DialogResult.OK == MessageBoxEx.Show("Ӱ����վ������,ͬʱ������������վ������ϵͳĳЩ�����޷�����ʹ��,�Ƿ���ͬʱ������������վ!",
                        "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        Application.Run(new frmLogin());
                    }
                }
            }
        }

        /// <summary>
        /// ���������ʱ�ļ�
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
                MessageBox.Show("ɾ����ʱ�ļ�ʧ��!");
            }
        }
    }
}