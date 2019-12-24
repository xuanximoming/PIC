namespace SIS
{
    partial class frmExamInf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamInf));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_BaseInf = new System.Windows.Forms.TabPage();
            this.btn_AddExamItem = new System.Windows.Forms.Button();
            this.label45 = new BaseControls.MyLabel();
            this.dud_PatientLocalId = new BaseControls.MyDomainUpDown();
            this.txt_Costs = new BaseControls.TextBoxExDecimal(this.components);
            this.label26 = new BaseControls.MyLabel();
            this.txt_Charges = new BaseControls.TextBoxExDecimal(this.components);
            this.label27 = new BaseControls.MyLabel();
            this.cmb_ChargeType = new System.Windows.Forms.ComboBox();
            this.label49 = new BaseControls.MyLabel();
            this.cmb_AgeUnit = new System.Windows.Forms.ComboBox();
            this.cmb_ExamSubClass = new System.Windows.Forms.ComboBox();
            this.cmb_ExamClass = new System.Windows.Forms.ComboBox();
            this.cmb_PatientSource = new System.Windows.Forms.ComboBox();
            this.cmb_Sex = new System.Windows.Forms.ComboBox();
            this.cmb_Transcriber = new System.Windows.Forms.ComboBox();
            this.lv_ExamItem = new System.Windows.Forms.ListView();
            this.Item_Name = new System.Windows.Forms.ColumnHeader();
            this.Item_Charge = new System.Windows.Forms.ColumnHeader();
            this.Item_Cost = new System.Windows.Forms.ColumnHeader();
            this.Item_Index = new System.Windows.Forms.ColumnHeader();
            this.cmb_ExamItems = new System.Windows.Forms.ComboBox();
            this.cmb_ReferDoctor = new System.Windows.Forms.ComboBox();
            this.rb_Abnormal = new System.Windows.Forms.RadioButton();
            this.cmb_ReferDept = new System.Windows.Forms.ComboBox();
            this.rb_NoAbnormal = new System.Windows.Forms.RadioButton();
            this.txt_PatientAge = new BaseControls.userTextBox();
            this.txt_PatientName = new BaseControls.userTextBox();
            this.cb_IsInquiry = new System.Windows.Forms.CheckBox();
            this.myLabel4 = new BaseControls.MyLabel();
            this.txt_ReportDateTime = new BaseControls.userTextBox();
            this.txt_InpNo = new BaseControls.userTextBox();
            this.txt_BedNum = new BaseControls.userTextBox();
            this.myLabel2 = new BaseControls.MyLabel();
            this.myLabel14 = new BaseControls.MyLabel();
            this.myLabel8 = new BaseControls.MyLabel();
            this.myLabel6 = new BaseControls.MyLabel();
            this.myLabel5 = new BaseControls.MyLabel();
            this.label47 = new BaseControls.MyLabel();
            this.label48 = new BaseControls.MyLabel();
            this.myLabel11 = new BaseControls.MyLabel();
            this.myLabel7 = new BaseControls.MyLabel();
            this.myLabel10 = new BaseControls.MyLabel();
            this.myLabel9 = new BaseControls.MyLabel();
            this.myLabel13 = new BaseControls.MyLabel();
            this.tabPage_HIS = new System.Windows.Forms.TabPage();
            this.button_zybl = new System.Windows.Forms.Button();
            this.button_mzbl = new System.Windows.Forms.Button();
            this.button_LISReport = new System.Windows.Forms.Button();
            this.button_CheckList = new System.Windows.Forms.Button();
            this.tabPage_OtherInf = new System.Windows.Forms.TabPage();
            this.gb_ClinicInf = new System.Windows.Forms.GroupBox();
            this.label38 = new BaseControls.MyLabel();
            this.txt_ClinDiag = new System.Windows.Forms.TextBox();
            this.label34 = new BaseControls.MyLabel();
            this.txt_ClinSymp = new System.Windows.Forms.TextBox();
            this.label40 = new BaseControls.MyLabel();
            this.txt_PhysSign = new System.Windows.Forms.TextBox();
            this.gb_TestInf = new System.Windows.Forms.GroupBox();
            this.txt_ReqMemo = new System.Windows.Forms.TextBox();
            this.label35 = new BaseControls.MyLabel();
            this.txt_RelevantDiag = new System.Windows.Forms.TextBox();
            this.label33 = new BaseControls.MyLabel();
            this.txt_RelevantLabTest = new System.Windows.Forms.TextBox();
            this.label32 = new BaseControls.MyLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmb_ExamGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new BaseControls.MyLabel();
            this.label23 = new BaseControls.MyLabel();
            this.cmb_ImgEquipment = new System.Windows.Forms.ComboBox();
            this.txt_PatientId = new BaseControls.userTextBox();
            this.txt_TelephoneNum = new System.Windows.Forms.TextBox();
            this.txt_OpdNo = new System.Windows.Forms.TextBox();
            this.myLabel15 = new BaseControls.MyLabel();
            this.label42 = new BaseControls.MyLabel();
            this.myLabel1 = new BaseControls.MyLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage_BaseInf.SuspendLayout();
            this.tabPage_HIS.SuspendLayout();
            this.tabPage_OtherInf.SuspendLayout();
            this.gb_ClinicInf.SuspendLayout();
            this.gb_TestInf.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_BaseInf);
            this.tabControl1.Controls.Add(this.tabPage_HIS);
            this.tabControl1.Controls.Add(this.tabPage_OtherInf);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 235);
            this.tabControl1.TabIndex = 118;
            // 
            // tabPage_BaseInf
            // 
            this.tabPage_BaseInf.AutoScroll = true;
            this.tabPage_BaseInf.Controls.Add(this.btn_AddExamItem);
            this.tabPage_BaseInf.Controls.Add(this.label45);
            this.tabPage_BaseInf.Controls.Add(this.dud_PatientLocalId);
            this.tabPage_BaseInf.Controls.Add(this.txt_Costs);
            this.tabPage_BaseInf.Controls.Add(this.label26);
            this.tabPage_BaseInf.Controls.Add(this.txt_Charges);
            this.tabPage_BaseInf.Controls.Add(this.label27);
            this.tabPage_BaseInf.Controls.Add(this.cmb_ChargeType);
            this.tabPage_BaseInf.Controls.Add(this.label49);
            this.tabPage_BaseInf.Controls.Add(this.cmb_AgeUnit);
            this.tabPage_BaseInf.Controls.Add(this.cmb_ExamSubClass);
            this.tabPage_BaseInf.Controls.Add(this.cmb_ExamClass);
            this.tabPage_BaseInf.Controls.Add(this.cmb_PatientSource);
            this.tabPage_BaseInf.Controls.Add(this.cmb_Sex);
            this.tabPage_BaseInf.Controls.Add(this.cmb_Transcriber);
            this.tabPage_BaseInf.Controls.Add(this.lv_ExamItem);
            this.tabPage_BaseInf.Controls.Add(this.cmb_ExamItems);
            this.tabPage_BaseInf.Controls.Add(this.cmb_ReferDoctor);
            this.tabPage_BaseInf.Controls.Add(this.rb_Abnormal);
            this.tabPage_BaseInf.Controls.Add(this.cmb_ReferDept);
            this.tabPage_BaseInf.Controls.Add(this.rb_NoAbnormal);
            this.tabPage_BaseInf.Controls.Add(this.txt_PatientAge);
            this.tabPage_BaseInf.Controls.Add(this.txt_PatientName);
            this.tabPage_BaseInf.Controls.Add(this.cb_IsInquiry);
            this.tabPage_BaseInf.Controls.Add(this.myLabel4);
            this.tabPage_BaseInf.Controls.Add(this.txt_ReportDateTime);
            this.tabPage_BaseInf.Controls.Add(this.txt_InpNo);
            this.tabPage_BaseInf.Controls.Add(this.txt_BedNum);
            this.tabPage_BaseInf.Controls.Add(this.myLabel2);
            this.tabPage_BaseInf.Controls.Add(this.myLabel14);
            this.tabPage_BaseInf.Controls.Add(this.myLabel8);
            this.tabPage_BaseInf.Controls.Add(this.myLabel6);
            this.tabPage_BaseInf.Controls.Add(this.myLabel5);
            this.tabPage_BaseInf.Controls.Add(this.label47);
            this.tabPage_BaseInf.Controls.Add(this.label48);
            this.tabPage_BaseInf.Controls.Add(this.myLabel11);
            this.tabPage_BaseInf.Controls.Add(this.myLabel7);
            this.tabPage_BaseInf.Controls.Add(this.myLabel10);
            this.tabPage_BaseInf.Controls.Add(this.myLabel9);
            this.tabPage_BaseInf.Controls.Add(this.myLabel13);
            this.tabPage_BaseInf.Location = new System.Drawing.Point(4, 21);
            this.tabPage_BaseInf.Name = "tabPage_BaseInf";
            this.tabPage_BaseInf.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BaseInf.Size = new System.Drawing.Size(685, 210);
            this.tabPage_BaseInf.TabIndex = 0;
            this.tabPage_BaseInf.Text = "基本信息";
            this.tabPage_BaseInf.UseVisualStyleBackColor = true;
            // 
            // btn_AddExamItem
            // 
            this.btn_AddExamItem.FlatAppearance.BorderSize = 0;
            this.btn_AddExamItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddExamItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_AddExamItem.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddExamItem.Image")));
            this.btn_AddExamItem.Location = new System.Drawing.Point(577, 65);
            this.btn_AddExamItem.Name = "btn_AddExamItem";
            this.btn_AddExamItem.Size = new System.Drawing.Size(16, 16);
            this.btn_AddExamItem.TabIndex = 203;
            this.btn_AddExamItem.UseVisualStyleBackColor = true;
            this.btn_AddExamItem.Click += new System.EventHandler(this.btn_AddExamItem_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 9F);
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(8, 93);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(53, 12);
            this.label45.TabIndex = 143;
            this.label45.Text = "检 查 号";
            // 
            // dud_PatientLocalId
            // 
            this.dud_PatientLocalId.Location = new System.Drawing.Point(64, 87);
            this.dud_PatientLocalId.Name = "dud_PatientLocalId";
            this.dud_PatientLocalId.Size = new System.Drawing.Size(89, 21);
            this.dud_PatientLocalId.TabIndex = 144;
            this.dud_PatientLocalId.TextChanged += new System.EventHandler(this.dud_PatientLocalId_TextChanged);
            // 
            // txt_Costs
            // 
            this.txt_Costs.Location = new System.Drawing.Point(219, 87);
            this.txt_Costs.Name = "txt_Costs";
            this.txt_Costs.Size = new System.Drawing.Size(55, 21);
            this.txt_Costs.TabIndex = 129;
            this.txt_Costs.Text = "0";
            this.txt_Costs.TextChanged += new System.EventHandler(this.txt_Costs_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 9F);
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(163, 93);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 128;
            this.label26.Text = "费    用";
            // 
            // txt_Charges
            // 
            this.txt_Charges.Location = new System.Drawing.Point(539, 183);
            this.txt_Charges.Name = "txt_Charges";
            this.txt_Charges.Size = new System.Drawing.Size(62, 21);
            this.txt_Charges.TabIndex = 142;
            this.txt_Charges.Text = "0";
            this.txt_Charges.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 9F);
            this.label27.ForeColor = System.Drawing.Color.Blue;
            this.label27.Location = new System.Drawing.Point(480, 186);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 12);
            this.label27.TabIndex = 141;
            this.label27.Text = "标准收费:";
            this.label27.Visible = false;
            // 
            // cmb_ChargeType
            // 
            this.cmb_ChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ChargeType.FormattingEnabled = true;
            this.cmb_ChargeType.Location = new System.Drawing.Point(331, 183);
            this.cmb_ChargeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ChargeType.MaxDropDownItems = 20;
            this.cmb_ChargeType.Name = "cmb_ChargeType";
            this.cmb_ChargeType.Size = new System.Drawing.Size(141, 20);
            this.cmb_ChargeType.TabIndex = 139;
            this.cmb_ChargeType.Visible = false;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 9F);
            this.label49.ForeColor = System.Drawing.Color.Blue;
            this.label49.Location = new System.Drawing.Point(270, 186);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(59, 12);
            this.label49.TabIndex = 140;
            this.label49.Text = "收费类别:";
            this.label49.Visible = false;
            // 
            // cmb_AgeUnit
            // 
            this.cmb_AgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AgeUnit.FormattingEnabled = true;
            this.cmb_AgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天"});
            this.cmb_AgeUnit.Location = new System.Drawing.Point(346, 9);
            this.cmb_AgeUnit.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_AgeUnit.Name = "cmb_AgeUnit";
            this.cmb_AgeUnit.Size = new System.Drawing.Size(39, 20);
            this.cmb_AgeUnit.TabIndex = 138;
            this.cmb_AgeUnit.TextChanged += new System.EventHandler(this.cmb_AgeUnit_TextChanged);
            // 
            // cmb_ExamSubClass
            // 
            this.cmb_ExamSubClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExamSubClass.FormattingEnabled = true;
            this.cmb_ExamSubClass.Location = new System.Drawing.Point(219, 61);
            this.cmb_ExamSubClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamSubClass.Name = "cmb_ExamSubClass";
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(89, 20);
            this.cmb_ExamSubClass.TabIndex = 137;
            this.cmb_ExamSubClass.SelectionChangeCommitted += new System.EventHandler(this.cmb_ExamSubClass_SelectionChangeCommitted);
            this.cmb_ExamSubClass.TextChanged += new System.EventHandler(this.cmb_ExamSubClass_TextChanged);
            // 
            // cmb_ExamClass
            // 
            this.cmb_ExamClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExamClass.FormattingEnabled = true;
            this.cmb_ExamClass.Location = new System.Drawing.Point(64, 61);
            this.cmb_ExamClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamClass.Name = "cmb_ExamClass";
            this.cmb_ExamClass.Size = new System.Drawing.Size(89, 20);
            this.cmb_ExamClass.TabIndex = 136;
            this.cmb_ExamClass.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamClass_SelectedIndexChanged);
            this.cmb_ExamClass.TextChanged += new System.EventHandler(this.cmb_ExamClass_TextChanged);
            // 
            // cmb_PatientSource
            // 
            this.cmb_PatientSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PatientSource.FormattingEnabled = true;
            this.cmb_PatientSource.Location = new System.Drawing.Point(64, 35);
            this.cmb_PatientSource.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_PatientSource.Name = "cmb_PatientSource";
            this.cmb_PatientSource.Size = new System.Drawing.Size(89, 20);
            this.cmb_PatientSource.TabIndex = 135;
            this.cmb_PatientSource.TextChanged += new System.EventHandler(this.cmb_PatientSource_TextChanged);
            // 
            // cmb_Sex
            // 
            this.cmb_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Sex.FormattingEnabled = true;
            this.cmb_Sex.Items.AddRange(new object[] {
            "男",
            "女",
            "？"});
            this.cmb_Sex.Location = new System.Drawing.Point(219, 9);
            this.cmb_Sex.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Sex.Name = "cmb_Sex";
            this.cmb_Sex.Size = new System.Drawing.Size(55, 20);
            this.cmb_Sex.TabIndex = 133;
            this.cmb_Sex.TextChanged += new System.EventHandler(this.cmb_Sex_TextChanged);
            // 
            // cmb_Transcriber
            // 
            this.cmb_Transcriber.FormattingEnabled = true;
            this.cmb_Transcriber.Location = new System.Drawing.Point(64, 114);
            this.cmb_Transcriber.Name = "cmb_Transcriber";
            this.cmb_Transcriber.Size = new System.Drawing.Size(89, 20);
            this.cmb_Transcriber.TabIndex = 132;
            this.cmb_Transcriber.TextChanged += new System.EventHandler(this.cmb_Transcriber_TextChanged);
            // 
            // lv_ExamItem
            // 
            this.lv_ExamItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item_Name,
            this.Item_Charge,
            this.Item_Cost,
            this.Item_Index});
            this.lv_ExamItem.FullRowSelect = true;
            this.lv_ExamItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ExamItem.Location = new System.Drawing.Point(322, 86);
            this.lv_ExamItem.MultiSelect = false;
            this.lv_ExamItem.Name = "lv_ExamItem";
            this.lv_ExamItem.Size = new System.Drawing.Size(269, 77);
            this.lv_ExamItem.TabIndex = 130;
            this.lv_ExamItem.UseCompatibleStateImageBehavior = false;
            this.lv_ExamItem.View = System.Windows.Forms.View.Details;
            // 
            // Item_Name
            // 
            this.Item_Name.Text = "项目名称";
            this.Item_Name.Width = 190;
            // 
            // Item_Charge
            // 
            this.Item_Charge.Text = "标准费用";
            this.Item_Charge.Width = 0;
            // 
            // Item_Cost
            // 
            this.Item_Cost.DisplayIndex = 3;
            this.Item_Cost.Text = "费用";
            this.Item_Cost.Width = 42;
            // 
            // Item_Index
            // 
            this.Item_Index.DisplayIndex = 2;
            this.Item_Index.Text = "";
            this.Item_Index.Width = 0;
            // 
            // cmb_ExamItems
            // 
            this.cmb_ExamItems.FormattingEnabled = true;
            this.cmb_ExamItems.Location = new System.Drawing.Point(374, 65);
            this.cmb_ExamItems.Name = "cmb_ExamItems";
            this.cmb_ExamItems.Size = new System.Drawing.Size(201, 20);
            this.cmb_ExamItems.TabIndex = 131;
            this.cmb_ExamItems.SelectionChangeCommitted += new System.EventHandler(this.cmb_ExamItems_SelectionChangeCommitted);
            // 
            // cmb_ReferDoctor
            // 
            this.cmb_ReferDoctor.FormattingEnabled = true;
            this.cmb_ReferDoctor.Location = new System.Drawing.Point(374, 36);
            this.cmb_ReferDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ReferDoctor.MaxDropDownItems = 15;
            this.cmb_ReferDoctor.Name = "cmb_ReferDoctor";
            this.cmb_ReferDoctor.Size = new System.Drawing.Size(71, 20);
            this.cmb_ReferDoctor.TabIndex = 114;
            this.cmb_ReferDoctor.TextChanged += new System.EventHandler(this.cmb_ReferDoctor_TextChanged);
            // 
            // rb_Abnormal
            // 
            this.rb_Abnormal.AutoSize = true;
            this.rb_Abnormal.ForeColor = System.Drawing.Color.Red;
            this.rb_Abnormal.Location = new System.Drawing.Point(497, 39);
            this.rb_Abnormal.Name = "rb_Abnormal";
            this.rb_Abnormal.Size = new System.Drawing.Size(47, 16);
            this.rb_Abnormal.TabIndex = 85;
            this.rb_Abnormal.TabStop = true;
            this.rb_Abnormal.Text = "阳性";
            this.rb_Abnormal.UseVisualStyleBackColor = true;
            // 
            // cmb_ReferDept
            // 
            this.cmb_ReferDept.FormattingEnabled = true;
            this.cmb_ReferDept.Location = new System.Drawing.Point(219, 35);
            this.cmb_ReferDept.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ReferDept.MaxDropDownItems = 30;
            this.cmb_ReferDept.Name = "cmb_ReferDept";
            this.cmb_ReferDept.Size = new System.Drawing.Size(89, 20);
            this.cmb_ReferDept.TabIndex = 113;
            this.cmb_ReferDept.SelectedIndexChanged += new System.EventHandler(this.cmb_ReferDept_SelectedIndexChanged);
            this.cmb_ReferDept.TextChanged += new System.EventHandler(this.cmb_ReferDept_TextChanged);
            // 
            // rb_NoAbnormal
            // 
            this.rb_NoAbnormal.AutoSize = true;
            this.rb_NoAbnormal.ForeColor = System.Drawing.Color.Red;
            this.rb_NoAbnormal.Location = new System.Drawing.Point(447, 39);
            this.rb_NoAbnormal.Name = "rb_NoAbnormal";
            this.rb_NoAbnormal.Size = new System.Drawing.Size(47, 16);
            this.rb_NoAbnormal.TabIndex = 84;
            this.rb_NoAbnormal.TabStop = true;
            this.rb_NoAbnormal.Text = "阴性";
            this.rb_NoAbnormal.UseVisualStyleBackColor = true;
            // 
            // txt_PatientAge
            // 
            this.txt_PatientAge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PatientAge.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientAge.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientAge.IsChangeColor = true;
            this.txt_PatientAge.Location = new System.Drawing.Point(312, 8);
            this.txt_PatientAge.Name = "txt_PatientAge";
            this.txt_PatientAge.Size = new System.Drawing.Size(32, 21);
            this.txt_PatientAge.TabIndex = 89;
            this.txt_PatientAge.TextChanged += new System.EventHandler(this.txt_PatientAge_TextChanged);
            // 
            // txt_PatientName
            // 
            this.txt_PatientName.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientName.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientName.IsChangeColor = true;
            this.txt_PatientName.Location = new System.Drawing.Point(64, 8);
            this.txt_PatientName.Name = "txt_PatientName";
            this.txt_PatientName.Size = new System.Drawing.Size(89, 21);
            this.txt_PatientName.TabIndex = 87;
            this.txt_PatientName.TextChanged += new System.EventHandler(this.txt_PatientName_TextChanged);
            // 
            // cb_IsInquiry
            // 
            this.cb_IsInquiry.AutoSize = true;
            this.cb_IsInquiry.Location = new System.Drawing.Point(549, 39);
            this.cb_IsInquiry.Name = "cb_IsInquiry";
            this.cb_IsInquiry.Size = new System.Drawing.Size(48, 16);
            this.cb_IsInquiry.TabIndex = 108;
            this.cb_IsInquiry.Text = "随访";
            this.cb_IsInquiry.UseVisualStyleBackColor = true;
            // 
            // myLabel4
            // 
            this.myLabel4.AutoSize = true;
            this.myLabel4.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel4.ForeColor = System.Drawing.Color.Black;
            this.myLabel4.Location = new System.Drawing.Point(8, 120);
            this.myLabel4.Name = "myLabel4";
            this.myLabel4.Size = new System.Drawing.Size(53, 12);
            this.myLabel4.TabIndex = 80;
            this.myLabel4.Text = "报告医生";
            // 
            // txt_ReportDateTime
            // 
            this.txt_ReportDateTime.BackColor = System.Drawing.Color.White;
            this.txt_ReportDateTime.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_ReportDateTime.ForeColor = System.Drawing.Color.Black;
            this.txt_ReportDateTime.IsChangeColor = true;
            this.txt_ReportDateTime.Location = new System.Drawing.Point(219, 114);
            this.txt_ReportDateTime.Name = "txt_ReportDateTime";
            this.txt_ReportDateTime.Size = new System.Drawing.Size(89, 21);
            this.txt_ReportDateTime.TabIndex = 77;
            // 
            // txt_InpNo
            // 
            this.txt_InpNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_InpNo.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_InpNo.ForeColor = System.Drawing.Color.Black;
            this.txt_InpNo.IsChangeColor = true;
            this.txt_InpNo.Location = new System.Drawing.Point(445, 7);
            this.txt_InpNo.Name = "txt_InpNo";
            this.txt_InpNo.Size = new System.Drawing.Size(66, 21);
            this.txt_InpNo.TabIndex = 97;
            this.txt_InpNo.TextChanged += new System.EventHandler(this.txt_InpNo_TextChanged);
            // 
            // txt_BedNum
            // 
            this.txt_BedNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_BedNum.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_BedNum.ForeColor = System.Drawing.Color.Black;
            this.txt_BedNum.IsChangeColor = true;
            this.txt_BedNum.Location = new System.Drawing.Point(543, 7);
            this.txt_BedNum.Name = "txt_BedNum";
            this.txt_BedNum.Size = new System.Drawing.Size(47, 21);
            this.txt_BedNum.TabIndex = 95;
            this.txt_BedNum.TextChanged += new System.EventHandler(this.txt_BedNum_TextChanged);
            // 
            // myLabel2
            // 
            this.myLabel2.AutoSize = true;
            this.myLabel2.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel2.ForeColor = System.Drawing.Color.Black;
            this.myLabel2.Location = new System.Drawing.Point(163, 120);
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.Size = new System.Drawing.Size(53, 12);
            this.myLabel2.TabIndex = 76;
            this.myLabel2.Text = "报告时间";
            // 
            // myLabel14
            // 
            this.myLabel14.AutoSize = true;
            this.myLabel14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLabel14.ForeColor = System.Drawing.Color.Red;
            this.myLabel14.Location = new System.Drawing.Point(163, 12);
            this.myLabel14.Name = "myLabel14";
            this.myLabel14.Size = new System.Drawing.Size(53, 12);
            this.myLabel14.TabIndex = 92;
            this.myLabel14.Text = "病人性别";
            // 
            // myLabel8
            // 
            this.myLabel8.AutoSize = true;
            this.myLabel8.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel8.ForeColor = System.Drawing.Color.Black;
            this.myLabel8.Location = new System.Drawing.Point(512, 12);
            this.myLabel8.Name = "myLabel8";
            this.myLabel8.Size = new System.Drawing.Size(29, 12);
            this.myLabel8.TabIndex = 94;
            this.myLabel8.Text = "床号";
            // 
            // myLabel6
            // 
            this.myLabel6.AutoSize = true;
            this.myLabel6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLabel6.ForeColor = System.Drawing.Color.Red;
            this.myLabel6.Location = new System.Drawing.Point(284, 12);
            this.myLabel6.Name = "myLabel6";
            this.myLabel6.Size = new System.Drawing.Size(29, 12);
            this.myLabel6.TabIndex = 88;
            this.myLabel6.Text = "年龄";
            // 
            // myLabel5
            // 
            this.myLabel5.AutoSize = true;
            this.myLabel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLabel5.ForeColor = System.Drawing.Color.Red;
            this.myLabel5.Location = new System.Drawing.Point(8, 12);
            this.myLabel5.Name = "myLabel5";
            this.myLabel5.Size = new System.Drawing.Size(53, 12);
            this.myLabel5.TabIndex = 86;
            this.myLabel5.Text = "病人姓名";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 9F);
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(163, 39);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 116;
            this.label47.Text = "申请科室";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("宋体", 9F);
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(320, 39);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(53, 12);
            this.label48.TabIndex = 115;
            this.label48.Text = "申请医生";
            // 
            // myLabel11
            // 
            this.myLabel11.AutoSize = true;
            this.myLabel11.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel11.ForeColor = System.Drawing.Color.Red;
            this.myLabel11.Location = new System.Drawing.Point(320, 68);
            this.myLabel11.Name = "myLabel11";
            this.myLabel11.Size = new System.Drawing.Size(53, 12);
            this.myLabel11.TabIndex = 104;
            this.myLabel11.Text = "检查项目";
            // 
            // myLabel7
            // 
            this.myLabel7.AutoSize = true;
            this.myLabel7.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel7.ForeColor = System.Drawing.Color.Black;
            this.myLabel7.Location = new System.Drawing.Point(392, 12);
            this.myLabel7.Name = "myLabel7";
            this.myLabel7.Size = new System.Drawing.Size(53, 12);
            this.myLabel7.TabIndex = 96;
            this.myLabel7.Text = "住 院 号";
            // 
            // myLabel10
            // 
            this.myLabel10.AutoSize = true;
            this.myLabel10.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel10.ForeColor = System.Drawing.Color.Black;
            this.myLabel10.Location = new System.Drawing.Point(163, 66);
            this.myLabel10.Name = "myLabel10";
            this.myLabel10.Size = new System.Drawing.Size(53, 12);
            this.myLabel10.TabIndex = 106;
            this.myLabel10.Text = "检查子类";
            // 
            // myLabel9
            // 
            this.myLabel9.AutoSize = true;
            this.myLabel9.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel9.ForeColor = System.Drawing.Color.Black;
            this.myLabel9.Location = new System.Drawing.Point(8, 39);
            this.myLabel9.Name = "myLabel9";
            this.myLabel9.Size = new System.Drawing.Size(53, 12);
            this.myLabel9.TabIndex = 98;
            this.myLabel9.Text = "病人来源";
            // 
            // myLabel13
            // 
            this.myLabel13.AutoSize = true;
            this.myLabel13.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel13.ForeColor = System.Drawing.Color.Black;
            this.myLabel13.Location = new System.Drawing.Point(8, 66);
            this.myLabel13.Name = "myLabel13";
            this.myLabel13.Size = new System.Drawing.Size(53, 12);
            this.myLabel13.TabIndex = 100;
            this.myLabel13.Text = "检查类别";
            // 
            // tabPage_HIS
            // 
            this.tabPage_HIS.Controls.Add(this.button_zybl);
            this.tabPage_HIS.Controls.Add(this.button_mzbl);
            this.tabPage_HIS.Controls.Add(this.button_LISReport);
            this.tabPage_HIS.Controls.Add(this.button_CheckList);
            this.tabPage_HIS.Location = new System.Drawing.Point(4, 21);
            this.tabPage_HIS.Name = "tabPage_HIS";
            this.tabPage_HIS.Size = new System.Drawing.Size(685, 210);
            this.tabPage_HIS.TabIndex = 2;
            this.tabPage_HIS.Text = "临床信息";
            this.tabPage_HIS.UseVisualStyleBackColor = true;
            // 
            // button_zybl
            // 
            this.button_zybl.Location = new System.Drawing.Point(37, 74);
            this.button_zybl.Name = "button_zybl";
            this.button_zybl.Size = new System.Drawing.Size(109, 23);
            this.button_zybl.TabIndex = 3;
            this.button_zybl.Text = "查看住院病历";
            this.button_zybl.UseVisualStyleBackColor = true;
            this.button_zybl.Click += new System.EventHandler(this.button_zybl_Click);
            // 
            // button_mzbl
            // 
            this.button_mzbl.Location = new System.Drawing.Point(37, 43);
            this.button_mzbl.Name = "button_mzbl";
            this.button_mzbl.Size = new System.Drawing.Size(109, 23);
            this.button_mzbl.TabIndex = 2;
            this.button_mzbl.Text = "查看门诊病历";
            this.button_mzbl.UseVisualStyleBackColor = true;
            this.button_mzbl.Click += new System.EventHandler(this.button_mzbl_Click);
            // 
            // button_LISReport
            // 
            this.button_LISReport.Location = new System.Drawing.Point(37, 12);
            this.button_LISReport.Name = "button_LISReport";
            this.button_LISReport.Size = new System.Drawing.Size(109, 23);
            this.button_LISReport.TabIndex = 1;
            this.button_LISReport.Text = "查看检验报告";
            this.button_LISReport.UseVisualStyleBackColor = true;
            this.button_LISReport.Click += new System.EventHandler(this.button_LISReport_Click);
            // 
            // button_CheckList
            // 
            this.button_CheckList.Location = new System.Drawing.Point(37, 112);
            this.button_CheckList.Name = "button_CheckList";
            this.button_CheckList.Size = new System.Drawing.Size(109, 23);
            this.button_CheckList.TabIndex = 0;
            this.button_CheckList.Text = "查看检查申请单";
            this.button_CheckList.UseVisualStyleBackColor = true;
            this.button_CheckList.Visible = false;
            this.button_CheckList.Click += new System.EventHandler(this.button_CheckList_Click);
            // 
            // tabPage_OtherInf
            // 
            this.tabPage_OtherInf.AutoScroll = true;
            this.tabPage_OtherInf.Controls.Add(this.gb_ClinicInf);
            this.tabPage_OtherInf.Controls.Add(this.gb_TestInf);
            this.tabPage_OtherInf.Controls.Add(this.panel3);
            this.tabPage_OtherInf.Location = new System.Drawing.Point(4, 21);
            this.tabPage_OtherInf.Name = "tabPage_OtherInf";
            this.tabPage_OtherInf.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_OtherInf.Size = new System.Drawing.Size(685, 210);
            this.tabPage_OtherInf.TabIndex = 1;
            this.tabPage_OtherInf.Text = "其它信息";
            this.tabPage_OtherInf.UseVisualStyleBackColor = true;
            // 
            // gb_ClinicInf
            // 
            this.gb_ClinicInf.Controls.Add(this.label38);
            this.gb_ClinicInf.Controls.Add(this.txt_ClinDiag);
            this.gb_ClinicInf.Controls.Add(this.label34);
            this.gb_ClinicInf.Controls.Add(this.txt_ClinSymp);
            this.gb_ClinicInf.Controls.Add(this.label40);
            this.gb_ClinicInf.Controls.Add(this.txt_PhysSign);
            this.gb_ClinicInf.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_ClinicInf.Location = new System.Drawing.Point(3, 134);
            this.gb_ClinicInf.Name = "gb_ClinicInf";
            this.gb_ClinicInf.Size = new System.Drawing.Size(679, 71);
            this.gb_ClinicInf.TabIndex = 141;
            this.gb_ClinicInf.TabStop = false;
            this.gb_ClinicInf.Text = "临床信息";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 9F);
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(455, 17);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(17, 48);
            this.label38.TabIndex = 53;
            this.label38.Text = "临\r\n床\r\n诊\r\n断";
            // 
            // txt_ClinDiag
            // 
            this.txt_ClinDiag.Location = new System.Drawing.Point(480, 17);
            this.txt_ClinDiag.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ClinDiag.Multiline = true;
            this.txt_ClinDiag.Name = "txt_ClinDiag";
            this.txt_ClinDiag.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ClinDiag.Size = new System.Drawing.Size(174, 50);
            this.txt_ClinDiag.TabIndex = 38;
            this.txt_ClinDiag.TextChanged += new System.EventHandler(this.txt_ClinDiag_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 9F);
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(236, 17);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(17, 48);
            this.label34.TabIndex = 54;
            this.label34.Text = "临\r\n床\r\n症\r\n状";
            // 
            // txt_ClinSymp
            // 
            this.txt_ClinSymp.Location = new System.Drawing.Point(256, 18);
            this.txt_ClinSymp.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ClinSymp.Multiline = true;
            this.txt_ClinSymp.Name = "txt_ClinSymp";
            this.txt_ClinSymp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ClinSymp.Size = new System.Drawing.Size(179, 48);
            this.txt_ClinSymp.TabIndex = 37;
            this.txt_ClinSymp.TextChanged += new System.EventHandler(this.txt_ClinSymp_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 9F);
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(11, 17);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(17, 24);
            this.label40.TabIndex = 106;
            this.label40.Text = "体\r\n征";
            // 
            // txt_PhysSign
            // 
            this.txt_PhysSign.Location = new System.Drawing.Point(36, 18);
            this.txt_PhysSign.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PhysSign.Multiline = true;
            this.txt_PhysSign.Name = "txt_PhysSign";
            this.txt_PhysSign.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_PhysSign.Size = new System.Drawing.Size(174, 49);
            this.txt_PhysSign.TabIndex = 107;
            // 
            // gb_TestInf
            // 
            this.gb_TestInf.Controls.Add(this.txt_ReqMemo);
            this.gb_TestInf.Controls.Add(this.label35);
            this.gb_TestInf.Controls.Add(this.txt_RelevantDiag);
            this.gb_TestInf.Controls.Add(this.label33);
            this.gb_TestInf.Controls.Add(this.txt_RelevantLabTest);
            this.gb_TestInf.Controls.Add(this.label32);
            this.gb_TestInf.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_TestInf.Location = new System.Drawing.Point(3, 61);
            this.gb_TestInf.Name = "gb_TestInf";
            this.gb_TestInf.Size = new System.Drawing.Size(679, 73);
            this.gb_TestInf.TabIndex = 142;
            this.gb_TestInf.TabStop = false;
            this.gb_TestInf.Text = "检验信息";
            // 
            // txt_ReqMemo
            // 
            this.txt_ReqMemo.Location = new System.Drawing.Point(480, 21);
            this.txt_ReqMemo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ReqMemo.Multiline = true;
            this.txt_ReqMemo.Name = "txt_ReqMemo";
            this.txt_ReqMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ReqMemo.Size = new System.Drawing.Size(174, 43);
            this.txt_ReqMemo.TabIndex = 38;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 9F);
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(455, 18);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(17, 48);
            this.label35.TabIndex = 53;
            this.label35.Text = "申\r\n请\r\n备\r\n注";
            // 
            // txt_RelevantDiag
            // 
            this.txt_RelevantDiag.Location = new System.Drawing.Point(256, 21);
            this.txt_RelevantDiag.Margin = new System.Windows.Forms.Padding(4);
            this.txt_RelevantDiag.Multiline = true;
            this.txt_RelevantDiag.Name = "txt_RelevantDiag";
            this.txt_RelevantDiag.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_RelevantDiag.Size = new System.Drawing.Size(179, 43);
            this.txt_RelevantDiag.TabIndex = 37;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 9F);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(236, 18);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 48);
            this.label33.TabIndex = 54;
            this.label33.Text = "其\r\n他\r\n诊\r\n断";
            // 
            // txt_RelevantLabTest
            // 
            this.txt_RelevantLabTest.Location = new System.Drawing.Point(36, 21);
            this.txt_RelevantLabTest.Margin = new System.Windows.Forms.Padding(4);
            this.txt_RelevantLabTest.Multiline = true;
            this.txt_RelevantLabTest.Name = "txt_RelevantLabTest";
            this.txt_RelevantLabTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_RelevantLabTest.Size = new System.Drawing.Size(174, 43);
            this.txt_RelevantLabTest.TabIndex = 107;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 9F);
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(11, 18);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(17, 48);
            this.label32.TabIndex = 0;
            this.label32.Text = "相\r\n关\r\n化\r\n验";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.cmb_ExamGroup);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.cmb_ImgEquipment);
            this.panel3.Controls.Add(this.txt_PatientId);
            this.panel3.Controls.Add(this.txt_TelephoneNum);
            this.panel3.Controls.Add(this.txt_OpdNo);
            this.panel3.Controls.Add(this.myLabel15);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Controls.Add(this.myLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(679, 58);
            this.panel3.TabIndex = 140;
            // 
            // cmb_ExamGroup
            // 
            this.cmb_ExamGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExamGroup.FormattingEnabled = true;
            this.cmb_ExamGroup.Location = new System.Drawing.Point(307, 32);
            this.cmb_ExamGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamGroup.Name = "cmb_ExamGroup";
            this.cmb_ExamGroup.Size = new System.Drawing.Size(109, 20);
            this.cmb_ExamGroup.TabIndex = 137;
            this.cmb_ExamGroup.TextChanged += new System.EventHandler(this.cmb_ExamGroup_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(236, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 138;
            this.label4.Text = "检查  组";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 9F);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(455, 34);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 133;
            this.label23.Text = "电话号码";
            // 
            // cmb_ImgEquipment
            // 
            this.cmb_ImgEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ImgEquipment.FormattingEnabled = true;
            this.cmb_ImgEquipment.Location = new System.Drawing.Point(307, 8);
            this.cmb_ImgEquipment.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ImgEquipment.Name = "cmb_ImgEquipment";
            this.cmb_ImgEquipment.Size = new System.Drawing.Size(109, 20);
            this.cmb_ImgEquipment.TabIndex = 113;
            this.cmb_ImgEquipment.TextChanged += new System.EventHandler(this.cmb_ImgEquipment_TextChanged);
            // 
            // txt_PatientId
            // 
            this.txt_PatientId.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientId.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientId.IsChangeColor = true;
            this.txt_PatientId.Location = new System.Drawing.Point(92, 8);
            this.txt_PatientId.Name = "txt_PatientId";
            this.txt_PatientId.Size = new System.Drawing.Size(109, 21);
            this.txt_PatientId.TabIndex = 91;
            this.txt_PatientId.Leave += new System.EventHandler(this.txt_PatientId_Leave);
            this.txt_PatientId.TextChanged += new System.EventHandler(this.txt_PatientID_TextChanged);
            // 
            // txt_TelephoneNum
            // 
            this.txt_TelephoneNum.Location = new System.Drawing.Point(526, 32);
            this.txt_TelephoneNum.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TelephoneNum.Name = "txt_TelephoneNum";
            this.txt_TelephoneNum.Size = new System.Drawing.Size(109, 21);
            this.txt_TelephoneNum.TabIndex = 134;
            this.txt_TelephoneNum.TextChanged += new System.EventHandler(this.txt_TelephoneNum_TextChanged);
            // 
            // txt_OpdNo
            // 
            this.txt_OpdNo.Location = new System.Drawing.Point(526, 8);
            this.txt_OpdNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_OpdNo.Name = "txt_OpdNo";
            this.txt_OpdNo.Size = new System.Drawing.Size(109, 21);
            this.txt_OpdNo.TabIndex = 135;
            // 
            // myLabel15
            // 
            this.myLabel15.AutoSize = true;
            this.myLabel15.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel15.ForeColor = System.Drawing.Color.Black;
            this.myLabel15.Location = new System.Drawing.Point(21, 11);
            this.myLabel15.Name = "myLabel15";
            this.myLabel15.Size = new System.Drawing.Size(41, 12);
            this.myLabel15.TabIndex = 90;
            this.myLabel15.Text = "病人ID";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 9F);
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(236, 11);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 12);
            this.label42.TabIndex = 114;
            this.label42.Text = "检查设备";
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel1.ForeColor = System.Drawing.Color.Black;
            this.myLabel1.Location = new System.Drawing.Point(455, 11);
            this.myLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Size = new System.Drawing.Size(53, 12);
            this.myLabel1.TabIndex = 136;
            this.myLabel1.Text = "门诊  号";
            // 
            // frmExamInf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 235);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.tabControl1);
            this.DockAreas = ((BaseControls.Docking.DockAreas)(((((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)
                        | BaseControls.Docking.DockAreas.DockTop)
                        | BaseControls.Docking.DockAreas.DockBottom)
                        | BaseControls.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExamInf";
            this.Text = "检查信息";
            this.DockStateChanged += new System.EventHandler(this.frmExamInf_DockStateChanged);
            this.Load += new System.EventHandler(this.frmExamInf_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_BaseInf.ResumeLayout(false);
            this.tabPage_BaseInf.PerformLayout();
            this.tabPage_HIS.ResumeLayout(false);
            this.tabPage_OtherInf.ResumeLayout(false);
            this.gb_ClinicInf.ResumeLayout(false);
            this.gb_ClinicInf.PerformLayout();
            this.gb_TestInf.ResumeLayout(false);
            this.gb_TestInf.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_BaseInf;
        public BaseControls.TextBoxExDecimal txt_Costs;
        private BaseControls.MyLabel label26;
        public System.Windows.Forms.ComboBox cmb_ReferDoctor;
        private BaseControls.MyLabel myLabel6;
        public System.Windows.Forms.ComboBox cmb_ReferDept;
        private BaseControls.MyLabel myLabel8;
        private BaseControls.MyLabel label47;
        private BaseControls.MyLabel myLabel14;
        private BaseControls.MyLabel label48;
        private BaseControls.MyLabel myLabel7;
        private BaseControls.MyLabel myLabel9;
        private System.Windows.Forms.CheckBox cb_IsInquiry;
        private BaseControls.MyLabel myLabel13;
        private BaseControls.userTextBox txt_InpNo;
        private BaseControls.MyLabel myLabel2;
        private BaseControls.userTextBox txt_BedNum;
        private BaseControls.userTextBox txt_ReportDateTime;
        private BaseControls.MyLabel myLabel5;
        private BaseControls.MyLabel myLabel4;
        private BaseControls.userTextBox txt_PatientName;
        private BaseControls.MyLabel myLabel10;
        private BaseControls.MyLabel myLabel11;
        private BaseControls.userTextBox txt_PatientAge;
        private System.Windows.Forms.TabPage tabPage_OtherInf;
        public System.Windows.Forms.ListView lv_ExamItem;
        private System.Windows.Forms.ColumnHeader Item_Name;
        private System.Windows.Forms.ColumnHeader Item_Charge;
        private System.Windows.Forms.ColumnHeader Item_Cost;
        private System.Windows.Forms.ColumnHeader Item_Index;
        public System.Windows.Forms.ComboBox cmb_ExamItems;
        private System.Windows.Forms.GroupBox gb_ClinicInf;
        private BaseControls.MyLabel label38;
        public System.Windows.Forms.TextBox txt_ClinDiag;
        private BaseControls.MyLabel label34;
        public System.Windows.Forms.TextBox txt_ClinSymp;
        private BaseControls.MyLabel label40;
        public System.Windows.Forms.TextBox txt_PhysSign;
        private System.Windows.Forms.GroupBox gb_TestInf;
        public System.Windows.Forms.TextBox txt_ReqMemo;
        private BaseControls.MyLabel label35;
        public System.Windows.Forms.TextBox txt_RelevantDiag;
        private BaseControls.MyLabel label33;
        public System.Windows.Forms.TextBox txt_RelevantLabTest;
        private BaseControls.MyLabel label32;
        private System.Windows.Forms.Panel panel3;
        private BaseControls.MyLabel label23;
        public System.Windows.Forms.ComboBox cmb_ImgEquipment;
        private BaseControls.userTextBox txt_PatientId;
        public System.Windows.Forms.TextBox txt_TelephoneNum;
        public System.Windows.Forms.TextBox txt_OpdNo;
        private BaseControls.MyLabel myLabel15;
        private BaseControls.MyLabel label42;
        private BaseControls.MyLabel myLabel1;
        public System.Windows.Forms.ComboBox cmb_Transcriber;
        public System.Windows.Forms.ComboBox cmb_Sex;
        public System.Windows.Forms.ComboBox cmb_PatientSource;
        public System.Windows.Forms.ComboBox cmb_ExamSubClass;
        public System.Windows.Forms.ComboBox cmb_ExamClass;
        public System.Windows.Forms.ComboBox cmb_AgeUnit;
        public System.Windows.Forms.ComboBox cmb_ChargeType;
        private BaseControls.MyLabel label49;
        public System.Windows.Forms.ComboBox cmb_ExamGroup;
        private BaseControls.MyLabel label4;
        public BaseControls.TextBoxExDecimal txt_Charges;
        private BaseControls.MyLabel label27;
        public System.Windows.Forms.RadioButton rb_NoAbnormal;
        public System.Windows.Forms.RadioButton rb_Abnormal;
        private BaseControls.MyLabel label45;
        public BaseControls.MyDomainUpDown dud_PatientLocalId;
        public System.Windows.Forms.Button btn_AddExamItem;
        private System.Windows.Forms.TabPage tabPage_HIS;
        private System.Windows.Forms.Button button_CheckList;
        private System.Windows.Forms.Button button_zybl;
        private System.Windows.Forms.Button button_mzbl;
        private System.Windows.Forms.Button button_LISReport;

    }
}