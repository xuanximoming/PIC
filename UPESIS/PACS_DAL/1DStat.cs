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
        private string querySql;	//��ѯ���
        private System.Data.DataSet queryDs;	//��ѯ���ݼ�
        public DStat()
            : base(GetConfig.GetPacsConnStr())
        {

        }
        //���ҽʦ������ͳ��
        public override DataSet queryDiagDocWork(string queryDate, string queryExamDoc)
        {
            this.querySql = "select b.TRANSCRIBER ,decode(a.patient_source,'1','����','2','����','3','����','4','����','5','���') as Patient_Source,count(a.EXAM_ACCESSION_NUM  ) as examcount,sum(b.IS_ABNORMAL ) as abnormalcount from worklist a,report b where a.EXAM_ACCESSION_NUM = b.EXAM_NO and b.report_date_time " + queryDate + queryExamDoc + "group by  b.TRANSCRIBER,decode(a.patient_source,'1','����','2','����','3','����','4','����','5','���')";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        //����������ͳ��
        public override DataSet queryExamClassWork(string queryDate, string queryExamClass)
        {
            this.querySql = " select a.exam_class,a.exam_sub_class,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a where a.req_date_time " + queryDate + queryExamClass + " group by a.exam_class,a.exam_sub_class ";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        //���ҹ�����ͳ��
        public override DataSet queryDiagDeptWork(string queryDate, string queryDeptName)
        {
            this.querySql = "select a.exam_group,decode(a.patient_source,'1','����','2','����','3','����','4','����','5','���') as Patient_Source,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a,report b where  a.exam_accession_num = b.exam_no(+) and b.report_date_time " + queryDate + queryDeptName + " group by a.exam_group,decode(a.patient_source,'1','����','2','����','3','����','4','����','5','���')";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        /// <summary>
        /// ������ͳ�� 
        /// </summary>
        public override DataSet queryPatientCount(string queryDate, string queryPatientSource)
        {
            this.querySql = "select decode(a.patient_source,'1','����','2','����','3','����','4','����','5','���') as Patient_Source,a.EXAM_CLASS ,a.EXAM_SUB_CLASS ,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a where  a.req_date_time " + queryDate + queryPatientSource + " group by a.EXAM_CLASS ,decode(a.patient_source,'1','����','2','����','3','����','4','����','5','���'),a.EXAM_SUB_CLASS ";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }
    }
}
