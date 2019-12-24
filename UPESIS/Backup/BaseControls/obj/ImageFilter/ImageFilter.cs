﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using BaseControls.ImageBox.Imaging.Filters;

namespace BaseControls.ImageFilter
{

    public partial class ImageFilter : Control
    {
        private Bitmap previewImage;
        private Bitmap image;
        private IFilter filter;
        private Pen blackPen = new Pen(Color.Black, 1);
        private Cursor cursorHand;
        private Cursor cursorHandMove;

        private int areaWidth, areaHeight;
        private int imageX, imageY;
        private bool tracking = false;

        private int startTrackingX, startTrackingY;
        private int oldImageX, oldImageY;

        // Image property
        [Browsable(false)]
        public Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;

                if (value != null)
                {
                    // calculate size of preview area
                    areaWidth = Math.Min(ClientRectangle.Width - 2, image.Width);
                    areaHeight = Math.Min(ClientRectangle.Height - 2, image.Height);

                    // calculate image position
                    imageX = (image.Width - areaWidth) >> 1;
                    imageY = (image.Height - areaHeight) >> 1;
                }

                RefreshFilter();
            }
        }
        // Filter property
        [Browsable(false)]
        public IFilter Filter
        {
            set
            {
                filter = value;
                RefreshFilter();
            }
        }

        // Constructor
        public ImageFilter()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);


            // load cursors
            Assembly assembly = this.GetType().Assembly;
            //Byte[] Harrow = Properties.Resources.harrow;
            //Stream StrHarrow = new MemoryStream(Harrow);
            //Byte[] Hmove = Properties.Resources.hmove;
            //Stream StrHove = new MemoryStream(Hmove);
            cursorHand = new Cursor(assembly.GetManifestResourceStream("BaseControls.Resources.harrow.cur"));//new Cursor(StrHarrow);//
            cursorHandMove = new Cursor(assembly.GetManifestResourceStream("BaseControls.Resources.hmove.cur"));//new Cursor(StrHove); //
        }

        // Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blackPen.Dispose();

                if (previewImage != null)
                {
                    previewImage.Dispose();
                    cursorHand.Dispose();
                    cursorHandMove.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        // Initialize control
        private void InitializeComponent()
        {
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageFilter_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageFilter_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageFilter_MouseDown);
        }

        // Paint control
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            Rectangle rc = ClientRectangle;
            int width = rc.Width;
            int height = rc.Height;
            int x, y;

            // calculate size of preview area
            if (image != null)
            {
                width = areaWidth + 2;
                height = areaHeight + 2;
            }
            // calculate position of preview area
            x = (rc.Width - width) >> 1;
            y = (rc.Height - height) >> 1;

            // draw rectangle
            g.DrawRectangle(blackPen, x, y, width - 1, height - 1);

            x++;
            y++;

            if (image != null)
            {
                if (previewImage == null)
                {
                    // draw original image
                    g.DrawImage(image, new Rectangle(x, y, areaWidth, areaHeight), imageX, imageY, areaWidth, areaHeight, GraphicsUnit.Pixel);
                }
                else
                {
                    // draw preview image
                    g.DrawImage(previewImage, x, y, areaWidth, areaHeight);
                }
            }

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        // Refresh preview
        public void RefreshFilter()
        {
            // release old image
            if (previewImage != null)
            {
                previewImage.Dispose();
                previewImage = null;
            }

            if ((image != null) && (filter != null))
            {
                Bitmap tmp = image.Clone(new Rectangle(imageX, imageY, areaWidth, areaHeight), image.PixelFormat);

                try
                {
                    previewImage = filter.Apply(tmp);
                }
                catch (Exception)
                {
                }

                // release temp image
                tmp.Dispose();
            }

            // repaint
            Invalidate();
        }

        // On mouse move
        private void ImageFilter_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (image != null)
            {
                if (!tracking)
                {
                    // calculate position of preview area
                    int x = ((ClientRectangle.Width - areaWidth - 2) >> 1) + 1;
                    int y = ((ClientRectangle.Height - areaHeight - 2) >> 1) + 1;

                    // check mouse coordinates
                    if ((e.X >= x) && (e.Y >= y) &&
                        (e.X < x + areaWidth) && (e.Y < y + areaHeight))
                    {
                        Cursor = cursorHand;
                    }
                    else
                        Cursor = Cursors.Default;
                }
                else
                {
                    int dx = e.X - startTrackingX;
                    int dy = e.Y - startTrackingY;

                    imageX = Math.Max(0, Math.Min(image.Width - areaWidth, oldImageX - dx));
                    imageY = Math.Max(0, Math.Min(image.Height - areaHeight, oldImageY - dy));

                    Invalidate();

                    Cursor = cursorHandMove;
                }
            }
        }

        // On mouse button down
        private void ImageFilter_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((image != null) && (e.Button == MouseButtons.Left))
            {
                // start tracking
                tracking = true;
                Capture = true;

                startTrackingX = e.X;
                startTrackingY = e.Y;

                oldImageX = imageX;
                oldImageY = imageY;

                // release preview image
                if (previewImage != null)
                {
                    previewImage.Dispose();
                    previewImage = null;
                }
                // repaint
                Invalidate();

                // set cursor
                Cursor = cursorHandMove;
            }
        }

        // On mouse button up
        private void ImageFilter_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (tracking)
            {
                // stop tracking
                tracking = false;
                Capture = false;

                RefreshFilter();

                // set cursor
                Cursor = cursorHand;
            }
        }
    }



}
