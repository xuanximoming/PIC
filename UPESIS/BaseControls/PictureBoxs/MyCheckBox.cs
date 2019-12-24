using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BaseControls.PictureBoxs
{
    public partial class MyCheckBox : System.Windows.Forms.CheckBox
    {
        public MyCheckBox()
        {
            InitializeComponent();
        }

        public MyCheckBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public bool ReadOnly = true;
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (!ReadOnly)
                base.OnKeyDown(e);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {
            if (!ReadOnly)
                base.OnMouseDown(mevent);
        }
    }
}
