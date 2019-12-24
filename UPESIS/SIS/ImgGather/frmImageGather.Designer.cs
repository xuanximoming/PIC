namespace SIS
{
    partial class frmImageGather
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageGather));
            this.dockPanel = new BaseControls.Docking.DockPanel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.ptb_View = new System.Windows.Forms.PictureBox();
            this.ptb_Gather = new System.Windows.Forms.PictureBox();
            this.axMSComm1 = new AxMSCommLib.AxMSComm();
            this.p_Buttons = new System.Windows.Forms.Panel();
            this.btn_ShowView = new BaseControls.Buttons.VistaButton();
            this.btn_CardSetting = new BaseControls.Buttons.VistaButton();
            this.btn_DinamicCatch = new BaseControls.Buttons.VistaButton();
            this.btn_StaticCatch = new BaseControls.Buttons.VistaButton();
            this.rb_Back = new System.Windows.Forms.RadioButton();
            this.rb_Prefer = new System.Windows.Forms.RadioButton();
            this.btn_EditClincReport = new System.Windows.Forms.Button();
            this.btn_Set = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.dockPanel.SuspendLayout();
            this.p_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Gather)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMSComm1)).BeginInit();
            this.p_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.Controls.Add(this.p_Main);
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.Size = new System.Drawing.Size(1028, 678);
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
            this.dockPanel.TabIndex = 5;
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.ptb_View);
            this.p_Main.Controls.Add(this.ptb_Gather);
            this.p_Main.Controls.Add(this.axMSComm1);
            this.p_Main.Controls.Add(this.p_Buttons);
            this.p_Main.Location = new System.Drawing.Point(2, 4);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(845, 600);
            this.p_Main.TabIndex = 7;
            // 
            // ptb_View
            // 
            this.ptb_View.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ptb_View.BackColor = System.Drawing.Color.Black;
            this.ptb_View.Location = new System.Drawing.Point(11, 21);
            this.ptb_View.Name = "ptb_View";
            this.ptb_View.Size = new System.Drawing.Size(744, 561);
            this.ptb_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptb_View.TabIndex = 13;
            this.ptb_View.TabStop = false;
            this.ptb_View.Visible = false;
            // 
            // ptb_Gather
            // 
            this.ptb_Gather.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ptb_Gather.BackColor = System.Drawing.Color.Black;
            this.ptb_Gather.Location = new System.Drawing.Point(11, 19);
            this.ptb_Gather.Name = "ptb_Gather";
            this.ptb_Gather.Size = new System.Drawing.Size(744, 561);
            this.ptb_Gather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptb_Gather.TabIndex = 12;
            this.ptb_Gather.TabStop = false;
            // 
            // axMSComm1
            // 
            this.axMSComm1.Enabled = true;
            this.axMSComm1.Location = new System.Drawing.Point(2, 2);
            this.axMSComm1.Name = "axMSComm1";
            this.axMSComm1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMSComm1.OcxState")));
            this.axMSComm1.Size = new System.Drawing.Size(38, 38);
            this.axMSComm1.TabIndex = 7;
            // 
            // p_Buttons
            // 
            this.p_Buttons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Buttons.Controls.Add(this.btn_ShowView);
            this.p_Buttons.Controls.Add(this.btn_CardSetting);
            this.p_Buttons.Controls.Add(this.btn_DinamicCatch);
            this.p_Buttons.Controls.Add(this.btn_StaticCatch);
            this.p_Buttons.Controls.Add(this.rb_Back);
            this.p_Buttons.Controls.Add(this.rb_Prefer);
            this.p_Buttons.Controls.Add(this.btn_EditClincReport);
            this.p_Buttons.Controls.Add(this.btn_Set);
            this.p_Buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_Buttons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.p_Buttons.Location = new System.Drawing.Point(769, 0);
            this.p_Buttons.Name = "p_Buttons";
            this.p_Buttons.Size = new System.Drawing.Size(76, 600);
            this.p_Buttons.TabIndex = 5;
            // 
            // btn_ShowView
            // 
            this.btn_ShowView.BackColor = System.Drawing.Color.Transparent;
            this.btn_ShowView.BaseColor = System.Drawing.Color.Transparent;
            this.btn_ShowView.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_ShowView.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_ShowView.ButtonText = "实时显示";
            this.btn_ShowView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShowView.ForeColor = System.Drawing.Color.Indigo;
            this.btn_ShowView.Image = ((System.Drawing.Image)(resources.GetObject("btn_ShowView.Image")));
            this.btn_ShowView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ShowView.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_ShowView.Location = new System.Drawing.Point(-1, 148);
            this.btn_ShowView.Name = "btn_ShowView";
            this.btn_ShowView.Size = new System.Drawing.Size(75, 69);
            this.btn_ShowView.TabIndex = 8;
            this.btn_ShowView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ShowView.Click += new System.EventHandler(this.vtn_ShowView_Click);
            // 
            // btn_CardSetting
            // 
            this.btn_CardSetting.BackColor = System.Drawing.Color.Transparent;
            this.btn_CardSetting.BaseColor = System.Drawing.Color.Transparent;
            this.btn_CardSetting.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_CardSetting.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_CardSetting.ButtonText = "初始化卡";
            this.btn_CardSetting.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CardSetting.ForeColor = System.Drawing.Color.Indigo;
            this.btn_CardSetting.Image = ((System.Drawing.Image)(resources.GetObject("btn_CardSetting.Image")));
            this.btn_CardSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CardSetting.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_CardSetting.Location = new System.Drawing.Point(-1, 439);
            this.btn_CardSetting.Name = "btn_CardSetting";
            this.btn_CardSetting.Size = new System.Drawing.Size(75, 69);
            this.btn_CardSetting.TabIndex = 7;
            this.btn_CardSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CardSetting.Click += new System.EventHandler(this.btn_CardSetting_Click);
            // 
            // btn_DinamicCatch
            // 
            this.btn_DinamicCatch.BackColor = System.Drawing.Color.Transparent;
            this.btn_DinamicCatch.BaseColor = System.Drawing.Color.Transparent;
            this.btn_DinamicCatch.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_DinamicCatch.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_DinamicCatch.ButtonText = "动态采集";
            this.btn_DinamicCatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DinamicCatch.ForeColor = System.Drawing.Color.Indigo;
            this.btn_DinamicCatch.Image = ((System.Drawing.Image)(resources.GetObject("btn_DinamicCatch.Image")));
            this.btn_DinamicCatch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_DinamicCatch.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_DinamicCatch.Location = new System.Drawing.Point(-1, 342);
            this.btn_DinamicCatch.Name = "btn_DinamicCatch";
            this.btn_DinamicCatch.Size = new System.Drawing.Size(75, 69);
            this.btn_DinamicCatch.TabIndex = 6;
            this.btn_DinamicCatch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_DinamicCatch.Visible = false;
            this.btn_DinamicCatch.Click += new System.EventHandler(this.btn_DinamicCatch_Click);
            // 
            // btn_StaticCatch
            // 
            this.btn_StaticCatch.BackColor = System.Drawing.Color.Transparent;
            this.btn_StaticCatch.BaseColor = System.Drawing.Color.Transparent;
            this.btn_StaticCatch.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_StaticCatch.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_StaticCatch.ButtonText = "静态采集";
            this.btn_StaticCatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StaticCatch.ForeColor = System.Drawing.Color.Indigo;
            this.btn_StaticCatch.Image = ((System.Drawing.Image)(resources.GetObject("btn_StaticCatch.Image")));
            this.btn_StaticCatch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_StaticCatch.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_StaticCatch.Location = new System.Drawing.Point(-1, 245);
            this.btn_StaticCatch.Name = "btn_StaticCatch";
            this.btn_StaticCatch.Size = new System.Drawing.Size(75, 69);
            this.btn_StaticCatch.TabIndex = 5;
            this.btn_StaticCatch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_StaticCatch.Click += new System.EventHandler(this.btn_StaticCatch_Click);
            // 
            // rb_Back
            // 
            this.rb_Back.AutoSize = true;
            this.rb_Back.Location = new System.Drawing.Point(13, 92);
            this.rb_Back.Name = "rb_Back";
            this.rb_Back.Size = new System.Drawing.Size(49, 17);
            this.rb_Back.TabIndex = 3;
            this.rb_Back.TabStop = true;
            this.rb_Back.Text = "后台";
            this.rb_Back.UseVisualStyleBackColor = true;
            this.rb_Back.CheckedChanged += new System.EventHandler(this.rb_Back_CheckedChanged);
            // 
            // rb_Prefer
            // 
            this.rb_Prefer.AutoSize = true;
            this.rb_Prefer.Location = new System.Drawing.Point(13, 48);
            this.rb_Prefer.Name = "rb_Prefer";
            this.rb_Prefer.Size = new System.Drawing.Size(49, 17);
            this.rb_Prefer.TabIndex = 2;
            this.rb_Prefer.TabStop = true;
            this.rb_Prefer.Text = "前台";
            this.rb_Prefer.UseVisualStyleBackColor = true;
            this.rb_Prefer.CheckedChanged += new System.EventHandler(this.rb_Prefer_CheckedChanged);
            // 
            // btn_EditClincReport
            // 
            this.btn_EditClincReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EditClincReport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_EditClincReport.Location = new System.Drawing.Point(15, 730);
            this.btn_EditClincReport.Name = "btn_EditClincReport";
            this.btn_EditClincReport.Size = new System.Drawing.Size(32, 32);
            this.btn_EditClincReport.TabIndex = 1;
            this.btn_EditClincReport.UseVisualStyleBackColor = true;
            // 
            // btn_Set
            // 
            this.btn_Set.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Set.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Set.Location = new System.Drawing.Point(15, 674);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(32, 32);
            this.btn_Set.TabIndex = 1;
            this.btn_Set.Text = "设置";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Visible = false;
            // 
            // frmImageGather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 678);
            this.Controls.Add(this.dockPanel);
            this.Name = "frmImageGather";
            this.Text = "ImgGather";
            this.VisibleChanged += new System.EventHandler(this.ImgGather_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImageGather_FormClosing);
            this.dockPanel.ResumeLayout(false);
            this.p_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Gather)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMSComm1)).EndInit();
            this.p_Buttons.ResumeLayout(false);
            this.p_Buttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.Docking.DockPanel dockPanel;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.Panel p_Buttons;
        private System.Windows.Forms.Button btn_EditClincReport;
        private System.Windows.Forms.Button btn_Set;
        private System.IO.Ports.SerialPort serialPort1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.RadioButton rb_Back;
        private System.Windows.Forms.RadioButton rb_Prefer;
        private BaseControls.Buttons.VistaButton btn_DinamicCatch;
        private BaseControls.Buttons.VistaButton btn_StaticCatch;
        private BaseControls.Buttons.VistaButton btn_CardSetting;
        private BaseControls.Buttons.VistaButton btn_ShowView;
        private AxMSCommLib.AxMSComm axMSComm1;
        public System.Windows.Forms.PictureBox ptb_View;
        public System.Windows.Forms.PictureBox ptb_Gather;
    }
}