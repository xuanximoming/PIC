using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SIS_BLL;
using SIS_Model;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using BaseControls.PictureBoxs;
using BaseControls.Docking;
using ILL;
using System.Runtime.InteropServices;


namespace SIS
{
    public partial class frmReportEdit : Form
    {
        public delegate void PicBoxClick(string nosign, string txt);//ί��:���ڴ���ͼƬ�ĵ����¼�
        private MWorkList MworkList;//WORKLIST model
        private MReport mReport;//����MODEL
        private BReport bReport = new BReport();
        private BWorkList bWorklist = new BWorkList();
        private WordClass word;
        private Thread thdRun;
        private int? ReportStatus = 0;
        private frmQuickQuery frmQuery;

        private frmReportTemp frmTemp;
        public frmRptImages frmRptImg;
        //private frmRegister frmReg;
        private frmExamInf frmExam;
        private frmHistoryExam frmHRpt;
        private frmPacsHistory frmPacsH;
        private frmReportCompare frmEptCmp;
        private frmRecommendation frmRem;
        private frmReportEdit.PicBoxClick picClick;
        private Thread thread;
        public bool isCanOpe = true; //�Ƿ��ܹ���������
        private bool isInit = false;
        private string TempPath = System.Windows.Forms.Application.StartupPath + "\\temp\\report.doc";
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private bool isShowWord = false;  //��ģʽ�Ƿ���WORD
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private DeserializeDockContent m_deserializeDockContent;

        #region ��Ϣ����
        //const int WM_COPYDATA = 0x004A;
        //[StructLayout(LayoutKind.Sequential)]
        //public struct COPYDATASTRUCT
        //{
        //    public IntPtr dwData;
        //    public int cbData;
        //    [MarshalAs(UnmanagedType.LPStr)]
        //    public string lpData;
        //}
        ////����
        //protected override void DefWndProc(ref System.Windows.Forms.Message m)
        //{

        //    switch (m.Msg)
        //    {
        //        case WM_COPYDATA:
        //            COPYDATASTRUCT mystr = new COPYDATASTRUCT();
        //            Type mytype = mystr.GetType();
        //            mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
        //            if (mystr.lpData.ToString() == this.MworkList.EXAM_ACCESSION_NUM)
        //            {
        //                MworkList = (MWorkList)(bWorklist.GetModel(mystr.lpData.ToString()));
        //                word.mWorklist = MworkList;
        //                word.initWorklist();
        //            }
        //            //textBox1.Text =
        //            //m.Result = 1;
        //            break;
        //        default:
        //            base.DefWndProc(ref m);
        //            break;
        //    }
        //}
        #endregion ��Ϣ����

        public frmReportEdit(frmQuickQuery frmQuery)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.frmQuery = frmQuery;
            FrmRptEditInit();
        }
        public frmReportEdit()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            FrmRptEditInit();
        }

        /*��������������������༭�����沼����ʾ*/
        public void FrmRptEditInit()
        {
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            word = new WordClass(this.winWordControl);
            string configFile = Application.StartupPath + "\\Config\\RptDockPanel.config";
            if (!dockPanel.LoadFromXml(configFile, m_deserializeDockContent))
            {


                picClick = new SIS.frmReportEdit.PicBoxClick(PicBox_Click);
                frmTemp = new frmReportTemp(picClick, word);
                frmTemp.Show(this.dockPanel, BaseControls.Docking.DockState.DockLeft);

                frmRptImg = new frmRptImages(word,this.ctms_Tools);
                frmRptImg.panel = this.p_Main;
                frmRptImg.change = new frmRptImages.ChceckChanged(Picture_CheckChanged);
                frmRptImg.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
                frmRptImg.ContextMenuStrip = ctms_Tools;

                frmRem = new frmRecommendation();
                frmRem.panel = this.p_Main;
                frmRem.Show(this.dockPanel, BaseControls.Docking.DockState.DockBottomAutoHide);
                if (GetConfig.RS_HistoryRpt == "PACS")
                {
                    frmPacsH = new frmPacsHistory(picClick);
                    frmPacsH.panel = this.p_Main;
                    frmPacsH.Show(this.dockPanel, BaseControls.Docking.DockState.DockLeft);
                }
                else
                {
                    frmHRpt = new frmHistoryExam(picClick);
                    frmHRpt.panel = this.p_Main;
                    frmHRpt.Show(this.dockPanel, BaseControls.Docking.DockState.DockLeft);
                }

                frmExam = new frmExamInf();
                frmExam.panel = this.p_Main;
                frmExam.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
            }
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            switch (persistString)
            {
                case "SIS.frmReportTemp":
                    picClick = new SIS.frmReportEdit.PicBoxClick(PicBox_Click);
                    frmTemp = new frmReportTemp(picClick, word);

                    return frmTemp;
                case "SIS.frmRptImages":
                    frmRptImg = new frmRptImages(word,this.ctms_Tools);
                    frmRptImg.panel = this.p_Main;
                    frmRptImg.change = new frmRptImages.ChceckChanged(Picture_CheckChanged);
                    return frmRptImg;
                case "SIS.frmExamInf":
                    frmExam = new frmExamInf();
                    frmExam.panel = this.p_Main;
                    frmExam.Show(this.dockPanel, BaseControls.Docking.DockState.DockRightAutoHide);
                    return frmExam;
                case "SIS.frmPacsHistory":
                    picClick = new SIS.frmReportEdit.PicBoxClick(PicBox_Click);
                    frmPacsH = new frmPacsHistory(picClick);
                    frmPacsH.panel = this.p_Main;
                    frmPacsH.Show(this.dockPanel, BaseControls.Docking.DockState.DockLeftAutoHide);
                    return frmPacsH;
                case "SIS.frmHistoryExam":
                    picClick = new SIS.frmReportEdit.PicBoxClick(PicBox_Click);
                    frmHRpt = new frmHistoryExam(picClick);
                    frmHRpt.panel = this.p_Main;
                    frmHRpt.Show(this.dockPanel, BaseControls.Docking.DockState.DockLeftAutoHide);
                    return frmHRpt;
                case "SIS.frmRecommendation":
                    frmRem = new frmRecommendation();
                    frmRem.panel = this.p_Main;
                    frmRem.Show(this.dockPanel, BaseControls.Docking.DockState.DockBottomAutoHide);
                    return frmRem;
                default:
                    return null;
            }
        }
        //���水ģʽ�򿪣�����ͨģʽ��wordģʽ
        public void initForm(MWorkList model, MReport mReport, bool isShowWord)
        {
            //this.Text = string.Format("�������ţ�{0}", model.EXAM_ACCESSION_NUM);
            this.isShowWord = isShowWord;
            this.mReport = mReport;// (MReport)(bReport.GetModel(model.EXAM_ACCESSION_NUM));
            this.winWordControl.QuitWord();
            FileOperator file = new FileOperator();
            file.FilesCopy(Application.StartupPath + "\\ReportCache", Application.StartupPath + "\\temp", true);
            List<ImgObj> arr = file.ArrReportImg(frmMainForm.examInf.ArrayImages, Application.StartupPath + "\\ReportCache", Application.StartupPath + "\\temp");
            this.MworkList = model;
            
            initReport(arr);
        }

        //��ʼ����������
        public void initReport(List<ImgObj> arr)
        {
                     
            this.isInit = true;
            //���Word
            if (!DisplayContent())
                return;

            this.SetPreView();

            CheckRptStatus(arr);

            this.Visible = true;
            //���ر���ģ��
            GetConfig.RS_TempExamClass = this.MworkList.EXAM_CLASS;//���ݴ򿪵���������Ӧ��ģ��
            thread = new Thread(new ThreadStart(frmTemp.RootSearch));
            thread.IsBackground = true;
            thread.Start();

            //���ؼ����Ϣ
            thread = new Thread(new ThreadStart(LoadRegCtl));
            thread.IsBackground = true;
            thread.Start();
            
            //������ʷ����
            //LoadHistoryRpt();
            thread = new Thread(new ThreadStart(LoadHistoryRpt));
            thread.IsBackground = true;
            thread.Start();
            this.isInit = false;
        }

        #region ��ͨģʽ

        private void FillContent(bool ReadOnly)
        {
            this.p_Rpt.Visible = !this.isShowWord;
            this.txt_Description.Text =this.mReport.DESCRIPTION;
            this.txt_ExamPara.Text = this.mReport.EXAM_PARA;
            this.txt_Impression.Text = this.mReport.IMPRESSION;
            this.txt_Recommendation.Text = this.mReport.RECOMMENDATION;
            this.txt_Description.ReadOnly = ReadOnly;
            this.txt_ExamPara.ReadOnly = ReadOnly;
            this.txt_Impression.ReadOnly = ReadOnly;
            this.txt_Recommendation.ReadOnly = ReadOnly;
        }
        private void txt_ExamPara_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.word.Saved = false;
        }

        private void txt_Description_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.word.Saved = false;
        }

        private void txt_Impression_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.word.Saved = false;
        }

        private void txt_Recommendation_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.word.Saved = false;
        }
        #endregion

        private void CheckRptStatus(List<ImgObj> arr)
        {
            string ReportDoctor = MworkList.REPORT_DOCTOR;
            if (MworkList.REPORT_STATUS == 2 || (((SIS_Model.MUser)frmMainForm.iUser).DOCTOR_LEVEL != 9 &&(ReportDoctor != null && ReportDoctor != "" && ReportDoctor != ((SIS_Model.MUser)frmMainForm.iUser).DOCTOR_ID)))//�жϴ򿪱���ҽ���Ƿ���д�����ҽ��
            {
                this.btn_Catch.Enabled = false;
                this.btn_Save.Enabled = false;
                this.frmTemp.isSendToRpt = false;
                this.isCanOpe = false;
                this.tsmi_Delete.Enabled = false;
                this.tsmi_DeleteAll.Enabled = false;
                this.tsmi_Refresh.Enabled = false;
                this.tsmi_Import.Enabled = false;
                this.ReportStatus = -1;//��ʾ�˳����ø��±���״̬
                this.frmRptImg.LoadImages(arr, false, true);
                if (!this.isShowWord)
                    this.FillContent(true);
                else
                    this.p_Rpt.Visible = false;
                this.frmExam.Enabled = false;
            }
            else
            {
                this.btn_Save.Enabled = true;
                this.btn_Catch.Enabled = true;
                this.frmTemp.isSendToRpt = true;
                this.isCanOpe = true;
                this.tsmi_Delete.Enabled = true;
                this.tsmi_DeleteAll.Enabled = true;
                this.tsmi_Refresh.Enabled = true;
                this.tsmi_Import.Enabled = true;
                this.ReportStatus = MworkList.REPORT_STATUS;//�����ʼ��ʱ����״̬
                this.frmRptImg.LoadImages(arr, false, false);
              
                //ChangeReportStatus(2);//�޸�״̬Ϊ���༭
                if (!this.isShowWord)
                    this.FillContent(false);
                else
                    this.p_Rpt.Visible = false;
                this.frmExam.Enabled = true;
            }
            if (this.mReport.RECOMMENDATION != null && this.mReport.RECOMMENDATION != "")
                ShowRecommendation(true);
            else
                ShowRecommendation(false);
        }

        /// <summary>
        /// �޸�WorkList��ReportStatus
        /// </summary>
        /// <param name="status">0����ԤԼ��1���Ѽ�飬2�����༭</param>
        private void ChangeReportStatus(int? status)
        {
            MworkList.REPORT_STATUS = status;
            bWorklist.Update(MworkList, "where EXAM_ACCESSION_NUM='" + MworkList.EXAM_ACCESSION_NUM + "'");
            //MworkList.REPORT_STATUS = ReportStatus;
        }

        private void LoadRegCtl()
        {
            //bool Confirmed = Convert.ToInt32(this.MworkList.IS_CONFIRMED) == 0 ? false : true;
            //bool isSickRoom = false;
            //BPatientSource bPatientSource = new BPatientSource();
            //System.Data.DataTable dt = bPatientSource.GetList("1=1");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (dt.Rows[i]["PATIENT_SOURCE"].ToString() == "����")
            //        isSickRoom = this.MworkList.PATIENT_SOURCE == dt.Rows[i]["PATIENT_SOURCE_ID"].ToString() ? true : false;
            //}
            //if (frmReg == null)
            //{
            //    frmReg = new frmRegister();
            //    frmReg.TopLevel = false;
            //    frmReg.FormBorderStyle = FormBorderStyle.None;
            //    this.tabPage_Reg.Controls.Add(frmReg);
            //    frmReg.Dock = DockStyle.Fill;
            //    frmReg.btn_Back.Visible = false;
            //    frmReg.btn_NewPatientId.Visible = false;
            //    frmReg.btn_SamePatient.Visible = false;
            //    frmReg.btn_New.Visible = false;
            //    frmReg.btn_OpenRpt.Visible = false;
            //    frmReg.Text = "�����Ϣ";
            //    frmReg.Show();
            //}
            //else
            //    frmReg.newReg.NewExam();
            //frmReg.initReg.initMode5(this.MworkList, Confirmed, isSickRoom);
            frmExam.init(this.MworkList, this.mReport, this.word);
        }

         ///<summary>
        /// �޸�Report��PRINT_COUNT
         ///</summary>
        private void SetPrintCount()
        {
            if (mReport.PRINT_COUNT == null)
                mReport.PRINT_COUNT = 1;
            else
                mReport.PRINT_COUNT += 1;
            bReport.Update(mReport, "where EXAM_NO='" + mReport.EXAM_NO + "'");
            //MworkList.REPORT_STATUS = ReportStatus;
        }

        private bool DisplayContent()
        {
            if (word.WordInit(MworkList, mReport, TempPath) == -1)
            {
                MessageBoxEx.Show("�򿪱���ʧ�ܣ������´򿪣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Visible = false;
                return false;
            }
            else
            {
                //this.Visible = true;
                return true;
            }
        }

        /// <summary>
        /// ͼƬ��ʱ����
        /// </summary>
        private void Picture_CheckChanged(userCtrPicture ctr)
        {
            if (this.isInit)
                return;
            //userCtrPicture ctr = (userCtrPicture)sender;
            string FilePath = ctr.FilePath;
            if (!GetConfig.IsAddLocMap)
            {
                if (ctr.GetCheck())
                    word.InsertImg(FilePath);
                else
                    word.DelImg(FilePath);
            }
            else
            {
                if (ctr.GetCheck())
                    word.InsertImgWithLocMap(FilePath, ctr.LocMapPath);
                else
                    word.DelImgWithLocMap(FilePath, ctr.LocMapPath);
            }
        }

        /// <summary>
        /// ͼ�굥��ʱ�ص�����
        /// </summary>
        /// <param name="no"></param>
        private void PicBox_Click(string nodesign, string txt)
        {
            DataTable dt = frmTemp.dtDeptNodes;
            // 1�������,2������,3�������,4��ע
            switch (nodesign.Trim())
            {
                case "1":
                    word.ValueAppend(FieldDict.DESCRIPTION, txt);//�������
                    if (!this.isShowWord)
                        this.txt_Description.Text += txt;
                    break;
                case "2":
                    word.ValueAppend(FieldDict.IMPRESSION, txt);//������
                    if (!this.isShowWord)
                        this.txt_Impression.Text += txt;
                    break;
                case "3":
                    word.ValueAppend(FieldDict.EXAM_PARA, txt);//�������
                    if (!this.isShowWord)
                        this.txt_ExamPara.Text += txt;
                    break;
                case "4":
                    word.ValueAppend(FieldDict.RECOMMENDATION, txt);//��ע
                    if (!this.isShowWord)
                        this.txt_Recommendation.Text += txt;
                    break;
                default:
                    
                    DataRow dw=frmTemp.FindNode(nodesign.Trim());
                    if (dw != null)
                        word.ValueAppend(dw["PRINT_FIELD"].ToString().Trim(), txt);
                    break;
            }
        }

 
        private void frmReportEdit_Load(object sender, EventArgs e)
        {
            clsIme.SetIme(this);
        }

        /// <summary>
        /// ���汨��
        /// </summary>
        private bool SaveReport()
        {
            if (!this.isShowWord)
            {
                word.SetValue(FieldDict.EXAM_PARA, this.txt_ExamPara.Text);
                word.SetValue(FieldDict.DESCRIPTION, this.txt_Description.Text);
                word.SetValue(FieldDict.IMPRESSION, this.txt_Impression.Text);
                word.SetValue(FieldDict.RECOMMENDATION, this.txt_Recommendation.Text);
            }
            string ImgToPaxPaths = "";
            bool isSuccess = false;
            try
            {
                List<ImgObj> arraySaveImg = this.frmRptImg.SaveImgs(ref ImgToPaxPaths);

                // word.SaveDocument("");//�����ĵ�
                MReport mReport = word.GetMReport(TempPath);
                if (this.frmRem != null && this.frmRem.GetRecommendation() != "")
                    mReport.RECOMMENDATION = frmRem.GetRecommendation();
                this.MworkList = frmExam.mworklist;
                this.mReport.IS_ABNORMAL = frmExam.mrpt.IS_ABNORMAL;
                this.mReport.TRANSCRIBER = frmExam.mrpt.TRANSCRIBER;
                SaveReportCls save = new SaveReportCls(MworkList, mReport, arraySaveImg);
                isSuccess = frmExam.Save();
                isSuccess &= save.SaveReport();
                isSuccess &= save.SaveImage(arraySaveImg, MworkList);
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return false; 
            }
            if (ILL.GetConfig.IsConnectPax)
            {
                SendRptToPax SendToPax = new SendRptToPax(MworkList, mReport, ImgToPaxPaths.TrimEnd(';'));//��PACS�ӿڣ�
                if (SendToPax.mStudy.STUDY_INSTANCE_UID != "")
                {
                    sendRptToHT.SendToHT(SendToPax.mStudy.STUDY_INSTANCE_UID);
                }
            }
            this.ReportStatus = 1;
            return isSuccess;
        }
        private SendRptToHT sendRptToHT = new SendRptToHT();//��ͨ����ӿ���

        #region �رմ���

        /// <summary>
        /// �رմ���
        /// </summary>
        private new void Close()
        {
            if (this.btn_Save.Enabled && !word.Saved)
            {
                DialogResult dr = MessageBoxEx.Show("�Ƿ񱣴�?", "��ʾ", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (!SaveReport())
                        {
                            MessageBoxEx.Show("����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (this.ReportStatus != -1)
                                ChangeReportStatus(this.ReportStatus);
                        }
                        else
                            if (this.ReportStatus != -1)
                                ChangeReportStatus(1);
                        break;
                    case DialogResult.No:
                        if (this.ReportStatus != -1)
                            ChangeReportStatus(this.ReportStatus);
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
                if (this.ReportStatus != -1)
                    ChangeReportStatus(this.ReportStatus);
            this.Visible = false;
            if (frmMainForm.myMainForm.iView != null)
                frmMainForm.myMainForm.iView.Hide();
            frmTemp.Exit(true);
            frmRptImg.Exit();
            frmMainForm.myMainForm.Activate();
        }
        #endregion �رմ���

        private void frmReportEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.winWordControl.QuitWord();
            string configFile = Application.StartupPath + "\\Config\\RptDockPanel.config";
            dockPanel.SaveAsXml(configFile);
        }

        private void btn_Catch_Click(object sender, EventArgs e)
        {
            Image img = (Image)frmMainForm.myMainForm.iGather.GetCatch();
            if (img != null)
            {
                img = FileOperator.CutImg(img);
                FileOperator.BackCatchImg(img);
                this.frmRptImg.AddPreferImage(img);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!frmExam.rb_NoAbnormal.Checked && !frmExam.rb_Abnormal.Checked)
            {
                MessageBoxEx.Show("��ѡ�񱨸�������ԣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SaveReport())
            {
                this.frmRptImg.ReLoadImg(MworkList);
                this.ReportStatus = 1;
            }
            else
                MessageBoxEx.Show("���汣��ʧ��,Ϊ��ֹ���ݶ�ʧ,�����±��棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
                this.Close();
                if (frmQuery != null)
                {
                    frmQuery.QueryWorklist();
                    frmQuery.QueueInfoBind();//ˢ���Ŷ���Ϣ
                }
        }


        private void LoadHistoryRpt()
        {
            if (GetConfig.RS_HistoryRpt == "PACS")
            {
                frmPacsH.txt_PatientName.Text = this.MworkList.PATIENT_NAME;
                frmPacsH.FindStudy();
            }
            else
            {
                frmHRpt.txt_PatientId.Text = this.MworkList.PATIENT_ID;
                frmHRpt.FindWorkList();
            }
        }

        private void tsmi_InterestExam_Click(object sender, EventArgs e)
        {
            MInterestPatient mintPat = new MInterestPatient();
            mintPat.DOCTOR_ID = ((MUser)frmMainForm.iUser).DOCTOR_ID;
            mintPat.EXAM_ACCESSION_NUM = this.MworkList.EXAM_ACCESSION_NUM;
            mintPat.PATIENT_ID = this.MworkList.PATIENT_ID;
            mintPat.IS_NOTE = 1;
            BInterestPatient bintPat = new BInterestPatient();
            bintPat.Add(mintPat);
        }

        private void LoadInterest()
        {
            BInterestPatient bintPat = new BInterestPatient();
            DataTable dt = bintPat.GetList(" PARENT_NOTE_ID= 0 and DOCTOR_ID='" + ((MUser)frmMainForm.iUser).DOCTOR_ID + "' Order by NOTE_ID");

        }

        private void btn_Interest_Click(object sender, EventArgs e)
        {
            frmInterestPatientL frmIntPatL = new frmInterestPatientL();
            frmIntPatL.InitForm(MworkList.PATIENT_ID, MworkList.EXAM_ACCESSION_NUM);
            frmIntPatL.Show();
        }

        private void btn_ImgView_Click(object sender, EventArgs e)
        {
            //frmMainForm.myMainForm.iGather.ReSetCard();//����������
            if (frmMainForm.myMainForm.iView == null)
                frmMainForm.myMainForm.iView = new frmImgView();
            frmMainForm.myMainForm.iView.Show();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (this.btn_Save.Enabled && !word.Saved)
            {
                if (SaveReport())
                    this.Print();
                else
                    MessageBoxEx.Show("���汣��ʧ��,Ϊ��ֹ���ݶ�ʧ,�����±��棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                this.Print();
        }
        /// <summary>
        /// ��ӡ
        /// </summary>
        private void Print()
        {
            if (word.PrintDocument() == -1)
                MessageBoxEx.Show("���ô�ӡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (GetConfig.RS_PrintClose)
                {
                    SetPrintCount();
                    if (this.ReportStatus != -1)
                        ChangeReportStatus(1);
                    this.Visible = false;
                    if (frmMainForm.myMainForm.iView != null)
                        frmMainForm.myMainForm.iView.Hide();
                    frmTemp.Exit(true);
                    frmRptImg.Exit();
                    frmMainForm.myMainForm.Activate();
                    if (frmQuery != null)
                        frmQuery.QueryWorklist();
                }
            }
        }

        private void SetPreView()
        {
            if (this.frmExam != null&&!this.frmExam.Visible)
                this.frmExam.Show();
            if (this.frmHRpt != null && !this.frmHRpt.Visible)
                this.frmHRpt.Show();
            if (this.frmPacsH != null && !this.frmPacsH.Visible)
                this.frmPacsH.Show();
            if (this.frmTemp != null && !this.frmTemp.Visible)
                this.frmTemp.Show();
            if (this.frmRptImg != null && !this.frmRptImg.Visible)
                this.frmRptImg.Show();
            this.btn_PreView.Text = "��ӡԤ��";
            word.ClosePreViewDocument();
            if (!this.isShowWord)
                this.p_Rpt.Visible = true;
        }

        //��ӡԤ��
        private void PreView()
        {
            
            if ( word.PreViewDocument() == -1)
                MessageBoxEx.Show("�������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (this.frmExam!=null)
                    this.frmExam.Hide();
                if (this.frmHRpt != null)
                    this.frmHRpt.Hide();
                if (this.frmPacsH != null)
                    this.frmPacsH.Hide();
                if (this.frmTemp != null)
                    this.frmTemp.Hide();
                if (this.frmRptImg != null)
                    this.frmRptImg.Hide();
                this.btn_PreView.Text = "�ر�Ԥ��";
                this.p_Rpt.Visible = false;
                word.SetPreViewPercentage();
            }
            
        }

        private void btn_PreView_Click(object sender, EventArgs e)
        {
            if (this.btn_PreView.Text == "�ر�Ԥ��")
            {
                this.SetPreView();
                return;
            }
            if (!this.isShowWord)//����Ƿ�WORDģʽ����д��WORD�е��ֶ�
            {
                word.SetValue(FieldDict.EXAM_PARA, this.txt_ExamPara.Text);
                word.SetValue(FieldDict.DESCRIPTION, this.txt_Description.Text);
                word.SetValue(FieldDict.IMPRESSION, this.txt_Impression.Text);
                word.SetValue(FieldDict.RECOMMENDATION, this.txt_Recommendation.Text);
            }
            if (this.btn_Save.Enabled && !word.Saved)
            {
                //if (SaveReport())//��ӡԤ���Ƿ񱣴�
                    if (true)
                    PreView();
                else
                    MessageBoxEx.Show("����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                PreView();
        }

        private void frmReportEdit_Activated(object sender, EventArgs e)
        {
            frmMainForm.GatherOrRpt = 1;
            this.BringToFront();
        }

        private void btn_PrintTemplate_Click(object sender, EventArgs e)
        {
            SIS.frmPrintTemplate.Template t = new frmPrintTemplate.Template();
            t.ExamClass = MworkList.EXAM_CLASS;
            t.ExamSubClass = MworkList.EXAM_SUB_CLASS;
            t.TemplateName = mReport.PRINT_TEMPLATE;
            frmPrintTemplate frmPrint = new frmPrintTemplate(t);
            DialogResult dr = frmPrint.ShowDialog();
            if (dr == DialogResult.OK&&frmPrint.mpt!=null)
            {
                //............................
                mReport = word.GetMReport();
                //******************
                mReport.PRINT_TEMPLATE = frmPrint.mpt.PRINT_TEMPLATE;
                mReport.FIELD_INF = frmPrint.mpt.FIELD_INF;
                this.isInit = true;
                //this.frmRptImg.ReSetCheck();
                this.winWordControl.QuitWord();
                FileOperator file = new FileOperator();
                file.FileSave(frmPrint.mpt.FILE_NAME, this.TempPath);
                word.WordInitChange(MworkList, mReport, TempPath);
                initAddImg();
                this.isInit = false;
            }
        }
        //�л�ģ�����ѹ�ͼƬ�����µı�����
        private void initAddImg()
        {

            string str = "";
            List<ImgObj> arraySaveImg = this.frmRptImg.SaveImgs();
            for (int i = 0; i < arraySaveImg.Count; i++)
            {
                ImgObj obj = (ImgObj)arraySaveImg[i];
                if (obj.IsCheck)
                {
                    string FilePath = obj.MarkImgPath!=""?obj.MarkImgPath:obj.ImagePath;
                    if (!GetConfig.IsAddLocMap)
                    {
                        word.InsertImg(FilePath);
                    }
                    else
                    {
                        word.InsertImgWithLocMap(FilePath, obj.LocMapPath);
                    }
                }
            }
        }
        #region ������

        private void tsmi_Explorer_Click(object sender, EventArgs e)
        {
            this.frmRptImg.Explorer();
        }

        private void tsmi_Refresh_Click(object sender, EventArgs e)
        {
            this.frmRptImg.LoadImages(this.frmRptImg.arrayImg, true,!this.isCanOpe);
        }

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            this.frmRptImg.DeleteImage(false);
        }

        private void tsmi_DeleteAll_Click(object sender, EventArgs e)
        {
            this.frmRptImg.DeleteImage(true);
        }

        private void tsmi_Export_Click(object sender, EventArgs e)
        {
            this.frmRptImg.Export();
        }

        private void tsmi_ExportAll_Click(object sender, EventArgs e)
        {
            this.frmRptImg.ExportAll();
        }

        private void tsmi_RptTrack_Click(object sender, EventArgs e)
        {
            if (frmEptCmp == null)
                frmEptCmp = new frmReportCompare();
            frmEptCmp.InitData(MworkList.EXAM_ACCESSION_NUM);
            frmEptCmp.Show();
        }


        private void tsmi_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.Filter = "Jpeg�ļ�(*.jpg)|*.jpg";
            if (op.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < op.FileNames.Length; i++)
                {
                    if (op.FileNames[i].Substring(op.FileNames[i].LastIndexOf('.')).ToLower() == ".jpg")
                    {
                        Image img = Image.FromFile(op.FileNames[i]);
                        frmRptImg.AddPreferImage(img);
                    }
                }
            }
        }
        #endregion

        private void ShowRecommendation(bool isShow)
        {
            frmRem.init(this.mReport.RECOMMENDATION);
            if (isShow)
                frmRem.Show();
            else
                frmRem.Hide();
        }

        private void tsmi_ShowRecommendation_Click(object sender, EventArgs e)
        {
            ShowRecommendation(true);
        }

        private void toolStrip_InitCard_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.iGather.ReSetCard();
            this.btn_ImgView_Click(null, null);
            
        }
        //��ӡ��ͼ����
        private void btn_Print2_Click(object sender, EventArgs e)
        {
            PrintDelImg();
        }
        //��ӡ��ͼ
        private void PrintDelImg()
        {
            string str = "";
            List<ImgObj> arraySaveImg = this.frmRptImg.SaveImgs();
            for (int i = 0; i < arraySaveImg.Count; i++)
            {
                ImgObj obj = (ImgObj)arraySaveImg[i];
                if (obj.IsCheck)
                {
                    string FilePath = obj.MarkImgPath != "" ? obj.MarkImgPath : obj.ImagePath;
                    if (!GetConfig.IsAddLocMap)
                    {
                        // word.InsertImg(FilePath);
                        word.DelImg(FilePath);
                    }
                    else
                    {
                        // word.InsertImgWithLocMap(FilePath, obj.LocMapPath);
                        word.DelImgWithLocMap(FilePath, obj.LocMapPath);
                    }
                }
            }
            //this.Print();
            word.PrintDocument();
            initAddImg();
        }

        private void tsmi_DelPicPrint_Click(object sender, EventArgs e)
        {
            PrintDelImg();
        }

        private void tsmi_Print_Click(object sender, EventArgs e)
        {
            btn_Print_Click(null, null);
        }
    }
}