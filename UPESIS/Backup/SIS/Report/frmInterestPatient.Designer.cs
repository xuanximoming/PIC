namespace SIS.SysMaintenance
{
    partial class frmInterestPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterestPatient));
            this.pl_Left = new BaseControls.Panels.MyPanel();
            this.trv_InterestPatient = new System.Windows.Forms.TreeView();
            this.cms_InterestPatient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Add_Equ = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Add_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_li = new System.Windows.Forms.ToolStripMenuItem();
            this.pl_Right = new BaseControls.Panels.MyPanel();
            this.txt_MEMO = new BaseControls.MyTextBox();
            this.txt_NOTE_NAME = new BaseControls.MyTextBox();
            this.label2 = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.lv_Patient = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.pl_Left.SuspendLayout();
            this.cms_InterestPatient.SuspendLayout();
            this.pl_Right.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_Left
            // 
            this.pl_Left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pl_Left.BorderColor = System.Drawing.Color.Silver;
            this.pl_Left.Controls.Add(this.trv_InterestPatient);
            this.pl_Left.Location = new System.Drawing.Point(12, 36);
            this.pl_Left.Name = "pl_Left";
            this.pl_Left.Size = new System.Drawing.Size(229, 548);
            this.pl_Left.TabIndex = 0;
            // 
            // trv_InterestPatient
            // 
            this.trv_InterestPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trv_InterestPatient.ContextMenuStrip = this.cms_InterestPatient;
            this.trv_InterestPatient.Cursor = System.Windows.Forms.Cursors.Default;
            this.trv_InterestPatient.FullRowSelect = true;
            this.trv_InterestPatient.Location = new System.Drawing.Point(9, 6);
            this.trv_InterestPatient.Name = "trv_InterestPatient";
            this.trv_InterestPatient.Size = new System.Drawing.Size(210, 537);
            this.trv_InterestPatient.TabIndex = 37;
            this.trv_InterestPatient.DoubleClick += new System.EventHandler(this.trv_InterestPatient_DoubleClick);
            this.trv_InterestPatient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trv_InterestPatient_MouseDown);
            // 
            // cms_InterestPatient
            // 
            this.cms_InterestPatient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_Add,
            this.cms_Delete,
            this.tsm_li});
            this.cms_InterestPatient.Name = "cms_TEMPLATE_DICT";
            this.cms_InterestPatient.Size = new System.Drawing.Size(95, 70);
            // 
            // cms_Add
            // 
            this.cms_Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_Add_Equ,
            this.cms_Add_Next});
            this.cms_Add.Name = "cms_Add";
            this.cms_Add.Size = new System.Drawing.Size(94, 22);
            this.cms_Add.Text = "新增";
            // 
            // cms_Add_Equ
            // 
            this.cms_Add_Equ.Name = "cms_Add_Equ";
            this.cms_Add_Equ.Size = new System.Drawing.Size(94, 22);
            this.cms_Add_Equ.Text = "同级";
            this.cms_Add_Equ.Click += new System.EventHandler(this.cms_Add_Equ_Click);
            // 
            // cms_Add_Next
            // 
            this.cms_Add_Next.Name = "cms_Add_Next";
            this.cms_Add_Next.Size = new System.Drawing.Size(94, 22);
            this.cms_Add_Next.Text = "下级";
            this.cms_Add_Next.Click += new System.EventHandler(this.cms_Add_Next_Click);
            // 
            // cms_Delete
            // 
            this.cms_Delete.Name = "cms_Delete";
            this.cms_Delete.Size = new System.Drawing.Size(94, 22);
            this.cms_Delete.Text = "删除";
            this.cms_Delete.Click += new System.EventHandler(this.cms_Delete_Click);
            // 
            // tsm_li
            // 
            this.tsm_li.Name = "tsm_li";
            this.tsm_li.Size = new System.Drawing.Size(94, 22);
            this.tsm_li.Text = "收缩";
            this.tsm_li.Click += new System.EventHandler(this.tsm_li_Click);
            // 
            // pl_Right
            // 
            this.pl_Right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_Right.BorderColor = System.Drawing.Color.Silver;
            this.pl_Right.Controls.Add(this.txt_MEMO);
            this.pl_Right.Controls.Add(this.txt_NOTE_NAME);
            this.pl_Right.Controls.Add(this.label2);
            this.pl_Right.Controls.Add(this.label1);
            this.pl_Right.Location = new System.Drawing.Point(247, 36);
            this.pl_Right.Name = "pl_Right";
            this.pl_Right.Size = new System.Drawing.Size(553, 94);
            this.pl_Right.TabIndex = 0;
            // 
            // txt_MEMO
            // 
            this.txt_MEMO.Location = new System.Drawing.Point(64, 33);
            this.txt_MEMO.Multiline = true;
            this.txt_MEMO.Name = "txt_MEMO";
            this.txt_MEMO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_MEMO.Size = new System.Drawing.Size(477, 51);
            this.txt_MEMO.TabIndex = 1;
            // 
            // txt_NOTE_NAME
            // 
            this.txt_NOTE_NAME.Location = new System.Drawing.Point(64, 6);
            this.txt_NOTE_NAME.Name = "txt_NOTE_NAME";
            this.txt_NOTE_NAME.Size = new System.Drawing.Size(239, 21);
            this.txt_NOTE_NAME.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "说明：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分类：";
            // 
            // lv_Patient
            // 
            this.lv_Patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_Patient.LargeImageList = this.imageList1;
            this.lv_Patient.Location = new System.Drawing.Point(247, 145);
            this.lv_Patient.Name = "lv_Patient";
            this.lv_Patient.Size = new System.Drawing.Size(553, 434);
            this.lv_Patient.TabIndex = 33;
            this.lv_Patient.TileSize = new System.Drawing.Size(144, 90);
            this.lv_Patient.UseCompatibleStateImageBehavior = false;
            this.lv_Patient.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_Patient_MouseDoubleClick);
            this.lv_Patient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_Patient_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder doc.png");
            this.imageList1.Images.SetKeyName(1, "doc.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
            this.tableLayoutPanel1.TabIndex = 32;
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
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(155, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Clean.Location = new System.Drawing.Point(256, 4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(94, 19);
            this.btn_Clean.TabIndex = 0;
            this.btn_Clean.Text = "清空";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // frmInterestPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 590);
            this.Controls.Add(this.lv_Patient);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pl_Right);
            this.Controls.Add(this.pl_Left);
            this.Name = "frmInterestPatient";
            this.Text = "感兴趣病人记录";
            this.Load += new System.EventHandler(this.InterestPatient_Load);
            this.pl_Left.ResumeLayout(false);
            this.cms_InterestPatient.ResumeLayout(false);
            this.pl_Right.ResumeLayout(false);
            this.pl_Right.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.Panels.MyPanel pl_Left;
        private BaseControls.Panels.MyPanel pl_Right;
        private System.Windows.Forms.TreeView trv_InterestPatient;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Clean;
        private BaseControls.MyTextBox txt_MEMO;
        private BaseControls.MyTextBox txt_NOTE_NAME;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.ListView lv_Patient;
        private System.Windows.Forms.ContextMenuStrip cms_InterestPatient;
        private System.Windows.Forms.ToolStripMenuItem cms_Add;
        private System.Windows.Forms.ToolStripMenuItem cms_Add_Equ;
        private System.Windows.Forms.ToolStripMenuItem cms_Add_Next;
        private System.Windows.Forms.ToolStripMenuItem cms_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsm_li;
        private System.Windows.Forms.ImageList imageList1;
    }
}