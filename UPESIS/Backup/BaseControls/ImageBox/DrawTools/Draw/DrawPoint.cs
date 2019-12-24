using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace BaseControls.ImageBox.DrawTools
{
    /// <summary>
    /// Line graphic object
    /// </summary>
 public   class DrawPoint : BaseControls.ImageBox.DrawTools.DrawObject
    {
        public Point Point;

        private const string entryStart = "Point";

        /// <summary>
        ///  Graphic objects for hit test
        /// </summary>
        private GraphicsPath areaPath = null;
        private Pen areaPen = null;
        private Region areaRegion = null;

        public int PointSize = 10;

        public DrawPoint()
            : this(0, 0)
        {
        }

        public DrawPoint(int x1, int y1)
            : base()
        {
            Point.X = x1;
            Point.Y = y1;

            Initialize();
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawPoint drawPoint = new DrawPoint();
            drawPoint.Point = this.Point;

            FillDrawObjectFields(drawPoint);
            return drawPoint;
        }


        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color), Point.X, Point.Y, PointSize, PointSize);
        }

        public override int HandleCount
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            return Point;
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                        return i;
                }
            }

            if (PointInObject(point))
                return 0;

            return -1;
        }

        protected override bool PointInObject(Point point)
        {
            Size pSize = new Size(PointSize, PointSize);
            Rectangle rectangle = new Rectangle(Point, pSize);
            return rectangle.Contains(point);
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            CreateObjects();

            return AreaRegion.IsVisible(rectangle);
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                case 2:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        public override void MoveHandleTo(Point point, int handleNumber)
        {
            Point = point;
            Invalidate();
        }

        public override void Move(int deltaX, int deltaY)
        {
            Point.X += deltaX;
            Point.Y += deltaY;

            Invalidate();
        }

        public override void SaveToStream(System.Runtime.Serialization.SerializationInfo info, int orderNumber)
        {
            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                "{0}{1}",
                entryStart, orderNumber),
                Point);

            base.SaveToStream(info, orderNumber);
        }

        public override void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            Point = (Point)info.GetValue(
                String.Format(CultureInfo.InvariantCulture,
                "{0}{1}",
                entryStart, orderNumber),
                typeof(Point));

            base.LoadFromStream(info, orderNumber);
        }


        /// <summary>
        /// Invalidate object.
        /// When object is invalidated, path used for hit test
        /// is released and should be created again.
        /// </summary>
        protected void Invalidate()
        {
            if (AreaPath != null)
            {
                AreaPath.Dispose();
                AreaPath = null;
            }

            if (AreaPen != null)
            {
                AreaPen.Dispose();
                AreaPen = null;
            }

            if (AreaRegion != null)
            {
                AreaRegion.Dispose();
                AreaRegion = null;
            }
        }

        /// <summary>
        /// Create graphic objects used from hit test.
        /// </summary>
        protected virtual void CreateObjects()
        {
            if (AreaPath != null)
                return;

            // Create path which contains wide line
            // for easy mouse selection
            AreaPath = new GraphicsPath();
            AreaPen = new Pen(Color.Red, 7);
            Rectangle po = new Rectangle(Point.X, Point.Y, 1, 1);
            AreaPath.AddRectangle(po);
            AreaPath.Widen(AreaPen);

            // Create region from the path
            AreaRegion = new Region(AreaPath);
        }

        protected GraphicsPath AreaPath
        {
            get
            {
                return areaPath;
            }
            set
            {
                areaPath = value;
            }
        }

        protected Pen AreaPen
        {
            get
            {
                return areaPen;
            }
            set
            {
                areaPen = value;
            }
        }

        protected Region AreaRegion
        {
            get
            {
                return areaRegion;
            }
            set
            {
                areaRegion = value;
            }
        }

    }
}
