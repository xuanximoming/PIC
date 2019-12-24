using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;


namespace BaseControls.ImageBox.DrawTools
{
	/// <summary>
	/// Rectangle tool
	/// </summary>
    class ToolRectangle : BaseControls.ImageBox.DrawTools.ToolObject
	{

		public ToolRectangle()  
		{
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("BaseControls.ImageBox.Resources", assembly);
            Cursor = (System.Windows.Forms.Cursor)(rm.GetObject("Rectangle"));
		}

        public override void OnMouseDown(ImageCtl drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawRectangle(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(ImageCtl drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if ( e.Button == MouseButtons.Left )
            {
                Point point = new Point(e.X, e.Y);
                drawArea.GraphicsList[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }
	}
}
