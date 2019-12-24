using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SIS_Function
{
    /// <summary>
    /// 控制数据导出到Excel中
    /// </summary>
    public class Excel
    {
        private delegate void dlgExcelOdbc(System.Windows.Forms.DataGridView gridView, string FileName);
        private delegate void dlgExcelOdbc2(string caption, string date, DataGridView dgv, string FileName);
        public static IAsyncResult sync;
        public static ProGressForm pgf;
        public static int Block = 0;
        private Timer tim;

        //导出当前页DataGridView中的数据到EXcel中
        public void ExportTOExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SaveFileDialog sfdl = new SaveFileDialog();
                sfdl.Filter = "Execl files (*.xls)|*.xls";
                sfdl.FilterIndex = 0;
                sfdl.RestoreDirectory = true;
                sfdl.CreatePrompt = true;
                sfdl.Title = "导出文件保存路径";
                sfdl.ShowDialog();
                string strName = sfdl.FileName;
                if (strName.Length != 0)
                {
                    tim = new Timer();
                    tim.Tick += new EventHandler(tim_Tick);
                    tim.Start();
                    ExportExcel2("登记记录", "", dgv, strName);
                }
            }
        }

        private void tim_Tick(object sender, EventArgs e)
        {
            if (sync != null)
            {
                while (!sync.IsCompleted)
                {
                    Application.DoEvents();
                    if (Block <= 100)
                    {
                        pgf.progressBar1.Value = Block;
                    }
                }
                pgf.DialogResult = DialogResult.OK;
                tim.Stop();
            }
        }

        public static void ExportExcel(System.Windows.Forms.DataGridView gridView, string FileName)
        {
            dlgExcelOdbc fd = new dlgExcelOdbc(ProGressForm.FillExcel);
            sync = fd.BeginInvoke(gridView, FileName, null, null);
            pgf = new ProGressForm();
            pgf.l_Notice.Text = "正在导出....";
            pgf.progressBar1.Style = ProgressBarStyle.Blocks;
            pgf.progressBar1.Value = 0;
            pgf.ShowDialog();
        }

        public static void ExportExcel2(string caption, string date, DataGridView dgv, string FileName)
        {
            dlgExcelOdbc2 fd = new dlgExcelOdbc2(ProGressForm.ExportToExcel);
            sync = fd.BeginInvoke(caption, date, dgv, FileName, null, null);
            pgf = new ProGressForm();
            pgf.l_Notice.Text = "正在导出....";
            pgf.progressBar1.Style = ProgressBarStyle.Blocks;
            pgf.progressBar1.Value = 0;
            pgf.ShowDialog();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //导出整个DataGridView中的数据到Excel中
        //public void ExportTOExcel2()
        //{
        //    if (this.ExamLView.Rows.Count == 0)
        //    {
        //        MessageBox.Show("没有数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    else
        //    {
        //        this.saveFileDialog2.Filter = "Execl files (*.xls)|*.xls";
        //        this.saveFileDialog2.FilterIndex = 0;
        //        this.saveFileDialog2.RestoreDirectory = true;
        //        //saveFileDialog2.CreatePrompt = true;
        //        this.saveFileDialog2.Title = "导出文件保存路径";
        //        this.saveFileDialog2.FileName = null;
        //        this.saveFileDialog2.ShowDialog();
        //        string FileName = saveFileDialog2.FileName;

        //        if (FileName.Length != 0)
        //        {
        //            progressBar.Visible = true;
        //            System.Data.DataTable dt = objSet.Tables[0];

        //            System.IO.FileStream objFileStream;
        //            System.IO.StreamWriter objStreamWriter;
        //            string strLine = "";
        //            objFileStream = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
        //            objStreamWriter = new System.IO.StreamWriter(objFileStream, System.Text.Encoding.Unicode);
        //            progressBar.Value = 0;

        //            for (int i = 0; i < dt.Columns.Count; i++)
        //            {
        //                strLine = strLine + dt.Columns[i].ColumnName.ToString() + Convert.ToChar(9);

        //            }
        //            objStreamWriter.WriteLine(strLine);
        //            strLine = "";

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                strLine = strLine + (i + 1) + Convert.ToChar(9);
        //                for (int j = 1; j < dt.Columns.Count; j++)
        //                {
        //                    strLine = strLine + dt.Rows[i][j].ToString() + Convert.ToChar(9);

        //                }
        //                objStreamWriter.WriteLine(strLine);
        //                progressBar.Value += 100 / dt.Rows.Count;
        //                strLine = "";
        //            }
        //            objStreamWriter.Close();
        //            objFileStream.Close();
        //            MessageBox.Show("数据已经成功导出到：" + this.saveFileDialog2.FileName.ToString(), "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            progressBar.Value = 0;
        //            progressBar.Visible = false;
        //        }
        //    }
        //}

        ////————————————————————————————————————————————————————————————————————
        ////导出到XML(整个数据源)

        //public void ExportTOXML()
        //{
        //    if (this.ExamLView.Rows.Count == 0)
        //    {
        //        MessageBox.Show("没有数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    else
        //    {
        //        this.saveFileDialog2.Filter = "XML files (*.xml)|*.xml";
        //        this.saveFileDialog2.FilterIndex = 0;
        //        this.saveFileDialog2.RestoreDirectory = true;
        //        this.saveFileDialog2.Title = "导出文件保存路径";
        //        this.saveFileDialog2.FileName = null;
        //        this.saveFileDialog2.ShowDialog();
        //        string FileName = this.saveFileDialog2.FileName;

        //        if (FileName.Length != 0)
        //        {
        //            progressBar.Visible = true;
        //            objSet.WriteXml(this.saveFileDialog2.FileName.ToString());
        //            for (int i = 0; i < objSet.Tables[0].Rows.Count; i++)
        //            {
        //                progressBar.Value += 100 / objSet.Tables[0].Rows.Count;
        //            }
        //            MessageBox.Show("数据已经成功导出到：" + this.saveFileDialog2.FileName.ToString(), "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            progressBar.Value = 0;
        //            progressBar.Visible = false;
        //        }
        //    }
        //}

    }
}
