using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using SIS_Function;
using System.Data;
using System.Collections;
using System.IO;

namespace SIS.RegisterCls
{
    public class RegCls_HT : DBControl 
    {
        private FileTransfer fileTransfer = null;
        public RegCls_HT()
            : base(GetConfig.GetHisConnStr())
        {
            fileTransfer = new FileTransfer(ILL.GetConfig.ServerIp, ILL.GetConfig.ServerPort);
        }
        /// <summary>
        /// 判断病人档案中是否有该病人资料
        /// </summary>
        /// <returns></returns>
        private bool CheckPatientIDInHIS(string PatientId)
        {
            string sql = "select Patient_ID from PAT_MASTER_INDEX where PATIENT_ID='" + PatientId + "'";
            return recordIsExist(sql);
        }
        /// <summary>
        /// 根据条件获取申请单
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="PatNoType"></param>
        /// <param name="PatNo"></param>
        /// <returns></returns>
        public DataTable GetQPInfo(Hashtable ht)
        {
            string PatNo="";
            string PatNoType="";
            if (ht.Contains("PATIENT_ID"))
            {
                PatNo = ht["PATIENT_ID"].ToString().Trim();
                PatNoType = "1";
            }
            else
            {
                if (ht.Contains("PATIENT_NAME"))
                {
                    PatNo = ht["PATIENT_NAME"].ToString().Trim();
                    PatNoType = "5";
                }
                else
                {
                    return null;
                }
            }
            byte[] Condition = Encoding.Default.GetBytes(CreateQPInfo("2", PatNoType, PatNo));

            byte[] result = fileTransfer.QPInfo(Condition);
            return GetDt(result);
            //return null;
        }
        //public DataTable GetQPInfo(string Source, string PatNoType, string PatNo)
        //{
        //    byte[] Condition = Encoding.Default.GetBytes(CreateQPInfo(Source, PatNoType, PatNo));

        //    byte[] result = fileTransfer.QPInfo(Condition);
        //    return GetDt(result);
        //    //return null;
        //}
        /// <summary>
        /// 解析接收到的申请单流
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        private DataTable GetDt(byte[] bt)
        {
            try
            {
                MemoryStream ms = new MemoryStream(bt);
                StreamReader fileRead = new StreamReader(ms, System.Text.Encoding.Default);
                //StreamReader fileRead = new StreamReader(Application.StartupPath + "\\bb.txt", System.Text.Encoding.Default);

                ArrayList array = new ArrayList();
                for (string str = fileRead.ReadLine(); str != null; str = fileRead.ReadLine())
                {
                    array.Add(str);
                }
                fileRead.Close();
                string TableName = "";
                ArrayList arColumns = new ArrayList();
                ArrayList arValues = new ArrayList();
                for (int i = 0; i < array.Count; i++)
                {
                    string str = array[i].ToString();
                    if (str.Trim().Length > 0)
                    {
                        if (str.Substring(0, 1) == "[")//解析[update]
                        {
                            TableName = str.Substring(1, str.LastIndexOf("]") - 1);
                        }
                        else if (str.IndexOf('=') > 0)//解析A=a
                        {
                            string ColName = str.Substring(0, str.IndexOf('='));
                            string ColValue = str.Substring(str.IndexOf('=') + 1);
                            if (!arColumns.Contains(ColName))
                                arColumns.Add(ColName);
                            arValues.Add(ColValue);
                        }
                    }
                }
                DataTable dt = new DataTable(TableName);
                for (int i = 0; i < arColumns.Count; i++)//创建表格格式
                {
                    dt.Columns.Add(new DataColumn(arColumns[i].ToString()));
                }
                DataRow dw = dt.NewRow();
                for (int i = 0; i < arValues.Count; i++)//填充行
                {
                    int index = i % dt.Columns.Count;

                    if (index == 0)
                    {
                        dw = dt.NewRow();

                    }
                    dw[index] = arValues[i].ToString() == "null" ? "" : arValues[i].ToString();
                    if (index == 0)
                        dt.Rows.Add(dw);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 构造申请单查询条件
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="PatNoType"></param>
        /// <param name="PatNo"></param>
        /// <returns></returns>

        private string CreateQPInfo(string Source, string PatNoType, string PatNo)
        {
            string str = "";
            str += "[QPInfo]\r\n";
            str += string.Format("Source={0}\r\n", Source);
            str += string.Format("PatNoType={0}\r\n", PatNoType);
            str += string.Format("PatNo={0}\r\n", PatNo);
            return str;
        }
       
    }
}
