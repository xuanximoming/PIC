using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BaseControls.ImageBox.DrawTools.DocToolkit;
using BaseControls.ImageBox.DrawTools;


namespace BaseControls.ImageBox
{
    public partial class ImageCtl : PictureBox
    {
        #region Constructor

        public ImageCtl()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Enumerations

        public enum DrawToolType
        {
            Pointer,
            Point,
            Rectangle,
            Ellipse,
            Line,
            Polygon,
            Text,
            NumberOfXImage
        };

        #endregion

        #region Members

        private GraphicsList graphicsList;    // list of draw objects
        // (instances of DrawObject-derived classes)

        private DrawToolType activeTool;      // active drawing tool
        private Tool[] tools;                 // array of tools

        // Information about owner form
        private Form owner;

        //private ContextMenuStrip m_ContextMenu;

        private UndoManager undoManager;

        #endregion

        #region Properties

        /// <summary>
        /// Reference to the owner form
        /// </summary>
        public Form Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        /// <summary>
        /// Active drawing tool.
        /// </summary>
        public DrawToolType ActiveTool
        {
            get
            {
                return activeTool;
            }
            set
            {
                activeTool = value;
            }
        }

        /// <summary>
        /// List of graphics objects.
        /// </summary>
        public GraphicsList GraphicsList
        {
            get
            {
                return graphicsList;
            }
            set
            {
                graphicsList = value;
            }
        }

        /// <summary>
        /// Return True if Undo operation is possible
        /// </summary>
        public bool CanUndo
        {
            get
            {
                if ( undoManager != null )
                {
                    return undoManager.CanUndo;
                }

                return false;
            }
        }

        /// <summary>
        /// Return True if Redo operation is possible
        /// </summary>
        public bool CanRedo
        {
            get
            {
                if (undoManager != null)
                {
                    return undoManager.CanRedo;
                }

                return false;
            }
        }


        #endregion

        #region Other Functions

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="docManager"></param>
        public void Initialize()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            // Keep reference to owner form
            this.Owner = this.FindForm ();

            // set default tool
            activeTool = DrawToolType.Pointer;

            // create list of graphic objects
            graphicsList = new GraphicsList();

            // Create undo manager
            undoManager = new UndoManager(graphicsList);

            // create array of drawing tools
            tools = new Tool[(int)DrawToolType.NumberOfXImage];
            tools[(int)DrawToolType.Pointer] = new ToolPointer();
            tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
            tools[(int)DrawToolType.Ellipse] = new ToolEllipse();
            tools[(int)DrawToolType.Line] = new ToolLine();
            tools[(int)DrawToolType.Polygon] = new ToolPolygon();
            tools[(int)DrawToolType.Text] = new ToolText();
            tools[(int)DrawToolType.Point] = new ToolPoint();
        }

        /// <summary>
        /// Add command to history.
        /// </summary>
        public void AddCommandToHistory(Command command)
        {
            undoManager.AddCommandToHistory(command);
        }

        /// <summary>
        /// Clear Undo history.
        /// </summary>
        public void ClearHistory()
        {
            undoManager.ClearHistory();
        }

        /// <summary>
        /// Undo
        /// </summary>
        public void Undo()
        {
            undoManager.Undo();
            Refresh();
        }

        /// <summary>
        /// Redo
        /// </summary>
        public void Redo()
        {
            undoManager.Redo();
            Refresh();
        }


        /// <summary>
        /// Right-click handler
        /// </summary>
        /// <param name="e"></param>
        private void OnContextMenu(MouseEventArgs e)
        {
            // Change current selection if necessary

            //Point point = new Point(e.X, e.Y);

            //int n = GraphicsList.Count;
            //DrawObject o = null;

            //for (int i = 0; i < n; i++)
            //{
            //    if (GraphicsList[i].HitTest(point) == 0)
            //    {
            //        o = GraphicsList[i];
            //        break;
            //    }
            //}

            //if (o != null)
            //{
            //    if (!o.Selected)
            //        GraphicsList.UnselectAll();

            //    // Select clicked object
            //    o.Selected = true;
            //}
            //else
            //{
            //    GraphicsList.UnselectAll();
            //}

            //Refresh();      // in the case selection was changed

            // Show context menu.
            // Context menu items are filled from owner form Edit menu items.
            //m_ContextMenu = new ContextMenuStrip();

            //int nItems = owner.ContextParent.DropDownItems.Count;

            //// Read Edit items and move them to context menu.
            //// Since every move reduces number of items, read them in reverse order.
            //// To get items in direct order, insert each of them to beginning.
            //for (int i = nItems - 1; i >= 0; i--)
            //{
            //    m_ContextMenu.Items.Insert(0, owner.ContextParent.DropDownItems[i]);
            //}

            // Show context menu for owner form, so that it handles items selection.
            // Convert point from this window coordinates to owner's coordinates.
            //point.X += this.Left;
            //point.Y += this.Top;

            //m_ContextMenu.Show(owner, point);

            //Owner.SetStateOfControls();  // enable/disable menu items

            // Context menu is shown, but owner's Edit menu is now empty.
            // Subscribe to context menu Closed event and restore items there.
            //m_ContextMenu.Closed += delegate(object sender, ToolStripDropDownClosedEventArgs args)
            //{
            //    if (m_ContextMenu != null)      // precaution
            //    {
            //        nItems = m_ContextMenu.Items.Count;

            //        for (int k = nItems - 1; k >= 0; k--)
            //        {
            //            owner.ContextParent.DropDownItems.Insert(0, m_ContextMenu.Items[k]);
            //        }
            //    }
            //};
        }

        public void DeleteLabelText()
        {
            for (int k = 0; k < this.Controls.Count; k++)//²éÕÒtextbox
            {
                if (this.Controls[k].GetType().FullName == "BaseControls.ImageBox.DrawTools.XTextBox")
                {
                    XTextBox t = (XTextBox)this.Controls[k];
                    if (t.isSelected)
                        this.Controls.RemoveAt(k);
                }
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Draw graphic objects and 
        /// group selection rectangle (optionally)
        /// </summary>
        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            //SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            //e.Graphics.FillRectangle(brush,
            //    this.ClientRectangle);

            if (graphicsList != null)
            {
                graphicsList.Draw(e.Graphics);
            }

            //DrawNetSelection(e.Graphics);

            //brush.Dispose();
        }

        /// <summary>
        /// Mouse down.
        /// Left button down event is passed to active tool.
        /// Right button down event is handled in this class.
        /// </summary>
        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tools[(int)activeTool].OnMouseDown(this, e);
        }

        /// <summary>
        /// Mouse move.
        /// Moving without button pressed or with left button pressed
        /// is passed to active tool.
        /// </summary>
        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
                tools[(int)activeTool].OnMouseMove(this, e);
            else
                this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Mouse up event.
        /// Left button up event is passed to active tool.
        /// </summary>
        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tools[(int)activeTool].OnMouseUp(this, e);
        }

        #endregion Event Handlers

    }
}
