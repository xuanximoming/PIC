namespace SIS
{
    partial class frmInterestPatientL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterestPatientL));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cms_InterestPatient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_li = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SaveNoteName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.trv_InterestPatient = new System.Windows.Forms.TreeView();
            this.pl_Right = new BaseControls.Panels.MyPanel();
            this.chk_EXAM_ACCESSION_NUM = new System.Windows.Forms.CheckBox();
            this.chk_PATIENT_ID = new System.Windows.Forms.CheckBox();
            this.txt_NOTE_NAME = new BaseControls.MyTextBox();
            this.txt_MEMO = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.cms_InterestPatient.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pl_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder doc.png");
            this.imageList1.Images.SetKeyName(1, "doc.png");
            // 
            // cms_InterestPatient
            // 
            this.cms_InterestPatient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_Add,
            this.tsm_li});
            this.cms_InterestPatient.Name = "cms_TEMPLATE_DICT";
            this.cms_InterestPatient.Size = new System.Drawing.Size(119, 48);
            // 
            // cms_Add
            // 
            this.cms_Add.Name = "cms_Add";
            this.cms_Add.Size = new System.Drawing.Size(118, 22);
            this.cms_Add.Text = "新增分类";
            this.cms_Add.Click += new System.EventHandler(this.cms_Add_Click);
            // 
            // tsm_li
            // 
            this.tsm_li.Name = "tsm_li";
            this.tsm_li.Size = new System.Drawing.Size(118, 22);
            this.tsm_li.Text = "收缩";
            this.tsm_li.Click += new System.EventHandler(this.tsm_li_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 649F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_SaveNoteName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 27);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // btn_SaveNoteName
            // 
            this.btn_SaveNoteName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SaveNoteName.FlatAppearance.BorderSize = 0;
            this.btn_SaveNoteName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveNoteName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_SaveNoteName.Location = new System.Drawing.Point(4, 4);
            this.btn_SaveNoteName.Name = "btn_SaveNoteName";
            this.btn_SaveNoteName.Size = new System.Drawing.Size(94, 19);
            this.btn_SaveNoteName.TabIndex = 1;
            this.btn_SaveNoteName.Text = "新增分类";
            this.btn_SaveNoteName.UseVisualStyleBackColor = true;
            this.btn_SaveNoteName.Click += new System.EventHandler(this.btn_SaveNoteName_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(105, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存病人资料";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // trv_InterestPatient
            // 
            this.trv_InterestPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trv_InterestPatient.ContextMenuStrip = this.cms_InterestPatient;
            this.trv_InterestPatient.Cursor = System.Windows.Forms.Cursors.Default;
            this.trv_InterestPatient.FullRowSelect = true;
            this.trv_InterestPatient.Location = new System.Drawing.Point(4, 30);
            this.trv_InterestPatient.Name = "trv_InterestPatient";
            this.trv_InterestPatient.Size = new System.Drawing.Size(180, 459);
            this.trv_InterestPatient.TabIndex = 38;
            this.trv_InterestPatient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trv_InterestPatient_MouseDown);
            // 
            // pl_Right
            // 
            this.pl_Right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_Right.BorderColor = System.Drawing.Color.Silver;
            this.pl_Right.Controls.Add(this.chk_EXAM_ACCESSION_NUM);
            this.pl_Right.Controls.Add(this.chk_PATIENT_ID);
            this.pl_Right.Controls.Add(this.txt_NOTE_NAME);
            this.pl_Right.Controls.Add(this.txt_MEMO);
            this.pl_Right.Controls.Add(this.label1);
            this.pl_Right.Controls.Add(this.label2);
            this.pl_Right.Location = new System.Drawing.Point(190, 30);
            this.pl_Right.Name = "pl_Right";
            this.pl_Right.Size = new System.Drawing.Size(158, 459);
            this.pl_Right.TabIndex = 39;
            // 
            // chk_EXAM_ACCESSION_NUM
            // 
            this.chk_EXAM_ACCESSION_NUM.AutoSize = true;
            this.chk_EXAM_ACCESSION_NUM.Location = new System.Drawing.Point(88, 12);
            this.chk_EXAM_ACCESSION_NUM.Name = "chk_EXAM_ACCESSION_NUM";
            this.chk_EXAM_ACCESSION_NUM.Size = new System.Drawing.Size(60, 16);
            this.chk_EXAM_ACCESSION_NUM.TabIndex = 41;
            this.chk_EXAM_ACCESSION_NUM.Text = "申请号";
            this.chk_EXAM_ACCESSION_NUM.UseVisualStyleBackColor = true;
            // 
            // chk_PATIENT_ID
            // 
            this.chk_PATIENT_ID.AutoSize = true;
            this.chk_PATIENT_ID.Location = new System.Drawing.Point(9, 12);
            this.chk_PATIENT_ID.Name = "chk_PATIENT_ID";
            this.chk_PATIENT_ID.Size = new System.Drawing.Size(60, 16);
            this.chk_PATIENT_ID.TabIndex = 41;
            this.chk_PATIENT_ID.Text = "病人ID";
            this.chk_PATIENT_ID.UseVisualStyleBackColor = true;
            // 
            // txt_NOTE_NAME
            // 
            this.txt_NOTE_NAME.Location = new System.Drawing.Point(49, 41);
            this.txt_NOTE_NAME.Name = "txt_NOTE_NAME";
            this.txt_NOTE_NAME.Size = new System.Drawing.Size(95, 21);
            this.txt_NOTE_NAME.TabIndex = 40;
            // 
            // txt_MEMO
            // 
            this.txt_MEMO.Location = new System.Drawing.Point(5, 89);
            this.txt_MEMO.Multiline = true;
            this.txt_MEMO.Name = "txt_MEMO";
            this.txt_MEMO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_MEMO.Size = new System.Drawing.Size(150, 367);
            this.txt_MEMO.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分类名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "说明：";
            // 
            // frmInterestPatientL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 501);
            this.Controls.Add(this.pl_Right);
            this.Controls.Add(this.trv_InterestPatient);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInterestPatientL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "感兴趣病人入库";
            this.Load += new System.EventHandler(this.frmInterestPatientL_Load);
            this.cms_InterestPatient.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pl_Right.ResumeLayout(false);
            this.pl_Right.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cms_InterestPatient;
        private System.Windows.Forms.ToolStripMenuItem cms_Add;
        private System.Windows.Forms.ToolStripMenuItem tsm_li;
        private System.Windows.Forms.TreeView trv_InterestPatient;
        private BaseControls.Panels.MyPanel pl_Right;
        private BaseControls.MyTextBox txt_MEMO;
        private BaseControls.MyLabel label2;
        private BaseControls.MyTextBox txt_NOTE_NAME;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.CheckBox chk_PATIENT_ID;
        private System.Windows.Forms.CheckBox chk_EXAM_ACCESSION_NUM;
        public System.Windows.Forms.Button btn_SaveNoteName;

    }
}