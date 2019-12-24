using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BaseControls
{
    /// <summary>
    /// DataGridView行合并.请对属性MergeColumnNames 赋值既可
    /// </summary>
    public partial class MyDataGridView : DataGridView
    {

        #region 构造函数
        public MyDataGridView()
        {
            InitializeComponent();
        }
        #endregion

        #region 重写的事件
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码

            // 调用基类 OnPaint
            base.OnPaint(pe);
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    DrawCell(e);
                }
                else
                {
                    DrawTableHead(e);
                }
                base.OnCellPainting(e);
            }
            catch
            { }
        }
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (this.MergeCellArray.Count > 0)
                    {
                        for (int j = 0; j < this.MergeCellArray.Count; j++)
                        {
                            MergeCell mergeCell = (MergeCell)this.MergeCellArray[j];
                            if (e.RowIndex != -1 && e.RowIndex >= mergeCell.MergeMinRowIndex && e.RowIndex <= mergeCell.MergeMaxRowIndex && e.ColumnIndex >= mergeCell.MergeMinColumnIndex && e.ColumnIndex <= mergeCell.MergeMaxColumnIndex)
                            {
                                this.Refresh();
                            }
                        }
                    }
                }
                base.OnCellClick(e);
            }
            catch
            { }
        }
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (this.MergeCellArray.Count > 0)
                    {
                        for (int j = 0; j < this.MergeCellArray.Count; j++)
                        {
                            MergeCell mergeCell = (MergeCell)this.MergeCellArray[j];
                            if (e.RowIndex != -1 && e.RowIndex >= mergeCell.MergeMinRowIndex && e.RowIndex <= mergeCell.MergeMaxRowIndex && e.ColumnIndex >= mergeCell.MergeMinColumnIndex && e.ColumnIndex <= mergeCell.MergeMaxColumnIndex)
                            {
                                this.Refresh();
                            }
                        }
                    }
                }
                base.OnCellEndEdit(e);
            }
            catch
            { }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 画单元格
        /// </summary>
        /// <param name="e"></param>
        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (this.MergeColumnNames.Contains(this.Columns[e.ColumnIndex].Name) && e.RowIndex != -1)
            {
                this.PaintMergeColumns(e);
            }
            else
            {
                this.PaintMergeCells(e);
            }

        }
        /// <summary>
        /// 画二维表头
        /// </summary>
        /// <param name="e"></param>
        private void DrawTableHead(System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            //二维表头
            if (e.RowIndex == -1)
            {
                if (SpanRows.ContainsKey(e.ColumnIndex)) //被合并的列
                {
                    //画边框
                    Graphics g = e.Graphics;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    int left = e.CellBounds.Left, top = e.CellBounds.Top + 2,
                    right = e.CellBounds.Right, bottom = e.CellBounds.Bottom;

                    switch (SpanRows[e.ColumnIndex].Position)
                    {
                        case 1:
                            left += 2;
                            break;
                        case 2:
                            break;
                        case 3:
                            right -= 2;
                            break;
                    }

                    //画上半部分底色
                    g.FillRectangle(new SolidBrush(this._mergecolumnheaderbackcolor), left, top,
                    right - left, (bottom - top) / 2);

                    //画中线
                    g.DrawLine(new Pen(this.GridColor), left, (top + bottom) / 2,
                    right, (top + bottom) / 2);

                    //写小标题
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(e.Value + "", e.CellStyle.Font, Brushes.Black,
                    new Rectangle(left, (top + bottom) / 2, right - left, (bottom - top) / 2), sf);
                    left = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Left, true).Left - 2;

                    if (left < 0) left = this.GetCellDisplayRectangle(-1, -1, true).Width;
                    right = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Right, true).Right - 2;
                    if (right < 0) right = this.Width;

                    g.DrawString(SpanRows[e.ColumnIndex].Text, e.CellStyle.Font, Brushes.Black,
                    new Rectangle(left, top, right - left, (bottom - top) / 2), sf);
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// 重绘合并的列
        /// </summary>
        /// <param name="e"></param>
        private void PaintMergeColumns(System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            Brush gridBrush = new SolidBrush(this.GridColor);
            SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int cellwidth;
            //上面相同的行数
            int UpRows = 0;
            //下面相同的行数
            int DownRows = 0;
            //总行数
            int Rowcount = 0;
            cellwidth = e.CellBounds.Width;
            Pen gridLinePen = new Pen(gridBrush);
            string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
            string curSelected = this.CurrentRow.Cells[e.ColumnIndex].Value == null ? "" : this.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Trim();
            if (!string.IsNullOrEmpty(curValue))
            {
                #region 获取下面的行数
                for (int i = e.RowIndex; i < this.Rows.Count; i++)
                {
                    if (this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                    {
                        //this.Rows[i].Cells[e.ColumnIndex].Selected = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

                        DownRows++;
                        if (e.RowIndex != i)
                        {
                            cellwidth = cellwidth < this.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : this.Rows[i].Cells[e.ColumnIndex].Size.Width;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
                #region 获取上面的行数
                for (int i = e.RowIndex; i >= 0; i--)
                {
                    if (this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                    {
                        //this.Rows[i].Cells[e.ColumnIndex].Selected = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                        UpRows++;
                        if (e.RowIndex != i)
                        {
                            cellwidth = cellwidth < this.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : this.Rows[i].Cells[e.ColumnIndex].Size.Width;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
                Rowcount = DownRows + UpRows - 1;
                if (Rowcount < 2)
                {
                    return;
                }
            }
            if (this.Rows[e.RowIndex].Selected)
            {
                backBrush.Color = e.CellStyle.SelectionBackColor;
                fontBrush.Color = e.CellStyle.SelectionForeColor;
            }
            //以背景色填充
            e.Graphics.FillRectangle(backBrush, e.CellBounds);
            //画字符串
            PaintingFont(e, cellwidth, UpRows, DownRows, Rowcount);
            if (DownRows == 1)
            {
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                Rowcount = 0;
            }
            // 画右边线
            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

            e.Handled = true;
        }
        /// <summary>
        /// 重绘合并的单元格
        /// </summary>
        /// <param name="e"></param>
        private void PaintMergeCells(System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if (this.MergeCellArray.Count == 0)
            {
                return;
            }
            else
            {
                Brush gridBrush = new SolidBrush(this.GridColor);
                SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
                SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
                //上面相同的行数
                int UpRows = 0;
                //下面相同的行数
                int DownRows = 0;
                //总行数
                int Rowcount = 0;
                int cellwidth = 0;
                int cellheight = 0;
                for (int j = 0; j < this.MergeCellArray.Count; j++)
                {
                    MergeCell mergeCell = (MergeCell)this.MergeCellArray[j];
                    if (e.RowIndex != -1 && e.RowIndex >= mergeCell.MergeMinRowIndex && e.RowIndex <= mergeCell.MergeMaxRowIndex && e.ColumnIndex >= mergeCell.MergeMinColumnIndex && e.ColumnIndex <= mergeCell.MergeMaxColumnIndex)
                    {
                        Pen gridLinePen = new Pen(gridBrush);
                        for (int i = mergeCell.MergeMinColumnIndex; i <= mergeCell.MergeMaxColumnIndex; i++)
                        {
                            cellwidth += this.Rows[e.RowIndex].Cells[i].Size.Width;
                        }
                        for (int i = mergeCell.MergeMinRowIndex; i <= mergeCell.MergeMaxRowIndex; i++)
                        {
                            cellheight += this.Rows[i].Cells[e.ColumnIndex].Size.Height;
                        }
                        DownRows = mergeCell.MergeMaxRowIndex - e.RowIndex + 1;
                        UpRows = e.RowIndex - mergeCell.MergeMinRowIndex;
                        Rowcount = mergeCell.MergeMaxRowIndex - mergeCell.MergeMinRowIndex + 1;
                        if (this.Rows[e.RowIndex].Selected)
                        {
                            backBrush.Color = e.CellStyle.SelectionBackColor;
                            fontBrush.Color = e.CellStyle.SelectionForeColor;
                        }

                        // Determine the width before the current cell.
                        int nWidthLeft = 0;
                        int nHeightTop = 0;
                        for (int i = mergeCell.MergeMinColumnIndex; i < e.ColumnIndex; i++)
                        {
                            nWidthLeft += this.Rows[e.RowIndex].Cells[i].Size.Width;
                        }
                        for (int i = mergeCell.MergeMinRowIndex; i < e.RowIndex; i++)
                        {
                            nHeightTop += this.Rows[i].Cells[e.ColumnIndex].Size.Height;
                        }

                        RectangleF rectDest = new RectangleF(e.CellBounds.Left - nWidthLeft, e.CellBounds.Top - nHeightTop, cellwidth, cellheight);

                        //以背景色填充
                        e.Graphics.FillRectangle(backBrush, rectDest);

                        if (DownRows == 1)
                        {
                            e.Graphics.DrawLine(gridLinePen, rectDest.Left, e.CellBounds.Bottom - 1, rectDest.Right, e.CellBounds.Bottom - 1);
                            Rowcount = 0;
                        }
                        // 画右边线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, rectDest.Top, e.CellBounds.Right - 1, rectDest.Bottom);


                        //画字符串
                        PaintingFont(e, this.Rows[mergeCell.MiddleCellRowIndex].Cells[mergeCell.MiddleCellColumnIndex].Value.ToString(), rectDest);
                        e.Handled = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 画字符串
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cellwidth"></param>
        /// <param name="UpRows"></param>
        /// <param name="DownRows"></param>
        /// <param name="count"></param>
        private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int cellwidth, int UpRows, int DownRows, int count)
        {
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
            int fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
            int cellheight = e.CellBounds.Height;

            if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
        }

        /// <summary>
        /// 画指定值的字符串
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cellwidth"></param>
        /// <param name="UpRows"></param>
        /// <param name="DownRows"></param>
        /// <param name="count"></param>
        private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, string Value, RectangleF rectDest)
        {
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(Value, e.CellStyle.Font, fontBrush, rectDest, sf);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 设置或获取合并列的集合
        /// </summary>
        [MergableProperty(false)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Description("设置或获取合并列的集合"), Browsable(true), Category("单元格合并")]
        public List<string> MergeColumnNames
        {
            get
            {
                return _mergecolumnname;
            }
            set
            {
                _mergecolumnname = value;
            }
        }
        private List<string> _mergecolumnname = new List<string>();
        #endregion

        #region 二维表头
        private struct SpanInfo //表头信息
        {
            public SpanInfo(string Text, int Position, int Left, int Right)
            {
                this.Text = Text;
                this.Position = Position;
                this.Left = Left;
                this.Right = Right;
            }

            public string Text; //列主标题
            public int Position; //位置，1:左，2中，3右
            public int Left; //对应左行
            public int Right; //对应右行
        }
        private Dictionary<int, SpanInfo> SpanRows = new Dictionary<int, SpanInfo>();//需要2维表头的列
        /// <summary>
        /// 合并列
        /// </summary>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="ColCount">需要合并的列数</param>
        /// <param name="Text">合并列后的文本</param>
        public void AddSpanHeader(int ColIndex, int ColCount, string Text)
        {
            if (ColCount < 2)
            {
                throw new Exception("行宽应大于等于2，合并1列无意义。");
            }
            //将这些列加入列表
            int Right = ColIndex + ColCount - 1; //同一大标题下的最后一列的索引
            SpanRows[ColIndex] = new SpanInfo(Text, 1, ColIndex, Right); //添加标题下的最左列
            SpanRows[Right] = new SpanInfo(Text, 3, ColIndex, Right); //添加该标题下的最右列
            for (int i = ColIndex + 1; i < Right; i++) //中间的列
            {
                SpanRows[i] = new SpanInfo(Text, 2, ColIndex, Right);
            }
        }
        /// <summary>
        /// 清除合并的列
        /// </summary>
        public void ClearSpanInfo()
        {
            SpanRows.Clear();
            //ReDrawHead();
        }

        private void DataGridViewEx_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)// && e.Type == ScrollEventType.EndScroll)
            {
                timer1.Enabled = false;
                timer1.Enabled = true;
            }
        }

        //刷新显示表头
        public void ReDrawHead()
        {
            foreach (int si in SpanRows.Keys)
            {
                this.Invalidate(this.GetCellDisplayRectangle(si, -1, true));
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ReDrawHead();
        }
        /// <summary>
        /// 二维表头的背景颜色
        /// </summary>
        [Description("二维表头的背景颜色"), Browsable(true), Category("二维表头")]
        public Color MergeColumnHeaderBackColor
        {
            get { return this._mergecolumnheaderbackcolor; }
            set { this._mergecolumnheaderbackcolor = value; }
        }
        private Color _mergecolumnheaderbackcolor = System.Drawing.SystemColors.Control;
        #endregion

        #region 单元格合并
        private struct MergeCell //合并的单元格结构体
        {
            public MergeCell(int MergeMaxColumnIndex, int MergeMaxRowIndex, int MergeMinColumnIndex, int MergeMinRowIndex, int MiddleCellColumnIndex, int MiddleCellRowIndex)
            {
                this.MergeMaxColumnIndex = MergeMaxColumnIndex;
                this.MergeMaxRowIndex = MergeMaxRowIndex;
                this.MergeMinColumnIndex = MergeMinColumnIndex;
                this.MergeMinRowIndex = MergeMinRowIndex;
                this.MiddleCellColumnIndex = MiddleCellColumnIndex;
                this.MiddleCellRowIndex = MiddleCellRowIndex;
            }
            public int MergeMinRowIndex;//合并单元格最小行索引
            public int MergeMinColumnIndex;//最大列索引
            public int MergeMaxRowIndex;//最大行索引
            public int MergeMaxColumnIndex;//最大列索引
            public int MiddleCellRowIndex;//中间单元格行索引
            public int MiddleCellColumnIndex;//中间单元格列索引
        }
        private ArrayList MergeCellArray = new ArrayList();//合并的单元格集合
        /// <summary>
        /// 合并单元格
        /// </summary>
        public void MergeCells()
        {
            if (this.SelectedCells.Count <= 1)
                return;
            else
            {
                //int[] RowsIndex = new int[this.SelectedCells.Count];
                //int[] ColumnsIndex = new int[this.SelectedCells.Count];
                int MinRowIndex = this.RowCount;//最小行索引
                int MinColumnIndex = this.ColumnCount;//最大列索引
                int MaxRowIndex = -1;//最大行索引
                int MaxColumnIndex = -1;//最大列索引
                for (int i = 0; i < this.SelectedCells.Count; i++)
                {
                    if (!this.ReadOnly)
                    {
                        this.SelectedCells[i].ReadOnly = true;//使选中的单元格只读
                    }
                    DataGridViewCell cell = this.SelectedCells[i];
                    //RowsIndex[i] = cell.RowIndex;
                    //ColumnsIndex[i] = cell.ColumnIndex;
                    for (int j = 0; j < this.MergeCellArray.Count; j++)
                    {
                        MergeCell mergeCell = (MergeCell)this.MergeCellArray[j];
                        if (cell.RowIndex >= mergeCell.MergeMinRowIndex && cell.RowIndex <= mergeCell.MergeMaxRowIndex && cell.ColumnIndex >= mergeCell.MergeMinColumnIndex && cell.ColumnIndex <= mergeCell.MergeMaxColumnIndex)
                        {
                            return;
                        }
                    }
                    if (cell.RowIndex <= MinRowIndex)
                    {
                        MinRowIndex = cell.RowIndex;
                    }
                    if (cell.RowIndex >= MaxRowIndex)
                    {
                        MaxRowIndex = cell.RowIndex;
                    }
                    if (cell.ColumnIndex <= MinColumnIndex)
                    {
                        MinColumnIndex = cell.ColumnIndex;
                    }
                    if (cell.ColumnIndex >= MaxColumnIndex)
                    {
                        MaxColumnIndex = cell.ColumnIndex;
                    }
                }
                int DefaultCellCount = (MaxRowIndex - MinRowIndex + 1) * (MaxColumnIndex - MinColumnIndex + 1);//长方形选择区域的单元格数
                if (this.SelectedCells.Count != DefaultCellCount)
                    return;
                else
                {
                    int MiddleCellRowIndex = 0;//中间单元格行索引
                    int MiddleCellColumnIndex = 0;//中间单元格列索引
                    if ((MaxRowIndex - MinRowIndex) > 0)
                    {
                        MiddleCellRowIndex = (MaxRowIndex - MinRowIndex) == 1 ? MinRowIndex : MinRowIndex + (MaxRowIndex - MinRowIndex) / 2;
                    }
                    if ((MaxColumnIndex - MinColumnIndex) > 0)
                    {
                        MiddleCellColumnIndex = (MaxColumnIndex - MinColumnIndex) == 1 ? MinColumnIndex : MinColumnIndex + (MaxColumnIndex - MinColumnIndex) / 2;
                    }
                    if (MiddleCellRowIndex == 0 && MiddleCellColumnIndex == 0)
                    {
                        MiddleCellColumnIndex = MinColumnIndex;
                        MiddleCellRowIndex = MinRowIndex;
                    }
                    else
                    {
                        if (MiddleCellRowIndex > 0 && MiddleCellColumnIndex == 0)
                        {
                            MiddleCellColumnIndex = MinColumnIndex;
                        }
                        else
                        {
                            if (MiddleCellColumnIndex > 0 && MiddleCellRowIndex == 0)
                            {
                                MiddleCellRowIndex = MinRowIndex;
                            }
                        }
                    }
                    if (!this.ReadOnly)
                    {
                        this.Rows[MiddleCellRowIndex].Cells[MiddleCellColumnIndex].ReadOnly = false;//中间单元格非只读
                    }
                    MergeCell mergeCell = new MergeCell(MaxColumnIndex, MaxRowIndex, MinColumnIndex, MinRowIndex, MiddleCellColumnIndex, MiddleCellRowIndex);
                    this.MergeCellArray.Add(mergeCell);
                    this.Refresh();
                }
            }
        }

        public void ClearMergeCells()
        {
            this.MergeCellArray.Clear();
            this.Refresh();
        }
        #endregion

        /// <summary>
        /// 获取DataGridView的XML格式的表达字符串
        /// </summary>
        /// <returns></returns>
        public string GetViewToXML()
        {
            string head = "<?xml version='1.0' encoding='utf-8'?>";
            string width = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn headerCell in this.Columns)
            {
                dt.Columns.Add(headerCell.HeaderText);
                width += "$" + headerCell.Width.ToString();
            }
            for (int j = 0; j < this.Rows.Count - 1; j++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    try
                    {
                        dr[i] = this.Rows[j].Cells[i].Value.ToString();
                    }
                    catch
                    {
                        dr[i] = "";
                    }
                }
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            string MergeCellArrayStr = "";
            if (this.MergeCellArray.Count > 0)
            {
                MergeCellArrayStr += "{";
                for (int i = 0; i < this.MergeCellArray.Count; i++)
                {
                    MergeCell mergeCell = (MergeCell)this.MergeCellArray[i];
                    MergeCellArrayStr += mergeCell.MergeMaxColumnIndex + "," + mergeCell.MergeMaxRowIndex + "," + mergeCell.MergeMinColumnIndex + "," + mergeCell.MergeMinRowIndex + "," + mergeCell.MiddleCellColumnIndex + "," + mergeCell.MiddleCellRowIndex + "√";
                }
                MergeCellArrayStr = MergeCellArrayStr.TrimEnd(',') + "}";
            }
            System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            string color = this.GridColor.R.ToString() + "," + this.GridColor.G.ToString() + "," + this.GridColor.B.ToString();
            string xml = head + ds.GetXml() + "$" + rc.Width.ToString() + "*" + rc.Height.ToString() + "$" + this.Width.ToString() + width + MergeCellArrayStr + "@" + color;
            return xml;
        }

        /// <summary>
        /// 由XML格式的表达字符串设置DataGridView的数据源
        /// </summary>
        /// <returns></returns>
        public void SetViewFromXML(string str)
        {
            try
            {
                this.Columns.Clear();
                DataSet ds = new DataSet();
                System.Xml.XmlTextReader xmlr = new System.Xml.XmlTextReader(new System.IO.StringReader(str.Substring(0, str.IndexOf("$")).Replace("\r\n", "").Replace("''", "'")));
                ds.ReadXml(xmlr);
                this.DataSource = ds.Tables[0].DefaultView;

                int index_Scale = str.IndexOf("$");
                int index_Width = str.IndexOf("$", index_Scale + 1);
                int index_Merge = str.IndexOf("{", index_Width + 1);
                int index_GridColor = str.IndexOf("@", index_Width + 1);

                if (index_GridColor > 0)
                {
                    string[] color = str.Substring(index_GridColor + 1, str.Length - 1 - index_GridColor).Split(',');
                    this.GridColor = Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2]));
                    if (color[0] == "255" && color[1] == "255" && color[2] == "255")
                        this.DefaultCellStyle.BackColor = Color.LightGray;
                    else
                        this.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    this.GridColor = Color.Black;
                    this.DefaultCellStyle.BackColor = Color.White;
                }
                string Scale = str.Substring(index_Scale, index_Width - index_Scale);
                int index_x = Scale.IndexOf("*");
                //string ScaleWidth = Scale.Substring(1, index_x - 1);
                //string ScaleHeight = Scale.Substring(index_x + 1, Scale.Length - index_x - 1);
                //System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                //double widthScale = double.Parse(ScaleWidth) / (double)rc.Width;
                //double heigthScale = double.Parse(ScaleHeight) / (double)rc.Height;

                string[] columns = null;
                if (index_Merge == -1)
                {
                    columns = str.Substring(index_Width + 1, str.Length - index_Width - 1).Split('$');
                }
                else
                {
                    columns = str.Substring(index_Width + 1, index_Merge - index_Width - 1).Split('$');
                }
                double reportWidthScale = double.Parse(columns[0]) / (double)this.Width;
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    int width = (int)(int.Parse(columns[i + 1]) / reportWidthScale);
                    this.Columns[i].Width = width;
                }
                this.MergeCellArray.Clear();
                if (index_Merge != -1)
                {
                    string[] mergeCells = str.Substring(index_Merge + 1, str.Length - index_Merge - 2).Split('√');
                    foreach (string mergeCell in mergeCells)
                    {
                        if (mergeCell != "")
                        {
                            string[] mergeCellPro = mergeCell.Split(',');
                            int MaxColumnIndex = int.Parse(mergeCellPro[0]);
                            int MaxRowIndex = int.Parse(mergeCellPro[1]);
                            int MinColumnIndex = int.Parse(mergeCellPro[2]);
                            int MinRowIndex = int.Parse(mergeCellPro[3]);
                            int MiddleColumnIndex = int.Parse(mergeCellPro[4]);
                            int MiddleRowIndex = int.Parse(mergeCellPro[5]);
                            MergeCell mc = new MergeCell(MaxColumnIndex, MaxRowIndex, MinColumnIndex, MinRowIndex, MiddleColumnIndex, MiddleRowIndex);
                            this.MergeCellArray.Add(mc);
                            for (int i = MinRowIndex; i <= MaxRowIndex; i++)
                            {
                                for (int j = MinColumnIndex; j <= MaxColumnIndex; j++)
                                {
                                    this.Rows[i].Cells[j].ReadOnly = true;
                                }
                            }
                            this.Rows[MiddleRowIndex].Cells[MiddleColumnIndex].ReadOnly = false;
                        }
                    }
                }
                this.Refresh();
            }
            catch { }
        }

        #region DataGridView截图
        PictureBox pictureBox = new PictureBox();
        private int defaultScaleWidth = 1280;
        public int DefaultScaleWidth
        {
            get { return this.defaultScaleWidth; }
            set { this.defaultScaleWidth = value; }
        }
        /// <summary>
        /// DATAGRIDVIEW跨越滚动截图
        /// </summary>
        /// <param name="_View">DataGridView</param>
        /// <returns>图形</returns>
        public Image DrawViewToImage(int times, float Ftimes)
        {
            Font font = this.Font;
            DockStyle ds = this.Dock;
            bool addRows = this.AllowUserToAddRows;
            DataGridViewAutoSizeColumnsMode dgvscm = this.AutoSizeColumnsMode;
            Color backcolor = this.DefaultCellStyle.BackColor;
            this.DefaultCellStyle.BackColor = Color.White;
            pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
            SizeF size = new SizeF(this.Size);
            this.AllowUserToAddRows = false;
            this.Dock = DockStyle.None;
            pictureBox.Size = this.Size;
            pictureBox.Location = this.Location;
            Bitmap thisBmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            this.DrawToBitmap(thisBmp, new System.Drawing.Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
            pictureBox.Image = thisBmp;

            this.Visible = false;
            this.Font = new Font("宋体", 9 * Ftimes, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
            System.Drawing.Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            double widthScale = (double)this.DefaultScaleWidth / (double)rc.Width;
            this.Size = new Size((int)(size.Width * widthScale), (int)(size.Height));
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.AutoSize = true;

            int height = 0;
            for (int i = 0; i < this.Rows.Count; i++)
            {
                height += this.Rows[i].Height;
            }
            Bitmap _NewBitmap = new Bitmap((int)((this.Width) - 32), (int)(height + 5));
            this.DrawToBitmap(_NewBitmap, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));
            pictureBox = new PictureBox();
            pictureBox.Image = _NewBitmap;
            pictureBox.Size = new Size(_NewBitmap.Size.Width + 10, _NewBitmap.Size.Height + 5);// new Size((int)(this.Width * times), (int)(this.Height * times));
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.BackColor = Color.White;
            Bitmap newbitm = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(newbitm, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));

            this.AutoSize = false;
            this.Visible = true;
            thisBmp.Dispose();
            //_NewBitmap.Dispose();
            //pictureBox.Dispose();
            this.AllowUserToAddRows = addRows;
            this.Font = font;
            this.Dock = ds;
            this.AutoSizeColumnsMode = dgvscm;
            this.DefaultCellStyle.BackColor = backcolor;
            return newbitm;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(
                   pictureBox.Image,
                    new Rectangle(0, 0, pictureBox.Width, pictureBox.Height),
                    // destination rectangle 
                    0,
                    0,           // upper-left corner of source rectangle
                    pictureBox.Width,       // width of source rectangle
                    pictureBox.Height,      // height of source rectangle
                    GraphicsUnit.Pixel);
            }
        }

        #endregion

        #region XMLFileInit

        private string xmlFile;
        public string XmlFile
        {
            get { return this.xmlFile; }
            set { this.xmlFile = value; }
        }

        /// <summary>
        /// 根据DataGridView当前排列顺序和宽度记录在DataTable中
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public System.Data.DataTable GetViewColumns()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXml(this.xmlFile);
            if(ds.Tables==null||ds.Tables.Count==0)
                return null;
            DataTable dt=ds.Tables[0];
            List<DataRow> drsTemp = new List<DataRow>();
            for (int i = 0; i < this.Columns.Count; i++)
            {
                bool isHave = false;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["ColumnName"].ToString() == this.Columns[i].Name)
                    {
                        dt.Rows[j]["DisplayIndex"] = this.Columns[i].DisplayIndex.ToString("000");
                        dt.Rows[j]["Width"] = this.Columns[i].Width;
                        isHave = true;
                        break;
                    }
                }
                if (!isHave)
                {
                    DataRow dr = dt.NewRow();
                    dr["ColumnName"] = this.Columns[i].Name;
                    dr["DisplayIndex"] = this.Columns[i].DisplayIndex;
                    dr["Text"] = this.Columns[i].HeaderText;
                    dr["DataName"] = this.Columns[i].DataPropertyName;
                    dr["Visible"] = this.Columns[i].Visible == true ? 1 : 0;
                    dr["Width"] = this.Columns[i].Width;
                    dr["AutoSizeMode"] = this.Columns[i].AutoSizeMode;
                    drsTemp.Add(dr);
                }
            }
            if (drsTemp.Count > 0)
            {
                foreach (DataRow dr in drsTemp)
                {
                    dt.Rows.Add(dr);
                }
            }
            System.Data.DataRow[] drs = dt.Select("1=1", " DisplayIndex Asc");
            ds = new System.Data.DataSet();
            ds.Merge(drs);
            return ds.Tables[0];
        }

        /// <summary>
        /// 根据XmlFile中的表数据设置DataGridView的列头的名称、文本、显示与否、显示位置、宽度、自动调节模式，并返回XmlFile表数据的DataTable
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public System.Data.DataTable SetViewColumns()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXml(this.xmlFile);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < this.Columns.Count; j++)
                {
                    if (ds.Tables[0].Rows[i]["ColumnName"].ToString() == this.Columns[j].Name)
                    {
                        this.initColumn((DataGridViewTextBoxColumn)this.Columns[j], ds.Tables[0].Rows[i]);
                        break;
                    }
                }
            }
            return ds.Tables[0];
        }


        /// <summary>
        /// 根据XmlFile中的表数据添加列并设置DataGridView的列头的名称、文本、显示与否、显示位置、宽度、自动调节模式，并返回XmlFile表数据的DataTable
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public System.Data.DataTable AddViewColumns()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXml(this.xmlFile);
            this.Columns.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                this.initColumn(column, ds.Tables[0].Rows[i]);
                this.Columns.Add(column);
            }
            return ds.Tables[0];
        }

        private DataGridViewTextBoxColumn initColumn(DataGridViewTextBoxColumn column, System.Data.DataRow dr)
        {
            column.Name = dr["ColumnName"].ToString();
            column.Visible = dr["Visible"].ToString() == "0" ? false : true;
            column.HeaderText = dr["Text"].ToString();
            column.DisplayIndex = Convert.ToInt32(dr["DisplayIndex"].ToString());
            column.Width = Convert.ToInt32(dr["Width"].ToString());
            column.DataPropertyName = dr["DataName"].ToString();
            switch (dr["AutoSizeMode"].ToString())
            {
                case "NotSet":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                    break;
                case "AllCells":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    break;
                case "AllCellsExceptHeader":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    break;
                case "ColumnHeader":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    break;
                case "DisplayedCells":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    break;
                case "DisplayedCellsExceptHeader":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                    break;
                case "Fill":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                case "None":
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    break;
            }
            return column;
        }

        #endregion
    }
}

