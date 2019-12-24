namespace SIS
{
    partial class frmDockForm
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
            this.p_TwoAndThree = new System.Windows.Forms.Panel();
            this.p_Three = new BaseControls.TabControl.RibbonPanel();
            this.outlookBar = new BaseControls.OutlookBar();
            this.p_Two = new BaseControls.TabControl.RibbonPanel();
            this.p_TwoAndThree.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_TwoAndThree
            // 
            this.p_TwoAndThree.AutoScroll = true;
            this.p_TwoAndThree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_TwoAndThree.Controls.Add(this.p_Three);
            this.p_TwoAndThree.Controls.Add(this.outlookBar);
            this.p_TwoAndThree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_TwoAndThree.Location = new System.Drawing.Point(0, 235);
            this.p_TwoAndThree.Name = "p_TwoAndThree";
            this.p_TwoAndThree.Size = new System.Drawing.Size(178, 341);
            this.p_TwoAndThree.TabIndex = 2;
            // 
            // p_Three
            // 
            this.p_Three.AutoScroll = true;
            this.p_Three.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.p_Three.BaseColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.p_Three.Caption = "";
            this.p_Three.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Three.Location = new System.Drawing.Point(0, 0);
            this.p_Three.Name = "p_Three";
            this.p_Three.Opacity = 255;
            this.p_Three.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.p_Three.Size = new System.Drawing.Size(176, 147);
            this.p_Three.Speed = 8;
            this.p_Three.TabIndex = 0;
            // 
            // outlookBar
            // 
            this.outlookBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.outlookBar.ButtonHeight = 30;
            this.outlookBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outlookBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outlookBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlookBar.GradientButtonHoverDark = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(192)))), ((int)(((byte)(91)))));
            this.outlookBar.GradientButtonHoverLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.outlookBar.GradientButtonNormalDark = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(193)))), ((int)(((byte)(140)))));
            this.outlookBar.GradientButtonNormalLight = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(207)))));
            this.outlookBar.GradientButtonSelectedDark = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(150)))), ((int)(((byte)(21)))));
            this.outlookBar.GradientButtonSelectedLight = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            this.outlookBar.Location = new System.Drawing.Point(0, 147);
            this.outlookBar.Name = "outlookBar";
            this.outlookBar.SelectedButton = null;
            this.outlookBar.Size = new System.Drawing.Size(176, 192);
            this.outlookBar.TabIndex = 1;
            this.outlookBar.Click += new BaseControls.OutlookBar.ButtonClickEventHandler(this.outlookBar_Click);
            // 
            // p_Two
            // 
            this.p_Two.AutoScroll = true;
            this.p_Two.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.p_Two.BaseColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.p_Two.Caption = "";
            this.p_Two.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Two.Location = new System.Drawing.Point(0, 0);
            this.p_Two.Name = "p_Two";
            this.p_Two.Opacity = 255;
            this.p_Two.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.p_Two.Size = new System.Drawing.Size(178, 235);
            this.p_Two.Speed = 8;
            this.p_Two.TabIndex = 0;
            // 
            // frmDockForm
            // 
            this.AutoHidePortion = 0.16;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(178, 576);
            this.CloseButton = false;
            this.Controls.Add(this.p_Two);
            this.Controls.Add(this.p_TwoAndThree);
            this.DockAreas = ((BaseControls.Docking.DockAreas)((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDockForm";
            this.ShowHint = BaseControls.Docking.DockState.DockLeft;
            this.Text = "DockForm";
            this.Load += new System.EventHandler(this.DockForm_Load);
            this.SizeChanged += new System.EventHandler(this.frmDockForm_SizeChanged);
            this.DockStateChanged += new System.EventHandler(this.DockForm_DockStateChanged);
            this.p_TwoAndThree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_TwoAndThree;
        private BaseControls.OutlookBar outlookBar;
        private BaseControls.TabControl.RibbonPanel p_Three;
        private BaseControls.TabControl.RibbonPanel p_Two;
    }
}