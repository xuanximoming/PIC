namespace SIS.QualityControl
{
    partial class QC_ImageManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QC_ImageManage));
            this.myPnl = new BaseControls.Panels.MyPanel();
            this.dtp_QC_DATE = new System.Windows.Forms.DateTimePicker();
            this.cmb_Type = new System.Windows.Forms.ComboBox();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_Show = new System.Windows.Forms.Button();
            this.btn_ShowTop = new System.Windows.Forms.Button();
            this.dgv_ImageManage = new BaseControls.MyDataGridView();
            this.EXAM_ACCESSION_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_LOCAL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QC_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_SCORE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISTINCTION = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.myPnl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImageManage)).BeginInit();
            this.SuspendLayout();
            // 
            // myPnl
            // 
            this.myPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPnl.BorderColor = System.Drawing.Color.Silver;
            this.myPnl.Controls.Add(this.dtp_QC_DATE);
            this.myPnl.Controls.Add(this.cmb_Type);
            this.myPnl.Controls.Add(this.label1);
            this.myPnl.Controls.Add(this.label2);
            this.myPnl.Location = new System.Drawing.Point(12, 46);
            this.myPnl.Name = "myPnl";
            this.myPnl.Size = new System.Drawing.Size(948, 33);
            this.myPnl.TabIndex = 38;
            // 
            // dtp_QC_DATE
            // 
            this.dtp_QC_DATE.CustomFormat = "";
            this.dtp_QC_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_QC_DATE.Location = new System.Drawing.Point(293, 7);
            this.dtp_QC_DATE.Name = "dtp_QC_DATE";
            this.dtp_QC_DATE.Size = new System.Drawing.Size(132, 21);
            this.dtp_QC_DATE.TabIndex = 8;
            // 
            // cmb_Type
            // 
            this.cmb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Type.FormattingEnabled = true;
            this.cmb_Type.Location = new System.Drawing.Point(85, 8);
            this.cmb_Type.Name = "cmb_Type";
            this.cmb_Type.Size = new System.Drawing.Size(121, 20);
            this.cmb_Type.TabIndex = 10;
            this.cmb_Type.SelectedIndexChanged += new System.EventHandler(this.cmb_Type_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "质控时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "统计类型：";
            // 
            // btn_Del
            // 
            this.btn_Del.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Del.FlatAppearance.BorderSize = 0;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Del.Location = new System.Drawing.Point(398, 4);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(74, 19);
            this.btn_Del.TabIndex = 0;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
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
            this.btn_FunName.TabIndex = 5;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Del, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Find, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Show, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_ShowTop, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 27);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // btn_Find
            // 
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Find.Location = new System.Drawing.Point(155, 4);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(74, 19);
            this.btn_Find.TabIndex = 0;
            this.btn_Find.Text = "查询";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // btn_Show
            // 
            this.btn_Show.FlatAppearance.BorderSize = 0;
            this.btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Show.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Show.Location = new System.Drawing.Point(236, 4);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(74, 19);
            this.btn_Show.TabIndex = 0;
            this.btn_Show.Text = "查看记录";
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // btn_ShowTop
            // 
            this.btn_ShowTop.FlatAppearance.BorderSize = 0;
            this.btn_ShowTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowTop.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ShowTop.Location = new System.Drawing.Point(317, 4);
            this.btn_ShowTop.Name = "btn_ShowTop";
            this.btn_ShowTop.Size = new System.Drawing.Size(74, 19);
            this.btn_ShowTop.TabIndex = 0;
            this.btn_ShowTop.Text = "查看前10行记录";
            this.btn_ShowTop.UseVisualStyleBackColor = true;
            this.btn_ShowTop.Click += new System.EventHandler(this.btn_ShowTop_Click);
            // 
            // dgv_ImageManage
            // 
            this.dgv_ImageManage.AllowUserToAddRows = false;
            this.dgv_ImageManage.AllowUserToDeleteRows = false;
            this.dgv_ImageManage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ImageManage.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ImageManage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ImageManage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_ImageManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ImageManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_ACCESSION_NUM,
            this.PATIENT_LOCAL_ID,
            this.PATIENT_ID,
            this.TYPE,
            this.PATIENT_NAME,
            this.PATIENT_SEX,
            this.STUDY_DATE_TIME,
            this.QC_DATE,
            this.TOTAL_SCORE,
            this.DISTINCTION});
            this.dgv_ImageManage.DefaultScaleWidth = 1280;
            this.dgv_ImageManage.Location = new System.Drawing.Point(12, 95);
            this.dgv_ImageManage.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ImageManage.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ImageManage.MergeColumnNames")));
            this.dgv_ImageManage.Name = "dgv_ImageManage";
            this.dgv_ImageManage.ReadOnly = true;
            this.dgv_ImageManage.RowHeadersWidth = 30;
            this.dgv_ImageManage.RowTemplate.Height = 23;
            this.dgv_ImageManage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ImageManage.Size = new System.Drawing.Size(948, 509);
            this.dgv_ImageManage.TabIndex = 39;
            this.dgv_ImageManage.XmlFile = null;
            this.dgv_ImageManage.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ImageManage_DataError);
            // 
            // EXAM_ACCESSION_NUM
            // 
            this.EXAM_ACCESSION_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_ACCESSION_NUM.DataPropertyName = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.FillWeight = 20F;
            this.EXAM_ACCESSION_NUM.HeaderText = "检查申请号";
            this.EXAM_ACCESSION_NUM.Name = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.ReadOnly = true;
            this.EXAM_ACCESSION_NUM.Visible = false;
            // 
            // PATIENT_LOCAL_ID
            // 
            this.PATIENT_LOCAL_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_LOCAL_ID.DataPropertyName = "PATIENT_LOCAL_ID";
            this.PATIENT_LOCAL_ID.FillWeight = 12F;
            this.PATIENT_LOCAL_ID.HeaderText = "检查号";
            this.PATIENT_LOCAL_ID.Name = "PATIENT_LOCAL_ID";
            this.PATIENT_LOCAL_ID.ReadOnly = true;
            // 
            // PATIENT_ID
            // 
            this.PATIENT_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_ID.DataPropertyName = "PATIENT_ID";
            this.PATIENT_ID.FillWeight = 15F;
            this.PATIENT_ID.HeaderText = "病人ID";
            this.PATIENT_ID.Name = "PATIENT_ID";
            this.PATIENT_ID.ReadOnly = true;
            // 
            // TYPE
            // 
            this.TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TYPE.DataPropertyName = "TYPE";
            this.TYPE.FillWeight = 20F;
            this.TYPE.HeaderText = "图像类型";
            this.TYPE.Name = "TYPE";
            this.TYPE.ReadOnly = true;
            // 
            // PATIENT_NAME
            // 
            this.PATIENT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_NAME.DataPropertyName = "PATIENT_NAME";
            this.PATIENT_NAME.FillWeight = 15F;
            this.PATIENT_NAME.HeaderText = "姓名";
            this.PATIENT_NAME.Name = "PATIENT_NAME";
            this.PATIENT_NAME.ReadOnly = true;
            // 
            // PATIENT_SEX
            // 
            this.PATIENT_SEX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_SEX.DataPropertyName = "PATIENT_SEX";
            this.PATIENT_SEX.FillWeight = 10F;
            this.PATIENT_SEX.HeaderText = "性别";
            this.PATIENT_SEX.Name = "PATIENT_SEX";
            this.PATIENT_SEX.ReadOnly = true;
            // 
            // STUDY_DATE_TIME
            // 
            this.STUDY_DATE_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STUDY_DATE_TIME.DataPropertyName = "STUDY_DATE_TIME";
            this.STUDY_DATE_TIME.FillWeight = 15F;
            this.STUDY_DATE_TIME.HeaderText = "检查时间";
            this.STUDY_DATE_TIME.Name = "STUDY_DATE_TIME";
            this.STUDY_DATE_TIME.ReadOnly = true;
            // 
            // QC_DATE
            // 
            this.QC_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QC_DATE.DataPropertyName = "QC_DATE";
            this.QC_DATE.FillWeight = 15F;
            this.QC_DATE.HeaderText = "质控时间";
            this.QC_DATE.Name = "QC_DATE";
            this.QC_DATE.ReadOnly = true;
            // 
            // TOTAL_SCORE
            // 
            this.TOTAL_SCORE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TOTAL_SCORE.DataPropertyName = "TOTAL_SCORE";
            this.TOTAL_SCORE.FillWeight = 10F;
            this.TOTAL_SCORE.HeaderText = "总分";
            this.TOTAL_SCORE.Name = "TOTAL_SCORE";
            this.TOTAL_SCORE.ReadOnly = true;
            // 
            // DISTINCTION
            // 
            this.DISTINCTION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DISTINCTION.DataPropertyName = "DISTINCTION";
            this.DISTINCTION.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DISTINCTION.FillWeight = 15F;
            this.DISTINCTION.HeaderText = "级别";
            this.DISTINCTION.Name = "DISTINCTION";
            this.DISTINCTION.ReadOnly = true;
            this.DISTINCTION.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DISTINCTION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // QC_ImageManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(972, 616);
            this.Controls.Add(this.dgv_ImageManage);
            this.Controls.Add(this.myPnl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QC_ImageManage";
            this.Text = "统计管理";
            this.Load += new System.EventHandler(this.QC_ImageManage_Load);
            this.myPnl.ResumeLayout(false);
            this.myPnl.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImageManage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.Panels.MyPanel myPnl;
        public System.Windows.Forms.Button btn_Del;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.DateTimePicker dtp_QC_DATE;
        private System.Windows.Forms.ComboBox cmb_Type;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label2;
        private BaseControls.MyDataGridView dgv_ImageManage;
        public System.Windows.Forms.Button btn_Show;
        public System.Windows.Forms.Button btn_ShowTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ACCESSION_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_LOCAL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QC_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_SCORE;
        private System.Windows.Forms.DataGridViewComboBoxColumn DISTINCTION;
    }
}