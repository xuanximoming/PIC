using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Function
{
    /// <summary>
    /// Word图片单元格
    /// </summary>
    public class WordImgCell
    {
        //private string imgPath;
        private string imgName;
        private int tableIndex;
        private int rowIndex;
        private int columnIndex;
        private int imgWidth;
        private int imgHeight;

        //private string inf;
        //private int infRowIndex;
        //private int infColumnIndex;

        private string locMapName;
        private int locMapRowIndex;
        private int locMapColumnIndex;

        //public string ImgPath
        //{
        //    get { return this.imgPath; }
        //    set { this.imgPath = value; }
        //}

        public string ImgName
        {
            get { return this.imgName; }
            set { this.imgName = value; }
        }

        public int TableIndex
        {
            get { return this.tableIndex; }
            set { this.tableIndex = value; }
        }

        public int RowIndex
        {
            get { return this.rowIndex; }
            set { this.rowIndex = value; }
        }

        public int ColumnIndex
        {
            get { return this.columnIndex; }
            set { this.columnIndex = value; }
        }

        public int ImgWidth
        {
            get { return this.imgWidth; }
            set { this.imgWidth = value; }
        }

        public int ImgHeight
        {
            get { return this.imgHeight; }
            set { this.imgHeight = value; }
        }

        //public string Inf
        //{
        //    get { return this.inf; }
        //    set { this.inf = value; }
        //}

        //public int InfRowIndex
        //{
        //    get { return this.infRowIndex; }
        //    set { this.infRowIndex = value; }
        //}

        //public int InfColumnIndex
        //{
        //    get { return this.infColumnIndex; }
        //    set { this.infColumnIndex = value; }
        //}

        public string LocMapName
        {
            get { return this.locMapName; }
            set { this.locMapName = value; }
        }

        public int LocMapRowIndex
        {
            get { return this.locMapRowIndex; }
            set { this.locMapRowIndex = value; }
        }

        public int LocMapColumnIndex
        {
            get { return this.locMapColumnIndex; }
            set { this.locMapColumnIndex = value; }
        }

        public WordImgCell()
        {
        }

        public WordImgCell(string ImgName, int ImgHeight, int ImgWidth, int TableIndex, int RowIndex, int ColumnIndex)
        {
            this.imgName = ImgName;
            this.imgHeight = ImgHeight;
            this.imgWidth = ImgWidth;
            this.tableIndex = TableIndex;
            this.rowIndex = RowIndex;
            this.columnIndex = ColumnIndex;
        }

        public WordImgCell(string ImgName, int ImgHeight, int ImgWidth, int TableIndex, int RowIndex, int ColumnIndex, string LocMapName, int LocMapRowIndex, int LocMapColumnIndex)
        {
            this.imgName = ImgName;
            this.imgHeight = ImgHeight;
            this.imgWidth = ImgWidth;
            this.tableIndex = TableIndex;
            this.rowIndex = RowIndex;
            this.columnIndex = ColumnIndex;
            //this.inf = Inf;
            //this.infColumnIndex = InfColumnIndex;
            //this.infRowIndex = InfRowIndex;
            this.locMapColumnIndex = LocMapColumnIndex;
            this.locMapName = LocMapName;
            this.locMapRowIndex = LocMapRowIndex;
        }

        public WordImgCell Copy()
        {
            WordImgCell wic = new WordImgCell();
            wic.columnIndex = this.columnIndex;
            wic.imgHeight = this.imgHeight;
            wic.imgName = this.imgName;
            wic.imgWidth = this.imgWidth;
            //wic.inf = this.inf;
            //wic.infColumnIndex = this.infColumnIndex;
            //wic.infRowIndex = this.infRowIndex;
            wic.locMapColumnIndex = this.locMapColumnIndex;
            wic.locMapName = this.locMapName;
            wic.locMapRowIndex = this.locMapRowIndex;
            wic.rowIndex = this.rowIndex;
            wic.tableIndex = this.tableIndex;
            return wic;
        }
        /// <summary>
        /// 解释WordImgCell信息字符串
        /// </summary>
        public static List<WordImgCell> SetWordImgCells(string fields)
        {
            List<WordImgCell> WordImgCells = new List<WordImgCell>();
            if (fields == "")
                return WordImgCells;
            string[] Field = fields.Split('@');
            for (int i = 0; i < Field.Length; i++)
            {
                string[] FieldInfo = Field[i].ToString().Split(';');
                WordImgCell wic = new WordImgCell();
                wic.imgName = FieldInfo[0].ToString();
                wic.tableIndex = int.Parse(FieldInfo[1]);
                wic.rowIndex = int.Parse(FieldInfo[2]);
                wic.columnIndex = int.Parse(FieldInfo[3]);
                wic.imgHeight = int.Parse(FieldInfo[4]);
                wic.imgWidth = int.Parse(FieldInfo[5]);
                //wic.inf = FieldInfo[6];
                //wic.infRowIndex = int.Parse(FieldInfo[7]);
                //wic.infColumnIndex = int.Parse(FieldInfo[8]);
                wic.locMapName = FieldInfo[6];
                wic.locMapRowIndex = int.Parse(FieldInfo[7]);
                wic.locMapColumnIndex = int.Parse(FieldInfo[8]);
                WordImgCells.Add(wic);
            }
            return WordImgCells;
        }
        /// <summary>
        /// 获取WordImgCell信息字符串
        /// </summary>
        /// <returns></returns>
        public static string GetWordImgCells(List<WordImgCell> lwic)
        {
            if (lwic != null)
            {
                string FieldInfo = "";
                for (int i = 0; i < lwic.Count; i++)
                {
                    WordImgCell wic = (WordImgCell)lwic[i];
                    FieldInfo += wic.imgName + ";";
                    FieldInfo += wic.tableIndex.ToString() + ";";
                    FieldInfo += wic.rowIndex.ToString() + ";";
                    FieldInfo += wic.columnIndex + ";";
                    FieldInfo += wic.imgWidth.ToString() + ";";
                    FieldInfo += wic.imgHeight.ToString() + ";";
                    //FieldInfo += wic.inf + ";";
                    //FieldInfo += wic.infRowIndex.ToString() + ";";
                    //FieldInfo += wic.infColumnIndex.ToString() + ";";
                    FieldInfo += wic.locMapName + ";";
                    FieldInfo += wic.locMapRowIndex.ToString() + ";";
                    FieldInfo += wic.locMapColumnIndex.ToString() + "@";
                }
                return FieldInfo.TrimEnd('@');
            }
            else
            {
                return "";
            }
        }
    }
}
