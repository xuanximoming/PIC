namespace SIS
{
    partial class frmPrintTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintTemplate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Default = new BaseControls.Buttons.VistaButton();
            this.btn_Ok = new BaseControls.Buttons.VistaButton();
            this.btn_Cancel = new BaseControls.Buttons.VistaButton();
            this.dgv_PrintTemplate = new BaseControls.MyDataGridView();
            this.Exam_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_TEMPLATE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exam_Sub_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_TEMPLATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_DEFAULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_ShowAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PrintTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Default
            // 
            this.btn_Default.BackColor = System.Drawing.Color.Transparent;
            this.btn_Default.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Default.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Default.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Default.ButtonText = "默认";
            this.btn_Default.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Default.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Default.Image = ((System.Drawing.Image)(resources.GetObject("btn_Default.Image")));
            this.btn_Default.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Default.Location = new System.Drawing.Point(39, 333);
            this.btn_Default.Name = "btn_Default";
            this.btn_Default.Size = new System.Drawing.Size(76, 32);
            this.btn_Default.TabIndex = 4;
            this.btn_Default.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Default.Click += new System.EventHandler(this.btn_Default_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Ok.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Ok.ButtonText = "确定";
            this.btn_Ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Ok.Location = new System.Drawing.Point(123, 333);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(76, 32);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
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
            this.btn_Cancel.Location = new System.Drawing.Point(215, 333);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(76, 32);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dgv_PrintTemplate
            // 
            this.dgv_PrintTemplate.AllowUserToAddRows = false;
            this.dgv_PrintTemplate.AllowUserToDeleteRows = false;
            this.dgv_PrintTemplate.AllowUserToOrderColumns = true;
            this.dgv_PrintTemplate.AllowUserToResizeRows = false;
            this.dgv_PrintTemplate.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_PrintTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Exam_Class,
            this.PRINT_TEMPLATE_ID,
            this.Exam_Sub_Class,
            this.PRINT_TEMPLATE,
            this.IS_DEFAULT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PrintTemplate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PrintTemplate.DefaultScaleWidth = 1280;
            this.dgv_PrintTemplate.Location = new System.Drawing.Point(6, 34);
            this.dgv_PrintTemplate.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_PrintTemplate.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_PrintTemplate.MergeColumnNames")));
            this.dgv_PrintTemplate.MultiSelect = false;
            this.dgv_PrintTemplate.Name = "dgv_PrintTemplate";
            this.dgv_PrintTemplate.ReadOnly = true;
            this.dgv_PrintTemplate.RowHeadersVisible = false;
            this.dgv_PrintTemplate.RowTemplate.Height = 23;
            this.dgv_PrintTemplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PrintTemplate.Size = new System.Drawing.Size(322, 286);
            this.dgv_PrintTemplate.TabIndex = 52;
            this.dgv_PrintTemplate.XmlFile = null;
            this.dgv_PrintTemplate.DoubleClick += new System.EventHandler(this.dgv_PrintTemplate_DoubleClick);
            this.dgv_PrintTemplate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_PrintTemplate_MouseDoubleClick);
            // 
            // Exam_Class
            // 
            this.Exam_Class.DataPropertyName = "Exam_Class";
            this.Exam_Class.HeaderText = "检查类别";
            this.Exam_Class.Name = "Exam_Class";
            this.Exam_Class.ReadOnly = true;
            this.Exam_Class.Width = 80;
            // 
            // PRINT_TEMPLATE_ID
            // 
            this.PRINT_TEMPLATE_ID.DataPropertyName = "PRINT_TEMPLATE_ID";
            this.PRINT_TEMPLATE_ID.HeaderText = "模板ID";
            this.PRINT_TEMPLATE_ID.Name = "PRINT_TEMPLATE_ID";
            this.PRINT_TEMPLATE_ID.ReadOnly = true;
            this.PRINT_TEMPLATE_ID.Visible = false;
            // 
            // Exam_Sub_Class
            // 
            this.Exam_Sub_Class.DataPropertyName = "Exam_Sub_Class";
            this.Exam_Sub_Class.HeaderText = "检查子类";
            this.Exam_Sub_Class.Name = "Exam_Sub_Class";
            this.Exam_Sub_Class.ReadOnly = true;
            this.Exam_Sub_Class.Width = 80;
            // 
            // PRINT_TEMPLATE
            // 
            this.PRINT_TEMPLATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PRINT_TEMPLATE.DataPropertyName = "PRINT_TEMPLATE";
            this.PRINT_TEMPLATE.HeaderText = "打印模板";
            this.PRINT_TEMPLATE.Name = "PRINT_TEMPLATE";
            this.PRINT_TEMPLATE.ReadOnly = true;
            this.PRINT_TEMPLATE.Width = 78;
            // 
            // IS_DEFAULT
            // 
            this.IS_DEFAULT.DataPropertyName = "IS_DEFAULT";
            this.IS_DEFAULT.HeaderText = "是否默认";
            this.IS_DEFAULT.Name = "IS_DEFAULT";
            this.IS_DEFAULT.ReadOnly = true;
            this.IS_DEFAULT.Width = 80;
            // 
            // chk_ShowAll
            // 
            this.chk_ShowAll.AutoSize = true;
            this.chk_ShowAll.Location = new System.Drawing.Point(9, 12);
            this.chk_ShowAll.Name = "chk_ShowAll";
            this.chk_ShowAll.Size = new System.Drawing.Size(96, 16);
            this.chk_ShowAll.TabIndex = 53;
            this.chk_ShowAll.Text = "显示所有模板";
            this.chk_ShowAll.UseVisualStyleBackColor = true;
            this.chk_ShowAll.CheckedChanged += new System.EventHandler(this.chk_ShowAll_CheckedChanged);
            // 
            // frmPrintTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 389);
            this.Controls.Add(this.chk_ShowAll);
            this.Controls.Add(this.dgv_PrintTemplate);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Default);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmPrintTemplate";
            this.Text = "选择打印模板";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PrintTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseControls.Buttons.VistaButton btn_Default;
        private BaseControls.Buttons.VistaButton btn_Ok;
        private BaseControls.Buttons.VistaButton btn_Cancel;
        private BaseControls.MyDataGridView dgv_PrintTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam_Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_TEMPLATE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam_Sub_Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_TEMPLATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_DEFAULT;
        private System.Windows.Forms.CheckBox chk_ShowAll;
    }
}