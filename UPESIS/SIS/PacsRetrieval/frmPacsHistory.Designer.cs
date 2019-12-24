namespace SIS
{
    partial class frmPacsHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacsHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pan_Input = new System.Windows.Forms.Panel();
            this.p_Tool = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsb_Find = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_OpenImg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_CopyToRpt = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmi_Description = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Impression = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ExamPara = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Recommendation = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_PatientLocalId = new BaseControls.userTextBox();
            this.txt_PatientId = new BaseControls.userTextBox();
            this.txt_PatientName = new BaseControls.userTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.pan_List = new System.Windows.Forms.Panel();
            this.gb_HistoryRptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.l_RptInfo = new BaseControls.MyLabel();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_Study = new BaseControls.MyDataGridView();
            this.PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPORT_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPORT_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_ACCESSION_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_INSTANCE_UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.l_Count = new BaseControls.MyLabel();
            this.label10 = new BaseControls.MyLabel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pan_Input.SuspendLayout();
            this.p_Tool.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.pan_List.SuspendLayout();
            this.gb_HistoryRptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Study)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_Input
            // 
            this.pan_Input.AutoScroll = true;
            this.pan_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_Input.Controls.Add(this.p_Tool);
            this.pan_Input.Controls.Add(this.txt_PatientLocalId);
            this.pan_Input.Controls.Add(this.txt_PatientId);
            this.pan_Input.Controls.Add(this.txt_PatientName);
            this.pan_Input.Controls.Add(this.label1);
            this.pan_Input.Controls.Add(this.label2);
            this.pan_Input.Controls.Add(this.label3);
            this.pan_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_Input.Location = new System.Drawing.Point(0, 0);
            this.pan_Input.Name = "pan_Input";
            this.pan_Input.Size = new System.Drawing.Size(290, 167);
            this.pan_Input.TabIndex = 55;
            // 
            // p_Tool
            // 
            this.p_Tool.Controls.Add(this.toolStrip);
            this.p_Tool.Location = new System.Drawing.Point(19, 115);
            this.p_Tool.Name = "p_Tool";
            this.p_Tool.Size = new System.Drawing.Size(258, 36);
            this.p_Tool.TabIndex = 46;
            // 
            // toolStrip
            // 
            this.toolStrip.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Find,
            this.toolStripSeparator1,
            this.tsb_OpenImg,
            this.toolStripSeparator2,
            this.tsb_CopyToRpt});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(258, 36);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsb_Find
            // 
            this.tsb_Find.AutoSize = false;
            this.tsb_Find.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Find.Image")));
            this.tsb_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Find.Name = "tsb_Find";
            this.tsb_Find.Size = new System.Drawing.Size(60, 34);
            this.tsb_Find.Text = "查询";
            this.tsb_Find.Click += new System.EventHandler(this.tsb_Find_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tsb_OpenImg
            // 
            this.tsb_OpenImg.AutoSize = false;
            this.tsb_OpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsb_OpenImg.Image")));
            this.tsb_OpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OpenImg.Name = "tsb_OpenImg";
            this.tsb_OpenImg.Size = new System.Drawing.Size(73, 34);
            this.tsb_OpenImg.Text = "打开图像";
            this.tsb_OpenImg.Click += new System.EventHandler(this.tsb_OpenImg_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // tsb_CopyToRpt
            // 
            this.tsb_CopyToRpt.AutoSize = false;
            this.tsb_CopyToRpt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Description,
            this.tsmi_Impression,
            this.tsmi_ExamPara,
            this.tsmi_Recommendation});
            this.tsb_CopyToRpt.Image = ((System.Drawing.Image)(resources.GetObject("tsb_CopyToRpt.Image")));
            this.tsb_CopyToRpt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_CopyToRpt.Name = "tsb_CopyToRpt";
            this.tsb_CopyToRpt.Size = new System.Drawing.Size(100, 34);
            this.tsb_CopyToRpt.Text = "复制到报告";
            this.tsb_CopyToRpt.ButtonClick += new System.EventHandler(this.tsb_CopyToRpt_ButtonClick);
            // 
            // tsmi_Description
            // 
            this.tsmi_Description.Name = "tsmi_Description";
            this.tsmi_Description.Size = new System.Drawing.Size(130, 22);
            this.tsmi_Description.Text = "检查所见";
            this.tsmi_Description.Click += new System.EventHandler(this.tsmi_Description_Click);
            // 
            // tsmi_Impression
            // 
            this.tsmi_Impression.Name = "tsmi_Impression";
            this.tsmi_Impression.Size = new System.Drawing.Size(130, 22);
            this.tsmi_Impression.Text = "印象(诊断)";
            this.tsmi_Impression.Click += new System.EventHandler(this.tsmi_Impression_Click);
            // 
            // tsmi_ExamPara
            // 
            this.tsmi_ExamPara.Name = "tsmi_ExamPara";
            this.tsmi_ExamPara.Size = new System.Drawing.Size(130, 22);
            this.tsmi_ExamPara.Text = "检查参数";
            this.tsmi_ExamPara.Click += new System.EventHandler(this.tsmi_ExamPara_Click);
            // 
            // tsmi_Recommendation
            // 
            this.tsmi_Recommendation.Name = "tsmi_Recommendation";
            this.tsmi_Recommendation.Size = new System.Drawing.Size(130, 22);
            this.tsmi_Recommendation.Text = "建议";
            this.tsmi_Recommendation.Click += new System.EventHandler(this.tsmi_Recommendation_Click);
            // 
            // txt_PatientLocalId
            // 
            this.txt_PatientLocalId.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientLocalId.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientLocalId.IsChangeColor = true;
            this.txt_PatientLocalId.Location = new System.Drawing.Point(106, 80);
            this.txt_PatientLocalId.Name = "txt_PatientLocalId";
            this.txt_PatientLocalId.Size = new System.Drawing.Size(118, 21);
            this.txt_PatientLocalId.TabIndex = 43;
            this.txt_PatientLocalId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PatientLocalId_KeyDown);
            // 
            // txt_PatientId
            // 
            this.txt_PatientId.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientId.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientId.IsChangeColor = true;
            this.txt_PatientId.Location = new System.Drawing.Point(106, 51);
            this.txt_PatientId.Name = "txt_PatientId";
            this.txt_PatientId.Size = new System.Drawing.Size(117, 21);
            this.txt_PatientId.TabIndex = 41;
            this.txt_PatientId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PatientId_KeyDown);
            // 
            // txt_PatientName
            // 
            this.txt_PatientName.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_PatientName.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientName.IsChangeColor = true;
            this.txt_PatientName.Location = new System.Drawing.Point(106, 22);
            this.txt_PatientName.Name = "txt_PatientName";
            this.txt_PatientName.Size = new System.Drawing.Size(117, 21);
            this.txt_PatientName.TabIndex = 39;
            this.txt_PatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PatientName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "病人姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "病人ID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(47, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "检查号：";
            // 
            // pan_List
            // 
            this.pan_List.Controls.Add(this.gb_HistoryRptInfo);
            this.pan_List.Controls.Add(this.gb_PromptInfo);
            this.pan_List.Controls.Add(this.dgv_Study);
            this.pan_List.Controls.Add(this.panel1);
            this.pan_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_List.Location = new System.Drawing.Point(0, 167);
            this.pan_List.Name = "pan_List";
            this.pan_List.Size = new System.Drawing.Size(290, 611);
            this.pan_List.TabIndex = 56;
            // 
            // gb_HistoryRptInfo
            // 
            this.gb_HistoryRptInfo.BackgroundColor = System.Drawing.Color.Bisque;
            this.gb_HistoryRptInfo.BackgroundGradientColor = System.Drawing.Color.White;
            this.gb_HistoryRptInfo.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.gb_HistoryRptInfo.BorderColor = System.Drawing.Color.SandyBrown;
            this.gb_HistoryRptInfo.BorderThickness = 1F;
            this.gb_HistoryRptInfo.Controls.Add(this.pictureBox2);
            this.gb_HistoryRptInfo.Controls.Add(this.l_RptInfo);
            this.gb_HistoryRptInfo.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gb_HistoryRptInfo.GroupImage = null;
            this.gb_HistoryRptInfo.GroupTitle = "";
            this.gb_HistoryRptInfo.Location = new System.Drawing.Point(20, 167);
            this.gb_HistoryRptInfo.Name = "gb_HistoryRptInfo";
            this.gb_HistoryRptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_HistoryRptInfo.PaintGroupBox = false;
            this.gb_HistoryRptInfo.RoundCorners = 10;
            this.gb_HistoryRptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_HistoryRptInfo.ShadowControl = false;
            this.gb_HistoryRptInfo.ShadowThickness = 3;
            this.gb_HistoryRptInfo.Size = new System.Drawing.Size(246, 70);
            this.gb_HistoryRptInfo.TabIndex = 61;
            this.gb_HistoryRptInfo.UseWaitCursor = true;
            this.gb_HistoryRptInfo.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(3, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.UseWaitCursor = true;
            // 
            // l_RptInfo
            // 
            this.l_RptInfo.AutoSize = true;
            this.l_RptInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_RptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.l_RptInfo.Location = new System.Drawing.Point(41, 44);
            this.l_RptInfo.Name = "l_RptInfo";
            this.l_RptInfo.Size = new System.Drawing.Size(113, 12);
            this.l_RptInfo.TabIndex = 0;
            this.l_RptInfo.Text = "此次检查没有报告！";
            this.l_RptInfo.UseWaitCursor = true;
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(38, 96);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 33;
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
            this.lb_PromptInfo.Size = new System.Drawing.Size(161, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "查询不到符合此条件的记录！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_Study
            // 
            this.dgv_Study.AllowUserToAddRows = false;
            this.dgv_Study.AllowUserToDeleteRows = false;
            this.dgv_Study.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Study.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Study.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Study.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Study.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Study.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PATIENT_ID,
            this.PATIENT_NAME,
            this.PATIENT_AGE,
            this.PATIENT_SEX,
            this.EXAM_ITEM,
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.REPORT_DATE_TIME,
            this.REPORT_STATUS,
            this.STUDY_DATE_TIME,
            this.EXAM_ACCESSION_NUM,
            this.STUDY_INSTANCE_UID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Study.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Study.DefaultScaleWidth = 1280;
            this.dgv_Study.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Study.Location = new System.Drawing.Point(0, 20);
            this.dgv_Study.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Study.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Study.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Study.MergeColumnNames")));
            this.dgv_Study.Name = "dgv_Study";
            this.dgv_Study.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Study.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Study.RowHeadersVisible = false;
            this.dgv_Study.RowHeadersWidth = 20;
            this.dgv_Study.RowTemplate.Height = 23;
            this.dgv_Study.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Study.Size = new System.Drawing.Size(290, 591);
            this.dgv_Study.TabIndex = 32;
            this.dgv_Study.XmlFile = null;
            this.dgv_Study.DoubleClick += new System.EventHandler(this.dgv_WorkList_DoubleClick);
            this.dgv_Study.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Study_CellFormatting);
            this.dgv_Study.Click += new System.EventHandler(this.dgv_Study_Click);
            // 
            // PATIENT_ID
            // 
            this.PATIENT_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PATIENT_ID.DataPropertyName = "PATIENT_ID";
            this.PATIENT_ID.FillWeight = 12F;
            this.PATIENT_ID.Frozen = true;
            this.PATIENT_ID.HeaderText = "病人ID";
            this.PATIENT_ID.MinimumWidth = 70;
            this.PATIENT_ID.Name = "PATIENT_ID";
            this.PATIENT_ID.ReadOnly = true;
            this.PATIENT_ID.Visible = false;
            this.PATIENT_ID.Width = 80;
            // 
            // PATIENT_NAME
            // 
            this.PATIENT_NAME.DataPropertyName = "PATIENT_NAME";
            this.PATIENT_NAME.HeaderText = "姓名";
            this.PATIENT_NAME.Name = "PATIENT_NAME";
            this.PATIENT_NAME.ReadOnly = true;
            this.PATIENT_NAME.Width = 60;
            // 
            // PATIENT_AGE
            // 
            this.PATIENT_AGE.DataPropertyName = "PATIENT_AGE";
            this.PATIENT_AGE.HeaderText = "年龄";
            this.PATIENT_AGE.Name = "PATIENT_AGE";
            this.PATIENT_AGE.ReadOnly = true;
            this.PATIENT_AGE.Width = 50;
            // 
            // PATIENT_SEX
            // 
            this.PATIENT_SEX.DataPropertyName = "PATIENT_SEX";
            this.PATIENT_SEX.HeaderText = "性别";
            this.PATIENT_SEX.Name = "PATIENT_SEX";
            this.PATIENT_SEX.ReadOnly = true;
            this.PATIENT_SEX.Width = 50;
            // 
            // EXAM_ITEM
            // 
            this.EXAM_ITEM.DataPropertyName = "EXAM_ITEM";
            this.EXAM_ITEM.FillWeight = 13F;
            this.EXAM_ITEM.HeaderText = "检查项目";
            this.EXAM_ITEM.Name = "EXAM_ITEM";
            this.EXAM_ITEM.ReadOnly = true;
            this.EXAM_ITEM.Width = 120;
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            this.EXAM_CLASS.Width = 70;
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.ReadOnly = true;
            this.EXAM_SUB_CLASS.Width = 70;
            // 
            // REPORT_DATE_TIME
            // 
            this.REPORT_DATE_TIME.DataPropertyName = "REPORT_DATE_TIME";
            this.REPORT_DATE_TIME.FillWeight = 10F;
            this.REPORT_DATE_TIME.HeaderText = "报告时间";
            this.REPORT_DATE_TIME.Name = "REPORT_DATE_TIME";
            this.REPORT_DATE_TIME.ReadOnly = true;
            this.REPORT_DATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.REPORT_DATE_TIME.Width = 120;
            // 
            // REPORT_STATUS
            // 
            this.REPORT_STATUS.DataPropertyName = "REPORT_STATUS";
            this.REPORT_STATUS.HeaderText = "报告状态";
            this.REPORT_STATUS.Name = "REPORT_STATUS";
            this.REPORT_STATUS.ReadOnly = true;
            this.REPORT_STATUS.Width = 80;
            // 
            // STUDY_DATE_TIME
            // 
            this.STUDY_DATE_TIME.DataPropertyName = "STUDY_DATE_TIME";
            this.STUDY_DATE_TIME.HeaderText = "检查时间";
            this.STUDY_DATE_TIME.Name = "STUDY_DATE_TIME";
            this.STUDY_DATE_TIME.ReadOnly = true;
            this.STUDY_DATE_TIME.Width = 120;
            // 
            // EXAM_ACCESSION_NUM
            // 
            this.EXAM_ACCESSION_NUM.DataPropertyName = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.HeaderText = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.Name = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.ReadOnly = true;
            this.EXAM_ACCESSION_NUM.Visible = false;
            // 
            // STUDY_INSTANCE_UID
            // 
            this.STUDY_INSTANCE_UID.DataPropertyName = "STUDY_INSTANCE_UID";
            this.STUDY_INSTANCE_UID.HeaderText = "STUDY_INSTANCE_UID";
            this.STUDY_INSTANCE_UID.Name = "STUDY_INSTANCE_UID";
            this.STUDY_INSTANCE_UID.ReadOnly = true;
            this.STUDY_INSTANCE_UID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.l_Count);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 20);
            this.panel1.TabIndex = 54;
            // 
            // l_Count
            // 
            this.l_Count.Dock = System.Windows.Forms.DockStyle.Right;
            this.l_Count.Font = new System.Drawing.Font("宋体", 9F);
            this.l_Count.ForeColor = System.Drawing.Color.Blue;
            this.l_Count.Location = new System.Drawing.Point(115, 0);
            this.l_Count.Name = "l_Count";
            this.l_Count.Size = new System.Drawing.Size(171, 16);
            this.l_Count.TabIndex = 54;
            this.l_Count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(8, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 53;
            this.label10.Text = "检查列表";
            // 
            // splitter
            // 
            this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter.Location = new System.Drawing.Point(0, 167);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 611);
            this.splitter.TabIndex = 59;
            this.splitter.TabStop = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FILE_DATE_TIME";
            this.dataGridViewTextBoxColumn6.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FIELD_INF";
            this.dataGridViewTextBoxColumn3.HeaderText = "字段信息";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FILE_DATE_TIME";
            this.dataGridViewTextBoxColumn4.FillWeight = 13F;
            this.dataGridViewTextBoxColumn4.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FIELD_INF";
            this.dataGridViewTextBoxColumn5.HeaderText = "字段信息";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PRINT_TEMPLATE";
            this.dataGridViewTextBoxColumn2.FillWeight = 13F;
            this.dataGridViewTextBoxColumn2.HeaderText = "模版名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRINT_TEMPLATE_ID";
            this.dataGridViewTextBoxColumn1.FillWeight = 12F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "编号";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 81;
            // 
            // frmPacsHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(290, 778);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.pan_List);
            this.Controls.Add(this.pan_Input);
            this.DockAreas = ((BaseControls.Docking.DockAreas)(((((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)
                        | BaseControls.Docking.DockAreas.DockTop)
                        | BaseControls.Docking.DockAreas.DockBottom)
                        | BaseControls.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPacsHistory";
            this.Text = "历史记录";
            this.DockStateChanged += new System.EventHandler(this.frmPacsHistory_DockStateChanged);
            this.pan_Input.ResumeLayout(false);
            this.pan_Input.PerformLayout();
            this.p_Tool.ResumeLayout(false);
            this.p_Tool.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pan_List.ResumeLayout(false);
            this.gb_HistoryRptInfo.ResumeLayout(false);
            this.gb_HistoryRptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Study)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_Input;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel pan_List;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
        private BaseControls.MyDataGridView dgv_Study;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private BaseControls.MyLabel label3;
        private BaseControls.userTextBox txt_PatientLocalId;
        private BaseControls.MyLabel label2;
        private System.Windows.Forms.Panel p_Tool;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsb_Find;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton tsb_CopyToRpt;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ExamPara;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Description;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Impression;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Recommendation;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel panel1;
        private BaseControls.MyLabel l_Count;
        private BaseControls.MyLabel label10;
        public BaseControls.userTextBox txt_PatientId;
        private System.Windows.Forms.ToolStripButton tsb_OpenImg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public BaseControls.userTextBox txt_PatientName;
        private BaseControls.GroupBox.MyGroupBox gb_HistoryRptInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private BaseControls.MyLabel l_RptInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_AGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPORT_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPORT_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ACCESSION_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_INSTANCE_UID;

    }
}