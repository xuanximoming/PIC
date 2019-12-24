using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using SIS_Model;
using ILL;
namespace SIS_DAL
{
    /// <summary>
    /// ��IMAGE_EQUIPMENT��Ӱ���豸��
    /// </summary>
    public class DImgEquipment : IImgEquipment
    {
        private string strSql;
        private string TableName = "IMG_EQUIPMENT";
        public DImgEquipment()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// ����һ��Ӱ���豸��¼
        /// </summary>
        /// <param name="iimgEquipment"></param>
        /// <returns></returns>
        public override int Add(IModel iimgEquipment)
        {
            MImgEquipment imgEquipment = (MImgEquipment)iimgEquipment;
            Hashtable ht = new Hashtable();
            ht.Add("IMG_EQUIPMENT_ID", imgEquipment.IMG_EQUIPMENT_ID);
            ht.Add("IMG_EQUIPMENT_NAME", imgEquipment.IMG_EQUIPMENT_NAME);
            ht.Add("CLINIC_OFFICE_CODE", imgEquipment.CLINIC_OFFICE_ID);
            ht.Add("OFFICE", imgEquipment.OFFICE);
            ht.Add("SERIAL_CLASS", imgEquipment.SERIAL_CLASS);
            ht.Add("EQUIPMENT_STATE", imgEquipment.EQUIPMENT_STATE);
            ht.Add("OPERATOR_DOCTOR", imgEquipment.OPERATOR_DOCTOR);
            ht.Add("IP", imgEquipment.IP);
            ht.Add("LAST_CALL", imgEquipment.LAST_CALL);
            ht.Add("EQU_GUID", imgEquipment.EQU_GUID);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ��������Ӱ���豸��¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MImgEquipment imgEquipment = new MImgEquipment();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    imgEquipment = (MImgEquipment)ht2[i];
                    ht.Add("IMG_EQUIPMENT_ID", imgEquipment.IMG_EQUIPMENT_ID);
                    ht.Add("IMG_EQUIPMENT_NAME", imgEquipment.IMG_EQUIPMENT_NAME);
                    ht.Add("CLINIC_OFFICE_CODE", imgEquipment.CLINIC_OFFICE_ID);
                    ht.Add("OFFICE", imgEquipment.OFFICE);
                    ht.Add("SERIAL_CLASS", imgEquipment.SERIAL_CLASS);
                    ht.Add("EQUIPMENT_STATE", imgEquipment.EQUIPMENT_STATE);
                    ht.Add("OPERATOR_DOCTOR", imgEquipment.OPERATOR_DOCTOR);
                    ht.Add("IP", imgEquipment.IP);
                    ht.Add("LAST_CALL", imgEquipment.LAST_CALL);
                    ht.Add("EQU_GUID", imgEquipment.EQU_GUID);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ����Ӱ���豸��¼
        /// </summary>
        /// <param name="iimgEquipment"></param>
        /// <returns></returns>
        public override bool Exists(IModel iimgEquipment)
        {
            MImgEquipment imgEquipment = (MImgEquipment)iimgEquipment;
            strSql = "select * from " + TableName + " where IMG_EQUIPMENT_ID=" + imgEquipment.IMG_EQUIPMENT_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ��Ӱ���豸ID��Ӱ���豸��¼
        /// </summary>
        /// <param name="IMG_EQUIPMENT_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string IMG_EQUIPMENT_ID)
        {
            strSql = "select * from " + TableName + " where IMG_EQUIPMENT_ID = " + IMG_EQUIPMENT_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MImgEquipment imgEquipment = new MImgEquipment();
            imgEquipment.IMG_EQUIPMENT_ID = Convert.ToInt32(dt.Rows[0]["IMG_EQUIPMENT_ID"].ToString());

            if (dt.Rows[0]["CLINIC_OFFICE_CODE"].ToString() == "")
                imgEquipment.CLINIC_OFFICE_ID = null;
            else
                imgEquipment.CLINIC_OFFICE_ID = Convert.ToInt32(dt.Rows[0]["CLINIC_OFFICE_CODE"].ToString());

            if (dt.Rows[0]["LAST_CALL"].ToString() == "")
                imgEquipment.LAST_CALL = null;
            else
                imgEquipment.LAST_CALL = Convert.ToDateTime(dt.Rows[0]["LAST_CALL"].ToString());

            imgEquipment.IMG_EQUIPMENT_NAME = dt.Rows[0]["IMG_EQUIPMENT_NAME"].ToString();
            imgEquipment.OFFICE = dt.Rows[0]["OFFICE"].ToString();
            imgEquipment.SERIAL_CLASS = dt.Rows[0]["SERIAL_CLASS"].ToString();

            imgEquipment.EQUIPMENT_STATE = dt.Rows[0]["EQUIPMENT_STATE"].ToString();
            imgEquipment.OPERATOR_DOCTOR = dt.Rows[0]["OPERATOR_DOCTOR"].ToString();
            imgEquipment.IP = dt.Rows[0]["IP"].ToString();
            imgEquipment.EQU_GUID = dt.Rows[0]["EQU_GUID"].ToString();
            return imgEquipment;
        }

        /// <summary>
        /// ��ȡ����������Ӱ���豸��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ������ȡ����������Ӱ���豸��¼
        /// </summary>
        /// <param name="strConDiTion"></param>
        /// <returns></returns>
        public override DataTable GetListMore(string strConDiTion)
        {
            string sql = "select a.IMG_EQUIPMENT_ID,a.IMG_EQUIPMENT_NAME,a.OFFICE,a.SERIAL_CLASS,a.EQUIPMENT_STATE,a.OPERATOR_DOCTOR,a.IP,a.LAST_CALL," +
                        "a.EQU_GUID,b.CLINIC_OFFICE from IMG_EQUIPMENT a,CLINIC_OFFICE_DICT b where a.CLINIC_OFFICE_CODE =b.CLINIC_OFFICE_ID  and ";
            if (strConDiTion != "")
                sql += strConDiTion;

            return GetDataTable(sql + " 1=1 order by EQU_GUID asc");
        }

        /// <summary>
        /// ����ָ����Ӱ���豸��¼
        /// </summary>
        /// <param name="iimgEquipment"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iimgEquipment, string where)
        {
            MImgEquipment imgEquipment = (MImgEquipment)iimgEquipment;
            Hashtable ht = new Hashtable();
            ht.Add("IMG_EQUIPMENT_ID", imgEquipment.IMG_EQUIPMENT_ID);
            ht.Add("IMG_EQUIPMENT_NAME", imgEquipment.IMG_EQUIPMENT_NAME);
            ht.Add("CLINIC_OFFICE_CODE", imgEquipment.CLINIC_OFFICE_ID);
            ht.Add("OFFICE", imgEquipment.OFFICE);
            ht.Add("SERIAL_CLASS", imgEquipment.SERIAL_CLASS);
            ht.Add("EQUIPMENT_STATE", imgEquipment.EQUIPMENT_STATE);
            ht.Add("OPERATOR_DOCTOR", imgEquipment.OPERATOR_DOCTOR);
            ht.Add("IP", imgEquipment.IP);
            ht.Add("LAST_CALL", imgEquipment.LAST_CALL);
            ht.Add("EQU_GUID", imgEquipment.EQU_GUID);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// ��������Ӱ���豸��¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MImgEquipment imgEquipment = new MImgEquipment();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    imgEquipment = (MImgEquipment)ht2[i];
                    ht.Add("IMG_EQUIPMENT_ID", imgEquipment.IMG_EQUIPMENT_ID);
                    ht.Add("IMG_EQUIPMENT_NAME", imgEquipment.IMG_EQUIPMENT_NAME);
                    ht.Add("CLINIC_OFFICE_CODE", imgEquipment.CLINIC_OFFICE_ID);
                    ht.Add("OFFICE", imgEquipment.OFFICE);
                    ht.Add("SERIAL_CLASS", imgEquipment.SERIAL_CLASS);
                    ht.Add("EQUIPMENT_STATE", imgEquipment.EQUIPMENT_STATE);
                    ht.Add("OPERATOR_DOCTOR", imgEquipment.OPERATOR_DOCTOR);
                    ht.Add("IP", imgEquipment.IP);
                    ht.Add("LAST_CALL", imgEquipment.LAST_CALL);
                    ht.Add("EQU_GUID", imgEquipment.EQU_GUID);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where IMG_EQUIPMENT_ID = " + imgEquipment.IMG_EQUIPMENT_ID));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// ɾ������������������Ч���豸��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}