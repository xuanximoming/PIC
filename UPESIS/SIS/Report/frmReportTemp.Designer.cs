namespace SIS
{
    partial class frmReportTemp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportTemp));
            this.p_Content = new System.Windows.Forms.Panel();
            this.tree_Template = new BaseControls.MyTreeView();
            this.cms_Template = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_li = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Add_Equ = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Add_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ImportRptTem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_PasteEqu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_PasteNext = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter = new System.Windows.Forms.Splitter();
            this.p_Edit = new System.Windows.Forms.Panel();
            this.cmb_NodeSign = new BaseControls.ComboBoxs.MyComboBox();
            this.label4 = new BaseControls.MyLabel();
            this.txt_SortFlag = new BaseControls.NumberText();
            this.btn_Exit = new BaseControls.Buttons.VistaButton();
            this.txt_NodeName = new BaseControls.MyTextBox();
            this.label2 = new BaseControls.MyLabel();
            this.txt_InputCode = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.cmb_IsPrivate = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_Icdcode = new BaseControls.MyTextBox();
            this.label9 = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.label10 = new BaseControls.MyLabel();
            this.btn_Save = new BaseControls.Buttons.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_Part = new BaseControls.ComboBoxs.MyComboBox();
            this.myLabel1 = new BaseControls.MyLabel();
            this.cms_Template.SuspendLayout();
            this.p_Edit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Content
            // 
            this.p_Content.AutoScroll = true;
            this.p_Content.BackColor = System.Drawing.SystemColors.Window;
            this.p_Content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Content.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Content.Location = new System.Drawing.Point(0, 419);
            this.p_Content.Name = "p_Content";
            this.p_Content.Size = new System.Drawing.Size(265, 163);
            this.p_Content.TabIndex = 10;
            // 
            // tree_Template
            // 
            this.tree_Template.ContextMenuStrip = this.cms_Template;
            this.tree_Template.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_Template.Font = new System.Drawing.Font("宋体", 9F);
            this.tree_Template.ForeColor = System.Drawing.Color.Black;
            this.tree_Template.HideSelection = false;
            this.tree_Template.Location = new System.Drawing.Point(0, 41);
            this.tree_Template.Name = "tree_Template";
            this.tree_Template.Size = new System.Drawing.Size(265, 375);
            this.tree_Template.TabIndex = 11;
            this.tree_Template.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tree_Template_MouseDoubleClick);
            this.tree_Template.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_Template_AfterSelect);
            this.tree_Template.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_Template_MouseDown);
            // 
            // cms_Template
            // 
            this.cms_Template.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_li,
            this.tsmi_Refresh,
            this.toolStripSeparator3,
            this.tsmi_Add,
            this.tsmi_Edit,
            this.tsmi_ImportRptTem,
            this.toolStripSeparator1,
            this.tsmi_Delete,
            this.toolStripSeparator2,
            this.tsmi_Copy,
            this.tsmi_Paste});
            this.cms_Template.Name = "cms_TEMPLATE_DICT";
            this.cms_Template.Size = new System.Drawing.Size(119, 198);
            // 
            // tsmi_li
            // 
            this.tsmi_li.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_li.Image")));
            this.tsmi_li.Name = "tsmi_li";
            this.tsmi_li.Size = new System.Drawing.Size(118, 22);
            this.tsmi_li.Text = "收缩";
            this.tsmi_li.Click += new System.EventHandler(this.tsmi_li_Click);
            // 
            // tsmi_Refresh
            // 
            this.tsmi_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Refresh.Image")));
            this.tsmi_Refresh.Name = "tsmi_Refresh";
            this.tsmi_Refresh.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Refresh.Text = "刷新";
            this.tsmi_Refresh.Click += new System.EventHandler(this.tsmi_Refresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(115, 6);
            // 
            // tsmi_Add
            // 
            this.tsmi_Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Add_Equ,
            this.tsmi_Add_Next});
            this.tsmi_Add.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Add.Image")));
            this.tsmi_Add.Name = "tsmi_Add";
            this.tsmi_Add.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Add.Text = "新增";
            // 
            // tsmi_Add_Equ
            // 
            this.tsmi_Add_Equ.Name = "tsmi_Add_Equ";
            this.tsmi_Add_Equ.Size = new System.Drawing.Size(94, 22);
            this.tsmi_Add_Equ.Text = "同级";
            // 
            // tsmi_Add_Next
            // 
            this.tsmi_Add_Next.Name = "tsmi_Add_Next";
            this.tsmi_Add_Next.Size = new System.Drawing.Size(94, 22);
            this.tsmi_Add_Next.Text = "下级";
            // 
            // tsmi_Edit
            // 
            this.tsmi_Edit.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Edit.Image")));
            this.tsmi_Edit.Name = "tsmi_Edit";
            this.tsmi_Edit.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Edit.Text = "修改";
            this.tsmi_Edit.Click += new System.EventHandler(this.tsmi_Edit_Click);
            // 
            // tsmi_ImportRptTem
            // 
            this.tsmi_ImportRptTem.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ImportRptTem.Image")));
            this.tsmi_ImportRptTem.Name = "tsmi_ImportRptTem";
            this.tsmi_ImportRptTem.Size = new System.Drawing.Size(118, 22);
            this.tsmi_ImportRptTem.Text = "加至模板";
            this.tsmi_ImportRptTem.Click += new System.EventHandler(this.tsmi_ImportRptTem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // tsmi_Delete
            // 
            this.tsmi_Delete.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Delete.Image")));
            this.tsmi_Delete.Name = "tsmi_Delete";
            this.tsmi_Delete.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Delete.Text = "删除";
            this.tsmi_Delete.Click += new System.EventHandler(this.tsmi_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // tsmi_Copy
            // 
            this.tsmi_Copy.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Copy.Image")));
            this.tsmi_Copy.Name = "tsmi_Copy";
            this.tsmi_Copy.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Copy.Text = "复制";
            this.tsmi_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
            // 
            // tsmi_Paste
            // 
            this.tsmi_Paste.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_PasteEqu,
            this.tsmi_PasteNext});
            this.tsmi_Paste.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Paste.Image")));
            this.tsmi_Paste.Name = "tsmi_Paste";
            this.tsmi_Paste.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Paste.Text = "粘贴到";
            // 
            // tsmi_PasteEqu
            // 
            this.tsmi_PasteEqu.Name = "tsmi_PasteEqu";
            this.tsmi_PasteEqu.Size = new System.Drawing.Size(94, 22);
            this.tsmi_PasteEqu.Text = "同级";
            this.tsmi_PasteEqu.Click += new System.EventHandler(this.tsmi_PasteEqu_Click);
            // 
            // tsmi_PasteNext
            // 
            this.tsmi_PasteNext.Name = "tsmi_PasteNext";
            this.tsmi_PasteNext.Size = new System.Drawing.Size(94, 22);
            this.tsmi_PasteNext.Text = "下级";
            this.tsmi_PasteNext.Click += new System.EventHandler(this.tsmi_PasteNext_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Send.ico");
            // 
            // splitter
            // 
            this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.Location = new System.Drawing.Point(0, 416);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(265, 3);
            this.splitter.TabIndex = 12;
            this.splitter.TabStop = false;
            // 
            // p_Edit
            // 
            this.p_Edit.AutoScroll = true;
            this.p_Edit.Controls.Add(this.cmb_NodeSign);
            this.p_Edit.Controls.Add(this.label4);
            this.p_Edit.Controls.Add(this.txt_SortFlag);
            this.p_Edit.Controls.Add(this.btn_Exit);
            this.p_Edit.Controls.Add(this.txt_NodeName);
            this.p_Edit.Controls.Add(this.label2);
            this.p_Edit.Controls.Add(this.txt_InputCode);
            this.p_Edit.Controls.Add(this.label1);
            this.p_Edit.Controls.Add(this.cmb_IsPrivate);
            this.p_Edit.Controls.Add(this.txt_Icdcode);
            this.p_Edit.Controls.Add(this.label9);
            this.p_Edit.Controls.Add(this.label8);
            this.p_Edit.Controls.Add(this.label10);
            this.p_Edit.Controls.Add(this.btn_Save);
            this.p_Edit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Edit.Location = new System.Drawing.Point(0, 582);
            this.p_Edit.Name = "p_Edit";
            this.p_Edit.Size = new System.Drawing.Size(265, 164);
            this.p_Edit.TabIndex = 0;
            this.p_Edit.Visible = false;
            // 
            // cmb_NodeSign
            // 
            this.cmb_NodeSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NodeSign.FormattingEnabled = true;
            this.cmb_NodeSign.Location = new System.Drawing.Point(77, 37);
            this.cmb_NodeSign.Name = "cmb_NodeSign";
            this.cmb_NodeSign.Size = new System.Drawing.Size(172, 20);
            this.cmb_NodeSign.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "结点标志：";
            // 
            // txt_SortFlag
            // 
            this.txt_SortFlag.Location = new System.Drawing.Point(200, 93);
            this.txt_SortFlag.Name = "txt_SortFlag";
            this.txt_SortFlag.NumberCount = 3;
            this.txt_SortFlag.Size = new System.Drawing.Size(49, 21);
            this.txt_SortFlag.TabIndex = 24;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Exit.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Exit.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Exit.ButtonText = "退出";
            this.btn_Exit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Exit.Location = new System.Drawing.Point(136, 122);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(67, 32);
            this.btn_Exit.TabIndex = 23;
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // txt_NodeName
            // 
            this.txt_NodeName.Location = new System.Drawing.Point(77, 10);
            this.txt_NodeName.Name = "txt_NodeName";
            this.txt_NodeName.Size = new System.Drawing.Size(172, 21);
            this.txt_NodeName.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "结点名称：";
            // 
            // txt_InputCode
            // 
            this.txt_InputCode.Location = new System.Drawing.Point(77, 93);
            this.txt_InputCode.Name = "txt_InputCode";
            this.txt_InputCode.Size = new System.Drawing.Size(66, 21);
            this.txt_InputCode.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "简写：";
            // 
            // cmb_IsPrivate
            // 
            this.cmb_IsPrivate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IsPrivate.FormattingEnabled = true;
            this.cmb_IsPrivate.Items.AddRange(new object[] {
            "公有",
            "私有"});
            this.cmb_IsPrivate.Location = new System.Drawing.Point(200, 66);
            this.cmb_IsPrivate.Name = "cmb_IsPrivate";
            this.cmb_IsPrivate.Size = new System.Drawing.Size(49, 20);
            this.cmb_IsPrivate.TabIndex = 15;
            // 
            // txt_Icdcode
            // 
            this.txt_Icdcode.Location = new System.Drawing.Point(77, 65);
            this.txt_Icdcode.Name = "txt_Icdcode";
            this.txt_Icdcode.Size = new System.Drawing.Size(66, 21);
            this.txt_Icdcode.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(150, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "排序号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(162, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "私有：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "疾病分类码：";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Save.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Save.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Save.ButtonText = "保存";
            this.btn_Save.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Save.Location = new System.Drawing.Point(45, 122);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(67, 32);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_Part);
            this.panel1.Controls.Add(this.myLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 41);
            this.panel1.TabIndex = 13;
            // 
            // cmb_Part
            // 
            this.cmb_Part.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Part.FormattingEnabled = true;
            this.cmb_Part.Location = new System.Drawing.Point(47, 12);
            this.cmb_Part.MaxDropDownItems = 20;
            this.cmb_Part.Name = "cmb_Part";
            this.cmb_Part.Size = new System.Drawing.Size(96, 20);
            this.cmb_Part.TabIndex = 28;
            this.cmb_Part.SelectedIndexChanged += new System.EventHandler(this.cmb_Part_SelectedIndexChanged);
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel1.ForeColor = System.Drawing.Color.Black;
            this.myLabel1.Location = new System.Drawing.Point(12, 15);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Size = new System.Drawing.Size(29, 12);
            this.myLabel1.TabIndex = 27;
            this.myLabel1.Text = "脏器";
            // 
            // frmReportTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 746);
            this.CloseButton = false;
            this.Controls.Add(this.tree_Template);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.p_Content);
            this.Controls.Add(this.p_Edit);
            this.DockAreas = ((BaseControls.Docking.DockAreas)((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportTemp";
            this.Text = "报告模板";
            this.Load += new System.EventHandler(this.frmReportTemp_Load);
            this.cms_Template.ResumeLayout(false);
            this.p_Edit.ResumeLayout(false);
            this.p_Edit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Content;
        private BaseControls.MyTreeView tree_Template;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel p_Edit;
        private BaseControls.Buttons.VistaButton btn_Save;
        private BaseControls.MyTextBox txt_InputCode;
        private BaseControls.MyLabel label1;
        private BaseControls.ComboBoxs.MyComboBox cmb_IsPrivate;
        private BaseControls.MyTextBox txt_Icdcode;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel label8;
        private BaseControls.MyLabel label10;
        private BaseControls.MyTextBox txt_NodeName;
        private BaseControls.MyLabel label2;
        private BaseControls.Buttons.VistaButton btn_Exit;
        private System.Windows.Forms.ContextMenuStrip cms_Template;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Add;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Add_Equ;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Add_Next;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_li;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Edit;
        private BaseControls.NumberText txt_SortFlag;
        private BaseControls.ComboBoxs.MyComboBox cmb_NodeSign;
        private BaseControls.MyLabel label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Paste;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PasteEqu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PasteNext;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ImportRptTem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Refresh;
        private System.Windows.Forms.Panel panel1;
        private BaseControls.ComboBoxs.MyComboBox cmb_Part;
        private BaseControls.MyLabel myLabel1;
    }
}