using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SIS.Query
{
    public class DataChange
    {
        public struct DataBlock
        {
            public string Name;
            public string Code;
            public System.Drawing.Color Color;
        }

        /// <summary>
        /// 获取配置文件中的颜色
        /// </summary>
        public List<DataBlock> GetDataColor(string Str)
        {
            List<DataBlock> lDB = new List<DataBlock>();
            string[] stu = Str.Split('|');
            foreach (string s in stu)
            {
                string[] sData = s.Split(';');
                DataBlock db = new DataBlock();
                db.Name = sData[0];
                db.Color = System.Drawing.Color.FromArgb(Convert.ToInt32(sData[1]), Convert.ToInt32(sData[2]), Convert.ToInt32(sData[3]));
                lDB.Add(db);
            }
            return lDB;
        }

        public DataGridViewCellFormattingEventArgs ChangeReportStatus(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "未写";
                    e.CellStyle.ForeColor = System.Drawing.Color.Brown;
                    break;
                case "1":
                    e.Value = "已写";
                    e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                    break;
                case "2":
                    e.Value = "正在写";
                    e.CellStyle.ForeColor = System.Drawing.Color.HotPink;
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeIsConfirmed(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "未收费";
                    e.CellStyle.ForeColor = System.Drawing.Color.PaleGreen;
                    break;
                case "1":
                    e.Value = "已收费";
                    e.CellStyle.ForeColor = System.Drawing.Color.Green;
                    break;
                case "2":
                    e.Value = "退费";
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeIsPrinted(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "未打印";
                    e.CellStyle.ForeColor = System.Drawing.Color.BlueViolet;
                    break;
                case "":
                    e.Value = "未打印";
                    e.CellStyle.ForeColor = System.Drawing.Color.BlueViolet;
                    break;
                default :
                    e.Value = "已打印";
                    e.CellStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeIsOnline(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "离线";
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    break;
                case "1":
                    e.Value = "在线";
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkSlateBlue;
                    break;
                default:
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeIsPackprocess(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "未打包";
                    e.CellStyle.ForeColor = System.Drawing.Color.OrangeRed;
                    break;
                case "1":
                    e.Value = "已打包";
                    e.CellStyle.ForeColor = System.Drawing.Color.LightYellow;
                    break;
                default:
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeMatchStatus(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "未匹配";
                    //e.CellStyle.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "1":
                    e.Value = "已匹配";
                    //e.CellStyle.ForeColor = System.Drawing.Color.Green;
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeIsTemporary(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "正常登记";
                    //e.CellStyle.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "1":
                    e.Value = "临时登记";
                    //e.CellStyle.ForeColor = System.Drawing.Color.Green;
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeIsInQuiry(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "未标记";
                    //e.CellStyle.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "1":
                    e.Value = "已标记";
                    //e.CellStyle.ForeColor = System.Drawing.Color.Green;
                    break;
            }
            return e;
        }

        public DataGridViewCellFormattingEventArgs ChangeReportType(DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "0":
                    e.Value = "初步报告";
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                    break;
                case "1":
                    e.Value = "提交待审核";
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkOrange;
                    break;
                case "2":
                    e.Value = "审核报告";
                    e.CellStyle.ForeColor = System.Drawing.Color.Brown;
                    break;
                case "3":
                    e.Value = "冻结报告";
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkRed;
                    break;
            }
            return e;
        }


        public DataGridViewCellFormattingEventArgs ChangeData(DataGridViewCellFormattingEventArgs e,List<DataBlock> datas)
        {
            for(int i=0;i<datas.Count;i++)
            {
                if (e.Value.ToString() == datas[i].Code)
                {
                    e.Value = datas[i].Name;
                    e.CellStyle.ForeColor = datas[i].Color;
                    break;
                }      
            }
            return e;
        }
    }
}
