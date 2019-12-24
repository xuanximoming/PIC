namespace SIS.SysMaintenance
{
    partial class frmDoctorInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoctorInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btnFunName = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_Doctor = new BaseControls.MyDataGridView();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.txt_Doctor_Name = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.CLINIC_DOCTOR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_DOCTOR_PYCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Doctor)).BeginInit();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 868F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 27);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Add.Location = new System.Drawing.Point(135, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(63, 19);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(205, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(54, 19);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btnFunName
            // 
            this.btnFunName.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.btnFunName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFunName.Enabled = false;
            this.btnFunName.FlatAppearance.BorderSize = 0;
            this.btnFunName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFunName.Location = new System.Drawing.Point(1, 1);
            this.btnFunName.Margin = new System.Windows.Forms.Padding(0);
            this.btnFunName.Name = "btnFunName";
            this.btnFunName.Size = new System.Drawing.Size(130, 25);
            this.btnFunName.TabIndex = 3;
            this.btnFunName.Text = "button1";
            this.btnFunName.UseVisualStyleBackColor = true;
            // 
            // gb_PromptInfo
            // 
            this.gb_PromptInfo.BackgroundColor = System.Drawing.Color.Bisque;
            this.gb_PromptInfo.BackgroundGradientColor = System.Drawing.Color.White;
            this.gb_PromptInfo.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.gb_PromptInfo.BorderColor = System.Drawing.Color.SandyBrown;
            this.gb_PromptInfo.BorderThickness = 1F;
            this.gb_PromptInfo.Controls.Add(this.pictureBox1);
            this.gb_PromptInfo.Controls.Add(this.lb_PromptInfo);
            this.gb_PromptInfo.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gb_PromptInfo.GroupImage = null;
            this.gb_PromptInfo.GroupTitle = "";
            this.gb_PromptInfo.Location = new System.Drawing.Point(364, 111);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 19;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(45, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(101, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有医生信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_Doctor
            // 
            this.dgv_Doctor.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Doctor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Doctor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Doctor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Doctor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Doctor.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Doctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Doctor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Doctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Doctor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLINIC_DOCTOR_ID,
            this.CLINIC_DOCTOR,
            this.CLINIC_DOCTOR_PYCODE,
            this.CLINIC_OFFICE_ID,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Doctor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Doctor.DefaultScaleWidth = 1280;
            this.dgv_Doctor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Doctor.Location = new System.Drawing.Point(9, 91);
            this.dgv_Doctor.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Doctor.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Doctor.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Doctor.MergeColumnNames")));
            this.dgv_Doctor.Name = "dgv_Doctor";
            this.dgv_Doctor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Doctor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Doctor.RowTemplate.Height = 23;
            this.dgv_Doctor.Size = new System.Drawing.Size(864, 444);
            this.dgv_Doctor.TabIndex = 14;
            this.dgv_Doctor.XmlFile = null;
            this.dgv_Doctor.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Doctor_CellValueChanged);
            this.dgv_Doctor.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Doctor_DataError);
            this.dgv_Doctor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Doctor_CellContentClick);
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.txt_Doctor_Name);
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Location = new System.Drawing.Point(9, 34);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(864, 35);
            this.myPanel1.TabIndex = 20;
            // 
            // txt_Doctor_Name
            // 
            this.txt_Doctor_Name.Location = new System.Drawing.Point(43, 6);
            this.txt_Doctor_Name.Name = "txt_Doctor_Name";
            this.txt_Doctor_Name.Size = new System.Drawing.Size(146, 21);
            this.txt_Doctor_Name.TabIndex = 1;
            this.txt_Doctor_Name.TextChanged += new System.EventHandler(this.txt_Doctor_Name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // CLINIC_DOCTOR_ID
            // 
            this.CLINIC_DOCTOR_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_DOCTOR_ID.DataPropertyName = "CLINIC_DOCTOR_ID";
            this.CLINIC_DOCTOR_ID.FillWeight = 20F;
            this.CLINIC_DOCTOR_ID.HeaderText = "医生标识";
            this.CLINIC_DOCTOR_ID.MaxInputLength = 4;
            this.CLINIC_DOCTOR_ID.Name = "CLINIC_DOCTOR_ID";
            this.CLINIC_DOCTOR_ID.ReadOnly = true;
            // 
            // CLINIC_DOCTOR
            // 
            this.CLINIC_DOCTOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_DOCTOR.DataPropertyName = "CLINIC_DOCTOR";
            this.CLINIC_DOCTOR.FillWeight = 30F;
            this.CLINIC_DOCTOR.HeaderText = "医生姓名";
            this.CLINIC_DOCTOR.MaxInputLength = 16;
            this.CLINIC_DOCTOR.Name = "CLINIC_DOCTOR";
            this.CLINIC_DOCTOR.ReadOnly = true;
            // 
            // CLINIC_DOCTOR_PYCODE
            // 
            this.CLINIC_DOCTOR_PYCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_DOCTOR_PYCODE.DataPropertyName = "CLINIC_DOCTOR_PYCODE";
            this.CLINIC_DOCTOR_PYCODE.FillWeight = 20F;
            this.CLINIC_DOCTOR_PYCODE.HeaderText = "拼音码";
            this.CLINIC_DOCTOR_PYCODE.MaxInputLength = 16;
            this.CLINIC_DOCTOR_PYCODE.Name = "CLINIC_DOCTOR_PYCODE";
            this.CLINIC_DOCTOR_PYCODE.ReadOnly = true;
            // 
            // CLINIC_OFFICE_ID
            // 
            this.CLINIC_OFFICE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE_ID.DataPropertyName = "CLINIC_OFFICE_ID";
            this.CLINIC_OFFICE_ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CLINIC_OFFICE_ID.FillWeight = 30F;
            this.CLINIC_OFFICE_ID.HeaderText = "科室";
            this.CLINIC_OFFICE_ID.Name = "CLINIC_OFFICE_ID";
            this.CLINIC_OFFICE_ID.ReadOnly = true;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operate.FillWeight = 10F;
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.ReadOnly = true;
            this.Operate.Text = "删除";
            this.Operate.ToolTipText = "删除";
            this.Operate.UseColumnTextForButtonValue = true;
            this.Operate.Width = 50;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.FillWeight = 10F;
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 50;
            // 
            // frmDoctorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 560);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.dgv_Doctor);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmDoctorInfo";
            this.Text = "DoctorInfo";
            this.Load += new System.EventHandler(this.DoctorInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Doctor)).EndInit();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.MyDataGridView dgv_Doctor;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btnFunName;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.MyLabel lb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyLabel label1;
        private BaseControls.MyTextBox txt_Doctor_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_DOCTOR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_DOCTOR_PYCODE;
        private System.Windows.Forms.DataGridViewComboBoxColumn CLINIC_OFFICE_ID;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}