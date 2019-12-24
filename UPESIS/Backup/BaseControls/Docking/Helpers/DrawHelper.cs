using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BaseControls.Docking
{
	internal static class DrawHelper
	{
        public static int bshift = 8;

        public static Point RtlTransform(Control control, Point point)
        {
            if (control.RightToLeft != RightToLeft.Yes)
                return point;
            else
                return new Point(control.Right - point.X, point.Y);
        }

        public static Rectangle RtlTransform(Control control, Rectangle rectangle)
        {
            if (control.RightToLeft != RightToLeft.Yes)
                return rectangle;
            else
                return new Rectangle(control.ClientRectangle.Right - rectangle.Right, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public static GraphicsPath GetRoundedCornerTab(GraphicsPath graphicsPath, Rectangle rect, bool upCorner)
        {
            if (graphicsPath == null)
                graphicsPath = new GraphicsPath();
            else
                graphicsPath.Reset();
            
            int curveSize = 6;
            if (upCorner)
            {
                graphicsPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top + curveSize / 2);
                graphicsPath.AddArc(new Rectangle(rect.Left, rect.Top, curveSize, curveSize), 180, 90);
                graphicsPath.AddLine(rect.Left + curveSize / 2, rect.Top, rect.Right - curveSize / 2, rect.Top);
                graphicsPath.AddArc(new Rectangle(rect.Right - curveSize, rect.Top, curveSize, curveSize), -90, 90);
                graphicsPath.AddLine(rect.Right, rect.Top + curveSize / 2, rect.Right, rect.Bottom);
            }
            else
            {
                graphicsPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom - curveSize / 2);
                graphicsPath.AddArc(new Rectangle(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize), 0, 90);
                graphicsPath.AddLine(rect.Right - curveSize / 2, rect.Bottom, rect.Left + curveSize / 2, rect.Bottom);
                graphicsPath.AddArc(new Rectangle(rect.Left, rect.Bottom - curveSize, curveSize, curveSize), 90, 90);
                graphicsPath.AddLine(rect.Left, rect.Bottom - curveSize / 2, rect.Left, rect.Top);
            }

            return graphicsPath;
        }

		public static GraphicsPath CalculateGraphicsPathFromBitmap(Bitmap bitmap)
		{
			return CalculateGraphicsPathFromBitmap(bitmap, Color.Empty);
		}

		// From http://edu.cnzz.cn/show_3281.html
		public static GraphicsPath CalculateGraphicsPathFromBitmap(Bitmap bitmap, Color colorTransparent) 
		{ 
			GraphicsPath graphicsPath = new GraphicsPath(); 
			if (colorTransparent == Color.Empty)
				colorTransparent = bitmap.GetPixel(0, 0); 

			for(int row = 0; row < bitmap.Height; row ++) 
			{ 
				int colOpaquePixel = 0;
				for(int col = 0; col < bitmap.Width; col ++) 
				{ 
					if(bitmap.GetPixel(col, row) != colorTransparent) 
					{ 
						colOpaquePixel = col; 
						int colNext = col; 
						for(colNext = colOpaquePixel; colNext < bitmap.Width; colNext ++) 
							if(bitmap.GetPixel(colNext, row) == colorTransparent) 
								break;
 
						graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1)); 
						col = colNext; 
					} 
				} 
			} 
			return graphicsPath; 
		}
        public enum Corners
        {
            RightTop,
            LeftTop,
            LeftBottom,
            RightBottom,
            Bottom,
            Top
        }
        public enum TabDrawType
        {
            First,
            Active,
            Inactive
        }
        public enum GradientType
        {
            Flat,
            Linear,
            Bell
        }

        public static void DrawTab(Graphics g, Rectangle r, Corners corner, GradientType gradient, Color darkColor, Color lightColor, Color edgeColor, bool closed)
        {
            //dims
            Point[] points = null;
            GraphicsPath path = default(GraphicsPath);
            Region region = default(Region);
            LinearGradientBrush linearBrush = default(LinearGradientBrush);
            Brush brush = null;
            Pen pen = default(Pen);
            r.Inflate(-1, -1);
            //set brushes
            switch (gradient)
            {
                case GradientType.Flat:
                    brush = new SolidBrush(darkColor);
                    break; // TODO: might not be correct. Was : Exit Select
                case GradientType.Linear:
                    brush = new LinearGradientBrush(r, darkColor, lightColor, LinearGradientMode.Vertical);
                    break; // TODO: might not be correct. Was : Exit Select
                case GradientType.Bell:
                    linearBrush = new LinearGradientBrush(r, darkColor, lightColor, LinearGradientMode.Vertical);
                    linearBrush.SetSigmaBellShape(0.17f, 0.67f);
                    brush = linearBrush;
                    break; // TODO: might not be correct. Was : Exit Select
            }
            pen = new Pen(edgeColor, 1);
            //generic points
            points = new Point[12] { new Point(r.Left, r.Bottom), new Point(r.Left, r.Bottom - bshift), new Point(r.Left, r.Top + bshift), new Point(r.Left, r.Top), new Point(r.Left + bshift, r.Top), new Point(r.Right - bshift, r.Top), new Point(r.Right, r.Top), new Point(r.Right, r.Top + bshift), new Point(r.Right, r.Bottom - bshift), new Point(r.Right, r.Bottom), 
	new Point(r.Right - bshift, r.Bottom), new Point(r.Left + bshift, r.Bottom) };

            path = new GraphicsPath();
            switch (corner)
            {
                case Corners.LeftBottom:
                    path.AddLine(points[3], points[1]);
                    path.AddBezier(points[1], points[0], points[0], points[11]);
                    path.AddLine(points[11], points[9]);
                    path.AddLine(points[9], points[6]);
                    path.AddLine(points[6], points[3]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[3], points[1]);
                    g.DrawBezier(pen, points[1], points[0], points[0], points[11]);
                    g.DrawLine(pen, points[11], points[9]);
                    g.DrawLine(pen, points[9], points[6]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[6], points[3]);
                    }

                    break; // TODO: might not be correct. Was : Exit Select
                case Corners.LeftTop:
                    path.AddLine(points[0], points[2]);
                    path.AddBezier(points[2], points[3], points[3], points[4]);
                    path.AddLine(points[4], points[6]);
                    path.AddLine(points[6], points[9]);
                    path.AddLine(points[9], points[0]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[0], points[2]);
                    g.DrawBezier(pen, points[2], points[3], points[3], points[4]);
                    g.DrawLine(pen, points[4], points[6]);
                    g.DrawLine(pen, points[6], points[9]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[9], points[0]);
                    }

                    break; // TODO: might not be correct. Was : Exit Select
                case Corners.Bottom:

                    path.AddLine(points[1], points[3]);
                    path.AddBezier(points[1], points[0], points[0], points[11]);
                    path.AddLine(points[11], points[10]);
                    path.AddBezier(points[10], points[9], points[9], points[8]);
                    path.AddLine(points[8], points[6]);
                    path.AddLine(points[6], points[3]);
                    region = new Region(path);
                    g.FillRegion(brush, region);

                    g.DrawLine(pen, points[1], points[3]);
                    g.DrawBezier(pen, points[1], points[0], points[0], points[11]);
                    g.DrawLine(pen, points[11], points[10]);
                    g.DrawBezier(pen, points[10], points[9], points[9], points[8]);
                    g.DrawLine(pen, points[8], points[6]);

                    if (closed)
                    {
                        g.DrawLine(pen, points[6], points[3]);
                    }


                    break; // TODO: might not be correct. Was : Exit Select
                case Corners.Top:
                    path.AddLine(points[0], points[2]);
                    path.AddBezier(points[2], points[3], points[3], points[4]);
                    path.AddLine(points[4], points[5]);
                    path.AddBezier(points[5], points[6], points[6], points[7]);
                    path.AddLine(points[7], points[9]);
                    path.AddLine(points[9], points[0]);
                    region = new Region(path);
                    g.FillRegion(brush, region);

                    g.DrawLine(pen, points[0], points[2]);
                    g.DrawBezier(pen, points[2], points[3], points[3], points[4]);
                    g.DrawLine(pen, points[4], points[5]);
                    g.DrawBezier(pen, points[5], points[6], points[6], points[7]);
                    g.DrawLine(pen, points[7], points[9]);

                    if (closed)
                    {
                        g.DrawLine(pen, points[9], points[0]);
                    }


                    break; // TODO: might not be correct. Was : Exit Select
                case Corners.RightBottom:
                    path.AddLine(points[3], points[0]);
                    path.AddLine(points[0], points[10]);
                    path.AddBezier(points[10], points[9], points[9], points[8]);
                    path.AddLine(points[8], points[6]);
                    path.AddLine(points[6], points[3]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[3], points[0]);
                    g.DrawLine(pen, points[0], points[10]);
                    g.DrawBezier(pen, points[10], points[9], points[9], points[8]);
                    g.DrawLine(pen, points[8], points[6]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[6], points[3]);
                    }

                    break; // TODO: might not be correct. Was : Exit Select
                case Corners.RightTop:
                    path.AddLine(points[0], points[3]);
                    path.AddLine(points[3], points[5]);
                    path.AddBezier(points[5], points[6], points[6], points[7]);
                    path.AddLine(points[7], points[9]);
                    path.AddLine(points[9], points[0]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[0], points[3]);
                    g.DrawLine(pen, points[3], points[5]);
                    g.DrawBezier(pen, points[5], points[6], points[6], points[7]);
                    g.DrawLine(pen, points[7], points[9]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[9], points[0]);
                    }

                    break; // TODO: might not be correct. Was : Exit Select

            }
        }

        public static void DrawDocumentTab(Graphics g, Rectangle rect, Color backColorBegin, Color backColorEnd, Color edgeColor, TabDrawType tabType, bool closed)
        {
            GraphicsPath path = default(GraphicsPath);
            Region region = default(Region);
            Brush brush = null;
            Pen pen = default(Pen);
            brush = new LinearGradientBrush(rect, backColorBegin, backColorEnd, LinearGradientMode.Vertical);
            pen = new Pen(edgeColor, 1f);
            path = new GraphicsPath();

            if (tabType == TabDrawType.First)
            {
                path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
                path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
                path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
            }
            else
            {
                if (tabType == TabDrawType.Active)
                {
                    path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
                    path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                }
                else
                {
                    path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2);
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1);
                }
            }
            region = new Region(path);
            g.FillRegion(brush, region);
            g.DrawPath(pen, path);
        }

	}
}
