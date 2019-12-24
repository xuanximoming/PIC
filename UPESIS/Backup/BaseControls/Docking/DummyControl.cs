using System;
using System.Windows.Forms;

namespace BaseControls.Docking
{
	internal class DummyControl : Control
	{
		public DummyControl()
		{
			SetStyle(ControlStyles.Selectable, false);
		}
	}
}
