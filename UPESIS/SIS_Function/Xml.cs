using System;
using System.IO;
using System.Xml;
using System.Text;

namespace SIS_Function
{
	/// <summary>
	/// xml 的摘要说明。
	/// </summary>
	public class Xml
	{
		private FileStream _fs;
		private XmlTextWriter _w;
		private StringWriter _sw;

		public Xml()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 创建XML文件
		/// </summary>
		/// <param name="filePath">XML文件路径</param>
		public void CreateXml(string filePath)
		{
			_fs = new FileStream(filePath,FileMode.Create);
			_w = new XmlTextWriter(_fs,Encoding.Default);
		}

		/// <summary>
		/// 创建XML字符串
		/// </summary>
		public void CreateXml()
		{
			_sw = new StringWriter();
			_w = new XmlTextWriter(_sw);
		}

		/// <summary>
		/// 写入文件头
		/// </summary>
		/// <param name="head">文件头</param>
		public void WriteStartDocument(string head)
		{
			_w.WriteStartDocument();
			_w.WriteStartElement(head);
		}

		/// <summary>
		/// 写入文件尾
		/// </summary>
		public void WriteEndDocument()
		{
			_w.WriteEndDocument();
			_w.Flush();
		}

		/// <summary>
		/// 关闭文件流
		/// </summary>
		public void CloseFile()
		{
			_fs.Close();
		}

		public void WriteElement(string head, string node, string content)
		{
			_w.WriteStartElement(head);
			_w.WriteElementString(node,content);
			_w.WriteEndElement();
		}

		public void WriteElement(string head, string [] nodes, string [] contents)
		{
			_w.WriteStartElement(head);
			for (int i=0; i<nodes.Length; i++)
			{
				_w.WriteElementString(nodes[i],contents[i]);
			}
			_w.WriteEndElement();
		}

		/// <summary>
		/// 写入XML内容
		/// </summary>
		/// <param name="count">个数</param>
		/// <param name="head">文件头</param>
		/// <param name="FIDX">字段序号</param>
		/// <param name="FEDN">字段名</param>
		/// <param name="VALUE">内容</param>
		/// <param name="nodes">字段名数组</param>
		/// <param name="contents">内容数组</param>
		public void WriteElement(int count, string head, string FIDX, string FEDN, string VALUE, string [] nodes, string [] contents)
		{
			for (int i=0; i<count; i++)
			{
				_w.WriteStartElement(head);
				_w.WriteElementString(FIDX,Convert.ToString(i+1));
				_w.WriteElementString(FEDN,nodes[i]);
				_w.WriteElementString(VALUE,contents[i]);
				_w.WriteEndElement();
			}
		}

		/// <summary>
		/// 生成XML字符串
		/// </summary>
		/// <param name="count">个数</param>
		/// <param name="head">文件头</param>
		/// <param name="FIDX">字段序号</param>
		/// <param name="FEDN">字段名</param>
		/// <param name="VALUE">内容</param>
		/// <param name="nodes">字段名数组</param>
		/// <param name="contents">内容数组</param>
		/// <returns>返回XML字符串</returns>
		public string WriteXMLString(int count, string xmlhead, string head, string FIDX, string FEDN, string VALUE, string [] nodes, string [] contents)
		{
			string result = "";
			this.CreateXml();
			this.WriteStartDocument(xmlhead);
			for (int i=0; i<count; i++)
			{
				_w.WriteStartElement(head);
				_w.WriteElementString(FIDX,Convert.ToString(i+1));
				_w.WriteElementString(FEDN,nodes[i]);
				_w.WriteElementString(VALUE,contents[i]);
				_w.WriteEndElement();
			}
			this.WriteEndDocument();
			return result = _sw.ToString();
		}
	}
}
