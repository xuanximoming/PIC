using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BaseControls
{
    public class CtlSettings
    {
        public static Font GetFontValue(string type)
        {
            Font value = new Font("宋体", 9F);
            switch (type)
            {
                case "CrystalButton":
                    value = Properties.Settings.Default.Font_CrystalButton;
                    break;
                case "GlassButton":
                    value = Properties.Settings.Default.Font_GlassButton;
                    break;
                case "SkinButton":
                    value = Properties.Settings.Default.Font_SkinButton;
                    break;
                case "SplitButton":
                    value = Properties.Settings.Default.Font_SplitButton;
                    break;
                case "VistaButton":
                    value = Properties.Settings.Default.Font_VistaButton;
                    break;
                case "MyDataGridView":
                    value = Properties.Settings.Default.Font_MyDataGridView;
                    break;
                case "RichTextBoxEx":
                    value = Properties.Settings.Default.Font_RichTextBoxEx;
                    break;
                case "MyLabel":
                    value = Properties.Settings.Default.Font_MyLabel;
                    break;
                case "MyTreeView":
                    value = Properties.Settings.Default.Font_MyTreeView;
                    break;
                case "userTextBox":
                    value = Properties.Settings.Default.Font_userTextBox;
                    break;
                case "XTextBox":
                    value = Properties.Settings.Default.Font_XTextBox;
                    break;
            }
            return value;
        }

        public static Color GetForeColorValue(string type)
        {
            Color value = System.Drawing.Color.Black;
            switch (type)
            {
                case "VistaButton":
                    value = Properties.Settings.Default.ForeColor_VistaButton;
                    break;
                case "MyDataGridView":
                    value = Properties.Settings.Default.ForeColor_MyDataGridView;
                    break;
                case "RichTextBoxEx":
                    value = Properties.Settings.Default.ForeColor_RichTextBoxEx;
                    break;
                case "MyLabel":
                    value = Properties.Settings.Default.ForeColor_MyLabel;
                    break;
                case "MyTreeView":
                    value = Properties.Settings.Default.ForeColor_MyTreeView;
                    break;
                case "userTextBox":
                    value = Properties.Settings.Default.ForeColor_userTextBox;
                    break;
                case "XTextBox":
                    value = Properties.Settings.Default.ForeColor_XTextBox;
                    break;
            }
            return value;
        }


        public static void SetFont(Font f, string type)
        {
            switch (type)
            {
                case "CrystalButton":
                    Properties.Settings.Default.Font_CrystalButton = f;
                    break;
                case "GlassButton":
                    Properties.Settings.Default.Font_GlassButton = f;
                    break;
                case "SkinButton":
                    Properties.Settings.Default.Font_SkinButton = f;
                    break;
                case "SplitButton":
                    Properties.Settings.Default.Font_SplitButton = f;
                    break;
                case "VistaButton":
                    Properties.Settings.Default.Font_VistaButton = f;
                    break;
                case "MyDataGridView":
                    Properties.Settings.Default.Font_MyDataGridView = f;
                    break;
                case "RichTextBoxEx":
                    Properties.Settings.Default.Font_RichTextBoxEx = f;
                    break;
                case "MyLabel":
                    Properties.Settings.Default.Font_MyLabel = f;
                    break;
                case "MyTreeView":
                    Properties.Settings.Default.Font_MyTreeView = f;
                    break;
                case "userTextBox":
                    Properties.Settings.Default.Font_userTextBox = f;
                    break;
                case "XTextBox":
                    Properties.Settings.Default.Font_XTextBox = f;
                    break;
            }
            Properties.Settings.Default.Save();
        }

        public static void SetForeColor(Color f, string type)
        {
            switch (type)
            {
                case "VistaButton":
                    Properties.Settings.Default.ForeColor_VistaButton = f;
                    break;
                case "MyDataGridView":
                    Properties.Settings.Default.ForeColor_MyDataGridView = f;
                    break;
                case "RichTextBoxEx":
                    Properties.Settings.Default.ForeColor_RichTextBoxEx = f;
                    break;
                case "MyLabel":
                    Properties.Settings.Default.ForeColor_MyLabel = f;
                    break;
                case "MyTreeView":
                    Properties.Settings.Default.ForeColor_MyTreeView = f;
                    break;
                case "userTextBox":
                    Properties.Settings.Default.ForeColor_userTextBox = f;
                    break;
                case "XTextBox":
                    Properties.Settings.Default.ForeColor_XTextBox = f;
                    break;
            }
            Properties.Settings.Default.Save();
        }

        public static void SetCtlColor(Color c, string type)
        {
            switch (type)
            {
                case "ImageCtl_Color":
                    Properties.Settings.Default.ImageCtl_Color = c;
                    break;
            }
            Properties.Settings.Default.Save();
        }

        public static Color GetCtlColor(string type)
        {
            Color value = System.Drawing.Color.Black;
            switch (type)
            {
                case "ImageCtl_Color":
                    value = Properties.Settings.Default.ImageCtl_Color;
                    break;
            }
            return value;
        }

        public static void SetImageCtlPenWidth(int width)
        {
            Properties.Settings.Default.ImageCtl_PenWidth = width;
            Properties.Settings.Default.Save();
        }

        public static int GetImageCtlPenWidth()
        {
            int value = Properties.Settings.Default.ImageCtl_PenWidth;
            return value;
        }
    }
}
