namespace SIS.SysMaintenance
{
    partial class frmExamClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamClass));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btnFunName = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_ExamClass = new BaseControls.MyDataGridView();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.txt_EXAM_SUB_CLASS = new BaseControls.MyTextBox();
            this.txt_EXAM_CLASS = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DICOM_MODALITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOCAL_ID_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAG_IMAGE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEVICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExamClass)).BeginInit();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 873F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
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
            this.btn_Add.Size = new System.Drawing.Size(63, 19);
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(273, 131);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 22;
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
            this.lb_PromptInfo.Size = new System.Drawing.Size(125, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有检查类别信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_ExamClass
            // 
            this.dgv_ExamClass.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ExamClass.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ExamClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ExamClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ExamClass.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ExamClass.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ExamClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExamClass.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ExamClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExamClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.DICOM_MODALITY,
            this.LOCAL_ID_CLASS,
            this.TAG_IMAGE_NAME,
            this.DEVICE,
            this.SORT_ID,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ExamClass.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ExamClass.DefaultScaleWidth = 1280;
            this.dgv_ExamClass.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ExamClass.Location = new System.Drawing.Point(10, 87);
            this.dgv_ExamClass.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_ExamClass.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ExamClass.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ExamClass.MergeColumnNames")));
            this.dgv_ExamClass.Name = "dgv_ExamClass";
            this.dgv_ExamClass.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExamClass.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ExamClass.RowTemplate.Height = 23;
            this.dgv_ExamClass.Size = new System.Drawing.Size(790, 470);
            this.dgv_ExamClass.TabIndex = 20;
            this.dgv_ExamClass.XmlFile = null;
            this.dgv_ExamClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ExamClass_CellContentClick);
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.txt_EXAM_SUB_CLASS);
            this.myPanel1.Controls.Add(this.txt_EXAM_CLASS);
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Location = new System.Drawing.Point(10, 33);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(790, 35);
            this.myPanel1.TabIndex = 33;
            // 
            // txt_EXAM_SUB_CLASS
            // 
            this.txt_EXAM_SUB_CLASS.Location = new System.Drawing.Point(280, 8);
            this.txt_EXAM_SUB_CLASS.Name = "txt_EXAM_SUB_CLASS";
            this.txt_EXAM_SUB_CLASS.Size = new System.Drawing.Size(114, 21);
            this.txt_EXAM_SUB_CLASS.TabIndex = 1;
            this.txt_EXAM_SUB_CLASS.TextChanged += new System.EventHandler(this.txt_EXAM_SUB_CLASS_TextChanged);
            // 
            // txt_EXAM_CLASS
            // 
            this.txt_EXAM_CLASS.Location = new System.Drawing.Point(74, 8);
            this.txt_EXAM_CLASS.Name = "txt_EXAM_CLASS";
            this.txt_EXAM_CLASS.Size = new System.Drawing.Size(114, 21);
            this.txt_EXAM_CLASS.TabIndex = 1;
            this.txt_EXAM_CLASS.TextChanged += new System.EventHandler(this.txt_EXAM_CLASS_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(209, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检查子类：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "检查类别：";
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.FillWeight = 20F;
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.MaxInputLength = 6;
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            this.EXAM_CLASS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.FillWeight = 20F;
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.MaxInputLength = 8;
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.ReadOnly = true;
            this.EXAM_SUB_CLASS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DICOM_MODALITY
            // 
            this.DICOM_MODALITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DICOM_MODALITY.DataPropertyName = "DICOM_MODALITY";
            this.DICOM_MODALITY.FillWeight = 15F;
            this.DICOM_MODALITY.HeaderText = "DICOM标准名称";
            this.DICOM_MODALITY.MaxInputLength = 8;
            this.DICOM_MODALITY.Name = "DICOM_MODALITY";
            this.DICOM_MODALITY.ReadOnly = true;
            this.DICOM_MODALITY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DICOM_MODALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LOCAL_ID_CLASS
            // 
            this.LOCAL_ID_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LOCAL_ID_CLASS.DataPropertyName = "LOCAL_ID_CLASS";
            this.LOCAL_ID_CLASS.FillWeight = 15F;
            this.LOCAL_ID_CLASS.HeaderText = "检查号类型";
            this.LOCAL_ID_CLASS.MaxInputLength = 2;
            this.LOCAL_ID_CLASS.Name = "LOCAL_ID_CLASS";
            this.LOCAL_ID_CLASS.ReadOnly = true;
            this.LOCAL_ID_CLASS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TAG_IMAGE_NAME
            // 
            this.TAG_IMAGE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TAG_IMAGE_NAME.DataPropertyName = "TAG_IMAGE_NAME";
            this.TAG_IMAGE_NAME.FillWeight = 15F;
            this.TAG_IMAGE_NAME.HeaderText = "图像标记名称";
            this.TAG_IMAGE_NAME.MaxInputLength = 32;
            this.TAG_IMAGE_NAME.Name = "TAG_IMAGE_NAME";
            this.TAG_IMAGE_NAME.ReadOnly = true;
            this.TAG_IMAGE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DEVICE
            // 
            this.DEVICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DEVICE.DataPropertyName = "DEVICE";
            this.DEVICE.FillWeight = 30F;
            this.DEVICE.HeaderText = "影像设备名称";
            this.DEVICE.Name = "DEVICE";
            this.DEVICE.ReadOnly = true;
            this.DEVICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SORT_ID
            // 
            this.SORT_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SORT_ID.DataPropertyName = "SORT_ID";
            this.SORT_ID.FillWeight = 12F;
            this.SORT_ID.HeaderText = "排序号";
            this.SORT_ID.Name = "SORT_ID";
            this.SORT_ID.ReadOnly = true;
            this.SORT_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Operate.FillWeight = 10F;
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.ReadOnly = true;
            this.Operate.Text = "删除";
            this.Operate.ToolTipText = "删除";
            this.Operate.UseColumnTextForButtonValue = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit.FillWeight = 10F;
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // frmExamClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 566);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_ExamClass);
            this.Name = "frmExamClass";
            this.Text = "ExamClass";
            this.Load += new System.EventHandler(this.ExamClass_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExamClass)).EndInit();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.MyDataGridView dgv_ExamClass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.MyLabel lb_PromptInfo;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btnFunName;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyLabel label3;
        private BaseControls.MyTextBox txt_EXAM_SUB_CLASS;
        private BaseControls.MyTextBox txt_EXAM_CLASS;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DICOM_MODALITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOCAL_ID_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAG_IMAGE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEVICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT_ID;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}