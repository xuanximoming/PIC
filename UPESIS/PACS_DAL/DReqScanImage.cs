using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using PACS_Model;
using ILL;

namespace PACS_DAL
{
    /// <summary>
    /// ����REQ_SCAN_IMAGE�������뵥ɨ��ͼ��
    /// </summary>
    public class DReqScanImage : IReqScanImage
    {
        private string strSql;
        private string TableName = "REQ_SCAN_IMAGE";
        public DReqScanImage()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// ����һ�����뵥ɨ��ͼ���¼
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override int Add(IModel imodel)
        {
            MReqScanImage model = (MReqScanImage)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_NO", model.EXAM_ACCESSION_NUM);
            ht.Add("IMAGE_INDEX", model.IMAGE_INDEX);
            ht.Add("IMAGE_FILE", model.IMAGE_FILE);
            ht.Add("OPERATOR", model.OPERATOR);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// �����������뵥ͼ���¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MReqScanImage scanImage = new MReqScanImage();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    scanImage = (MReqScanImage)ht2[i];
                    ht.Add("EXAM_NO", scanImage.EXAM_ACCESSION_NUM);
                    ht.Add("IMAGE_INDEX", scanImage.IMAGE_INDEX);
                    ht.Add("IMAGE_FILE", scanImage.IMAGE_FILE);
                    ht.Add("OPERATOR", scanImage.OPERATOR);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);
            }
            else
                return 0;
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ�������뵥ͼ���¼
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override bool Exists(IModel imodel)
        {
            MReqScanImage model = (MReqScanImage)imodel;
            strSql = "select * from " + TableName + " where EXAM_NO=" + model.EXAM_ACCESSION_NUM + "and IMAGE_INDEX=" + model.IMAGE_INDEX;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ���ļ������š�ͼ�����е����뵥ͼ���¼
        /// </summary>
        /// <param name="EXAM_ACCESSION_NUM"></param>
        /// <param name="IMAGE_INDEX"></param>
        /// <returns></returns>
        public override IModel GetModel(string EXAM_ACCESSION_NUM,string IMAGE_INDEX)
        {
            strSql = "select * from " + TableName + " where EXAM_NO=" + EXAM_ACCESSION_NUM + "and IMAGE_INDEX=" + IMAGE_INDEX;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MReqScanImage Model = new MReqScanImage();
            Model.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_NO"].ToString();
            Model.IMAGE_INDEX=int.Parse(IMAGE_INDEX);
            Model.IMAGE_FILE = (byte[])dt.Rows[0]["IMAGE_FILE"];
            Model.OPERATOR=dt.Rows[0]["OPERATOR"].ToString();
            return Model;
        }

        /// <summary>
        /// ��ȡ�������������뵥ͼ���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ�������뵥ͼ���¼
        /// </summary>
        /// <param name="iscanImage"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iscanImage, string where)
        {
            MReqScanImage scanImage = (MReqScanImage)iscanImage;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_NO", scanImage.EXAM_ACCESSION_NUM);
            ht.Add("IMAGE_INDEX", scanImage.IMAGE_INDEX);
            ht.Add("IMAGE_FILE", scanImage.IMAGE_FILE);
            ht.Add("OPERATOR", scanImage.OPERATOR);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// ɾ���������������뵥ͼ���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}