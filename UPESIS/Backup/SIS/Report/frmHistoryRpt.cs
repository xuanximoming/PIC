using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_Model;
using ILL;
using System.IO;

namespace SIS
{
    public partial class frmHistoryRpt : Form
    {
        private string Pacstemp = Application.StartupPath + "\\Pacstemp\\";
        private WordClass wClass;
        public string CurExamAccessionNum = "";
        public frmHistoryRpt()
        {
            InitializeComponent();
            wClass = new WordClass(this.winWordControl);
            this.Init();
        }

        private void Init()
        {
            string str = GetConfig.RS_HistoryRptLocation;
            if (str == "")
                GetConfig.SetRS_HistoryRptLocation(Location.X.ToString() + "," + Location.Y.ToString() + "," + Size.Width.ToString() + "," + Size.Height.ToString());
            else
            {
                string[] location = str.Split(',');
                this.Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                this.Size = new Size(int.Parse(location[2]), int.Parse(location[3]));
            }
        }

        public int OpenRpt(MReport mReport, string Path)
        {
            this.winWordControl.CloseControl();
            int i = wClass.HistoryWordInit(mReport, Path);
            return i;
        }

        public int OpenRpt(MReport mReport,MStudy mStudy,string Path)
        {
            this.winWordControl.CloseControl();
            if (!Directory.Exists(Pacstemp))
                Directory.CreateDirectory(Pacstemp);
            string TempPath = Pacstemp +DateTime.Now.ToString("yyyyMMddhhmmssFFF")+ mReport.EXAM_NO + ".doc";
                File.Copy(Path, TempPath, true);
            int i = wClass.PacsWordInit(mReport, mStudy, TempPath);
            return i;
        }
        private void frmHistoryRpt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!frmMainForm.isClose)
            {
                this.Hide();
                e.Cancel = true;
            }
            else
            {
                this.winWordControl.QuitWord();
                string location = this.Location.X.ToString() + "," + this.Location.Y.ToString() + "," + this.Size.Width.ToString() + "," + this.Size.Height.ToString();
                GetConfig.SetRS_HistoryRptLocation(location);
            }
        }

        private void frmHistoryRpt_Activated(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}