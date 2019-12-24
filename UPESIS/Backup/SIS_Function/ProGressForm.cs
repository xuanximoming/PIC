using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel;

namespace SIS_Function
{
    public partial class ProGressForm : Form
    {
        public ProGressForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            //Display.SettingBackColor((Form)this); 
        }

        public static void FillExcel(System.Windows.Forms.DataGridView gridView, string FileName)
        {
            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            ApplicationClass excel = new ApplicationClass();
            excel.Application.Workbooks.Add(true); ;
            excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
            if (excel == null)
            {
                MessageBox.Show("EXCEL无法启动！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Workbooks books = (Workbooks)excel.Workbooks;
            Workbook book = (Workbook)(books.Add(miss));
            Worksheet sheet = (Worksheet)book.ActiveSheet;
            sheet.Name = "test";
            float fl = 0;
            //生成字段名称
            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                if (gridView.Columns[i].Visible == true && (gridView.Columns[i] is DataGridViewTextBoxColumn))
                {
                    excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText.ToString();
                }
            }
            //填充数据
            for (int i = 0; i < gridView.RowCount - 1; i++)
            {
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    if (gridView.Columns[j].Visible == true && (gridView.Columns[j] is DataGridViewTextBoxColumn))
                    {

                        if (gridView[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + gridView[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
                        }
                    }
                }
                fl += 100 / float.Parse(gridView.RowCount.ToString());
                if (fl > 1)
                {
                    Excel.Block += 1;
                    fl = 0;
                }
            }
            sheet.SaveAs(FileName, miss, miss, miss, miss, miss, XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
            book.Close(false, miss, miss);
            books.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            GC.Collect();
            MessageBox.Show("数据已经成功导出到：" + FileName, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel中，并加载显示出来(无加载模板)
        /// 只用于一般的导出Excel
        /// </summary>
        /// <param name="caption">要显示的页头</param>
        /// <param name="date">打印日期</param>
        /// <param name="dgv">要进行导出的DataGridView</param>
        public static void ExportToExcel(string caption, string date, DataGridView dgv, string FileName)
        {
            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            ApplicationClass Mylxls = new ApplicationClass();
            Mylxls.Application.Workbooks.Add(true); ;
            Mylxls.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
            if (Mylxls == null)
            {
                MessageBox.Show("EXCEL无法启动！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Workbooks books = (Workbooks)Mylxls.Workbooks;
            Workbook book = (Workbook)(books.Add(miss));
           Worksheet sheet = (Worksheet)book.ActiveSheet;
            sheet.Name = "worklist";
            //DataGridView可见列数
            int visiblecolumncount = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible == true && (dgv.Columns[i] is DataGridViewTextBoxColumn))
                {
                    visiblecolumncount++;
                }
            }

            try
            {
                //当前操作列的索引
                int currentcolumnindex = 1;
                //当前操作行的索引
                //Microsoft.Office.Interop.Excel.ApplicationClass Mylxls = new Microsoft.Office.Interop.Excel.ApplicationClass();
                //Mylxls.Application.Workbooks.Add(true);
                //Mylxls.Cells.Font.Size = 10.5;   //设置默认字体大小
                //设置标头
                //Mylxls.Caption = caption;
                ////显示表头
                //Mylxls.Cells[1, 1] = caption;
                //显示时间
                //Mylxls.Cells[2, 1] = date;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true && (dgv.Columns[i] is DataGridViewTextBoxColumn))   //如果显示
                    {
                        Mylxls.Cells[1, currentcolumnindex] = dgv.Columns[i].HeaderText;
                        Mylxls.get_Range(Mylxls.Cells[1, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).Cells.Borders.LineStyle = 1; //设置边框
                        Mylxls.get_Range(Mylxls.Cells[1, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).ColumnWidth = dgv.Columns[i].Width / 8;
                        //Mylxls.get_Range(Mylxls.Cells[3, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).Font.Bold = true; //粗体
                        Mylxls.get_Range(Mylxls.Cells[1, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).HorizontalAlignment = XlHAlign.xlHAlignCenter; //居中显示
                        currentcolumnindex++;
                    }
                }
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).MergeCells = true; //合并单元格
               // Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).RowHeight = 30;   //行高
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Name = "黑体";
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Size = 14;   //字体大小
               // Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //居中显示
                //Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).MergeCells = true; //合并
                //Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //左边显示
                //Mylxls.get_Range(Mylxls.Cells[1, 2], Mylxls.Cells[1, 2]).ColumnWidth = 12;  //列宽度

                object[,] dataArray = new object[dgv.Rows.Count, visiblecolumncount];
                float fl = 0;
                //当前操作列的索引
                //int currentcolumnindex = 1;
                //当前操作行的索引
                for (int i = 0; i < dgv.Rows.Count; i++)   //循环填充数据
                {
                    currentcolumnindex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true && (dgv.Columns[j] is DataGridViewTextBoxColumn))
                        {
                            if (dgv[j, i].Value != null)  //如果单元格内容不为空
                            {
                                dataArray[i, currentcolumnindex - 1] = dgv[j, i].Value.ToString();
                            }
                            currentcolumnindex++;
                        }
                    }
                    fl += 100 / float.Parse(dgv.RowCount.ToString());
                    if (fl > 1)
                    {
                        Excel.Block += 1;
                        fl = 0;
                    }
                }
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[dgv.Rows.Count + 1, visiblecolumncount]).Value2 = dataArray; //设置边框
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[dgv.Rows.Count + 1, visiblecolumncount]).Cells.Borders.LineStyle = 1; //设置边框
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[dgv.Rows.Count + 1, visiblecolumncount]).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight; //右边显示
                sheet.SaveAs(FileName, miss, miss, miss, miss, miss, XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                book.Close(false, miss, miss);
                books.Close();
                Mylxls.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Mylxls);
            }
            catch
            {
                MessageBox.Show("信息导出失败，请确认你的机子上装有Microsoft Office Excel 2003！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                GC.Collect();
                MessageBox.Show("数据已经成功导出到：" + FileName, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Excel.Block = 0;
            }
        }


    }
}