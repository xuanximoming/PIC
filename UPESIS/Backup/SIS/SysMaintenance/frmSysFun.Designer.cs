namespace SIS.SysMaintenance
{
    partial class frmSysFun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysFun));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new BaseControls.MyLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddSysFun = new System.Windows.Forms.Button();
            this.btnFunName = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.GvSysFun = new BaseControls.MyDataGridView();
            this.MODEL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_PLACE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CbSystemName = new BaseControls.ComboBoxs.MyComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvSysFun)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "请选择系统名称：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 649F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddSysFun, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancle, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 27);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(225, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "二级模块管理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddSysFun
            // 
            this.btnAddSysFun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddSysFun.FlatAppearance.BorderSize = 0;
            this.btnAddSysFun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSysFun.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddSysFun.Location = new System.Drawing.Point(132, 1);
            this.btnAddSysFun.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddSysFun.Name = "btnAddSysFun";
            this.btnAddSysFun.Size = new System.Drawing.Size(92, 25);
            this.btnAddSysFun.TabIndex = 4;
            this.btnAddSysFun.Text = "一级模块管理";
            this.btnAddSysFun.UseVisualStyleBackColor = true;
            this.btnAddSysFun.Click += new System.EventHandler(this.btnAddSysFun_Click);
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
            // btnCancle
            // 
            this.btnCancle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancle.FlatAppearance.BorderSize = 0;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancle.Location = new System.Drawing.Point(317, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(86, 19);
            this.btnCancle.TabIndex = 0;
            this.btnCancle.Text = "三级模块管理";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(345, 71);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 21;
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
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(42, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(149, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有二、三级模块信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // GvSysFun
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GvSysFun.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GvSysFun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GvSysFun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvSysFun.BackgroundColor = System.Drawing.Color.White;
            this.GvSysFun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvSysFun.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvSysFun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvSysFun.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MODEL_ID,
            this.MODEL_NAME,
            this.MODEL_PLACE,
            this.MODEL_CLASS,
            this.SORT_FLAG});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GvSysFun.DefaultCellStyle = dataGridViewCellStyle3;
            this.GvSysFun.DefaultScaleWidth = 1280;
            this.GvSysFun.Location = new System.Drawing.Point(10, 69);
            this.GvSysFun.Margin = new System.Windows.Forms.Padding(0);
            this.GvSysFun.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.GvSysFun.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("GvSysFun.MergeColumnNames")));
            this.GvSysFun.Name = "GvSysFun";
            this.GvSysFun.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvSysFun.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GvSysFun.RowTemplate.Height = 23;
            this.GvSysFun.Size = new System.Drawing.Size(795, 423);
            this.GvSysFun.TabIndex = 11;
            this.GvSysFun.XmlFile = null;
            // 
            // MODEL_ID
            // 
            this.MODEL_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_ID.DataPropertyName = "MODEL_ID";
            this.MODEL_ID.FillWeight = 10F;
            this.MODEL_ID.HeaderText = "编码";
            this.MODEL_ID.Name = "MODEL_ID";
            this.MODEL_ID.ReadOnly = true;
            // 
            // MODEL_NAME
            // 
            this.MODEL_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_NAME.DataPropertyName = "MODEL_NAME";
            this.MODEL_NAME.FillWeight = 20F;
            this.MODEL_NAME.HeaderText = "系统名称";
            this.MODEL_NAME.Name = "MODEL_NAME";
            this.MODEL_NAME.ReadOnly = true;
            // 
            // MODEL_PLACE
            // 
            this.MODEL_PLACE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_PLACE.DataPropertyName = "MODEL_PLACE";
            this.MODEL_PLACE.FillWeight = 30F;
            this.MODEL_PLACE.HeaderText = "窗体对象名称";
            this.MODEL_PLACE.Name = "MODEL_PLACE";
            this.MODEL_PLACE.ReadOnly = true;
            // 
            // MODEL_CLASS
            // 
            this.MODEL_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_CLASS.DataPropertyName = "MODEL_CLASS";
            this.MODEL_CLASS.FillWeight = 25F;
            this.MODEL_CLASS.HeaderText = "模块级别";
            this.MODEL_CLASS.Name = "MODEL_CLASS";
            this.MODEL_CLASS.ReadOnly = true;
            // 
            // SORT_FLAG
            // 
            this.SORT_FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SORT_FLAG.DataPropertyName = "SORT_FLAG";
            this.SORT_FLAG.FillWeight = 15F;
            this.SORT_FLAG.HeaderText = "序号";
            this.SORT_FLAG.Name = "SORT_FLAG";
            this.SORT_FLAG.ReadOnly = true;
            // 
            // CbSystemName
            // 
            this.CbSystemName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbSystemName.FormattingEnabled = true;
            this.CbSystemName.Location = new System.Drawing.Point(119, 42);
            this.CbSystemName.Name = "CbSystemName";
            this.CbSystemName.Size = new System.Drawing.Size(121, 20);
            this.CbSystemName.TabIndex = 9;
            this.CbSystemName.SelectedValueChanged += new System.EventHandler(this.CbSystemName_SelectedValueChanged);
            // 
            // SysFun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(814, 560);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.GvSysFun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbSystemName);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SysFun";
            this.Text = "系统功能";
            this.Load += new System.EventHandler(this.SysFun_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvSysFun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAddSysFun;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnCancle;
        public System.Windows.Forms.Button btnFunName;
        public System.Windows.Forms.Button button1;
        private BaseControls.ComboBoxs.MyComboBox CbSystemName;
        private BaseControls.MyLabel label1;
        private BaseControls.MyDataGridView GvSysFun;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_PLACE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT_FLAG;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.MyLabel lb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;



    }
}