namespace SIS.DeptManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamClass));
            this.cmb_ExamSubClass = new System.Windows.Forms.ComboBox();
            this.cmb_ExamClass = new System.Windows.Forms.ComboBox();
            this.cmb_LocalIdClass = new System.Windows.Forms.ComboBox();
            this.txt_Device = new System.Windows.Forms.TextBox();
            this.txt_PrintPatternClass = new System.Windows.Forms.TextBox();
            this.txt_Dicom = new System.Windows.Forms.TextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label43 = new BaseControls.MyLabel();
            this.label46 = new BaseControls.MyLabel();
            this.label44 = new BaseControls.MyLabel();
            this.label47 = new BaseControls.MyLabel();
            this.label45 = new BaseControls.MyLabel();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.dgv_ExamClass = new BaseControls.MyDataGridView();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEVICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DICOM_MODALITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOCAL_ID_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_PATTERN_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pl_Top = new BaseControls.Panels.MyPanel();
            this.label12 = new BaseControls.MyLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExamClass)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pl_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_ExamSubClass
            // 
            this.cmb_ExamSubClass.FormattingEnabled = true;
            this.cmb_ExamSubClass.Location = new System.Drawing.Point(297, 8);
            this.cmb_ExamSubClass.Name = "cmb_ExamSubClass";
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(160, 20);
            this.cmb_ExamSubClass.TabIndex = 75;
            // 
            // cmb_ExamClass
            // 
            this.cmb_ExamClass.FormattingEnabled = true;
            this.cmb_ExamClass.Location = new System.Drawing.Point(62, 8);
            this.cmb_ExamClass.Name = "cmb_ExamClass";
            this.cmb_ExamClass.Size = new System.Drawing.Size(160, 20);
            this.cmb_ExamClass.TabIndex = 76;
            this.cmb_ExamClass.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamClass_SelectedIndexChanged);
            // 
            // cmb_LocalIdClass
            // 
            this.cmb_LocalIdClass.FormattingEnabled = true;
            this.cmb_LocalIdClass.Location = new System.Drawing.Point(573, 8);
            this.cmb_LocalIdClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_LocalIdClass.Name = "cmb_LocalIdClass";
            this.cmb_LocalIdClass.Size = new System.Drawing.Size(160, 20);
            this.cmb_LocalIdClass.TabIndex = 69;
            // 
            // txt_Device
            // 
            this.txt_Device.Location = new System.Drawing.Point(62, 35);
            this.txt_Device.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Device.Name = "txt_Device";
            this.txt_Device.Size = new System.Drawing.Size(160, 21);
            this.txt_Device.TabIndex = 65;
            // 
            // txt_PrintPatternClass
            // 
            this.txt_PrintPatternClass.Location = new System.Drawing.Point(573, 35);
            this.txt_PrintPatternClass.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PrintPatternClass.Name = "txt_PrintPatternClass";
            this.txt_PrintPatternClass.Size = new System.Drawing.Size(160, 21);
            this.txt_PrintPatternClass.TabIndex = 71;
            // 
            // txt_Dicom
            // 
            this.txt_Dicom.Location = new System.Drawing.Point(297, 35);
            this.txt_Dicom.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Dicom.Name = "txt_Dicom";
            this.txt_Dicom.Size = new System.Drawing.Size(160, 21);
            this.txt_Dicom.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "检查设备：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 9F);
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(4, 10);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(65, 12);
            this.label43.TabIndex = 67;
            this.label43.Text = "检查类别：";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 9F);
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(464, 10);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(101, 12);
            this.label46.TabIndex = 73;
            this.label46.Text = "科室检查号类型：";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 9F);
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(229, 10);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 12);
            this.label44.TabIndex = 70;
            this.label44.Text = "检查子类：";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 9F);
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(465, 40);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(77, 12);
            this.label47.TabIndex = 74;
            this.label47.Text = "打印模板组：";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 9F);
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(230, 40);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(71, 12);
            this.label45.TabIndex = 72;
            this.label45.Text = "DECON标准：";
            // 
            // btn_Clean
            // 
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Clean.Location = new System.Drawing.Point(357, 4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(94, 19);
            this.btn_Clean.TabIndex = 4;
            this.btn_Clean.Text = "清空";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(256, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Find
            // 
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Find.Location = new System.Drawing.Point(155, 4);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(94, 19);
            this.btn_Find.TabIndex = 0;
            this.btn_Find.Text = "查找";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.FlatAppearance.BorderSize = 0;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Del.Location = new System.Drawing.Point(458, 4);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(94, 19);
            this.btn_Del.TabIndex = 4;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // dgv_ExamClass
            // 
            this.dgv_ExamClass.AllowUserToAddRows = false;
            this.dgv_ExamClass.AllowUserToDeleteRows = false;
            this.dgv_ExamClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ExamClass.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ExamClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ExamClass.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_ExamClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExamClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.DEVICE,
            this.DICOM_MODALITY,
            this.LOCAL_ID_CLASS,
            this.PRINT_PATTERN_CLASS});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ExamClass.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ExamClass.DefaultScaleWidth = 1280;
            this.dgv_ExamClass.Location = new System.Drawing.Point(12, 120);
            this.dgv_ExamClass.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ExamClass.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ExamClass.MergeColumnNames")));
            this.dgv_ExamClass.Name = "dgv_ExamClass";
            this.dgv_ExamClass.ReadOnly = true;
            this.dgv_ExamClass.RowHeadersWidth = 25;
            this.dgv_ExamClass.RowTemplate.Height = 23;
            this.dgv_ExamClass.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ExamClass.Size = new System.Drawing.Size(858, 434);
            this.dgv_ExamClass.TabIndex = 79;
            this.dgv_ExamClass.XmlFile = null;
            this.dgv_ExamClass.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ExamClass_CellClick);
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.FillWeight = 10F;
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.FillWeight = 10F;
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.ReadOnly = true;
            // 
            // DEVICE
            // 
            this.DEVICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DEVICE.DataPropertyName = "DEVICE";
            this.DEVICE.FillWeight = 10F;
            this.DEVICE.HeaderText = "检查设备";
            this.DEVICE.Name = "DEVICE";
            this.DEVICE.ReadOnly = true;
            // 
            // DICOM_MODALITY
            // 
            this.DICOM_MODALITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DICOM_MODALITY.DataPropertyName = "DICOM_MODALITY";
            this.DICOM_MODALITY.FillWeight = 10F;
            this.DICOM_MODALITY.HeaderText = "DICOM标准";
            this.DICOM_MODALITY.Name = "DICOM_MODALITY";
            this.DICOM_MODALITY.ReadOnly = true;
            // 
            // LOCAL_ID_CLASS
            // 
            this.LOCAL_ID_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LOCAL_ID_CLASS.DataPropertyName = "LOCAL_ID_CLASS";
            this.LOCAL_ID_CLASS.FillWeight = 20F;
            this.LOCAL_ID_CLASS.HeaderText = "科室本地检查号类型";
            this.LOCAL_ID_CLASS.Name = "LOCAL_ID_CLASS";
            this.LOCAL_ID_CLASS.ReadOnly = true;
            // 
            // PRINT_PATTERN_CLASS
            // 
            this.PRINT_PATTERN_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRINT_PATTERN_CLASS.DataPropertyName = "PRINT_PATTERN_CLASS";
            this.PRINT_PATTERN_CLASS.FillWeight = 10F;
            this.PRINT_PATTERN_CLASS.HeaderText = "打印模板组";
            this.PRINT_PATTERN_CLASS.Name = "PRINT_PATTERN_CLASS";
            this.PRINT_PATTERN_CLASS.ReadOnly = true;
            // 
            // btn_FunName
            // 
            this.btn_FunName.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.btn_FunName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_FunName.Enabled = false;
            this.btn_FunName.FlatAppearance.BorderSize = 0;
            this.btn_FunName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FunName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FunName.Location = new System.Drawing.Point(1, 1);
            this.btn_FunName.Margin = new System.Windows.Forms.Padding(0);
            this.btn_FunName.Name = "btn_FunName";
            this.btn_FunName.Size = new System.Drawing.Size(150, 25);
            this.btn_FunName.TabIndex = 6;
            this.btn_FunName.Text = "button1";
            this.btn_FunName.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Find, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Del, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 27);
            this.tableLayoutPanel1.TabIndex = 77;
            // 
            // pl_Top
            // 
            this.pl_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_Top.BorderColor = System.Drawing.Color.Silver;
            this.pl_Top.Controls.Add(this.txt_PrintPatternClass);
            this.pl_Top.Controls.Add(this.cmb_LocalIdClass);
            this.pl_Top.Controls.Add(this.label47);
            this.pl_Top.Controls.Add(this.txt_Dicom);
            this.pl_Top.Controls.Add(this.cmb_ExamSubClass);
            this.pl_Top.Controls.Add(this.label45);
            this.pl_Top.Controls.Add(this.cmb_ExamClass);
            this.pl_Top.Controls.Add(this.label46);
            this.pl_Top.Controls.Add(this.txt_Device);
            this.pl_Top.Controls.Add(this.label44);
            this.pl_Top.Controls.Add(this.label1);
            this.pl_Top.Controls.Add(this.label43);
            this.pl_Top.Controls.Add(this.label12);
            this.pl_Top.Location = new System.Drawing.Point(12, 39);
            this.pl_Top.Name = "pl_Top";
            this.pl_Top.Size = new System.Drawing.Size(858, 65);
            this.pl_Top.TabIndex = 78;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(860, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 90;
            this.label12.Text = "用户头像";
            this.label12.Visible = false;
            // 
            // frmExamClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 566);
            this.Controls.Add(this.dgv_ExamClass);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pl_Top);
            this.Name = "frmExamClass";
            this.Text = "检查类别";
            this.VisibleChanged += new System.EventHandler(this.ExamClass_VisibleChanged);
            this.Load += new System.EventHandler(this.ExamClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExamClass)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pl_Top.ResumeLayout(false);
            this.pl_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ExamSubClass;
        private System.Windows.Forms.ComboBox cmb_ExamClass;
        private System.Windows.Forms.ComboBox cmb_LocalIdClass;
        private System.Windows.Forms.TextBox txt_Device;
        private System.Windows.Forms.TextBox txt_PrintPatternClass;
        private System.Windows.Forms.TextBox txt_Dicom;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label43;
        private BaseControls.MyLabel label46;
        private BaseControls.MyLabel label44;
        private BaseControls.MyLabel label47;
        private BaseControls.MyLabel label45;
        public System.Windows.Forms.Button btn_Clean;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Find;
        public System.Windows.Forms.Button btn_Del;
        private BaseControls.MyDataGridView dgv_ExamClass;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BaseControls.Panels.MyPanel pl_Top;
        private BaseControls.MyLabel label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEVICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DICOM_MODALITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOCAL_ID_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_PATTERN_CLASS;
    }
}