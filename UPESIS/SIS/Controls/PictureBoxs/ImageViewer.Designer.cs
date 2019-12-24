using BaseControls.PictureBoxs;
using BaseControls.Buttons;
namespace BaseControls
{
    partial class ImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CounterclockwiseRotation = new BaseControls.Buttons.CrystalButton();
            this.btn_ClockwiseRotation = new BaseControls.Buttons.CrystalButton();
            this.btn_StopMove = new BaseControls.Buttons.CrystalButton();
            this.btn_Move = new BaseControls.Buttons.CrystalButton();
            this.btn_Save = new BaseControls.Buttons.CrystalButton();
            this.btn_BestBig = new BaseControls.Buttons.CrystalButton();
            this.btn_PrimaryBig = new BaseControls.Buttons.CrystalButton();
            this.btn_ForwardImage = new BaseControls.Buttons.CrystalButton();
            this.btn_BackImage = new BaseControls.Buttons.CrystalButton();
            this.l_Count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.ptb_Image = new BaseControls.PictureBoxs.MyPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btn_CounterclockwiseRotation);
            this.panel1.Controls.Add(this.btn_ClockwiseRotation);
            this.panel1.Controls.Add(this.btn_StopMove);
            this.panel1.Controls.Add(this.btn_Move);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_BestBig);
            this.panel1.Controls.Add(this.btn_PrimaryBig);
            this.panel1.Controls.Add(this.btn_ForwardImage);
            this.panel1.Controls.Add(this.btn_BackImage);
            this.panel1.Controls.Add(this.l_Count);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 484);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 67);
            this.panel1.TabIndex = 3;
            // 
            // btn_CounterclockwiseRotation
            // 
            this.btn_CounterclockwiseRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_CounterclockwiseRotation.BackColor = System.Drawing.Color.Transparent;
            this.btn_CounterclockwiseRotation.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CounterclockwiseRotation.ForeColor = System.Drawing.Color.Black;
            this.btn_CounterclockwiseRotation.Image = ((System.Drawing.Image)(resources.GetObject("btn_CounterclockwiseRotation.Image")));
            this.btn_CounterclockwiseRotation.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_CounterclockwiseRotation.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_CounterclockwiseRotation.Location = new System.Drawing.Point(443, 14);
            this.btn_CounterclockwiseRotation.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CounterclockwiseRotation.Name = "btn_CounterclockwiseRotation";
            this.btn_CounterclockwiseRotation.Size = new System.Drawing.Size(40, 36);
            this.btn_CounterclockwiseRotation.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_CounterclockwiseRotation, "逆时针旋转");
            this.btn_CounterclockwiseRotation.UseVisualStyleBackColor = false;
            this.btn_CounterclockwiseRotation.Click += new System.EventHandler(this.btn_CounterclockwiseRotation_Click);
            // 
            // btn_ClockwiseRotation
            // 
            this.btn_ClockwiseRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_ClockwiseRotation.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClockwiseRotation.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClockwiseRotation.ForeColor = System.Drawing.Color.Black;
            this.btn_ClockwiseRotation.Image = ((System.Drawing.Image)(resources.GetObject("btn_ClockwiseRotation.Image")));
            this.btn_ClockwiseRotation.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_ClockwiseRotation.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_ClockwiseRotation.Location = new System.Drawing.Point(389, 14);
            this.btn_ClockwiseRotation.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ClockwiseRotation.Name = "btn_ClockwiseRotation";
            this.btn_ClockwiseRotation.Size = new System.Drawing.Size(40, 36);
            this.btn_ClockwiseRotation.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_ClockwiseRotation, "顺时针旋转");
            this.btn_ClockwiseRotation.UseVisualStyleBackColor = false;
            this.btn_ClockwiseRotation.Click += new System.EventHandler(this.btn_ClockwiseRotation_Click);
            // 
            // btn_StopMove
            // 
            this.btn_StopMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_StopMove.BackColor = System.Drawing.Color.Transparent;
            this.btn_StopMove.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StopMove.ForeColor = System.Drawing.Color.Black;
            this.btn_StopMove.Image = ((System.Drawing.Image)(resources.GetObject("btn_StopMove.Image")));
            this.btn_StopMove.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_StopMove.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_StopMove.Location = new System.Drawing.Point(329, 14);
            this.btn_StopMove.Margin = new System.Windows.Forms.Padding(4);
            this.btn_StopMove.Name = "btn_StopMove";
            this.btn_StopMove.Size = new System.Drawing.Size(48, 36);
            this.btn_StopMove.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_StopMove, "停止移动");
            this.btn_StopMove.UseVisualStyleBackColor = false;
            this.btn_StopMove.Click += new System.EventHandler(this.btn_StopMove_Click);
            // 
            // btn_Move
            // 
            this.btn_Move.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_Move.BackColor = System.Drawing.Color.Transparent;
            this.btn_Move.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Move.ForeColor = System.Drawing.Color.Black;
            this.btn_Move.Image = ((System.Drawing.Image)(resources.GetObject("btn_Move.Image")));
            this.btn_Move.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Move.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_Move.Location = new System.Drawing.Point(276, 14);
            this.btn_Move.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(48, 36);
            this.btn_Move.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_Move, "移动图像");
            this.btn_Move.UseVisualStyleBackColor = false;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.Black;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Save.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_Save.Location = new System.Drawing.Point(605, 14);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(45, 36);
            this.btn_Save.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_Save, "另存为");
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_BestBig
            // 
            this.btn_BestBig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_BestBig.BackColor = System.Drawing.Color.Transparent;
            this.btn_BestBig.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BestBig.ForeColor = System.Drawing.Color.Black;
            this.btn_BestBig.Image = ((System.Drawing.Image)(resources.GetObject("btn_BestBig.Image")));
            this.btn_BestBig.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_BestBig.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_BestBig.Location = new System.Drawing.Point(551, 14);
            this.btn_BestBig.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BestBig.Name = "btn_BestBig";
            this.btn_BestBig.Size = new System.Drawing.Size(40, 36);
            this.btn_BestBig.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_BestBig, "最佳尺寸");
            this.btn_BestBig.UseVisualStyleBackColor = false;
            this.btn_BestBig.Click += new System.EventHandler(this.btn_BestBig_Click);
            // 
            // btn_PrimaryBig
            // 
            this.btn_PrimaryBig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_PrimaryBig.BackColor = System.Drawing.Color.Transparent;
            this.btn_PrimaryBig.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PrimaryBig.ForeColor = System.Drawing.Color.Black;
            this.btn_PrimaryBig.Image = ((System.Drawing.Image)(resources.GetObject("btn_PrimaryBig.Image")));
            this.btn_PrimaryBig.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_PrimaryBig.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_PrimaryBig.Location = new System.Drawing.Point(497, 14);
            this.btn_PrimaryBig.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PrimaryBig.Name = "btn_PrimaryBig";
            this.btn_PrimaryBig.Size = new System.Drawing.Size(40, 36);
            this.btn_PrimaryBig.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_PrimaryBig, "原始尺寸");
            this.btn_PrimaryBig.UseVisualStyleBackColor = false;
            this.btn_PrimaryBig.Click += new System.EventHandler(this.btn_PrimaryBig_Click);
            // 
            // btn_ForwardImage
            // 
            this.btn_ForwardImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_ForwardImage.BackColor = System.Drawing.Color.Transparent;
            this.btn_ForwardImage.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ForwardImage.ForeColor = System.Drawing.Color.Black;
            this.btn_ForwardImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_ForwardImage.Image")));
            this.btn_ForwardImage.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_ForwardImage.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_ForwardImage.Location = new System.Drawing.Point(208, 14);
            this.btn_ForwardImage.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ForwardImage.Name = "btn_ForwardImage";
            this.btn_ForwardImage.Size = new System.Drawing.Size(40, 36);
            this.btn_ForwardImage.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_ForwardImage, "下一张图片");
            this.btn_ForwardImage.UseVisualStyleBackColor = false;
            this.btn_ForwardImage.Click += new System.EventHandler(this.btn_ForwardImage_Click);
            // 
            // btn_BackImage
            // 
            this.btn_BackImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_BackImage.BackColor = System.Drawing.Color.Transparent;
            this.btn_BackImage.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BackImage.ForeColor = System.Drawing.Color.Black;
            this.btn_BackImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_BackImage.Image")));
            this.btn_BackImage.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_BackImage.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_BackImage.Location = new System.Drawing.Point(154, 14);
            this.btn_BackImage.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BackImage.Name = "btn_BackImage";
            this.btn_BackImage.Size = new System.Drawing.Size(40, 36);
            this.btn_BackImage.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_BackImage, "上一张图片");
            this.btn_BackImage.UseVisualStyleBackColor = false;
            this.btn_BackImage.Click += new System.EventHandler(this.btn_BackImage_Click);
            // 
            // l_Count
            // 
            this.l_Count.AutoSize = true;
            this.l_Count.Location = new System.Drawing.Point(103, 28);
            this.l_Count.Name = "l_Count";
            this.l_Count.Size = new System.Drawing.Size(16, 16);
            this.l_Count.TabIndex = 6;
            this.l_Count.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "图片数:";
            // 
            // saveImage
            // 
            this.saveImage.Filter = "JPG图像|*.JPG|所有文件|*.*";
            this.saveImage.FileOk += new System.ComponentModel.CancelEventHandler(this.saveImage_FileOk);
            // 
            // ptb_Image
            // 
            this.ptb_Image.BackColor = System.Drawing.Color.White;
            this.ptb_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptb_Image.Location = new System.Drawing.Point(0, 0);
            this.ptb_Image.Margin = new System.Windows.Forms.Padding(4);
            this.ptb_Image.Name = "ptb_Image";
            this.ptb_Image.Size = new System.Drawing.Size(702, 551);
            this.ptb_Image.TabIndex = 0;
            this.ptb_Image.TabStop = false;
            // 
            // ImageViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(702, 551);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptb_Image);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(600, 352);
            this.Name = "ImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片浏览器";
            this.TopMost = true;
            this.Move += new System.EventHandler(this.ImageViewer_Move);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPictureBox ptb_Image;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label l_Count;
        private System.Windows.Forms.Label label1;
        private CrystalButton btn_BackImage;
        private CrystalButton btn_PrimaryBig;
        private CrystalButton btn_ForwardImage;
        private CrystalButton btn_CounterclockwiseRotation;
        private CrystalButton btn_ClockwiseRotation;
        private CrystalButton btn_Move;
        private CrystalButton btn_BestBig;
        private System.Windows.Forms.SaveFileDialog saveImage;
        private CrystalButton btn_Save;
        private CrystalButton btn_StopMove;
    }
}