using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SIS_Function
{
    class FontOpe
    {
        public static Font GetFont(string fontStr)
        {
            string[] paras = fontStr.Split(',');
            FontStyle style = FontStyle.Regular;
            if (paras.Length > 2)
            {
                string[] ps = paras[2].Split('|');
                if (ps.Length == 1)
                {
                    if (ps[0] == "Bold")
                        style = FontStyle.Bold;
                    if (ps[0] == "Italic")
                        style = FontStyle.Italic;
                    if (ps[0] == "Strikeout")
                        style = FontStyle.Strikeout;
                    if (ps[0] == "Underline")
                        style = FontStyle.Underline;
                }
                else
                {
                    for (int i = 1; i < ps.Length; i++)
                    {
                        if (ps[i] == "Bold")
                            style |= FontStyle.Bold;
                        if (ps[i] == "Italic")
                            style |= FontStyle.Italic;
                        if (ps[i] == "Strikeout")
                            style |= FontStyle.Strikeout;
                        if (ps[i] == "Underline")
                            style |= FontStyle.Underline;
                    }
                }
            }
            GraphicsUnit graphicsUnit = GraphicsUnit.Point;
            if (paras.Length > 3)
            {
                switch (paras[3])
                {
                    case "Display":
                        graphicsUnit |= GraphicsUnit.Display;
                        break;
                    case "Document":
                        graphicsUnit |= GraphicsUnit.Document;
                        break;
                    case "Inch":
                        graphicsUnit |= GraphicsUnit.Inch;
                        break;
                    case "Millimeter":
                        graphicsUnit |= GraphicsUnit.Millimeter;
                        break;
                    case "Pixel":
                        graphicsUnit |= GraphicsUnit.Pixel;
                        break;
                    case "World":
                        graphicsUnit |= GraphicsUnit.World;
                        break;
                }
            }
            byte b = (byte)134;
            if (paras.Length > 4)
                b = (byte)int.Parse(paras[4]);
            Font f = new Font(paras[0], float.Parse(paras[1]), style, graphicsUnit, b);
            return f;
        }
    }
}
