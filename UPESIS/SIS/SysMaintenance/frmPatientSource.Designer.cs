namespace SIS.SysMaintenance
{
    partial class frmPatientSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientSource));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFunName = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_PatientSour = new BaseControls.MyDataGridView();
            this.PATIENT_SOURCE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SOURCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PatientSour)).BeginInit();
            this.SuspendLayout();
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
            this.btnFunName.Text = "病人来源标识";
            this.btnFunName.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 27);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Add.Location = new System.Drawing.Point(135, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(54, 19);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(196, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(50, 19);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(80, 71);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 52);
            this.gb_PromptInfo.TabIndex = 23;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(5, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(54, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(125, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有病人来源信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_PatientSour
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_PatientSour.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PatientSour.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PatientSour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PatientSour.BackgroundColor = System.Drawing.Color.White;
            this.dgv_PatientSour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PatientSour.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PatientSour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PatientSour.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PATIENT_SOURCE_ID,
            this.PATIENT_SOURCE,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PatientSour.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_PatientSour.DefaultScaleWidth = 1280;
            this.dgv_PatientSour.Location = new System.Drawing.Point(10, 50);
            this.dgv_PatientSour.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_PatientSour.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_PatientSour.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_PatientSour.MergeColumnNames")));
            this.dgv_PatientSour.Name = "dgv_PatientSour";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PatientSour.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_PatientSour.RowTemplate.Height = 23;
            this.dgv_PatientSour.Size = new System.Drawing.Size(320, 500);
            this.dgv_PatientSour.TabIndex = 22;
            this.dgv_PatientSour.XmlFile = null;
            this.dgv_PatientSour.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_PatientSour_DefaultValuesNeeded);
            this.dgv_PatientSour.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PatientSour_CellContentClick);
            // 
            // PATIENT_SOURCE_ID
            // 
            this.PATIENT_SOURCE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_SOURCE_ID.DataPropertyName = "PATIENT_SOURCE_ID";
            this.PATIENT_SOURCE_ID.FillWeight = 15F;
            this.PATIENT_SOURCE_ID.HeaderText = "来源标识";
            this.PATIENT_SOURCE_ID.Name = "PATIENT_SOURCE_ID";
            this.PATIENT_SOURCE_ID.ReadOnly = true;
            this.PATIENT_SOURCE_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PATIENT_SOURCE
            // 
            this.PATIENT_SOURCE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_SOURCE.DataPropertyName = "PATIENT_SOURCE";
            this.PATIENT_SOURCE.FillWeight = 15F;
            this.PATIENT_SOURCE.HeaderText = "来源名称";
            this.PATIENT_SOURCE.Name = "PATIENT_SOURCE";
            this.PATIENT_SOURCE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operate.FillWeight = 69.80753F;
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
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
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 54;
            // 
            // PatientSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 566);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.dgv_PatientSour);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PatientSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人来源标识";
            this.Load += new System.EventHandler(this.PatientSource_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatientSource_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PatientSour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.MyDataGridView dgv_PatientSour;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
        public System.Windows.Forms.Button btnFunName;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SOURCE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SOURCE;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;

    }
}