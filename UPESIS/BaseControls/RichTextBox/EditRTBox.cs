using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BaseControls
{
    public partial class EditRTBox : UserControl
    {
        private List<eLinkText> eLinkTexts;
        private eLinkText CurrentELinkText;
        private bool isLinkClick = false;
        private string linkText = "";

        private struct eLinkText
        {
            public List<string> Texts;
            public int TextStart;
            public int Index;
        }

        public EditRTBox()
        {
            InitializeComponent();
            CMS_RichTextEx cms = new CMS_RichTextEx(this.richTextBox);

        }

        public void SetLinkText(string text)
        {
            this.linkText = text;
            string[] ts = text.Split(']');
            List<string> results = new List<string>();
            for (int i = 0; i < ts.Length; i++)
            {
                string[] rr = ts[i].Split('[');
                foreach (string r in rr)
                {
                    if (r != "")
                        results.Add(r);
                }
            }
            eLinkTexts = new List<eLinkText>();
            for (int i = 0; i < results.Count; i++)
            {
                string[] rr = results[i].Split('|');
                eLinkText elt = new eLinkText();
                elt.Texts = new List<string>();
                for (int j = 0; j < rr.Length; j++)
                {
                    if (rr[j] != "")
                    {
                        elt.Texts.Add(rr[j]);
                        if (j == 0)
                        {
                            if (rr.Length == 1)
                            {
                                this.richTextBox.SelectedText += rr[j];
                                elt.TextStart = this.richTextBox.TextLength - rr[j].Length;
                            }
                            else
                            {
                                this.richTextBox.InsertLink(rr[j], this.richTextBox.TextLength);
                                elt.TextStart = this.richTextBox.TextLength - rr[j].Length;
                            }

                        }
                    }
                }
                elt.Index = i;
                eLinkTexts.Add(elt);
            }
        }

        public string GetLinkText()
        {
            return this.linkText;
        }

        private void richTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            Graphics g = this.richTextBox.CreateGraphics();
            SizeF s = g.MeasureString(this.richTextBox.Text, this.richTextBox.Font);
            float height = s.Height;
            this.Height = e.NewRectangle.Height + (int)(height * 3 / 2);
        }
        private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            this.isLinkClick = true;
            this.cms_Show.Items.Clear();
            foreach (eLinkText elt in eLinkTexts)
            {
                if (elt.Texts[0] == e.LinkText)
                {
                    this.CurrentELinkText = elt;
                    int length = -1, j = -1;
                    for (int i = 0; i < elt.Texts.Count; i++)
                    {
                        this.cms_Show.Items.Add(elt.Texts[i]);
                        this.cms_Show.Items[i].ToolTipText = elt.Texts[i];
                        if (elt.Texts[i].Length > length)
                        {
                            length = elt.Texts[i].Length;
                            j = i;
                        }
                    }
                    Point p = this.richTextBox.GetPositionFromCharIndex(elt.TextStart);
                    this.cms_Show.Show(this.richTextBox, p.X, p.Y + this.richTextBox.Font.Height);
                }
            }
        }


        private void cms_Show_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.richTextBox.Select(this.CurrentELinkText.TextStart, this.CurrentELinkText.Texts[0].Length);
            this.richTextBox.SelectedText = "";
            int len = this.CurrentELinkText.Texts[0].Length - e.ClickedItem.Text.ToString().Length;
            if (len != 0)
            {
                for (int i = this.CurrentELinkText.Index + 1; i < eLinkTexts.Count; i++)
                {
                    eLinkText elt = eLinkTexts[i];
                    elt.TextStart -= len;
                    eLinkTexts[i] = elt;
                }
            }
            this.richTextBox.InsertLink(e.ClickedItem.Text.ToString(), this.CurrentELinkText.TextStart);
            string t = this.CurrentELinkText.Texts[0];
            int index = this.cms_Show.Items.IndexOf(e.ClickedItem);
            this.CurrentELinkText.Texts[0] = this.CurrentELinkText.Texts[index];
            this.CurrentELinkText.Texts[index] = t;
            this.cms_Show.Visible = false;
        }

        private void richTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.isLinkClick && this.cms_Show.Visible)
                this.cms_Show.Hide();
            this.isLinkClick = false;
        }

    }
}
