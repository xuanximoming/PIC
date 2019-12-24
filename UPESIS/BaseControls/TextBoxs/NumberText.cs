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
        /// ת��ǵĺ���(DBC case)
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <returns>����ַ���</returns>
        ///<remarks>
        ///ȫ�ǿո�Ϊ12288����ǿո�Ϊ32
        ///�����ַ����(33-126)��ȫ��(65281-65374)�Ķ�Ӧ��ϵ�ǣ������65248
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


        protected override void OnKeyPress(KeyPressEventArgs e) // ���η����ּ�
        {
            if (this.ReadOnly) // ֻ��, ������ 
            {
                return;
            }
            if ((int)e.KeyChar < 32) // �����, ������ 
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) // �����ּ�, ���������� 
            {
                e.Handled = true;
                return;
            }
            if ((int)e.KeyChar == 32)//�ո�,��������
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // ����Ctrl+V
        {
            if (keyData == (Keys)Shortcut.CtrlV) // ��ݼ� Ctrl+V ճ������ 
            {
                this.ClearSelection();
                string text = Clipboard.GetText();
                for (int k = 0; k < text.Length; k++) // can not use SendKeys.Send 
                { // ͨ����Ϣģ���������, SendKeys.Send()��̬�������� 
                    SendCharKey(text[k]);
                } return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void SendCharKey(char c) // ͨ����Ϣģ�����¼��
        {
            Message msg = new Message();
            msg.HWnd = this.Handle;
            msg.Msg = WM_CHAR; // ��������ַ���Ϣ 0x0102
            msg.WParam = (IntPtr)c;
            msg.LParam = IntPtr.Zero;
            base.WndProc(ref msg);
        }

        protected override void WndProc(ref Message m) // ����Mouse��Paste��Ϣ
        {
            if (m.Msg == WM_PASTE) // ѡ�������Ĳ˵���"ճ��"���� 
            {
                this.ClearSelection();
                SendKeys.Send(Clipboard.GetText()); // ģ��������� 
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void ClearSelection() // �����ǰTextBox��ѡ��
        {
            if (this.SelectionLength == 0) 
            { 
                return; 
            }
            int selLength = this.SelectedText.Length; 
            this.SelectionStart += this.SelectedText.Length; // �����ѡ��֮�� 
            this.SelectionLength = 0; 
            for (int k = 1; k <= selLength; k++) 
            { 
                this.DeleteText(Keys.Back); 
            }
        }
        
        private void DeleteText(Keys key) // ɾ���ַ�������SelectionStartֵ
        { 
            int selStart = this.SelectionStart; 
            if (key == Keys.Delete) // ת��Delete����ΪBackSpace����
            { 
                selStart += 1;
                if (selStart > base.Text.Length) 
                {
                    return; 
                } 
            } 
            if (selStart == 0 || selStart > base.Text.Length) // ����Ҫɾ�� 
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
