using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;

namespace BaseControls.ImageBox.DrawTools
{
	/// <summary>
	/// Line tool
	/// </summary>
    class ToolLine : BaseControls.ImageBox.DrawTools.ToolObject
	{
        public ToolLine()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("BaseControls.ImageBox.Resources", assembly);
            Cursor = (System.Windows.Forms.Cursor)(rm.GetObject("Line"));
        }
        
        public override void OnMouseDown(ImageCtl drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawLine(e.X, e.Y, e.X + 1, e.Y + 1));
        }

        public override void OnMouseMove(ImageCtl drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if ( e.Button == MouseButtons.Left )
            {
                Point point = new Point(e.X, e.Y);
                drawArea.GraphicsList[0].MoveHandleTo(point, 2);
                drawArea.Refresh();
            }
        }
    }
}
