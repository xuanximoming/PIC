using System;
using System.Collections.Generic;
using System.Text;
using BaseControls.ImageTool;
using System.Drawing;

namespace SIS.ImgProcess.filters
{


    public class ProfessionalCaptureImageToolColorTable : 
        CaptureImageToolColorTable
    {
        private static readonly Color _borderColor = Color.FromArgb(106, 255, 34);
        private static readonly Color _backColorNormal = Color.FromArgb(221, 255, 205);
        private static readonly Color _backColorHover = Color.FromArgb(106, 255, 34);
        private static readonly Color _backColorPressed = Color.FromArgb(74, 226, 0);
        private static readonly Color _foreColor = Color.FromArgb(41, 126, 0);

        public ProfessionalCaptureImageToolColorTable() { }

        public override Color BorderColor
        {
            get { return _borderColor; }
        }

        public override Color BackColorNormal
        {
            get { return _backColorNormal; }
        }

        public override Color BackColorHover
        {
            get { return _backColorHover; }
        }

        public override Color BackColorPressed
        {
            get { return _backColorPressed; }
        }

        public override Color ForeColor
        {
            get { return _foreColor; }
        }
    }
}
