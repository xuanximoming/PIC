/*
 
 2008 Jos?Manuel Menéndez Poo
 * 
 * Please give me credit if you use this code. It's all I ask.
 * 
 * Contact me for more info: menendezpoo@gmail.com
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BaseControls.Ribbon
{
    /// <summary>
    /// Provides render functionallity for the Ribbon control
    /// </summary>
    /// <remarks></remarks>
    public class RibbonRenderer
    {
        /// <summary>
        /// Renders the Ribbon's background
        /// </summary>
        public virtual void OnRenderRibbonBackground(RibbonRenderEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders a RibbonTab
        /// </summary>
        /// <param name="e">Event data and paint tools</param>
        public virtual void OnRenderRibbonTab(RibbonTabRenderEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders a RibbonItem
        /// </summary>
        public virtual void OnRenderRibbonItem(RibbonItemRenderEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders the background of the content of the specified tab
        /// </summary>
        /// <param name="e">Event data and paint tools</param>
        public virtual void OnRenderRibbonTabContentBackground(RibbonTabRenderEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders the background of the specified ribbon panel
        /// </summary>
        /// <param name="e">Event data and paint tools</param>
        public virtual void OnRenderRibbonPanelBackground(RibbonPanelRenderEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders the text of the tab specified on the event
        /// </summary>
        /// <param name="e">Event data and paint tools</param>
        public virtual void OnRenderRibbonTabText(RibbonTabRenderEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders the text of the item specified on the event
        /// </summary>
        /// <param name="e">Event data and paint tools</param>
        public virtual void OnRenderRibbonItemText(RibbonItemBoundsEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders the border of the item, after the text and image of the item
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnRenderRibbonItemBorder(RibbonItemRenderEventArgs e)
        {

        }

        /// <summary>
        /// Renders the image of the item specified on the event
        /// </summary>
        public virtual void OnRenderRibbonItemImage(RibbonItemBoundsEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders the text of the specified panel
        /// </summary>
        /// <param name="e">Event data and paint tools</param>
        public virtual void OnRenderRibbonPanelText(RibbonPanelRenderEventArgs e)
        {
            
        }

        /// <summary>
        /// Renders the background of a dropdown
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnRenderDropDownBackground(RibbonCanvasEventArgs e)
        {
        }

        /// <summary>
        /// Renders the background of a panel background
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnRenderPanelPopupBackground(RibbonCanvasEventArgs e)
        {

        }

        /// <summary>
        /// Call to draw the scroll buttons on the tab
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnRenderTabScrollButtons(RibbonTabRenderEventArgs e)
        {
        }
    }
}
