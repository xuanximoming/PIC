﻿using System;
namespace PACS_Model
{
    /// <summary>
    /// 实体类PATIENT_INF_LOCAL_ID，病人信息与检查号对照
    /// </summary>
    [Serializable]
    public class MPatientInfLocalId : ILL.IModel
    {
        public MPatientInfLocalId()
        { }
        #region Model
        private string _patient_id;         //病人标志号
        private string _local_id_class;     //本地号类别
        private string _patient_local_id;   //检查本地标志号
        private int? _exam_times;           //检查次数

        /// <summary>
        /// 病人标志号
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// 本地号类别
        /// </summary>
        public string LOCAL_ID_CLASS
        {
            set { _local_id_class = value; }
            get { return _local_id_class; }
        }

        /// <summary>
        /// 检查本地标志号
        /// </summary>
        public string PATIENT_LOCAL_ID
        {
            set { _patient_local_id = value; }
            get { return _patient_local_id; }
        }

        /// <summary>
        /// 检查次数
        /// </summary>
        public int? EXAM_TIMES
        {
            set { _exam_times = value; }
            get { return _exam_times; }
        }
        #endregion Model

    }
}