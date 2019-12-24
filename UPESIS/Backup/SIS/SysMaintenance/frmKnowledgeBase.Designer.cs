namespace SIS.SysMaintenance
{
    partial class frmKnowledgeBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKnowledgeBase));
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.dgv_KnowledgeBase = new BaseControls.MyDataGridView();
            this.IMAGE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMAGE_INDEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMAGE_DATA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMAGE_COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_VISC_NAME = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_DESC_NAME = new BaseControls.ComboBoxs.MyComboBox();
            this.label3 = new BaseControls.MyLabel();
            this.label4 = new BaseControls.MyLabel();
            this.myPanel2 = new BaseControls.Panels.MyPanel();
            this.pb_Image = new System.Windows.Forms.PictureBox();
            this.pl_Base = new BaseControls.Panels.MyPanel();
            this.nud_IMAGE_INDEX = new System.Windows.Forms.NumericUpDown();
            this.cmb_CLINIC_OFFICE_CODE = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_COMMENT = new BaseControls.MyTextBox();
            this.txt_IMAGE_NAME = new BaseControls.MyTextBox();
            this.txt_VISC_NAME = new BaseControls.MyTextBox();
            this.txt_DESC_NAME = new BaseControls.MyTextBox();
            this.label6 = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label7 = new BaseControls.MyLabel();
            this.label5 = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.ofd_SelPicture = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_SelPic = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.myPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KnowledgeBase)).BeginInit();
            this.myPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).BeginInit();
            this.pl_Base.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IMAGE_INDEX)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.dgv_KnowledgeBase);
            this.myPanel1.Controls.Add(this.cmb_VISC_NAME);
            this.myPanel1.Controls.Add(this.cmb_DESC_NAME);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Controls.Add(this.label4);
            this.myPanel1.Location = new System.Drawing.Point(12, 33);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(230, 545);
            this.myPanel1.TabIndex = 3;
            // 
            // dgv_KnowledgeBase
            // 
            this.dgv_KnowledgeBase.AllowUserToAddRows = false;
            this.dgv_KnowledgeBase.AllowUserToDeleteRows = false;
            this.dgv_KnowledgeBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_KnowledgeBase.BackgroundColor = System.Drawing.Color.White;
            this.dgv_KnowledgeBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_KnowledgeBase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_KnowledgeBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KnowledgeBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IMAGE_NAME,
            this.IMAGE_INDEX,
            this.IMAGE_DATA,
            this.IMAGE_COMMENT,
            this.CLINIC_OFFICE_CODE});
            this.dgv_KnowledgeBase.DefaultScaleWidth = 1280;
            this.dgv_KnowledgeBase.Location = new System.Drawing.Point(10, 63);
            this.dgv_KnowledgeBase.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_KnowledgeBase.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_KnowledgeBase.MergeColumnNames")));
            this.dgv_KnowledgeBase.Name = "dgv_KnowledgeBase";
            this.dgv_KnowledgeBase.ReadOnly = true;
            this.dgv_KnowledgeBase.RowHeadersWidth = 30;
            this.dgv_KnowledgeBase.RowTemplate.Height = 23;
            this.dgv_KnowledgeBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_KnowledgeBase.Size = new System.Drawing.Size(209, 468);
            this.dgv_KnowledgeBase.TabIndex = 36;
            this.dgv_KnowledgeBase.XmlFile = null;
            this.dgv_KnowledgeBase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KnowledgeBase_CellDoubleClick);
            // 
            // IMAGE_NAME
            // 
            this.IMAGE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IMAGE_NAME.DataPropertyName = "IMAGE_NAME";
            this.IMAGE_NAME.FillWeight = 20F;
            this.IMAGE_NAME.HeaderText = "影像名称";
            this.IMAGE_NAME.Name = "IMAGE_NAME";
            this.IMAGE_NAME.ReadOnly = true;
            // 
            // IMAGE_INDEX
            // 
            this.IMAGE_INDEX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IMAGE_INDEX.DataPropertyName = "IMAGE_INDEX";
            this.IMAGE_INDEX.FillWeight = 10F;
            this.IMAGE_INDEX.HeaderText = "排序";
            this.IMAGE_INDEX.Name = "IMAGE_INDEX";
            this.IMAGE_INDEX.ReadOnly = true;
            // 
            // IMAGE_DATA
            // 
            this.IMAGE_DATA.DataPropertyName = "IMAGE_DATA";
            this.IMAGE_DATA.HeaderText = "影像数据";
            this.IMAGE_DATA.MaxInputLength = 999999999;
            this.IMAGE_DATA.Name = "IMAGE_DATA";
            this.IMAGE_DATA.ReadOnly = true;
            this.IMAGE_DATA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IMAGE_DATA.Visible = false;
            // 
            // IMAGE_COMMENT
            // 
            this.IMAGE_COMMENT.DataPropertyName = "IMAGE_COMMENT";
            this.IMAGE_COMMENT.HeaderText = "备注";
            this.IMAGE_COMMENT.Name = "IMAGE_COMMENT";
            this.IMAGE_COMMENT.ReadOnly = true;
            this.IMAGE_COMMENT.Visible = false;
            // 
            // CLINIC_OFFICE_CODE
            // 
            this.CLINIC_OFFICE_CODE.DataPropertyName = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE_CODE.HeaderText = "科室代码";
            this.CLINIC_OFFICE_CODE.Name = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE_CODE.ReadOnly = true;
            this.CLINIC_OFFICE_CODE.Visible = false;
            // 
            // cmb_VISC_NAME
            // 
            this.cmb_VISC_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VISC_NAME.FormattingEnabled = true;
            this.cmb_VISC_NAME.Location = new System.Drawing.Point(55, 9);
            this.cmb_VISC_NAME.Name = "cmb_VISC_NAME";
            this.cmb_VISC_NAME.Size = new System.Drawing.Size(151, 20);
            this.cmb_VISC_NAME.TabIndex = 35;
            this.cmb_VISC_NAME.SelectedIndexChanged += new System.EventHandler(this.cmb_VISC_NAME_SelectedIndexChanged);
            // 
            // cmb_DESC_NAME
            // 
            this.cmb_DESC_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DESC_NAME.FormattingEnabled = true;
            this.cmb_DESC_NAME.Location = new System.Drawing.Point(55, 37);
            this.cmb_DESC_NAME.Name = "cmb_DESC_NAME";
            this.cmb_DESC_NAME.Size = new System.Drawing.Size(151, 20);
            this.cmb_DESC_NAME.TabIndex = 34;
            this.cmb_DESC_NAME.SelectedIndexChanged += new System.EventHandler(this.cmb_DESC_NAME_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "病种：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "脏器：";
            // 
            // myPanel2
            // 
            this.myPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel2.BorderColor = System.Drawing.Color.Silver;
            this.myPanel2.Controls.Add(this.pb_Image);
            this.myPanel2.Location = new System.Drawing.Point(248, 173);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Size = new System.Drawing.Size(552, 405);
            this.myPanel2.TabIndex = 3;
            // 
            // pb_Image
            // 
            this.pb_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Image.Location = new System.Drawing.Point(3, 3);
            this.pb_Image.Name = "pb_Image";
            this.pb_Image.Size = new System.Drawing.Size(546, 399);
            this.pb_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Image.TabIndex = 0;
            this.pb_Image.TabStop = false;
            // 
            // pl_Base
            // 
            this.pl_Base.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_Base.BorderColor = System.Drawing.Color.Silver;
            this.pl_Base.Controls.Add(this.nud_IMAGE_INDEX);
            this.pl_Base.Controls.Add(this.cmb_CLINIC_OFFICE_CODE);
            this.pl_Base.Controls.Add(this.txt_COMMENT);
            this.pl_Base.Controls.Add(this.txt_IMAGE_NAME);
            this.pl_Base.Controls.Add(this.txt_VISC_NAME);
            this.pl_Base.Controls.Add(this.txt_DESC_NAME);
            this.pl_Base.Controls.Add(this.label6);
            this.pl_Base.Controls.Add(this.label8);
            this.pl_Base.Controls.Add(this.label2);
            this.pl_Base.Controls.Add(this.label7);
            this.pl_Base.Controls.Add(this.label5);
            this.pl_Base.Controls.Add(this.label1);
            this.pl_Base.Location = new System.Drawing.Point(248, 33);
            this.pl_Base.Name = "pl_Base";
            this.pl_Base.Size = new System.Drawing.Size(552, 132);
            this.pl_Base.TabIndex = 3;
            // 
            // nud_IMAGE_INDEX
            // 
            this.nud_IMAGE_INDEX.Location = new System.Drawing.Point(495, 8);
            this.nud_IMAGE_INDEX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud_IMAGE_INDEX.Name = "nud_IMAGE_INDEX";
            this.nud_IMAGE_INDEX.Size = new System.Drawing.Size(44, 21);
            this.nud_IMAGE_INDEX.TabIndex = 38;
            // 
            // cmb_CLINIC_OFFICE_CODE
            // 
            this.cmb_CLINIC_OFFICE_CODE.FormattingEnabled = true;
            this.cmb_CLINIC_OFFICE_CODE.Location = new System.Drawing.Point(281, 37);
            this.cmb_CLINIC_OFFICE_CODE.Name = "cmb_CLINIC_OFFICE_CODE";
            this.cmb_CLINIC_OFFICE_CODE.Size = new System.Drawing.Size(165, 20);
            this.cmb_CLINIC_OFFICE_CODE.TabIndex = 37;
            // 
            // txt_COMMENT
            // 
            this.txt_COMMENT.Location = new System.Drawing.Point(84, 65);
            this.txt_COMMENT.Multiline = true;
            this.txt_COMMENT.Name = "txt_COMMENT";
            this.txt_COMMENT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_COMMENT.Size = new System.Drawing.Size(455, 59);
            this.txt_COMMENT.TabIndex = 36;
            // 
            // txt_IMAGE_NAME
            // 
            this.txt_IMAGE_NAME.Location = new System.Drawing.Point(84, 37);
            this.txt_IMAGE_NAME.Name = "txt_IMAGE_NAME";
            this.txt_IMAGE_NAME.Size = new System.Drawing.Size(144, 21);
            this.txt_IMAGE_NAME.TabIndex = 36;
            // 
            // txt_VISC_NAME
            // 
            this.txt_VISC_NAME.Location = new System.Drawing.Point(84, 8);
            this.txt_VISC_NAME.Name = "txt_VISC_NAME";
            this.txt_VISC_NAME.Size = new System.Drawing.Size(144, 21);
            this.txt_VISC_NAME.TabIndex = 36;
            // 
            // txt_DESC_NAME
            // 
            this.txt_DESC_NAME.Location = new System.Drawing.Point(281, 8);
            this.txt_DESC_NAME.Name = "txt_DESC_NAME";
            this.txt_DESC_NAME.Size = new System.Drawing.Size(165, 21);
            this.txt_DESC_NAME.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "排序：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "科室：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "病种：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "备注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "影像名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "脏器：";
            // 
            // ofd_SelPicture
            // 
            this.ofd_SelPicture.FileName = "openFileDialog1";
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_SelPic, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Del, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
            this.tableLayoutPanel1.TabIndex = 28;
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
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(155, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_SelPic
            // 
            this.btn_SelPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SelPic.FlatAppearance.BorderSize = 0;
            this.btn_SelPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelPic.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_SelPic.Location = new System.Drawing.Point(357, 4);
            this.btn_SelPic.Name = "btn_SelPic";
            this.btn_SelPic.Size = new System.Drawing.Size(94, 19);
            this.btn_SelPic.TabIndex = 0;
            this.btn_SelPic.Text = "选择图片";
            this.btn_SelPic.UseVisualStyleBackColor = true;
            this.btn_SelPic.Click += new System.EventHandler(this.btn_SelPic_Click);
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
            this.btn_Clean.TabIndex = 7;
            this.btn_Clean.Text = "清空";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Del.FlatAppearance.BorderSize = 0;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Del.Location = new System.Drawing.Point(458, 4);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(94, 19);
            this.btn_Del.TabIndex = 8;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // KnowledgeBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 590);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.pl_Base);
            this.Controls.Add(this.myPanel2);
            this.Name = "KnowledgeBase";
            this.Text = "知识库表";
            this.VisibleChanged += new System.EventHandler(this.KnowledgeBase_VisibleChanged);
            this.Load += new System.EventHandler(this.KnowledgeBase_Load);
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KnowledgeBase)).EndInit();
            this.myPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).EndInit();
            this.pl_Base.ResumeLayout(false);
            this.pl_Base.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IMAGE_INDEX)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyDataGridView dgv_KnowledgeBase;
        private BaseControls.ComboBoxs.MyComboBox cmb_VISC_NAME;
        private BaseControls.ComboBoxs.MyComboBox cmb_DESC_NAME;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label4;
        private BaseControls.Panels.MyPanel myPanel2;
        private BaseControls.Panels.MyPanel pl_Base;
        private BaseControls.MyLabel label6;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label7;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel label1;
        private BaseControls.ComboBoxs.MyComboBox cmb_CLINIC_OFFICE_CODE;
        private BaseControls.MyTextBox txt_COMMENT;
        private BaseControls.MyTextBox txt_IMAGE_NAME;
        private BaseControls.MyTextBox txt_VISC_NAME;
        private BaseControls.MyTextBox txt_DESC_NAME;
        private BaseControls.MyLabel label8;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.Button btn_SelPic;
        public System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.NumericUpDown nud_IMAGE_INDEX;
        private System.Windows.Forms.PictureBox pb_Image;
        public System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.OpenFileDialog ofd_SelPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGE_INDEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGE_DATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGE_COMMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_OFFICE_CODE;
        public System.Windows.Forms.Button btn_Del;


    }
}