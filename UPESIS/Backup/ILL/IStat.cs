using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace ILL
{
    /// <summary>
    /// �̳�DBControl�ĳ�����IStat,���ڲ���SIS��ͳ��
    /// </summary>
  public abstract class IStat:DBControl 
    {
      public IStat(ConParam cps)
        :base(cps)
      {
      }
      /// <summary>
      /// ���ҽʦ������ͳ��
      /// </summary>
      public virtual DataSet queryDiagDocWork(string queryDate, string queryExamDoc)
      {
          return null;

      }
      /// <summary>
      /// ����������ͳ��
      /// </summary>
      public virtual DataSet queryExamClassWork(string queryDate, string queryExamClass)
      {
          return null;
      }

      /// <summary>
      /// ���ҹ�����ͳ��
      /// </summary>
      public virtual DataSet queryDiagDeptWork(string queryDate, string queryDiag)
      {
          return null;
      }
      
      /// <summary>
      /// ������ͳ�� 
      /// </summary>
      public virtual DataSet queryPatientCount(string queryDate, string queryPatientSource)
      {
          return null;
      }
      /// <summary>
      ///  ��鼼ʦͳ��
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryDoctor"></param>
      /// <returns></returns>
      public virtual DataSet queryExamDocWork(string queryDate, string queryDoctor)
      {
          return null;
      }
      public virtual DataSet queryAbnormal(string queryDate, string queryAbnormal)
      {
          return null;
      }
      public virtual DataSet queryApplyDept(string queryDate, string queryAbnormal)
      {
          return null;
      }
      
    }
}
