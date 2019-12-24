using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Update
{
    /// <summary>
    /// 类名：读写INI配置文件
    /// </summary>
    public class ClsIni
    {
        private string m_Path;     //INI文件名（完整路径）
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public ClsIni(string p_iniPath)
        {
            this.m_Path = p_iniPath;
        }

        /// <summary>
        /// 功能：写INI文件
        /// </summary>
        /// <param name="p_Section"></param>
        /// <param name="p_Key">要写入的键</param>
        /// <param name="p_Value">写入键对应的值</param>
        public void IniWriteValue(string p_Section, string p_Key, string p_Value)
        {
            WritePrivateProfileString(p_Section, p_Key, p_Value, this.m_Path);
        }


        /// <summary>
        /// 功能：读取INI文件
        /// </summary>
        /// <param name="p_Section"></param>
        /// <param name="p_Key"></param>
        /// <returns>返回对应键的字符串值</returns>
        public string IniReadValue(string p_Section, string p_Key)
        {
            StringBuilder strStr = new StringBuilder(255);
            GetPrivateProfileString(p_Section, p_Key, "", strStr, 255, this.m_Path);
            return strStr.ToString();
        }
    }
}
