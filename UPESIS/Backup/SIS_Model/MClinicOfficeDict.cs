using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����CLINC_OFFICE_DICT���ٴ����ұ�
    /// </summary>
    [Serializable]
    public class MClinicOfficeDict : ILL.IModel
    {
        public MClinicOfficeDict()
        { }
        #region Model
        private int? _clinic_office_id;         //�ٴ�����ID
        private string _clinic_office;          //�ٴ���������
        private int? _patient_source_id;        //������ԴID 0������ 1��סԺ
        private string _clinic_office_code;     //�ٴ����Ҵ���
        private string _clinic_office_flag;     //�ٴ����ұ�־ CD:������� RY��������
        private int? _cur_serial_num;           //������ˮ��
        private string _study_uid_header;       //���UIDͷ
        private string _clinic_office_pycode;   //�ٴ��������Ƽ���

        /// <summary>
        ///�ٴ�����ID 
        /// </summary>
        public int? CLINIC_OFFICE_ID
        {
            set { _clinic_office_id = value; }
            get { return _clinic_office_id; }
        }

        /// <summary>
        /// �ٴ���������
        /// </summary>
        public string CLINIC_OFFICE
        {
            set { _clinic_office = value; }
            get { return _clinic_office; }
        }

        /// <summary>
        /// ������ԴID
        /// </summary>
        public int? PATIENT_SOURCE_ID
        {
            set { _patient_source_id = value; }
            get { return _patient_source_id; }
        }

        /// <summary>
        /// �ٴ����Ҵ���
        /// </summary>
        public string CLINIC_OFFICE_CODE
        {
            set { _clinic_office_code = value; }
            get { return _clinic_office_code; }
        }

        /// <summary>
        /// �ٴ����ұ�־
        /// </summary>
        public string CLINIC_OFFICE_FLAG
        {
            set { _clinic_office_flag = value; }
            get { return _clinic_office_flag; }
        }

        /// <summary>
        /// ������ˮ��
        /// </summary>
        public int? CUR_SERIAL_NUM
        {
            set { _cur_serial_num = value; }
            get { return _cur_serial_num; }
        }

        /// <summary>
        /// ���UIDͷ
        /// </summary>
        public string STUDY_UID_HEADER
        {
            set { _study_uid_header = value; }
            get { return _study_uid_header; }
        }

        /// <summary>
        /// �ٴ�����ƴ������
        /// </summary>
        public string CLINIC_OFFICE_PYCODE
        {
            set { _clinic_office_pycode = value; }
            get { return _clinic_office_pycode; }
        }
        #endregion Model

    }
}