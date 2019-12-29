using ILL;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using SIS.Function;
using SIS_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIS
{
    /// <summary>
    /// Word��
    /// </summary>
    public class WordClass
    {
        private MUser mUser;
        ApplicationClass WordApp;
        Document WordDoc;
        private BaseControls.WinWordControl winWordCtl;
        public MWorkList mWorklist;
        private MReport mReport;
        private MStudy mStudy;
        private object pass = "xxx";
        private object missing = Type.Missing;
        private object set = true;
        public struct WordCell
        {
            public string Name;
            public int TableIndex;
            public int RowIndex;
            public int ColumnIndex;
            public int PageIndex;

        }
        public struct Template
        {
            public string ExamPara;
            public string Impression;
            public string Description;
            public string Recommendation;
        }
        private List<WordCell> WordCells;//���������ֶε�λ��
        private List<WordImgCell> imgCells;
        private WordCell wcImg;
        public bool Saved
        {
            get { return WordDoc.Saved; }
            set { WordDoc.Saved = value; }
        }

        public WordClass(BaseControls.WinWordControl word)
        {
            this.winWordCtl = word;
            mUser = (MUser)frmMainForm.iUser;
        }
        /// <summary>
        /// ��ģ�沢����һЩ���ã�
        /// </summary>
        /// <returns>-1Ϊʧ�ܣ�1Ϊ�ɹ�</returns>
        public int WordInit(MWorkList model, MReport mReport, string RptPath)
        {
            this.mWorklist = model;
            this.mReport = mReport;
            //��ģ��

            if (WordOpen(RptPath) == -1)
                return -1;
            if (mReport.FIELD_INF != null)
            {
                WordCells = SetWordCells(mReport.FIELD_INF);
                if (mReport.EXAM_NO == "" || mReport.EXAM_NO == null)
                {
                    InitValues();
                }
                else
                {
                    initWorklist();
                }
            }
            WordDoc.Saved = true;
            winWordCtl.OnResize();
            // InsertPicture(arrayImg);
            return 1;
        }
        /// <summary>
        /// ��ģ�沢����һЩ���ã�
        /// </summary>
        /// <returns>-1Ϊʧ�ܣ�1Ϊ�ɹ�</returns>
        public int WordInitChange(MWorkList model, MReport mReport, string RptPath)
        {
            this.mWorklist = model;
            this.mReport = mReport;
            //��ģ��

            if (WordOpen(RptPath) == -1)
                return -1;
            if (mReport.FIELD_INF != null)
            {
                WordCells = SetWordCells(mReport.FIELD_INF);
                //if (mReport.EXAM_NO == "" || mReport.EXAM_NO == null)
                //{
                InitValues();
                // }
                //else
                //{
                //   initWorklist();
                //}
            }
            WordDoc.Saved = true;
            winWordCtl.OnResize();
            // InsertPicture(arrayImg);
            return 1;
        }
        /// <summary>
        /// ��ģ�沢����һЩ���ã�
        /// </summary>
        /// <returns>-1Ϊʧ�ܣ�1Ϊ�ɹ�</returns>
        public int HistoryWordInit(MReport mReport, string RptPath)
        {
            this.mReport = mReport;
            //��ģ��

            if (WordOpen(RptPath) == -1)
                return -1;
            if (mReport.FIELD_INF != null)
            {
                WordCells = SetWordCells(mReport.FIELD_INF);
            }
            winWordCtl.OnResize();
            // InsertPicture(arrayImg);
            return 1;
        }
        /// <summary>
        /// ��ģ�沢����һЩ���ã�
        /// </summary>
        /// <returns>-1Ϊʧ�ܣ�1Ϊ�ɹ�</returns>
        public int PacsWordInit(MReport mReport, MStudy mStudy, string RptPath)
        {
            this.mReport = mReport;
            this.mStudy = mStudy;
            //��ģ��

            if (WordOpen(RptPath) == -1)
                return -1;
            if (mReport.FIELD_INF != null)
            {
                WordCells = SetWordCells(mReport.FIELD_INF);
            }
            InitPacsRpt();
            winWordCtl.OnResize();
            return 1;
        }
        /// <summary>
        /// ��WORD
        /// </summary>
        /// <returns>-1:�򿪲��ɹ���1���򿪳ɹ�</returns>
        public int WordOpen(string FileName)
        {
            WordDoc = null;
            WordApp = null;
            this.imgCells = null;
            try
            {
                //Load the template used for testing.
                this.winWordCtl.LoadDocument(FileName);
                WordDoc = this.winWordCtl.document;
                WordApp = this.winWordCtl.wd;
                return 1;
            }
            catch
            {
                this.winWordCtl.QuitWord();
                return -1;
            }
        }

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        private void InitValues()
        {
            initWorklist();
            initReport();
            //��WORD������ѡ��
            WordCombSource CmbSource = new WordCombSource();
            oleComboxBind(FieldDict.cmbSex, CmbSource.GetSex(), mWorklist.PATIENT_SEX);
            oleComboxBind(FieldDict.cmbAPPROVER, CmbSource.GetAPPROVER(mUser.CLINIC_OFFICE_CODE), mUser.DOCTOR_NAME);
            this.imgCells = new List<WordImgCell>();

        }
        private void InitPacsRpt()
        {
            SetValue(FieldDict.PATIENT_ID, mStudy.PATIENT_ID);
            SetValue(FieldDict.PATIENT_NAME, mStudy.PATIENT_NAME);
            SetValue(FieldDict.PATIENT_SEX, mStudy.PATIENT_SEX);
            //SetValue("PATIENT_PHONETIC", mStudy.PATIENT_PHONETIC);
            SetValue(FieldDict.PATIENT_AGE, mStudy.PATIENT_AGE.ToString() + mStudy.PATIENT_AGE_UNIT);
            SetValue(FieldDict.EXAM_ITEM, mStudy.EXAM_ITEM);
            SetValue(FieldDict.REQ_DEPT_NAME, mStudy.REQ_DEPT_NAME);
            SetValue(FieldDict.REQ_DATE_TIME, mStudy.REQ_DATE_TIME.ToString());
            SetValue(FieldDict.BED_NUM, mStudy.BED_NUM);
            SetValue(FieldDict.INP_NO, mStudy.INP_NO);
            SetValue(FieldDict.DEVICE, mStudy.DEVICE);
            SetValue(FieldDict.EXAM_CLASS, mStudy.EXAM_CLASS);
            SetValue(FieldDict.STUDY_ID, mStudy.STUDY_ID);
            SetValue(FieldDict.EXAM_SUB_CLASS, mStudy.EXAM_SUB_CLASS);
            SetValue(FieldDict.OUT_MED_INSTITUTION, mStudy.FACILITY);
            SetValue(FieldDict.EXAM_GROUP, mStudy.EXAM_GROUP);
            SetValue(FieldDict.REFER_DOCTOR, mStudy.REFER_DOCTOR);
            initReport();
        }
        public int initWorklist()
        {
            SetValue(FieldDict.PATIENT_ID, mWorklist.PATIENT_ID);
            SetValue(FieldDict.PATIENT_NAME, mWorklist.PATIENT_NAME);
            SetValue(FieldDict.PATIENT_SEX, mWorklist.PATIENT_SEX);
            //SetValue("PATIENT_PHONETIC", mWorklist.PATIENT_PHONETIC);
            SetValue(FieldDict.PATIENT_AGE, mWorklist.PATIENT_AGE.ToString() + mWorklist.PATIENT_AGE_UNIT);
            SetValue(FieldDict.EXAM_ITEMS, mWorklist.EXAM_ITEMS);
            SetValue(FieldDict.REQ_DEPT_NAME, mWorklist.REQ_DEPT_NAME);
            //SetValue(FieldDict.REQ_DATE_TIME, mWorklist.REQ_DATE_TIME.ToString());//�ͼ�ʱ��,������ʱ��
            SetValue(FieldDict.REQ_DATE_TIME, DateTime.Parse(mWorklist.REQ_DATE_TIME.ToString()).ToString(GetConfig.ReportDateFormat));
            SetValue(FieldDict.BED_NUM, mWorklist.BED_NUM);
            SetValue(FieldDict.INP_NO, mWorklist.INP_NO);
            SetValue(FieldDict.DEVICE, mWorklist.DEVICE);
            SetValue(FieldDict.EXAM_CLASS, mWorklist.EXAM_CLASS);
            SetValue(FieldDict.PATIENT_LOCAL_ID, mWorklist.PATIENT_LOCAL_ID);
            SetValue(FieldDict.EXAM_SUB_CLASS, mWorklist.EXAM_SUB_CLASS);
            SetValue(FieldDict.EXAM_GROUP, mWorklist.EXAM_GROUP);
            SetValue(FieldDict.OUT_MED_INSTITUTION, mWorklist.OUT_MED_INSTITUTION);
            SetValue(FieldDict.TELEPHONE_NUM, mWorklist.TELEPHONE_NUM);//�绰
            SetValue(FieldDict.REFER_DOCTOR, mWorklist.REFER_DOCTOR);

            SetValue(FieldDict.MAILING_ADDRESS, mWorklist.MAILING_ADDRESS);//��ַ
            SetValue(FieldDict.CLIN_DIAG, mWorklist.CLIN_DIAG);//�ٴ����
            SetValue(FieldDict.CLIN_SYMP, mWorklist.CLIN_SYMP);//֢״
            return 1;
        }
        private int initReport()
        {
            try
            {
                if (mReport == null)
                {
                    mReport = new MReport();

                }
                if (mReport.EXAM_NO == null)
                {
                    SetValue(FieldDict.DATE_TIME_NOW, DateTime.Now.ToString(GetConfig.ReportDateFormat));//��ǰʱ��
                }
                SetValue(FieldDict.DESCRIPTION, mReport.DESCRIPTION);
                SetValue(FieldDict.EXAM_PARA, mReport.EXAM_PARA);
                SetValue(FieldDict.IMPRESSION, mReport.IMPRESSION);
                SetValue(FieldDict.RECOMMENDATION, mReport.RECOMMENDATION);
                if (mReport.REPORT_DATE_TIME == null)
                    SetValue(FieldDict.REPORT_DATE_TIME, System.DateTime.Now.ToString(GetConfig.ReportDateFormat));//����ʱ��
                else
                    SetValue(FieldDict.REPORT_DATE_TIME, DateTime.Parse(mReport.REPORT_DATE_TIME.ToString()).ToString(GetConfig.ReportDateFormat));//����ʱ��
                //modify by liukun at 2010-7-8  begin 
                //�޸ļ�¼�����鿴���ߵ���ʷ����ʱ����鱨��ı���ҽ������ʾ�ɵ�ǰ��¼�û����û��������ǲ���ȷ�ģ���ȷ��Ӧ����ʾ��ԭʼ����ı���ҽ����
                //�޸�˼·����������ȡ����ҽ����������ҽ��Ϊ�գ���ȡ���ҽ���������ҽ����ȻΪ��ʱ����ȡ��ǰ��¼ϵͳ���û�����
                SetValue(FieldDict.TRANSCRIBER, //���ñ���ҽ�� begin  
                            (this.mReport != null && this.mReport.TRANSCRIBER != null && this.mReport.TRANSCRIBER.ToString().Trim() != "") ?  //�������ҽ����Ϊ��
                            this.mReport.TRANSCRIBER.ToString().Trim() :   //��ȡ����ҽ�������֣�����ȡ���ҽ��������
                            ((this.mStudy != null && this.mStudy.EXAM_DOCTOR == null && this.mStudy.EXAM_DOCTOR.ToString().Trim() == "") ?    //������ҽ����Ϊ��
                            this.mStudy.EXAM_DOCTOR.ToString().Trim() :    //��ȡ���ҽ�������֣�����ȡ���ҽ��������
                            ((MUser)frmMainForm.iUser).DOCTOR_NAME)        //ȡ���ҽ��������
                         );   //���ñ���ҽ��  end 
                //modify by liukun at 2010-7-8  end 
                SetValue(FieldDict.APPROVE_DATE_TIME, mReport.APPROVE_DATE_TIME.ToString());
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }
        /// <summary>
        /// ���ǩ������
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="CmdOrSheetName"></param>
        //public void SetValue(string key,string value,string CmdOrSheetName)
        //{
        //    this.axFramerControl1.SetFieldValue(key,value,CmdOrSheetName);
        //}
        /// <summary>
        /// ���ֶ����ֵ
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void SetValue(string Key, string Value)
        {
            unProtectWord();
            for (int i = 0; i < WordCells.Count; i++)
            {
                WordCell wc = (WordCell)WordCells[i];
                if (wc.Name == Key)
                {
                    if (wc.PageIndex > 0)
                    {
                        switch (wc.PageIndex)
                        {
                            case 1:
                                if (WordApp.ActiveWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
                                    WordApp.ActiveWindow.Panes[2].Close();
                                if (WordApp.ActiveWindow.View.Type == WdViewType.wdNormalView || WordApp.ActiveWindow.View.Type == WdViewType.wdOutlineView)
                                    WordApp.ActiveWindow.View.Type = WdViewType.wdPrintView;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                                WordApp.Selection.WholeStory();
                                WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = Value;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                                break;
                            case 2:
                                WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = Value;
                                break;
                            case 3:
                                if (WordApp.ActiveWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
                                    WordApp.ActiveWindow.Panes[2].Close();
                                if (WordApp.ActiveWindow.View.Type == WdViewType.wdNormalView || WordApp.ActiveWindow.View.Type == WdViewType.wdOutlineView)
                                    WordApp.ActiveWindow.View.Type = WdViewType.wdPrintView;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageFooter;
                                WordApp.Selection.WholeStory();
                                WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = Value;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                                break;
                        }
                    }
                    else
                        WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = Value;
                }
            }
            ProtectWord();
        }
        /// <summary>
        /// ���ݱ����ֶβ����ֶ�ֵ
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string GetValue(string Key)
        {
            string value = "";
            for (int i = 0; i < WordCells.Count; i++)
            {
                WordCell wc = (WordCell)WordCells[i];
                if (wc.Name == Key)
                    if (wc.PageIndex > 0)
                    {
                        switch (wc.PageIndex)
                        {
                            case 1:
                                if (WordApp.ActiveWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
                                    WordApp.ActiveWindow.Panes[2].Close();
                                if (WordApp.ActiveWindow.View.Type == WdViewType.wdNormalView || WordApp.ActiveWindow.View.Type == WdViewType.wdOutlineView)
                                    WordApp.ActiveWindow.View.Type = WdViewType.wdPrintView;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                                WordApp.Selection.WholeStory();
                                value = WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                                return value;
                            case 2:
                                value = WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text;
                                return value;
                            case 3:
                                if (WordApp.ActiveWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
                                    WordApp.ActiveWindow.Panes[2].Close();
                                if (WordApp.ActiveWindow.View.Type == WdViewType.wdNormalView || WordApp.ActiveWindow.View.Type == WdViewType.wdOutlineView)
                                    WordApp.ActiveWindow.View.Type = WdViewType.wdPrintView;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageFooter;
                                WordApp.Selection.WholeStory();
                                value = WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                                return value;
                        }
                    }
                    else
                        value = WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text;
            }
            return value;
        }
        /// <summary>
        /// ��ǩ�����ۼ�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="AppendValue"></param>
        public void ValueAppend(string Key, string AppendValue)
        {
            //SetValue(key, this.axFramerControl1.GetFieldValue(key, "") +Environment.NewLine+ AppendValue, "");
            for (int i = 0; i < WordCells.Count; i++)
            {
                WordCell wc = (WordCell)WordCells[i];
                if (wc.Name == Key)
                {
                    if (WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text == "\r\a")
                    {
                        WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = AppendValue;
                    }
                    else
                    {
                        WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text += AppendValue;
                    }
                }
            }
        }
        /// <summary>
        /// ���WORD����
        /// </summary>
        public void unProtectWord()
        {
            WordDoc.Unprotect(ref pass);
        }
        /// <summary>
        /// ����WORD
        /// </summary>
        public void ProtectWord()
        {
            WordDoc.Protect(WdProtectionType.wdAllowOnlyReading, ref set, ref pass, ref missing, ref missing);
        }
        public Template GetTemplate()
        {
            Template tem = new Template();
            tem.Recommendation = strFilter(GetValue(FieldDict.RECOMMENDATION));
            tem.Impression = strFilter(GetValue(FieldDict.IMPRESSION));
            tem.Description = strFilter(GetValue(FieldDict.DESCRIPTION));
            tem.ExamPara = strFilter(GetValue(FieldDict.EXAM_PARA));
            return tem;
        }
        /// <summary>
        /// ����ʱ��ȡWORD�ж�Ӧ�ֶε�����
        /// </summary>
        /// <returns></returns>
        public MReport GetMReport(object RptPath)
        {
            if (mReport.EXAM_NO == null || mReport.EXAM_NO == "")
            {
                mReport.EXAM_NO = mWorklist.EXAM_ACCESSION_NUM;
            }
            mReport.RECOMMENDATION = strFilter(GetValue(FieldDict.RECOMMENDATION));
            mReport.IMPRESSION = strFilter(GetValue(FieldDict.IMPRESSION));
            mReport.DESCRIPTION = strFilter(GetValue(FieldDict.DESCRIPTION));
            mReport.EXAM_PARA = strFilter(GetValue(FieldDict.EXAM_PARA));
            mReport.TRANSCRIBER = strFilter(GetValue(FieldDict.TRANSCRIBER));
            mReport.REPORT_TYPE = 1;
            if (mReport.REPORT_DATE_TIME == null)
                mReport.REPORT_DATE_TIME = System.DateTime.Now;
            SetValue(FieldDict.REPORT_DATE_TIME, System.DateTime.Now.ToString(GetConfig.ReportDateFormat));
            //mReport.FIELD_INF += "|IMAGES;" + WordImgCell.GetWordImgCells(this.imgCells);
            mReport.FIELD_INF = CutImageStr(mReport.FIELD_INF) + "|IMAGES;" + WordImgCell.GetWordImgCells(this.imgCells);
            object NewPath = System.Windows.Forms.Application.StartupPath + "\\temp\\NewReport.doc";
            object format = 0;
            object addRecentFiles = false;
            WordDoc.SaveAs(ref NewPath, ref format, ref missing, ref missing, ref addRecentFiles, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            WordDoc.SaveAs(ref RptPath, ref format, ref missing, ref missing, ref addRecentFiles, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            //for(int i=1;i<WordApp.RecentFiles.Count;i++)
            //{
            //    Microsoft.Office.Interop.Word.RecentFile rFile = WordApp.RecentFiles[i];
            //    if (rFile.Name == oldName)
            //        rFile.Open();
            //    //else
            //    //    WordApp.
            //}
            //WordApp.RecentFiles[0].Open();
            //WordApp.RecentFiles[1].
            //WordDoc.//this.axFramerControl1.SaveAs(NewPath, 0);
            return mReport;
        }
        /// <summary>
        /// �л�ģ��ʱȡ���������ݣ���������
        /// </summary>
        /// <returns></returns>
        public MReport GetMReport()
        {
            if (mReport.EXAM_NO == null || mReport.EXAM_NO == "")
            {
                mReport.EXAM_NO = mWorklist.EXAM_ACCESSION_NUM;
            }
            mReport.RECOMMENDATION = strFilter(GetValue(FieldDict.RECOMMENDATION));
            mReport.IMPRESSION = strFilter(GetValue(FieldDict.IMPRESSION));
            mReport.DESCRIPTION = strFilter(GetValue(FieldDict.DESCRIPTION));
            mReport.EXAM_PARA = strFilter(GetValue(FieldDict.EXAM_PARA));
            mReport.TRANSCRIBER = strFilter(GetValue(FieldDict.TRANSCRIBER));
            mReport.REPORT_TYPE = 1;
            mReport.REPORT_DATE_TIME = System.DateTime.Now;
            SetValue(FieldDict.REPORT_DATE_TIME, System.DateTime.Now.ToString(GetConfig.ReportDateFormat));
            mReport.FIELD_INF = CutImageStr(mReport.FIELD_INF) + "|IMAGES;" + WordImgCell.GetWordImgCells(this.imgCells);
            return mReport;
        }
        /// <summary>
        /// �г�mReport.FIELD_INF�е�ͼƬ��Ϣ�����ڱ���ʱ���ͼƬ��Ϣ�����»�ȡ�µ�ͼƬ��Ϣ
        /// </summary>
        /// <param name="FieldInf"></param>
        /// <returns></returns>
        private string CutImageStr(string FieldInf)
        {
            try
            {
                string Result = FieldInf;
                string[] Fileds = FieldInf.Split('|');
                string imgstr = Fileds[Fileds.Length - 1];
                if (imgstr.Substring(0, 6) == "IMAGES")
                    Result = FieldInf.Replace(imgstr, "").TrimEnd('|');
                return Result;
            }
            catch
            {
                return FieldInf;
            }
        }
        private string strFilter(string str)
        {
            return str.TrimEnd('\a').TrimEnd('\r');
        }
        private string strFilter2(string str)
        {
            return str.Replace("\r\a", "");
        }
        /// <summary>
        /// ����WORD
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public int SaveDocument(string FileName)
        {
            WordDoc.Save();
            //this.axFramerControl1.Save();
            return 0;
        }
        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <returns></returns>
        public int PrintDocument()
        {
            try
            {
                WordApp.ActiveDocument.PrintOut(ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing);
                return 1;
            }
            catch
            { return -1; }
        }
        /// <summary>
        /// ��ӡԤ��
        /// </summary>
        /// <returns></returns>
        public int PreViewDocument()
        {
            try
            {
                WordApp.ActiveDocument.PrintPreview();
                //WordApp.ActiveWindow.ActivePane.View.Zoom.Percentage = 100;
                return 1;
            }
            catch
            { return -1; }
        }
        public void SetPreViewPercentage()
        {
            WordApp.ActiveWindow.ActivePane.View.Zoom.Percentage = 100;
        }
        /// <summary>
        /// �رմ�ӡԤ��
        /// </summary>
        public int ClosePreViewDocument()
        {
            try
            {
                WordApp.ActiveDocument.ClosePrintPreview();
                return 1;
            }
            catch
            { return -1; }
        }
        /// <summary>
        /// ����ʱ��ȡWORD�ж�Ӧ�ֶε�����
        /// </summary>
        /// <returns></returns>
        public void WordSaveAs(object DestFile, object SourceFile, object format)
        {
            WordDoc.SaveAs(ref DestFile, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            WordDoc.SaveAs(ref SourceFile, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            //this.axFramerControl1.SaveAs(NewPath, 0);
            //return mReport;
        }
        /// <summary>
        /// ����WORD�ֶ���Ϣ�ַ���
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<WordCell> SetWordCells(string fields)
        {
            unProtectWord();
            List<WordCell> WordCells = new List<WordCell>();
            string[] Field = fields.Split('|');
            this.wcImg = new WordCell();
            for (int i = 0; i < Field.Length; i++)
            {
                string[] FieldInfo = Field[i].ToString().Split(';');
                if (FieldInfo[0].ToString() == "IMAGES")
                    this.imgCells = WordImgCell.SetWordImgCells(Field[i].ToString().Substring(7));
                else
                {
                    WordCell wc = new WordCell();
                    wc.Name = FieldInfo[0].ToString();
                    wc.TableIndex = int.Parse(FieldInfo[1]);
                    wc.RowIndex = int.Parse(FieldInfo[2]);
                    wc.ColumnIndex = int.Parse(FieldInfo[3]);
                    if (FieldInfo.Length > 4)
                    {
                        wc.PageIndex = int.Parse(FieldInfo[4]);
                        switch (wc.PageIndex)
                        {
                            case 1:
                                if (WordApp.ActiveWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
                                    WordApp.ActiveWindow.Panes[2].Close();
                                if (WordApp.ActiveWindow.View.Type == WdViewType.wdNormalView || WordApp.ActiveWindow.View.Type == WdViewType.wdOutlineView)
                                    WordApp.ActiveWindow.View.Type = WdViewType.wdPrintView;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                                WordApp.Selection.WholeStory();
                                if (strFilter2(WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text) == wc.Name)
                                    WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = "";
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                                break;
                            case 2:
                                if (strFilter2(WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text) == wc.Name)
                                    WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = "";
                                break;
                            case 3:
                                if (WordApp.ActiveWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
                                    WordApp.ActiveWindow.Panes[2].Close();
                                if (WordApp.ActiveWindow.View.Type == WdViewType.wdNormalView || WordApp.ActiveWindow.View.Type == WdViewType.wdOutlineView)
                                    WordApp.ActiveWindow.View.Type = WdViewType.wdPrintView;
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageFooter;
                                WordApp.Selection.WholeStory();
                                if (strFilter2(WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text) == wc.Name)
                                    WordApp.Selection.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = "";
                                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                                break;
                        }
                    }
                    else
                    {
                        if (strFilter2(WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text) == wc.Name)
                            WordDoc.Tables[wc.TableIndex].Rows[wc.RowIndex].Cells[wc.ColumnIndex].Range.Text = "";
                    }
                    if (wc.Name == FieldDict.IMAGE)
                        this.wcImg = wc;
                    WordCells.Add(wc);
                }
            }
            ProtectWord();
            return WordCells;
        }
        /// <summary>
        /// ��ȡWORD�ֶ���Ϣ�ַ���
        /// </summary>
        /// <returns></returns>
        public string GetWordCells()
        {
            List<WordCell> wordcells = GetField();
            string FieldInfo = "";
            for (int i = 0; i < wordcells.Count; i++)
            {
                WordCell wc = (WordCell)wordcells[i];
                FieldInfo += wc.Name + ";";
                FieldInfo += wc.TableIndex.ToString() + ";";
                FieldInfo += wc.RowIndex.ToString() + ";";
                FieldInfo += wc.ColumnIndex + ";";
                if (wc.PageIndex > 0)
                    FieldInfo += wc.PageIndex + "|";
                else
                    FieldInfo = FieldInfo.TrimEnd(';') + "|";
            }
            return FieldInfo.TrimEnd('|');
        }
        /// <summary>
        /// ȡ������WORD�ֶε�λ��
        /// </summary>
        /// <returns></returns>
        private List<WordCell> GetField()
        {
            unProtectWord();//�Ᵽ��
            List<WordCell> WordCells = new List<WordCell>();
            //if (!GetConfig.RS_IsCheckPageHF)
            if (!true)
                this.GetTablesField(WordDoc.Tables, WordCells, -1);
            else
            {
                this.GetTablesField(WordDoc.Tables, WordCells, 2);
                if (WordApp.ActiveWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
                    WordApp.ActiveWindow.Panes[2].Close();
                if (WordApp.ActiveWindow.View.Type == WdViewType.wdNormalView || WordApp.ActiveWindow.View.Type == WdViewType.wdOutlineView)
                    WordApp.ActiveWindow.View.Type = WdViewType.wdPrintView;
                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                WordApp.Selection.WholeStory();
                this.GetTablesField(WordApp.Selection.Tables, WordCells, 1);
                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageFooter;
                WordApp.Selection.WholeStory();
                this.GetTablesField(WordApp.Selection.Tables, WordCells, 3);
                WordApp.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
            }
            ProtectWord();//����
            return WordCells;
        }
        private ArrayList arNodeSigns;
        private void GetTablesField(Tables tabs, List<WordCell> WordCells, int pageIndex)
        {
            if (arNodeSigns == null)
                arNodeSigns = GetNodeFields();
            for (int i = 1; i < tabs.Count + 1; i++)
            {
                for (int j = 1; j < tabs[i].Rows.Count + 1; j++)
                {
                    for (int k = 1; k < tabs[i].Rows[j].Cells.Count + 1; k++)
                    {
                        WordCell wcell = new WordCell();
                        string FieldName = "";
                        string Text = tabs[i].Cell(j, k).Range.Text;
                        Text = Text.Replace("\r\a", "");
                        switch (Text)
                        {
                            case FieldDict.PATIENT_NAME:
                                FieldName = FieldDict.PATIENT_NAME;
                                break;
                            case FieldDict.PATIENT_ID:
                                FieldName = FieldDict.PATIENT_ID;
                                break;
                            case FieldDict.PATIENT_SEX:
                                FieldName = FieldDict.PATIENT_SEX;
                                break;
                            case FieldDict.PATIENT_AGE:
                                FieldName = FieldDict.PATIENT_AGE;
                                break;
                            case FieldDict.EXAM_NO:
                                FieldName = FieldDict.EXAM_NO;
                                break;
                            case FieldDict.EXAM_ITEMS:
                                FieldName = FieldDict.EXAM_ITEMS;
                                break;
                            case FieldDict.REQ_DEPT_NAME:
                                FieldName = FieldDict.REQ_DEPT_NAME;
                                break;
                            case FieldDict.STUDY_ID:
                                FieldName = FieldDict.STUDY_ID;
                                break;
                            case FieldDict.BED_NUM:
                                FieldName = FieldDict.BED_NUM;
                                break;
                            case FieldDict.INP_NO:
                                FieldName = FieldDict.INP_NO;
                                break;
                            case FieldDict.DEVICE:
                                FieldName = FieldDict.DEVICE;
                                break;
                            case FieldDict.EXAM_CLASS:
                                FieldName = FieldDict.EXAM_CLASS;
                                break;
                            case FieldDict.EXAM_SUB_CLASS:
                                FieldName = FieldDict.EXAM_SUB_CLASS;
                                break;
                            case FieldDict.REPORT_DATE_TIME:
                                FieldName = FieldDict.REPORT_DATE_TIME;
                                break;
                            case FieldDict.STUDY_DATE_TIME:
                                FieldName = FieldDict.STUDY_DATE_TIME;
                                break;
                            case FieldDict.REQ_DATE_TIME:
                                FieldName = FieldDict.REQ_DATE_TIME;
                                break;
                            case FieldDict.REFER_DOCTOR:
                                FieldName = FieldDict.REFER_DOCTOR;
                                break;
                            case FieldDict.PATIENT_LOCAL_ID:
                                FieldName = FieldDict.PATIENT_LOCAL_ID;
                                break;
                            case FieldDict.EXAM_ITEM:
                                FieldName = FieldDict.EXAM_ITEM;
                                break;
                            case FieldDict.PATIENT_SOURCE:
                                FieldName = FieldDict.PATIENT_SOURCE;
                                break;
                            case FieldDict.CHARGE_TYPE:
                                FieldName = FieldDict.CHARGE_TYPE;
                                break;
                            case FieldDict.TELEPHONE_NUM:
                                FieldName = FieldDict.TELEPHONE_NUM;
                                break;
                            case FieldDict.CLIN_SYMP:
                                FieldName = FieldDict.CLIN_SYMP;
                                break;
                            case FieldDict.CLIN_DIAG:
                                FieldName = FieldDict.CLIN_DIAG;
                                break;
                            case FieldDict.APPROVE_DATE_TIME:
                                FieldName = FieldDict.APPROVE_DATE_TIME;
                                break;
                            case FieldDict.IMAGE:
                                FieldName = FieldDict.IMAGE;
                                break;
                            case FieldDict.TRANSCRIBER:
                                FieldName = FieldDict.TRANSCRIBER;
                                break;
                            case FieldDict.OUT_MED_INSTITUTION:
                                FieldName = FieldDict.OUT_MED_INSTITUTION;
                                break;
                            case FieldDict.EXAM_GROUP:
                                FieldName = FieldDict.EXAM_GROUP;
                                break;
                            case FieldDict.MAILING_ADDRESS:    //ͨѶ��ַ
                                FieldName = FieldDict.MAILING_ADDRESS;
                                break;
                            //�����ֶ�
                            case FieldDict.DATE_TIME_NOW:     //��ǰʱ��
                                FieldName = FieldDict.DATE_TIME_NOW;
                                break;
                            //ģ���ֶ�
                            case FieldDict.DESCRIPTION:
                                FieldName = FieldDict.DESCRIPTION;
                                break;
                            case FieldDict.EXAM_PARA:
                                FieldName = FieldDict.EXAM_PARA;
                                break;
                            case FieldDict.IMPRESSION:
                                FieldName = FieldDict.IMPRESSION;
                                break;
                            case FieldDict.RECOMMENDATION:
                                FieldName = FieldDict.RECOMMENDATION;
                                break;
                            case FieldDict.BL_DIAG:
                                FieldName = FieldDict.BL_DIAG;
                                break;
                            case FieldDict.XB_DIAG:
                                FieldName = FieldDict.XB_DIAG;
                                break;
                            //ģ���ֶ�
                            default:
                                if (arNodeSigns.Contains(Text.Trim()))
                                {
                                    FieldName = Text.Trim();
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                        }
                        wcell.Name = FieldName;
                        wcell.TableIndex = i;
                        wcell.RowIndex = j;
                        wcell.ColumnIndex = k;
                        if (pageIndex != -1)
                            wcell.PageIndex = pageIndex;
                        WordCells.Add(wcell);
                    }
                }
            }
        }
        public ArrayList GetNodeFields()
        {
            ArrayList array = new ArrayList();
            System.Data.DataTable dt = GetNodesDt();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                array.Add(dt.Rows[i]["PRINT_FIELD"].ToString().Trim());
            }
            return array;
        }
        private System.Data.DataTable GetNodesDt()
        {
            string sql = "select * from TEMPLATE_TYPE_DICT where DEPT_CODE='" + ((MUser)frmMainForm.iUser).CLINIC_OFFICE_CODE + "'";
            System.Data.DataTable dt = new ILL.DGetSeqValue().GetDataTable(sql);
            return dt;
        }
        #region Word��Combox����
        /// <summary>
        /// ��WORD�� combox����Դ������ʼֵ
        /// </summary>
        /// <param name="oleCombName">�ؼ���</param>
        /// <param name="dt">����Դ</param>
        /// <param name="Value">��ʼֵ</param>
        private void oleComboxBind(string oleCombName, System.Data.DataTable dt, string Value)
        {
            object oleControlType = FindControl(oleCombName, WordDoc);
            if (oleControlType != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object[] param = new object[1] { dt.Rows[i][0].ToString() };
                    oleControlType.GetType().InvokeMember("AddItem", System.Reflection.BindingFlags.InvokeMethod, null, oleControlType, param);
                }
                oleControlType.GetType().InvokeMember("Value", System.Reflection.BindingFlags.SetProperty, null, oleControlType, new object[] { Value });
            }
        }
        /// <summary>
        /// ��ȡWORD��combox��ֵ
        /// </summary>
        /// <param name="oleCombName">�ؼ���</param>
        /// <returns></returns>
        private string GetoleCombValue(string oleCombName)
        {
            object oleControlType = FindControl(oleCombName, WordDoc);
            if (oleControlType != null)
                return (string)oleControlType.GetType().InvokeMember("Value", System.Reflection.BindingFlags.GetProperty, null, oleControlType, null);
            else
                return "";
        }
        /// <summary>
        /// ���ݿؼ�����ȡWORD�еĿؼ�
        /// </summary>
        /// <param name="name"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        private static object FindControl(string name, _Document document)
        {
            try
            {
                foreach (InlineShape shape in document.InlineShapes)
                {
                    if (shape.Type == WdInlineShapeType.wdInlineShapeOLEControlObject)
                    {
                        object oleControl = shape.OLEFormat.Object;
                        Type oleControlType = oleControl.GetType();
                        string oleControlName = (string)oleControlType.InvokeMember("Name",
                            System.Reflection.BindingFlags.GetProperty, null, oleControl, null);
                        if (String.Compare(oleControlName, name, true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                            return oleControl;
                    }
                }

                foreach (Microsoft.Office.Interop.Word.Shape shape in document.Shapes)
                {
                    if (shape.Type == MsoShapeType.msoOLEControlObject)
                    {
                        object oleControl = shape.OLEFormat.Object;
                        Type oleControlType = oleControl.GetType();
                        string oleControlName = (string)oleControlType.InvokeMember("Name",
                            System.Reflection.BindingFlags.GetProperty, null, oleControl, null);
                        if (String.Compare(oleControlName, name, true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                            return oleControl;
                    }
                }
            }
            catch
            {
                return null;// Returns null if the control is not found.
            }
            return null;
        }
        #endregion Word��Combox����

        #region Word�в���ͼƬ����
        /// <summary>
        /// ��WORD����ͼƬ
        /// </summary>
        public void InsertImg(string ImgPath)
        {
            unProtectWord();
            AddImg(ImgPath, GetConfig.RS_ImgWidth, GetConfig.RS_ImgHeight);
            ProtectWord();
        }
        /// <summary>
        /// ��WORD����ͼƬ�붨λͼ
        /// </summary>
        public void InsertImgWithLocMap(string ImgPath, string LocMapPath)
        {
            unProtectWord();
            this.AddImgWithLocMap(ImgPath, GetConfig.RS_ImgWidth, GetConfig.RS_ImgHeight, LocMapPath, GetConfig.RS_LocMapWidth, GetConfig.RS_LocMapHeight);
            ProtectWord();
        }

        /// <summary>
        /// �����ļ�·��ɾ��WORD��ƥ���ͼƬ
        /// </summary>
        public int DelImg(string ImgName)
        {
            unProtectWord();
            ImgName = ImgName.Substring(ImgName.LastIndexOf("\\") + 1).Replace("Mark", "");
            int i = -1;
            WordImgCell wic = FindImgCell(ImgName, ref i);
            if (wic != null)
                DeleteImg(wic, i);
            ProtectWord();
            return 0;
        }

        /// <summary>
        /// �����ļ�·��ɾ��WORD��ƥ���ͼƬ�붨λͼ
        /// </summary>
        public int DelImgWithLocMap(string ImgName, string LocMapPath)
        {
            unProtectWord();
            ImgName = ImgName.Substring(ImgName.LastIndexOf("\\") + 1).Replace("Mark", "");
            string LocMapName = LocMapPath.Substring(LocMapPath.LastIndexOf("\\") + 1);
            int i = -1;
            WordImgCell wic = FindImgCell(ImgName, ref i);
            if (wic != null)
                this.DeleteImgWithLocMap(wic, i, GetConfig.RS_ImgWidth, GetConfig.RS_ImgHeight, GetConfig.RS_LocMapWidth, GetConfig.RS_LocMapHeight);
            ProtectWord();
            return 0;
        }

        public int PasteImgWithLocMap(string ImgPath, string LocMapPath)
        {
            unProtectWord();
            string ImgName = ImgPath.Substring(ImgPath.LastIndexOf("\\") + 1).Replace("Mark", "");
            string LocMapName = LocMapPath.Substring(LocMapPath.LastIndexOf("\\") + 1);
            int i = -1;
            WordImgCell wic = FindImgCell(ImgName, ref i);
            if (wic != null)
                this.PasteImgLocMap(wic, i, ImgPath, GetConfig.RS_ImgWidth, GetConfig.RS_ImgHeight, LocMapPath, GetConfig.RS_LocMapWidth, GetConfig.RS_LocMapHeight);
            ProtectWord();
            return 0;
        }

        private WordImgCell FindImgCell(string ImgName, ref int i)
        {
            for (i = 0; i < this.imgCells.Count; i++)
            {
                if (imgCells[i].ImgName == ImgName)
                    return imgCells[i];
            }
            return null;
        }

        #region ����ͼƬ

        /// <summary>
        /// ���ͼ�����
        /// </summary>
        private void AddImg(string ImgPath, int ImgWidth, int ImgHeight)
        {
            if (this.wcImg.Name == null)
                return;
            Table ImgTable = WordDoc.Tables[wcImg.TableIndex];
            string ImgName = ImgPath.Substring(ImgPath.LastIndexOf("\\") + 1).Replace("Mark", "");
            if (wcImg.RowIndex != 1 || wcImg.ColumnIndex != 1)
            {
                object unit = WdUnits.wdCharacter;
                object count = 1;
                ImgTable.Cell(wcImg.RowIndex, wcImg.ColumnIndex).Select();
                this.AddImgToCell(ImgPath, ImgWidth, ImgHeight);
                this.imgCells = new List<WordImgCell>();
                WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, wcImg.RowIndex, wcImg.ColumnIndex);
                this.imgCells.Add(wic);
                //ImgTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
                return;
            }
            if (ImgTable != null)
            {
                ImgTable.Select();
                if (imgCells == null || imgCells.Count == 0)//��û����ͼƬ
                {
                    object unit = WdUnits.wdCharacter;
                    object count = 1;
                    WordApp.Selection.MoveLeft(ref unit, ref count, ref missing);
                    this.AddImgToCell(ImgPath, ImgWidth, ImgHeight);
                    this.imgCells = new List<WordImgCell>();
                    WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 1, 1);
                    this.imgCells.Add(wic);
                }
                else
                {
                    if (this.imgCells.Count < 3)//��û���볬��3��ͼƬ
                    {
                        int column = 1 + this.imgCells.Count;
                        this.AddImgCellHorizontal(1, column, ImgTable);//����ˮƽͼƬ��Ԫ��
                        this.AddImgToCell(ImgPath, ImgWidth, ImgHeight);
                        WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 1, column);
                        this.imgCells.Add(wic);
                    }
                    else
                    {
                        if (this.imgCells.Count == 3)//�Ѳ�����3��ͼƬ��Ҫ�����4��ʱ
                        {
                            this.AddFouthImg(ImgTable);
                            this.AddImgToCell(ImgPath, ImgWidth, ImgHeight);
                            WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 2, 2);
                            this.imgCells.Add(wic);
                        }
                        else
                        {
                            if (this.imgCells.Count == 4)//�Ѳ�����4��ͼƬ��Ҫ�����5��ʱ
                            {
                                this.AddFifthImg(ImgTable);
                                this.AddImgToCell(ImgPath, ImgWidth, ImgHeight);
                                WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 2, 2);
                                this.imgCells.Add(wic);
                            }
                            else
                            {
                                if (this.imgCells.Count % 3 > 0)//��û���볬��3�ı�����ͼƬ
                                {
                                    int column = 1 + this.imgCells.Count % 3;
                                    int row = ImgTable.Rows.Count;
                                    this.AddImgCellHorizontal(row, column, ImgTable);//����ˮƽͼƬ��Ԫ��
                                    this.AddImgToCell(ImgPath, ImgWidth, ImgHeight);
                                    WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, row, column);
                                    this.imgCells.Add(wic);
                                }
                                else
                                {
                                    int row = ImgTable.Rows.Count + 1;
                                    this.AddImgCellVertical(row, 1, ImgTable);//���촹ֱͼƬ��Ԫ��
                                    this.AddImgToCell(ImgPath, ImgWidth, ImgHeight);
                                    WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, row, 1);
                                    this.imgCells.Add(wic);
                                }
                            }
                        }
                    }
                }
                ImgTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
            }
        }

        /// <summary>
        /// ���ͼƬ����Ԫ����
        /// </summary>
        private void AddImgToCell(string ImgPath, int ImgWidth, int ImgHeigth)
        {
            object oMissed = WordApp.Application.Selection.Range;
            object oLinkToFile = false;     //ȱʡ   
            object oSaveWithDocument = true;//ȱʡ 
            InlineShape shape = WordApp.Selection.InlineShapes.AddPicture(ImgPath, ref oLinkToFile, ref oSaveWithDocument, ref missing);
            shape.Width = ImgWidth;
            shape.Height = ImgHeigth;
        }

        /// <summary>
        /// ��ˮƽ��������µ�ͼ��Ԫ��
        /// </summary>
        private void AddImgCellHorizontal(int RowIndex, int ColumnIndex, Table ImgTable)
        {
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object insertShiftCells = WdInsertCells.wdInsertCellsShiftRight;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.MoveLeft(ref unit, ref count, ref missing);
            WordApp.Selection.InsertCells(ref insertShiftCells);
            ImgTable.Cell(RowIndex, ColumnIndex).Select();
        }

        /// <summary>
        /// �ڴ�ֱ��������µ�ͼ��Ԫ��
        /// </summary>
        private void AddImgCellVertical(int RowIndex, int ColumnIndex, Table ImgTable)
        {
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object newRows = 1;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.InsertRowsBelow(ref newRows);
            ImgTable.Cell(RowIndex, ColumnIndex + 1).Select();
            object count2 = ImgTable.Columns.Count - ColumnIndex - 1;
            WordApp.Selection.MoveRight(ref unit, ref count2, ref extend);
            WordApp.Selection.Cells.Delete(ref shiftCells);
            ImgTable.Cell(RowIndex, ColumnIndex).Select();
        }

        private void AddFouthImg(Table ImgTable)
        {
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object newRows = 1;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.InsertRowsBelow(ref newRows);
            ImgTable.Cell(1, 3).Select();
            WordApp.Selection.Cut();
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.Paste();
            ImgTable.Cell(1, 3).Delete(ref shiftCells);
            ImgTable.Cell(2, 3).Delete(ref shiftCells);
            ImgTable.Cell(2, 2).Select();
            imgCells[2].RowIndex = 2;
            imgCells[2].ColumnIndex = 1;
        }

        private void AddFifthImg(Table ImgTable)
        {
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.MoveLeft(ref unit, ref count, ref missing);
            WordApp.Selection.InsertColumnsRight();
            ImgTable.Cell(2, 3).Delete(ref shiftCells);
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.Cut();
            ImgTable.Cell(1, 3).Select();
            WordApp.Selection.Paste();
            ImgTable.Cell(2, 2).Select();
            WordApp.Selection.Cut();
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.Paste();
            ImgTable.Cell(2, 2).Select();
            imgCells[2].RowIndex = 1;
            imgCells[2].ColumnIndex = 3;
            imgCells[3].ColumnIndex = 1;
        }

        /// <summary>
        /// ��ȡRowIndex�����д��ڵ�����
        /// </summary>
        private int GetColumns(Table ImgTable, int RowIndex)
        {
            if (RowIndex < ImgTable.Rows.Count)
                return ImgTable.Columns.Count;
            else
                return this.imgCells.Count - (RowIndex - 1) * ImgTable.Columns.Count;
        }

        /// <summary>
        /// ɾ��ͼ��
        /// </summary>
        private void DeleteImg(WordImgCell wic, int i)
        {
            int j = -1;
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object missing = Type.Missing;
            object newRows = 2;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            if (this.wcImg.Name == null)
                return;
            Table ImgTable = WordDoc.Tables[this.wcImg.TableIndex];
            if (wcImg.RowIndex != 1 || wcImg.ColumnIndex != 1)
            {
                ImgTable.Cell(wcImg.RowIndex, wcImg.ColumnIndex).Select();
                WordApp.Selection.TypeText(" ");
                WordApp.Selection.TypeBackspace();
                return;
            }
            for (int k = i; k < imgCells.Count; k++)//���ҵ���WordImgCell��ʼ���Ѻ�һ�������ݼ��е������λ���ϣ����޸���Ӧ������ֵ
            {
                WordImgCell wics = imgCells[k];
                int row = wics.RowIndex, column = wics.ColumnIndex;
                if (column + 1 <= this.GetColumns(ImgTable, row))//��ˮƽ��ͼƬ��Ԫ��
                {
                    ImgTable.Cell(row, column + 1).Select();
                    WordApp.Selection.Cut();
                    ImgTable.Cell(row, column).Select();
                    WordApp.Selection.Paste();
                    imgCells[k] = imgCells[k + 1].Copy();//����һ��WordImgCell��ֵ������һ��
                    imgCells[k].ColumnIndex -= 1;
                }
                else
                {
                    if (row + 1 <= ImgTable.Rows.Count)//����ֱ��ͼƬ��Ԫ��
                    {
                        ImgTable.Cell(row + 1, 1).Select();//ѡ����һ�еĵ�һ��
                        WordApp.Selection.Cut();
                        ImgTable.Cell(row, column).Select();
                        WordApp.Selection.Paste();
                        imgCells[k] = imgCells[k + 1].Copy();
                        imgCells[k].RowIndex = row;
                        imgCells[k].ColumnIndex = column;
                    }
                    else//�������һ����Ԫ��
                    {
                        ImgTable.Cell(row, column).Select();
                        if (row == 1 && column == 1)//���ǵ�һ����Ԫ��
                        {
                            WordApp.Selection.TypeText(" ");
                            WordApp.Selection.TypeBackspace();
                        }
                        else
                            WordApp.Selection.Cells.Delete(ref shiftCells);//��ɾ���õ�Ԫ��
                        this.imgCells.RemoveAt(k);
                    }
                }
            }
            if (this.imgCells.Count == 4)
                this.AdjustImgAtFour(ImgTable);
            if (this.imgCells.Count == 3)
                this.AdjustImgAtThree(ImgTable);
        }

        private void AdjustImgAtFour(Table ImgTable)
        {
            ImgTable.Cell(2, 1).Select();
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object insertShiftCells = WdInsertCells.wdInsertCellsShiftRight;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.InsertCells(ref insertShiftCells);
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.Cut();
            ImgTable.Cell(2, 2).Select();
            WordApp.Selection.Paste();
            ImgTable.Cell(1, 3).Select();
            WordApp.Selection.Cut();
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.Paste();
            ImgTable.Cell(1, 3).Delete(ref shiftCells);
            this.imgCells[2].RowIndex = 2;
            this.imgCells[2].ColumnIndex = 1;
            this.imgCells[3].ColumnIndex = 2;
            ImgTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
        }

        private void AdjustImgAtThree(Table ImgTable)
        {
            ImgTable.Cell(1, 2).Select();
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object insertShiftCells = WdInsertCells.wdInsertCellsShiftRight;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.InsertCells(ref insertShiftCells);
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.Cut();
            ImgTable.Cell(1, 3).Select();
            WordApp.Selection.Paste();
            ImgTable.Cell(2, 1).Delete(ref shiftCells);
            this.imgCells[2].RowIndex = 1;
            this.imgCells[2].ColumnIndex = 3;
            ImgTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
        }

        #endregion

        #region ����ͼƬ�붨λͼ������
        /// <summary>
        /// ���ͼ���붨λͼ����
        /// </summary>
        private void AddImgWithLocMap(string ImgPath, int ImgWidth, int ImgHeight, string LocMapPath, int LocMapWidth, int LocMapHeight)
        {
            if (this.wcImg.Name == null)
                return;
            Table ImgTable = WordDoc.Tables[wcImg.TableIndex];
            string ImgName = ImgPath.Substring(ImgPath.LastIndexOf("\\") + 1).Replace("Mark", "");
            string LocMapName = LocMapPath.Substring(LocMapPath.LastIndexOf("\\") + 1);
            if (ImgTable != null)
            {
                ImgTable.Select();
                if (ImgTable.Columns.Count == 1)
                {
                    this.SetFirstImgCell(ImgTable, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                    this.AddImgLocMapToCell(ImgPath, LocMapPath, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                    this.imgCells = new List<WordImgCell>();
                    WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 1, 1, LocMapName, 1, 2);
                    this.imgCells.Add(wic);
                }
                else
                {
                    if (this.imgCells.Count < 3)
                    {
                        int column = 1 + 2 * this.imgCells.Count;
                        this.AddImgLocMapCellsHorizontal(1, column, ImgTable, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                        this.AddImgLocMapToCell(ImgPath, LocMapPath, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                        WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 1, column, LocMapName, 1, column + 1);
                        this.imgCells.Add(wic);
                    }
                    else
                    {
                        if (this.imgCells.Count == 3)//�Ѳ�����3��ͼƬ��Ҫ�����4��ʱ
                        {
                            this.AddFouthImgLocMapCells(ImgTable, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                            this.AddImgLocMapToCell(ImgPath, LocMapPath, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                            WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 2, 3, LocMapName, 2, 4);
                            this.imgCells.Add(wic);
                        }
                        else
                        {
                            if (this.imgCells.Count == 4)//�Ѳ�����4��ͼƬ��Ҫ�����5��ʱ
                            {
                                this.AddFifthImgLocMapCells(ImgTable, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                                this.AddImgLocMapToCell(ImgPath, LocMapPath, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                                WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, 2, 3, LocMapName, 2, 4);
                                this.imgCells.Add(wic);
                            }
                            else
                            {
                                if (this.imgCells.Count % 3 > 0)
                                {
                                    int column = 1 + 2 * (this.imgCells.Count % 3);
                                    int row = ImgTable.Rows.Count;
                                    this.AddImgLocMapCellsHorizontal(row, column, ImgTable, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                                    this.AddImgLocMapToCell(ImgPath, LocMapPath, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                                    WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, row, column, LocMapName, row, column + 1);
                                    this.imgCells.Add(wic);
                                }
                                else
                                {
                                    int row = ImgTable.Rows.Count + 1;
                                    this.AddImgLocMapCellsVertical(row, ImgTable, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                                    this.AddImgLocMapToCell(ImgPath, LocMapPath, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
                                    WordImgCell wic = new WordImgCell(ImgName, ImgWidth, ImgHeight, wcImg.TableIndex, row, 1, LocMapName, row, 2);
                                    this.imgCells.Add(wic);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���ñ���е�һ�鵥Ԫ���ʽ
        /// </summary>
        private void SetFirstImgCell(Table ImgTable, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            object unit = WdUnits.wdCharacter;
            object count = 2;
            WordApp.Selection.InsertColumnsRight();
            WordApp.Selection.MoveLeft(ref unit, ref count, ref missing);
            ImgTable.Cell(1, 1).Width = ImgWidth;
            ImgTable.Cell(1, 1).Height = ImgHeigth;
            ImgTable.Cell(1, 2).Width = LocMapWidth;
            ImgTable.Cell(1, 2).Height = LocMapHeight;
        }

        /// <summary>
        /// ���ͼƬ�붨λͼ����Ԫ����
        /// </summary>
        private void AddImgLocMapToCell(string ImgPath, string LocMapPath, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object extend = WdMovementType.wdExtend;
            object oMissed = WordApp.Application.Selection.Range;
            object oLinkToFile = false;     //ȱʡ   
            object oSaveWithDocument = true;//ȱʡ 
            InlineShape shape = WordApp.Selection.InlineShapes.AddPicture(ImgPath, ref oLinkToFile, ref oSaveWithDocument, ref missing);
            shape.Width = ImgWidth;
            shape.Height = ImgHeigth;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            if (LocMapPath != "")
            {
                InlineShape shape2 = WordApp.Selection.InlineShapes.AddPicture(LocMapPath, ref oLinkToFile, ref oSaveWithDocument, ref missing);
                shape2.Width = LocMapWidth;
                shape2.Height = LocMapHeight;
            }
        }

        /// <summary>
        /// ��ˮƽ��������µ�ͼ���붨λͼ��Ԫ��
        /// </summary>
        private void AddImgLocMapCellsHorizontal(int RowIndex, int ColumnIndex, Table ImgTable, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            object shiftCells2 = WdInsertCells.wdInsertCellsShiftRight;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.MoveLeft(ref unit, ref count, ref missing);
            WordApp.Selection.InsertCells(ref shiftCells2);
            WordApp.Selection.InsertCells(ref shiftCells2);
            ImgTable.Cell(RowIndex, ColumnIndex).Width = ImgWidth;
            ImgTable.Cell(RowIndex, ColumnIndex).Height = ImgHeigth;
            ImgTable.Cell(RowIndex, ColumnIndex + 1).Width = LocMapWidth;
            ImgTable.Cell(RowIndex, ColumnIndex + 1).Height = LocMapHeight;
        }

        /// <summary>
        /// �ڴ�ֱ��������µ�ͼ���붨λͼ��Ԫ��
        /// </summary>
        private void AddImgLocMapCellsVertical(int RowIndex, Table ImgTable, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object newRows = 1;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.InsertRowsBelow(ref newRows);
            ImgTable.Cell(RowIndex, 3).Select();
            object count2 = ImgTable.Columns.Count - 3;
            WordApp.Selection.MoveRight(ref unit, ref count2, ref extend);
            WordApp.Selection.Cells.Delete(ref shiftCells);

            ImgTable.Cell(RowIndex, 1).Width = ImgWidth;
            ImgTable.Cell(RowIndex, 1).Height = ImgHeigth;
            ImgTable.Cell(RowIndex, 2).Width = LocMapWidth;
            ImgTable.Cell(RowIndex, 2).Height = LocMapHeight;
            ImgTable.Cell(RowIndex, 1).Select();
        }

        private void AddFouthImgLocMapCells(Table ImgTable, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object newRows = 1;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.InsertRowsBelow(ref newRows);

            ImgTable.Cell(1, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Copy();
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Paste();

            ImgTable.Cell(1, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Cells.Delete(ref shiftCells);

            ImgTable.Cell(2, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Cells.Delete(ref shiftCells);

            ImgTable.Cell(2, 3).Width = ImgWidth;
            ImgTable.Cell(2, 3).Height = ImgHeigth;
            ImgTable.Cell(2, 4).Width = LocMapWidth;
            ImgTable.Cell(2, 4).Height = LocMapHeight;

            ImgTable.Cell(2, 3).Select();
            imgCells[2].RowIndex = 2;
            imgCells[2].ColumnIndex = 1;
            imgCells[2].LocMapRowIndex = 2;
            imgCells[2].LocMapColumnIndex = 2;
        }

        private void AddFifthImgLocMapCells(Table ImgTable, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.MoveLeft(ref unit, ref count, ref missing);
            WordApp.Selection.InsertColumnsRight();
            WordApp.Selection.InsertColumnsRight();

            ImgTable.Cell(2, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Cells.Delete(ref shiftCells);

            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Copy();
            ImgTable.Cell(1, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Paste();

            ImgTable.Cell(2, 3).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Copy();
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Paste();

            ImgTable.Cell(1, 5).Width = ImgWidth;
            ImgTable.Cell(1, 5).Height = ImgHeigth;
            ImgTable.Cell(1, 6).Width = LocMapWidth;
            ImgTable.Cell(1, 6).Height = LocMapHeight;

            ImgTable.Cell(2, 3).Select();
            WordApp.Selection.TypeText(" ");
            WordApp.Selection.TypeBackspace();
            ImgTable.Cell(2, 4).Select();
            WordApp.Selection.TypeText(" ");
            WordApp.Selection.TypeBackspace();

            ImgTable.Cell(2, 3).Select();
            imgCells[2].RowIndex = 1;
            imgCells[2].ColumnIndex = 5;
            imgCells[2].LocMapRowIndex = 1;
            imgCells[2].LocMapColumnIndex = 6;
            imgCells[3].ColumnIndex = 1;
            imgCells[3].LocMapColumnIndex = 2;
        }

        /// <summary>
        /// ��ȡRowIndex�����д��ڵ�����
        /// </summary>
        private int GetColumns2(Table ImgTable, int RowIndex)
        {
            if (RowIndex < ImgTable.Rows.Count)
                return ImgTable.Columns.Count;
            else
                return this.imgCells.Count * 2 - (RowIndex - 1) * ImgTable.Columns.Count;
        }

        /// <summary>
        /// ɾ��ͼ���붨λͼ
        /// </summary>
        private void DeleteImgWithLocMap(WordImgCell wic, int i, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            int j = -1;
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object missing = Type.Missing;
            object newRows = 2;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            if (this.wcImg.Name == null)
                return;
            Table ImgTable = WordDoc.Tables[this.wcImg.TableIndex];
            for (int k = i; k < imgCells.Count; k++)//���ҵ���WordImgCell��ʼ���Ѻ�һ�������ݼ��е������λ���ϣ����޸���Ӧ������ֵ
            {
                WordImgCell wics = imgCells[k];
                int row = wics.RowIndex, column = wics.ColumnIndex;
                if (wics.ColumnIndex + 2 < this.GetColumns2(ImgTable, row))//��ˮƽ��ͼƬ��Ԫ��
                {
                    ImgTable.Cell(row, column + 2).Select();
                    WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
                    WordApp.Selection.Copy();
                    ImgTable.Cell(row, column).Select();
                    WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
                    WordApp.Selection.Paste();

                    imgCells[k] = imgCells[k + 1].Copy();//����һ��WordImgCell��ֵ������һ��
                    imgCells[k].ColumnIndex -= 2;
                    imgCells[k].LocMapColumnIndex -= 2;
                }
                else
                {
                    if (wics.RowIndex + 1 <= ImgTable.Rows.Count)//����ֱ��ͼƬ��Ԫ��
                    {
                        ImgTable.Cell(row + 1, 1).Select();//ѡ����һ�еĵ�һ��
                        WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
                        WordApp.Selection.Copy();
                        ImgTable.Cell(row, column).Select();
                        WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
                        WordApp.Selection.Paste();

                        imgCells[k] = imgCells[k + 1].Copy();
                        imgCells[k].RowIndex = row;
                        imgCells[k].ColumnIndex = column;
                        imgCells[k].LocMapRowIndex = row;
                        imgCells[k].LocMapColumnIndex = column + 1;
                    }
                    else//�������һ����Ԫ��
                    {
                        ImgTable.Cell(row, column).Select();
                        WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
                        //WordApp.Selection.MoveDown(ref unit2, ref count, ref extend);
                        if (row == 1 && column == 1)//���ǵ�һ����Ԫ��
                        {
                            WordApp.Selection.Cells.Merge();
                            WordApp.Selection.TypeText(" ");
                            WordApp.Selection.TypeBackspace();
                            ImgTable.Cell(1, 1).Height = 10;
                        }
                        else
                            WordApp.Selection.Cells.Delete(ref shiftCells);//��ɾ���õ�Ԫ��
                        this.imgCells.RemoveAt(k);
                    }
                }
            }
            if (this.imgCells.Count == 4)
                this.AdjustImgLocMapCellsAtFour(ImgTable, ImgWidth, ImgHeigth, LocMapWidth, LocMapHeight);
            if (this.imgCells.Count == 3)
                this.AdjustImgLocMapCellsAtThree(ImgTable, ImgWidth, ImgHeigth, LocMapWidth, LocMapHeight);
        }


        private void AdjustImgLocMapCellsAtFour(Table ImgTable, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            ImgTable.Cell(2, 2).Select();
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object insertShiftCells = WdInsertCells.wdInsertCellsShiftRight;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            object shiftCells2 = WdInsertCells.wdInsertCellsShiftRight;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.InsertCells(ref shiftCells2);
            WordApp.Selection.InsertCells(ref shiftCells2);

            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Copy();
            ImgTable.Cell(2, 3).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Paste();

            ImgTable.Cell(1, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Copy();
            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Paste();

            ImgTable.Cell(1, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Cells.Delete(ref shiftCells);





            this.imgCells[2].RowIndex = 2;
            this.imgCells[2].ColumnIndex = 1;
            this.imgCells[2].LocMapRowIndex = 2;
            this.imgCells[2].LocMapColumnIndex = 2;
            this.imgCells[3].ColumnIndex = 3;
            this.imgCells[3].LocMapColumnIndex = 4;

            //ImgTable.Cell(2, 3).Width = ImgWidth;
            //ImgTable.Cell(2, 3).Height = ImgHeigth;
            //ImgTable.Cell(2, 4).Width = LocMapWidth;
            //ImgTable.Cell(2, 4).Height = LocMapHeight;
            ImgTable.Cell(1, 3).Width = ImgWidth;
            ImgTable.Cell(1, 3).Height = ImgHeigth;
            ImgTable.Cell(1, 4).Width = LocMapWidth;
            ImgTable.Cell(1, 4).Height = LocMapHeight;

            ImgTable.Cell(2, 3).Width = ImgTable.Cell(1, 3).Width;
            ImgTable.Cell(2, 3).Height = ImgTable.Cell(1, 3).Height;
            ImgTable.Cell(2, 4).Width = ImgTable.Cell(1, 4).Width;
            ImgTable.Cell(2, 4).Height = ImgTable.Cell(1, 4).Height;

        }

        private void AdjustImgLocMapCellsAtThree(Table ImgTable, int ImgWidth, int ImgHeigth, int LocMapWidth, int LocMapHeight)
        {
            ImgTable.Cell(1, 4).Select();
            object unit = WdUnits.wdCharacter;
            object count = 1;
            object unit2 = WdUnits.wdLine;
            object extend = WdMovementType.wdExtend;
            object insertShiftCells = WdInsertCells.wdInsertCellsShiftRight;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            object shiftCells2 = WdInsertCells.wdInsertCellsShiftRight;
            WordApp.Selection.MoveRight(ref unit, ref count, ref missing);
            WordApp.Selection.InsertCells(ref shiftCells2);
            WordApp.Selection.InsertCells(ref shiftCells2);

            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Copy();
            ImgTable.Cell(1, 5).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Paste();

            ImgTable.Cell(2, 1).Select();
            WordApp.Selection.MoveRight(ref unit, ref count, ref extend);
            WordApp.Selection.Cells.Delete(ref shiftCells);

            ImgTable.Cell(1, 5).Width = ImgWidth;
            ImgTable.Cell(1, 5).Height = ImgHeigth;
            ImgTable.Cell(1, 6).Width = LocMapWidth;
            ImgTable.Cell(1, 6).Height = LocMapHeight;

            this.imgCells[2].RowIndex = 1;
            this.imgCells[2].ColumnIndex = 5;
            this.imgCells[2].LocMapRowIndex = 1;
            this.imgCells[2].LocMapColumnIndex = 6;
        }

        private void PasteImgLocMap(WordImgCell wic, int i, string ImgPath, int ImgWidth, int ImgHeight, string LocMapPath, int LocMapWidth, int LocMapHeight)
        {
            int j = -1;
            object unit = WdUnits.wdCharacter;
            object unit2 = WdUnits.wdLine;
            object count = 1;
            object missing = Type.Missing;
            object newRows = 2;
            object extend = WdMovementType.wdExtend;
            object shiftCells = WdDeleteCells.wdDeleteCellsShiftLeft;
            if (this.wcImg.Name == null)
                return;
            Table ImgTable = WordDoc.Tables[this.wcImg.TableIndex];
            ImgTable.Cell(wic.RowIndex, wic.ColumnIndex).Select();
            WordApp.Selection.TypeText(" ");
            WordApp.Selection.TypeBackspace();
            ImgTable.Cell(wic.LocMapRowIndex, wic.LocMapColumnIndex).Select();
            WordApp.Selection.TypeText(" ");
            WordApp.Selection.TypeBackspace();
            ImgTable.Cell(wic.RowIndex, wic.ColumnIndex).Select();
            AddImgLocMapToCell(ImgPath, LocMapPath, ImgWidth, ImgHeight, LocMapWidth, LocMapHeight);
        }

        #endregion

        #endregion
    }
}