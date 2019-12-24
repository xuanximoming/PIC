namespace SIS
{
    partial class frmRptImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptImages));
            this.p_Rpt = new System.Windows.Forms.Panel();
            this.p_RptImages = new System.Windows.Forms.Panel();
            this.l_Count = new BaseControls.MyLabel();
            this.p_Rpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Rpt
            // 
            this.p_Rpt.AutoScroll = true;
            this.p_Rpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Rpt.Controls.Add(this.p_RptImages);
            this.p_Rpt.Controls.Add(this.l_Count);
            this.p_Rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Rpt.Location = new System.Drawing.Point(0, 0);
            this.p_Rpt.Name = "p_Rpt";
            this.p_Rpt.Size = new System.Drawing.Size(167, 626);
            this.p_Rpt.TabIndex = 2;
            // 
            // p_RptImages
            // 
            this.p_RptImages.AutoScroll = true;
            this.p_RptImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_RptImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_RptImages.Location = new System.Drawing.Point(0, 18);
            this.p_RptImages.Name = "p_RptImages";
            this.p_RptImages.Size = new System.Drawing.Size(165, 606);
            this.p_RptImages.TabIndex = 2;
            // 
            // l_Count
            // 
            this.l_Count.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_Count.Font = new System.Drawing.Font("宋体", 9F);
            this.l_Count.ForeColor = System.Drawing.Color.Black;
            this.l_Count.Location = new System.Drawing.Point(0, 0);
            this.l_Count.Name = "l_Count";
            this.l_Count.Size = new System.Drawing.Size(165, 18);
            this.l_Count.TabIndex = 0;
            this.l_Count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRptImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 626);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.p_Rpt);
            this.DockAreas = ((BaseControls.Docking.DockAreas)(((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)
                        | BaseControls.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptImages";
            this.Text = "病人图象";
            this.Load += new System.EventHandler(this.frmRptImages_Load);
            this.SizeChanged += new System.EventHandler(this.PreferImages_SizeChanged);
            this.DockStateChanged += new System.EventHandler(this.PreferImages_DockStateChanged);
            this.p_Rpt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Rpt;
        private System.Windows.Forms.Panel p_RptImages;
        private BaseControls.MyLabel l_Count;
    }
}