namespace SIS
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            BaseControls.Docking.DockPanelSkin dockPanelSkin1 = new BaseControls.Docking.DockPanelSkin();
            BaseControls.Docking.AutoHideStripSkin autoHideStripSkin1 = new BaseControls.Docking.AutoHideStripSkin();
            BaseControls.Docking.DockPanelGradient dockPanelGradient1 = new BaseControls.Docking.DockPanelGradient();
            BaseControls.Docking.TabGradient tabGradient1 = new BaseControls.Docking.TabGradient();
            BaseControls.Docking.DockPaneStripSkin dockPaneStripSkin1 = new BaseControls.Docking.DockPaneStripSkin();
            BaseControls.Docking.DockPaneStripGradient dockPaneStripGradient1 = new BaseControls.Docking.DockPaneStripGradient();
            BaseControls.Docking.TabGradient tabGradient2 = new BaseControls.Docking.TabGradient();
            BaseControls.Docking.DockPanelGradient dockPanelGradient2 = new BaseControls.Docking.DockPanelGradient();
            BaseControls.Docking.TabGradient tabGradient3 = new BaseControls.Docking.TabGradient();
            BaseControls.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new BaseControls.Docking.DockPaneStripToolWindowGradient();
            BaseControls.Docking.TabGradient tabGradient4 = new BaseControls.Docking.TabGradient();
            BaseControls.Docking.TabGradient tabGradient5 = new BaseControls.Docking.TabGradient();
            BaseControls.Docking.DockPanelGradient dockPanelGradient3 = new BaseControls.Docking.DockPanelGradient();
            BaseControls.Docking.TabGradient tabGradient6 = new BaseControls.Docking.TabGradient();
            BaseControls.Docking.TabGradient tabGradient7 = new BaseControls.Docking.TabGradient();
            this.panTopLine = new System.Windows.Forms.Panel();
            this.p_Patient = new System.Windows.Forms.Panel();
            this.l_PatientId = new BaseControls.MyLabel();
            this.l_ExamAccessionNum = new BaseControls.MyLabel();
            this.l_PatientSex = new BaseControls.MyLabel();
            this.l_PatientName = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.label5 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Settings = new BaseControls.Buttons.VistaButton();
            this.btn_Exit = new BaseControls.Buttons.VistaButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Logout = new BaseControls.Buttons.VistaButton();
            this.btn_Lock = new BaseControls.Buttons.VistaButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_SystemName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_User = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Dept = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanel = new BaseControls.Docking.DockPanel();
            this.p_Sub = new System.Windows.Forms.Panel();
            this.timer_Main = new System.Windows.Forms.Timer(this.components);
            this.timer_Lock = new System.Windows.Forms.Timer(this.components);
            this.timer_Close = new System.Windows.Forms.Timer(this.components);
            this.panTopLine.SuspendLayout();
            this.p_Patient.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.dockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTopLine
            // 
            this.panTopLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panTopLine.BackgroundImage")));
            this.panTopLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTopLine.Controls.Add(this.p_Patient);
            this.panTopLine.Controls.Add(this.panel2);
            this.panTopLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopLine.Location = new System.Drawing.Point(0, 0);
            this.panTopLine.Name = "panTopLine";
            this.panTopLine.Size = new System.Drawing.Size(1020, 43);
            this.panTopLine.TabIndex = 1;
            // 
            // p_Patient
            // 
            this.p_Patient.BackColor = System.Drawing.Color.Transparent;
            this.p_Patient.Controls.Add(this.l_PatientId);
            this.p_Patient.Controls.Add(this.l_ExamAccessionNum);
            this.p_Patient.Controls.Add(this.l_PatientSex);
            this.p_Patient.Controls.Add(this.l_PatientName);
            this.p_Patient.Controls.Add(this.label1);
            this.p_Patient.Controls.Add(this.label5);
            this.p_Patient.Controls.Add(this.label2);
            this.p_Patient.Controls.Add(this.label3);
            this.p_Patient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Patient.Location = new System.Drawing.Point(0, 0);
            this.p_Patient.Name = "p_Patient";
            this.p_Patient.Size = new System.Drawing.Size(669, 41);
            this.p_Patient.TabIndex = 2;
            // 
            // l_PatientId
            // 
            this.l_PatientId.AutoSize = true;
            this.l_PatientId.BackColor = System.Drawing.Color.Transparent;
            this.l_PatientId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PatientId.ForeColor = System.Drawing.Color.Cyan;
            this.l_PatientId.Location = new System.Drawing.Point(133, 16);
            this.l_PatientId.Name = "l_PatientId";
            this.l_PatientId.Size = new System.Drawing.Size(23, 14);
            this.l_PatientId.TabIndex = 3;
            this.l_PatientId.Text = "ID";
            // 
            // l_ExamAccessionNum
            // 
            this.l_ExamAccessionNum.AutoSize = true;
            this.l_ExamAccessionNum.BackColor = System.Drawing.Color.Transparent;
            this.l_ExamAccessionNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ExamAccessionNum.ForeColor = System.Drawing.Color.Cyan;
            this.l_ExamAccessionNum.Location = new System.Drawing.Point(509, 16);
            this.l_ExamAccessionNum.Name = "l_ExamAccessionNum";
            this.l_ExamAccessionNum.Size = new System.Drawing.Size(71, 14);
            this.l_ExamAccessionNum.TabIndex = 9;
            this.l_ExamAccessionNum.Text = "RY345443";
            // 
            // l_PatientSex
            // 
            this.l_PatientSex.AutoSize = true;
            this.l_PatientSex.BackColor = System.Drawing.Color.Transparent;
            this.l_PatientSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PatientSex.ForeColor = System.Drawing.Color.Cyan;
            this.l_PatientSex.Location = new System.Drawing.Point(389, 16);
            this.l_PatientSex.Name = "l_PatientSex";
            this.l_PatientSex.Size = new System.Drawing.Size(22, 14);
            this.l_PatientSex.TabIndex = 7;
            this.l_PatientSex.Text = "男";
            // 
            // l_PatientName
            // 
            this.l_PatientName.AutoSize = true;
            this.l_PatientName.BackColor = System.Drawing.Color.Transparent;
            this.l_PatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PatientName.ForeColor = System.Drawing.Color.Cyan;
            this.l_PatientName.Location = new System.Drawing.Point(270, 16);
            this.l_PatientName.Name = "l_PatientName";
            this.l_PatientName.Size = new System.Drawing.Size(37, 14);
            this.l_PatientName.TabIndex = 5;
            this.l_PatientName.Text = "姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(73, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "病人ID：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(438, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "检查序号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(229, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(346, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "性别：";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btn_Settings);
            this.panel2.Controls.Add(this.btn_Exit);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btn_Logout);
            this.panel2.Controls.Add(this.btn_Lock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(669, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 41);
            this.panel2.TabIndex = 1;
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Settings.BackColor = System.Drawing.Color.Transparent;
            this.btn_Settings.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Settings.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Settings.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Settings.ButtonText = "设置";
            this.btn_Settings.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Settings.ForeColor = System.Drawing.Color.Black;
            this.btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_Settings.Image")));
            this.btn_Settings.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Settings.Location = new System.Drawing.Point(24, 3);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(71, 39);
            this.btn_Settings.TabIndex = 5;
            this.btn_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Exit.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Exit.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Exit.ButtonText = "退出";
            this.btn_Exit.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.ForeColor = System.Drawing.Color.Black;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Exit.Location = new System.Drawing.Point(267, 3);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(71, 39);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(257, 13);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 15);
            this.panel3.TabIndex = 4;
            // 
            // btn_Logout
            // 
            this.btn_Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_Logout.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Logout.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Logout.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Logout.ButtonText = "注销";
            this.btn_Logout.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Logout.ForeColor = System.Drawing.Color.Black;
            this.btn_Logout.Image = ((System.Drawing.Image)(resources.GetObject("btn_Logout.Image")));
            this.btn_Logout.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Logout.Location = new System.Drawing.Point(178, 3);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(71, 39);
            this.btn_Logout.TabIndex = 3;
            this.btn_Logout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // btn_Lock
            // 
            this.btn_Lock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Lock.BackColor = System.Drawing.Color.Transparent;
            this.btn_Lock.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Lock.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Lock.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Lock.ButtonText = "锁定";
            this.btn_Lock.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Lock.ForeColor = System.Drawing.Color.Black;
            this.btn_Lock.Image = ((System.Drawing.Image)(resources.GetObject("btn_Lock.Image")));
            this.btn_Lock.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Lock.Location = new System.Drawing.Point(101, 3);
            this.btn_Lock.Name = "btn_Lock";
            this.btn_Lock.Size = new System.Drawing.Size(71, 39);
            this.btn_Lock.TabIndex = 2;
            this.btn_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Lock.Click += new System.EventHandler(this.btn_Lock_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_SystemName,
            this.tssl_Version,
            this.tssl_User,
            this.tssl_Dept,
            this.tssl_Time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 724);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_SystemName
            // 
            this.tssl_SystemName.AutoSize = false;
            this.tssl_SystemName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tssl_SystemName.Name = "tssl_SystemName";
            this.tssl_SystemName.Size = new System.Drawing.Size(300, 17);
            this.tssl_SystemName.Text = "广州宜诚影像信息系统";
            // 
            // tssl_Version
            // 
            this.tssl_Version.AutoSize = false;
            this.tssl_Version.Name = "tssl_Version";
            this.tssl_Version.Size = new System.Drawing.Size(150, 17);
            this.tssl_Version.Text = "v 1.0.0";
            // 
            // tssl_User
            // 
            this.tssl_User.AutoSize = false;
            this.tssl_User.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tssl_User.Image = ((System.Drawing.Image)(resources.GetObject("tssl_User.Image")));
            this.tssl_User.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssl_User.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssl_User.Name = "tssl_User";
            this.tssl_User.Size = new System.Drawing.Size(150, 17);
            this.tssl_User.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // tssl_Dept
            // 
            this.tssl_Dept.AutoSize = false;
            this.tssl_Dept.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tssl_Dept.Image = ((System.Drawing.Image)(resources.GetObject("tssl_Dept.Image")));
            this.tssl_Dept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssl_Dept.Name = "tssl_Dept";
            this.tssl_Dept.Size = new System.Drawing.Size(150, 17);
            this.tssl_Dept.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // tssl_Time
            // 
            this.tssl_Time.AutoSize = false;
            this.tssl_Time.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tssl_Time.Name = "tssl_Time";
            this.tssl_Time.Size = new System.Drawing.Size(255, 17);
            this.tssl_Time.Spring = true;
            this.tssl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.Controls.Add(this.p_Sub);
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel.DockLeftPortion = 0.16;
            this.dockPanel.DockRightPortion = 0.16;
            this.dockPanel.Location = new System.Drawing.Point(0, 43);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1020, 681);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel.Skin = dockPanelSkin1;
            this.dockPanel.TabIndex = 6;
            // 
            // p_Sub
            // 
            this.p_Sub.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p_Sub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Sub.Location = new System.Drawing.Point(0, 0);
            this.p_Sub.Name = "p_Sub";
            this.p_Sub.Size = new System.Drawing.Size(1020, 681);
            this.p_Sub.TabIndex = 5;
            // 
            // timer_Main
            // 
            this.timer_Main.Interval = 1000;
            this.timer_Main.Tick += new System.EventHandler(this.timer_Main_Tick);
            // 
            // timer_Lock
            // 
            this.timer_Lock.Interval = 1000;
            // 
            // timer_Close
            // 
            this.timer_Close.Interval = 1000;
            this.timer_Close.Tick += new System.EventHandler(this.timer_Close_Tick);
            // 
            // frmMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1020, 746);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.panTopLine);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainForm";
            this.Text = "宜诚影像信息管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmMainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panTopLine.ResumeLayout(false);
            this.p_Patient.ResumeLayout(false);
            this.p_Patient.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.dockPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTopLine;
        internal System.Windows.Forms.Panel p_Sub;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private BaseControls.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripStatusLabel tssl_User;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Dept;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Version;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Time;
        private BaseControls.Buttons.VistaButton btn_Lock;
        private BaseControls.Buttons.VistaButton btn_Exit;
        private BaseControls.Buttons.VistaButton btn_Logout;
        private BaseControls.MyLabel l_ExamAccessionNum;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel l_PatientSex;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel l_PatientName;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel l_PatientId;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_SystemName;
        private System.Windows.Forms.Panel p_Patient;
        private System.Windows.Forms.Timer timer_Main;
        private System.Windows.Forms.Timer timer_Lock;
        private BaseControls.Buttons.VistaButton btn_Settings;
        private System.Windows.Forms.Timer timer_Close;
    }
}

