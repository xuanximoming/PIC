using System;
using System.IO;
using System.Text;

namespace SIS_Function
{
	/// <summary>
	/// Phoneticize 的摘要说明。
	/// </summary>
	public class Phoneticize
	{
		public  string _filepath = @"D:\PHONEA1.txt";
		
		/// <summary>
		/// 中文拼音对照文件
		/// </summary>
		public Phoneticize(string file_path)
		{
			if(file_path.Trim() != "")
			{
				_filepath = file_path.Trim();
			}
		}	

		/// <summary>
		/// 中文转换拼音
		/// </summary>
		/// <param name="convertstr">转换内容</param>
		/// <param name="isconvertall">是否转换为全拼,true为全拼,false为拼音首字母</param>
		/// <returns></returns>
		public string Convert(string convertstr, bool isconvertall)
		{
			string a = "",b = "",c = "";
			for (int i=0; i<convertstr.Length; i++)
			{
				a = convertstr.Substring(i,1);
				if (isChinese(a))
				{
					System.IO.StreamReader fileRead = new StreamReader(_filepath,System.Text.Encoding.Default);;
					for (string str = fileRead.ReadLine(); str != null; str = fileRead.ReadLine())
					{
						b = str.Substring(0,1);
						if (a.Equals(b))
						{
							if (isconvertall)
								c += str.Substring(1,str.Length-1).Trim();
							else
								c += str.Substring(1,1).Trim();
						}
					}
					fileRead.Close();
                    if (isconvertall)
                        c += " ";
				}
				else
				{
					c += a;
				}
			}
			return c;
		}
		
		/// <summary>
		/// 判断是否为中文
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public bool isChinese(string str)
		{
			int chfrom = System.Convert.ToInt32("4e00", 16);    //范围（0x4e00～0x9fff）转换成int（chfrom～chend）
			int chend = System.Convert.ToInt32("9fff", 16);
			char a = System.Convert.ToChar(str);
			int code = System.Convert.ToInt32(a);
			
			if (code >= chfrom && code <= chend)     
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
