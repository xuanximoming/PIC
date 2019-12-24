using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// STAT�࣬����ͳ�ƹ���
    /// </summary>
    public class BStat
    {
      private static IStat dal = DALFactory.DAL.CreateDStat();
      public BStat()
      {
      }

      /// <summary>
      /// ���ҽʦ������ͳ��
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryExamDoc"></param>
      /// <returns></returns>
      public DataSet queryDiagDocWork(string queryDate, string queryExamDoc)
      {
          return dal.queryDiagDocWork(queryDate, queryExamDoc);
      }

      /// <summary>
      /// ����������ͳ��
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryExamClass"></param>
      /// <returns></returns>
      public DataSet queryExamClassWork(string queryDate, string queryExamClass)
      {
          return dal.queryExamClassWork(queryDate, queryExamClass);   
      }

      /// <summary>
      /// ���ҹ�����ͳ��
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryDeptName"></param>
      /// <returns></returns>
      public DataSet queryDiagDeptWork(string queryDate, string queryDeptName)
      {
          return dal.queryDiagDeptWork(queryDate, queryDeptName);
      }

      /// <summary>
      /// ��鲡����ϸͳ�� 
      /// </summary>
      public DataSet queryPatientCount(string queryDate, string queryPatientSource)
      {
          return dal.queryPatientCount(queryDate, queryPatientSource);
      }
      
       /// <summary>
       /// ��鼼ʦͳ�� 
       /// </summary>
      public DataSet queryExamDocWork(string queryDate, string queryDoctor)
      {
          return dal.queryExamDocWork(queryDate, queryDoctor);
      }

      ///<summary>
      ///�����Բ�����ͳ��
      ///</summary>
      public DataSet queryAbnormal(string queryDate,string queryAbnormal)
      {
          return dal.queryAbnormal(queryDate,queryAbnormal );
      }

      ///<summary>
      ///���������뵥ͳ��
      ///</summary>
      public DataSet queryApplyDept(string queryDate, string queryAbnormal)
      {
          return dal.queryApplyDept(queryDate, queryAbnormal);
      }
      
    }
}