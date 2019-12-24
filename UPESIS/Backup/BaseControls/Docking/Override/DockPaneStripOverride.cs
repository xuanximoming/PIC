using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace BaseControls.Docking
{
    public partial class DockPaneStripOverride : VS2005DockPaneStrip
    {
        protected internal DockPaneStripOverride(DockPane pane)
            : base(pane)
        {
            BackColor = SystemColors.ControlLight;
        }
    }
}

