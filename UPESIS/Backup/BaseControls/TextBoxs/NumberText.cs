using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseControls
{
    public partial class NumberText : TextBox
    {
        private int WM_CHAR = 0x0102;
        private int WM_PASTE = 0x0302;
        private int numberCount = 3;

        public int NumberCount
        {
            get
            {
               return this.numberCount;
            }
            set
            {
                this.numberCount = value;
            }
        }

        public NumberText()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public char ToDBC(char input)
        {
            if (input == 12288)
            {
                input = (char)32;
            }
            if (input > 65280 && input < 65375)
            {
                input = (char)(input - 65248);
            }
            return input;
        }


        protected override void OnKeyPress(KeyPressEventArgs e) // 屏蔽非数字键
        {
            if (this.ReadOnly) // 只读, 不处理 
            {
                return;
            }
            if ((int)e.KeyChar < 32) // 特殊键, 不处理 
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) // 非数字键, 放弃该输入 
            {
                e.Handled = true;
                return;
            }
            if ((int)e.KeyChar == 32)//空格,放弃输入
            {
                e.Handled = true;
                return;
            }
            if (this.SelectionLength == 0 && this.Text.Length >= this.numberCount)
            {
                e.Handled = true;
                return;
            }
            char text = this.ToDBC(e.KeyChar);
            if (text != e.KeyChar)
            {
                e.KeyChar = text;
            }
            base.OnKeyPress(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // 捕获Ctrl+V
        {
            if (keyData == (Keys)Shortcut.CtrlV) // 快捷键 Ctrl+V 粘贴操作 
            {
                this.ClearSelection();
                string text = Clipboard.GetText();
                for (int k = 0; k < text.Length; k++) // can not use SendKeys.Send 
                { // 通过消息模拟键盘输入, SendKeys.Send()静态方法不行 
                    SendCharKey(text[k]);
                } return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void SendCharKey(char c) // 通过消息模拟键盘录入
        {
            Message msg = new Message();
            msg.HWnd = this.Handle;
            msg.Msg = WM_CHAR; // 输入键盘字符消息 0x0102
            msg.WParam = (IntPtr)c;
            msg.LParam = IntPtr.Zero;
            base.WndProc(ref msg);
        }

        protected override void WndProc(ref Message m) // 捕获Mouse的Paste消息
        {
            if (m.Msg == WM_PASTE) // 选择上下文菜单的"粘贴"操作 
            {
                this.ClearSelection();
                SendKeys.Send(Clipboard.GetText()); // 模拟键盘输入 
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void ClearSelection() // 清除当前TextBox的选择
        {
            if (this.SelectionLength == 0) 
            { 
                return; 
            }
            int selLength = this.SelectedText.Length; 
            this.SelectionStart += this.SelectedText.Length; // 光标在选择之后 
            this.SelectionLength = 0; 
            for (int k = 1; k <= selLength; k++) 
            { 
                this.DeleteText(Keys.Back); 
            }
        }
        
        private void DeleteText(Keys key) // 删除字符并计算SelectionStart值
        { 
            int selStart = this.SelectionStart; 
            if (key == Keys.Delete) // 转换Delete操作为BackSpace操作
            { 
                selStart += 1;
                if (selStart > base.Text.Length) 
                {
                    return; 
                } 
            } 
            if (selStart == 0 || selStart > base.Text.Length) // 不需要删除 
            { 
                return; 
            } 
            if (selStart == 1 && base.Text.Length == 1)
            {
                base.Text = ""; 
                base.SelectionStart = 0; 
            } 
            else // selStart > 0 
            { 
                base.Text = base.Text.Substring(0, selStart - 1) + base.Text.Substring(selStart, base.Text.Length - selStart); 
                base.SelectionStart = selStart - 1; 
            }
        }

    }
}
