namespace SIS
{
    partial class frmBackImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackImages));
            this.p_Back = new System.Windows.Forms.Panel();
            this.p_BackImags = new System.Windows.Forms.Panel();
            this.ctms_Images = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.l_Count = new BaseControls.MyLabel();
            this.p_Back.SuspendLayout();
            this.ctms_Images.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Back
            // 
            this.p_Back.AutoScroll = true;
            this.p_Back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Back.Controls.Add(this.p_BackImags);
            this.p_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Back.Location = new System.Drawing.Point(0, 18);
            this.p_Back.Name = "p_Back";
            this.p_Back.Size = new System.Drawing.Size(168, 598);
            this.p_Back.TabIndex = 3;
            // 
            // p_BackImags
            // 
            this.p_BackImags.AutoScroll = true;
            this.p_BackImags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_BackImags.ContextMenuStrip = this.ctms_Images;
            this.p_BackImags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_BackImags.Location = new System.Drawing.Point(0, 0);
            this.p_BackImags.Name = "p_BackImags";
            this.p_BackImags.Size = new System.Drawing.Size(166, 596);
            this.p_BackImags.TabIndex = 1;
            // 
            // ctms_Images
            // 
            this.ctms_Images.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Refresh,
            this.toolStripSeparator1,
            this.tsmi_Delete,
            this.tsmi_DeleteAll,
            this.toolStripSeparator2,
            this.tsmi_Export,
            this.tsmi_ExportAll});
            this.ctms_Images.Name = "contextMenuStrip1";
            this.ctms_Images.Size = new System.Drawing.Size(119, 126);
            // 
            // tsmi_Refresh
            // 
            this.tsmi_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Refresh.Image")));
            this.tsmi_Refresh.Name = "tsmi_Refresh";
            this.tsmi_Refresh.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Refresh.Text = "刷新";
            this.tsmi_Refresh.Click += new System.EventHandler(this.tsmi_Refresh_Click);
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
            // tsmi_DeleteAll
            // 
            this.tsmi_DeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_DeleteAll.Image")));
            this.tsmi_DeleteAll.Name = "tsmi_DeleteAll";
            this.tsmi_DeleteAll.Size = new System.Drawing.Size(118, 22);
            this.tsmi_DeleteAll.Text = "全部删除";
            this.tsmi_DeleteAll.Click += new System.EventHandler(this.tsmi_DeleteAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // tsmi_Export
            // 
            this.tsmi_Export.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Export.Image")));
            this.tsmi_Export.Name = "tsmi_Export";
            this.tsmi_Export.Size = new System.Drawing.Size(118, 22);
            this.tsmi_Export.Text = "导出";
            this.tsmi_Export.Click += new System.EventHandler(this.tsmi_Export_Click);
            // 
            // tsmi_ExportAll
            // 
            this.tsmi_ExportAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ExportAll.Image")));
            this.tsmi_ExportAll.Name = "tsmi_ExportAll";
            this.tsmi_ExportAll.Size = new System.Drawing.Size(118, 22);
            this.tsmi_ExportAll.Text = "全部导出";
            this.tsmi_ExportAll.Click += new System.EventHandler(this.tsmi_ExportAll_Click);
            // 
            // l_Count
            // 
            this.l_Count.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_Count.Font = new System.Drawing.Font("宋体", 9F);
            this.l_Count.ForeColor = System.Drawing.Color.Black;
            this.l_Count.Location = new System.Drawing.Point(0, 0);
            this.l_Count.Name = "l_Count";
            this.l_Count.Size = new System.Drawing.Size(168, 18);
            this.l_Count.TabIndex = 4;
            this.l_Count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBackImages
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(168, 616);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.p_Back);
            this.Controls.Add(this.l_Count);
            this.DockAreas = ((BaseControls.Docking.DockAreas)((((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)
                        | BaseControls.Docking.DockAreas.DockTop)
                        | BaseControls.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBackImages";
            this.Text = "后台图象";
            this.Load += new System.EventHandler(this.BackImages_Load);
            this.SizeChanged += new System.EventHandler(this.BackImages_SizeChanged);
            this.DockStateChanged += new System.EventHandler(this.BackImages_DockStateChanged);
            this.p_Back.ResumeLayout(false);
            this.ctms_Images.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Back;
        private System.Windows.Forms.Panel p_BackImags;
        private System.Windows.Forms.ContextMenuStrip ctms_Images;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Refresh;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ExportAll;
        private BaseControls.MyLabel l_Count;
    }
}