using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;

namespace BaseControls.ImageBox.DrawTools
{
    /// <summary>
    /// Line tool
    /// </summary>
    class ToolPoint : BaseControls.ImageBox.DrawTools.ToolObject
    {
        public ToolPoint()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("BaseControls.ImageBox.Resources", assembly);
            Cursor = (System.Windows.Forms.Cursor)(rm.GetObject("Line"));
        }

        public override void OnMouseDown(ImageCtl drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawPoint(e.X, e.Y));
        }

        public override void OnMouseMove(ImageCtl drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                drawArea.GraphicsList[0].MoveHandleTo(point, 2);
                drawArea.Refresh();
            }
        }
    }
}
