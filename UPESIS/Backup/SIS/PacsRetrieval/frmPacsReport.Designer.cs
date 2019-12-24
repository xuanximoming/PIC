namespace SIS
{
    partial class frmPacsReport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacsReport));
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_EmsInf = new System.Windows.Forms.Button();
            this.btn_LisInf = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_PatInf = new System.Windows.Forms.Button();
            this.wwc_Report = new BaseControls.WinWordControl();
            this.txt_ApproveDateTime = new BaseControls.userTextBox();
            this.txt_ReportDateTime = new BaseControls.userTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.txt_Approver = new BaseControls.userTextBox();
            this.txt_Transcriber = new BaseControls.userTextBox();
            this.myLabel1 = new BaseControls.MyLabel();
            this.myLabel2 = new BaseControls.MyLabel();
            this.rb_NoAbnormal = new System.Windows.Forms.RadioButton();
            this.rb_Abnormal = new System.Windows.Forms.RadioButton();
            this.txt_PatientSex = new BaseControls.userTextBox();
            this.txt_PatientID = new BaseControls.userTextBox();
            this.myLabel3 = new BaseControls.MyLabel();
            this.myLabel4 = new BaseControls.MyLabel();
            this.txt_PatientAge = new BaseControls.userTextBox();
            this.txt_PatientName = new BaseControls.userTextBox();
            this.myLabel5 = new BaseControls.MyLabel();
            this.myLabel6 = new BaseControls.MyLabel();
            this.txt_InpNo = new BaseControls.userTextBox();
            this.myLabel7 = new BaseControls.MyLabel();
            this.txt_BedNum = new BaseControls.userTextBox();
            this.myLabel8 = new BaseControls.MyLabel();
            this.txt_PatientSource = new BaseControls.userTextBox();
            this.myLabel9 = new BaseControls.MyLabel();
            this.txt_ExamSubClass = new BaseControls.userTextBox();
            this.myLabel10 = new BaseControls.MyLabel();
            this.txt_ExamItem = new BaseControls.userTextBox();
            this.myLabel11 = new BaseControls.MyLabel();
            this.txt_StudyDateTime = new BaseControls.userTextBox();
            this.myLabel12 = new BaseControls.MyLabel();
            this.txt_ExamClass = new BaseControls.userTextBox();
            this.myLabel13 = new BaseControls.MyLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.tableLayoutPanel5.Controls.Add(this.btn_Close, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_EmsInf, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_LisInf, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_PatInf, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(942, 27);
            this.tableLayoutPanel5.TabIndex = 48;
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.Color.Black;
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(408, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(64, 19);
            this.btn_Close.TabIndex = 54;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_EmsInf
            // 
            this.btn_EmsInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_EmsInf.FlatAppearance.BorderSize = 0;
            this.btn_EmsInf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_EmsInf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btn_EmsInf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EmsInf.ForeColor = System.Drawing.Color.Black;
            this.btn_EmsInf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EmsInf.ImageIndex = 5;
            this.btn_EmsInf.Location = new System.Drawing.Point(317, 4);
            this.btn_EmsInf.Name = "btn_EmsInf";
            this.btn_EmsInf.Size = new System.Drawing.Size(84, 19);
            this.btn_EmsInf.TabIndex = 13;
            this.btn_EmsInf.Text = "病历信息";
            this.btn_EmsInf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_EmsInf.UseVisualStyleBackColor = true;
            // 
            // btn_LisInf
            // 
            this.btn_LisInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_LisInf.FlatAppearance.BorderSize = 0;
            this.btn_LisInf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_LisInf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btn_LisInf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LisInf.ForeColor = System.Drawing.Color.Black;
            this.btn_LisInf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LisInf.ImageIndex = 4;
            this.btn_LisInf.Location = new System.Drawing.Point(226, 4);
            this.btn_LisInf.Name = "btn_LisInf";
            this.btn_LisInf.Size = new System.Drawing.Size(84, 19);
            this.btn_LisInf.TabIndex = 12;
            this.btn_LisInf.Text = "检验信息";
            this.btn_LisInf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LisInf.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "报告调阅";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_PatInf
            // 
            this.btn_PatInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PatInf.FlatAppearance.BorderSize = 0;
            this.btn_PatInf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_PatInf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btn_PatInf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PatInf.ForeColor = System.Drawing.Color.Black;
            this.btn_PatInf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PatInf.ImageIndex = 2;
            this.btn_PatInf.Location = new System.Drawing.Point(135, 4);
            this.btn_PatInf.Name = "btn_PatInf";
            this.btn_PatInf.Size = new System.Drawing.Size(84, 19);
            this.btn_PatInf.TabIndex = 12;
            this.btn_PatInf.Text = "病人资料";
            this.btn_PatInf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PatInf.UseVisualStyleBackColor = true;
            // 
            // wwc_Report
            // 
            this.wwc_Report.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.wwc_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wwc_Report.Location = new System.Drawing.Point(245, 27);
            this.wwc_Report.Name = "wwc_Report";
            this.wwc_Report.ShowMenuBar = false;
            this.wwc_Report.ShowToolBar = false;
            this.wwc_Report.Size = new System.Drawing.Size(697, 604);
            this.wwc_Report.TabIndex = 49;
            // 
            // txt_ApproveDateTime
            // 
            this.txt_ApproveDateTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ApproveDateTime.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ApproveDateTime.ForeColor = System.Drawing.Color.Black;
            this.txt_ApproveDateTime.IsChangeColor = true;
            this.txt_ApproveDateTime.Location = new System.Drawing.Point(83, 527);
            this.txt_ApproveDateTime.Name = "txt_ApproveDateTime";
            this.txt_ApproveDateTime.ReadOnly = true;
            this.txt_ApproveDateTime.Size = new System.Drawing.Size(136, 21);
            this.txt_ApproveDateTime.TabIndex = 18;
            // 
            // txt_ReportDateTime
            // 
            this.txt_ReportDateTime.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ReportDateTime.ForeColor = System.Drawing.Color.Black;
            this.txt_ReportDateTime.IsChangeColor = true;
            this.txt_ReportDateTime.Location = new System.Drawing.Point(83, 465);
            this.txt_ReportDateTime.Name = "txt_ReportDateTime";
            this.txt_ReportDateTime.ReadOnly = true;
            this.txt_ReportDateTime.Size = new System.Drawing.Size(136, 21);
            this.txt_ReportDateTime.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "报告时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "审核时间：";
            // 
            // txt_Approver
            // 
            this.txt_Approver.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Approver.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_Approver.ForeColor = System.Drawing.Color.Black;
            this.txt_Approver.IsChangeColor = true;
            this.txt_Approver.Location = new System.Drawing.Point(83, 497);
            this.txt_Approver.Name = "txt_Approver";
            this.txt_Approver.ReadOnly = true;
            this.txt_Approver.Size = new System.Drawing.Size(136, 21);
            this.txt_Approver.TabIndex = 22;
            // 
            // txt_Transcriber
            // 
            this.txt_Transcriber.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_Transcriber.ForeColor = System.Drawing.Color.Black;
            this.txt_Transcriber.IsChangeColor = true;
            this.txt_Transcriber.Location = new System.Drawing.Point(83, 434);
            this.txt_Transcriber.Name = "txt_Transcriber";
            this.txt_Transcriber.ReadOnly = true;
            this.txt_Transcriber.Size = new System.Drawing.Size(136, 21);
            this.txt_Transcriber.TabIndex = 20;
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel1.ForeColor = System.Drawing.Color.Black;
            this.myLabel1.Location = new System.Drawing.Point(13, 437);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Size = new System.Drawing.Size(65, 12);
            this.myLabel1.TabIndex = 19;
            this.myLabel1.Text = "报告医生：";
            // 
            // myLabel2
            // 
            this.myLabel2.AutoSize = true;
            this.myLabel2.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel2.ForeColor = System.Drawing.Color.Black;
            this.myLabel2.Location = new System.Drawing.Point(13, 500);
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.Size = new System.Drawing.Size(65, 12);
            this.myLabel2.TabIndex = 21;
            this.myLabel2.Text = "审核医生：";
            // 
            // rb_NoAbnormal
            // 
            this.rb_NoAbnormal.AutoSize = true;
            this.rb_NoAbnormal.Enabled = false;
            this.rb_NoAbnormal.Location = new System.Drawing.Point(31, 389);
            this.rb_NoAbnormal.Name = "rb_NoAbnormal";
            this.rb_NoAbnormal.Size = new System.Drawing.Size(47, 16);
            this.rb_NoAbnormal.TabIndex = 52;
            this.rb_NoAbnormal.TabStop = true;
            this.rb_NoAbnormal.Text = "阴性";
            this.rb_NoAbnormal.UseVisualStyleBackColor = true;
            // 
            // rb_Abnormal
            // 
            this.rb_Abnormal.AutoSize = true;
            this.rb_Abnormal.Enabled = false;
            this.rb_Abnormal.Location = new System.Drawing.Point(118, 389);
            this.rb_Abnormal.Name = "rb_Abnormal";
            this.rb_Abnormal.Size = new System.Drawing.Size(47, 16);
            this.rb_Abnormal.TabIndex = 53;
            this.rb_Abnormal.TabStop = true;
            this.rb_Abnormal.Text = "阳性";
            this.rb_Abnormal.UseVisualStyleBackColor = true;
            // 
            // txt_PatientSex
            // 
            this.txt_PatientSex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PatientSex.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientSex.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientSex.IsChangeColor = true;
            this.txt_PatientSex.Location = new System.Drawing.Point(83, 101);
            this.txt_PatientSex.Name = "txt_PatientSex";
            this.txt_PatientSex.ReadOnly = true;
            this.txt_PatientSex.Size = new System.Drawing.Size(136, 21);
            this.txt_PatientSex.TabIndex = 61;
            // 
            // txt_PatientID
            // 
            this.txt_PatientID.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientID.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientID.IsChangeColor = true;
            this.txt_PatientID.Location = new System.Drawing.Point(83, 39);
            this.txt_PatientID.Name = "txt_PatientID";
            this.txt_PatientID.ReadOnly = true;
            this.txt_PatientID.Size = new System.Drawing.Size(136, 21);
            this.txt_PatientID.TabIndex = 59;
            // 
            // myLabel3
            // 
            this.myLabel3.AutoSize = true;
            this.myLabel3.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel3.ForeColor = System.Drawing.Color.Black;
            this.myLabel3.Location = new System.Drawing.Point(13, 42);
            this.myLabel3.Name = "myLabel3";
            this.myLabel3.Size = new System.Drawing.Size(53, 12);
            this.myLabel3.TabIndex = 58;
            this.myLabel3.Text = "病人ID：";
            // 
            // myLabel4
            // 
            this.myLabel4.AutoSize = true;
            this.myLabel4.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel4.ForeColor = System.Drawing.Color.Black;
            this.myLabel4.Location = new System.Drawing.Point(13, 104);
            this.myLabel4.Name = "myLabel4";
            this.myLabel4.Size = new System.Drawing.Size(65, 12);
            this.myLabel4.TabIndex = 60;
            this.myLabel4.Text = "病人性别：";
            // 
            // txt_PatientAge
            // 
            this.txt_PatientAge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PatientAge.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientAge.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientAge.IsChangeColor = true;
            this.txt_PatientAge.Location = new System.Drawing.Point(83, 132);
            this.txt_PatientAge.Name = "txt_PatientAge";
            this.txt_PatientAge.ReadOnly = true;
            this.txt_PatientAge.Size = new System.Drawing.Size(136, 21);
            this.txt_PatientAge.TabIndex = 57;
            // 
            // txt_PatientName
            // 
            this.txt_PatientName.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientName.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientName.IsChangeColor = true;
            this.txt_PatientName.Location = new System.Drawing.Point(83, 70);
            this.txt_PatientName.Name = "txt_PatientName";
            this.txt_PatientName.ReadOnly = true;
            this.txt_PatientName.Size = new System.Drawing.Size(136, 21);
            this.txt_PatientName.TabIndex = 55;
            // 
            // myLabel5
            // 
            this.myLabel5.AutoSize = true;
            this.myLabel5.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel5.ForeColor = System.Drawing.Color.Black;
            this.myLabel5.Location = new System.Drawing.Point(13, 73);
            this.myLabel5.Name = "myLabel5";
            this.myLabel5.Size = new System.Drawing.Size(65, 12);
            this.myLabel5.TabIndex = 54;
            this.myLabel5.Text = "病人姓名：";
            // 
            // myLabel6
            // 
            this.myLabel6.AutoSize = true;
            this.myLabel6.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel6.ForeColor = System.Drawing.Color.Black;
            this.myLabel6.Location = new System.Drawing.Point(13, 135);
            this.myLabel6.Name = "myLabel6";
            this.myLabel6.Size = new System.Drawing.Size(65, 12);
            this.myLabel6.TabIndex = 56;
            this.myLabel6.Text = "病人年龄：";
            // 
            // txt_InpNo
            // 
            this.txt_InpNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_InpNo.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_InpNo.ForeColor = System.Drawing.Color.Black;
            this.txt_InpNo.IsChangeColor = true;
            this.txt_InpNo.Location = new System.Drawing.Point(83, 194);
            this.txt_InpNo.Name = "txt_InpNo";
            this.txt_InpNo.ReadOnly = true;
            this.txt_InpNo.Size = new System.Drawing.Size(136, 21);
            this.txt_InpNo.TabIndex = 65;
            // 
            // myLabel7
            // 
            this.myLabel7.AutoSize = true;
            this.myLabel7.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel7.ForeColor = System.Drawing.Color.Black;
            this.myLabel7.Location = new System.Drawing.Point(13, 197);
            this.myLabel7.Name = "myLabel7";
            this.myLabel7.Size = new System.Drawing.Size(53, 12);
            this.myLabel7.TabIndex = 64;
            this.myLabel7.Text = "住院号：";
            // 
            // txt_BedNum
            // 
            this.txt_BedNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_BedNum.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_BedNum.ForeColor = System.Drawing.Color.Black;
            this.txt_BedNum.IsChangeColor = true;
            this.txt_BedNum.Location = new System.Drawing.Point(83, 225);
            this.txt_BedNum.Name = "txt_BedNum";
            this.txt_BedNum.ReadOnly = true;
            this.txt_BedNum.Size = new System.Drawing.Size(136, 21);
            this.txt_BedNum.TabIndex = 63;
            // 
            // myLabel8
            // 
            this.myLabel8.AutoSize = true;
            this.myLabel8.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel8.ForeColor = System.Drawing.Color.Black;
            this.myLabel8.Location = new System.Drawing.Point(13, 228);
            this.myLabel8.Name = "myLabel8";
            this.myLabel8.Size = new System.Drawing.Size(41, 12);
            this.myLabel8.TabIndex = 62;
            this.myLabel8.Text = "床号：";
            // 
            // txt_PatientSource
            // 
            this.txt_PatientSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PatientSource.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientSource.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientSource.IsChangeColor = true;
            this.txt_PatientSource.Location = new System.Drawing.Point(83, 163);
            this.txt_PatientSource.Name = "txt_PatientSource";
            this.txt_PatientSource.ReadOnly = true;
            this.txt_PatientSource.Size = new System.Drawing.Size(136, 21);
            this.txt_PatientSource.TabIndex = 67;
            // 
            // myLabel9
            // 
            this.myLabel9.AutoSize = true;
            this.myLabel9.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel9.ForeColor = System.Drawing.Color.Black;
            this.myLabel9.Location = new System.Drawing.Point(13, 166);
            this.myLabel9.Name = "myLabel9";
            this.myLabel9.Size = new System.Drawing.Size(65, 12);
            this.myLabel9.TabIndex = 66;
            this.myLabel9.Text = "病人来源：";
            // 
            // txt_ExamSubClass
            // 
            this.txt_ExamSubClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ExamSubClass.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ExamSubClass.ForeColor = System.Drawing.Color.Black;
            this.txt_ExamSubClass.IsChangeColor = true;
            this.txt_ExamSubClass.Location = new System.Drawing.Point(83, 287);
            this.txt_ExamSubClass.Name = "txt_ExamSubClass";
            this.txt_ExamSubClass.ReadOnly = true;
            this.txt_ExamSubClass.Size = new System.Drawing.Size(136, 21);
            this.txt_ExamSubClass.TabIndex = 75;
            // 
            // myLabel10
            // 
            this.myLabel10.AutoSize = true;
            this.myLabel10.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel10.ForeColor = System.Drawing.Color.Black;
            this.myLabel10.Location = new System.Drawing.Point(13, 290);
            this.myLabel10.Name = "myLabel10";
            this.myLabel10.Size = new System.Drawing.Size(65, 12);
            this.myLabel10.TabIndex = 74;
            this.myLabel10.Text = "检查子类：";
            // 
            // txt_ExamItem
            // 
            this.txt_ExamItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ExamItem.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ExamItem.ForeColor = System.Drawing.Color.Black;
            this.txt_ExamItem.IsChangeColor = true;
            this.txt_ExamItem.Location = new System.Drawing.Point(83, 318);
            this.txt_ExamItem.Name = "txt_ExamItem";
            this.txt_ExamItem.ReadOnly = true;
            this.txt_ExamItem.Size = new System.Drawing.Size(136, 21);
            this.txt_ExamItem.TabIndex = 73;
            // 
            // myLabel11
            // 
            this.myLabel11.AutoSize = true;
            this.myLabel11.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel11.ForeColor = System.Drawing.Color.Black;
            this.myLabel11.Location = new System.Drawing.Point(13, 321);
            this.myLabel11.Name = "myLabel11";
            this.myLabel11.Size = new System.Drawing.Size(65, 12);
            this.myLabel11.TabIndex = 72;
            this.myLabel11.Text = "检查项目：";
            // 
            // txt_StudyDateTime
            // 
            this.txt_StudyDateTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_StudyDateTime.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_StudyDateTime.ForeColor = System.Drawing.Color.Black;
            this.txt_StudyDateTime.IsChangeColor = true;
            this.txt_StudyDateTime.Location = new System.Drawing.Point(83, 349);
            this.txt_StudyDateTime.Name = "txt_StudyDateTime";
            this.txt_StudyDateTime.ReadOnly = true;
            this.txt_StudyDateTime.Size = new System.Drawing.Size(136, 21);
            this.txt_StudyDateTime.TabIndex = 71;
            // 
            // myLabel12
            // 
            this.myLabel12.AutoSize = true;
            this.myLabel12.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel12.ForeColor = System.Drawing.Color.Black;
            this.myLabel12.Location = new System.Drawing.Point(13, 352);
            this.myLabel12.Name = "myLabel12";
            this.myLabel12.Size = new System.Drawing.Size(65, 12);
            this.myLabel12.TabIndex = 70;
            this.myLabel12.Text = "检查时间：";
            // 
            // txt_ExamClass
            // 
            this.txt_ExamClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ExamClass.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ExamClass.ForeColor = System.Drawing.Color.Black;
            this.txt_ExamClass.IsChangeColor = true;
            this.txt_ExamClass.Location = new System.Drawing.Point(83, 256);
            this.txt_ExamClass.Name = "txt_ExamClass";
            this.txt_ExamClass.ReadOnly = true;
            this.txt_ExamClass.Size = new System.Drawing.Size(136, 21);
            this.txt_ExamClass.TabIndex = 69;
            // 
            // myLabel13
            // 
            this.myLabel13.AutoSize = true;
            this.myLabel13.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel13.ForeColor = System.Drawing.Color.Black;
            this.myLabel13.Location = new System.Drawing.Point(13, 259);
            this.myLabel13.Name = "myLabel13";
            this.myLabel13.Size = new System.Drawing.Size(65, 12);
            this.myLabel13.TabIndex = 68;
            this.myLabel13.Text = "检查类别：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ExamSubClass);
            this.groupBox1.Controls.Add(this.txt_PatientSex);
            this.groupBox1.Controls.Add(this.myLabel10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_ExamItem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.myLabel11);
            this.groupBox1.Controls.Add(this.txt_ReportDateTime);
            this.groupBox1.Controls.Add(this.txt_StudyDateTime);
            this.groupBox1.Controls.Add(this.txt_ApproveDateTime);
            this.groupBox1.Controls.Add(this.myLabel12);
            this.groupBox1.Controls.Add(this.myLabel2);
            this.groupBox1.Controls.Add(this.txt_ExamClass);
            this.groupBox1.Controls.Add(this.myLabel1);
            this.groupBox1.Controls.Add(this.myLabel13);
            this.groupBox1.Controls.Add(this.txt_Transcriber);
            this.groupBox1.Controls.Add(this.txt_PatientSource);
            this.groupBox1.Controls.Add(this.txt_Approver);
            this.groupBox1.Controls.Add(this.myLabel9);
            this.groupBox1.Controls.Add(this.rb_NoAbnormal);
            this.groupBox1.Controls.Add(this.txt_InpNo);
            this.groupBox1.Controls.Add(this.rb_Abnormal);
            this.groupBox1.Controls.Add(this.myLabel7);
            this.groupBox1.Controls.Add(this.myLabel6);
            this.groupBox1.Controls.Add(this.txt_BedNum);
            this.groupBox1.Controls.Add(this.myLabel5);
            this.groupBox1.Controls.Add(this.myLabel8);
            this.groupBox1.Controls.Add(this.txt_PatientName);
            this.groupBox1.Controls.Add(this.txt_PatientAge);
            this.groupBox1.Controls.Add(this.txt_PatientID);
            this.groupBox1.Controls.Add(this.myLabel4);
            this.groupBox1.Controls.Add(this.myLabel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 604);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检查信息";
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(242, 27);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 604);
            this.splitter1.TabIndex = 53;
            this.splitter1.TabStop = false;
            // 
            // frmPacsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(942, 631);
            this.Controls.Add(this.wwc_Report);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "frmPacsReport";
            this.Text = "frmPacsReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.Button btn_EmsInf;
        public System.Windows.Forms.Button btn_LisInf;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btn_PatInf;
        private BaseControls.userTextBox txt_ApproveDateTime;
        private BaseControls.userTextBox txt_ReportDateTime;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label2;
        private System.Windows.Forms.RadioButton rb_Abnormal;
        private System.Windows.Forms.RadioButton rb_NoAbnormal;
        private BaseControls.userTextBox txt_Approver;
        private BaseControls.userTextBox txt_Transcriber;
        private BaseControls.MyLabel myLabel1;
        private BaseControls.MyLabel myLabel2;
        private BaseControls.userTextBox txt_ExamSubClass;
        private BaseControls.MyLabel myLabel10;
        private BaseControls.userTextBox txt_ExamItem;
        private BaseControls.MyLabel myLabel11;
        private BaseControls.userTextBox txt_StudyDateTime;
        private BaseControls.MyLabel myLabel12;
        private BaseControls.userTextBox txt_ExamClass;
        private BaseControls.MyLabel myLabel13;
        private BaseControls.userTextBox txt_PatientSource;
        private BaseControls.MyLabel myLabel9;
        private BaseControls.userTextBox txt_InpNo;
        private BaseControls.MyLabel myLabel7;
        private BaseControls.userTextBox txt_BedNum;
        private BaseControls.MyLabel myLabel8;
        private BaseControls.userTextBox txt_PatientSex;
        private BaseControls.userTextBox txt_PatientID;
        private BaseControls.MyLabel myLabel3;
        private BaseControls.MyLabel myLabel4;
        private BaseControls.userTextBox txt_PatientAge;
        private BaseControls.userTextBox txt_PatientName;
        private BaseControls.MyLabel myLabel5;
        private BaseControls.MyLabel myLabel6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.Button btn_Close;
        private BaseControls.WinWordControl wwc_Report;
    }
}