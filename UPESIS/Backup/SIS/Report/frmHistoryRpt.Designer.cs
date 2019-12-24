namespace SIS
{
    partial class frmHistoryRpt
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
            this.winWordControl = new BaseControls.WinWordControl();
            this.p_Control = new System.Windows.Forms.Panel();
            this.l_Notice = new BaseControls.MyLabel();
            this.p_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // winWordControl
            // 
            this.winWordControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.winWordControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.winWordControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winWordControl.Location = new System.Drawing.Point(0, 0);
            this.winWordControl.Name = "winWordControl";
            this.winWordControl.ShowMenuBar = false;
            this.winWordControl.ShowToolBar = false;
            this.winWordControl.Size = new System.Drawing.Size(658, 494);
            this.winWordControl.TabIndex = 59;
            // 
            // p_Control
            // 
            this.p_Control.AutoScroll = true;
            this.p_Control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Control.Controls.Add(this.l_Notice);
            this.p_Control.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Control.Location = new System.Drawing.Point(0, 494);
            this.p_Control.Name = "p_Control";
            this.p_Control.Size = new System.Drawing.Size(658, 113);
            this.p_Control.TabIndex = 60;
            this.p_Control.Visible = false;
            // 
            // l_Notice
            // 
            this.l_Notice.AutoSize = true;
            this.l_Notice.Font = new System.Drawing.Font("宋体", 9F);
            this.l_Notice.ForeColor = System.Drawing.Color.Red;
            this.l_Notice.Location = new System.Drawing.Point(17, 27);
            this.l_Notice.Name = "l_Notice";
            this.l_Notice.Size = new System.Drawing.Size(35, 12);
            this.l_Notice.TabIndex = 6;
            this.l_Notice.Text = "dddll";
            // 
            // frmHistoryRpt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(658, 607);
            this.Controls.Add(this.winWordControl);
            this.Controls.Add(this.p_Control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmHistoryRpt";
            this.Text = "报告浏览";
            this.Activated += new System.EventHandler(this.frmHistoryRpt_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHistoryRpt_FormClosing);
            this.p_Control.ResumeLayout(false);
            this.p_Control.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public BaseControls.WinWordControl winWordControl;
        private System.Windows.Forms.Panel p_Control;
        private BaseControls.MyLabel l_Notice;
    }
}