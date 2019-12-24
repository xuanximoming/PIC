using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace SIS.ImgProcess
{
    public class ToolText : System.Windows.Forms.TextBox
	{
		#region private variables

		private  uPictureBox myPictureBox;
		private  bool   myUpToDate = false;
		private  bool   myCaretUpToDate = false;
		private  Bitmap myBitmap;
		private  Bitmap myAlphaBitmap;

		private int myFontHeight = 10;

		private System.Windows.Forms.Timer myTimer1;

		private bool myCaretState = true;

		private bool myPaintedFirstTime = false;

		private Color myBackColor = Color.White;
		private int myBackAlpha = 10;
        private int mode = -1; //0:移动或改变大小模式; 1:编辑模式
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion // end private variables


		#region public methods and overrides

        public ToolText(Control Parent)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitializeComponent call

			this.BackColor = myBackColor;
            this.Multiline = true;
            this.AutoSize = false;
            this.BorderStyle = BorderStyle.None;
            this.myBackAlpha = 0;
			this.SetStyle(ControlStyles.UserPaint,false);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
			this.SetStyle(ControlStyles.DoubleBuffer,true);
            System.Reflection.PropertyInfo _BorderStyleInfo = this.GetType().GetProperty("BorderStyle");
            if (_BorderStyleInfo == null) return;
            try
            {
                if ((BorderStyle)_BorderStyleInfo.GetValue(this, new object[] { }) == BorderStyle.Fixed3D) m_SamillSizeLeft = 8;
            }
            catch{}
            this.Parent = Parent;
            this.Parent.MouseDown += new MouseEventHandler(Parent_MouseDown);
			myPictureBox = new uPictureBox();
			this.Controls.Add(myPictureBox);
			myPictureBox.Dock = DockStyle.Fill;
		}

        void Parent_MouseDown(object sender, MouseEventArgs e)
        {
            OnLostFocus(e);
            this.Parent.Focus();
            //this.Update();
        }

		protected override void OnResize(EventArgs e)
		{
			
			base.OnResize (e);
			this.myBitmap = new Bitmap(this.ClientRectangle.Width,this.ClientRectangle.Height);//(this.Width,this.Height);
			this.myAlphaBitmap = new Bitmap(this.ClientRectangle.Width,this.ClientRectangle.Height);//(this.Width,this.Height);
			myUpToDate = false;
			this.Invalidate();
		}


		//Some of these should be moved to the WndProc later

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);
			myUpToDate = false;
			this.Invalidate();
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp (e);
			myUpToDate = false;
			this.Invalidate();

		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress (e);
			myUpToDate = false;
			this.Invalidate();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                m_MoveCommand = GetCommand(new Point(e.X, e.Y));
                m_MousePoint = new Point(e.X, e.Y);
                m_MouseRight = new Point(e.X, e.Y);
                switch (m_MoveCommand)
                {
                    case MoveCommand.Move:
                        this.Cursor = Cursors.SizeAll;
                        break;
                    default:
                        break;
                }
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                this.mode = 1;
                this.ReadOnly = false;
                base.OnMouseDoubleClick(e);
                myTimer1 = new System.Windows.Forms.Timer(this.components);
                myTimer1.Interval = (int)win32.GetCaretBlinkTime(); //  usually around 500;
                myTimer1.Tick += new EventHandler(myTimer1_Tick);
                myTimer1.Enabled = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
		{
            m_MoveCommand = MoveCommand.None;
            if (this.IsMove && this.mode == 0)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.IBeam;
            if (MoveEnd != null) MoveEnd(this);
			base.OnMouseUp (e);
			this.Invalidate();
		}

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (m_MoveCommand == MoveCommand.None)
            {
                GetCursor(new Point(e.X, e.Y));
                return;
            }
            switch (m_MoveCommand)
            {
                case MoveCommand.Move:
                    int _PointX = m_MousePoint.X - e.X;
                    int _PointY = m_MousePoint.Y - e.Y;
                    if (m_Min)
                    {
                        if (this.Location.X - _PointX <= 0) _PointX = 0;
                        if (this.Location.Y - _PointY <= 0) _PointY = 0;
                    }
                    if (m_Max)
                    {
                        if (this.Location.X - _PointX + this.Width >= this.Parent.Width) _PointX = 0;
                        if (this.Location.Y - _PointY + this.Height >= this.Parent.Height) _PointY = 0;
                    }

                    this.Location = new Point(this.Location.X - _PointX, this.Location.Y - _PointY);
                    break;

                #region 上下左右
                case MoveCommand.SizeRight:
                    if ((this.Width + e.X - m_MousePoint.X) < 10) break;
                    if (m_Max)
                    {
                        int _Max = (this.Width + e.X - m_MousePoint.X) + this.Location.X;
                        if (_Max >= this.Parent.Width) break;
                    }
                    this.Width = this.Width + e.X - m_MousePoint.X;
                    m_MousePoint.X = e.X;
                    m_MousePoint.Y = e.Y;
                    break;

                case MoveCommand.SizeDown:
                    if ((this.Height + e.Y - m_MousePoint.Y) < 10) break;
                    if (m_Max)
                    {
                        int _Max = (this.Height + e.Y - m_MousePoint.Y) + this.Location.Y;
                        if (_Max >= this.Parent.Height) break;
                    }
                    this.Height = this.Height + e.Y - m_MousePoint.Y;
                    m_MousePoint.X = e.X;
                    m_MousePoint.Y = e.Y;
                    break;
                case MoveCommand.SizeUp:
                    if ((this.Height - (e.Y - m_MousePoint.Y)) < 10) break;
                    if (m_Min)
                    {
                        int _Mix = this.Top + (e.Y - m_MousePoint.Y);
                        if (_Mix < 0) break;
                    }
                    this.Top = this.Top + (e.Y - m_MousePoint.Y);
                    this.Height = this.Height - (e.Y - m_MousePoint.Y);
                    break;
                case MoveCommand.SizeLeft:
                    if ((this.Width - (e.X - m_MousePoint.X)) < 10) break;
                    if (m_Min)
                    {
                        int _Mix = this.Left + e.X - m_MousePoint.X;
                        if (_Mix < 0) break;
                    }
                    this.Left = this.Left + e.X - m_MousePoint.X;
                    this.Width = this.Width - (e.X - m_MousePoint.X);
                    break;
                #endregion

                #region 四角
                case MoveCommand.SizeLeftUp:
                    int _Left = this.Left + e.X - m_MousePoint.X;
                    int _Top = this.Top + (e.Y - m_MousePoint.Y);
                    int _Width = this.Width - (e.X - m_MousePoint.X);
                    int _Height = this.Height - (e.Y - m_MousePoint.Y);

                    if (_Width < 10)        //这里如果错误 换成直接返回break  
                    {
                        _Width = 10;
                        _Left = this.Left;
                    }
                    if (_Height < 10)
                    {
                        _Height = 10;
                        _Top = this.Top;
                    }

                    if (m_Min)
                    {
                        if (_Left < 0)
                        {
                            _Left = 0;
                            _Width = this.Width;

                        }
                        if (_Top < 0)
                        {
                            _Top = 0;
                            _Height = this.Height;
                        }
                    }
                    this.Left = _Left;
                    this.Top = _Top;
                    this.Width = _Width;
                    this.Height = _Height;
                    break;
                case MoveCommand.SizeRightDown:

                    if ((this.Width + e.X - m_MousePoint.X) < 10) break;
                    if ((this.Height + e.Y - m_MousePoint.Y) < 10) break;
                    if (m_Max)
                    {
                        int _Max = (this.Height + e.Y - m_MousePoint.Y) + this.Location.Y;
                        if (_Max >= this.Parent.Height) break;
                        _Max = (this.Width + e.X - m_MousePoint.X) + this.Location.X;
                        if (_Max >= this.Parent.Width) break;
                    }
                    this.Width = this.Width + e.X - m_MousePoint.X;
                    this.Height = this.Height + e.Y - m_MousePoint.Y;
                    m_MousePoint.X = e.X;
                    m_MousePoint.Y = e.Y; //'记录光标拖动的当前点 
                    break;

                case MoveCommand.SizeRightUp:
                    if ((this.Width + (e.X - m_MousePoint.X)) < 10) break;
                    if ((this.Height - (e.Y - m_MouseRight.Y)) < 10) break;
                    if (m_Min)
                    {
                        if ((this.Top + (e.Y - m_MouseRight.Y)) < 0) break;
                    }
                    this.Top = this.Top + (e.Y - m_MouseRight.Y);
                    this.Width = this.Width + (e.X - m_MousePoint.X);
                    this.Height = this.Height - (e.Y - m_MouseRight.Y);
                    m_MousePoint.X = e.X;
                    m_MousePoint.Y = e.Y; //'记录光标拖动的当前点 
                    break;

                case MoveCommand.SizeLeftDown:
                    if ((this.Width - (e.X - m_MouseRight.X)) < 10) break;
                    if ((this.Height + e.Y - m_MousePoint.Y) < 10) break;

                    if (m_Min)
                    {
                        if ((this.Left + e.X - m_MouseRight.X) < 0) break;
                    }
                    if (m_Max)
                    {
                        int _Max = (this.Height + e.Y - m_MousePoint.Y) + this.Location.Y;
                        if (_Max >= this.Parent.Height) break;
                    }

                    this.Left = this.Left + e.X - m_MouseRight.X;
                    this.Width = this.Width - (e.X - m_MouseRight.X);
                    this.Height = this.Height + e.Y - m_MousePoint.Y;
                    m_MousePoint.X = e.X;
                    m_MousePoint.Y = e.Y; //'记录光标拖动的当前点 
                    break;
                #endregion
            }
            base.OnMouseMove(e);
            this.Update();
        }

		protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
		{
			base.OnGiveFeedback (gfbevent);
			myUpToDate = false;
			this.Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			Point ptCursor = Cursor.Position; 
			Form f = this.FindForm();
			ptCursor = f.PointToClient(ptCursor);
            if (this.Bounds.X > ptCursor.X && this.Bounds.Y > ptCursor.Y && this.Bounds.Right < ptCursor.X && this.Bounds.Bottom < ptCursor.Y) 
            {
				base.OnMouseLeave (e);
                this.Cursor = Cursors.Default;
            }
		}		
				
		protected override void OnChangeUICues(UICuesEventArgs e)
		{
			base.OnChangeUICues (e);
			myUpToDate = false;
			this.Invalidate();
		}
		
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);

			myCaretUpToDate = false;
			myUpToDate = false;
			this.Invalidate();
            this.myBackAlpha = 255;
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);
            this.myBackAlpha = 0;
            this.ReadOnly = true;
			myCaretUpToDate = false;
			myUpToDate = false;
			this.Invalidate();
            if (myTimer1 != null)
                myTimer1.Dispose();
            this.mode = this.IsMove ? 0 : -1;
		}

		protected override void OnFontChanged(EventArgs e)
		{
			if (this.myPaintedFirstTime)
				this.SetStyle(ControlStyles.UserPaint,false);

			base.OnFontChanged (e);

			if (this.myPaintedFirstTime)
				this.SetStyle(ControlStyles.UserPaint,true);

				
			myFontHeight = GetFontHeight();


			myUpToDate = false;
			this.Invalidate();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged (e);
            //int lc = win32.SendMessage(this.Handle, win32.EM_GETLINECOUNT, IntPtr.Zero, "");
            //int sf = myFontHeight * lc;
            //this.ClientSize = new Size(this.ClientSize.Width, sf + 5);
			myUpToDate = false;
			this.Invalidate();
		}
		
		protected override void WndProc(ref Message m)
		{

			base.WndProc (ref m);

			// need to rewrite as a big switch

			if (m.Msg == win32.WM_PAINT)
			{
				myPaintedFirstTime = true;

				if (!myUpToDate || !myCaretUpToDate)
					GetBitmaps();
				myUpToDate = true;
				myCaretUpToDate = true;

				if (myPictureBox.Image != null) myPictureBox.Image.Dispose();
				myPictureBox.Image = (System.Drawing.Image)myAlphaBitmap.Clone();

			}

			else if (m.Msg ==  win32.WM_HSCROLL || m.Msg == win32.WM_VSCROLL)
			{
				myUpToDate = false;
				this.Invalidate();			
			}

			else if (m.Msg == win32.WM_LBUTTONDOWN 
				|| m.Msg == win32.WM_RBUTTONDOWN
				|| m.Msg == win32.WM_LBUTTONDBLCLK
				//  || m.Msg == win32.WM_MOUSELEAVE  ///****
				)
			{
				myUpToDate = false;
				this.Invalidate();			
			}

			else if (m.Msg == win32.WM_MOUSEMOVE )
			{
				if (m.WParam.ToInt32() != 0)  //shift key or other buttons
				{
					myUpToDate = false;
					this.Invalidate();			
				}
			}

		}


		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				//this.BackColor = Color.Pink;
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion		//end public method and overrides


		#region public property overrides

		public new BorderStyle BorderStyle
		{
			get {return base.BorderStyle;}
			set 
			{
				if (this.myPaintedFirstTime)
					this.SetStyle(ControlStyles.UserPaint,false);

				base.BorderStyle = value;
				
				if (this.myPaintedFirstTime)
					this.SetStyle(ControlStyles.UserPaint,true);

				this.myBitmap = null;
				this.myAlphaBitmap = null;
				myUpToDate = false;
				this.Invalidate();
			}
		}

		public  new Color BackColor
		{
			get
			{
				return Color.FromArgb(base.BackColor.R, base.BackColor.G, base.BackColor.B);
			}
			set
			{
				myBackColor = value;
				base.BackColor = value;
				myUpToDate = false;
			}
		}
		public override bool Multiline
		{
			get{return base.Multiline;}
			set
			{
				if (this.myPaintedFirstTime)
					this.SetStyle(ControlStyles.UserPaint,false);
				
				base.Multiline = value;

				if (this.myPaintedFirstTime)
					this.SetStyle(ControlStyles.UserPaint,true);

				this.myBitmap = null;
				this.myAlphaBitmap = null;
				myUpToDate = false;
				this.Invalidate();
			}
		}

		
		#endregion    //end public property overrides


		#region private functions and classes

		private int GetFontHeight()
		{
			Graphics g = this.CreateGraphics();
			SizeF sf_font = g.MeasureString("X",this.Font);
			g.Dispose();
			return  (int) sf_font.Height;
		}
		
		
		private void GetBitmaps()
		{
			if (myBitmap == null
				|| myAlphaBitmap == null
				|| myBitmap.Width != Width 
				|| myBitmap.Height != Height		
				|| myAlphaBitmap.Width != Width 
				|| myAlphaBitmap.Height != Height)
			{
				myBitmap = null;
				myAlphaBitmap = null;
			}
		if (myBitmap == null)
			{
				myBitmap = new Bitmap(this.ClientRectangle.Width,this.ClientRectangle.Height);//(Width,Height);
				myUpToDate = false;
			}
			if (!myUpToDate)
			{
				//Capture the TextBox control window

				this.SetStyle(ControlStyles.UserPaint,false);
				
				win32.CaptureWindow(this,ref myBitmap);

				this.SetStyle(ControlStyles.UserPaint,true);
				this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);
				this.BackColor = Color.FromArgb(myBackAlpha,myBackColor);

			}
			//--
			
			Rectangle r2 = new Rectangle(0,0,this.ClientRectangle.Width,this.ClientRectangle.Height);
			ImageAttributes tempImageAttr = new ImageAttributes();			

			//Found the color map code in the MS Help

			ColorMap[] tempColorMap = new ColorMap[1];
			tempColorMap[0] = new ColorMap();
			tempColorMap[0].OldColor = Color.FromArgb(255,myBackColor); 
			tempColorMap[0].NewColor = Color.FromArgb(myBackAlpha,myBackColor);

			tempImageAttr.SetRemapTable(tempColorMap);

			if (myAlphaBitmap != null)
				myAlphaBitmap.Dispose();
							
			myAlphaBitmap = new Bitmap(this.ClientRectangle.Width,this.ClientRectangle.Height);//(Width,Height);

			Graphics tempGraphics1 = Graphics.FromImage(myAlphaBitmap);
			tempGraphics1.DrawImage(myBitmap,r2,0,0,this.ClientRectangle.Width,this.ClientRectangle.Height,GraphicsUnit.Pixel,tempImageAttr);
			tempGraphics1.Dispose();

            if (this.Focused && (this.SelectionLength == 0) && this.mode == 1)
            {
                Graphics tempGraphics2 = Graphics.FromImage(myAlphaBitmap);
                if (myCaretState)
                {
                    //Draw the caret
                    Point caret = this.findCaret();
                    Pen p = new Pen(this.ForeColor, 1);
                    tempGraphics2.DrawLine(p, caret.X, caret.Y + 0, caret.X, caret.Y + myFontHeight + 2);
                    tempGraphics2.Dispose();
                }
            }
		}


		private Point findCaret() 
		{

			Point pointCaret = new Point(0);
			int i_char_loc = this.SelectionStart;
			IntPtr pi_char_loc = new IntPtr(i_char_loc);

			int i_point = win32.SendMessage(this.Handle,win32.EM_POSFROMCHAR,pi_char_loc,IntPtr.Zero);
			pointCaret = new Point(i_point);

			if (i_char_loc == 0) 
			{
				pointCaret = new Point(0);
			}
			else if (i_char_loc >= this.Text.Length)
			{
				pi_char_loc = new IntPtr(i_char_loc - 1);
				i_point = win32.SendMessage(this.Handle,win32.EM_POSFROMCHAR,pi_char_loc,IntPtr.Zero);
				pointCaret = new Point(i_point);

				Graphics g = this.CreateGraphics();
				String t1 = this.Text.Substring(this.Text.Length-1,1) + "X";
				SizeF sizet1 = g.MeasureString(t1,this.Font);
				SizeF sizex  = g.MeasureString("X",this.Font);
				g.Dispose();
				int xoffset = (int)(sizet1.Width - sizex.Width);
				pointCaret.X = pointCaret.X + xoffset;

				if (i_char_loc == this.Text.Length)
				{
					String slast = this.Text.Substring(Text.Length-1,1);
					if (slast == "\n")
					{
						pointCaret.X = 1;
						pointCaret.Y = pointCaret.Y + myFontHeight;
					}
				}

			}
			return pointCaret;
		}


		private void myTimer1_Tick(object sender, EventArgs e)
		{
			//Timer used to turn caret on and off for focused control

			myCaretState = !myCaretState;
			myCaretUpToDate = false;
			this.Invalidate();
		}


		private class uPictureBox : PictureBox 
		{
			public uPictureBox() 
			{
				this.SetStyle(ControlStyles.Selectable,false);
				this.SetStyle(ControlStyles.UserPaint,true);
				this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
				this.SetStyle(ControlStyles.DoubleBuffer,true);

				this.Cursor = null;
				this.Enabled = true; 
				this.SizeMode = PictureBoxSizeMode.Normal;
				
			}

			//uPictureBox
			protected override void WndProc(ref Message m)
			{
				if (m.Msg == win32.WM_LBUTTONDOWN 
					|| m.Msg == win32.WM_RBUTTONDOWN
					|| m.Msg == win32.WM_LBUTTONDBLCLK
					|| m.Msg == win32.WM_MOUSELEAVE
					|| m.Msg == win32.WM_MOUSEMOVE )
				{
					//Send the above messages back to the parent control
					win32.PostMessage(this.Parent.Handle,(uint) m.Msg,m.WParam,m.LParam);
				}

				else if (m.Msg == win32.WM_LBUTTONUP)
				{
					//??  for selects and such
					this.Parent.Invalidate();
				}


				base.WndProc (ref m);
			}


		}   // End uPictureBox Class


		#endregion  // end private functions and classes


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion


		#region New Public Properties

		[
		Category("Appearance"),
		Description("The alpha value used to blend the control's background. Valid values are 0 through 255."),
		Browsable(true),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)

		]
		public int BackAlpha
		{
			get { return myBackAlpha; }
			set 
			{
				int v = value;
				if (v > 255)
					v = 255;
				myBackAlpha = v;
				myUpToDate = false; 
				Invalidate();
			}
		}

		#endregion

          #region 移动命令
        private enum MoveCommand
        {
            None,
            Move,
            SizeLeft,
            SizeRight,
            SizeUp,
            SizeDown,
            SizeLeftUp,
            SizeLeftDown,
            SizeRightUp,
            SizeRightDown
        }
        /// <summary> 
        /// 当前命令 
        /// </summary> 
        private MoveCommand m_MoveCommand = MoveCommand.None;
        #endregion

        private Point m_MousePoint = Point.Empty;
        private Point m_MouseRight = Point.Empty;

        private int m_SamillSizeTop = 3;
        private int m_SamillSizeLeft = 5;

        /// <summary> 
        /// 根据鼠标位置获取执行的命令 
        /// </summary> 
        /// <param name="p_MousePoint"></param> 
        private MoveCommand GetCommand(Point p_MousePoint)
        {
            #region 四角
            if (p_MousePoint.X <= m_SamillSizeTop && p_MousePoint.Y <= m_SamillSizeTop) if (m_Size) return MoveCommand.SizeLeftUp;
            if (p_MousePoint.X <= m_SamillSizeTop && p_MousePoint.Y >= this.Height - m_SamillSizeLeft) if (m_Size) return MoveCommand.SizeLeftDown;
            if (p_MousePoint.X >= this.Width - m_SamillSizeLeft && p_MousePoint.Y <= m_SamillSizeTop) if (m_Size) return MoveCommand.SizeRightUp;
            if (p_MousePoint.X >= this.Width - m_SamillSizeLeft && p_MousePoint.Y >= this.Height - m_SamillSizeLeft) if (m_Size) return MoveCommand.SizeRightDown;
            #endregion

            #region 上下左右
            if (p_MousePoint.X <= m_SamillSizeTop) if (m_Size) return MoveCommand.SizeLeft;
            if (p_MousePoint.Y <= m_SamillSizeTop) if (m_Size) return MoveCommand.SizeUp;
            if (p_MousePoint.X >= this.Width - m_SamillSizeLeft) if (m_Size) return MoveCommand.SizeRight;
            if (p_MousePoint.Y >= this.Height - m_SamillSizeLeft) if (m_Size) return MoveCommand.SizeDown;
            #endregion


            if (m_Move && this.mode != 1) return MoveCommand.Move;
            return MoveCommand.None;

        }
        /// <summary> 
        /// 设置鼠标样式 
        /// </summary> 
        /// <param name="p_MousePoint"></param> 
        private void GetCursor(Point p_MousePoint)
        {
            MoveCommand _Command = GetCommand(p_MousePoint);
            switch (_Command)
            {
                #region 四角
                case MoveCommand.Move:
                    this.Cursor = Cursors.Hand;
                    return;
                case MoveCommand.SizeLeftUp:
                    this.Cursor = Cursors.SizeNWSE;
                    return;
                case MoveCommand.SizeLeftDown:
                    this.Cursor = Cursors.SizeNESW;
                    return;
                case MoveCommand.SizeRightUp:
                    this.Cursor = Cursors.SizeNESW;
                    return;
                case MoveCommand.SizeRightDown:
                    this.Cursor = Cursors.SizeNWSE;
                    return;
                #endregion

                #region 上下左右
                case MoveCommand.SizeLeft:
                    this.Cursor = Cursors.SizeWE;
                    return;
                case MoveCommand.SizeUp:
                    this.Cursor = Cursors.SizeNS;
                    return;
                case MoveCommand.SizeRight:
                    this.Cursor = Cursors.SizeWE;
                    return;
                case MoveCommand.SizeDown:
                    this.Cursor = Cursors.SizeNS;
                    return;
                #endregion
            }
        }

        private bool m_Move = true;
        /// <summary> 
        /// 是否能移动控件 
        /// </summary> 
        public bool IsMove { get { return m_Move; } set { m_Move = value; } }

        private bool m_Min = true;
        /// <summary> 
        /// 是否移动到最小区域 
        /// </summary> 
        public bool Min { get { return m_Min; } set { m_Min = value; } }

        private bool m_Max = true;
        /// <summary> 
        /// 是否移动到最大区域 
        /// </summary> 
        public bool Max { get { return m_Max; } set { m_Max = value; } }

        private bool m_Size = true;
        /// <summary> 
        /// 是否能设置大小 
        /// </summary> 
        public bool IsChangeSize { get { return m_Size; } set { m_Size = value; } }

        public delegate void ControlMoveEnd(Control sender);
        public event ControlMoveEnd MoveEnd;

	}  // End AlphaTextBox Class

}
