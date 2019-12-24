using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BaseControls.PictureBoxs
{
    /// <summary>
    /// 组件MyCheckBox，继承于CheckBox，复选框
    /// </summary>
    public partial class MyCheckBox : System.Windows.Forms.CheckBox
    {
        /// <summary>
        /// 无参构造方法
        /// </summary>
        public MyCheckBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 含参，即容器的构造方法
        /// </summary>
        /// <param name="container"></param>
        public MyCheckBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool ReadOnly = true;

        /// <summary>
        /// 重写键下事件，决定于ReadOnly
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (!ReadOnly)
                base.OnKeyDown(e);
        }

        /// <summary>
        /// 重写鼠标按下事件,决定于ReadOnly
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {
            if (!ReadOnly)
                base.OnMouseDown(mevent);
        }
    }
}