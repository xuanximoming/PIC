using System;
using System.Text;
using ILL;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using System.Collections.Generic;

namespace PACS_DAL
{
    public class DStat : IStat
    {
        private string querySql;	//查询语句
        private System.Data.DataSet queryDs;	//查询数据集
        public DStat()
            : base(GetConfig.GetPacsConnStr())
        {

        }
        //诊断医师工作量统计
        public override DataSet queryDiagDocWork(string queryDate, string queryExamDoc)
        {
            this.querySql = "select b.TRANSCRIBER ,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检') as Patient_Source,count(a.EXAM_ACCESSION_NUM  ) as examcount,sum(b.IS_ABNORMAL ) as abnormalcount from worklist a,report b where a.EXAM_ACCESSION_NUM = b.EXAM_NO and b.report_date_time " + queryDate + queryExamDoc + "group by  b.TRANSCRIBER,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检')";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        //检查类别工作量统计
        public override DataSet queryExamClassWork(string queryDate, string queryExamClass)
        {
            this.querySql = " select a.exam_class,a.exam_sub_class,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a where a.req_date_time " + queryDate + queryExamClass + " group by a.exam_class,a.exam_sub_class ";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        //科室工作量统计
        public override DataSet queryDiagDeptWork(string queryDate, string queryDeptName)
        {
            this.querySql = "select a.exam_group,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检') as Patient_Source,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a,report b where  a.exam_accession_num = b.exam_no(+) and b.report_date_time " + queryDate + queryDeptName + " group by a.exam_group,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检')";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        /// <summary>
        /// 病人数统计 
        /// </summary>
        public override DataSet queryPatientCount(string queryDate, string queryPatientSource)
        {
            this.querySql = "select decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检') as Patient_Source,a.EXAM_CLASS ,a.EXAM_SUB_CLASS ,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a where  a.req_date_time " + queryDate + queryPatientSource + " group by a.EXAM_CLASS ,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检'),a.EXAM_SUB_CLASS ";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }
    }
}
