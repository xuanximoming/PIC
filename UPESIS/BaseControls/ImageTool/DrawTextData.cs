﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BaseControls.ImageTool
{
    /* 作者：Starts_2000
     * 日期：2009-09-08
     * 网站：http://www.csharpwin.com CS 程序员之窗。
     * 你可以免费使用或修改以下代码，但请保留版权信息。
     * 具体请查看 CS程序员之窗开源协议（http://www.csharpwin.com/csol.html）。
     */
    internal class DrawTextData
    {
        private string _text;
        private Font _font;
        private Rectangle _textRect;
        private bool _completed;

        public DrawTextData() { }

        public DrawTextData(string text, Font font, Rectangle textRect) 
        {
            _text = text;
            _font = font;
            _textRect = textRect;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public Rectangle TextRect
        {
            get { return _textRect; }
            set { _textRect = value; }
        }

        public bool Completed
        {
            get { return _completed; }
            set { _completed = value; }
        }
    }
}
