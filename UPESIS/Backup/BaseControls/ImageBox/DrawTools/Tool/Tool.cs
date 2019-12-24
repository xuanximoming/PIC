using System;
using System.Windows.Forms;
using System.Drawing;


namespace BaseControls.ImageBox.DrawTools
{
	/// <summary>
	/// Base class for all drawing tools
	/// </summary>
	abstract class Tool
	{

        /// <summary>
        /// Left nous button is pressed
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDown(ImageCtl drawArea, MouseEventArgs e)
        {
        }


        /// <summary>
        /// Mouse is moved, left mouse button is pressed or none button is pressed
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseMove(ImageCtl drawArea, MouseEventArgs e)
        {
        }


        /// <summary>
        /// Left mouse button is released
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseUp(ImageCtl drawArea, MouseEventArgs e)
        {
        }
    }
}
