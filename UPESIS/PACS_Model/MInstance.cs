using System;
using System.Collections.Generic;
using System.Text;

namespace PACS_Model
{
        /// <summary>
        /// ʵ����INSTANCE��ͼ���¼��
        /// </summary>
        [Serializable]
    public class MInstance : ILL.IModel
        {
            public MInstance()
            { }
            #region Model
            private int _instance_key;          //ʵ�����������ݿ��Զ�����
            private string _sop_instance_uid;   //ʵ��UID
            private string _sop_class_uid;      //���UID
            private int? _series_key;           //ͼ����������
            private int? _study_key;            //�������
            private string _origin_aetitle;     //�������ݵ�ԭʼ�豸
            private int? _key_mark;             //��ͼ���־
            private int? _ordinal;              //���к�
            private int? _volume_key;           //����
            private string _host_name;          //������
            private string _path_name;          //ͼ��·����
            private string _file_name;          //�ļ�����һ���ͼ��·����һ��
            private string _format;             //�ļ���ʽ
            private int? _checked;              //��֤��־
            private int? _instance_no;          //ʵ�����
            private int? _instance_index;       //ʵ������

            /// <summary>
            ///ʵ������ 
            /// </summary>
            public int INSTANCE_KEY
            {
                set { _instance_key = value; }
                get { return _instance_key; }
            }

            /// <summary>
            /// ʵ��UID
            /// </summary>
            public string SOP_INSTANCE_UID
            {
                set { _sop_instance_uid = value; }
                get { return _sop_instance_uid; }
            }

            /// <summary>
            /// ���UID
            /// </summary>
            public string SOP_CLASS_UID
            {
                set { _sop_class_uid = value; }
                get { return _sop_class_uid; }
            }

            /// <summary>
            /// ͼ����������
            /// </summary>
            public int? SERIES_KEY
            {
                set { _series_key = value; }
                get { return _series_key; }
            }

            /// <summary>
            ///������� 
            /// </summary>
            public int? STUDY_KEY
            {
                set { _study_key = value; }
                get { return _study_key; }
            }

            /// <summary>
            /// ����ͼ���ԭʼ�豸
            /// </summary>
            public string ORIGIN_AETITLE
            {
                set { _origin_aetitle = value; }
                get { return _origin_aetitle; }
            }

            /// <summary>
            /// ��ͼ���־
            /// </summary>
            public int? KEY_MARK
            {
                set { _key_mark = value; }
                get { return _key_mark; }
            }

            /// <summary>
            /// ���к�
            /// </summary>
            public int? ORDINAL
            {
                set { _ordinal = value; }
                get { return _ordinal; }
            }

            /// <summary>
            /// ���ֵ
            /// </summary>
            public int? VOLUME_KEY
            {
                set { _volume_key = value; }
                get { return _volume_key; }
            }

            /// <summary>
            /// ������
            /// </summary>
            public string HOST_NAME
            {
                set { _host_name = value; }
                get { return _host_name; }
            }

            /// <summary>
            /// ·����
            /// </summary>
            public string PATH_NAME
            {
                set { _path_name = value; }
                get { return _path_name; }
            }

            /// <summary>
            /// �ļ���
            /// </summary>
            public string FILE_NAME
            {
                set { _file_name = value; }
                get { return _file_name; }
            }

            /// <summary>
            /// ͼ���ʽ
            /// </summary>
            public string FORMAT
            {
                set { _format = value; }
                get { return _format; }
            }

            /// <summary>
            /// ��֤��־
            /// </summary>
            public int? CHECKED
            {
                set { _checked = value; }
                get { return _checked; }
            }

            /// <summary>
            /// ʵ�����
            /// </summary>
            public int? INSTANCE_NO
            {
                set { _instance_no = value; }
                get { return _instance_no; }
            }

            /// <summary>
            /// ʵ������
            /// </summary>
            public int? INSTANCE_INDEX
            {
                set { _instance_index = value; }
                get { return _instance_index; }
            }

            #endregion Model
        }
}