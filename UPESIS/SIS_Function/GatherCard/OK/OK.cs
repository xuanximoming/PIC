using System;
using System.Runtime.InteropServices;
using System.Collections;

namespace SIS_Function.GatherCard
{
	
	public struct BLOCKINFO
	{
        //short iType;        // 图象类型(如BK\BM)
        //short iWidth;       // 宽度
        //short iHeight;      // 高度
        //short iBitCount;    // 象元位数
        //short iFormType;    // 图象格式
        //short iBlockStep;   // 图象块跨距的低字
        //short iHiStep;      // 图象块跨距的高字
        //short lTotal;       // 图象总帧数的低字
        //short iHiTotal;     // 图象总帧数的高字
        //short iInterval;    // 图象帧间隔数
//		LPBTYPE lpBits;     // 图象数据指针/文件路径名
//		LPBTYPE lpExtra;    // 额外数据（如调色板等)指针
	}
	
	public struct SEQINFO
	{
        //short iType;        // 文件类型
        //short iWidth;       // 宽度
        //short iHeight;      // 高度
        //short iBitCount;    // 象元位数
        //short iFormType;    // 图象格式
        //short lBlockStep;   // 图象块跨距的低字
        //short iHiStep;      // 图象块跨距的高字
        //short lTotal;       // 图象总帧数的低字
        //short lHiTotal;     // 图象总帧数的高字
        //short iInterval;    // 图象帧间隔数
	}

    public class OK
	{
		#region 基本功能
		/// <summary>
		/// 打开卡
		/// </summary>
		/// <param name="iIndex">卡的索引号</param>
		/// <returns></returns>
		[DllImport("OKAPI32.dll")]
		public static extern IntPtr okOpenBoard(ref int iIndex);

		/// <summary>
		/// 关闭卡
		/// </summary>
		/// <param name="hBoard">引用卡的句柄</param>
		/// <returns></returns>
		[DllImport("OKAPI32.dll")]
		public static extern bool okCloseBoard(IntPtr hBoard);
		#endregion 基本功能

		#region 系统信息
		/// <summary>
		/// 获得最后调用的错误码
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
		#endregion 系统信息

		#region 设置采集参数
		[DllImport("OKAPI32.dll")]
		public static extern long okSetTargetRect(IntPtr hBoard, Int32 target, int lpTgtRect);

		/// <summary>
		/// 设置回显窗口
		/// </summary>
		/// <param name="hBoard">卡的句柄</param>
		/// <param name="hWnd">窗口句柄</param>
		/// <returns></returns>
		[DllImport("OKAPI32.dll")]
		public static extern bool okSetToWndRect(IntPtr hBoard, IntPtr hWnd);

		[DllImport("OKAPI32.dll")]
		public static extern long okSetVideoParam(IntPtr hBoard, Int32 wParam, long lParam);
		
		[DllImport("OKAPI32.dll")]
		public static extern long okSetCaptureParam(IntPtr hBoard, Int32 wParam, int lParam);

		#endregion 设置采集参数

		#region 视频采集
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
		/// 自定义回显函数
		/// </summary>
		/// <param name="hBoard">卡的句柄</param>
		/// <param name="beginproc">开始采集时回调味的函数</param>
		/// <param name="seqprogress">每采集完一帧就回调的函数</param>
		/// <param name="endproc">完成采集后回调的函数</param>
		/// <returns></returns>
//		[DllImport("OKAPI32.dll")]
//		public static extern bool okSetSeqCallback(IntPtr hBoard, BeginProc beginproc, SeqProgress seq, EndProc endproc);

		[DllImport("OKAPI32.dll")]
		public static extern long okSetConvertParam(IntPtr hBoard, string wParam, int lParam);

		[DllImport("OKAPI32.dll")]
		public static extern long okGetCaptureStatus(IntPtr hBoard, bool bWait);
		#endregion 视频采集

		#region 数据传送
		[DllImport("OKAPI32.dll")]
		public static extern long okTransferRect(IntPtr hBoard, int dest, long first, int src, long start, long num);

		[DllImport("OKAPI32.dll")]
		public static extern long okReadRect(IntPtr hBoard, int src, int start, IntPtr lpBuf);

		[DllImport("OKAPI32.dll")]
		public static extern long okWriteRect(IntPtr hBoard, int dest, long start, byte[] lpBuf);
		#endregion 数据传送

		#region 文件读写
		[DllImport("OKAPI32.dll")]
		public static extern long okSaveImageFile(IntPtr hBoard, string szFileName, int first, int target, int start, int num);

		[DllImport("OKAPI32.dll")]
		public static extern long okLoadImageFile(IntPtr hBoard, string szFileName, int first, long target, int start, int num);
		#endregion 文件读写

		public delegate bool BeginProc(IntPtr hBoard);
		public delegate bool SeqProgress(IntPtr hBoard, int No);
		public delegate bool EndProc(IntPtr hBoard);
        public BeginProc begin;
        public SeqProgress seq;
        public EndProc end;

		/// <summary>
		/// 开始采集时回调味的函数
		/// </summary>
		/// <param name="hBoard"></param>
		/// <returns></returns>
		public static bool beginproc(IntPtr hBoard)
		{
			return true;
		}

		/// <summary>
		/// 每采集完一帧就回调的函数
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
		/// 完成采集后回调的函数
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
