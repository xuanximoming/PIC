using System;
using System.Runtime.InteropServices;
using System.Collections;

namespace SIS_Function.GatherCard
{
	
	public struct BLOCKINFO
	{
        //short iType;        // ͼ������(��BK\BM)
        //short iWidth;       // ���
        //short iHeight;      // �߶�
        //short iBitCount;    // ��Ԫλ��
        //short iFormType;    // ͼ���ʽ
        //short iBlockStep;   // ͼ�����ĵ���
        //short iHiStep;      // ͼ�����ĸ���
        //short lTotal;       // ͼ����֡���ĵ���
        //short iHiTotal;     // ͼ����֡���ĸ���
        //short iInterval;    // ͼ��֡�����
//		LPBTYPE lpBits;     // ͼ������ָ��/�ļ�·����
//		LPBTYPE lpExtra;    // �������ݣ����ɫ���)ָ��
	}
	
	public struct SEQINFO
	{
        //short iType;        // �ļ�����
        //short iWidth;       // ���
        //short iHeight;      // �߶�
        //short iBitCount;    // ��Ԫλ��
        //short iFormType;    // ͼ���ʽ
        //short lBlockStep;   // ͼ�����ĵ���
        //short iHiStep;      // ͼ�����ĸ���
        //short lTotal;       // ͼ����֡���ĵ���
        //short lHiTotal;     // ͼ����֡���ĸ���
        //short iInterval;    // ͼ��֡�����
	}

    public class OK
	{
		#region ��������
		/// <summary>
		/// �򿪿�
		/// </summary>
		/// <param name="iIndex">����������</param>
		/// <returns></returns>
		[DllImport("OKAPI32.dll")]
		public static extern IntPtr okOpenBoard(ref int iIndex);

		/// <summary>
		/// �رտ�
		/// </summary>
		/// <param name="hBoard">���ÿ��ľ��</param>
		/// <returns></returns>
		[DllImport("OKAPI32.dll")]
		public static extern bool okCloseBoard(IntPtr hBoard);
		#endregion ��������

		#region ϵͳ��Ϣ
		/// <summary>
		/// ��������õĴ�����
		/// </summary>
		/// <returns></returns>
		[DllImport("OKAPI32.dll")]
		public static extern long okGetLastError();

		[DllImport("OKAPI32.dll")]
		public static extern long okGetBufferSize(IntPtr hBoard, ref System.UInt32 lpLinear, ref System.UInt32 dwSize);
		
		[DllImport("OKAPI32.dll")]
		public static extern System.IntPtr okGetBufferAddr(IntPtr hBoard, long lNoFrame);

		[DllImport("OKAPI32.dll")]
		public static extern System.UInt32 okGetTargetInfo(IntPtr hBoard, int tgt, int lNoframe, ref int width, ref int height, ref int stride);

		[DllImport("OKAPI32.dll")]
		public static extern short okGetTypeCode(IntPtr hBoard, string lpBoardName);
		#endregion ϵͳ��Ϣ

		#region ���òɼ�����
		[DllImport("OKAPI32.dll")]
		public static extern long okSetTargetRect(IntPtr hBoard, Int32 target, int lpTgtRect);

		/// <summary>
		/// ���û��Դ���
		/// </summary>
		/// <param name="hBoard">���ľ��</param>
		/// <param name="hWnd">���ھ��</param>
		/// <returns></returns>
		[DllImport("OKAPI32.dll")]
		public static extern bool okSetToWndRect(IntPtr hBoard, IntPtr hWnd);

		[DllImport("OKAPI32.dll")]
		public static extern long okSetVideoParam(IntPtr hBoard, Int32 wParam, long lParam);
		
		[DllImport("OKAPI32.dll")]
		public static extern long okSetCaptureParam(IntPtr hBoard, Int32 wParam, int lParam);

		#endregion ���òɼ�����

		#region ��Ƶ�ɼ�
		[DllImport("OKAPI32.dll")]
		public static extern IntPtr okCaptureThread(IntPtr hBoard, int Dest, long lStart, long lNoFrame);

		[DllImport("OKAPI32.dll")]
		public static extern bool okCaptureTo(IntPtr hBoard, int target, long wParam, int lParam);

		[DllImport("OKAPI32.dll")]
		public static extern bool okCaptureByBuffer(IntPtr hBoard, int dest, int start, int num);

		[DllImport("OKAPI32.dll")]
		public static extern bool okCaptureByBuffer(IntPtr hBoard, string dest, int start, int num);

        [DllImport("OKAPI32.dll")]
        public static extern bool okCaptureByBufferEx(IntPtr hBoard,int fileset, string dest, int start, int num);

		[DllImport("OKAPI32.dll")]
		public static extern bool okSetSeqCallback(IntPtr hBoard, BeginProc beginproc, SeqProgress seq, EndProc endproc);
		
		[DllImport("OKAPI32.dll")]
		public static extern bool okStopCapture(IntPtr hBoard);
		
		/// <summary>
		/// �Զ�����Ժ���
		/// </summary>
		/// <param name="hBoard">���ľ��</param>
		/// <param name="beginproc">��ʼ�ɼ�ʱ�ص�ζ�ĺ���</param>
		/// <param name="seqprogress">ÿ�ɼ���һ֡�ͻص��ĺ���</param>
		/// <param name="endproc">��ɲɼ���ص��ĺ���</param>
		/// <returns></returns>
//		[DllImport("OKAPI32.dll")]
//		public static extern bool okSetSeqCallback(IntPtr hBoard, BeginProc beginproc, SeqProgress seq, EndProc endproc);

		[DllImport("OKAPI32.dll")]
		public static extern long okSetConvertParam(IntPtr hBoard, string wParam, int lParam);

		[DllImport("OKAPI32.dll")]
		public static extern long okGetCaptureStatus(IntPtr hBoard, bool bWait);
		#endregion ��Ƶ�ɼ�

		#region ���ݴ���
		[DllImport("OKAPI32.dll")]
		public static extern long okTransferRect(IntPtr hBoard, int dest, long first, int src, long start, long num);

		[DllImport("OKAPI32.dll")]
		public static extern long okReadRect(IntPtr hBoard, int src, int start, IntPtr lpBuf);

		[DllImport("OKAPI32.dll")]
		public static extern long okWriteRect(IntPtr hBoard, int dest, long start, byte[] lpBuf);
		#endregion ���ݴ���

		#region �ļ���д
		[DllImport("OKAPI32.dll")]
		public static extern long okSaveImageFile(IntPtr hBoard, string szFileName, int first, int target, int start, int num);

		[DllImport("OKAPI32.dll")]
		public static extern long okLoadImageFile(IntPtr hBoard, string szFileName, int first, long target, int start, int num);
		#endregion �ļ���д

		public delegate bool BeginProc(IntPtr hBoard);
		public delegate bool SeqProgress(IntPtr hBoard, int No);
		public delegate bool EndProc(IntPtr hBoard);
        public BeginProc begin;
        public SeqProgress seq;
        public EndProc end;

		/// <summary>
		/// ��ʼ�ɼ�ʱ�ص�ζ�ĺ���
		/// </summary>
		/// <param name="hBoard"></param>
		/// <returns></returns>
		public static bool beginproc(IntPtr hBoard)
		{
			return true;
		}

		/// <summary>
		/// ÿ�ɼ���һ֡�ͻص��ĺ���
		/// </summary>
		/// <param name="hBoard"></param>
		/// <param name="No"></param>
		/// <returns></returns>
        //public bool seqprogress(IntPtr hBoard, int No)
        //{
        //    long temp;
        //    IntPtr a = System.Runtime.InteropServices.Marshal.AllocHGlobal(Convert.ToInt32(f.size));
        //    temp = ok.okReadRect(hBoard, 1, no, a);
        //    System.Drawing.Bitmap bm = new Bitmap(f.width, f.height, f.stride, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, a);

        //    f.pictureBox1.Image = bm;

        //    return true;
        //}
		public static byte[] lpBuf;

		/// <summary>
		/// ��ɲɼ���ص��ĺ���
		/// </summary>
		/// <param name="hBoard"></param>
		/// <returns></returns>
		public static bool endproc(IntPtr hBoard)
		{
			return true;
		}

		public IntPtr OpenBoard(int i)
		{
            IntPtr a = OK.okOpenBoard(ref i);
			return a;
		}

		public long lastError()
		{
            long a = OK.okGetLastError();
			return a;
		}

		public long SetTargetRect(IntPtr hBoard, int target, int lpTgtRect)
		{
            return OK.okSetTargetRect(hBoard, target, lpTgtRect);
		}

		public bool SetToWndRect(IntPtr hBoard, IntPtr hWnd)
		{
            return OK.okSetToWndRect(hBoard, hWnd);
		}

		public bool CaptureTo(IntPtr hBoard, int target, long wParam, int lParam)
		{
            return OK.okCaptureTo(hBoard, target, wParam, lParam);
		}

		public void CloseBoard(IntPtr hBoard)
		{
//			ok.okStopCapture(hBoard);
            OK.okCloseBoard(hBoard);
		}

        public bool SetSeqCallback(IntPtr hBoard, BeginProc beginproc, SeqProgress seq, EndProc endproc)
        {
            return OK.okSetSeqCallback(hBoard, beginproc, seq, endproc);
        }

//		public long ReadRect(IntPtr hBoard, int src, long start, byte[] lpBuf)
//		{
//			return ok.okReadRect(hBoard,src,start,lpBuf);
//		}

		public long WriteRect(IntPtr hBoard, int dest, long start, byte[] lpBuf)
		{
            return OK.okWriteRect(hBoard, dest, start, lpBuf);
		}

		public long SaveImageFile(IntPtr hBoard, string szFileName, int first, int target, int start, int num)
		{
            return OK.okSaveImageFile(hBoard, szFileName, first, target, start, num);
		}

		public long LoadImageFile(IntPtr hBoard, string szFileName, int first, long target, int start, int num)
		{
            return OK.okLoadImageFile(hBoard, szFileName, first, target, start, num);
		}

		public bool GetTargetInfo(IntPtr hBoard, int tgt, int lNoframe, ref short width, ref short height, ref int stride)
		{
//			byte [] buffer;
//			buffer = (System.by)ok.okGetTargetInfo(hBoard,1,0,ref width,ref height,ref stride);

			return true;
		}

	}
}
