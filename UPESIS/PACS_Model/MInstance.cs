using System;
using System.Collections.Generic;
using System.Text;

namespace PACS_Model
{
        /// <summary>
        /// 实体类INSTANCE，图像记录表
        /// </summary>
        [Serializable]
    public class MInstance : ILL.IModel
        {
            public MInstance()
            { }
            #region Model
            private int _instance_key;          //实例主键，数据库自动产生
            private string _sop_instance_uid;   //实例UID
            private string _sop_class_uid;      //类别UID
            private int? _series_key;           //图像序列主键
            private int? _study_key;            //检查主键
            private string _origin_aetitle;     //产生数据的原始设备
            private int? _key_mark;             //主图像标志
            private int? _ordinal;              //序列号
            private int? _volume_key;           //卷标号
            private string _host_name;          //主机名
            private string _path_name;          //图像路径名
            private string _file_name;          //文件名，一般和图像路径名一致
            private string _format;             //文件格式
            private int? _checked;              //验证标志
            private int? _instance_no;          //实例编号
            private int? _instance_index;       //实例索引

            /// <summary>
            ///实例主键 
            /// </summary>
            public int INSTANCE_KEY
            {
                set { _instance_key = value; }
                get { return _instance_key; }
            }

            /// <summary>
            /// 实例UID
            /// </summary>
            public string SOP_INSTANCE_UID
            {
                set { _sop_instance_uid = value; }
                get { return _sop_instance_uid; }
            }

            /// <summary>
            /// 类别UID
            /// </summary>
            public string SOP_CLASS_UID
            {
                set { _sop_class_uid = value; }
                get { return _sop_class_uid; }
            }

            /// <summary>
            /// 图像序列主键
            /// </summary>
            public int? SERIES_KEY
            {
                set { _series_key = value; }
                get { return _series_key; }
            }

            /// <summary>
            ///检查主键 
            /// </summary>
            public int? STUDY_KEY
            {
                set { _study_key = value; }
                get { return _study_key; }
            }

            /// <summary>
            /// 产生图像的原始设备
            /// </summary>
            public string ORIGIN_AETITLE
            {
                set { _origin_aetitle = value; }
                get { return _origin_aetitle; }
            }

            /// <summary>
            /// 主图像标志
            /// </summary>
            public int? KEY_MARK
            {
                set { _key_mark = value; }
                get { return _key_mark; }
            }

            /// <summary>
            /// 序列号
            /// </summary>
            public int? ORDINAL
            {
                set { _ordinal = value; }
                get { return _ordinal; }
            }

            /// <summary>
            /// 卷标值
            /// </summary>
            public int? VOLUME_KEY
            {
                set { _volume_key = value; }
                get { return _volume_key; }
            }

            /// <summary>
            /// 主机名
            /// </summary>
            public string HOST_NAME
            {
                set { _host_name = value; }
                get { return _host_name; }
            }

            /// <summary>
            /// 路径名
            /// </summary>
            public string PATH_NAME
            {
                set { _path_name = value; }
                get { return _path_name; }
            }

            /// <summary>
            /// 文件名
            /// </summary>
            public string FILE_NAME
            {
                set { _file_name = value; }
                get { return _file_name; }
            }

            /// <summary>
            /// 图像格式
            /// </summary>
            public string FORMAT
            {
                set { _format = value; }
                get { return _format; }
            }

            /// <summary>
            /// 验证标志
            /// </summary>
            public int? CHECKED
            {
                set { _checked = value; }
                get { return _checked; }
            }

            /// <summary>
            /// 实例编号
            /// </summary>
            public int? INSTANCE_NO
            {
                set { _instance_no = value; }
                get { return _instance_no; }
            }

            /// <summary>
            /// 实例主键
            /// </summary>
            public int? INSTANCE_INDEX
            {
                set { _instance_index = value; }
                get { return _instance_index; }
            }

            #endregion Model
        }
}