using System;
using System.Windows.Forms;
using System.Resources;

namespace BaseControls.ImageBox.DrawTools
{
	/// <summary>
	/// Ellipse tool
	/// </summary>
    class ToolEllipse : BaseControls.ImageBox.DrawTools.ToolRectangle
	{
		public ToolEllipse()
		{
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("BaseControls.ImageBox.Resources", assembly);
            Cursor = (System.Windows.Forms.Cursor)(rm.GetObject("Ellipse"));
		}

        public override void OnMouseDown(ImageCtl drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawEllipse(e.X, e.Y, 1, 1));
        }

	}
}
