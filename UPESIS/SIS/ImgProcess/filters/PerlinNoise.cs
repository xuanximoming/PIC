using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BaseControls.ImageBox.Imaging.Filters;
using BaseControls.ImageBox.Imaging.Textures;

namespace SIS.ImgProcess.filters
{
    public partial class PerlinNoise : UserControl
    {
        private Point p;
        private IFilter filter;
        private float imageWidth;
        private float imageHeight;
        private SaveBackImageToXml saveImgToXml;
        private String flag;
        public PerlinNoise()
        {
            InitializeComponent();
            drawArea.Image = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            saveImgToXml = new SaveBackImageToXml();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PerlinNoise_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }

        private void PerlinNoise_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Arrow;
            if (e.Button == MouseButtons.Left)
            {
                Point mousePoint = Control.MousePosition;
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePoint);
            }
        }

        private void cb_EffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_EffectType.SelectedIndex)
            {
                case 0:			// Marble effect
                    filter = new Texturer(new MarbleTexture(imageWidth / 96, imageHeight / 48), 0.7f, 0.3f);
                    flag = "Marble";
                    break;
                case 1:			// Wood effect
                    filter = new Texturer(new WoodTexture(), 0.7f, 0.3f);
                    flag = "Wood";
                    break;
                case 2:			// Clouds
                    filter = new Texturer(new CloudsTexture(), 0.7f, 0.3f);
                    flag = "Clouds";
                    break;
                case 3:			// Labyrinth
                    filter = new Texturer(new LabyrinthTexture(), 0.7f, 0.3f);
                    flag = "Labyrinth";
                    break;
                case 4:			// Textile
                    filter = new Texturer(new TextileTexture(), 0.7f, 0.3f);
                    flag = "Textile";
                    break;
                case 5:			// Dirty
                    TexturedFilter f = new TexturedFilter(new CloudsTexture(), new Sepia());

                    f.PreserveLevel = 0.30f;
                    f.FilterLevel = 0.90f;

                    filter = f;
                    flag = "Dirty";
                    break;
                case 6:			// Rusty
                    filter = new TexturedFilter(new CloudsTexture(), new Sepia(), new GrayscaleBT709());
                    flag = "Rusty";
                    break;
            }
            drawArea.Filter = filter;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            frmImgProcess.imgProcess.ApplyFilter(filter);
            saveImgToXml.SaveImgProcess(frmImgProcess.imgProcess.drawArea, frmImgProcess.imgProcess.lb_ImageName.Text, flag);
           
        }

    }
}
