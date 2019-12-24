using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Query
{
    public class QuerySql
    {
        ///// <summary>
        ///// 检索WORKLIST条件为：本科室--EXAM_DEPT字段
        ///// </summary>
        //public string QueryWorklist(string ExamDept,string PatientID,string PatientName,string PatientLocalID,
        //    string InpNo,string ChargeType,string ConfirmedIndex,string ExamClass,string ExamItem,string ExamSubClass,
        //    string PatientSource,string ReferDept,string ExamGroup,string ReportTypeIndex,
        //    string ReferDoctor,string )
        //{
        //    string where = " 1=1 and EXAM_DEPT=" + ExamDept;
        //    if (PatientID.Trim() != "")
        //        where += " and patient_id='" + PatientID.Trim() + "'";
        //    if (PatientName.Trim() != "")
        //        where += " and patient_name like '%" + PatientName.Trim() + "%'";
        //    if (PatientLocalID.Trim() != "")
        //        where += " and patient_local_id='" + PatientLocalID.Trim() + "'";
        //    if (InpNo.Trim() != "")
        //        where += " and inp_no='" + InpNo.Trim() + "'";
        //    if (ChargeType.Trim() != "")
        //        where += " and CHARGE_TYPE = " + ChargeType.Trim();
        //    if (ConfirmedIndex.Trim() != "")
        //        where += " and IS_CONFIRMED =" + (int.Parse(ConfirmedIndex) + 1).ToString();
        //    if (ExamClass != "")
        //        where += " and EXAM_CLASS ='" + ExamClass + "'";
        //    if (ExamItem != "")
        //        where += " and EXAM_ITEMS like '%" + ExamItem + "%'";
        //    if (ExamSubClass != "")
        //        where += " and EXAM_SUB_CLASS = '" + ExamSubClass + "'";
        //    if (PatientSource != null)
        //        where += " and PATIENT_SOURCE = '" + PatientSource + "'";
        //    if (ReferDept != "")
        //        where += " and REQ_DEPT_NAME = '" + ReferDept + "'";
        //    if (ReferDoctor != "")
        //        where += " and REFER_DOCTOR ='" + ReferDoctor + "'";
        //    if (ExamGroup != "")
        //        where += " and EXAM_GROUP ='" + ExamGroup + "'";
        //    if (ReportTypeIndex != "")
        //        where += " and REPORT_TYPE = " + (int.Parse(ReportTypeIndex) + 1).ToString();
        //    if (this.dtp_From.Checked || this.dtp_To.Checked)
        //    {
        //        string DateFrom = "", DateTo = "";
        //        if (this.dtp_From.Checked)
        //            DateFrom = this.dtp_From.Text;
        //        else
        //            DateFrom = this.dtp_From.MinDate.ToShortDateString();
        //        if (this.dtp_To.Checked)
        //            DateTo = this.dtp_To.Value.AddDays(1).ToShortDateString();
        //        else
        //            DateTo = System.DateTime.Now.AddMonths(1).ToShortDateString();
        //        where += DateTimeSql(DateFrom, DateTo);
        //    }
        //    where += " order by REQ_DATE_TIME DESC";
        //    DataTable dt = Bworklist.GetWorkListReport(where);
        //    dgv_ExamList.DataSource = dt;
        //    if (dt.Rows.Count > 0)
        //        dgv_ExamList.Rows[0].Selected = false;
        //    this.l_Count.Text = "共 " + dgv_ExamList.Rows.Count + " 条记录";
        //    this.p_Control.Controls.Clear();
        //    this.txt_Impression.Text = "";
        //    this.txt_Description.Text = "";
        //}
        ///// <summary>
        ///// 排队模式时用的查询WL
        ///// </summary>
        ///// <param name="EXAM_ACCESSION_NUM"></param>
        //private void QueryWorklist(string EXAM_ACCESSION_NUM)
        //{
        //    string where = "";
        //    switch (GetConfig.SisOdbcMode)
        //    {
        //        case "ACCESS":
        //            where = " 1=1 and REQ_DATE_TIME between date() and date()+1 and EXAM_DEPT=" + this.ExamDept + " ";
        //            break;
        //        case "ORACLE":
        //            where = " 1=1 and REQ_DATE_TIME>=trunc(sysdate) and REQ_DATE_TIME<trunc(sysdate+1) and EXAM_DEPT=" + this.ExamDept + " ";
        //            break;
        //        case "SQL":
        //            break;
        //    }
        //    dgv_ExamList.DataSource = Bworklist.GetList(where);
        //    //LockWorklist(EXAM_ACCESSION_NUM);
        //}
    }
}
