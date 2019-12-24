using System;
using System.Windows.Forms;
using System.Drawing;


namespace BaseControls.ImageBox.DrawTools
{
	/// <summary>
	/// Base class for all tools which create new graphic object
	/// </summary>
    abstract class ToolObject : BaseControls.ImageBox.DrawTools.Tool
	{
        private Color toolColor = Color.Black;
        public Color ToolColor
        {
            get { return this.toolColor; }
            set { this.toolColor = value; }
        }

        private Cursor cursor;

        /// <summary>
        /// Tool cursor.
        /// </summary>
        protected Cursor Cursor
        {
            get
            {
                return cursor;
            }
            set
            {
                cursor = value;
            }
        }


        /// <summary>
        /// Left mouse is released.
        /// New object is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(ImageCtl drawArea, MouseEventArgs e)
        {
            drawArea.GraphicsList[0].Normalize();
            drawArea.AddCommandToHistory(new CommandAdd(drawArea.GraphicsList[0]));
            drawArea.ActiveTool = ImageCtl.DrawToolType.Pointer;

            drawArea.Capture = false;
            drawArea.Refresh();
        }

        /// <summary>
        /// Add new object to draw area.
        /// Function is called when user left-clicks draw area,
        /// and one of ToolObject-derived tools is active.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="o"></param>
        protected void AddNewObject(ImageCtl drawArea, DrawObject o)
        {
            drawArea.GraphicsList.UnselectAll();

            o.Selected = true;
            //MessageBox.Show(o.ID.ToString());
            drawArea.GraphicsList.Add(o);

            drawArea.Capture = true;
            drawArea.Refresh();

        }
	}
}
