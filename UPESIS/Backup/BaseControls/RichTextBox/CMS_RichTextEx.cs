using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BaseControls
{
    public partial class CMS_RichTextEx :System.Windows.Forms.RichTextBox
    {
        public CMS_RichTextEx()
        {
            InitializeComponent();
        }

        public CMS_RichTextEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.richTextBox = this;
            this.richTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox.EnableAutoDragDrop = true;
        }
        public CMS_RichTextEx(System.Windows.Forms.RichTextBox richTextBox)
        {
            InitializeComponent();
            this.richTextBox = richTextBox;
            this.richTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox.EnableAutoDragDrop = true;
        }
        private bool isChangeColor = true;
        public bool IsChangeColor
        {
            get { return isChangeColor; }
            set { isChangeColor = value; }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (isChangeColor)
                this.BackColor = Color.PapayaWhip;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (isChangeColor)
                this.BackColor = Color.White;
        }
        private System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
        private void cms_RichText_Opened(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText.Length > 0)
            {
                CMcopy.Enabled = true;
                CMcut.Enabled = true;
                CMdel.Enabled = true;
            }
            else
            {
                CMcopy.Enabled = false;
                CMcut.Enabled = false;
                CMdel.Enabled = false;
            }

            if (richTextBox.CanUndo == true)
            {
                this.CMcancle.Enabled = true;
            }
            else
            {
                this.CMcancle.Enabled = false;
            }

            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                this.CMpaste.Enabled = true;
            }
            else
            {
                this.CMpaste.Enabled = false;
            }

            if (richTextBox.Text != "")
            {
                CMselectall.Enabled = true;
            }
            else
            {
                CMselectall.Enabled = false;
            }
        }

        //ÓÒ¼ü²Ëµ¥ ³·Ïú   
        private void CMcancle_Click(object sender, EventArgs e)
        {
            if (CMcancle.Enabled == true)
            {
                this.richTextBox.Undo();
                this.richTextBox.ClearUndo();
            }
        }

        //ÓÒ¼ü²Ëµ¥¼ôÇÐ   
        private void CMcut_Click(object sender, EventArgs e)
        {
            if (CMcut.Enabled == true)
            {
                this.richTextBox.Cut();
            }
        }

        //ÓÒ¼ü²Ëµ¥ ¸´ÖÆ   
        private void CMcopy_Click(object sender, EventArgs e)
        {
            if (CMcopy.Enabled == true)
            {
                richTextBox.Copy();
            }
        }

        //ÓÒ¼ü²Ëµ¥ Õ³Ìù   
        private void CMpaste_Click(object sender, EventArgs e)
        {
            if (CMpaste.Enabled == true)
            {
                richTextBox.Paste();
            }
        }

        //ÓÒ¼ü²Ëµ¥ É¾³ý   
        private void CMdel_Click(object sender, EventArgs e)
        {
            if (CMdel.Enabled == true)
            {
                richTextBox.SelectedText = "";
            }
        }

        //ÓÒ¼ü²Ëµ¥ È«Ñ¡   
        private void CMselectall_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        ////ÓÒ¼ü²Ëµ¥ ÔÄ¶ÁË³Ðò   
        //private void CMalign_Click(object sender, EventArgs e)
        //{
        //    if (CMalign.Checked == true)
        //    {
        //        richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        //    }
        //    else
        //    {
        //        richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        //    }
        //}

    }
}
