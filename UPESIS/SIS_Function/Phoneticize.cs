using System;
using System.IO;
using System.Text;

namespace SIS_Function
{
	/// <summary>
	/// Phoneticize ��ժҪ˵����
	/// </summary>
	public class Phoneticize
	{
		public  string _filepath = @"D:\PHONEA1.txt";
		
		/// <summary>
		/// ����ƴ�������ļ�
		/// </summary>
		public Phoneticize(string file_path)
		{
			if(file_path.Trim() != "")
			{
				_filepath = file_path.Trim();
			}
		}	

		/// <summary>
		/// ����ת��ƴ��
		/// </summary>
		/// <param name="convertstr">ת������</param>
		/// <param name="isconvertall">�Ƿ�ת��Ϊȫƴ,trueΪȫƴ,falseΪƴ������ĸ</param>
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
		/// �ж��Ƿ�Ϊ����
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public bool isChinese(string str)
		{
			int chfrom = System.Convert.ToInt32("4e00", 16);    //��Χ��0x4e00��0x9fff��ת����int��chfrom��chend��
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
