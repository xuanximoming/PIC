using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Function
{
    public class Display
    {
        //private static API.Ini ini = new API.Ini(@System.Windows.Forms.Application.StartupPath + @"\Settings.ini");
        //public static int BCred = Convert.ToInt32(ini.IniReadValue("Display", "BackColorRed").ToString());
        //public static int BCgreen = Convert.ToInt32(ini.IniReadValue("Display", "BackColorGreen").ToString());
        //public static int BCblue = Convert.ToInt32(ini.IniReadValue("Display", "BackColorBlue").ToString());
        //public static string fontFamily = ini.IniReadValue("Display", "FontFamily").ToString();
        //public static string fontSize = ini.IniReadValue("Display", "FontSize").ToString();
        //public static string fontStyle = ini.IniReadValue("Display", "FontStyle").ToString();
        //public static string fontUnit = ini.IniReadValue("Display", "FontUnit").ToString();
        //public static string fontGDICharSet = ini.IniReadValue("Display", "FontGDICharSet").ToString();
        //public static string fontGDIVerticalFont = ini.IniReadValue("Display", "FontGDIVerticalFont").ToString();
        //public static int FCred = Convert.ToInt32(ini.IniReadValue("Display", "FontColorRed").ToString());
        //public static int FCgreen = Convert.ToInt32(ini.IniReadValue("Display", "FontColorGreen").ToString());
        //public static int FCblue = Convert.ToInt32(ini.IniReadValue("Display", "FontColorBlue").ToString());
        //public static System.Drawing.FontStyle FontStyle;
        //public static System.Drawing.GraphicsUnit FontUnit;
        //public static int defaultScreenWide = Convert.ToInt32(ini.IniReadValue("Display", "DefaultScreenWide").ToString());
        //public static int defaultScreenHeight = Convert.ToInt32(ini.IniReadValue("Display", "DefaultScreenHeight").ToString());
        //public static double ScaleWide =double.Parse( System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString())/double.Parse(defaultScreenWide.ToString());
        //public static double ScaleHeight =double.Parse( System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString()) /double.Parse( defaultScreenHeight.ToString());

        //设置窗体背景颜色
        //public static void SettingBackColor(System.Windows.Forms.Form form)
        //{
        //    string screenResolution = ini.IniReadValue("Display", "ScreenResolution");
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    FontStyleTranslate();
        //    form.BackColor = System.Drawing.Color.FromArgb(BCred, BCgreen, BCblue);
        //    //form.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.StartupPath + "\\logo.ico");
        //    if (rc.Width.ToString() + "*" + rc.Height.ToString() != screenResolution)
        //    {
        //        double FontSize = 12 * rc.Width / defaultScreenWide * 0.93;
        //        form.Font = new System.Drawing.Font(fontFamily, float.Parse(FontSize.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    else
        //    {
        //        form.Font = new System.Drawing.Font(fontFamily, float.Parse(fontSize), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    form.ForeColor = System.Drawing.Color.FromArgb(FCred, FCgreen, FCblue);
        //    ResolutionForm(form);
        //    Resolution(form.Controls);
        //}

        //public static void SettingCrystalButton(CrystalButton cb)
        //{
        //    string screenResolution = ini.IniReadValue("Display", "ScreenResolution");
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    if (rc.Width.ToString() + "*" + rc.Height.ToString() != screenResolution)
        //    {
        //        double FontSize = 12 * 1.5 * rc.Width / defaultScreenWide * 0.93;
        //        cb.Font = new System.Drawing.Font(fontFamily, float.Parse(FontSize.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    else
        //    {
        //        Double db = double.Parse(fontSize) * 1.5;
        //        cb.Font = new System.Drawing.Font(fontFamily, float.Parse(db.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    cb.ImageSize = new System.Drawing.Size(cb.ImageSize.Width * rc.Width / defaultScreenWide, cb.ImageSize.Height * rc.Height / defaultScreenHeight);
        //}

        //public static void SettingVistaButton(VistaButton vb)
        //{
        //    string screenResolution = ini.IniReadValue("Display", "ScreenResolution");
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    if (rc.Width.ToString() + "*" + rc.Height.ToString() != screenResolution)
        //    {
        //        double FontSize = 12 * rc.Width / defaultScreenWide * 0.93;
        //        vb.Font = new System.Drawing.Font(fontFamily, float.Parse(FontSize.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    else
        //    {
        //        vb.Font = new System.Drawing.Font(fontFamily, float.Parse(fontSize), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    vb.ImageSize = new System.Drawing.Size(vb.ImageSize.Width * rc.Width / defaultScreenWide, vb.ImageSize.Height * rc.Height / defaultScreenHeight);
        //}

        //public static void SettingToolStrip(System.Windows.Forms.ToolStrip ts)
        //{
        //    string screenResolution = ini.IniReadValue("Display", "ScreenResolution");
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    if (rc.Width.ToString() + "*" + rc.Height.ToString() != screenResolution)
        //    {
        //        double FontSize = 12 * rc.Width / defaultScreenWide * 0.93;
        //        ts.Font = new System.Drawing.Font(fontFamily, float.Parse(FontSize.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    else
        //    {
        //        ts.Font = new System.Drawing.Font(fontFamily, float.Parse(fontSize), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    ts.ImageScalingSize = new System.Drawing.Size(ts.ImageScalingSize.Width * rc.Width / defaultScreenWide, ts.ImageScalingSize.Height * rc.Height / defaultScreenHeight);
        //}

        //public static void SettingStatusStrip(System.Windows.Forms.StatusStrip ss)
        //{
        //    string screenResolution = ini.IniReadValue("Display", "ScreenResolution");
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    if (rc.Width.ToString() + "*" + rc.Height.ToString() != screenResolution)
        //    {
        //        double FontSize = 12 * rc.Width / defaultScreenWide * 0.93;
        //        ss.Font = new System.Drawing.Font(fontFamily, float.Parse(FontSize.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    else
        //    {
        //        ss.Font = new System.Drawing.Font(fontFamily, float.Parse(fontSize), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //}

        //public static void SettingGrouper(Grouper grouper)
        //{
        //    string screenResolution = ini.IniReadValue("Display", "ScreenResolution");
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    if (rc.Width.ToString() + "*" + rc.Height.ToString() != screenResolution)
        //    {
        //        double FontSize = 12 * rc.Width / defaultScreenWide * 0.93;
        //        grouper.Font = new System.Drawing.Font(fontFamily, float.Parse(FontSize.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    else
        //    {
        //        grouper.Font = new System.Drawing.Font(fontFamily, float.Parse(fontSize), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    //ResolutionGrouper(grouper);
        //}

        //设置TabControl的TabPage背景颜色
        //public static void SettingTabBackColor(System.Windows.Forms.TabControl tab)
        //{

        //    for (int i = 0; i < tab.TabPages.Count; i++)
        //    {
        //        tab.TabPages[i].BackColor = System.Drawing.Color.FromArgb(BCred, BCgreen, BCblue);
        //    }
        //}

        //public static void FontStyleTranslate()
        //{
        //    switch (fontStyle)
        //    {
        //        case "0000":
        //            FontStyle = System.Drawing.FontStyle.Regular;
        //            break;
        //        case "0001":
        //            FontStyle = System.Drawing.FontStyle.Underline;
        //            break;
        //        case "0010":
        //            FontStyle = System.Drawing.FontStyle.Strikeout;
        //            break;
        //        case "0011":
        //            FontStyle = ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Strikeout)));
        //            break;
        //        case "0100":
        //            FontStyle = System.Drawing.FontStyle.Italic;
        //            break;
        //        case "0101":
        //            FontStyle = ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline)));
        //            break;
        //        case "0110":
        //            FontStyle = ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Strikeout)));
        //            break;
        //        case "0111":
        //            FontStyle = ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline) | System.Drawing.FontStyle.Strikeout)));
        //            break;
        //        case "1000":
        //            FontStyle = System.Drawing.FontStyle.Bold;
        //            break;
        //        case "1001":
        //            FontStyle = ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline)));
        //            break;
        //        case "1010":
        //            FontStyle = ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout)));
        //            break;
        //        case "1011":
        //            FontStyle = ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline) | System.Drawing.FontStyle.Strikeout)));
        //            break;
        //        case "1100":
        //            FontStyle = ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)));
        //            break;
        //        case "1101":
        //            FontStyle = ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline)));
        //            break;
        //        case "1110":
        //            FontStyle = ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Strikeout)));
        //            break;
        //        case "1111":
        //            FontStyle = ((System.Drawing.FontStyle)((((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline) | System.Drawing.FontStyle.Strikeout)));
        //            break;
        //        default:
        //            FontStyle = System.Drawing.FontStyle.Regular;
        //            break;
        //    }
        //    FontUnit = System.Drawing.GraphicsUnit.Point;
        //}

        //private static void Resolution(System.Windows.Forms.Control.ControlCollection Con)
        //{
        //    //遍历控件             
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
        //    if (rc.Width != defaultScreenWide || rc.Height != defaultScreenHeight)
        //    {
        //        foreach (System.Windows.Forms.Control i in Con)
        //        {
        //            i.Width = i.Width * rc.Width / defaultScreenWide;//现有屏幕比例和标准比例换算,标准为defaultScreenWide*defaultScreenHeight,                
        //            i.Height = i.Height * rc.Height / (defaultScreenHeight - 30);//738为除去工具条后的标准Height.                
        //            i.Left = i.Left * rc.Width / defaultScreenWide;
        //            i.Top = i.Top * rc.Height / (defaultScreenHeight - 30);
        //            if (i.Controls.Count > 0)
        //            {
        //                Resolution(i.Controls);//递归                
        //            }
        //        }
        //        //for (int i = 0; i < Con.Count; i++)
        //        //{
        //        //    Con[i].Width = Con[i].Width * rc.Width / defaultScreenWide;//现有屏幕比例和标准比例换算,标准为defaultScreenWide*defaultScreenHeight,                
        //        //    Con[i].Height = Con[i].Height * rc.Height / (defaultScreenHeight-30);//738为除去工具条后的标准Height.                
        //        //    Con[i].Left = Con[i].Left * rc.Width / defaultScreenWide;
        //        //    Con[i].Top = Con[i].Top * rc.Height / (defaultScreenHeight - 30);
        //        //    if (Con[i].Controls.Count > 0)
        //        //    {
        //        //        Resolution(Con[i].Controls);//递归                
        //        //    }
        //        //}
        //    }
        //}

        //public static void Resolution(System.Windows.Forms.UserControl userControl)
        //{
        //    string screenResolution = ini.IniReadValue("Display", "ScreenResolution");
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    FontStyleTranslate();
        //    //userControl.BackColor = System.Drawing.Color.FromArgb(BCred, BCgreen, BCblue);
        //    //form.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.StartupPath + "\\logo.ico");
        //    if (rc.Width.ToString() + "*" + rc.Height.ToString() != screenResolution)
        //    {
        //        double FontSize = 12 * rc.Width / defaultScreenWide * 0.93;
        //        userControl.Font = new System.Drawing.Font(fontFamily, float.Parse(FontSize.ToString()), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    else
        //    {
        //        userControl.Font = new System.Drawing.Font(fontFamily, float.Parse(fontSize), FontStyle, FontUnit, Convert.ToByte(fontGDICharSet), Convert.ToBoolean(fontGDIVerticalFont));
        //    }
        //    userControl.ForeColor = System.Drawing.Color.FromArgb(FCred, FCgreen, FCblue);
        //    if (rc.Width != defaultScreenWide || rc.Height != (defaultScreenWide - 30))
        //    {
        //        userControl.Width = userControl.Width * rc.Width / defaultScreenWide;//现有屏幕比例和标准比例换算,标准为defaultScreenWide*defaultScreenHeight,                
        //        userControl.Height = userControl.Height * rc.Height / (defaultScreenHeight - 30);//738为除去工具条后的标准Height.                
        //        userControl.Left = userControl.Left * rc.Width / defaultScreenWide;
        //        userControl.Top = userControl.Top * rc.Height / (defaultScreenHeight - 30);

        //        //遍历控件             
        //        foreach (System.Windows.Forms.Control i in userControl.Controls)
        //        {
        //            i.Width = i.Width * rc.Width / defaultScreenWide;//现有屏幕比例和标准比例换算,标准为defaultScreenWide*defaultScreenHeight,                
        //            i.Height = i.Height * rc.Height / (defaultScreenHeight - 30);//738为除去工具条后的标准Height.                
        //            i.Left = i.Left * rc.Width / defaultScreenWide;
        //            i.Top = i.Top * rc.Height / (defaultScreenHeight - 30);
        //            if (i.Controls.Count > 0)
        //            {
        //                Resolution(i.Controls);//递归                
        //            }
        //        }
        //    }
        //}

      
        //private static void ResolutionForm(System.Windows.Forms.Form form)
        //{
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
        //    if (rc.Width != defaultScreenWide || rc.Height != (defaultScreenWide - 30))
        //    {
        //        form.Width = form.Width * rc.Width / defaultScreenWide;//现有屏幕比例和标准比例换算,标准为defaultScreenWide*defaultScreenHeight,                
        //        form.Height = form.Height * rc.Height / (defaultScreenHeight - 30);//738为除去工具条后的标准Height.                
        //        form.Left = form.Left * rc.Width / defaultScreenWide;
        //        form.Top = form.Top * rc.Height / (defaultScreenHeight - 30);
        //    }
        //}

        //private static void ResolutionGrouper(Grouper grouper)
        //{
        //    System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
        //    if (rc.Width != defaultScreenWide || rc.Height != (defaultScreenWide - 30))
        //    {
        //        grouper.Width = grouper.Width * rc.Width / defaultScreenWide;//现有屏幕比例和标准比例换算,标准为defaultScreenWide*defaultScreenHeight,                
        //        grouper.Height = grouper.Height * rc.Height / (defaultScreenHeight - 30);//738为除去工具条后的标准Height.                
        //        grouper.Left = grouper.Left * rc.Width / defaultScreenWide;
        //        grouper.Top = grouper.Top * rc.Height / (defaultScreenHeight - 30);
        //    }
        //}
    }
}
