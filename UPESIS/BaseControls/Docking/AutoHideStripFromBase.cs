using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
// *****************************************************************************
// 
//  Copyright 2004, Weifen Luo
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Weifen Luo
//  and are supplied subject to licence terms.
// 
//  WinFormsUI Library Version 1.0
// *****************************************************************************
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace BaseControls.Docking
{
    [ToolboxItem(false)]
    public partial class AutoHideStripFromBase : AutoHideStripBase
    {
        private const int _ImageHeight = 16;
        private const int _ImageWidth = 16;
        private const int _ImageGapTop = 2;
        private const int _ImageGapLeft = 4;
        private const int _ImageGapRight = 4;
        private const int _ImageGapBottom = 2;
        private const int _TextGapLeft = 4;
        private const int _TextGapRight = 10;
        private const int _TabGapTop = 3;
        private const int _TabGapLeft = 2;
        private const int _TabGapBetween = 10;
        private static StringFormat _stringFormatTabHorizontal;
        private static StringFormat _stringFormatTabVertical;
        private static Matrix _matrixIdentity;
        #region "Customizable Properties"
        private static DockState[] _dockStates;
        protected virtual StringFormat StringFormatTabHorizontal
        {
            get { return _stringFormatTabHorizontal; }
        }
        protected virtual StringFormat StringFormatTabVertical
        {
            get { return _stringFormatTabVertical; }
        }
        protected virtual int ImageHeight
        {
            get { return _ImageHeight; }
        }
        protected virtual int ImageWidth
        {
            get { return _ImageWidth; }
        }
        protected virtual int ImageGapTop
        {
            get { return _ImageGapTop; }
        }
        protected virtual int ImageGapLeft
        {
            get { return _ImageGapLeft; }
        }
        protected virtual int ImageGapRight
        {
            get { return _ImageGapRight; }
        }
        protected virtual int ImageGapBottom
        {
            get { return _ImageGapBottom; }
        }
        protected virtual int TextGapLeft
        {
            get { return _TextGapLeft; }
        }
        protected virtual int TextGapRight
        {
            get { return _TextGapRight; }
        }
        protected virtual int TabGapTop
        {
            get { return _TabGapTop; }
        }
        protected virtual int TabGapLeft
        {
            get { return _TabGapLeft; }
        }
        protected virtual int TabGapBetween
        {
            get { return _TabGapBetween; }
        }
        protected virtual void BeginDrawTab()
        {
        }
        protected virtual void EndDrawTab()
        {
        }
        protected virtual Brush BrushTabBackGround
        {
            get { return SystemBrushes.Control; }
        }
        protected virtual Pen PenTabBorder
        {
            get { return SystemPens.GrayText; }
        }
        protected virtual Brush BrushTabText
        {
            get { return SystemBrushes.FromSystemColor(SystemColors.ControlDarkDark); }
        }
        #endregion
        private Matrix MatrixIdentity
        {
            get { return _matrixIdentity; }
        }
        private DockState[] DockStates
        {
            get { return _dockStates; }
        }
        static AutoHideStripFromBase()
        {
            _stringFormatTabHorizontal = new StringFormat();
            _stringFormatTabHorizontal.Alignment = StringAlignment.Near;
            _stringFormatTabHorizontal.LineAlignment = StringAlignment.Center;
            _stringFormatTabHorizontal.FormatFlags = StringFormatFlags.NoWrap;
            _stringFormatTabVertical = new StringFormat();
            _stringFormatTabVertical.Alignment = StringAlignment.Near;
            _stringFormatTabVertical.LineAlignment = StringAlignment.Center;
            _stringFormatTabVertical.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionVertical;
            _matrixIdentity = new Matrix();
            _dockStates = new DockState[5];
            _dockStates[0] = DockState.DockLeftAutoHide;
            _dockStates[1] = DockState.DockRightAutoHide;
            _dockStates[2] = DockState.DockTopAutoHide;
            _dockStates[3] = DockState.DockBottomAutoHide;
        }
        protected internal AutoHideStripFromBase(DockPanel panel)
            : base(panel)
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.WhiteSmoke;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.Navy, Color.WhiteSmoke, LinearGradientMode.BackwardDiagonal))
            {
                g.FillRectangle(brush, ClientRectangle);
            }
            DrawTabStrip(g);
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            CalculateTabs();
            base.OnLayout(levent);
        }
        private void DrawTabStrip(Graphics g)
        {
            DrawTabStrip(g, DockState.DockTopAutoHide);
            DrawTabStrip(g, DockState.DockBottomAutoHide);
            DrawTabStrip(g, DockState.DockLeftAutoHide);
            DrawTabStrip(g, DockState.DockRightAutoHide);
        }
        private void DrawTabStrip(Graphics g, DockState dockState)
        {
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
            if (rectTabStrip.IsEmpty)
            {
                return;
            }
            Matrix matrixIdentity = g.Transform;
            if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
            {
                Matrix matrixRotated = new Matrix();
                matrixRotated.RotateAt(90, new PointF((float)rectTabStrip.X + (float)rectTabStrip.Height / 2, (float)rectTabStrip.Y + (float)rectTabStrip.Height / 2));
                g.Transform = matrixRotated;
            }
            foreach (Pane pane in GetPanes(dockState))
            {
                foreach (Tab tab in pane.AutoHideTabs)
                {
                    DrawTab(g, tab);
                }
            }
            g.Transform = matrixIdentity;
        }
        private void CalculateTabs()
        {
            CalculateTabs(DockState.DockTopAutoHide);
            CalculateTabs(DockState.DockBottomAutoHide);
            CalculateTabs(DockState.DockLeftAutoHide);
            CalculateTabs(DockState.DockRightAutoHide);
        }
        private void CalculateTabs(DockState dockState)
        {
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
            int imageHeight = rectTabStrip.Height - ImageGapTop - ImageGapBottom;
            int imageWidth = 0;
            if (imageHeight > this.ImageHeight)
            {
                imageWidth = this.ImageWidth * (imageHeight / this.ImageHeight);
            }
            using (Graphics g = CreateGraphics())
            {
                int x = TabGapLeft + rectTabStrip.X;
                foreach (Pane pane in GetPanes(dockState))
                {
                    int maxWidth = 0;
                    foreach (Tab tab in pane.AutoHideTabs)
                    {
                        int width = imageWidth + ImageGapLeft + ImageGapRight + (int)g.MeasureString(tab.Content.DockHandler.TabText, Font).Width + 1 + TextGapLeft + TextGapRight;
                        if (width > maxWidth)
                        {
                            maxWidth = width;
                        }
                    }
                    foreach (Tab tab in pane.AutoHideTabs)
                    {
                        tab.TabX = x;
                        if (object.ReferenceEquals(tab.Content, pane.DockPane.ActiveContent))
                        {
                            tab.TabWidth = maxWidth;
                        }
                        else
                        {
                            tab.TabWidth = imageWidth + ImageGapLeft + ImageGapRight;
                        }
                        x += tab.TabWidth;
                    }
                    x += TabGapBetween;
                }
            }
        }
        private void DrawTab(Graphics g, Tab tab)
        {
            Rectangle rectTab = GetTabRectangle(tab);
            if (rectTab.IsEmpty)
            {
                return;
            }
            DockState dockState = tab.Content.DockHandler.DockState;
            IDockContent content = tab.Content;
            BeginDrawTab();
            Brush brushTabBackGround = this.BrushTabBackGround;
            Pen penTabBorder = this.PenTabBorder;
            Brush brushTabText = this.BrushTabText;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (dockState == DockState.DockTopAutoHide || dockState == DockState.DockRightAutoHide)
            {
                DrawHelper.DrawTab(g, rectTab, BaseControls.Docking.DrawHelper.Corners.Bottom, BaseControls.Docking.DrawHelper.GradientType.Flat, Color.FromArgb(244, 242, 232), Color.FromArgb(244, 242, 232), Color.FromArgb(172, 168, 153), true);
            }
            else
            {
                DrawHelper.DrawTab(g, rectTab, BaseControls.Docking.DrawHelper.Corners.Top, BaseControls.Docking.DrawHelper.GradientType.Flat, Color.FromArgb(244, 242, 232), Color.FromArgb(244, 242, 232), Color.FromArgb(172, 168, 153), true);
            }

            // Set no rotate for drawing icon and text
            Matrix matrixRotate = g.Transform;
            g.Transform = MatrixIdentity;

            // Draw the icon
            Rectangle rectImage = rectTab;
            rectImage.X += ImageGapLeft;
            rectImage.Y += ImageGapTop;
            int imageHeight = rectTab.Height - ImageGapTop - ImageGapBottom;
            int imageWidth = this.ImageWidth;
            if (imageHeight > this.ImageHeight)
            {
                imageWidth = this.ImageWidth * (imageHeight / this.ImageHeight);
            }
            rectImage.Height = imageHeight;
            rectImage.Width = imageWidth;
            rectImage = GetTransformedRectangle(dockState, rectImage);
            g.DrawIcon(content.DockHandler.Icon, rectImage);

            // Draw the text
            if (object.ReferenceEquals(content, content.DockHandler.Pane.ActiveContent))
            {
                Rectangle rectText = rectTab;
                rectText.X += ImageGapLeft + imageWidth + ImageGapRight + TextGapLeft;
                rectText.Width -= ImageGapLeft + imageWidth + ImageGapRight + TextGapLeft;
                rectText = GetTransformedRectangle(dockState, rectText);
                if (dockState == DockState.DockLeftAutoHide || dockState == DockState.DockRightAutoHide)
                {
                    g.DrawString(content.DockHandler.TabText, Font, brushTabText, rectText, StringFormatTabVertical);
                }
                else
                {
                    g.DrawString(content.DockHandler.TabText, Font, brushTabText, rectText, StringFormatTabHorizontal);
                }
            }
            // Set rotate back
            g.Transform = matrixRotate;
            EndDrawTab();
        }
        private Rectangle GetLogicalTabStripRectangle(DockState dockState)
        {
            return GetLogicalTabStripRectangle(dockState, false);
        }
        private Rectangle GetLogicalTabStripRectangle(DockState dockState, bool transformed)
        {
            if (!DockHelper.IsDockStateAutoHide(dockState))
            {
                return Rectangle.Empty;
            }
            int leftPanes = GetPanes(DockState.DockLeftAutoHide).Count;
            int rightPanes = GetPanes(DockState.DockRightAutoHide).Count;
            int topPanes = GetPanes(DockState.DockTopAutoHide).Count;
            int bottomPanes = GetPanes(DockState.DockBottomAutoHide).Count;
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            height = MeasureHeight();
            if (dockState == DockState.DockLeftAutoHide && leftPanes > 0)
            {
                x = 0;
                if (topPanes == 0)
                {
                    y = 0;
                }
                else
                {
                    y = height;
                }
                if (topPanes == 0)
                {
                    if (bottomPanes == 0)
                    {
                        width = this.Height;
                    }
                    else
                    {
                        width = this.Height - height;
                    }
                }
                else
                {
                    if (bottomPanes == 0)
                    {
                        width = this.Height - height;
                    }
                    else
                    {
                        width = this.Height - height * 2;
                    }
                }
            }
            else if (dockState == DockState.DockRightAutoHide && rightPanes > 0)
            {
                x = this.Width - height;
                if (leftPanes != 0 && x < height)
                {
                    x = height;
                }
                if (topPanes == 0)
                {
                    y = 0;
                }
                else
                {
                    y = height;
                }
                if (topPanes == 0)
                {
                    if (bottomPanes == 0)
                    {
                        width = this.Height;
                    }
                    else
                    {
                        width = this.Height - height;
                    }
                }
                else
                {
                    if (bottomPanes == 0)
                    {
                        width = this.Height - height;
                    }
                    else
                    {
                        width = this.Height - height * 2;
                    }
                }
            }
            else if (dockState == DockState.DockTopAutoHide && topPanes > 0)
            {
                if (leftPanes == 0)
                {
                    x = 0;
                }
                else
                {
                    x = height;
                }
                y = 0;
                if (leftPanes == 0)
                {
                    if (rightPanes == 0)
                    {
                        width = this.Width;
                    }
                    else
                    {
                        width = this.Width - height;
                    }
                }
                else
                {
                    if (rightPanes == 0)
                    {
                        width = this.Width - height;
                    }
                    else
                    {
                        width = this.Width - height * 2;
                    }
                }
            }
            else if (dockState == DockState.DockBottomAutoHide && bottomPanes > 0)
            {
                if (leftPanes == 0)
                {
                    x = 0;
                }
                else
                {
                    x = height;
                }
                y = this.Height - height;
                if (topPanes != 0 && y < height)
                {
                    y = height;
                }
                if (leftPanes == 0)
                {
                    if (rightPanes == 0)
                    {
                        width = this.Width;
                    }
                    else
                    {
                        width = this.Width - height;
                    }
                }
                else
                {
                    if (rightPanes == 0)
                    {
                        width = this.Width - height;
                    }
                    else
                    {
                        width = this.Width - height * 2;
                    }
                }

            }
            else
            {
                return Rectangle.Empty;
            }
            if (!transformed)
            {
                return new Rectangle(x, y, width, height);
            }
            else
            {
                return GetTransformedRectangle(dockState, new Rectangle(x, y, width, height));
            }
        }
        private Rectangle GetTabRectangle(Tab tab)
        {
            return GetTabRectangle(tab, false);
        }
        private Rectangle GetTabRectangle(Tab tab, bool transformed)
        {
            DockState dockState = tab.Content.DockHandler.DockState;
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
            if (rectTabStrip.IsEmpty)
            {
                return Rectangle.Empty;
            }
            int x = tab.TabX;
            int y = 0;

            if ((dockState == DockState.DockTopAutoHide || dockState == DockState.DockRightAutoHide))
            {
                y = rectTabStrip.Y;
            }
            else
            {
                y = rectTabStrip.Y + TabGapTop;
            }

            int width = ((Tab)tab).TabWidth;
            int height = rectTabStrip.Height - TabGapTop;
            if (!transformed)
            {
                return new Rectangle(x, y, width, height);
            }
            else
            {
                return GetTransformedRectangle(dockState, new Rectangle(x, y, width, height));
            }
        }
        private Rectangle GetTransformedRectangle(DockState dockState, Rectangle rect)
        {
            if (dockState != DockState.DockLeftAutoHide && dockState != DockState.DockRightAutoHide)
            {
                return rect;
            }
            PointF[] pts = new PointF[2];
            // the center of the rectangle
            pts[0].X = (float)rect.X + (float)rect.Width / 2;
            pts[0].Y = (float)rect.Y + (float)rect.Height / 2;
            Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
            Matrix matrix = new Matrix();
            matrix.RotateAt(90, new PointF((float)rectTabStrip.X + (float)rectTabStrip.Height / 2, (float)rectTabStrip.Y + (float)rectTabStrip.Height / 2));
            matrix.TransformPoints(pts);
            return new Rectangle((int)(pts[0].X - (float)rect.Height / 2 + 0.5f), (int)(pts[0].Y - (float)rect.Width / 2 + 0.5f), rect.Height, rect.Width);
        }

        protected override IDockContent HitTest(Point ptMouse)
        {
            foreach (DockState state in DockStates)
            {
                Rectangle rectTabStrip = GetLogicalTabStripRectangle(state, true);
                if (!rectTabStrip.Contains(ptMouse))
                {
                    continue;
                }
                foreach (Pane pane in GetPanes(state))
                {
                    foreach (Tab tab in pane.AutoHideTabs)
                    {
                        Rectangle rectTab = GetTabRectangle(tab, true);
                        rectTab.Intersect(rectTabStrip);
                        if (rectTab.Contains(ptMouse))
                        {
                            return tab.Content;
                        }
                    }
                }
            }
            return null;
        }
        protected internal override int MeasureHeight()
        {
            return Math.Max(ImageGapBottom + ImageGapTop + ImageHeight, Font.Height) + TabGapTop;
        }
        protected override void OnRefreshChanges()
        {
            CalculateTabs();
            Invalidate();
        }
    }
}
