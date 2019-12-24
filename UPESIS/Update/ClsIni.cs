using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Update
{
    /// <summary>
    /// ��������дINI�����ļ�
    /// </summary>
    public class ClsIni
    {
        private string m_Path;     //INI�ļ���������·����
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public ClsIni(string p_iniPath)
        {
            this.m_Path = p_iniPath;
        }

        /// <summary>
        /// ���ܣ�дINI�ļ�
        /// </summary>
        /// <param name="p_Section"></param>
        /// <param name="p_Key">Ҫд��ļ�</param>
        /// <param name="p_Value">д�����Ӧ��ֵ</param>
        public void IniWriteValue(string p_Section, string p_Key, string p_Value)
        {
            WritePrivateProfileString(p_Section, p_Key, p_Value, this.m_Path);
        }


        /// <summary>
        /// ���ܣ���ȡINI�ļ�
        /// </summary>
        /// <param name="p_Section"></param>
        /// <param name="p_Key"></param>
        /// <returns>���ض�Ӧ�����ַ���ֵ</returns>
        public string IniReadValue(string p_Section, string p_Key)
        {
            StringBuilder strStr = new StringBuilder(255);
            GetPrivateProfileString(p_Section, p_Key, "", strStr, 255, this.m_Path);
            return strStr.ToString();
        }
    }
}
