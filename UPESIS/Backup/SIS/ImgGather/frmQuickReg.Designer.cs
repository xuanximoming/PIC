namespace SIS.ImgGather
{
    partial class frmQuickReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuickReg));
            this.dud_PatientLocalId = new BaseControls.MyDomainUpDown();
            this.label30 = new BaseControls.MyLabel();
            this.btn_NewPatientId = new System.Windows.Forms.Button();
            this.label45 = new BaseControls.MyLabel();
            this.txt_PatientName = new BaseControls.MyTextBox();
            this.label37 = new BaseControls.MyLabel();
            this.txt_PatientId = new BaseControls.MyTextBox();
            this.cmb_ExamItems = new System.Windows.Forms.ComboBox();
            this.label44 = new BaseControls.MyLabel();
            this.label46 = new BaseControls.MyLabel();
            this.txt_Age = new BaseControls.NumberText();
            this.cmb_AgeUnit = new System.Windows.Forms.ComboBox();
            this.label43 = new BaseControls.MyLabel();
            this.dtp_Birth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new BaseControls.MyLabel();
            this.label24 = new BaseControls.MyLabel();
            this.cmb_Sex = new System.Windows.Forms.ComboBox();
            this.cmb_ExamClass = new System.Windows.Forms.ComboBox();
            this.cmb_ExamSubClass = new System.Windows.Forms.ComboBox();
            this.btn_Save = new BaseControls.Buttons.VistaButton();
            this.label2 = new BaseControls.MyLabel();
            this.btn_Add = new BaseControls.Buttons.VistaButton();
            this.btn_Cancel = new BaseControls.Buttons.VistaButton();
            this.lv_ExamItem = new System.Windows.Forms.ListView();
            this.Item_Name = new System.Windows.Forms.ColumnHeader();
            this.Item_Index = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // dud_PatientLocalId
            // 
            this.dud_PatientLocalId.Location = new System.Drawing.Point(116, 290);
            this.dud_PatientLocalId.Name = "dud_PatientLocalId";
            this.dud_PatientLocalId.Size = new System.Drawing.Size(129, 21);
            this.dud_PatientLocalId.TabIndex = 145;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Blue;
            this.label30.Location = new System.Drawing.Point(30, 37);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(59, 12);
            this.label30.TabIndex = 138;
            this.label30.Text = "病人姓名:";
            // 
            // btn_NewPatientId
            // 
            this.btn_NewPatientId.FlatAppearance.BorderSize = 0;
            this.btn_NewPatientId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewPatientId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_NewPatientId.Image = ((System.Drawing.Image)(resources.GetObject("btn_NewPatientId.Image")));
            this.btn_NewPatientId.Location = new System.Drawing.Point(227, 67);
            this.btn_NewPatientId.Name = "btn_NewPatientId";
            this.btn_NewPatientId.Size = new System.Drawing.Size(18, 21);
            this.btn_NewPatientId.TabIndex = 144;
            this.btn_NewPatientId.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.Blue;
            this.label45.Location = new System.Drawing.Point(30, 299);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(47, 12);
            this.label45.TabIndex = 137;
            this.label45.Text = "检查号:";
            // 
            // txt_PatientName
            // 
            this.txt_PatientName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_PatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PatientName.Location = new System.Drawing.Point(116, 32);
            this.txt_PatientName.Name = "txt_PatientName";
            this.txt_PatientName.Size = new System.Drawing.Size(129, 21);
            this.txt_PatientName.TabIndex = 143;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.Blue;
            this.label37.Location = new System.Drawing.Point(30, 259);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(59, 12);
            this.label37.TabIndex = 136;
            this.label37.Text = "检查子类:";
            // 
            // txt_PatientId
            // 
            this.txt_PatientId.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_PatientId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PatientId.Location = new System.Drawing.Point(116, 69);
            this.txt_PatientId.Name = "txt_PatientId";
            this.txt_PatientId.Size = new System.Drawing.Size(109, 21);
            this.txt_PatientId.TabIndex = 142;
            // 
            // cmb_ExamItems
            // 
            this.cmb_ExamItems.FormattingEnabled = true;
            this.cmb_ExamItems.Location = new System.Drawing.Point(116, 335);
            this.cmb_ExamItems.Name = "cmb_ExamItems";
            this.cmb_ExamItems.Size = new System.Drawing.Size(129, 20);
            this.cmb_ExamItems.TabIndex = 141;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.Color.Blue;
            this.label44.Location = new System.Drawing.Point(30, 148);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(59, 12);
            this.label44.TabIndex = 139;
            this.label44.Text = "病人年龄:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.Color.Blue;
            this.label46.Location = new System.Drawing.Point(30, 338);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 12);
            this.label46.TabIndex = 132;
            this.label46.Text = "检查项目:";
            // 
            // txt_Age
            // 
            this.txt_Age.Location = new System.Drawing.Point(116, 142);
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.NumberCount = 3;
            this.txt_Age.Size = new System.Drawing.Size(55, 21);
            this.txt_Age.TabIndex = 140;
            // 
            // cmb_AgeUnit
            // 
            this.cmb_AgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AgeUnit.FormattingEnabled = true;
            this.cmb_AgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天"});
            this.cmb_AgeUnit.Location = new System.Drawing.Point(178, 142);
            this.cmb_AgeUnit.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_AgeUnit.Name = "cmb_AgeUnit";
            this.cmb_AgeUnit.Size = new System.Drawing.Size(67, 20);
            this.cmb_AgeUnit.TabIndex = 129;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.Blue;
            this.label43.Location = new System.Drawing.Point(30, 111);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(59, 12);
            this.label43.TabIndex = 133;
            this.label43.Text = "病人性别:";
            // 
            // dtp_Birth
            // 
            this.dtp_Birth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Birth.Location = new System.Drawing.Point(116, 179);
            this.dtp_Birth.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_Birth.Name = "dtp_Birth";
            this.dtp_Birth.Size = new System.Drawing.Size(129, 21);
            this.dtp_Birth.TabIndex = 128;
            this.dtp_Birth.Value = new System.DateTime(2009, 1, 11, 17, 14, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(30, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 135;
            this.label1.Text = "病人ID:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(30, 222);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 12);
            this.label24.TabIndex = 134;
            this.label24.Text = "检查类别:";
            // 
            // cmb_Sex
            // 
            this.cmb_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Sex.FormattingEnabled = true;
            this.cmb_Sex.Items.AddRange(new object[] {
            "男",
            "女",
            "？"});
            this.cmb_Sex.Location = new System.Drawing.Point(116, 106);
            this.cmb_Sex.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Sex.Name = "cmb_Sex";
            this.cmb_Sex.Size = new System.Drawing.Size(129, 20);
            this.cmb_Sex.TabIndex = 127;
            // 
            // cmb_ExamClass
            // 
            this.cmb_ExamClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExamClass.FormattingEnabled = true;
            this.cmb_ExamClass.Location = new System.Drawing.Point(116, 216);
            this.cmb_ExamClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamClass.Name = "cmb_ExamClass";
            this.cmb_ExamClass.Size = new System.Drawing.Size(129, 20);
            this.cmb_ExamClass.TabIndex = 130;
            // 
            // cmb_ExamSubClass
            // 
            this.cmb_ExamSubClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExamSubClass.FormattingEnabled = true;
            this.cmb_ExamSubClass.Location = new System.Drawing.Point(116, 252);
            this.cmb_ExamSubClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExamSubClass.Name = "cmb_ExamSubClass";
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(129, 20);
            this.cmb_ExamSubClass.TabIndex = 131;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Save.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Save.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Save.ButtonText = "保存";
            this.btn_Save.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Save.Location = new System.Drawing.Point(108, 516);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(67, 32);
            this.btn_Save.TabIndex = 146;
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(30, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 147;
            this.label2.Text = "出生日期:";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Add.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Add.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Add.ButtonText = "新增";
            this.btn_Add.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Add.Location = new System.Drawing.Point(32, 516);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(67, 32);
            this.btn_Add.TabIndex = 148;
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancel.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Cancel.ButtonText = "取消";
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Cancel.Location = new System.Drawing.Point(184, 516);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(67, 32);
            this.btn_Cancel.TabIndex = 149;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lv_ExamItem
            // 
            this.lv_ExamItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item_Name,
            this.Item_Index});
            this.lv_ExamItem.FullRowSelect = true;
            this.lv_ExamItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ExamItem.Location = new System.Drawing.Point(32, 381);
            this.lv_ExamItem.MultiSelect = false;
            this.lv_ExamItem.Name = "lv_ExamItem";
            this.lv_ExamItem.Size = new System.Drawing.Size(213, 96);
            this.lv_ExamItem.TabIndex = 150;
            this.lv_ExamItem.UseCompatibleStateImageBehavior = false;
            this.lv_ExamItem.View = System.Windows.Forms.View.Details;
            // 
            // Item_Name
            // 
            this.Item_Name.Text = "项目名称";
            this.Item_Name.Width = 140;
            // 
            // Item_Index
            // 
            this.Item_Index.Text = "";
            this.Item_Index.Width = 0;
            // 
            // frmQuickReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 589);
            this.Controls.Add(this.lv_ExamItem);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dud_PatientLocalId);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.btn_NewPatientId);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.txt_PatientName);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txt_PatientId);
            this.Controls.Add(this.cmb_ExamItems);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.txt_Age);
            this.Controls.Add(this.cmb_AgeUnit);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.dtp_Birth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmb_Sex);
            this.Controls.Add(this.cmb_ExamClass);
            this.Controls.Add(this.cmb_ExamSubClass);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmQuickReg";
            this.Text = "快速登记";
            this.DockStateChanged += new System.EventHandler(this.frmQuickReg_DockStateChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public BaseControls.MyDomainUpDown dud_PatientLocalId;
        private BaseControls.MyLabel label30;
        public System.Windows.Forms.Button btn_NewPatientId;
        private BaseControls.MyLabel label45;
        public BaseControls.MyTextBox txt_PatientName;
        private BaseControls.MyLabel label37;
        public BaseControls.MyTextBox txt_PatientId;
        public System.Windows.Forms.ComboBox cmb_ExamItems;
        private BaseControls.MyLabel label44;
        private BaseControls.MyLabel label46;
        public BaseControls.NumberText txt_Age;
        public System.Windows.Forms.ComboBox cmb_AgeUnit;
        private BaseControls.MyLabel label43;
        public System.Windows.Forms.DateTimePicker dtp_Birth;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label24;
        public System.Windows.Forms.ComboBox cmb_Sex;
        public System.Windows.Forms.ComboBox cmb_ExamClass;
        public System.Windows.Forms.ComboBox cmb_ExamSubClass;
        private BaseControls.Buttons.VistaButton btn_Save;
        private BaseControls.MyLabel label2;
        private BaseControls.Buttons.VistaButton btn_Add;
        private BaseControls.Buttons.VistaButton btn_Cancel;
        public System.Windows.Forms.ListView lv_ExamItem;
        private System.Windows.Forms.ColumnHeader Item_Name;
        private System.Windows.Forms.ColumnHeader Item_Index;
    }
}