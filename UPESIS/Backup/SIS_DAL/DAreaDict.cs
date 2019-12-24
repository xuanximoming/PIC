using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using SIS_Model;

namespace SIS_DAL
{
    /// <summary>
    /// ��AREA_DICT������������
    /// </summary>
    public class DAreaDict :IAreaDict
    {
        private string strSql;
        private string TableName = "AREA_DICT";
        public DAreaDict():base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// ����һ����������¼
        /// </summary>
        /// <param name="iarea"></param>
        /// <returns></returns>
        public override int Add(IModel iarea)
        {
            MAreaDict area = (MAreaDict)iarea;
            Hashtable ht = new Hashtable();
            ht.Add("AREA_CODE",area.AREA_CODE );
            ht.Add("AREA_NAME", area.AREA_NAME);
            ht.Add("INPUT_CODE", area.INPUT_CODE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ������������¼
        /// </summary>
        /// <param name="iarea"></param>
        /// <returns></returns>
        public override bool Exists(IModel iarea)
        {
            MAreaDict area = (MAreaDict)iarea;
            strSql = "select * from " + TableName + " where AREA_CODE='" + area.AREA_CODE + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ���������������������¼
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        public override IModel GetModel(string areaCode)
        {
            strSql = "select * from " + TableName + "  where AREA_CODE='" + areaCode + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MAreaDict area = new MAreaDict();
            area.AREA_CODE = dt.Rows[0]["AREA_CODE"].ToString();
            area.AREA_NAME = dt.Rows[0]["AREA_NAME"].ToString();
            area.INPUT_CODE = dt.Rows[0]["INPUT_CODE"].ToString();
            return area;
        }

        /// <summary>
        /// ��ȡ�����������������б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ������������¼
        /// </summary>
        /// <param name="iarea"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iarea, string where)
        {
            MAreaDict area = (MAreaDict)iarea;
            Hashtable ht = new Hashtable();
            ht.Add("AREA_CODE", area.AREA_CODE);
            ht.Add("AREA_NAME", area.AREA_NAME);
            ht.Add("INPUT_CODE", area.INPUT_CODE);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// ɾ��������������������¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }    
    }
}