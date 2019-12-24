using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SIS_BLL;
using NEROLib;
using System.IO;
using ILL;
using SIS_Model;


namespace SIS.NeroBurn
{
    public partial class Burn : Form
    {
        private BStudy b_study;
        private BWorkList b_worklist;

        private BImage b_image = new BImage();
        private BInstance b_Instance = new BInstance();
        private BReport b_report = new BReport();
        private FileOperator FileOp = new FileOperator();
        
        
        private Nero m_Nero;
        private NeroDrives m_drives;
        private NeroDrive m_drive;
        private NeroISOTrack isoTrack;

        private _INeroDriveEvents_OnDriveStatusChangedEventHandler m_evDriveStatusChanged;      //设备状态改变时发生
        private _INeroDriveEvents_OnDoneCDInfoEventHandler m_evOnDoneCDInfo;                    //获取完CD信息时发生
        private SIS_Function.ApiIni opini = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");

        public Burn()
        {
            InitializeComponent();
        }

        //绑定性别
        private void Bind_PATIENT_SEX()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("dtl",typeof(string)));
            dt.Columns.Add(new DataColumn ("vwl",typeof(string )));
            DataRow dr1 = dt.NewRow();
            DataRow dr2 = dt.NewRow();

            dr1["dtl"] = "F"; dr1["vwl"] = "女";
            dr2["dtl"] = "M"; dr2["vwl"] = "男";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);

            ((DataGridViewComboBoxColumn)dgv_study.Columns["PATIENT_SEX"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_study.Columns["PATIENT_SEX"]).DisplayMember  = "vwl";
            ((DataGridViewComboBoxColumn)dgv_study.Columns["PATIENT_SEX"]).ValueMember = "dtl";
        }

        private void Burn_Load(object sender, EventArgs e)
        {
             switch (ILL.GetConfig.DALAndModel)
            {
                case "SIS":
                    b_worklist = new BWorkList();
                    break;
                case "PACS":
                    b_study = new BStudy();
                    Bind_PATIENT_SEX();
                    break;
            }

            this.btn_FunName.Text = this.Text.ToString();
            this.dgv_study.AutoGenerateColumns = false;
            dgv_WorkList.AutoGenerateColumns = false;

            cmb_PATIENT_SEX.Items.Add("");
            cmb_PATIENT_SEX.Items.Add("男");
            cmb_PATIENT_SEX.Items.Add("女");

            dtps_STUDY_DATE_TIME.Value = DateTime.Now.AddMonths(-1);
            dtpe_STUDY_DATE_TIME.Value = DateTime.Now;

            int itDay=int.Parse(opini.IniReadValue("NeroBurn", "DefaultDay") );
            dtp_StudyS.Value = DateTime.Now.AddDays(-itDay);
            dtp_Studye.Value = DateTime.Now;

            int VKnameLength = int.Parse(opini.IniReadValue("NeroBurn", "VKdiqit"));
            l_discVolumeKey.Text =opini.IniReadValue("NeroBurn", "VKhead").PadRight(VKnameLength,'0');

            m_Nero = new NeroClass();
             m_drives = ((INero5)m_Nero).GetDrives(NERO_MEDIA_TYPE.NERO_MEDIA_DVD_M);
            for (int i = 0; i < m_drives.Count; i++)
            {
                NeroDrive drive = (NeroDrive)m_drives.Item(i);
                string sDriveLetter = (drive.DriveLetter == "") ? "?" : drive.DriveLetter.ToUpper();
                cmb_BurnDevices.Items.Add(sDriveLetter + ": " + drive.DeviceName);
                cmb_BurnDevices.SelectedIndex = 0;
            }

            GetDiscInfo();
            m_evDriveStatusChanged = new _INeroDriveEvents_OnDriveStatusChangedEventHandler(m_drive_OnDriveStatusChanged);
            m_drive.OnDriveStatusChanged += m_evDriveStatusChanged;
            m_drive.EnableStatusCallback(NERO_DRIVESTATUS_TYPE.NDT_DISC_CHANGE, true);
            m_drive.EnableStatusCallback(NERO_DRIVESTATUS_TYPE.NDT_IN_USE_CHANGE, true);
        }

        private void  FindData( string strDion)
        {
            DataTable dt=new DataTable();
            if (ILL.GetConfig.DALAndModel == "PACS")
            {
                dt = b_study.GetList(strDion.ToString() + "IS_ONLINE=1  order by STUDY_KEY ASC");
                dgv_study.DataSource = dt;
                dgv_study.Visible = true;
                dgv_WorkList.Visible = false;
            }
            else if (ILL.GetConfig.DALAndModel == "SIS")
            {
                dt = b_worklist.GetList(strDion.ToString() + "IS_ONLINE=1 order by EXAM_ACCESSION_NUM ASC");
                dgv_WorkList.DataSource = dt;
                dgv_WorkList.Visible = true;
                dgv_study.Visible = false;
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            StringBuilder sbl = new StringBuilder();

            if (txt_PATIENT_ID.Text.Trim() != "")
                sbl.Append("PATIENT_ID like '%" + txt_PATIENT_ID.Text.Trim() + "%' and ");
            if (txt_PATIENT_NAME.Text.Trim() != "")
                sbl.Append("PATIENT_NAME like '%" + txt_PATIENT_NAME.Text.Trim() + "%' and ");

            if (ILL.GetConfig.DALAndModel == "PACS")
            {
                if (cmb_PATIENT_SEX.Text == "男")
                    sbl.Append("PATIENT_SEX ='M' and ");
                else if (cmb_PATIENT_SEX.Text == "女")
                    sbl.Append("PATIENT_SEX ='F' and ");
            }
            else
                if (cmb_PATIENT_SEX.Text != "")
                    sbl.Append("PATIENT_SEX ='" + cmb_PATIENT_SEX.Text + "' and ");

            if (txt_PATIENT_AGE.Text.Trim() != "")
                sbl.Append("PATIENT_AGE ='" + txt_PATIENT_AGE.Text + "' and ");

            if (dtps_STUDY_DATE_TIME.Checked)
            {
                if (dtpe_STUDY_DATE_TIME.Checked)
                    sbl.Append("STUDY_DATE_TIME between to_date('" + dtps_STUDY_DATE_TIME.Value.ToString() +
                        "','YYYY-MM-DD HH24:MI:SS') AND TO_DATE('" + dtpe_STUDY_DATE_TIME.Value.ToString() + "','YYYY-MM-DD HH24:MI:SS') AND ");
                else
                    sbl.Append("STUDY_DATE_TIME >= to_date('" + dtps_STUDY_DATE_TIME.Value.ToString() + "','YYYY-MM-DD HH24:MI:SS') AND ");
            }
            else
            {
                if (dtpe_STUDY_DATE_TIME.Checked)
                    sbl.Append("STUDY_DATE_TIME <= TO_DATE('" + dtpe_STUDY_DATE_TIME.Value.ToString() + "','YYYY-MM-DD HH24:MI:SS') AND ");
            }

            FindData(sbl.ToString());
        }

        private void dgv_study_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgv_WorkList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            switch (ILL.GetConfig.DALAndModel)
            {
                case "SIS":
                    for (int i=0;i<dgv_WorkList.Rows.Count ;i++)
                    {
                        dgv_WorkList.Rows[i].Cells["IDL"].Value = true;
                    }
                    break;
                case "PACS":
                    for (int i = 0; i < dgv_study.Rows.Count; i++)
                    {
                        dgv_study.Rows[i].Cells["ID"].Value = true;
                    }
                    break;
            }
        }

        private void btn_NotSelectAll_Click(object sender, EventArgs e)
        {
            switch (ILL.GetConfig.DALAndModel)
            {
                case "SIS":
                    for (int i = 0; i < dgv_WorkList.Rows.Count; i++)
                    {
                        dgv_WorkList.Rows[i].Cells["IDL"].Value = false ;
                    }
                    break;
                case "PACS":
                    for (int i = 0; i < dgv_study.Rows.Count; i++)
                    {
                        dgv_study.Rows[i].Cells["ID"].Value = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 获取光盘信息
        /// </summary>
        private void GetDiscInfo()
        {
            m_drive = (NeroDrive)m_drives.Item(cmb_BurnDevices.SelectedIndex);
            if (m_drive != null)
            {
                m_evOnDoneCDInfo = new _INeroDriveEvents_OnDoneCDInfoEventHandler(drive_OnDoneCDInfo);
                m_drive.OnDoneCDInfo += m_evOnDoneCDInfo;
                m_drive.CDInfo(NERO_CDINFO_FLAGS.NERO_READ_CD_TEXT);
            }
        }

        //设备状态改变后发生的事件
        private void m_drive_OnDriveStatusChanged(NERO_DRIVESTATUS_RESULT driveStatus)
        {
            switch (driveStatus)
            {
                case NERO_DRIVESTATUS_RESULT.NDR_DISC_INSERTED:
                    MessageBox.Show("光盘已插入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.b_getDiscInfo_Click(null, null);//调用获取光盘信息的点击事件,可及时触发获取CD信息后发生的事件.
                    break;
                case NERO_DRIVESTATUS_RESULT.NDR_DISC_REMOVED:
                    MessageBox.Show("光盘已弹出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.b_getDiscInfo_Click(null, null);//调用获取光盘信息的点击事件,可及时触发获取CD信息后发生的事件.
                    break;
                case NERO_DRIVESTATUS_RESULT.NDR_DRIVE_IN_USE:
                    //MessageBox.Show("光驱正在使用!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case NERO_DRIVESTATUS_RESULT.NDR_DRIVE_NOT_IN_USE:
                    //MessageBox.Show("光驱未在使用!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("未知状态!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        //获取光盘信息的点击事件
        void b_getDiscInfo_Click(object sender, EventArgs e)
        {
            GetDiscInfo();//调用获取光盘信息的方法
        }

        //获取完CD信息后发生的事件
        private void drive_OnDoneCDInfo(INeroCDInfo pCDInfo)
        {
            m_drive.OnDoneCDInfo -= m_evOnDoneCDInfo;

            this.Cursor = Cursors.Default;
            NeroCDInfo cdInfo = (NeroCDInfo)pCDInfo;
            if (cdInfo != null)
            {
                double discSize = (double)cdInfo.TotalCapacity * (double)2048;
                l_DiscSize.Text = this.FormatFileSize(discSize);           //光盘大小
                string discType = m_Nero.get_TypeNameOfMedia(cdInfo.MediaType);
                this.lb_DiscType.Text = discType;                               //光盘类型
                NERO_MEDIA_TYPE nmt = pCDInfo != null ? pCDInfo.MediaType : NERO_MEDIA_TYPE.NERO_MEDIA_NONE;
                NeroSpeeds speeds = m_drive.get_AvailableSpeeds(NERO_ACCESSTYPE.NERO_ACCESSTYPE_WRITE, nmt);
                foreach (int iSpeed in speeds)
                {
                    float fSpeed = iSpeed / (float)speeds.BaseSpeedKBs;
                    cmb_BurnSpeed.Items.Add( "x (" + iSpeed.ToString() + " kb/s)");
                }
            }
            else
            {
                l_DiscSize.Text = "";
                lb_DiscType.Text = "";
                cmb_BurnSpeed.Items.Clear();
                cmb_BurnSpeed.Text = "";
            }
            txt_PATIENT_NAME.Focus();
        }

        /// <summary>
        /// 格式化文件大小
        /// </summary>
        /// <param name="FileSize"></param>
        /// <returns></returns>
        private string FormatFileSize(double FileSize)
        {
            string formatedSize = "";
            if (FileSize < 1024)
                formatedSize = FileSize.ToString() + " B ";
            else if (FileSize < Math.Pow(1024, 2))
                formatedSize = Convert.ToString(Math.Round(FileSize / 1024, 2)) + " KB";
            else if (FileSize < Math.Pow(1024, 3))
                formatedSize = Convert.ToString(Math.Round(FileSize / 1048576, 2)) + " MB";
            else
                formatedSize = Convert.ToString(Math.Round(FileSize / 1073741824, 2)) + " GB";
            return formatedSize;
        }

        private void btn_SystemSet_Click(object sender, EventArgs e)
        {
            SystemSet vk = new SystemSet();
            vk.ShowDialog();

            int VKnameLength = int.Parse(opini.IniReadValue("NeroBurn", "VKdiqit"));
            l_discVolumeKey.Text = opini.IniReadValue("NeroBurn", "VKhead").PadRight(VKnameLength, '0');

            int itDay = int.Parse(opini.IniReadValue("NeroBurn", "DefaultDay"));
            dtp_StudyS.Value = DateTime.Now.AddDays(-itDay);
        }

        private void btn_PatientPack_Click(object sender, EventArgs e)
        {
            if (l_discVolumeKey.Text.Trim() == "")
            {
                MessageBoxEx.Show("卷标不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isoTrack = new NeroISOTrackClass();
            isoTrack.BurnOptions = (NERO_BURN_OPTIONS)((uint)NERO_BURN_OPTIONS.NERO_BURN_OPTION_CREATE_ISO_FS + (uint)NERO_BURN_OPTIONS.NERO_BURN_OPTION_USE_JOLIET);
            isoTrack.Name = l_discVolumeKey.Text;

            string tpPath = opini.IniReadValue("NeroBurn", "TempDirect");   //下载的文件默认存放的目录
            //下载所选记录的文件到本地
            switch (ILL.GetConfig.DALAndModel)
            {
                case "SIS":
                    if (dgv_WorkList.SelectedRows.Count <= 0)
                    {
                        MessageBoxEx.Show("请选择需要打包的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    GetDownFile_WorkList(null , tpPath);
                    break;
                case "PACS":
                    if (dgv_study.SelectedRows.Count <= 0)
                    {
                        MessageBoxEx.Show("请选择需要打包的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    GetDownFile_Study(null, tpPath);
                    break;
            }
        }

        //超声图片打包下载;如果dt为NULL则说明打包方式为时间打包，否则为病人打包方式
        private void GetDownFile_WorkList(DataTable dt,string lcPath)
        {
            //NeroFolder ParentFloder = null;
            string NowParentDirectNamePath = "";        //当前操作的一级目录路径
            string NowParentDirectName = "";        //当前操作的一级目录名
            string sPath = ILL.GetConfig.ServerImgDir;  //服务器上固定路径前缀
            if (dt == null)
            {
                for  (int i=0;i<dgv_WorkList.Rows.Count;i++)
                {
                    if (dgv_WorkList.Rows[i].Cells["IDL"].Value != null && dgv_WorkList.Rows[i].Cells["IDL"].Value.ToString() == "True")
                    {
                        string ParentDirectName = Convert.ToDateTime(dgv_WorkList.Rows[i].Cells["STUDY_DATETIME"].Value).ToString("yyyyMMdd");
                        if (NowParentDirectName != ParentDirectName)
                        {
                            NowParentDirectName = ParentDirectName;
                            NowParentDirectNamePath = lcPath + "\\" + NowParentDirectName;
                            Directory.CreateDirectory(NowParentDirectNamePath);     //创建一级目录
                        }
                        PackSubFileToISO_WorkList(dgv_WorkList.Rows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString(), NowParentDirectNamePath, sPath);
                    }
                }
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string ParentDirectName = Convert.ToDateTime(dr["STUDY_DATE_TIME"]).ToString("yyyyMMdd");
                    if (NowParentDirectName != ParentDirectName)
                    {
                        NowParentDirectName = ParentDirectName;
                        NowParentDirectNamePath = lcPath + "\\" + NowParentDirectName;
                        Directory.CreateDirectory(NowParentDirectNamePath);     //创建一级目录
                    }
                    PackSubFileToISO_WorkList(dr ["EXAM_ACCESSION_NUM"].ToString(), NowParentDirectNamePath, sPath);
                }
            }
        }

        //获取文件到硬盘
        private void PackSubFileToISO_WorkList(string subFileName, string NowParentDirectNamePath,string ServerPath)
        {
            DataTable ImageDatatable = b_image.GetList(" EXAM_ACCESSION_NUM ='" + subFileName + "'");
            SIS_Function.FileTransfer socket = new SIS_Function.FileTransfer(ILL.GetConfig.ServerIp, ILL.GetConfig.ServerPort);//连接SOCKET

            //创建二级目录
            string NowSubDirectNamePath = NowParentDirectNamePath + "\\" + subFileName;
            Directory.CreateDirectory(NowSubDirectNamePath);
            //NeroFolder subFolder = new NeroFolderClass();
            //ParentFloder.Folders.Add(subFolder);
            //subFolder.Name = studySet.series_instance_uid[j].ToString();
            MReport m_Report = (MReport)b_report.GetModel(subFileName);     //读取WROD报告
            if (m_Report != null)
            FileOp.FileSave(m_Report.REPORT_NAME, NowSubDirectNamePath + "\\" + subFileName + ".DOC");

            for (int i = 0; i < ImageDatatable.Rows.Count; i++)
            {
                string tPath = ImageDatatable.Rows[i]["IMAGE_PATH"].ToString().Replace('/', '\\');
                socket.FileDown(ServerPath + tPath, NowSubDirectNamePath + tPath.Substring(tPath.LastIndexOf('\\'), tPath.Length - tPath.LastIndexOf('\\')));
            }
        }

        //放射图片打包下载;如果dt为NULL则说明打包方式为时间打包
        private void GetDownFile_Study(DataTable dt, string lcPath)
        {
            string NowParentDirectNamePath = "";        //当前操作的一级目录路径
            string NowParentDirectName = "";        //当前操作的一级目录名
            string sPath = ILL.GetConfig.ServerImgDir;  //服务器上固定路径前缀
            if (dt == null)
            {
                for (int i=0;i<dgv_study.Rows.Count;i++)
                {
                    if (dgv_study.Rows[i].Cells["ID"].Value!=null &&dgv_study.Rows[i].Cells["ID"].Value.ToString() == "True")
                    {
                        string ParentDirectName = Convert.ToDateTime(dgv_study.Rows[i].Cells["STUDY_DATE_TIME"].Value).ToString("yyyyMMdd");
                        if (NowParentDirectName != ParentDirectName)
                        {
                            NowParentDirectName = ParentDirectName;
                            NowParentDirectNamePath = lcPath + "\\" + NowParentDirectName;
                            Directory.CreateDirectory(NowParentDirectNamePath);     //创建一级目录
                        }
                        PackSubFileToISO_Study(dgv_study.Rows[i].Cells["STUDY_KEY"].Value.ToString(), NowParentDirectNamePath, sPath);
                    }
                }
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string ParentDirectName = Convert.ToDateTime(dr["STUDY_DATE_TIME"]).ToString("yyyyMMdd");
                    if (NowParentDirectName != ParentDirectName)
                    {
                        NowParentDirectName = ParentDirectName;
                        NowParentDirectNamePath = lcPath + "\\" + NowParentDirectName;
                        Directory.CreateDirectory(NowParentDirectNamePath);     //创建一级目录
                    }
                    PackSubFileToISO_Study(dr["STUDY_KEY"].ToString(), NowParentDirectNamePath, sPath);
                }
            }
        }

        //获取文件到硬盘
        private void PackSubFileToISO_Study(string subFileName, string NowParentDirectNamePath, string ServerPath)
        {
            DataTable ImageDatatable =b_Instance.GetList(" STUDY_KEY ='" + subFileName + "'");
            SIS_Function.FileTransfer socket = new SIS_Function.FileTransfer(ILL.GetConfig.ServerIp, ILL.GetConfig.ServerPort);//连接SOCKET

            //创建二级目录
            string NowSubDirectNamePath = NowParentDirectNamePath + "\\" + subFileName;
            Directory.CreateDirectory(NowSubDirectNamePath);
            //NeroFolder subFolder = new NeroFolderClass();
            //ParentFloder.Folders.Add(subFolder);
            //subFolder.Name = studySet.series_instance_uid[j].ToString();
            PACS_Model.MReport m_Report = (PACS_Model.MReport)b_report.GetModel(subFileName);     //读取WROD报告
            if (m_Report!=null )
                FileOp.FileSave(m_Report.REPORT_NAME, NowSubDirectNamePath + "\\" + subFileName + ".DOC");

            for (int i = 0; i < ImageDatatable.Rows.Count; i++)
            {
                string tPath = ImageDatatable.Rows[i]["PATH_NAME"].ToString().Replace('/', '\\');
                socket.FileDown(ServerPath + tPath, NowSubDirectNamePath + tPath.Substring(tPath.LastIndexOf('\\'), tPath.Length - tPath.LastIndexOf('\\')));
            }
        }

        private void AddFileToISOTrack(ref NeroISOTrack isoTrack, string sPath, NeroFolder folderParent)
        {
            NeroFile file = new NeroFileClass();
            file.SourceFilePath = sPath;
            file.Name = Path.GetFileName(sPath);
            file.EntryTime = Directory.GetLastWriteTime(sPath);
            folderParent.Files.Add(file);
        }

        private void btn_TimePack_Click(object sender, EventArgs e)
        {
            if (l_discVolumeKey.Text.Trim() == "")
            {
                MessageBoxEx.Show("卷标不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isoTrack = new NeroISOTrackClass();
            isoTrack.BurnOptions = (NERO_BURN_OPTIONS)((uint)NERO_BURN_OPTIONS.NERO_BURN_OPTION_CREATE_ISO_FS + (uint)NERO_BURN_OPTIONS.NERO_BURN_OPTION_USE_JOLIET);
            isoTrack.Name = l_discVolumeKey.Text;

            string tpPath = opini.IniReadValue("NeroBurn", "TempDirect");   //下载的文件默认存放的目录
            //下载所选记录的文件到本地
             string sql="STUDY_DATE_TIME between to_date('" + dtp_StudyS.Value.ToString() +
                        "','YYYY-MM-DD HH24:MI:SS') AND TO_DATE('" + dtp_Studye.Value.ToString() + "','YYYY-MM-DD HH24:MI:SS') ";
            switch (ILL.GetConfig.DALAndModel)
            {
                case "SIS":
                    DataTable dt = b_worklist.GetList(sql);
                    if (dt.Rows.Count  <= 0)
                    {
                        MessageBoxEx.Show("未查找到需要打包的数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    GetDownFile_WorkList(dt, tpPath);
                    break;
                case "PACS":
                    DataTable dt1 = b_study.GetList(sql);
                    if (dt1.Rows.Count  <= 0)
                    {
                        MessageBoxEx.Show("未查找到需要打包的数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    GetDownFile_Study(dt1, tpPath);
                    break;
            }
        }

    }
}