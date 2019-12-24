namespace SIS
{
    partial class frmPacsStudy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacsStudy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Find = new System.Windows.Forms.ToolStripButton();
            this.tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Clear = new System.Windows.Forms.ToolStripButton();
            this.tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_OpenRpt = new System.Windows.Forms.ToolStripButton();
            this.tss7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_OpenImg = new System.Windows.Forms.ToolStripButton();
            this.GroupBox_QueryItem = new BaseControls.GroupBox.MyGroupBox();
            this.txt_ExamGroup = new BaseControls.userTextBox();
            this.txt_DiagImpression = new BaseControls.userTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_ExamDoctor = new BaseControls.userTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_ExamAccessionNum = new BaseControls.userTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.cmb_DateType = new System.Windows.Forms.ComboBox();
            this.cmb_ExamItem = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_InpNo = new BaseControls.userTextBox();
            this.cmb_ReportType = new System.Windows.Forms.ComboBox();
            this.cmb_IsOnline = new System.Windows.Forms.ComboBox();
            this.cmb_PatientSource = new System.Windows.Forms.ComboBox();
            this.cmb_ChargeType = new System.Windows.Forms.ComboBox();
            this.cmb_ExamClass = new System.Windows.Forms.ComboBox();
            this.cmb_ExamSubClass = new System.Windows.Forms.ComboBox();
            this.cmb_ReferDept = new System.Windows.Forms.ComboBox();
            this.cmb_ReferDoctor = new System.Windows.Forms.ComboBox();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_PatientLocalId = new BaseControls.userTextBox();
            this.txt_PatientID = new BaseControls.userTextBox();
            this.txt_Name = new BaseControls.userTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.l_Count = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_Study = new BaseControls.MyDataGridView();
            this.cms_Study = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_ChangeList = new System.Windows.Forms.ToolStripMenuItem();
            this.p_Buttom = new System.Windows.Forms.Panel();
            this.txt_Description = new BaseControls.userTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.txt_Impression = new BaseControls.userTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip.SuspendLayout();
            this.GroupBox_QueryItem.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Study)).BeginInit();
            this.cms_Study.SuspendLayout();
            this.p_Buttom.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tss1,
            this.tsb_Find,
            this.tss2,
            this.tsb_Clear,
            this.tss3,
            this.tsb_OpenRpt,
            this.tss7,
            this.tsb_OpenImg});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1066, 28);
            this.toolStrip.TabIndex = 56;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(130, 27);
            this.toolStripButton1.Text = "PACS调阅";
            // 
            // tss1
            // 
            this.tss1.AutoSize = false;
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_Find
            // 
            this.tsb_Find.AutoSize = false;
            this.tsb_Find.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsb_Find.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Find.Image")));
            this.tsb_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsb_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Find.Name = "tsb_Find";
            this.tsb_Find.Size = new System.Drawing.Size(65, 27);
            this.tsb_Find.Text = "查询";
            this.tsb_Find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsb_Find.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsb_Find.Click += new System.EventHandler(this.tsb_Find_Click);
            // 
            // tss2
            // 
            this.tss2.AutoSize = false;
            this.tss2.Name = "tss2";
            this.tss2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_Clear
            // 
            this.tsb_Clear.AutoSize = false;
            this.tsb_Clear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsb_Clear.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Clear.Image")));
            this.tsb_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsb_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Clear.Name = "tsb_Clear";
            this.tsb_Clear.Size = new System.Drawing.Size(65, 27);
            this.tsb_Clear.Text = "清空";
            this.tsb_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsb_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsb_Clear.Click += new System.EventHandler(this.tsb_Clear_Click);
            // 
            // tss3
            // 
            this.tss3.AutoSize = false;
            this.tss3.Name = "tss3";
            this.tss3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_OpenRpt
            // 
            this.tsb_OpenRpt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsb_OpenRpt.Image = ((System.Drawing.Image)(resources.GetObject("tsb_OpenRpt.Image")));
            this.tsb_OpenRpt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OpenRpt.Name = "tsb_OpenRpt";
            this.tsb_OpenRpt.Size = new System.Drawing.Size(87, 24);
            this.tsb_OpenRpt.Text = "打开报告";
            this.tsb_OpenRpt.Click += new System.EventHandler(this.tsb_OpenRpt_Click);
            // 
            // tss7
            // 
            this.tss7.AutoSize = false;
            this.tss7.Name = "tss7";
            this.tss7.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_OpenImg
            // 
            this.tsb_OpenImg.AutoSize = false;
            this.tsb_OpenImg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsb_OpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsb_OpenImg.Image")));
            this.tsb_OpenImg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsb_OpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OpenImg.Name = "tsb_OpenImg";
            this.tsb_OpenImg.Size = new System.Drawing.Size(90, 27);
            this.tsb_OpenImg.Text = "打开图像";
            this.tsb_OpenImg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsb_OpenImg.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsb_OpenImg.Click += new System.EventHandler(this.tsb_OpenImg_Click);
            // 
            // GroupBox_QueryItem
            // 
            this.GroupBox_QueryItem.AutoScroll = true;
            this.GroupBox_QueryItem.BackgroundColor = System.Drawing.Color.White;
            this.GroupBox_QueryItem.BackgroundGradientColor = System.Drawing.Color.White;
            this.GroupBox_QueryItem.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.GroupBox_QueryItem.BorderColor = System.Drawing.Color.Black;
            this.GroupBox_QueryItem.BorderThickness = 1F;
            this.GroupBox_QueryItem.Controls.Add(this.txt_ExamGroup);
            this.GroupBox_QueryItem.Controls.Add(this.txt_DiagImpression);
            this.GroupBox_QueryItem.Controls.Add(this.label16);
            this.GroupBox_QueryItem.Controls.Add(this.label15);
            this.GroupBox_QueryItem.Controls.Add(this.txt_ExamDoctor);
            this.GroupBox_QueryItem.Controls.Add(this.label13);
            this.GroupBox_QueryItem.Controls.Add(this.txt_ExamAccessionNum);
            this.GroupBox_QueryItem.Controls.Add(this.label11);
            this.GroupBox_QueryItem.Controls.Add(this.dtp_From);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_DateType);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_ExamItem);
            this.GroupBox_QueryItem.Controls.Add(this.label9);
            this.GroupBox_QueryItem.Controls.Add(this.txt_InpNo);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_ReportType);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_IsOnline);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_PatientSource);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_ChargeType);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_ExamClass);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_ExamSubClass);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_ReferDept);
            this.GroupBox_QueryItem.Controls.Add(this.cmb_ReferDoctor);
            this.GroupBox_QueryItem.Controls.Add(this.dtp_To);
            this.GroupBox_QueryItem.Controls.Add(this.label8);
            this.GroupBox_QueryItem.Controls.Add(this.label7);
            this.GroupBox_QueryItem.Controls.Add(this.txt_PatientLocalId);
            this.GroupBox_QueryItem.Controls.Add(this.txt_PatientID);
            this.GroupBox_QueryItem.Controls.Add(this.txt_Name);
            this.GroupBox_QueryItem.Controls.Add(this.label5);
            this.GroupBox_QueryItem.Controls.Add(this.label24);
            this.GroupBox_QueryItem.Controls.Add(this.label1);
            this.GroupBox_QueryItem.Controls.Add(this.label4);
            this.GroupBox_QueryItem.Controls.Add(this.label37);
            this.GroupBox_QueryItem.Controls.Add(this.label2);
            this.GroupBox_QueryItem.Controls.Add(this.label49);
            this.GroupBox_QueryItem.Controls.Add(this.label47);
            this.GroupBox_QueryItem.Controls.Add(this.label12);
            this.GroupBox_QueryItem.Controls.Add(this.label48);
            this.GroupBox_QueryItem.Controls.Add(this.label3);
            this.GroupBox_QueryItem.Controls.Add(this.label6);
            this.GroupBox_QueryItem.Controls.Add(this.label14);
            this.GroupBox_QueryItem.CustomGroupBoxColor = System.Drawing.Color.LightCyan;
            this.GroupBox_QueryItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox_QueryItem.GroupImage = null;
            this.GroupBox_QueryItem.GroupTitle = "查询条件";
            this.GroupBox_QueryItem.Location = new System.Drawing.Point(0, 28);
            this.GroupBox_QueryItem.Name = "GroupBox_QueryItem";
            this.GroupBox_QueryItem.Padding = new System.Windows.Forms.Padding(20);
            this.GroupBox_QueryItem.PaintGroupBox = true;
            this.GroupBox_QueryItem.RoundCorners = 10;
            this.GroupBox_QueryItem.ShadowColor = System.Drawing.Color.DarkGray;
            this.GroupBox_QueryItem.ShadowControl = false;
            this.GroupBox_QueryItem.ShadowThickness = 3;
            this.GroupBox_QueryItem.Size = new System.Drawing.Size(1066, 130);
            this.GroupBox_QueryItem.TabIndex = 57;
            // 
            // txt_ExamGroup
            // 
            this.txt_ExamGroup.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ExamGroup.ForeColor = System.Drawing.Color.Black;
            this.txt_ExamGroup.IsChangeColor = true;
            this.txt_ExamGroup.Location = new System.Drawing.Point(985, 57);
            this.txt_ExamGroup.Name = "txt_ExamGroup";
            this.txt_ExamGroup.Size = new System.Drawing.Size(26, 21);
            this.txt_ExamGroup.TabIndex = 143;
            this.txt_ExamGroup.Visible = false;
            this.txt_ExamGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ExamGroup_KeyDown);
            // 
            // txt_DiagImpression
            // 
            this.txt_DiagImpression.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_DiagImpression.ForeColor = System.Drawing.Color.Black;
            this.txt_DiagImpression.IsChangeColor = true;
            this.txt_DiagImpression.Location = new System.Drawing.Point(584, 88);
            this.txt_DiagImpression.Name = "txt_DiagImpression";
            this.txt_DiagImpression.Size = new System.Drawing.Size(312, 21);
            this.txt_DiagImpression.TabIndex = 142;
            this.txt_DiagImpression.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DiagImpression_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(521, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 141;
            this.label16.Text = "诊断意见：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(922, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 139;
            this.label15.Text = "诊    室：";
            this.label15.Visible = false;
            // 
            // txt_ExamDoctor
            // 
            this.txt_ExamDoctor.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ExamDoctor.ForeColor = System.Drawing.Color.Black;
            this.txt_ExamDoctor.IsChangeColor = true;
            this.txt_ExamDoctor.Location = new System.Drawing.Point(985, 36);
            this.txt_ExamDoctor.Name = "txt_ExamDoctor";
            this.txt_ExamDoctor.Size = new System.Drawing.Size(26, 21);
            this.txt_ExamDoctor.TabIndex = 138;
            this.txt_ExamDoctor.Visible = false;
            this.txt_ExamDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ExamDoctor_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(922, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 137;
            this.label13.Text = "检查医生：";
            this.label13.Visible = false;
            // 
            // txt_ExamAccessionNum
            // 
            this.txt_ExamAccessionNum.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ExamAccessionNum.ForeColor = System.Drawing.Color.Black;
            this.txt_ExamAccessionNum.IsChangeColor = true;
            this.txt_ExamAccessionNum.Location = new System.Drawing.Point(70, 34);
            this.txt_ExamAccessionNum.Name = "txt_ExamAccessionNum";
            this.txt_ExamAccessionNum.Size = new System.Drawing.Size(100, 21);
            this.txt_ExamAccessionNum.TabIndex = 136;
            this.txt_ExamAccessionNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ExamAccessionNum_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(9, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 135;
            this.label11.Text = "申 请 号：";
            // 
            // dtp_From
            // 
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_From.Location = new System.Drawing.Point(681, 34);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.ShowCheckBox = true;
            this.dtp_From.Size = new System.Drawing.Size(98, 21);
            this.dtp_From.TabIndex = 134;
            // 
            // cmb_DateType
            // 
            this.cmb_DateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DateType.FormattingEnabled = true;
            this.cmb_DateType.Items.AddRange(new object[] {
            "登记时间",
            "检查时间",
            "报告时间"});
            this.cmb_DateType.Location = new System.Drawing.Point(584, 34);
            this.cmb_DateType.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_DateType.MaxDropDownItems = 15;
            this.cmb_DateType.Name = "cmb_DateType";
            this.cmb_DateType.Size = new System.Drawing.Size(77, 20);
            this.cmb_DateType.TabIndex = 133;
            // 
            // cmb_ExamItem
            // 
            this.cmb_ExamItem.DropDownWidth = 140;
            this.cmb_ExamItem.FormattingEnabled = true;
            this.cmb_ExamItem.Location = new System.Drawing.Point(777, 62);
            this.cmb_ExamItem.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamItem.MaxDropDownItems = 15;
            this.cmb_ExamItem.Name = "cmb_ExamItem";
            this.cmb_ExamItem.Size = new System.Drawing.Size(119, 20);
            this.cmb_ExamItem.TabIndex = 131;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(713, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 132;
            this.label9.Text = "检查项目：";
            // 
            // txt_InpNo
            // 
            this.txt_InpNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_InpNo.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_InpNo.ForeColor = System.Drawing.Color.Black;
            this.txt_InpNo.IsChangeColor = true;
            this.txt_InpNo.Location = new System.Drawing.Point(70, 62);
            this.txt_InpNo.Name = "txt_InpNo";
            this.txt_InpNo.Size = new System.Drawing.Size(100, 21);
            this.txt_InpNo.TabIndex = 130;
            this.txt_InpNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_InpNo_KeyDown);
            // 
            // cmb_ReportType
            // 
            this.cmb_ReportType.FormattingEnabled = true;
            this.cmb_ReportType.Items.AddRange(new object[] {
            "",
            "初步报告",
            "提交待审核",
            "审核报告",
            "冻结报告"});
            this.cmb_ReportType.Location = new System.Drawing.Point(413, 89);
            this.cmb_ReportType.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ReportType.Name = "cmb_ReportType";
            this.cmb_ReportType.Size = new System.Drawing.Size(100, 20);
            this.cmb_ReportType.TabIndex = 128;
            // 
            // cmb_IsOnline
            // 
            this.cmb_IsOnline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IsOnline.FormattingEnabled = true;
            this.cmb_IsOnline.Items.AddRange(new object[] {
            "",
            "在线",
            "离线"});
            this.cmb_IsOnline.Location = new System.Drawing.Point(242, 89);
            this.cmb_IsOnline.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_IsOnline.Name = "cmb_IsOnline";
            this.cmb_IsOnline.Size = new System.Drawing.Size(100, 20);
            this.cmb_IsOnline.TabIndex = 128;
            // 
            // cmb_PatientSource
            // 
            this.cmb_PatientSource.FormattingEnabled = true;
            this.cmb_PatientSource.Location = new System.Drawing.Point(70, 89);
            this.cmb_PatientSource.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_PatientSource.Name = "cmb_PatientSource";
            this.cmb_PatientSource.Size = new System.Drawing.Size(100, 20);
            this.cmb_PatientSource.TabIndex = 125;
            // 
            // cmb_ChargeType
            // 
            this.cmb_ChargeType.FormattingEnabled = true;
            this.cmb_ChargeType.Location = new System.Drawing.Point(983, 17);
            this.cmb_ChargeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ChargeType.MaxDropDownItems = 20;
            this.cmb_ChargeType.Name = "cmb_ChargeType";
            this.cmb_ChargeType.Size = new System.Drawing.Size(26, 20);
            this.cmb_ChargeType.TabIndex = 124;
            this.cmb_ChargeType.Visible = false;
            // 
            // cmb_ExamClass
            // 
            this.cmb_ExamClass.FormattingEnabled = true;
            this.cmb_ExamClass.Location = new System.Drawing.Point(413, 62);
            this.cmb_ExamClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamClass.Name = "cmb_ExamClass";
            this.cmb_ExamClass.Size = new System.Drawing.Size(100, 20);
            this.cmb_ExamClass.TabIndex = 117;
            this.cmb_ExamClass.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamClass_SelectedIndexChanged);
            // 
            // cmb_ExamSubClass
            // 
            this.cmb_ExamSubClass.FormattingEnabled = true;
            this.cmb_ExamSubClass.Location = new System.Drawing.Point(584, 62);
            this.cmb_ExamSubClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamSubClass.Name = "cmb_ExamSubClass";
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(116, 20);
            this.cmb_ExamSubClass.TabIndex = 118;
            this.cmb_ExamSubClass.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamSubClass_SelectedIndexChanged);
            // 
            // cmb_ReferDept
            // 
            this.cmb_ReferDept.FormattingEnabled = true;
            this.cmb_ReferDept.Location = new System.Drawing.Point(985, 78);
            this.cmb_ReferDept.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ReferDept.MaxDropDownItems = 30;
            this.cmb_ReferDept.Name = "cmb_ReferDept";
            this.cmb_ReferDept.Size = new System.Drawing.Size(26, 20);
            this.cmb_ReferDept.TabIndex = 113;
            this.cmb_ReferDept.Visible = false;
            this.cmb_ReferDept.SelectedIndexChanged += new System.EventHandler(this.cmb_ReferDept_SelectedIndexChanged);
            // 
            // cmb_ReferDoctor
            // 
            this.cmb_ReferDoctor.FormattingEnabled = true;
            this.cmb_ReferDoctor.Location = new System.Drawing.Point(880, 13);
            this.cmb_ReferDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ReferDoctor.MaxDropDownItems = 15;
            this.cmb_ReferDoctor.Name = "cmb_ReferDoctor";
            this.cmb_ReferDoctor.Size = new System.Drawing.Size(26, 20);
            this.cmb_ReferDoctor.TabIndex = 114;
            this.cmb_ReferDoctor.Visible = false;
            // 
            // dtp_To
            // 
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_To.Location = new System.Drawing.Point(798, 34);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.ShowCheckBox = true;
            this.dtp_To.Size = new System.Drawing.Size(98, 21);
            this.dtp_To.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(782, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "到";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(663, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "从";
            // 
            // txt_PatientLocalId
            // 
            this.txt_PatientLocalId.BackColor = System.Drawing.Color.White;
            this.txt_PatientLocalId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PatientLocalId.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientLocalId.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientLocalId.IsChangeColor = true;
            this.txt_PatientLocalId.Location = new System.Drawing.Point(242, 62);
            this.txt_PatientLocalId.Name = "txt_PatientLocalId";
            this.txt_PatientLocalId.Size = new System.Drawing.Size(100, 21);
            this.txt_PatientLocalId.TabIndex = 16;
            this.txt_PatientLocalId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PatientLocalId_KeyDown);
            // 
            // txt_PatientID
            // 
            this.txt_PatientID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PatientID.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientID.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientID.IsChangeColor = true;
            this.txt_PatientID.Location = new System.Drawing.Point(243, 33);
            this.txt_PatientID.Name = "txt_PatientID";
            this.txt_PatientID.Size = new System.Drawing.Size(100, 21);
            this.txt_PatientID.TabIndex = 14;
            this.txt_PatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PatientID_KeyDown);
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_Name.ForeColor = System.Drawing.Color.Black;
            this.txt_Name.IsChangeColor = true;
            this.txt_Name.Location = new System.Drawing.Point(413, 33);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(100, 21);
            this.txt_Name.TabIndex = 12;
            this.txt_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Name_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 129;
            this.label5.Text = "住 院 号：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(350, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 120;
            this.label24.Text = "检查类别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(350, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "病人姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 127;
            this.label4.Text = "病人来源：";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.Blue;
            this.label37.Location = new System.Drawing.Point(521, 66);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(65, 12);
            this.label37.TabIndex = 119;
            this.label37.Text = "检查子类：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(179, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "病 人 ID：";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.Color.Blue;
            this.label49.Location = new System.Drawing.Point(922, 21);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(65, 12);
            this.label49.TabIndex = 126;
            this.label49.Text = "收费类别：";
            this.label49.Visible = false;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.Color.Blue;
            this.label47.Location = new System.Drawing.Point(922, 82);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(65, 12);
            this.label47.TabIndex = 116;
            this.label47.Text = "申请科室：";
            this.label47.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(179, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "检 查 号：";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.Color.Blue;
            this.label48.Location = new System.Drawing.Point(817, 17);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(65, 12);
            this.label48.TabIndex = 115;
            this.label48.Text = "申请医生：";
            this.label48.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(521, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "时间范围：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(350, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "报告类型：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(179, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "在线状态：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.l_Count);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 20);
            this.panel1.TabIndex = 58;
            // 
            // l_Count
            // 
            this.l_Count.Dock = System.Windows.Forms.DockStyle.Right;
            this.l_Count.ForeColor = System.Drawing.Color.Blue;
            this.l_Count.Location = new System.Drawing.Point(895, 0);
            this.l_Count.Name = "l_Count";
            this.l_Count.Size = new System.Drawing.Size(171, 20);
            this.l_Count.TabIndex = 54;
            this.l_Count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(8, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 53;
            this.label10.Text = "检查列表";
            // 
            // dgv_Study
            // 
            this.dgv_Study.AllowUserToAddRows = false;
            this.dgv_Study.AllowUserToDeleteRows = false;
            this.dgv_Study.AllowUserToOrderColumns = true;
            this.dgv_Study.AllowUserToResizeRows = false;
            this.dgv_Study.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Study.ContextMenuStrip = this.cms_Study;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Study.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Study.DefaultScaleWidth = 1280;
            this.dgv_Study.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Study.Location = new System.Drawing.Point(0, 178);
            this.dgv_Study.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Study.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Study.MergeColumnNames")));
            this.dgv_Study.MultiSelect = false;
            this.dgv_Study.Name = "dgv_Study";
            this.dgv_Study.ReadOnly = true;
            this.dgv_Study.RowHeadersVisible = false;
            this.dgv_Study.RowTemplate.Height = 23;
            this.dgv_Study.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Study.Size = new System.Drawing.Size(1066, 318);
            this.dgv_Study.TabIndex = 59;
            this.dgv_Study.XmlFile = null;
            this.dgv_Study.DoubleClick += new System.EventHandler(this.dgv_Study_DoubleClick);
            this.dgv_Study.Click += new System.EventHandler(this.dgv_Study_Click);
            // 
            // cms_Study
            // 
            this.cms_Study.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ChangeList});
            this.cms_Study.Name = "cms_BackImg";
            this.cms_Study.Size = new System.Drawing.Size(119, 26);
            // 
            // tsmi_ChangeList
            // 
            this.tsmi_ChangeList.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ChangeList.Image")));
            this.tsmi_ChangeList.Name = "tsmi_ChangeList";
            this.tsmi_ChangeList.Size = new System.Drawing.Size(118, 22);
            this.tsmi_ChangeList.Text = "调整列表";
            this.tsmi_ChangeList.Click += new System.EventHandler(this.tsmi_ChangeList_Click);
            // 
            // p_Buttom
            // 
            this.p_Buttom.AutoScroll = true;
            this.p_Buttom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Buttom.Controls.Add(this.txt_Description);
            this.p_Buttom.Controls.Add(this.splitter2);
            this.p_Buttom.Controls.Add(this.txt_Impression);
            this.p_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Buttom.Location = new System.Drawing.Point(0, 499);
            this.p_Buttom.Name = "p_Buttom";
            this.p_Buttom.Size = new System.Drawing.Size(1066, 147);
            this.p_Buttom.TabIndex = 60;
            // 
            // txt_Description
            // 
            this.txt_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Description.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_Description.ForeColor = System.Drawing.Color.Blue;
            this.txt_Description.IsChangeColor = true;
            this.txt_Description.Location = new System.Drawing.Point(0, 0);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Description.Size = new System.Drawing.Size(555, 145);
            this.txt_Description.TabIndex = 9;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(555, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 145);
            this.splitter2.TabIndex = 10;
            this.splitter2.TabStop = false;
            // 
            // txt_Impression
            // 
            this.txt_Impression.Dock = System.Windows.Forms.DockStyle.Right;
            this.txt_Impression.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_Impression.ForeColor = System.Drawing.Color.Blue;
            this.txt_Impression.IsChangeColor = true;
            this.txt_Impression.Location = new System.Drawing.Point(558, 0);
            this.txt_Impression.Multiline = true;
            this.txt_Impression.Name = "txt_Impression";
            this.txt_Impression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Impression.Size = new System.Drawing.Size(506, 145);
            this.txt_Impression.TabIndex = 7;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 496);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1066, 3);
            this.splitter1.TabIndex = 61;
            this.splitter1.TabStop = false;
            // 
            // frmPacsStudy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1066, 646);
            this.Controls.Add(this.dgv_Study);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.p_Buttom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBox_QueryItem);
            this.Controls.Add(this.toolStrip);
            this.Name = "frmPacsStudy";
            this.Text = "frmPacsStudy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPacsStudy_FormClosing);
            this.Load += new System.EventHandler(this.frmPacsStudy_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.GroupBox_QueryItem.ResumeLayout(false);
            this.GroupBox_QueryItem.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Study)).EndInit();
            this.cms_Study.ResumeLayout(false);
            this.p_Buttom.ResumeLayout(false);
            this.p_Buttom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ToolStripButton tsb_Find;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.ToolStripButton tsb_Clear;
        private System.Windows.Forms.ToolStripSeparator tss3;
        private System.Windows.Forms.ToolStripButton tsb_OpenRpt;
        private System.Windows.Forms.ToolStripButton tsb_OpenImg;
        private BaseControls.GroupBox.MyGroupBox GroupBox_QueryItem;
        private System.Windows.Forms.ComboBox cmb_DateType;
        private System.Windows.Forms.ComboBox cmb_ExamItem;
        private System.Windows.Forms.Label label9;
        private BaseControls.userTextBox txt_InpNo;
        private System.Windows.Forms.ComboBox cmb_ReportType;
        private System.Windows.Forms.ComboBox cmb_PatientSource;
        private System.Windows.Forms.ComboBox cmb_ChargeType;
        private System.Windows.Forms.ComboBox cmb_ExamClass;
        private System.Windows.Forms.ComboBox cmb_ExamSubClass;
        private System.Windows.Forms.ComboBox cmb_ReferDept;
        private System.Windows.Forms.ComboBox cmb_ReferDoctor;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private BaseControls.userTextBox txt_PatientLocalId;
        private BaseControls.userTextBox txt_PatientID;
        private BaseControls.userTextBox txt_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label l_Count;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripSeparator tss7;
        private BaseControls.MyDataGridView dgv_Study;
        private System.Windows.Forms.ComboBox cmb_IsOnline;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.ContextMenuStrip cms_Study;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ChangeList;
        private System.Windows.Forms.Panel p_Buttom;
        private BaseControls.userTextBox txt_Description;
        private System.Windows.Forms.Splitter splitter2;
        private BaseControls.userTextBox txt_Impression;
        private System.Windows.Forms.Splitter splitter1;
        private BaseControls.userTextBox txt_ExamAccessionNum;
        private System.Windows.Forms.Label label11;
        private BaseControls.userTextBox txt_ExamDoctor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private BaseControls.userTextBox txt_DiagImpression;
        private System.Windows.Forms.Label label16;
        private BaseControls.userTextBox txt_ExamGroup;
    }
}