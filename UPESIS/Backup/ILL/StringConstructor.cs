using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace ILL
{
    /// <summary>
    /// �����StringConstructor,�����ַ����Ĺ���
    /// </summary>
    public sealed class StringConstructor
    {
        /// <summary>
        /// ����SQL�������
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="Cols">��Ҫ������м���</param>
        /// <returns>string</returns>
        public static string InsertSql(string TableName, Hashtable Cols)
        {
            int Count = 0;
            string Fields = " (";
            string Values = " Values(";
            if (Cols.Count <= 0)
            {
                return null;
            }
            foreach (DictionaryEntry item in Cols)
            {
                if (Count != 0)
                {
                    Fields += ",";
                    Values += ",";
                }
                Fields += item.Key.ToString();
                Values += GetItemValue(item);
                Count++;
            }
            Fields += ")";
            Values += ")";

            String SqlString = "Insert into " + TableName + Fields + Values;
            return SqlString;
        }

        /// <summary>
        /// ��ȡ�ֶε�ֵ
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static String GetItemValue(DictionaryEntry item)
        {
            if (item.Value == null)
                return "NULL";
            string ItemValue = "";
            switch (item.Value.GetType().ToString())
            {
                case "System.String":
                    ItemValue = IsString(item.Value.ToString());
                    break;
                case "System.DateTime":

                    ItemValue = IsDate(item.Value.ToString());
                    break;
                case "System.Int32":
                    ItemValue = IsNumber(item.Value.ToString());
                    break;
                case "System.Decimal":
                    ItemValue = IsNumber(item.Value.ToString());
                    break;
                case "System.Byte[]":
                    ItemValue = ":" + item.Key.ToString();
                    break;
                default:
                    ItemValue = IsNumber(item.Value.ToString());
                    break;

            }
            return ItemValue;
        }

        /// <summary>
        /// ����SQL�������
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Cols"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public static String UpdateSql(String TableName, Hashtable Cols, String Where)
        {
            int Count = 0;
            if (Cols.Count <= 0)
            {
                return null;
            }
            String Fields = " ";
            foreach (DictionaryEntry item in Cols)
            {
                if (Count != 0)
                {
                    Fields += ",";
                }
                Fields += item.Key.ToString();
                Fields += "=";
                Fields += GetItemValue(item);
                // Fields += item.Value.ToString();
                Count++;
            }
            Fields += " ";
            String SqlString = "Update " + TableName + " Set " + Fields + Where;
            return SqlString;
        }
        /// <summary>
        /// ����WHERE����
        /// </summary>
        /// <param name="Cols"> Hashtable</param>
        /// <param name="Type">And/Or</param>
        /// <returns></returns>
        public static String WhereSql(Hashtable Cols, String Type)
        {
            int Count = 0;
            String Where = "";

            //���ݹ�ϣ��ѭ�����������Ӿ�
            foreach (DictionaryEntry item in Cols)
            {
                if (Count == 0)
                    Where = " Where ";
                else
                    Where += " " + Type + " ";
                //string ItemValue = "
                ////���ݲ�ѯ�е��������ͣ������Ƿ�ӵ�����
                //if (item.Value.GetType().ToString() == "System.String")
                //{
                //    Where += item.Key.ToString()
                //        + " Like "
                //        + IsString("%"
                //        + item.Value.ToString()
                //        + "%");
                //}
                //else if (item.Value.GetType().ToString() == "System.DateTime")
                //{

                //}
                //else
                //{
                //    Where += item.Key.ToString() + "= " + item.Value.ToString();
                //}
                Where += item.Key.ToString() + "= " + GetItemValue(item);
                Count++;
            }
            return Where;
        }
        public static String GetSequeueSql(String SqueueName)
        {
            string sql = "select " + SqueueName + ".nextval from dual";
            return sql;
        }
        /// <summary>
        /// ����ɾ����SQL���
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public static String DeleteSql(String TableName, String Where)
        {
            String SqlString = "Delete from " + TableName + Where;
            return SqlString;
        }
        /// <summary>
        /// ת��ʱ��Ϊ�ʺ���ORACLE��ִ�е�ʱ������
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string IsDate(string date)
        {
            if (date == "")
                date = System.DateTime.Now.ToString();
            string str = "to_date('" + date + "','yyyy-mm-dd HH24:MI:SS')";
            return str;
        }
        /// <summary>
        /// ת���ַ���Ϊ��SQL�����еĺϷ��ַ���
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string IsString(String pStr)
        {
            return ("'" + pStr.Replace("'", "''") + "'");
        }
        /// <summary>
        /// ת����������Ϊ�ʺ���SQL��ִ�е�����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string IsNumber(string str)
        {
            if (str == "")
                str = "0";
            return str;
        }
    }
}
