using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Drawing;

namespace BaseControls.ImageBox.DrawTools
{
    /// <summary>
    /// Rectangle tool
    /// </summary>
    class ToolText : BaseControls.ImageBox.DrawTools.ToolObject
    {

        public ToolText()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("BaseControls.ImageBox.Resources", assembly);
            Cursor = (System.Windows.Forms.Cursor)(rm.GetObject("Rectangle"));
        }

        public override void OnMouseDown(ImageCtl drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawText(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(ImageCtl drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                drawArea.GraphicsList[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }

        public override void OnMouseUp(ImageCtl drawArea, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                ((DrawText)drawArea.GraphicsList[0]).CreateXTextBox(drawArea);
                drawArea.GraphicsList.RemoveAt(0);
                drawArea.ActiveTool = ImageCtl.DrawToolType.Pointer;
                drawArea.Refresh();
            }
        }
    }
}
