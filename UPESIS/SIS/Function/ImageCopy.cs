using ILL;
using SIS_BLL;
using SIS_Function;
using SIS_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SIS
{
    /// <summary>
    /// ͼƬ������
    /// </summary>
    public class ImageCopy
    {
        private FileTransfer fileTranfer = null;
        private MWorkList mWorklist = new MWorkList();
        private Hashtable htImages = new Hashtable();
        private BImage Bimage = new BImage();
        private List<ImgObj> arrayImg = new List<ImgObj>();

        private BReport bReport = new BReport();
        private BWorkList bWorkList = new BWorkList();
        private BPrintTemplateDict bPrint = new BPrintTemplateDict();
        private MPrintTemplateDict mPrint = new MPrintTemplateDict();

        private FileOperator FileOp = new FileOperator();

        public ImageCopy()
        {
            fileTranfer = new FileTransfer(ILL.GetConfig.ServerIp, ILL.GetConfig.ServerPort);//�ļ�������
        }

        /// <summary>
        /// ��ReportStatus״̬����ͼ��
        /// </summary>
        public List<ImgObj> LoadImages(MWorkList Mworklist, string saveDir)
        {
            arrayImg = new List<ImgObj>();
            this.mWorklist = Mworklist;
            DownLoadPicture(saveDir);
            return arrayImg;
        }

        /// <summary>
        /// ���ر���ͼƬ
        /// </summary>
        /// <param name="saveDir"></param>
        //private void LoadLocalImage(string saveDir)
        //{
        //    string path = GetConfig.TempPath + "\\" + Convert.ToDateTime(mWorklist.REQ_DATE_TIME).ToString("yyyyMMdd") + "\\" + mWorklist.EXAM_ACCESSION_NUM;
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);
        //    string[] files = Directory.GetFiles(path, "*.jpg");
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        string temppath = saveDir + "\\" + files[i].Substring(files[i].LastIndexOf("\\") + 1);
        //        File.Copy(files[i].ToString(), temppath, true);
        //        ImgObj imgObj = new ImgObj(temppath, false, null);
        //        arrayImg.Add(imgObj);
        //    }
        //}

        /// <summary>
        /// ���ر��μ���ͼƬ
        /// </summary>
        /// <returns>����ֵ0:���سɹ���-1����ʧ��</returns>
        private int DownLoadPicture(string saveDir)
        {
            try
            {

                string Message = "", Message2 = "", Serverpath = "", temppath = "", MarkPath = "";
                DataTable dt = Bimage.GetList("1=1 and EXAM_ACCESSION_NUM='" + mWorklist.EXAM_ACCESSION_NUM + "'order by IS_PRINT DESC");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fileTranfer.ConnServer();//2010-03-17�޸�
                    Serverpath = dt.Rows[i]["IMAGE_PATH"].ToString();
                    temppath = saveDir.TrimEnd('\\') + "\\" + Serverpath.Substring(Serverpath.LastIndexOf("\\") + 1);
                    switch (fileTranfer.FileDown(Serverpath, temppath))
                    {
                        case 1:
                            MImage Mimg = (MImage)Bimage.GetModel(dt.Rows[i]);
                            ImgObj imgObj = new ImgObj(temppath, Convert.ToBoolean(Mimg.IS_PRINT), Mimg);
                            arrayImg.Add(imgObj);
                            break;
                        case -1:
                            Message2 += Serverpath + ",";
                            break;
                        case -2:
                            Message += Serverpath + ",";
                            break;
                        default:
                            break;
                    }
                    if (dt.Rows[i]["MARK_IMAGE_PATH"].ToString() != "")
                    {
                        MarkPath = dt.Rows[i]["MARK_IMAGE_PATH"].ToString();
                        temppath = saveDir + "\\" + MarkPath.Substring(MarkPath.LastIndexOf("/") + 1);
                        switch (fileTranfer.FileDown(MarkPath, temppath))//���ش�����ͼ��
                        {
                            case 1:
                                arrayImg[arrayImg.Count - 1].MarkImgPath = temppath;
                                arrayImg[arrayImg.Count - 1].MarkInf = dt.Rows[i]["MARK_INF"].ToString();//��¼ͼ������Ϣ
                                break;
                            case -1:
                                Message2 += MarkPath + ",";
                                break;
                            case -2:
                                Message += MarkPath + ",";
                                break;
                            default:
                                break;
                        }
                    }
                    if (GetConfig.IsAddLocMap)
                        this.DownLoadLocMap(saveDir, dt.Rows[i]["IMAGE_ID"].ToString(), arrayImg.Count - 1);//���ض�λͼ
                }
                if (Message != "")
                    Message = "����" + Message + "�ļ�ʧ�ܣ�";
                if (Message2 != "")
                    Message += "������ͼƬ��" + Message2 + "�����ڣ�";
                if (Message != "")
                    MessageBox.Show(Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            catch
            {
                //MessageBox.Show("����ͼ��ʧ��");
                return -1;
            }
        }

        /// <summary>
        /// ���ض�λͼƬ
        /// </summary>
        /// <param name="saveDir"></param>
        /// <param name="MapId"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int DownLoadLocMap(string saveDir, string MapId, int index)
        {
            BLocationMap bLocMap = new BLocationMap();
            try
            {
                MLocationMap mLocMap = (MLocationMap)bLocMap.GetModel(MapId);
                if (mLocMap != null)
                {
                    string Serverpath = mLocMap.MAP_PATH;
                    string temppath = saveDir + "\\" + Serverpath.Substring(Serverpath.LastIndexOf("/") + 1);
                    if (fileTranfer.FileDown(Serverpath, temppath) == 1)
                    {
                        arrayImg[index].Inf = mLocMap.MAP_EXPLAIN;
                        arrayImg[index].LocMapPath = temppath;
                        arrayImg[index].MLocationMap = mLocMap;
                    }
                    else
                    {
                        MessageBoxEx.Show("����" + Serverpath + "�ļ�ʧ�ܣ�");
                        return -1;//��������Ͽ����ز��ɹ�������-1
                    }
                }
                return 0;
            }
            catch
            {
                //MessageBox.Show("����ͼ��ʧ��");
                return -1;
            }
        }

        /// <summary>
        /// �ϴ�ͼƬ�����������������ݿ�
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <param name="localpath"></param>
        /// <returns>0:�ϴ�ʧ��,1:�ϴ��ɹ�,-1:��������</returns>
        public int FileUpLoad(MImage model, string localpath, bool isMarkImg)
        {
            try
            {
                int i = -2;
                if (isMarkImg)
                    i = fileTranfer.FileUpLoad(model.MARK_IMAGE_PATH, localpath);
                else
                    i = fileTranfer.FileUpLoad(model.IMAGE_PATH, localpath);
                if (i < 0)
                    return 0;
                int imageId = -1;
                if (model.IMAGE_ID == null)
                {
                    i = Bimage.Add(model, ref imageId);
                    model.IMAGE_ID = imageId;
                }
                else
                {
                    i = Bimage.Update(model, "where IMAGE_ID=" + model.IMAGE_ID);
                }
                if (i < 0)
                    return 0;
                if (!isMarkImg)
                {
                    SIS_Model.MWorkList mWorkList = (SIS_Model.MWorkList)bWorkList.GetModel(model.EXAM_ACCESSION_NUM);
                    if (mWorkList.IMAGE_COUNTS == null)
                        mWorkList.IMAGE_COUNTS = 1;
                    else
                        mWorkList.IMAGE_COUNTS += 1;
                    bWorkList.Update(mWorkList, " where EXAM_ACCESSION_NUM = '" + mWorkList.EXAM_ACCESSION_NUM + "'");
                }
                return 1;// 
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// ɾ��ͼƬ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteImg(MImage model)
        {
            if (Bimage.Delete(" where IMAGE_ID=" + model.IMAGE_ID.ToString()) >= 0)
            {
                SIS_Model.MWorkList mWorkList = (SIS_Model.MWorkList)bWorkList.GetModel(model.EXAM_ACCESSION_NUM);
                if (mWorkList.IMAGE_COUNTS == null)
                    mWorkList.IMAGE_COUNTS = 0;
                else
                    mWorkList.IMAGE_COUNTS -= 1;
                if (mWorkList.IMAGE_COUNTS < 0)
                    mWorkList.IMAGE_COUNTS = 0;
                bWorkList.Update(mWorkList, " where EXAM_ACCESSION_NUM = '" + mWorkList.EXAM_ACCESSION_NUM + "'");
            }
            return 0;
        }

        /// <summary>
        /// �ϴ���λͼ�����������������ݿ�
        /// </summary>
        public int FileUpLoad(MLocationMap mLocMap, string localpath)
        {
            try
            {
                fileTranfer.FileUpLoad(mLocMap.MAP_PATH, localpath);
                BLocationMap bLocMap = new BLocationMap();
                int i = 0;
                if (bLocMap.Exists(mLocMap))
                    i = bLocMap.Update(mLocMap, " where MAP_ID = " + mLocMap.MAP_ID);
                else
                    i = bLocMap.Add(mLocMap);
                return 1;// 
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// �ϴ��ļ���������
        /// </summary>
        /// <param name="ServerPath"></param>
        /// <param name="Localpath"></param>
        /// <returns></returns>
        public int FileUpLoad(string ServerPath, string Localpath)
        {
            return fileTranfer.FileUpLoad(ServerPath, Localpath);
        }

        /// <summary>
        /// �ӷ����������ļ�
        /// </summary>
        /// <param name="ServerPath"></param>
        /// <param name="Localpath"></param>
        /// <returns></returns>
        public int FileDown(string ServerPath, string Localpath)
        {
            return fileTranfer.FileDown(ServerPath, Localpath);
        }

        /// <summary>
        /// ���ر���
        /// </summary>
        /// <returns></returns>
        public IModel ReportDownLoad(IModel iWorklist, string saveDir)
        {
            string ReportPath = saveDir + "\\report.doc";
            try
            {
                if (GetConfig.DALAndModel == "SIS")
                {
                    SIS_Model.MWorkList mWorklist = (SIS_Model.MWorkList)iWorklist;
                    SIS_Model.MReport mReport = (SIS_Model.MReport)bReport.GetModel(mWorklist.EXAM_ACCESSION_NUM);
                    if (mReport == null || mReport.REPORT_NAME == null)
                    {
                        if (mReport == null)
                            mReport = new SIS_Model.MReport();
                        SIS_Model.MPrintTemplateDict mPrint = (SIS_Model.MPrintTemplateDict)bPrint.GetModel(mWorklist.EXAM_CLASS, mWorklist.EXAM_SUB_CLASS);
                        if (mPrint != null)
                        {
                            FileOp.FileSave(mPrint.FILE_NAME, ReportPath);
                            mReport.FIELD_INF = mPrint.FIELD_INF;
                            mReport.PRINT_TEMPLATE = mPrint.PRINT_TEMPLATE;
                        }
                        else//�޴˼����𣬼������Ĵ�ӡģ��ʱ�����ش˼������µ�Ĭ�ϴ�ӡģ��
                        {
                            DataTable dt = bPrint.GetList("EXAM_CLASS = '" + mWorklist.EXAM_CLASS + "'");
                            if (dt.Rows.Count > 0)
                            {
                                mPrint = (SIS_Model.MPrintTemplateDict)bPrint.GetModel(dt.Rows[0]);
                                FileOp.FileSave(mPrint.FILE_NAME, ReportPath);
                                mReport.FIELD_INF = mPrint.FIELD_INF;
                                mReport.PRINT_TEMPLATE = mPrint.PRINT_TEMPLATE;
                            }
                            else
                                return null;
                        }
                    }
                    else
                        FileOp.FileSave(mReport.REPORT_NAME, ReportPath);
                    return mReport;
                }
                else
                {
                    PACS_Model.MWorkList mWorklist = (PACS_Model.MWorkList)iWorklist;
                    PACS_Model.MReport mReport = (PACS_Model.MReport)bReport.GetModel(mWorklist.EXAM_ACCESSION_NUM);
                    if (mReport == null || mReport.REPORT_NAME == null)
                    {
                        if (mReport == null)
                            mReport = new PACS_Model.MReport();
                        PACS_Model.MPrintTemplateDict mPrint = (PACS_Model.MPrintTemplateDict)bPrint.GetModel(mWorklist.EXAM_CLASS, mWorklist.EXAM_SUB_CLASS);
                        if (mPrint != null)
                        {
                            FileOp.FileSave(mPrint.FILE_NAME, ReportPath);
                            mReport.FIELD_INF = mPrint.FIELD_INF;
                            mReport.PRINT_TEMPLATE = mPrint.PRINT_TEMPLATE;
                        }
                        else//�޴˼����𣬼������Ĵ�ӡģ��ʱ�����ش˼������µ�Ĭ�ϴ�ӡģ��
                        {
                            DataTable dt = bPrint.GetList("EXAM_CLASS = '" + mWorklist.EXAM_CLASS + "'");
                            if (dt.Rows.Count > 0)
                            {
                                mPrint = (PACS_Model.MPrintTemplateDict)bPrint.GetModel(dt.Rows[0]);
                                FileOp.FileSave(mPrint.FILE_NAME, ReportPath);
                                mReport.FIELD_INF = mPrint.FIELD_INF;
                                mReport.PRINT_TEMPLATE = mPrint.PRINT_TEMPLATE;
                            }
                            else
                                return null;
                        }
                    }
                    else
                        FileOp.FileSave(mReport.REPORT_NAME, ReportPath);
                    return mReport;
                }
            }
            catch { return null; }
        }

        /// <summary>
        /// ���ر���
        /// </summary>
        /// <returns></returns>
        public SIS_Model.MReport PacsReportDownLoad(SIS_Model.MStudy mStudy, string saveDir)
        {
            SIS_Model.MReport mReport = (SIS_Model.MReport)bReport.GetModel(mStudy.EXAM_ACCESSION_NUM);
            if (mReport == null)
                return null;
            string ReportPath = saveDir + "\\" + mStudy.EXAM_ACCESSION_NUM + ".doc";
            if (mReport.REPORT_NAME == null)
            {
                SIS_Model.MPrintTemplateDict mPrint = (SIS_Model.MPrintTemplateDict)bPrint.GetModel(mStudy.EXAM_CLASS, mStudy.EXAM_SUB_CLASS);
                if (mPrint != null)
                {
                    FileOp.FileSave(mPrint.FILE_NAME, ReportPath);
                    mReport.FIELD_INF = mPrint.FIELD_INF;
                }
                else//�޴˼����𣬼������Ĵ�ӡģ��ʱ�����ش˼������µ�Ĭ�ϴ�ӡģ��
                {
                    DataTable dt = bPrint.GetList("EXAM_CLASS = '" + mStudy.EXAM_CLASS + "'");
                    if (dt.Rows.Count > 0)
                    {
                        mPrint = (SIS_Model.MPrintTemplateDict)bPrint.GetModel(dt.Rows[0]);
                        FileOp.FileSave(mPrint.FILE_NAME, ReportPath);
                        mReport.FIELD_INF = mPrint.FIELD_INF;
                    }
                    else
                        return null;
                }
            }
            else
                FileOp.FileSave(mReport.REPORT_NAME, ReportPath);
            return mReport;
        }
    }
}
