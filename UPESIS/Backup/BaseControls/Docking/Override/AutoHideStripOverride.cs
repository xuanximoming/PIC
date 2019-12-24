
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace BaseControls.Docking
{
    public partial class AutoHideStripOverride : VS2005AutoHideStrip
    {
        protected internal AutoHideStripOverride(DockPanel dockPanel)
            : base(dockPanel)
        {
            BackColor = Color.Yellow;
        }
    }
}

