using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIS_Model;

namespace SIS
{
    public class WordCombSource
    {
        private SIS_BLL.BUser bUser = new SIS_BLL.BUser();
        public WordCombSource()
        {
        }
        public DataTable GetSex()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("sex"));
            string[] sex={"ÄÐ","Å®"};
            for (int i = 0; i < sex.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = sex[i].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable GetAPPROVER(string ClinicOfficeCode)
        {
            DataTable dt = bUser.GetList(" 1=1 and CLINIC_OFFICE_CODE=" + ClinicOfficeCode);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName != "DOCTOR_NAME")
                    dt.Columns.Remove(dt.Columns[i].ColumnName);
            }
            return dt;
        }


    }
}
