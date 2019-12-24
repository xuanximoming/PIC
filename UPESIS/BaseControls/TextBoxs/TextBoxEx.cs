using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace BaseControls
{
    public partial class TextBoxEx : TextBox
    {
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_MOUSEUP = 0x202;
        private bool isDraging = false;
        private bool isMouseDown = false;
        private Label lb;
        private Timer t;

        public TextBoxEx()
        {
            InitializeComponent();
            lb = new Label();
            lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lb.Visible = true;
            lb.Size = new System.Drawing.Size(1, 23);
            lb.Visible = false;
            this.Controls.Add(lb);
        }

        protected override void WndProc(ref Message m)
        {
            if (this.isMouseDown)
            {
                if (m.Msg == WM_MOUSEUP && !this.isDraging)
                {
                    Point p = Control.MousePosition;
                    Point po = this.PointToClient(p);
                    int index = this.GetCharIndexFromPosition(po);
                    this.SelectionStart = index;
                    this.SelectionLength = 0;
                    this.isMouseDown = false;
                }
                if (m.Msg == WM_MOUSEMOVE)
                {
                    this.isMouseDown = false;
                    string s = this.Handle.ToString() + ";" + this.SelectionStart.ToString() + ";" + this.SelectionLength.ToString() + ";" + this.SelectedText;
                    Clipboard.SetText(s);
                    this.isDraging = true;
                    this.DoDragDrop(this.SelectedText, DragDropEffects.Move);
                }
            }
            if (m.Msg == WM_LBUTTONDOWN)
            {
                Point p = Control.MousePosition;
                int index = this.GetCharIndexFromPosition(this.PointToClient(p));
                if (this.SelectionLength > 0 && this.SelectionStart <= index && (this.SelectionStart + this.SelectionLength) >= index)
                    this.isMouseDown = true;
                else
                    base.WndProc(ref m);
            }
            else
                base.WndProc(ref m);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            Point insert = new Point(drgevent.X, drgevent.Y);
            Point p = this.PointToClient(insert);
            int index = this.GetCharIndexFromPosition(p);
            int start = this.SelectionStart;
            int length = this.SelectionLength;
            string s = Clipboard.GetText();
            int first = s.IndexOf(';');
            string handle = s.Substring(0, first);
            int second = s.IndexOf(';', handle.Length + 1);
            string selectionStart = s.Substring(handle.Length + 1, second - first - 1);
            int third = s.IndexOf(';', handle.Length + selectionStart.Length + 2);
            string selectionLength = s.Substring(handle.Length + selectionStart.Length + 2, third - second - 1);
            string dragData = s.Substring(handle.Length + selectionStart.Length + selectionLength.Length + 3);
            if (handle != this.Handle.ToString())
            {
                start = Convert.ToInt32(selectionStart);
                int ip = Convert.ToInt32(handle);
                TextBoxEx t = (TextBoxEx)Control.FromHandle((IntPtr)ip);
                t.Text = t.Text.Remove(start, Convert.ToInt32(selectionLength));
                t.lb.Visible = false;
                this.Text = this.Text.Insert(index, dragData);
                this.SelectionStart = index + dragData.Length;
                this.Focus();
            }
            else
            {
                if (start > index)
                {
                    this.Text = this.Text.Remove(start, length);
                    this.Text = this.Text.Insert(index, dragData);
                    this.Select(index, dragData.Length);
                }
                if ((start + length) <= index)
                {
                    if (index == this.Text.Length - 1)
                    {
                        Point po = this.GetPositionFromCharIndex(index);
                        Graphics g = this.CreateGraphics();
                        float width = g.MeasureString(this.Text.Substring(index, 1), this.Font).Width;
                        if (p.X - po.X < width)
                        {
                            this.Text = this.Text.Insert(index, dragData);
                            this.Text = this.Text.Remove(start, length);
                            this.Select(index - dragData.Length, dragData.Length);
                        }
                        else
                        {
                            this.Text = this.Text.Insert(index + 1, dragData);
                            this.Text = this.Text.Remove(start, length);
                            this.Select(index + 1 - dragData.Length, dragData.Length);
                        }
                    }
                    else
                    {
                        this.Text = this.Text.Insert(index, dragData);
                        this.Text = this.Text.Remove(start, length);
                        this.Select(index - dragData.Length, dragData.Length);
                    }
                }
            }
            this.lb.Visible = false;
            this.isDraging = false;
            base.OnDragDrop(drgevent);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            drgevent.Effect = System.Windows.Forms.DragDropEffects.Move;
            base.OnDragEnter(drgevent);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if (this.isDraging)
            {
                Point p = Control.MousePosition;
                Point po = this.PointToClient(p);
                int index = this.GetCharIndexFromPosition(po);
                Point pt = this.GetPositionFromCharIndex(index);
                if (index == this.Text.Length - 1)
                {
                    Graphics g = this.CreateGraphics();
                    int width = Convert.ToInt32(g.MeasureString(this.Text.Substring(index, 1), this.Font).Width);
                    if (po.X - pt.X < width)
                        this.lb.Location = pt;
                    else
                        this.lb.Location = new Point(pt.X + width, pt.Y);
                }
                else
                    this.lb.Location = pt;
                this.lb.Height = this.Font.Height;
                this.lb.Visible = true;
            }
            base.OnDragOver(drgevent);
        }

        private void TextBoxEx_TextChanged(object sender, EventArgs e)
        {
            this.Text = ChangeTextBox(this.Text);
        }
        private string ChangeTextBox(string str)
        {
            string strTest = str.Replace("\r\n", "\r").Replace('\n', '\r').Replace("\r", "\r\n");
            return strTest;
        }
    }
}
