namespace BaseControls
{
    partial class CMS_RichTextEx
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMS_RichTextEx));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CMcancle = new System.Windows.Forms.ToolStripMenuItem();
            this.CMcut = new System.Windows.Forms.ToolStripMenuItem();
            this.CMcopy = new System.Windows.Forms.ToolStripMenuItem();
            this.CMpaste = new System.Windows.Forms.ToolStripMenuItem();
            this.CMdel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CMselectall = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMcancle,
            this.toolStripSeparator1,
            this.CMcut,
            this.CMcopy,
            this.CMpaste,
            this.CMdel,
            this.toolStripSeparator2,
            this.CMselectall});
            this.contextMenuStrip1.Name = "cms_TEMPLATE_DICT";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 142);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.cms_RichText_Opened);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // CMcancle
            // 
            this.CMcancle.Image = ((System.Drawing.Image)(resources.GetObject("CMcancle.Image")));
            this.CMcancle.Name = "CMcancle";
            this.CMcancle.Size = new System.Drawing.Size(112, 22);
            this.CMcancle.Text = "撤消(&U)";
            this.CMcancle.Click += new System.EventHandler(this.CMcancle_Click);
            // 
            // CMcut
            // 
            this.CMcut.Image = ((System.Drawing.Image)(resources.GetObject("CMcut.Image")));
            this.CMcut.Name = "CMcut";
            this.CMcut.Size = new System.Drawing.Size(112, 22);
            this.CMcut.Text = "剪切(&T)";
            this.CMcut.Click += new System.EventHandler(this.CMcut_Click);
            // 
            // CMcopy
            // 
            this.CMcopy.Image = ((System.Drawing.Image)(resources.GetObject("CMcopy.Image")));
            this.CMcopy.Name = "CMcopy";
            this.CMcopy.Size = new System.Drawing.Size(112, 22);
            this.CMcopy.Text = "复制(&C)";
            this.CMcopy.Click += new System.EventHandler(this.CMcopy_Click);
            // 
            // CMpaste
            // 
            this.CMpaste.Image = ((System.Drawing.Image)(resources.GetObject("CMpaste.Image")));
            this.CMpaste.Name = "CMpaste";
            this.CMpaste.Size = new System.Drawing.Size(112, 22);
            this.CMpaste.Text = "粘贴(&P)";
            this.CMpaste.Click += new System.EventHandler(this.CMpaste_Click);
            // 
            // CMdel
            // 
            this.CMdel.Image = ((System.Drawing.Image)(resources.GetObject("CMdel.Image")));
            this.CMdel.Name = "CMdel";
            this.CMdel.Size = new System.Drawing.Size(112, 22);
            this.CMdel.Text = "删除(&D)";
            this.CMdel.Click += new System.EventHandler(this.CMdel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // CMselectall
            // 
            this.CMselectall.Name = "CMselectall";
            this.CMselectall.Size = new System.Drawing.Size(112, 22);
            this.CMselectall.Text = "全选(&A)";
            this.CMselectall.Click += new System.EventHandler(this.CMselectall_Click);
            this.contextMenuStrip1.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CMcancle;
        private System.Windows.Forms.ToolStripMenuItem CMcut;
        private System.Windows.Forms.ToolStripMenuItem CMcopy;
        private System.Windows.Forms.ToolStripMenuItem CMpaste;
        private System.Windows.Forms.ToolStripMenuItem CMdel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CMselectall;
    }
}
