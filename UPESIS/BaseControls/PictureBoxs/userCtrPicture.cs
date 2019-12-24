using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace BaseControls.PictureBoxs
{
    public partial class userCtrPicture : PictureBox
    {
        private string filePath = "";
        private string fileName = "";
        private bool isSelecting = false;//是否单击选中
        private bool isSelected = false;//是否双击选中
        public bool isOpenDoubleClick = true;//是否双击边框变红色
        private object imgobj;
        public event EventHandler CheckChanged;
        private double image_ratio = 0;
        private Color clickColor = Color.Green;
        private Color dbClickColor = Color.Red;
        private string locMapPath = "";
        private string inf = "";
        private bool isMark = false;
        public userCtrPicture()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Size = new Size(135, 100);
            this.DoubleBuffered = true;
            this.checkBox.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
            this.checkBox.Visible = true;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //线程安全
            EventHandler temp = CheckChanged;
            if (temp != null)
            {
                temp(this, null);
            }
        }

        /// <summary>
        /// 是否单击选中
        /// </summary>
        public bool IsSelecting
        {
            get {   return this.isSelecting;  }
            set {   this.isSelecting = value; }
        }
        /// <summary>
        /// 图像信息
        /// </summary>
        public object ImgObj
        {
            get { return this.imgobj; }
            set { this.imgobj = value; }
        }
        /// <summary>
        /// 是否双击选中
        /// </summary>
        public bool IsSelected
        {
            get  {  return this.isSelected;}
            set{   this.isSelected = value; }
        }

        /// <summary>
        ///  单击选中时的边框颜色
        /// </summary>
        public Color ClickColor
        {
            get { return this.clickColor; }
            set { this.clickColor = value; }
        }

        /// <summary>
        /// 双击选中时的边框颜色
        /// </summary>
        public Color DbClickColor
        {
            get { return this.dbClickColor; }
            set { this.dbClickColor = value; }
        }


        /// <summary>
        /// 图象文件路径
        /// </summary>
        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }

        /// <summary>
        /// 图象文件名
        /// </summary>
        public string FileName
        {
            get{  return this.fileName; }
            set{  this.fileName = value; }
        }

        /// <summary>
        /// 图象文件大小比例
        /// </summary>
        public double ImageRatio
        {
            get { return this.image_ratio; }
            set { this.image_ratio = value; }
        }

        /// <summary>
        /// 定位图路径
        /// </summary>
        public string LocMapPath
        {
            get { return this.locMapPath; }
            set { this.locMapPath = value; }
        }

        /// <summary>
        /// 定位图描述
        /// </summary>
        public string Inf
        {
            get { return this.inf; }
            set { this.inf = value; }
        }

        /// <summary>
        /// 是否处理后的图像
        /// </summary>
        public bool IsMark
        {
            get { return this.isMark; }
            set { this.isMark = value; }
        }

        public void LoadFile(string file)
        {
            System.IO.FileStream fs = null;
            try
            {
                fs = new System.IO.FileStream(file, System.IO.FileMode.Open);
                if (fs.Length > 0)
                {
                    Image image = Image.FromStream(fs);
                    this.Image = image;
                    this.filePath = file;
                    this.fileName = file.Substring(file.LastIndexOf("\\") + 1);
                    this.image_ratio = (double)image.Width / (double)image.Height;
                }
                else
                {
                    fs.Close();
                    //System.IO.File.Delete(file);
                }
            }
            catch{}
            if (fs != null)
                fs.Close();
        }

        public void SetDoubleClick(bool isCan)
        {
            this.isOpenDoubleClick = isCan;
        }

        public void SetCheckBoxVisible(bool isVisible)
        {
            this.checkBox.Visible = isVisible;
        }

        public void SetCheckBoxReadOnly(bool Readonly)
        {
            this.checkBox.ReadOnly = Readonly;
        }


        public void SetCheck(bool isCheck)
        {
            this.checkBox.Checked = isCheck;
        }
        public void SetCheck()
        {
            this.checkBox.Checked = !this.checkBox.Checked;
        }
        public bool GetCheck()
        {
            return this.checkBox.Checked;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.isSelecting)
                {
                    this.isSelecting = false;
                    PaintEventArgs pe = new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle);
                    this.OnPaint(pe);
                }
                else
                {
                    this.isSelecting = true;
                    PaintEventArgs pe = new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle);
                    this.OnPaint(pe);
                }
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (this.isOpenDoubleClick)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.isSelecting = false;
                    if (this.isSelected)
                    {
                        this.isSelected = false;
                        PaintEventArgs pe = new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle);
                        this.OnPaint(pe);
                    }
                    else
                    {
                        SetParent();
                        this.isSelected = true;
                        PaintEventArgs pe = new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle);
                        this.OnPaint(pe);
                    }
                }
            }
            base.OnMouseDoubleClick(e);
        }

        private void SetParent()
        {
            for (int i = 0; i < this.Parent.Controls.Count; i++)
            {
                if (this.Parent.Controls[i].GetType().Name == "userCtrPicture")
                {
                    userCtrPicture uc = (userCtrPicture)this.Parent.Controls[i];
                    uc.isSelected = false;
                    uc.Refresh();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);           
            if (this.isSelecting)
            {
                Pen p = new Pen(clickColor, 3);
                Rectangle rect = this.ClientRectangle;
                e.Graphics.DrawRectangle(p, rect.X, rect.Y, rect.Width - 2, rect.Height - 2);
            }
            if (isSelected)
            {
                Pen p = new Pen(dbClickColor, 3);
                Rectangle rect = this.ClientRectangle;
                e.Graphics.DrawRectangle(p, rect.X, rect.Y, rect.Width - 2, rect.Height - 2);
            }
        }

    }
}
