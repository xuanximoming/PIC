using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml;
using BaseControls.ImageBox;
using BaseControls.ImageBox.DrawTools;
using BaseControls.ImageBox.Imaging.Filters;
using BaseControls.ImageBox.Imaging;
using BaseControls.ImageBox.Imaging.Textures;
using ILL;
using System.Windows.Forms;
namespace SIS.ImgProcess
{
    class ReadImageFromXML
    {

        private XmlDocument xmlDoc;
        private string XmlPath = Application.StartupPath + "\\Config\\BackImgprocessed.xml";
        private XmlElement xmlE;
        private string ImageName;
        private IFilter filter;

        public ReadImageFromXML()
        {
        }

        public ReadImageFromXML( string ImageName)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlPath);
            this.ImageName = ImageName;
        }

        public void GetImageProcess()//显示图片时读取
        {
            XmlNode node = xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + ImageName + "'] ");
            if(node!=null)
            {
                if(node.HasChildNodes)
                {
                    XmlNodeList xmlNolist = node.ChildNodes;
                    foreach(XmlNode xn in xmlNolist)
                    {
                        XmlElement xmlE = (XmlElement)xn;
                        switch(xmlE.Name)
                        {
                            case "DrawLine":
                                DrawLine dl = new DrawLine(Convert.ToInt32(xmlE.GetAttribute("StartPointX")), Convert.ToInt32(xmlE.GetAttribute("StartPointY")), Convert.ToInt32(xmlE.GetAttribute("EndPointX")), Convert.ToInt32(xmlE.GetAttribute("EndPointY")));                              
                                dl.ID =  Convert.ToInt32(xmlE.GetAttribute("ID"));
                                frmImgProcess.imgProcess.drawArea.GraphicsList.UnselectAll();
                                frmImgProcess.imgProcess.drawArea.GraphicsList.Add(dl);
                                frmImgProcess.imgProcess.drawArea.Capture = true;
                                frmImgProcess.imgProcess.drawArea.Refresh();
                                break;
                            case "DrawRectangle":
                                DrawRectangle dr = new DrawRectangle(Convert.ToInt32(xmlE.GetAttribute("X")), Convert.ToInt32(xmlE.GetAttribute("Y")), Convert.ToInt32(xmlE.GetAttribute("Width")), Convert.ToInt32(xmlE.GetAttribute("Height")));
                                dr.ID = Convert.ToInt32(xmlE.GetAttribute("ID"));
                                frmImgProcess.imgProcess.drawArea.GraphicsList.UnselectAll();
                                frmImgProcess.imgProcess.drawArea.GraphicsList.Add(dr);
                                frmImgProcess.imgProcess.drawArea.Capture = true;
                                frmImgProcess.imgProcess.drawArea.Refresh();
                                break;

                            case "DrawEllipse":
                                DrawEllipse de = new DrawEllipse(Convert.ToInt32(xmlE.GetAttribute("X")), Convert.ToInt32(xmlE.GetAttribute("Y")), Convert.ToInt32(xmlE.GetAttribute("Width")), Convert.ToInt32(xmlE.GetAttribute("Height")));
                                de.ID = Convert.ToInt32(xmlE.GetAttribute("ID"));
                                frmImgProcess.imgProcess.drawArea.GraphicsList.UnselectAll();
                                frmImgProcess.imgProcess.drawArea.GraphicsList.Add(de);
                                frmImgProcess.imgProcess.drawArea.Capture = true;
                                frmImgProcess.imgProcess.drawArea.Refresh();
                                break;

                            case "DrawPoint":
                                DrawPoint dp = new DrawPoint(Convert.ToInt32(xmlE.GetAttribute("X")), Convert.ToInt32(xmlE.GetAttribute("Y")));
                                dp.ID = Convert.ToInt32(xmlE.GetAttribute("ID"));
                                frmImgProcess.imgProcess.drawArea.GraphicsList.UnselectAll();
                                frmImgProcess.imgProcess.drawArea.GraphicsList.Add(dp);
                                frmImgProcess.imgProcess.drawArea.Capture = true;
                                frmImgProcess.imgProcess.drawArea.Refresh();
                                break;

                            case "DrawPolygon":
                                DrawPolygon dpy = new DrawPolygon();
                                string pointStr = xmlE.GetAttribute("pointStr");
                                string[] poList = pointStr.Split('$');
                                string[] p ={ };
                                for (int i = 0; i < poList.Length;i++ )
                                {
                                    if(poList[i].ToString()!="")
                                    {
                                        p = poList[i].Split(',');
                                        Point point = new Point(Convert.ToInt32(p[0]),Convert.ToInt32(p[1]));
                                        dpy.pointArray.Add(point);
                                    }
                                }
                                dpy.ID = Convert.ToInt32(xmlE.GetAttribute("ID"));
                                frmImgProcess.imgProcess.drawArea.GraphicsList.UnselectAll();
                                frmImgProcess.imgProcess.drawArea.GraphicsList.Add(dpy);
                                frmImgProcess.imgProcess.drawArea.Capture = true;
                                frmImgProcess.imgProcess.drawArea.Refresh();
                                break;
                            case "TextBox":
                                ToolText tx = new ToolText(frmImgProcess.imgProcess.drawArea);
                                tx.Location = new Point(Convert.ToInt32(xmlE.GetAttribute("X")), Convert.ToInt32(xmlE.GetAttribute("Y")));
                                tx.Width = Convert.ToInt32(xmlE.GetAttribute("Width"));
                                tx.Height = Convert.ToInt32(xmlE.GetAttribute("Height"));
                                tx.Name = xmlE.GetAttribute("ID");
                                tx.Min = true;
                                tx.Max = true;
                                tx.IsChangeSize = true;
                                tx.ReadOnly = false;
                                tx.IsMove = true;
                                tx.Text = xmlE.GetAttribute("Content");
                                tx.ForeColor = System.Drawing.Color.Red;
                                frmImgProcess.imgProcess.drawArea.Controls.Add(tx);
                                break;
                            case "Process":
                                XmlNode nodeProcess = xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + ImageName + "']/Process ");
                                if (nodeProcess != null)
                                {
                                    if (nodeProcess.HasChildNodes)
                                    {
                                        XmlNodeList xmlNodeProcesslist = nodeProcess.ChildNodes;
                                        foreach (XmlNode xn2 in xmlNodeProcesslist)
                                        {
                                            XmlElement xmlE2 = (XmlElement)xn2;

                                            switch (xmlE2.Name)
                                            {
                                                case "BrightnessCorrection"://亮度
                                                    BrightnessCorrection brightnesscorr = new BrightnessCorrection();
                                                    brightnesscorr.AdjustValue = double.Parse(xmlE2.GetAttribute("Value"));
                                                    frmImgProcess.imgProcess.ApplyFilter(brightnesscorr);
                                                    break;
                                                case "ContrastCorrection"://对比
                                                    ContrastCorrection contrastCorr = new ContrastCorrection();
                                                    contrastCorr.Factor = double.Parse(xmlE2.GetAttribute("Value"));
                                                    frmImgProcess.imgProcess.ApplyFilter(contrastCorr);
                                                    break;
                                                case "HueModifier"://色相
                                                    HueModifier huemodifier = new HueModifier();
                                                    huemodifier.Hue = int.Parse(xmlE2.GetAttribute("Value"));
                                                    frmImgProcess.imgProcess.ApplyFilter(huemodifier);
                                                    break;                                                    
                                                case "Saturation"://饱和度
                                                    SaturationCorrection saturationcorr = new SaturationCorrection();
                                                    saturationcorr.AdjustValue = double.Parse(xmlE2.GetAttribute("Value"));
                                                    frmImgProcess.imgProcess.ApplyFilter(saturationcorr);
                                                    break;
                                                case "GrayscaleBT709"://灰度
                                                    GrayscaleBT709 grayscalebt = new GrayscaleBT709();
                                                    frmImgProcess.imgProcess.ApplyFilter(grayscalebt);
                                                    break;
                                                case "Filter"://过滤
                                                    ColorFiltering colorfilter = new ColorFiltering();
                                                    IntRange red = new IntRange(0, 255);
                                                    IntRange green = new IntRange(0, 255);
                                                    IntRange blue = new IntRange(0, 255);
                                                    byte fillR = 0, fillG = 0, fillB = 0;
                                                    string fillType = "";
                                                    red.Min = int.Parse(xmlE2.GetAttribute("RedMin"));
                                                    red.Max = int.Parse(xmlE2.GetAttribute("RedMax"));
                                                    green.Min = int.Parse(xmlE2.GetAttribute("GreenMin"));
                                                    green.Max = int.Parse(xmlE2.GetAttribute("GreenMax"));
                                                    blue.Min = int.Parse(xmlE2.GetAttribute("BlueMin"));
                                                    blue.Max = int.Parse(xmlE2.GetAttribute("BlueMax"));
                                                    fillR = byte.Parse(xmlE2.GetAttribute("FillRed"));
                                                    fillG = byte.Parse(xmlE2.GetAttribute("FillGreen"));
                                                    fillB = byte.Parse(xmlE2.GetAttribute("FillBlue"));
                                                    fillType = xmlE2.GetAttribute("FillType");
                                                    colorfilter.Red = red;
                                                    colorfilter.Green = green;
                                                    colorfilter.Blue = blue;
                                                    colorfilter.FillColor = new RGB(fillR, fillG, fillB);
                                                    if (fillType == "OutSide")
                                                        colorfilter.FillOutsideRange = true;
                                                    else
                                                        colorfilter.FillOutsideRange = false;
                                                    frmImgProcess.imgProcess.ApplyFilter(colorfilter);
                                                    break;
                                                case "Gaussian"://柔化
                                                    GaussianBlur gaussianBlur = new GaussianBlur();
                                                    gaussianBlur.Sigma = double.Parse(xmlE2.GetAttribute("Sigma"));
                                                    gaussianBlur.Size = int.Parse(xmlE2.GetAttribute("Size"));
                                                    frmImgProcess.imgProcess.ApplyFilter(gaussianBlur);
                                                    break;
                                                case "DifferenceEdgeDetector"://边缘增强
                                                    DifferenceEdgeDetector differenceEdgeD = new DifferenceEdgeDetector();
                                                    frmImgProcess.imgProcess.ApplyFilter(differenceEdgeD);
                                                    break; 
                                                case "RotateFlip"://镜像
                                                    frmImgProcess.imgProcess.drawArea.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                                    frmImgProcess.imgProcess.drawArea.Refresh();
                                                    break;
                                                case "PerlinNoise"://去噪
                                                    string value = "";
                                                    value = xmlE2.GetAttribute("Value");
                                 
                                                    float imageWidth=0;
                                                    float imageHeight=0;
                                                    switch(value)
                                                    {

                                                        case "Marble":
                                                            filter = new Texturer(new MarbleTexture(imageWidth / 96, imageHeight / 48), 0.7f, 0.3f);
                                                            break;
                                                        case "Wood":
                                                            filter = new Texturer(new WoodTexture(), 0.7f, 0.3f);
                                                            break;
                                                        case "Clouds":
                                                            filter = new Texturer(new CloudsTexture(), 0.7f, 0.3f);
                                                            break;
                                                        case "Labyrinth":
                                                            filter = new Texturer(new LabyrinthTexture(), 0.7f, 0.3f);
                                                            break;
                                                        case "Textile":
                                                            filter = new Texturer(new TextileTexture(), 0.7f, 0.3f);
                                                            break;
                                                        case "Dirty":
                                                            TexturedFilter f = new TexturedFilter(new CloudsTexture(), new Sepia());
                                                            f.PreserveLevel = 0.30f;
                                                            f.FilterLevel = 0.90f;
                                                            filter = f;                                                         
                                                            break;
                                                        case "Rusty":
                                                            filter = new TexturedFilter(new CloudsTexture(), new Sepia(), new GrayscaleBT709());
                                                            break;

                                                    }
                                                    frmImgProcess.imgProcess.ApplyFilter(filter);
                                                    break;
                                                case "Sharpen":
                                                    Sharpen sharpen = new Sharpen();
                                                    frmImgProcess.imgProcess.ApplyFilter(sharpen);
                                                    break;
                                                case "Mean":
                                                    Mean mean = new Mean();
                                                    frmImgProcess.imgProcess.ApplyFilter(mean);
                                                    break; 
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        public bool SetPoint(ImageCtl drawArea, string value)
        {
            try
            {
                string[] s = value.Split(';');
                DrawPoint dp = new DrawPoint(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]));
                dp.ID = Convert.ToInt32(s[2]);
                drawArea.GraphicsList.UnselectAll();
                drawArea.GraphicsList.Add(dp);
                drawArea.Capture = true;
                drawArea.Refresh();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //public IFilter GetImageProcess(string processName)//
        //{
        //    XmlNode nodeProcess = xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + ImageName + "']/Process ");
        //    if (nodeProcess != null)
        //    {
        //        if (nodeProcess.HasChildNodes)
        //        {
        //            XmlElement xmlE2 = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + ImageName + "']/Process/" + processName);
        //            if (xmlE2 != null)
        //                switch (processName)
        //                {
        //                    case "BrightnessCorrection"://亮度
        //                        BrightnessCorrection brightnesscorr = new BrightnessCorrection();
        //                        brightnesscorr.AdjustValue = double.Parse(xmlE2.GetAttribute("Value"));
        //                        return brightnesscorr;
        //                    case "ContrastCorrection"://对比
        //                        ContrastCorrection contrastCorr = new ContrastCorrection();
        //                        contrastCorr.Factor = double.Parse(xmlE2.GetAttribute("Value"));
        //                        return contrastCorr;
        //                    case "HueModifier"://色相
        //                        HueModifier huemodifier = new HueModifier();
        //                        huemodifier.Hue = int.Parse(xmlE2.GetAttribute("Value"));
        //                        return huemodifier;
        //                    case "Saturation"://饱和度
        //                        SaturationCorrection saturationcorr = new SaturationCorrection();
        //                        saturationcorr.AdjustValue = double.Parse(xmlE2.GetAttribute("Value"));
        //                        return saturationcorr;

        //                    case "Filter"://过滤
        //                        ColorFiltering colorfilter = new ColorFiltering();
        //                        IntRange red = new IntRange(0, 255);
        //                        IntRange green = new IntRange(0, 255);
        //                        IntRange blue = new IntRange(0, 255);
        //                        byte fillR = 0, fillG = 0, fillB = 0;
        //                        string fillType = "";
        //                        red.Min = int.Parse(xmlE2.GetAttribute("RedMin"));
        //                        red.Max = int.Parse(xmlE2.GetAttribute("RedMax"));
        //                        green.Min = int.Parse(xmlE2.GetAttribute("GreenMin"));
        //                        green.Max = int.Parse(xmlE2.GetAttribute("GreenMax"));
        //                        blue.Min = int.Parse(xmlE2.GetAttribute("BlueMin"));
        //                        blue.Max = int.Parse(xmlE2.GetAttribute("BlueMax"));
        //                        fillR = byte.Parse(xmlE2.GetAttribute("FillRed"));
        //                        fillG = byte.Parse(xmlE2.GetAttribute("FillGreen"));
        //                        fillB = byte.Parse(xmlE2.GetAttribute("FillBlue"));
        //                        fillType = xmlE2.GetAttribute("FillType");
        //                        colorfilter.Red = red;
        //                        colorfilter.Green = green;
        //                        colorfilter.Blue = blue;
        //                        colorfilter.FillColor = new RGB(fillR, fillG, fillB);
        //                        if (fillType == "OutSide")
        //                            colorfilter.FillOutsideRange = true;
        //                        else
        //                            colorfilter.FillOutsideRange = false;
        //                        return colorfilter;
        //                    case "Gaussian"://柔化
        //                        GaussianBlur gaussianBlur = new GaussianBlur();
        //                        gaussianBlur.Sigma = double.Parse(xmlE2.GetAttribute("Sigma"));
        //                        gaussianBlur.Size = int.Parse(xmlE2.GetAttribute("Size"));
        //                        return gaussianBlur;
        //                    case "PerlinNoise"://去噪
        //                        string value = "";
        //                        value = xmlE2.GetAttribute("Value");
        //                        float imageWidth = 0;
        //                        float imageHeight = 0;
        //                        switch (value)
        //                        {

        //                            case "Marble":
        //                                filter = new Texturer(new MarbleTexture(imageWidth / 96, imageHeight / 48), 0.7f, 0.3f);
        //                                break;
        //                            case "Wood":
        //                                filter = new Texturer(new WoodTexture(), 0.7f, 0.3f);
        //                                break;
        //                            case "Clouds":
        //                                filter = new Texturer(new CloudsTexture(), 0.7f, 0.3f);
        //                                break;
        //                            case "Labyrinth":
        //                                filter = new Texturer(new LabyrinthTexture(), 0.7f, 0.3f);
        //                                break;
        //                            case "Textile":
        //                                filter = new Texturer(new TextileTexture(), 0.7f, 0.3f);
        //                                break;
        //                            case "Dirty":
        //                                TexturedFilter f = new TexturedFilter(new CloudsTexture(), new Sepia());
        //                                f.PreserveLevel = 0.30f;
        //                                f.FilterLevel = 0.90f;
        //                                filter = f;
        //                                break;
        //                            case "Rusty":
        //                                filter = new TexturedFilter(new CloudsTexture(), new Sepia(), new GrayscaleBT709());
        //                                break;

        //                        }
        //                        return filter; 
        //                }
        //        }
        //    }
        //    return null;
        //}
    }
}
