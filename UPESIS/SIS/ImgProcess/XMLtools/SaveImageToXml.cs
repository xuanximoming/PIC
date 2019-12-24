using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
using BaseControls.ImageBox;
using BaseControls.ImageBox.DrawTools;
using BaseControls.ImageBox.Imaging.Filters;
using BaseControls.ImageBox.Imaging;
using ILL;

namespace SIS.ImgProcess
{
    public class SaveImageToXml
    {
        private XmlDocument xmlDoc;
        private string XmlPath = Application.StartupPath + "\\Config\\BackImgprocessed.xml";
        private XmlElement xmlE;
        public SaveImageToXml()
        {
            xmlDoc = new XmlDocument();
        }

        public string SaveImageToXml2(ImageCtl drawArea, string imageName)
        {
            string xml = "";
            xmlDoc.Load(XmlPath);
            xmlE = null;
            XmlElement root = xmlDoc.DocumentElement;
            XmlNode node = xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] ");
            if (node == null)//新图片记录
            {

                xmlE = xmlDoc.CreateElement("Image");
                XmlAttribute xmlA = xmlDoc.CreateAttribute("Name");
                XmlText xt = xmlDoc.CreateTextNode(imageName);
                xmlE.Attributes.Append(xmlA);
                xmlA.AppendChild(xt);
            }
            else//已处理过
            {
                for (int i = 0; i < ((XmlElement)node).ChildNodes.Count; i++)
                {
                    XmlElement xx = (XmlElement)(node.ChildNodes[i]);
                    if (xx.Name != "Process")
                        node.RemoveChild(xx);
                }
                xmlE = (XmlElement)node;
            }
            DrawObject o = null;
            TextBox xtb = new TextBox();
            for (int k = 0; k < drawArea.Controls.Count; k++)//查找textbox
            {
                if ((drawArea.Controls[k].GetType().FullName == "BaseControls.ImageBox.DrawTools.XTextBox" || drawArea.Controls[k].GetType().FullName == "SIS.ImgProcess.ToolText") && drawArea.Controls[k].Name != "")
                {


                    xtb = (TextBox)drawArea.Controls[k];
                    XmlElement nodeNext = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "']/TextBox[@ID='" + xtb.Name + "']");
                    if (nodeNext != null)
                    {
                        nodeNext.SetAttribute("X", xtb.Location.X.ToString());
                        nodeNext.SetAttribute("Y", xtb.Location.Y.ToString());
                        nodeNext.SetAttribute("Width", xtb.Size.Width.ToString());
                        nodeNext.SetAttribute("Height", xtb.Size.Height.ToString());
                        nodeNext.SetAttribute("Content", xtb.Text);
                    }
                    else
                    {
                        XmlElement xmlText = xmlDoc.CreateElement("TextBox");

                        XmlAttribute xmlATextID = xmlDoc.CreateAttribute("ID");
                        XmlText xtTextID = xmlDoc.CreateTextNode(xtb.Name);

                        XmlAttribute xmlATextX = xmlDoc.CreateAttribute("X");
                        XmlText xtTextX = xmlDoc.CreateTextNode(xtb.Location.X.ToString());

                        XmlAttribute xmlATextY = xmlDoc.CreateAttribute("Y");
                        XmlText xtTextY = xmlDoc.CreateTextNode(xtb.Location.Y.ToString());

                        XmlAttribute xmlATextWidth = xmlDoc.CreateAttribute("Width");
                        XmlText xtTextWidth = xmlDoc.CreateTextNode(xtb.Size.Width.ToString());

                        XmlAttribute xmlATextHeight = xmlDoc.CreateAttribute("Height");
                        XmlText xtTextHeight = xmlDoc.CreateTextNode(xtb.Size.Height.ToString());

                        XmlAttribute xmlATextContent = xmlDoc.CreateAttribute("Content");
                        XmlText xtTextContent = xmlDoc.CreateTextNode(xtb.Text);

                        xmlText.Attributes.Append(xmlATextID);
                        xmlATextID.AppendChild(xtTextID);

                        xmlText.Attributes.Append(xmlATextX);
                        xmlATextX.AppendChild(xtTextX);

                        xmlText.Attributes.Append(xmlATextY);
                        xmlATextY.AppendChild(xtTextY);

                        xmlText.Attributes.Append(xmlATextWidth);
                        xmlATextWidth.AppendChild(xtTextWidth);


                        xmlText.Attributes.Append(xmlATextHeight);
                        xmlATextHeight.AppendChild(xtTextHeight);

                        xmlText.Attributes.Append(xmlATextContent);
                        xmlATextContent.AppendChild(xtTextContent);

                        xmlE.AppendChild(xmlText);

                    }
                }
            }

            for (int i = 0; i < drawArea.GraphicsList.Count; i++)//查找连接线、椭圆、矩形、箭头
            {

                o = drawArea.GraphicsList[i];
                switch (o.GetType().FullName)
                {
                    case "BaseControls.ImageBox.DrawTools.DrawLine":

                        XmlElement nodeNext = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "']/DrawLine[@ID='" + o.ID.ToString() + "']");
                        if (nodeNext != null)
                        {
                            nodeNext.SetAttribute("StartPointX", ((DrawLine)o).startPoint.X.ToString());
                            nodeNext.SetAttribute("StartPointY", ((DrawLine)o).startPoint.Y.ToString());
                            nodeNext.SetAttribute("EndPointX", ((DrawLine)o).endPoint.X.ToString());
                            nodeNext.SetAttribute("EndPointY", ((DrawLine)o).endPoint.Y.ToString());
                        }
                        else
                        {
                            XmlElement xmlEDrawLine = xmlDoc.CreateElement("DrawLine");

                            XmlAttribute xmlADrawLineID = xmlDoc.CreateAttribute("ID");
                            XmlText xtDrawLineIDt = xmlDoc.CreateTextNode(o.ID.ToString());

                            XmlAttribute xmlADrawLineSartX = xmlDoc.CreateAttribute("StartPointX");
                            XmlText xtDrawLineStartXT = xmlDoc.CreateTextNode(((DrawLine)o).startPoint.X.ToString());
                            XmlAttribute xmlADrawLineSartY = xmlDoc.CreateAttribute("StartPointY");
                            XmlText xtDrawLineStartYT = xmlDoc.CreateTextNode(((DrawLine)o).startPoint.Y.ToString());

                            XmlAttribute xmlADrawLineEndX = xmlDoc.CreateAttribute("EndPointX");
                            XmlText xtDrawLineEndXT = xmlDoc.CreateTextNode(((DrawLine)o).endPoint.X.ToString());
                            XmlAttribute xmlADrawLineEndY = xmlDoc.CreateAttribute("EndPointY");
                            XmlText xtDrawLineEndYT = xmlDoc.CreateTextNode(((DrawLine)o).endPoint.Y.ToString());

                            xmlEDrawLine.Attributes.Append(xmlADrawLineID);
                            xmlADrawLineID.AppendChild(xtDrawLineIDt);

                            xmlEDrawLine.Attributes.Append(xmlADrawLineSartX);
                            xmlADrawLineSartX.AppendChild(xtDrawLineStartXT);
                            xmlEDrawLine.Attributes.Append(xmlADrawLineSartY);
                            xmlADrawLineSartY.AppendChild(xtDrawLineStartYT);

                            xmlEDrawLine.Attributes.Append(xmlADrawLineEndX);
                            xmlADrawLineEndX.AppendChild(xtDrawLineEndXT);
                            xmlEDrawLine.Attributes.Append(xmlADrawLineEndY);
                            xmlADrawLineEndY.AppendChild(xtDrawLineEndYT);

                            xmlE.AppendChild(xmlEDrawLine);

                        }

                        break;
                    case "BaseControls.ImageBox.DrawTools.DrawRectangle":

                        XmlElement nodeNext2 = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "']/DrawRectangle[@ID='" + o.ID.ToString() + "']");
                        if (nodeNext2 != null)
                        {
                            nodeNext2.SetAttribute("X", ((DrawRectangle)o).rectangle.X.ToString());
                            nodeNext2.SetAttribute("Y", ((DrawRectangle)o).rectangle.Y.ToString());
                            nodeNext2.SetAttribute("Width", ((DrawRectangle)o).rectangle.Width.ToString());
                            nodeNext2.SetAttribute("Height", ((DrawRectangle)o).rectangle.Height.ToString());
                        }
                        else
                        {
                            XmlElement xmlEDrawRectangle = xmlDoc.CreateElement("DrawRectangle");

                            XmlAttribute xmlADrawRectangleID = xmlDoc.CreateAttribute("ID");
                            XmlText xtDrawRectangleIDt = xmlDoc.CreateTextNode(o.ID.ToString());

                            XmlAttribute xmlADrawRectangleX = xmlDoc.CreateAttribute("X");
                            XmlText xtDrawRectangleXT = xmlDoc.CreateTextNode(((DrawRectangle)o).rectangle.X.ToString());
                            XmlAttribute xmlADrawRectangleY = xmlDoc.CreateAttribute("Y");
                            XmlText xtDrawRectangleYT = xmlDoc.CreateTextNode(((DrawRectangle)o).rectangle.Y.ToString());

                            XmlAttribute xmlADrawRectangleWidth = xmlDoc.CreateAttribute("Width");
                            XmlText xtDrawRectangleWidth = xmlDoc.CreateTextNode(((DrawRectangle)o).rectangle.Width.ToString());
                            XmlAttribute xmlADrawRectangleHeight = xmlDoc.CreateAttribute("Height");
                            XmlText xtDrawRectangleHeight = xmlDoc.CreateTextNode(((DrawRectangle)o).rectangle.Height.ToString());

                            xmlEDrawRectangle.Attributes.Append(xmlADrawRectangleID);
                            xmlADrawRectangleID.AppendChild(xtDrawRectangleIDt);

                            xmlEDrawRectangle.Attributes.Append(xmlADrawRectangleX);
                            xmlADrawRectangleX.AppendChild(xtDrawRectangleXT);
                            xmlEDrawRectangle.Attributes.Append(xmlADrawRectangleY);
                            xmlADrawRectangleY.AppendChild(xtDrawRectangleYT);

                            xmlEDrawRectangle.Attributes.Append(xmlADrawRectangleWidth);
                            xmlADrawRectangleWidth.AppendChild(xtDrawRectangleWidth);
                            xmlEDrawRectangle.Attributes.Append(xmlADrawRectangleHeight);
                            xmlADrawRectangleHeight.AppendChild(xtDrawRectangleHeight);

                            xmlE.AppendChild(xmlEDrawRectangle);


                        }

                        break;
                    case "BaseControls.ImageBox.DrawTools.DrawEllipse":
                        XmlElement nodeNext3 = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "']/DrawEllipse[@ID='" + o.ID.ToString() + "']");
                        if (nodeNext3 != null)
                        {
                            nodeNext3.SetAttribute("X", ((DrawEllipse)o).rectangle.X.ToString());
                            nodeNext3.SetAttribute("Y", ((DrawEllipse)o).rectangle.Y.ToString());
                            nodeNext3.SetAttribute("Width", ((DrawEllipse)o).rectangle.Width.ToString());
                            nodeNext3.SetAttribute("Height", ((DrawEllipse)o).rectangle.Height.ToString());
                        }
                        else
                        {
                            XmlElement xmlEDrawEllipse = xmlDoc.CreateElement("DrawEllipse");

                            XmlAttribute xmlADrawEllipseID = xmlDoc.CreateAttribute("ID");
                            XmlText xtDrawEllipseIDt = xmlDoc.CreateTextNode(o.ID.ToString());

                            XmlAttribute xmlADrawEllipseeX = xmlDoc.CreateAttribute("X");
                            XmlText xtDrawEllipseXT = xmlDoc.CreateTextNode(((DrawEllipse)o).rectangle.X.ToString());
                            XmlAttribute xmlADrawEllipseY = xmlDoc.CreateAttribute("Y");
                            XmlText xtDrawEllipseYT = xmlDoc.CreateTextNode(((DrawEllipse)o).rectangle.Y.ToString());

                            XmlAttribute xmlADrawEllipseWidth = xmlDoc.CreateAttribute("Width");
                            XmlText xtDrawEllipseWidth = xmlDoc.CreateTextNode(((DrawEllipse)o).rectangle.Width.ToString());
                            XmlAttribute xmlADrawEllipseHeight = xmlDoc.CreateAttribute("Height");
                            XmlText xtDrawEllipseHeight = xmlDoc.CreateTextNode(((DrawEllipse)o).rectangle.Height.ToString());

                            xmlEDrawEllipse.Attributes.Append(xmlADrawEllipseID);
                            xmlADrawEllipseID.AppendChild(xtDrawEllipseIDt);

                            xmlEDrawEllipse.Attributes.Append(xmlADrawEllipseeX);
                            xmlADrawEllipseeX.AppendChild(xtDrawEllipseXT);
                            xmlEDrawEllipse.Attributes.Append(xmlADrawEllipseY);
                            xmlADrawEllipseY.AppendChild(xtDrawEllipseYT);

                            xmlEDrawEllipse.Attributes.Append(xmlADrawEllipseWidth);
                            xmlADrawEllipseWidth.AppendChild(xtDrawEllipseWidth);
                            xmlEDrawEllipse.Attributes.Append(xmlADrawEllipseHeight);
                            xmlADrawEllipseHeight.AppendChild(xtDrawEllipseHeight);

                            xmlE.AppendChild(xmlEDrawEllipse);
                        }

                        break;
                    case "BaseControls.ImageBox.DrawTools.DrawPoint":
                        XmlElement nodeNext4 = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "']/DrawPoint[@ID='" + o.ID.ToString() + "']");
                        if (nodeNext4 != null)
                        {
                            nodeNext4.SetAttribute("X", ((DrawPoint)o).Point.X.ToString());
                            nodeNext4.SetAttribute("Y", ((DrawPoint)o).Point.Y.ToString());
                        }
                        else
                        {
                            XmlElement xmlEDrawPoint = xmlDoc.CreateElement("DrawPoint");

                            XmlAttribute xmlADrawPointID = xmlDoc.CreateAttribute("ID");
                            XmlText xtDrawPointIDt = xmlDoc.CreateTextNode(o.ID.ToString());

                            XmlAttribute xmlADrawPointX = xmlDoc.CreateAttribute("X");
                            XmlText xtDrawPointXT = xmlDoc.CreateTextNode(((DrawPoint)o).Point.X.ToString());
                            XmlAttribute xmlADrawPointY = xmlDoc.CreateAttribute("Y");
                            XmlText xtDrawPointYT = xmlDoc.CreateTextNode(((DrawPoint)o).Point.Y.ToString());

                            xmlEDrawPoint.Attributes.Append(xmlADrawPointID);
                            xmlADrawPointID.AppendChild(xtDrawPointIDt);

                            xmlEDrawPoint.Attributes.Append(xmlADrawPointX);
                            xmlADrawPointX.AppendChild(xtDrawPointXT);
                            xmlEDrawPoint.Attributes.Append(xmlADrawPointY);
                            xmlADrawPointY.AppendChild(xtDrawPointYT);

                            xmlE.AppendChild(xmlEDrawPoint);

                        }
                        break;

                    case "BaseControls.ImageBox.DrawTools.DrawPolygon":
                        XmlElement nodeNext5 = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "']/DrawPolygon[@ID='" + o.ID.ToString() + "']");
                        if (nodeNext5 != null)
                        {
                            nodeNext5.SetAttribute("StartPointX", ((DrawPolygon)o).startPoint.X.ToString());
                            nodeNext5.SetAttribute("StartPointY", ((DrawPolygon)o).startPoint.Y.ToString());
                            nodeNext5.SetAttribute("EndPointX", ((DrawPolygon)o).endPoint.X.ToString());
                            nodeNext5.SetAttribute("EndPointX", ((DrawPolygon)o).endPoint.Y.ToString());

                            Point p = new Point();
                            string pointStr = "$";
                            for (int j = 0; j < ((DrawPolygon)o).pointArray.Count; j++)
                            {
                                p = ((DrawPolygon)o).pointArray[j];
                                pointStr = pointStr + p.X + "," + p.Y + "$";

                            }
                            nodeNext5.SetAttribute("pointStr", pointStr);
                        }
                        else
                        {
                            XmlElement xmlEDrawPolygon = xmlDoc.CreateElement("DrawPolygon");

                            XmlAttribute xmlADrawPolygonID = xmlDoc.CreateAttribute("ID");
                            XmlText xtDrawPolygonIDt = xmlDoc.CreateTextNode(o.ID.ToString());

                            XmlAttribute xmlADrawPolygonSartX = xmlDoc.CreateAttribute("StartPointX");
                            XmlText xtDrawPolygonStartXT = xmlDoc.CreateTextNode(((DrawPolygon)o).startPoint.X.ToString());
                            XmlAttribute xmlADrawPolygonSartY = xmlDoc.CreateAttribute("StartPointY");
                            XmlText xtDrawPolygonStartYT = xmlDoc.CreateTextNode(((DrawPolygon)o).startPoint.Y.ToString());

                            XmlAttribute xmlADrawPolygonEndX = xmlDoc.CreateAttribute("EndPointX");
                            XmlText xtDrawPolygonEndXT = xmlDoc.CreateTextNode(((DrawPolygon)o).endPoint.X.ToString());
                            XmlAttribute xmlADrawPolygonEndY = xmlDoc.CreateAttribute("EndPointY");
                            XmlText xtDrawPolygonEndYT = xmlDoc.CreateTextNode(((DrawPolygon)o).endPoint.Y.ToString());

                            XmlAttribute xmlADrawPloygonPoint = xmlDoc.CreateAttribute("pointStr");
                            Point p = new Point();
                            string pointStr = "$";
                            for (int j = 0; j < ((DrawPolygon)o).pointArray.Count; j++)
                            {
                                p = ((DrawPolygon)o).pointArray[j];
                                pointStr = pointStr + p.X + "," + p.Y + "$";

                            }
                            XmlText xtDrawPloygonPoint = xmlDoc.CreateTextNode(pointStr);


                            xmlEDrawPolygon.Attributes.Append(xmlADrawPolygonID);
                            xmlADrawPolygonID.AppendChild(xtDrawPolygonIDt);

                            xmlEDrawPolygon.Attributes.Append(xmlADrawPolygonSartX);
                            xmlADrawPolygonSartX.AppendChild(xtDrawPolygonStartXT);
                            xmlEDrawPolygon.Attributes.Append(xmlADrawPolygonSartY);
                            xmlADrawPolygonSartY.AppendChild(xtDrawPolygonStartYT);

                            xmlEDrawPolygon.Attributes.Append(xmlADrawPolygonEndX);
                            xmlADrawPolygonEndX.AppendChild(xtDrawPolygonEndXT);
                            xmlEDrawPolygon.Attributes.Append(xmlADrawPolygonEndY);
                            xmlADrawPolygonEndY.AppendChild(xtDrawPolygonEndYT);

                            xmlEDrawPolygon.Attributes.Append(xmlADrawPloygonPoint);
                            xmlADrawPloygonPoint.AppendChild(xtDrawPloygonPoint);

                            xmlE.AppendChild(xmlEDrawPolygon);
                        }
                        break;
                }
            }
            
            XmlNode xn = xmlDoc.SelectSingleNode("PatientBackImage");
            xn.AppendChild(xmlE);

            xmlDoc.Save(XmlPath);
            return xmlE.InnerXml;
        }


        public string SaveImgProcess(ImageCtl drawArea, string imageName, string processName, IFilter filter)//图像处理,另一个重载的方法 处理去噪
        {
            xmlDoc.Load(XmlPath);
            xmlE = null;
            XmlNode node = xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] ");
            if (node == null)
            {

                xmlE = xmlDoc.CreateElement("Image");
                XmlAttribute xmlA = xmlDoc.CreateAttribute("Name");
                XmlText xt = xmlDoc.CreateTextNode(imageName);
                xmlE.Attributes.Append(xmlA);
                xmlA.AppendChild(xt);
            }
            else
                xmlE = (XmlElement)node;

            XmlElement xmlENext = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process");
            if (xmlENext == null)
            {
                xmlENext = xmlDoc.CreateElement("Process");
                xmlE.AppendChild(xmlENext);
            }
            switch (processName)
            {
                case "BrightnessCorrection"://亮度

                    XmlElement xmlEBrightCorr = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/BrightnessCorrection");
                    if (xmlEBrightCorr != null)
                    {
                        xmlEBrightCorr.SetAttribute("Value", ((BrightnessCorrection)filter).AdjustValue.ToString());
                    }
                    else
                    {
                        xmlEBrightCorr = xmlDoc.CreateElement("BrightnessCorrection");

                        XmlAttribute xmlABrightCorr = xmlDoc.CreateAttribute("Value");
                        XmlText xmlTBrightCorr = xmlDoc.CreateTextNode(((BrightnessCorrection)filter).AdjustValue.ToString());

                        xmlEBrightCorr.Attributes.Append(xmlABrightCorr);
                        xmlABrightCorr.AppendChild(xmlTBrightCorr);

                        xmlENext.AppendChild(xmlEBrightCorr);
                    }


                    break;
                case "ContrastCorrection"://对比
                    XmlElement xmlEContrastCorr = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/ContrastCorrection");
                    if (xmlEContrastCorr != null)
                    {
                        xmlEContrastCorr.SetAttribute("Value", ((ContrastCorrection)filter).Factor.ToString());
                    }
                    else
                    {
                        xmlEContrastCorr = xmlDoc.CreateElement("ContrastCorrection");

                        XmlAttribute xmlAContrastCorr = xmlDoc.CreateAttribute("Value");
                        XmlText xmlTContrastCorr = xmlDoc.CreateTextNode(((ContrastCorrection)filter).Factor.ToString());

                        xmlEContrastCorr.Attributes.Append(xmlAContrastCorr);
                        xmlAContrastCorr.AppendChild(xmlTContrastCorr);

                        xmlENext.AppendChild(xmlEContrastCorr);

                    }
                    break;
                case "HueModifier"://色相

                    XmlElement xmlEHueModifier = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/HueModifier");
                    if (xmlEHueModifier != null)
                    {
                        xmlEHueModifier.SetAttribute("Value", ((HueModifier)filter).Hue.ToString());
                    }
                    else
                    {
                        xmlEHueModifier = xmlDoc.CreateElement("HueModifier");

                        XmlAttribute xmlAHueModifier = xmlDoc.CreateAttribute("Value");
                        XmlText xmlTHueModifier = xmlDoc.CreateTextNode(((HueModifier)filter).Hue.ToString());

                        xmlEHueModifier.Attributes.Append(xmlAHueModifier);
                        xmlAHueModifier.AppendChild(xmlTHueModifier);

                        xmlENext.AppendChild(xmlEHueModifier);

                    }
                    break;
                case "Saturation"://饱和度
                    XmlElement xmlESaturation = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/Saturation");
                    if (xmlESaturation != null)
                    {
                        xmlESaturation.SetAttribute("Value", ((SaturationCorrection)filter).AdjustValue.ToString());
                    }
                    else
                    {
                        xmlESaturation = xmlDoc.CreateElement("Saturation");

                        XmlAttribute xmlASaturation = xmlDoc.CreateAttribute("Value");
                        XmlText xmlTSaturation = xmlDoc.CreateTextNode(((SaturationCorrection)filter).AdjustValue.ToString());

                        xmlESaturation.Attributes.Append(xmlASaturation);
                        xmlASaturation.AppendChild(xmlTSaturation);

                        xmlENext.AppendChild(xmlESaturation);

                    }
                    break;

                case "GrayscaleBT709"://灰度
                    XmlElement xmlEGrayscaleBT709 = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/GrayscaleBT709");
                    if (xmlEGrayscaleBT709 == null)
                    {
                        xmlEGrayscaleBT709 = xmlDoc.CreateElement("GrayscaleBT709");
                        xmlENext.AppendChild(xmlEGrayscaleBT709);
                    }
                    break;

                case "Filter"://过滤

                    XmlElement xmlEFilter = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/Filter");
                    if (xmlEFilter != null)
                    {
                        xmlEFilter.SetAttribute("RedMin", ((ColorFiltering)filter).Red.Min.ToString());
                        xmlEFilter.SetAttribute("RedMax", ((ColorFiltering)filter).Red.Max.ToString());
                        xmlEFilter.SetAttribute("GreenMin", ((ColorFiltering)filter).Green.Min.ToString());
                        xmlEFilter.SetAttribute("GreenMax", ((ColorFiltering)filter).Green.Max.ToString());
                        xmlEFilter.SetAttribute("BlueMin", ((ColorFiltering)filter).Blue.Min.ToString());
                        xmlEFilter.SetAttribute("BlueMax", ((ColorFiltering)filter).Blue.Max.ToString());

                        xmlEFilter.SetAttribute("FillRed", ((ColorFiltering)filter).FillColor.Red.ToString());
                        xmlEFilter.SetAttribute("FillGreen", ((ColorFiltering)filter).FillColor.Green.ToString());
                        xmlEFilter.SetAttribute("FillBlue", ((ColorFiltering)filter).FillColor.Blue.ToString());
                        if (((ColorFiltering)filter).FillOutsideRange)
                            xmlEFilter.SetAttribute("FillType", "OutSide");
                        else
                            xmlEFilter.SetAttribute("FillType", "InSide");

                    }
                    else
                    {
                        xmlEFilter = xmlDoc.CreateElement("Filter");

                        XmlAttribute xmlARedMin = xmlDoc.CreateAttribute("RedMin");
                        XmlText xmlTRedMin = xmlDoc.CreateTextNode(((ColorFiltering)filter).Red.Min.ToString());
                        XmlAttribute xmlARedMax = xmlDoc.CreateAttribute("RedMax");
                        XmlText xmlTRedMax = xmlDoc.CreateTextNode(((ColorFiltering)filter).Red.Max.ToString());

                        XmlAttribute xmlAGreenMin = xmlDoc.CreateAttribute("GreenMin");
                        XmlText xmlTGreenMin = xmlDoc.CreateTextNode(((ColorFiltering)filter).Green.Min.ToString());
                        XmlAttribute xmlAGreenMax = xmlDoc.CreateAttribute("GreenMax");
                        XmlText xmlTGreenMax = xmlDoc.CreateTextNode(((ColorFiltering)filter).Green.Max.ToString());

                        XmlAttribute xmlABlueMin = xmlDoc.CreateAttribute("BlueMin");
                        XmlText xmlTBlueMin = xmlDoc.CreateTextNode(((ColorFiltering)filter).Blue.Min.ToString());
                        XmlAttribute xmlABlueMax = xmlDoc.CreateAttribute("BlueMax");
                        XmlText xmlTBlueMax = xmlDoc.CreateTextNode(((ColorFiltering)filter).Blue.Max.ToString());

                        XmlAttribute xmlAFillRed = xmlDoc.CreateAttribute("FillRed");
                        XmlText xmlTFillRed = xmlDoc.CreateTextNode(((ColorFiltering)filter).FillColor.Red.ToString());

                        XmlAttribute xmlFillGreen = xmlDoc.CreateAttribute("FillGreen");
                        XmlText xmlTFillGreen = xmlDoc.CreateTextNode(((ColorFiltering)filter).FillColor.Green.ToString());

                        XmlAttribute xmlFillBule = xmlDoc.CreateAttribute("FillBlue");
                        XmlText xmlTFillBlue = xmlDoc.CreateTextNode(((ColorFiltering)filter).FillColor.Blue.ToString());

                        XmlAttribute xmlFillType = xmlDoc.CreateAttribute("FillType");
                        XmlText xmlTFillOutType = xmlDoc.CreateTextNode("OutSide");
                        XmlText xmlTFillInType = xmlDoc.CreateTextNode("InSide");

                        xmlEFilter.Attributes.Append(xmlARedMin);
                        xmlARedMin.AppendChild(xmlTRedMin);

                        xmlEFilter.Attributes.Append(xmlARedMax);
                        xmlARedMax.AppendChild(xmlTRedMax);

                        xmlEFilter.Attributes.Append(xmlAGreenMin);
                        xmlAGreenMin.AppendChild(xmlTGreenMin);

                        xmlEFilter.Attributes.Append(xmlAGreenMax);
                        xmlAGreenMax.AppendChild(xmlTGreenMax);

                        xmlEFilter.Attributes.Append(xmlABlueMin);
                        xmlABlueMin.AppendChild(xmlTBlueMin);

                        xmlEFilter.Attributes.Append(xmlABlueMax);
                        xmlABlueMax.AppendChild(xmlTBlueMax);

                        xmlEFilter.Attributes.Append(xmlAFillRed);
                        xmlAFillRed.AppendChild(xmlTRedMin);

                        xmlEFilter.Attributes.Append(xmlFillGreen);
                        xmlFillGreen.AppendChild(xmlTFillGreen);

                        xmlEFilter.Attributes.Append(xmlFillBule);
                        xmlFillBule.AppendChild(xmlTFillBlue);

                        xmlEFilter.Attributes.Append(xmlFillType);
                        if (((ColorFiltering)filter).FillOutsideRange)
                            xmlFillType.AppendChild(xmlTFillOutType);
                        else
                            xmlFillType.AppendChild(xmlTFillInType);

                        xmlENext.AppendChild(xmlEFilter);

                    }
                    break;
                case "Gaussian"://柔化
                    XmlElement xmlEGaussian = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/Gaussian");
                    if (xmlEGaussian != null)
                    {
                        xmlEGaussian.SetAttribute("Sigma", ((GaussianBlur)filter).Sigma.ToString());
                        xmlEGaussian.SetAttribute("Size", ((GaussianBlur)filter).Size.ToString());
                    }
                    else
                    {
                        xmlEGaussian = xmlDoc.CreateElement("Gaussian");

                        XmlAttribute xmlAGaussianSigma = xmlDoc.CreateAttribute("Sigma");
                        XmlText xmlTGaussianSigma = xmlDoc.CreateTextNode(((GaussianBlur)filter).Sigma.ToString());

                        XmlAttribute xmlAGaussianSize = xmlDoc.CreateAttribute("Size");
                        XmlText xmlTGaussianSize = xmlDoc.CreateTextNode(((GaussianBlur)filter).Size.ToString());

                        xmlEGaussian.Attributes.Append(xmlAGaussianSigma);
                        xmlAGaussianSigma.AppendChild(xmlTGaussianSigma);

                        xmlEGaussian.Attributes.Append(xmlAGaussianSize);
                        xmlAGaussianSize.AppendChild(xmlTGaussianSize);

                        xmlENext.AppendChild(xmlEGaussian);

                    }
                    break;
                case "DifferenceEdgeDetector"://边缘增强
                    XmlElement xmlEDifferenceEdgeDetector = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/DifferenceEdgeDetector");
                    if (xmlEDifferenceEdgeDetector == null)
                    {
                        xmlEDifferenceEdgeDetector = xmlDoc.CreateElement("DifferenceEdgeDetector");
                        xmlENext.AppendChild(xmlEDifferenceEdgeDetector);
                    }
                    break;
                case "RotateFlip"://镜像
                    XmlElement xmlERotateFlip = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/RotateFlip");
                    if (xmlERotateFlip == null)
                    {
                        xmlERotateFlip = xmlDoc.CreateElement("RotateFlip");
                        xmlENext.AppendChild(xmlERotateFlip);
                    }
                    break;

                case "Sharpen"://锐化
                    XmlElement xmlESharpen = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/Sharpen");
                    if (xmlESharpen == null)
                    {
                        xmlESharpen = xmlDoc.CreateElement("Sharpen");
                        xmlENext.AppendChild(xmlESharpen);
                    }
                    break;

                case "Mean"://均值
                    XmlElement xmlEMean = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/Mean");
                    if (xmlEMean == null)
                    {
                        xmlEMean = xmlDoc.CreateElement("Mean");
                        xmlENext.AppendChild(xmlEMean);
                    }
                    break;
            }

            xmlE.AppendChild(xmlENext);
            XmlNode xn = xmlDoc.SelectSingleNode("PatientBackImage");
            xn.AppendChild(xmlE);
            xmlDoc.Save(XmlPath);
            return xmlE.InnerXml;
        }


        public string SaveImgProcess(ImageCtl drawArea, string imageName, String flag)//处理去噪  
        {
            xmlDoc.Load(XmlPath);
            xmlE = null;
            XmlNode node = xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] ");
            if (node == null)
            {

                xmlE = xmlDoc.CreateElement("Image");
                XmlAttribute xmlA = xmlDoc.CreateAttribute("Name");
                XmlText xt = xmlDoc.CreateTextNode(imageName);
                xmlE.Attributes.Append(xmlA);
                xmlA.AppendChild(xt);
            }
            else
            {
                xmlE = (XmlElement)node;
            }
            XmlElement xmlENext = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process");
            if (xmlENext == null)
            {
                xmlENext = xmlDoc.CreateElement("Process");
                xmlE.AppendChild(xmlENext);
            }

            //去噪
            XmlElement xmlEPerlinNoise = (XmlElement)xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + imageName + "'] /Process/PerlinNoise");
            if (xmlEPerlinNoise != null)
            {
                xmlEPerlinNoise.SetAttribute("Value", flag);
            }
            else
            {
                xmlEPerlinNoise = xmlDoc.CreateElement("PerlinNoise");
                XmlAttribute xmlAPerlinNoise = xmlDoc.CreateAttribute("Value");
                XmlText xmlTPerlinNoise = xmlDoc.CreateTextNode(flag);
                xmlEPerlinNoise.Attributes.Append(xmlAPerlinNoise);
                xmlAPerlinNoise.AppendChild(xmlTPerlinNoise);
                xmlENext.AppendChild(xmlEPerlinNoise);
            }

            xmlE.AppendChild(xmlENext);
            XmlNode xn = xmlDoc.SelectSingleNode("PatientBackImage");
            xn.AppendChild(xmlE);

            xmlDoc.Save(XmlPath);
            return xmlE.InnerXml;
        }

        public string SavePoint(ImageCtl drawArea)
        {
            string s="";
            for (int i = 0; i < drawArea.GraphicsList.Count; i++)//查找点
            {
                DrawObject o = drawArea.GraphicsList[i];
                if (o.GetType().FullName == "BaseControls.ImageBox.DrawTools.DrawPoint")
                {
                    s = ((DrawPoint)o).Point.X.ToString() + ";" + ((DrawPoint)o).Point.Y.ToString() + ";" + o.ID.ToString();
                }
            }
            return s;
        }
    }
}
