namespace BaseControls.PictureBoxs
{
    partial class userCtrPictureEx
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
            this.l_Buttom = new System.Windows.Forms.Label();
            this.l_Top = new System.Windows.Forms.Label();
            this.Picture = new BaseControls.PictureBoxs.userCtrPicture();
            this.l_Right = new BaseControls.VerticalLabel();
            this.l_Left = new BaseControls.VerticalLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Buttom
            // 
            this.l_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.l_Buttom.Location = new System.Drawing.Point(0, 127);
            this.l_Buttom.Name = "l_Buttom";
            this.l_Buttom.Size = new System.Drawing.Size(168, 14);
            this.l_Buttom.TabIndex = 1;
            this.l_Buttom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Buttom.TextChanged += new System.EventHandler(this.l_Buttom_TextChanged);
            // 
            // l_Top
            // 
            this.l_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_Top.Location = new System.Drawing.Point(0, 0);
            this.l_Top.Name = "l_Top";
            this.l_Top.Size = new System.Drawing.Size(168, 14);
            this.l_Top.TabIndex = 2;
            this.l_Top.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.White;
            this.Picture.ClickColor = System.Drawing.Color.Green;
            this.Picture.DbClickColor = System.Drawing.Color.Red;
            this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Picture.FileName = "";
            this.Picture.FilePath = "";
            this.Picture.ImageRatio = 0;
            this.Picture.ImgObj = null;
            this.Picture.Inf = "";
            this.Picture.IsMark = false;
            this.Picture.IsSelected = false;
            this.Picture.IsSelecting = false;
            this.Picture.Location = new System.Drawing.Point(14, 14);
            this.Picture.LocMapPath = "";
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(140, 113);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            
            // 
            // l_Right
            // 
            this.l_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.l_Right.Location = new System.Drawing.Point(154, 14);
            this.l_Right.Name = "l_Right";
            this.l_Right.RenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.l_Right.Size = new System.Drawing.Size(14, 113);
            this.l_Right.TabIndex = 6;
            this.l_Right.Text = null;
            this.l_Right.TextDrawMode = BaseControls.DrawMode.TopBottom;
            this.l_Right.TransparentBackground = false;
            // 
            // l_Left
            // 
            this.l_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.l_Left.Location = new System.Drawing.Point(0, 14);
            this.l_Left.Name = "l_Left";
            this.l_Left.RenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.l_Left.Size = new System.Drawing.Size(14, 113);
            this.l_Left.TabIndex = 5;
            this.l_Left.Text = null;
            this.l_Left.TextDrawMode = BaseControls.DrawMode.BottomUp;
            this.l_Left.TransparentBackground = false;
            // 
            // userCtrPictureEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.l_Right);
            this.Controls.Add(this.l_Left);
            this.Controls.Add(this.l_Top);
            this.Controls.Add(this.l_Buttom);
            this.Name = "userCtrPictureEx";
            this.Size = new System.Drawing.Size(168, 141);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public userCtrPicture Picture;
        public System.Windows.Forms.Label l_Buttom;
        public System.Windows.Forms.Label l_Top;
        public VerticalLabel l_Left;
        public VerticalLabel l_Right;

    }
}
