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
            excel.Visible = false;//����true�����ڵ�����ʱ�����ʾEXcel���档
            if (excel == null)
            {
                MessageBox.Show("EXCEL�޷�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Workbooks books = (Workbooks)excel.Workbooks;
            Workbook book = (Workbook)(books.Add(miss));
            Worksheet sheet = (Worksheet)book.ActiveSheet;
            sheet.Name = "test";
            float fl = 0;
            //�����ֶ�����
            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                if (gridView.Columns[i].Visible == true && (gridView.Columns[i] is DataGridViewTextBoxColumn))
                {
                    excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText.ToString();
                }
            }
            //�������
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
            MessageBox.Show("�����Ѿ��ɹ���������" + FileName, "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ��DataGridView�е����ݵ�����Excel�У���������ʾ����(�޼���ģ��)
        /// ֻ����һ��ĵ���Excel
        /// </summary>
        /// <param name="caption">Ҫ��ʾ��ҳͷ</param>
        /// <param name="date">��ӡ����</param>
        /// <param name="dgv">Ҫ���е�����DataGridView</param>
        public static void ExportToExcel(string caption, string date, DataGridView dgv, string FileName)
        {
            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            ApplicationClass Mylxls = new ApplicationClass();
            Mylxls.Application.Workbooks.Add(true); ;
            Mylxls.Visible = false;//����true�����ڵ�����ʱ�����ʾEXcel���档
            if (Mylxls == null)
            {
                MessageBox.Show("EXCEL�޷�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Workbooks books = (Workbooks)Mylxls.Workbooks;
            Workbook book = (Workbook)(books.Add(miss));
           Worksheet sheet = (Worksheet)book.ActiveSheet;
            sheet.Name = "worklist";
            //DataGridView�ɼ�����
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
                //��ǰ�����е�����
                int currentcolumnindex = 1;
                //��ǰ�����е�����
                //Microsoft.Office.Interop.Excel.ApplicationClass Mylxls = new Microsoft.Office.Interop.Excel.ApplicationClass();
                //Mylxls.Application.Workbooks.Add(true);
                //Mylxls.Cells.Font.Size = 10.5;   //����Ĭ�������С
                //���ñ�ͷ
                //Mylxls.Caption = caption;
                ////��ʾ��ͷ
                //Mylxls.Cells[1, 1] = caption;
                //��ʾʱ��
                //Mylxls.Cells[2, 1] = date;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true && (dgv.Columns[i] is DataGridViewTextBoxColumn))   //�����ʾ
                    {
                        Mylxls.Cells[1, currentcolumnindex] = dgv.Columns[i].HeaderText;
                        Mylxls.get_Range(Mylxls.Cells[1, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).Cells.Borders.LineStyle = 1; //���ñ߿�
                        Mylxls.get_Range(Mylxls.Cells[1, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).ColumnWidth = dgv.Columns[i].Width / 8;
                        //Mylxls.get_Range(Mylxls.Cells[3, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).Font.Bold = true; //����
                        Mylxls.get_Range(Mylxls.Cells[1, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).HorizontalAlignment = XlHAlign.xlHAlignCenter; //������ʾ
                        currentcolumnindex++;
                    }
                }
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).MergeCells = true; //�ϲ���Ԫ��
               // Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).RowHeight = 30;   //�и�
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Name = "����";
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Size = 14;   //�����С
               // Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //������ʾ
                //Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).MergeCells = true; //�ϲ�
                //Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //�����ʾ
                //Mylxls.get_Range(Mylxls.Cells[1, 2], Mylxls.Cells[1, 2]).ColumnWidth = 12;  //�п��

                object[,] dataArray = new object[dgv.Rows.Count, visiblecolumncount];
                float fl = 0;
                //��ǰ�����е�����
                //int currentcolumnindex = 1;
                //��ǰ�����е�����
                for (int i = 0; i < dgv.Rows.Count; i++)   //ѭ���������
                {
                    currentcolumnindex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true && (dgv.Columns[j] is DataGridViewTextBoxColumn))
                        {
                            if (dgv[j, i].Value != null)  //�����Ԫ�����ݲ�Ϊ��
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
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[dgv.Rows.Count + 1, visiblecolumncount]).Value2 = dataArray; //���ñ߿�
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[dgv.Rows.Count + 1, visiblecolumncount]).Cells.Borders.LineStyle = 1; //���ñ߿�
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[dgv.Rows.Count + 1, visiblecolumncount]).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight; //�ұ���ʾ
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
                MessageBox.Show("��Ϣ����ʧ�ܣ���ȷ����Ļ�����װ��Microsoft Office Excel 2003��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                GC.Collect();
                MessageBox.Show("�����Ѿ��ɹ���������" + FileName, "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Excel.Block = 0;
            }
        }


    }
}