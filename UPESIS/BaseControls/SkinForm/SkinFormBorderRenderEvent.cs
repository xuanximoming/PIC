﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BaseControls.SkinForm
{
    /* 作者：Starts_2000
     * 日期：2009-09-20
     * 网站：http://www.csharpwin.com CS 程序员之窗。
     * 你可以免费使用或修改以下代码，但请保留版权信息。
     * 具体请查看 CS程序员之窗开源协议（http://www.csharpwin.com/csol.html）。
     */

    public delegate void SkinFormBorderRenderEventHandler(
        object sender,
        SkinFormBorderRenderEventArgs e);

    public class SkinFormBorderRenderEventArgs : PaintEventArgs
    {
        private SkinFormCtl _skinForm;
        private bool _active;

        public SkinFormBorderRenderEventArgs(
            SkinFormCtl skinForm,
            Graphics g,
            Rectangle clipRect,
            bool active)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
            _active = active;
        }

        public SkinFormCtl SkinForm
        {
            get { return _skinForm; }
        }

        public bool Active
        {
            get { return _active; }
        }
    }
}
