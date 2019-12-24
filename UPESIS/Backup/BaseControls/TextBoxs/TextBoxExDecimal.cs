using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BaseControls
{
    //    public partial class TextBoxExDecimal : Component
    //    {
    //        public TextBoxExDecimal()
    //        {
    //            InitializeComponent();
    //        }

    //        public TextBoxExDecimal(IContainer container)
    //        {
    //            container.Add(this);

    //            InitializeComponent();
    //        }
    //    }
    //}
    public partial class TextBoxExDecimal : System.Windows.Forms.TextBox
    {
        public const int WM_CONTEXTMENU = 0x007b;//�Ҽ��˵���Ϣ 
        public const int WM_CHAR = 0x0102;       //�����ַ���Ϣ����������ģ����뷨����ĺ����������Ϣ��
        public const int WM_CUT = 0x0300;        //�����ʹ���Ϣ��һ���༭���combobox��ɾ����ǰѡ����ı�
        public const int WM_COPY = 0x0301;       //�����ʹ���Ϣ��һ���༭���combobox�����Ƶ�ǰѡ����ı���������
        public const int WM_PASTE = 0x0302;      //�����ʹ���Ϣ��editcontrol��combobox�Ӽ������еõ�����
        public const int WM_CLEAR = 0x0303;      //�����ʹ���Ϣ��editcontrol��combobox�����ǰѡ������ݣ�
        public const int WM_UNDO = 0x0304;        //�����ʹ���Ϣ��editcontrol��combobox�������һ�β���

        public TextBoxExDecimal()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
         public TextBoxExDecimal(IContainer container)
         {
             container.Add(this);

             InitializeComponent();
         }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CHAR:
                    System.Console.WriteLine(m.WParam);
                    bool isSign = ((int)m.WParam == 45);
                    bool isNum = ((int)m.WParam >= 48) && ((int)m.WParam <= 57);
                    bool isBack = (int)m.WParam == (int)Keys.Back;
                    bool isDelete = (int)m.WParam == (int)Keys.Delete;//ʵ��������һ��"."��
                    bool isCtr = ((int)m.WParam == 24) || ((int)m.WParam == 22) || ((int)m.WParam == 26) || ((int)m.WParam == 3);

                    if (isNum || isBack || isCtr)
                    {
                        base.WndProc(ref m);
                    }
                    if (isSign)
                    {
                        if (this.SelectionStart != 0)
                        {
                            break;
                        }
                        base.WndProc(ref m);
                        break;
                    }
                    if (isDelete)
                    {
                        if (this.Text.IndexOf(".") < 0)
                        {
                            base.WndProc(ref m);
                        }
                    }
                    if ((int)m.WParam == 1)
                    {
                        this.SelectAll();
                    }
                    break;
                case WM_PASTE:
                    IDataObject iData = Clipboard.GetDataObject();//ȡ���������

                    if (iData.GetDataPresent(DataFormats.Text)) //�ж��Ƿ���Text
                    {
                        string str = (string)iData.GetData(DataFormats.Text);//ȡ����
                        if (MatchNumber(str))
                        {
                            base.WndProc(ref m);
                            break;
                        }
                    }
                    m.Result = (IntPtr)0;//������ճ��
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private bool MatchNumber(string ClipboardText)
        {
            int index = 0;
            string strNum = "-0.123456789";

            index = ClipboardText.IndexOf(strNum[0]);
            if (index >= 0)
            {
                if (index > 0)
                {
                    return false;
                }
                index = this.SelectionStart;
                if (index > 0)
                {
                    return false;
                }
            }

            index = ClipboardText.IndexOf(strNum[2]);
            if (index != -1)
            {
                index = this.Text.IndexOf(strNum[2]);
                if (index != -1)
                {
                    return false;
                }
            }

            for (int i = 0; i < ClipboardText.Length; i++)
            {
                index = strNum.IndexOf(ClipboardText);
                if (index < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}