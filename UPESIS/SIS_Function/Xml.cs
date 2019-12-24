using System;
using System.IO;
using System.Xml;
using System.Text;

namespace SIS_Function
{
	/// <summary>
	/// xml ��ժҪ˵����
	/// </summary>
	public class Xml
	{
		private FileStream _fs;
		private XmlTextWriter _w;
		private StringWriter _sw;

		public Xml()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ����XML�ļ�
		/// </summary>
		/// <param name="filePath">XML�ļ�·��</param>
		public void CreateXml(string filePath)
		{
			_fs = new FileStream(filePath,FileMode.Create);
			_w = new XmlTextWriter(_fs,Encoding.Default);
		}

		/// <summary>
		/// ����XML�ַ���
		/// </summary>
		public void CreateXml()
		{
			_sw = new StringWriter();
			_w = new XmlTextWriter(_sw);
		}

		/// <summary>
		/// д���ļ�ͷ
		/// </summary>
		/// <param name="head">�ļ�ͷ</param>
		public void WriteStartDocument(string head)
		{
			_w.WriteStartDocument();
			_w.WriteStartElement(head);
		}

		/// <summary>
		/// д���ļ�β
		/// </summary>
		public void WriteEndDocument()
		{
			_w.WriteEndDocument();
			_w.Flush();
		}

		/// <summary>
		/// �ر��ļ���
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
		/// д��XML����
		/// </summary>
		/// <param name="count">����</param>
		/// <param name="head">�ļ�ͷ</param>
		/// <param name="FIDX">�ֶ����</param>
		/// <param name="FEDN">�ֶ���</param>
		/// <param name="VALUE">����</param>
		/// <param name="nodes">�ֶ�������</param>
		/// <param name="contents">��������</param>
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
		/// ����XML�ַ���
		/// </summary>
		/// <param name="count">����</param>
		/// <param name="head">�ļ�ͷ</param>
		/// <param name="FIDX">�ֶ����</param>
		/// <param name="FEDN">�ֶ���</param>
		/// <param name="VALUE">����</param>
		/// <param name="nodes">�ֶ�������</param>
		/// <param name="contents">��������</param>
		/// <returns>����XML�ַ���</returns>
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
