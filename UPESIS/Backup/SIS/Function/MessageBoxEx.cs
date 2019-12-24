using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Crownwood.DotNetMagic.Common;
using Crownwood.DotNetMagic.Controls;
using Crownwood.DotNetMagic.Forms;
using System.Configuration;
using System.Xml;

namespace SIS
{
    public class MessageBoxEx
    {
        private static DialogResult ShowWindow(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        {
            MessageWindow MsgWin = new MessageWindow();
            MsgWin.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = MsgWin.DrawWindow(owner, text, caption, buttons, icon, defaultbutton);
            MsgWin.Dispose();
            return result;
        }

        public static DialogResult Show(string text)
        {
            return ShowWindow(null, text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption)
        {
            return ShowWindow(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return ShowWindow(null, text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return ShowWindow(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return ShowWindow(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return ShowWindow(null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return ShowWindow(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return ShowWindow(null, text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return ShowWindow(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return ShowWindow(owner, text, caption, buttons, icon, defaultButton);
        }
    }

    internal class MessageWindow : DotNetMagicForm
    {
        private ButtonWithStyle vbutton1;
        private ButtonWithStyle vbutton2;
        private ButtonWithStyle vbutton3;
        private PictureBox vPicBox;
        private Panel vPanel1;
        private Label vLabel1;
        private bool vBool1 = true;
        private bool vBool2 = true;
        private bool vBool3 = true;
        private MessageBoxButtons msgBoxButtons;
        private IContainer vContainer1 = null;

        [DllImport("winmm.dll", EntryPoint = "PlaySound")]
        public static extern int PlaySound(
            string lpszName,
            int hModule,
            int dwFlags
        );
        [DllImport("user32.dll", EntryPoint = "DrawIconEx")]
        public static extern int DrawIconEx(
            IntPtr hdc,
            int xLeft,
            int yTop,
            IntPtr hIcon,
            int cxWidth,
            int cyWidth,
            int istepIfAniCur,
            IntPtr hbrFlickerFreeDraw,
            int diFlags
        );

        public MessageWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.vbutton1 = new ButtonWithStyle();
            this.vbutton2 = new ButtonWithStyle();
            this.vbutton3 = new ButtonWithStyle();
            this.vPicBox = new PictureBox();
            this.vPanel1 = new Panel();
            this.vLabel1 = new Label();
            base.SuspendLayout();
            //vbutton1
            this.vbutton1.Location = new Point(26, 85);
            this.vbutton1.Name = "vbutton1";
            this.vbutton1.Size = new Size(77, 24);
            this.vbutton1.TabIndex = 0;
            this.vbutton1.Text = "&OK";
            this.vbutton1.AlwaysDrawBorder = true;
            this.vbutton1.Click += new EventHandler(this.Button1_Click);
            //vbutton2
            this.vbutton2.Location = new Point(109, 85);
            this.vbutton2.Name = "vbutton2";
            this.vbutton2.Size = new Size(77, 24);
            this.vbutton2.TabIndex = 1;
            this.vbutton2.Text = "&Cancel";
            this.vbutton2.AlwaysDrawBorder = true;
            this.vbutton2.Click += new EventHandler(this.Button2_Click);
            //vbutton3
            this.vbutton3.Location = new Point(192, 85);
            this.vbutton3.Name = "vbutton3";
            this.vbutton3.Size = new Size(77, 24);
            this.vbutton3.TabIndex = 2;
            this.vbutton3.Text = "&Ignore";
            this.vbutton3.AlwaysDrawBorder = true;
            this.vbutton3.Click += new EventHandler(this.Button3_Click);
            //vPicBox
            this.vPicBox.BackColor = Color.Transparent;
            this.vPicBox.Location = new Point(10, 18);
            this.vPicBox.Name = "vPicBox";
            this.vPicBox.Size = new Size(32, 32);
            this.vPicBox.TabIndex = 3;
            this.vPicBox.TabStop = false;
            //vPanel1
            this.vPanel1.Name = "vPanel1";
            this.vPanel1.TabIndex = 4;
            this.vPanel1.Dock = DockStyle.Fill;
            this.vPanel1.BackColor = Color.FromArgb(191, 219, 255);
            //vLabel1
            this.vLabel1.AutoSize = false;
            this.vLabel1.Location = new Point(53, 10);
            this.vLabel1.Size = new Size(225, 53);
            this.vLabel1.Text = String.Empty;

            base.Controls.Add(this.vPanel1);
            this.vPanel1.Controls.Add(this.vbutton1);
            this.vPanel1.Controls.Add(this.vbutton2);
            this.vPanel1.Controls.Add(this.vbutton3);
            this.vPanel1.Controls.Add(this.vPicBox);
            this.vPanel1.Controls.Add(this.vLabel1);

            base.ControlBox = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(290, 0x79);
            base.Style = VisualStyle.Office2007Blue;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.ShowInTaskbar = false;
            base.ShowIcon = false;
            base.Name = "MessageBoxDialog";
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.ResumeLayout(false);
        }

        public DialogResult DrawWindow(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        {
            this.msgBoxButtons = buttons;
            this.Text = (caption != String.Empty) ? caption : " ";
            this.vLabel1.Text = text;
            if (icon != MessageBoxIcon.None)
                this.vPicBox.Image = this.DrawIcon(icon);
            else
            {
                this.vPicBox.Image = null;
                this.vPicBox.Visible = false;
            }
            if (((buttons == MessageBoxButtons.OKCancel) || (buttons == MessageBoxButtons.RetryCancel)) || (buttons == MessageBoxButtons.YesNo))
            {
                this.vbutton3.Visible = false;
                this.vBool3 = false;
            }
            else if (buttons == MessageBoxButtons.OK)
            {
                this.vbutton2.Visible = false;
                this.vbutton3.Visible = false;
                this.vBool2 = false;
                this.vBool3 = false;
            }
            if (buttons == MessageBoxButtons.OK)
            {
                this.AcceptButton = this.vbutton1;
                this.CancelButton = this.vbutton1;
            }
            else if (((buttons == MessageBoxButtons.OKCancel) || (buttons == MessageBoxButtons.RetryCancel)) || (buttons == MessageBoxButtons.YesNo))
            {
                base.AcceptButton = this.vbutton1;
                base.CancelButton = this.vbutton2;
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                base.AcceptButton = this.vbutton1;
                base.CancelButton = this.vbutton3;
            }
            this.SetButtonText(buttons);
            if ((defaultbutton == MessageBoxDefaultButton.Button1) && this.vBool1)
                this.vbutton1.Select();
            else if ((defaultbutton == MessageBoxDefaultButton.Button2) && this.vBool2)
                this.vbutton2.Select();
            else if ((defaultbutton == MessageBoxDefaultButton.Button3) && this.vBool3)
                this.vbutton3.Select();
            this.SetLabelSize();
            this.SetLocation();
            this.ChangeStyle();
            if (icon == MessageBoxIcon.Question)
                PlaySound("SystemQuestion", 1, 3);
            else if (icon == MessageBoxIcon.Asterisk)
                PlaySound("SystemAsterisk", 2, 3);
            else
                PlaySound("SystemExclamation", 3, 3);
            return base.ShowDialog(owner);
        }

        private void ChangeStyle()
        {
            this.vbutton1.Style = VisualStyle.Office2007Blue;
            this.vbutton2.Style = VisualStyle.Office2007Blue;
            this.vbutton3.Style = VisualStyle.Office2007Blue;
            this.vPanel1.BackColor = Color.FromArgb(191, 219, 255);//Blue
            this.ForeColor = Color.Black;
            base.Style = VisualStyle.Office2007Blue;
            //if (Config.Style == VisualStyle.Office2007Blue)
            //{
            //    this.vbutton1.Style = VisualStyle.Office2007Blue;
            //    this.vbutton2.Style = VisualStyle.Office2007Blue;
            //    this.vbutton3.Style = VisualStyle.Office2007Blue;
            //    this.vPanel1.BackColor = Color.FromArgb(191, 219, 255);//Blue
            //    this.ForeColor = Color.Black;
            //    base.Style = VisualStyle.Office2007Blue;
            //}
            //else if (Config.Style == VisualStyle.Office2007Silver)
            //{
            //    this.vbutton1.Style = VisualStyle.Office2007Silver;
            //    this.vbutton2.Style = VisualStyle.Office2007Silver;
            //    this.vbutton3.Style = VisualStyle.Office2007Silver;
            //    this.vPanel1.BackColor = Color.FromArgb(208, 212, 221);//Silver
            //    this.ForeColor = Color.Black;
            //    base.Style = VisualStyle.Office2007Silver;
            //}
            //else if (Config.Style == VisualStyle.Office2007Black)
            //{
            //    this.vbutton1.Style = VisualStyle.Office2007Black;
            //    this.vbutton2.Style = VisualStyle.Office2007Black;
            //    this.vbutton3.Style = VisualStyle.Office2007Black;
            //    this.vPanel1.BackColor = Color.FromArgb(83, 83, 83);//Black
            //    this.ForeColor = Color.White;
            //    base.Style = VisualStyle.Office2007Black;
            //}
            //else
            //{
            //    this.vbutton1.Style = VisualStyle.Plain;
            //    this.vbutton2.Style = VisualStyle.Plain;
            //    this.vbutton3.Style = VisualStyle.Plain;
            //    this.vPanel1.BackColor = Color.White;
            //}
        }

        private void SetButtonText(MessageBoxButtons buttons)
        {
            if (buttons == MessageBoxButtons.AbortRetryIgnore)
            {
                this.vbutton1.Text = "中断(&A)";
                this.vbutton2.Text = "重试(&T)";
                this.vbutton3.Text = "忽略(&I)";
            }
            else if (buttons == MessageBoxButtons.OK)
                this.vbutton1.Text = "确定(&O)";
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                this.vbutton1.Text = "确定(&O)";
                this.vbutton2.Text = "取消(&C)";
            }
            else if (buttons == MessageBoxButtons.RetryCancel)
            {
                this.vbutton1.Text = "重试(&T)";
                this.vbutton2.Text = "取消(&C)";
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                this.vbutton1.Text = "是(&Y)";
                this.vbutton2.Text = "否(&N)";
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                this.vbutton1.Text = "是(&Y)";
                this.vbutton2.Text = "否(&N)";
                this.vbutton3.Text = "取消(&C)";
            }
        }

        private Image DrawIcon(MessageBoxIcon icon)
        {
            Icon asterisk = null;
            if (icon == MessageBoxIcon.Asterisk)
                asterisk = SystemIcons.Asterisk;
            else if ((icon == MessageBoxIcon.Hand) || (icon == MessageBoxIcon.Hand))
                asterisk = SystemIcons.Error;
            else if (icon == MessageBoxIcon.Exclamation)
                asterisk = SystemIcons.Exclamation;
            else if (icon == MessageBoxIcon.Hand)
                asterisk = SystemIcons.Hand;
            else if (icon == MessageBoxIcon.Asterisk)
                asterisk = SystemIcons.Information;
            else if (icon == MessageBoxIcon.Question)
                asterisk = SystemIcons.Question;
            else if (icon == MessageBoxIcon.Exclamation)
                asterisk = SystemIcons.Warning;
            Bitmap image = new Bitmap(asterisk.Width, asterisk.Height);
            image.MakeTransparent();
            using (Graphics graphics = Graphics.FromImage(image))
            {
                if (((Environment.Version.Build <= 0xe79) && (Environment.Version.Revision == 0x120)) &&((Environment.Version.Major == 1) && (Environment.Version.Minor == 0)))
                {
                    IntPtr hdc = graphics.GetHdc();
                    try
                    {
                        DrawIconEx(hdc, 0, 0, asterisk.Handle, asterisk.Width, asterisk.Height, 0, IntPtr.Zero, 3);


                        return image;
                    }
                    finally
                    {
                        graphics.ReleaseHdc(hdc);
                    }
                }
                if (asterisk.Handle == IntPtr.Zero)
                    return image;
                try
                {
                    graphics.DrawIcon(asterisk, 0, 0);
                    return image;
                }
                catch
                {
                    return image;
                }
            }
        }

        private void SetLabelSize()
        {
            int DefaultWordLength = 36;
            int DefaultNumberOfRows = 4;
            int DefaultRowHeight = DefaultWordLength / DefaultNumberOfRows;
            int TextTrothLength = (this.vLabel1.Text.Length < 1) ? 0 : 0;// Config.GetCnStringLength(this.vLabel1.Text.Trim());
            int TrothNumberOfRows = 0;
            if (TextTrothLength != 0)
                TrothNumberOfRows = (TextTrothLength % DefaultWordLength != 0) ? TextTrothLength / DefaultWordLength + 1 :TextTrothLength / DefaultWordLength;
            if (TrothNumberOfRows == 1 && this.vPicBox.Image == null)
                this.vLabel1.TextAlign = ContentAlignment.MiddleCenter;
            else if (TrothNumberOfRows == 1 && this.vPicBox.Image != null)
                this.vLabel1.TextAlign = ContentAlignment.MiddleLeft;
            else if (TrothNumberOfRows > 4)
            {
                int AddHight = (TrothNumberOfRows - DefaultNumberOfRows) * DefaultRowHeight;
                this.vLabel1.Size = new Size(this.vLabel1.Size.Width, this.vLabel1.Size.Height + AddHight);
                base.ClientSize = new Size(base.ClientSize.Width, base.ClientSize.Height + AddHight);
            }
        }

        private void SetLocation()
        {
            Size empty = Size.Empty;
            int num = 6;
            int num2 = 40;
            int num3 = 10;
            if (this.vPicBox.Image != null)
                this.vLabel1.Left = this.vPicBox.Bounds.Right + 0x10;
            else
                this.vLabel1.Left = this.vPicBox.Left;

            int num5 = Math.Max(this.vLabel1.Bounds.Bottom, this.vPicBox.Bounds.Bottom) + 0x10;
            this.vbutton1.Top = num5;
            this.vbutton2.Top = num5;
            this.vbutton3.Top = num5;
            int num6 = (this.vbutton1.Width + (this.vBool2 ? (this.vbutton2.Width + num) : 0)) + (this.vBool3 ? (this.vbutton3.Width + num) : 0);
            int num7 = num6 + (num2 * 2);
            if (num6 < (this.vLabel1.Bounds.Right + num3))
                num7 = this.vLabel1.Bounds.Right + num3;
            else
                this.vLabel1.Width += (num7 - this.vLabel1.Bounds.Right) - num3;
            int num8 = (num7 - num6) / 2;
            this.vbutton1.Left = num8;
            num8 += this.vbutton1.Width + num;
            if (this.vBool2)
            {
                this.vbutton2.Left = num8;
                num8 += this.vbutton2.Width + num;
            }
            if (this.vBool3)
            {
                this.vbutton3.Left = num8;
                num8 += this.vbutton3.Width + num;
            }
            empty = new Size((this.vLabel1.Bounds.Right + num3) + (SystemInformation.FixedFrameBorderSize.Width * 2), ((this.vbutton1.Bounds.Bottom + num3) + (SystemInformation.FixedFrameBorderSize.Height * 2)) + SystemInformation.CaptionHeight);
            base.Size = empty;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult oK = DialogResult.OK;
            if ((this.msgBoxButtons == MessageBoxButtons.OK) || (this.msgBoxButtons == MessageBoxButtons.OKCancel))
            {
                oK = DialogResult.OK;
            }
            else if ((this.msgBoxButtons == MessageBoxButtons.YesNo) || (this.msgBoxButtons == MessageBoxButtons.YesNoCancel))
            {
                oK = DialogResult.Yes;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                oK = DialogResult.Abort;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.RetryCancel)
            {
                oK = DialogResult.Retry;
            }
            base.DialogResult = oK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult cancel = DialogResult.Cancel;
            if (this.msgBoxButtons == MessageBoxButtons.OKCancel)
            {
                cancel = DialogResult.Cancel;
            }
            else if ((this.msgBoxButtons == MessageBoxButtons.YesNo) || (this.msgBoxButtons ==MessageBoxButtons.YesNoCancel))
            {
                cancel = DialogResult.No;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                cancel = DialogResult.Retry;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.RetryCancel)
            {
                cancel = DialogResult.Cancel;
            }
            base.DialogResult = cancel;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult cancel = DialogResult.Cancel;
            if (this.msgBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                cancel = DialogResult.Ignore;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.YesNoCancel)
            {
                cancel = DialogResult.Cancel;
            }
            base.DialogResult = cancel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.vContainer1 != null))
            {
                this.vContainer1.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}