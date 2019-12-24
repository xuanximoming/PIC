using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BaseControls.PictureBoxs
{
    /// <summary>
    /// ���MyCheckBox���̳���CheckBox����ѡ��
    /// </summary>
    public partial class MyCheckBox : System.Windows.Forms.CheckBox
    {
        /// <summary>
        /// �޲ι��췽��
        /// </summary>
        public MyCheckBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���Σ��������Ĺ��췽��
        /// </summary>
        /// <param name="container"></param>
        public MyCheckBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool ReadOnly = true;

        /// <summary>
        /// ��д�����¼���������ReadOnly
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (!ReadOnly)
                base.OnKeyDown(e);
        }

        /// <summary>
        /// ��д��갴���¼�,������ReadOnly
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {
            if (!ReadOnly)
                base.OnMouseDown(mevent);
        }
    }
}