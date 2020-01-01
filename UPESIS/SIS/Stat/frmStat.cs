using CrystalDecisions.CrystalReports.Engine;
using ILL;
using SIS_BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SIS
{
    public partial class frmStat : Form
    {
        private string queryDate, queryExamDoc, queryExamClass, queryDeptName, queryPatientSource, queryDiag, queryDoctor, queryAbnormal;
        private string initSql, initDept;		//查询条件
        private System.Data.DataSet queryDs;//查询数据集
        private System.Data.DataSet initDs;		//初始数据集
        private ReportDocument rep;		//报表容器
        private int selectId;			//选择顺序号
        private BClinicOfficeDict bClinicOfficeDict = new BClinicOfficeDict();
        private BStat bStat = new BStat();
        private BExamClass bExamClass = new BExamClass();
        private BQueueInfo bQueueInfo = new BQueueInfo();
        private BUser bUser = new BUser();
        private DataTable dt;
        private string path = Application.StartupPath + "\\CrystalReports\\";


        public frmStat()
        {
            InitializeComponent();
            try
            {
                initData();	//初始化数据
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.ToString());
            }
        }

        // 初始化数据
        private void initData()
        {
            IModel user = (IModel)frmMainForm.iUser;
            this.date_StatA.Text = System.DateTime.Now.AddDays(-30).ToShortDateString();
            this.date_StatB.Text = System.DateTime.Now.ToShortDateString();
            this.initDeptName();//初始化影像科室 
            this.initExamDoctor();     //诊断医生初始化
            this.initDiagDept(); //诊室列表初始化
            this.clearPanel();//隐藏统计条件容器
            this.initPatientSource();//初始化病人来源
            this.initExamDoc();//初始化检查技师
            this.rep = new ReportDocument();
            this.list_Stat.SelectedIndex = 0;
        }

        //影像科室初始化
        private void initDeptName()
        {
            this.cmb_DeptName.Items.Clear();
            if (GetConfig.IsSelectDB.ToUpper() == "YES")
            {
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        this.initSql = " clinic_office_flag = 'RY' ";
                        break;
                    case "PACS":
                        this.initSql = " dept_area = 'RY' ";
                        break;
                }

                this.initDs = bClinicOfficeDict.GetData(this.initSql);//从用户科室表中查询科室名
                this.cmb_DeptName.DataSource = this.initDs.Tables[0].DefaultView;
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        this.cmb_DeptName.DisplayMember = "clinic_office";
                        this.cmb_DeptName.ValueMember = "clinic_office_code";
                        break;
                    case "PACS":
                        this.cmb_DeptName.DisplayMember = "dept_name";
                        this.cmb_DeptName.ValueMember = "dept_code";
                        break;
                }

            }
            else
            {
                string ExamDeptName = GetConfig.ExamDeptName;
                string ExamDeptCode = GetConfig.ExamDeptCode;
                DataTable dt = new DataTable();
                dt.Columns.Add("ExamDeptName", typeof(string));
                dt.Columns.Add("ExamDeptCode", typeof(string));
                dt.Rows.Add(ExamDeptName, ExamDeptCode);
                this.cmb_DeptName.DataSource = dt;
                this.cmb_DeptName.DisplayMember = "ExamDeptName";
                this.cmb_DeptName.ValueMember = "ExamDeptCode";
            }

            this.cmb_DeptName.SelectedIndex = 0;
        }

        //诊断医生初始化
        private void initExamDoctor()
        {
            this.cmb_ExamDoc.Items.Clear();
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.initSql = " doctor_level>3 and clinic_office_code = '" + this.cmb_DeptName.SelectedValue.ToString() + "'";
                    break;
                case "PACS":
                    this.initSql = " capability >3 and user_dept = '" + this.cmb_DeptName.SelectedValue.ToString() + "'";
                    break;
            }
            this.initDs = bUser.GetData(this.initSql);
            this.cmb_ExamDoc.Items.Add("全部");
            for (int i = 0; i < this.initDs.Tables[0].Rows.Count; i++)
            {
                this.cmb_ExamDoc.Items.Add(this.initDs.Tables[0].Rows[i][0].ToString());
            }
            this.cmb_ExamDoc.SelectedIndex = 0;
        }
        // 诊室列表初始化
        private void initDiagDept()
        {
            this.cmb_Diag.Items.Clear();
            this.initDept = GetConfig.ExamDeptName;
            this.initSql = " visit_dept='" + this.initDept + "'";
            this.dt = bQueueInfo.GetQueue(this.initSql);
            this.cmb_Diag.Items.Add("全部");
            for (int i = 0; i < this.dt.Rows.Count; i++)
            {
                this.cmb_Diag.Items.Add(this.dt.Rows[i]["QUEUE_NAME"].ToString());
            }
            this.cmb_Diag.SelectedIndex = 0;
        }

        //病人来源初始化
        private void initPatientSource()
        {
            SIS_BLL.BPatientSource bPatientSource = new BPatientSource();
            DataTable dt = bPatientSource.GetList(" 1=1");
            DataRow dw = dt.NewRow();
            if (GetConfig.DALAndModel == "SIS")
            {
                dw["PATIENT_SOURCE_ID"] = "-1";
                dw["PATIENT_SOURCE"] = "全部";
            }
            else
            {
                dw["PATIENT_SOURCE_CODE"] = "-1";
                dw["PATIENT_SOURCE_NAME"] = "全部";
            }
            dt.Rows.Add(dw);
            //string[] patient_Source = GetConfig.PatientSource.Split(';');
            //string[] patient_Source_Code = GetConfig.PatientSourceCode.Split(';');
            //DataTable dt = new DataTable();
            //DataColumn column;
            //DataRow row;
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.Char");
            //column.ColumnName = "Patient_Source_Code";
            //dt.Columns.Add(column);
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "Patient_Source";
            //dt.Columns.Add(column);
            //for (int i = 0; i < patient_Source.Length; i++)
            //{
            //    row = dt.NewRow();
            //    row["Patient_Source_Code"] = patient_Source_Code[i];
            //    row["Patient_Source"] = patient_Source[i];
            //    dt.Rows.Add(row);
            //}
            this.cmb_PatientSource.DataSource = dt;
            if (GetConfig.DALAndModel == "SIS")
            {
                this.cmb_PatientSource.DisplayMember = "PATIENT_SOURCE";
                this.cmb_PatientSource.ValueMember = "PATIENT_SOURCE_ID";
            }
            else
            {
                this.cmb_PatientSource.DisplayMember = "PATIENT_SOURCE_NAME";
                this.cmb_PatientSource.ValueMember = "PATIENT_SOURCE_CODE";
            }
            this.cmb_PatientSource.SelectedIndex = this.cmb_PatientSource.Items.Count - 1;
        }

        //初始化 检查技师
        private void initExamDoc()
        {
            this.cmb_ExamDoctor.Items.Clear();
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.initSql = " doctor_level=3 and clinic_office_code = '" + this.cmb_DeptName.SelectedValue.ToString() + "'";
                    break;
                case "PACS":
                    this.initSql = " capability =3 and user_dept = '" + this.cmb_DeptName.SelectedValue.ToString() + "'";
                    break;
            }
            this.initDs = bUser.GetData(this.initSql);
            this.cmb_ExamDoctor.Items.Add("全部");
            for (int i = 0; i < this.initDs.Tables[0].Rows.Count; i++)
            {
                this.cmb_ExamDoctor.Items.Add(this.initDs.Tables[0].Rows[i][0].ToString());
            }
            this.cmb_ExamDoctor.SelectedIndex = 0;
        }

        //影像科室选择   刷新诊断医生和诊室列表
        private void cmb_DeptName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.cmb_ExamDoc.Items.Clear();
            this.cmb_Diag.Items.Clear();
            this.initDept = " VISIT_DEPT='" + this.cmb_DeptName.Text.Trim() + "'";
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.initSql = " clinic_office_code = '" + this.cmb_DeptName.SelectedValue.ToString() + "'";
                    break;
                case "PACS":
                    this.initSql = " dept_code = '" + this.cmb_DeptName.SelectedValue.ToString() + "'";
                    break;
            }
            this.initDs = bUser.GetData(this.initSql);
            this.dt = bQueueInfo.GetList(this.initDept);
            this.cmb_ExamDoc.Items.Add("全部");
            this.cmb_Diag.Items.Add("全部");
            for (int i = 0; i < this.initDs.Tables[0].Rows.Count; i++)
            {
                this.cmb_ExamDoc.Items.Add(this.initDs.Tables[0].Rows[i][0].ToString().Trim());
            }
            for (int i = 0; i < this.dt.Rows.Count; i++)
            {
                this.cmb_Diag.Items.Add(this.dt.Rows[i]["QUEUE_NAME"].ToString().Trim());
            }
            this.cmb_ExamDoc.SelectedIndex = 0;
            this.cmb_Diag.SelectedIndex = 0;
        }

        //隐藏统计条件容器
        private void clearPanel()
        {
            this.p_ExamClass.Visible = false;
        }
        private void list_Stat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.initQueryData();//根据选择条件的变化进行初始化
        }
        private void initQueryData()
        {
            this.clearPanel();//隐藏统计条件容器
            switch (this.list_Stat.SelectedIndex)
            {
                case 0://诊断医师工作量统计   初始化
                    this.initDiagDocWork();
                    break;
                case 2://检查类别工作量统计   初始化
                    this.initExamClassWork();
                    break;
                case 3://科室工作量统计   初始化
                    this.initDiagDeptWork();
                    break;
                case 4://病人数统计   初始化
                    this.initPatientCount();
                    break;
                case 1://检查技师统计 初始化
                    this.initDoctor();
                    break;
                case 5: //阴阳性病人数统计初始化
                    this.initAbnormal();
                    break;
                case 6://各科室申请单统计
                    this.initApplyStatic();
                    break;
            }
        }

        //诊断医师工作量统计   初始化
        private void initDiagDocWork()
        {
            this.clearPanel();
            this.initExamDoctor();
            this.p_Diag.Visible = false;
            this.p_DiagDoctor.Visible = true;
            this.p_PatientSource.Visible = false;
            this.p_ExamDoctor.Visible = false;
            this.p_DiagDoctor.Location = new Point(4, 64);
        }

        //检查类别工作量统计   初始化
        private void initExamClassWork()
        {
            this.p_ExamClass.Visible = true;
            this.p_Diag.Visible = false;
            this.p_DiagDoctor.Visible = false;
            this.p_PatientSource.Visible = false;
            this.p_ExamDoctor.Visible = false;
            this.p_ExamClass.Location = new Point(4, 64);
            this.cmb_ExamClass.Items.Clear();
            this.cmb_ExamSubClass.Items.Clear();
            string[] examClass = GetConfig.ExamClass.Split(',');
            this.cmb_ExamClass.Items.Add("全部");
            for (int i = 0; i < examClass.Length; i++)
            {
                this.cmb_ExamClass.Items.Add(examClass[i].ToString().Trim());
            }
            this.cmb_ExamClass.SelectedIndex = 0;
        }
        //根据检查类别检索相应的检查之类
        private void cmb_ExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmb_ExamSubClass.Items.Clear();
            this.initSql = "";
            if (this.cmb_ExamClass.Text.Trim() == "全部")
            {
                SIS_BLL.BExamClass bExam_class = new BExamClass();

                string examClass = GetConfig.ExamClass.Replace(",", "','");
                DataTable dt = bExamClass.GetList(" exam_class in ('" + examClass + "')");
                //string[] examSubClass = GetConfig.ExamSubClass.Split(';');
                this.cmb_ExamSubClass.Items.Add("全部");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.cmb_ExamSubClass.Items.Add(dt.Rows[i]["EXAM_SUB_CLASS"]);
                }
            }
            else
            {
                this.initSql = " exam_class = '" + this.cmb_ExamClass.Text.Trim() + "' ";
                this.dt = bExamClass.GetList(this.initSql);
                this.cmb_ExamSubClass.Items.Add("全部");
                for (int i = 0; i < this.dt.Rows.Count; i++)
                {
                    this.cmb_ExamSubClass.Items.Add(this.dt.Rows[i]["exam_sub_class"].ToString().Trim());
                }
            }
            this.cmb_ExamSubClass.SelectedIndex = 0;
        }

        //科室工作量统计   初始化
        private void initDiagDeptWork()
        {
            this.clearPanel();
            this.initDiagDept(); //诊室列表初始化
            this.initPatientSource();//初始化病人来源
            this.p_ExamDoctor.Visible = false;
            this.p_DiagDoctor.Visible = false;
            this.p_Diag.Visible = true;
            this.p_PatientSource.Visible = true;
            this.p_PatientSource.Location = new Point(4, 100);
        }
        //病人明细统计   初始化
        private void initPatientCount()
        {
            this.p_ExamClass.Visible = true;
            this.initExamClassWork();
            this.p_Diag.Visible = false;
            this.p_DiagDoctor.Visible = false;
            this.p_ExamDoctor.Visible = false;
            this.p_PatientSource.Visible = false;
            this.p_ExamClass.Location = new Point(4, 64);
            this.cmb_ExamClass.Visible = true;
            //this.cmb_ExamSubClass.Visible = false;
            //this.label7.Visible = false;

        }

        //技师工作量统计  初始化
        private void initDoctor()
        {
            this.clearPanel();
            this.initExamDoc();
            this.p_Diag.Visible = false;
            this.p_DiagDoctor.Visible = false;
            this.p_PatientSource.Visible = false;
            this.p_ExamDoctor.Visible = true;
            this.p_ExamDoctor.Location = new Point(4, 64);

        }
        //阴阳性病人数统计初始化
        private void initAbnormal()
        {
            this.clearPanel();
            this.p_Diag.Visible = false;
            this.p_DiagDoctor.Visible = false;
            this.p_PatientSource.Visible = false;
            this.p_ExamDoctor.Visible = false;
        }
        //各科室申请单统计初始化
        private void initApplyStatic()
        {
            this.clearPanel();
            this.initExamDoctor();
            this.initPatientSource();//初始化病人来源
            this.p_Diag.Visible = false;
            this.p_DiagDoctor.Visible = true;
            //this.p_PatientSource.Visible = false;
            this.p_ExamDoctor.Visible = false;
            this.p_DiagDoctor.Location = new Point(4, 64);
            this.p_PatientSource.Visible = true;
            this.p_PatientSource.Location = new Point(4, 100);
        }
        //设置报表视图
        private void setReportViewer()
        {
            this.rep.SetDataSource(this.queryDs.Tables[0]);
            // this.rep.SetParameterValue("dateA", this.date_StatA.Text);
            // this.rep.SetParameterValue("dateB", this.date_StatB.Text);
            this.ReportViewer.ReportSource = this.rep;
        }


        //开始统计
        private void btn_Stat_Click(object sender, EventArgs e)
        {
            this.statData();//数据统计
        }
        //数据统计，根据在ListBox选择的条件进行查询条件设置
        private void statData()
        {
            this.selectId = this.list_Stat.SelectedIndex;
            this.condition(this.selectId);//根据在ListBox选择的项进行条件设置初始化,构造查询条件
            switch (this.selectId)
            {
                case 0://诊断医师工作量统计
                    this.queryDiagDocWork();
                    break;
                case 2://检查类别工作量统计
                    this.queryExamClassWork();
                    break;
                case 3://科室工作量统计
                    this.queryDiagDeptWork();
                    break;
                case 4://人次统计
                    this.queryPatientCount();
                    break;
                case 1://技师工作量统计
                    this.queryExamDocWork();
                    break;
                case 5: //阴阳性病人数统计
                    this.queryAbnormalCount();
                    break;
                case 6: //各科室申请单统计
                    this.queryApplyDeptStat();
                    break;
            }
        }
        //条件设置初始化,构造查询条件
        private void condition(int i)
        {
            this.queryDate = "";
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    this.queryDate = " between #" + this.date_StatA.Text + "# and #" + Convert.ToDateTime(this.date_StatB.Text).AddDays(1).ToShortDateString() + "#";
                    break;
                case "ORACLE":
                    this.queryDate = " between to_date('" + this.date_StatA.Text + "','yyyy-mm-dd') and to_date('" + Convert.ToDateTime(this.date_StatB.Text).AddDays(1).ToShortDateString() + "','yyyy-mm-dd')";
                    break;
                case "SQL":
                    break;
            }

            this.queryDeptName = " and a.exam_dept = '" + this.cmb_DeptName.SelectedValue.ToString() + "'";
            this.queryDate += queryDeptName;
            switch (i)
            {
                case 0://诊断医师工作量统计
                    this.queryExamDoc = this.queryDeptName;
                    if (this.cmb_ExamDoc.Text == "全部")
                        this.queryExamDoc += " and 1=1";
                    else
                        this.queryExamDoc += " and b.TRANSCRIBER = '" + this.cmb_ExamDoc.Text.Trim() + "'";
                    break;
                case 1://技师工作量统计
                    this.queryExamClass = this.queryDeptName;
                    //modify by liukun at 2010-6-22 begin 
                    //if (this.cmb_ExamClass.Text == "全部")
                    //    this.queryExamClass += " and 1=1";
                    //else
                    //    this.queryExamClass += " and a.exam_class = '" + this.cmb_ExamClass.Text.Trim() + "'";
                    //if (this.cmb_ExamSubClass.Text == "全部")
                    //    this.queryExamClass += " and 1=1";
                    //else
                    //    this.queryExamClass += " and a.exam_sub_class = '" + this.cmb_ExamSubClass.Text.Trim() + "'";
                    //break;
                    if (this.cmb_ExamDoctor.Text != "全部")
                    {
                        this.queryDate += " and a.EXAM_DOCTOR = '" + cmb_ExamDoctor.Text.Trim() + "'";
                    }
                    break;
                //modify by liukun at 2010-6-22　end 
                case 2://检查类别工作量统计
                    this.queryDiag = this.queryDeptName;
                    //modify by liukun at 2010-6-17　being 
                    //修改说明：cmb_Diag、cmb_PatientSource在统计“科室工作量统计”时根本就不会显示出来，因此这里的条件完全是形同虚设。所以全部注释并重写统计条件
                    //if (this.cmb_Diag.Text == "全部")
                    //    this.queryDiag += " and 1=1";
                    //else
                    //    this.queryDiag += " and a.exam_group = '" + this.cmb_Diag.Text.Trim() + "'";
                    //if (this.cmb_PatientSource.Text == "全部")
                    //    this.queryDiag += " and 1=1";
                    //else
                    //    this.queryDiag += " and a.patient_source='" + this.cmb_PatientSource.SelectedValue.ToString() + "'";
                    if (this.cmb_ExamClass.Text != "全部")  //检查类别
                    {
                        this.queryDate += " and a.exam_class = '" + this.cmb_ExamClass.Text.Trim() + "'";
                    }
                    if (this.cmb_ExamSubClass.Text != "全部")   //检查子类
                    {
                        this.queryDate += " and a.exam_sub_class = '" + this.cmb_ExamSubClass.Text.Trim() + "'";
                    }
                    break;
                case 3://科室工作量统计
                    this.queryPatientSource = this.queryDeptName;
                    if (this.cmb_Diag.Text != "全部")   //诊室
                    {
                        this.queryDate += " and a.exam_group = '" + this.cmb_Diag.Text.Trim() + "'";
                    }
                    if (this.cmb_PatientSource.Text != "全部")  //病人来源
                    {
                        this.queryDate += " and a.patient_source = '" + this.cmb_PatientSource.SelectedValue.ToString() + "'";
                    }
                    break;
                case 4://检查病人明细报表
                    this.queryDoctor = this.queryDeptName;
                    if (this.cmb_ExamClass.Text != "全部")  //检查类别
                    {
                        this.queryDate += " and a.exam_class = '" + this.cmb_ExamClass.Text.Trim() + "'";
                    }
                    if (this.cmb_ExamSubClass.Text != "全部")   //检查子类
                    {
                        this.queryDate += " and a.exam_sub_class = '" + this.cmb_ExamSubClass.Text.Trim() + "'";
                    }
                    break;
                //modify by liukun at 2010-6-17　end 
                case 5://阴阳性病人数统计
                    this.queryAbnormal = this.queryDeptName;
                    break;
                //add by liukun at 2010-6-22　begin 
                case 6://各科室申请单统计
                    if (this.cmb_ExamDoc.Text != "全部")
                    {
                        if (GetConfig.DALAndModel == "SIS")     //超声系统
                        {
                            this.queryDate += " and b.doctor_name = '" + this.cmb_ExamDoc.Text.Trim() + "'";
                        }
                        else if (GetConfig.DALAndModel == "PACS")   //放射科登记系统
                        {
                            this.queryDate += " and b.user_name = '" + this.cmb_ExamDoc.Text.Trim() + "'";
                        }
                    }
                    if (this.cmb_PatientSource.Text != "全部")
                    {
                        this.queryDate += " and a.patient_source = '" + this.cmb_PatientSource.SelectedValue.ToString() + "'";
                    }
                    break;
                //add by liukun at 2010-6-22 end 
            }
        }
        //诊断医师工作量统计
        private void queryDiagDocWork()
        {
            this.queryDs = bStat.queryDiagDocWork(this.queryDate, this.queryExamDoc);
            this.rep.Load(path + "DiagDocWorkReport.rpt");
            this.setReportViewer();
        }

        //检查类别工作量统计
        private void queryExamClassWork()
        {
            this.queryDs = bStat.queryExamClassWork(this.queryDate, this.queryExamClass);
            this.rep.Load(path + "ExamClassWorkReport.rpt");
            this.setReportViewer();
        }

        //科室工作量统计
        private void queryDiagDeptWork()
        {
            this.queryDs = bStat.queryDiagDeptWork(this.queryDate, this.queryDiag);
            this.rep.Load(path + "DiagDeptWorkReport.rpt");
            this.setReportViewer();
        }

        /// <summary>
        /// 指定检查科室指定登记时间的病人数统计 
        /// </summary>
        private void queryPatientCount()
        {
            this.queryDs = bStat.queryPatientCount(this.queryDate, this.queryPatientSource);
            this.rep.Load(path + "PatientCountReport.rpt");
            this.setReportViewer();
        }

        ///<summary>
        ///检查技师工作量统计
        ///</summary>
        private void queryExamDocWork()
        {

            this.queryDs = bStat.queryExamDocWork(this.queryDate, this.queryDoctor);
            this.rep.Load(path + "ExamgDocWorkReport.rpt");
            this.setReportViewer();
        }
        ///<summary>
        ///阴阳性病人数统计
        ///</summary>
        private void queryAbnormalCount()
        {
            this.queryDs = bStat.queryAbnormal(this.queryDate, this.queryAbnormal);
            this.rep.Load(path + "Abnormal.rpt");
            this.setReportViewer();
        }
        ///<summary>
        ///各科室申请单统计
        ///</summary>
        private void queryApplyDeptStat()
        {
            this.queryDs = bStat.queryApplyDept(this.queryDate, this.queryAbnormal);
            this.rep.Load(path + "ApplyDeptStat.rpt");
            this.setReportViewer();
        }
    }
}
