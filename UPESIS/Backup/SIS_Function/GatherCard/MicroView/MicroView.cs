using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SIS_Function.GatherCard
{
    public class MicroView
    {
        public MicroView() { }

        #region COMMON

        #region enum
        public enum RUNOPER
        {
            MVSTOP = 0, // MVSTOP: 停止工作；
            MVRUN = 1, // MVRUN: 卡开始工作；
            MVPAUSE = 2, //MVPAUSE: 暂停卡的工作；
            MVQUERYSTATU = 3, //MVQUERYSTATU: 查询卡的当前状态，
            MVERROR = 4 //MVERROR:为错误的状态。
        }

        public enum VIDEOSOURCE
        {
            COMPOSITE = 0,
            SVIDEO = 1,
            R_G_B = 2,
            Y_CR_CB = 3
        }

        public enum VIDEOSTANDARD
        {
            PAL = 0,
            NTSC = 1,
            OTHER = 2/*SCAM*/
        }

        public enum RGBVECTOR
        {
            R_LUM = 0,
            G_LUM = 1,
            B_LUM = 2,
            R_COARSE = 3,
            G_COARSE = 4,
            B_COARSE = 5
        }

        public enum MV_PARAMTER
        {
            GET_BOARD_TYPE = 0,
            GET_GRAPHICAL_INTERFACE = 1,
            SET_GARBIMAGEINFO = 2,
            SET_DISPIMAGEINFO = 3,
            BUFFERTYPE = 4,
            DEFAULT_PARAM = 5,

            // 控制显示的
            DISP_PRESENCE = 6,
            DISP_WHND = 7,
            DISP_TOP = 8,
            DISP_LEFT = 9,
            DISP_HEIGHT = 10,
            DISP_WIDTH = 11,

            // 控制A/D的调节参数
            ADJUST_STANDARD = 12,
            ADJUST_SOURCE = 13,
            ADJUST_CHANNEL = 14,
            ADJUST_LUMINANCE = 15,
            ADJUST_CHROMINANE = 16,
            ADJUST_SATURATION = 17,
            ADJUST_HUE = 18,
            ADJUST_CONTRAST = 19,

            //支持RGB卡
            ADJUST_R_LUM = 20,
            ADJUST_G_LUM = 21,
            ADJUST_B_LUM = 22,
            ADJUST_R_COARSE = 23,
            ADJUST_G_COARSE = 24,
            ADJUST_B_COARSE = 25,

            // 控制板卡的捕获参数
            GRAB_XOFF = 60,
            GRAB_YOFF = 61,
            GRAB_HEIGHT = 62,
            GRAB_WIDTH = 63,
            GRAB_IN_HEIGHT = 64,
            GRAB_IN_WIDTH = 65,
            GRAB_BITDESCRIBE = 66,
            GRAB_WHOLEWIDTH = 67,

            // 控制板卡的工作参数
            WORK_UPDOWN = 34,
            WORK_FLIP = 35,
            WORK_SKIP = 36,
            WORK_SYNC = 37,
            WORK_INTERLACE = 38,
            WORK_ISBLACK = 39,
            WORK_FIELD = 40,
            OSD_MODE = 41,

            //支持V500系列卡
            TENBIT_MODE = 42,
            OUTPUT_VIDEO = 43,
            FILERSELECT1 = 44,
            FILERSELECT2 = 45,

            // 控制板卡的捕获参数(保留,兼容老版本)
            GARB_XOFF = 26,
            GARB_YOFF = 27,
            GARB_HEIGHT = 28,
            GARB_WIDTH = 29,
            GARB_IN_HEIGHT = 30,
            GARB_IN_WIDTH = 31,
            GARB_BITDESCRIBE = 32,
            GARB_WHOLEWIDTH = 33,


            //shen add 
            //支持卡类型MVBOARD2.h中所有卡
            ADJUST_BACKCOLORKEY = 200,
            DISP_FLIP = 201,
            IMAGE_PROCESS = 202,
            VIDEO_SINGLE = 203,
            GET_BOARD_PASS = 204,
            //20050407新增
            RESTARTCAPTURE = 300,
            RESTOPCAPTURE = 301,
            //20060315
            GRAB_AUTOFIELD = 205,
        }

        public enum CALLBACKTYPE
        {
            BEFORE_PROCESS = 0,
            AFTER_PROCESS = 1,
            NO_USED = 2
        }
        public enum MV_FILETYPE
        {
            RAW = 0,
            BMP = 1,
            JPEG = 2
        }

        public enum VIDEOSIGNAL
        {
            GLLEVEL = 0,
            DIVIDER = 1,
            ISINTERLACE = 2,
            XSHIFT = 3,
            YSHIFT = 4,
            XSIZE = 5,
            YSIZE = 6,
            VCOR = 7,
            VCOG = 8,
            LP = 9,

            LINEFREQENCY = 10,
            LINETOTAL = 11,
            LINEACTIVETIME = 12,
            LINESYNTIME = 13,
            LINESHOULDER = 14,

            FRAMENUM = 15,
            FIELDSYNTIME = 16,
            FIELDTOTAL = 17,
            FIELDSHOULDER = 18,
            SOURFREQ = 19,
            FREQSUB = 20
        }

        public enum GDIFunc
        {
            SetGDIText = 0, SetGDITextColor = 1,
            SetGDITextFormat = 2, SetGDITextPosition = 3,
            SetGDIGraph = 4, SetGDIGraphPen = 5,
            SetGDICanCalAll = 6, SetGDICanCalOne = 7
        }

        public enum DISPCOLORFMT
        {
            DISP_Y8 = 0,
            DISP_RGB15 = 1,
            DISP_RGB16 = 2,
            DISP_RGB24 = 3,
            DISP_RGB32 = 4,
        }

        public enum GRAPHMODE
        {
            GRAPH_STRING = 0,
            GRAPH_LINE = 1,
            GRAPH_CIRCLE = 2
        }
        #endregion
        #region struct
        [StructLayout(LayoutKind.Explicit)]
        public struct MV_IMAGEINFO
        {
            [FieldOffset(0)]
            public uint Length;      // 图像的大小，以字节计
            [FieldOffset(8)]
            public uint nColor;      // 图像的颜色
            [FieldOffset(16)]
            public uint Heigth;      // 图像的高
            [FieldOffset(24)]
            public uint Width;       // 图像的宽
            [FieldOffset(32)]
            public uint SkipPixel;   // 每行跳过的像素
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Rect
        {
            [FieldOffset(0)]
            public int left;
            [FieldOffset(4)]
            public int top;
            [FieldOffset(8)]
            public int right;
            [FieldOffset(12)]
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagRGBQUAD
        {
            [MarshalAs(UnmanagedType.I1)]
            public byte rgbBlue;
            [MarshalAs(UnmanagedType.I1)]
            public byte rgbGreen;
            [MarshalAs(UnmanagedType.I1)]
            public byte rgbRed;
            [MarshalAs(UnmanagedType.I1)]
            public byte rgbReserved;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MV_RGB
        {
            public int R_hWnd;
            public Rect R_Rect;
            public int G_hWnd;
            public Rect G_Rect;
            public int B_hWnd;
            public Rect B_Rect;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_NOTIFY
        {
            CONTINUEGARBMECHANISM pContinueCall;
            PTRIGGEROUTINE pTirggerCall;
            IntPtr pContext;
        }
        public struct GDIOPERATION
        {
            IntPtr pIs;
            GDIOPERATIONFUNC SetGDIText;
            GDIOPERATIONFUNC SetGDITextColor;
            GDIOPERATIONFUNC SetGDITextFormat;
            GDIOPERATIONFUNC SetGDITextPosition;
            GDIOPERATIONFUNC SetGDIGraph;
            GDIOPERATIONFUNC SetGDIGraphPen;
            GDIOPERATIONFUNC SetGDICanCalAll;
            GDIOPERATIONFUNC SetGDICanCalOne;
        }
                #endregion

        // 控制板卡使用的缓存类型, 对应BUFFERTYPE
        public const int SYSTEM_MEMORY_DX = 0; // 系统内存显示方式, 支持所有的选项,如左右翻转, 该方式下采集不丢帧，显示可能会丢帧;
        public const int SYSTEM_MEMORY_GDI = 1;  // GDI系统内存显示方式, 支持所有的选项, 如左右翻转, 该方式下采集不丢帧, 显示可能会丢帧;
        public const int VIDEO_MEMORY = 2; // 直接显存显示方式, 只有在显示位数和采集位数相等时采用, 该方式下支持不丢帧显示而采集丢
        // 帧或不支持采集; 对于M10，RGB10，M20，RGB20型卡不支持所有的选项(如左右翻转)。
        public static int RECEDE_NOISES = 3; // 对于M10，RGB10，M20，RGB20型卡不支持，而V3型卡为4帧平均方式

        // 控制系统的显示工作状态，对应DISP_PRESENCE
        public const int SHOW_CLOSE = 0;			// 显示关闭
        public const int SHOW_OPEN = 1;			// 显示打开

        // 控制视频采集标准，对应ADJUST_STANDARD
        public const int SIGNAL_PAL = 0;		// PAL
        public const int SIGNAL_NTSC = 1;		// NTSC
        public const int SIGNAL_NONSTANDARD = 2;		// 对于M20，RGB20

        // 控制视频信号的输入源, 对应ADJUST_SOURCE
        public const int SVIDEO_IN = 1;		// SVIDEO输入
        public const int COMPOSITE_IN = 0;		// 复合输入

        // 控制视频信号输入源的通道, 对应ADJUST_CHANNEL
        public const int CHANNEL_0 = 0;
        public const int CHANNEL_1 = 1;
        public const int CHANNEL_2 = 2;
        public const int CHANNEL_3 = 3;
        public const int CHANNEL_4 = 4;
        public const int CHANNEL_5 = 5;
        public const int CHANNEL_6 = 6;
        public const int CHANNEL_7 = 7;
        public const int CHANNEL_8 = 8;
        public const int CHANNEL_9 = 9;

        // 控制视频捕获的格式，对应GARB_BITDESCRIBE
        public const int DATA_MONOCHOY8 = 0;
        public const int DATA_RGB1555 = 1;
        public const int DATA_CO_RGB24 = 2;
        public const int DATA_aRGB8888 = 3;
        public const int DATA_RGB8332 = 4;
        public const int DATA_CO_RGB565 = 5;
        public const int DATA_RGB5515 = 6;
        public const int DATA_CO_YUV444 = 7;
        public const int DATA_CO_YUV422 = 8;
        public const int DATA_YUV411 = 9;

        // 控制板卡的翻转工作参数，对应WORK_UPDOWN和WORK_FLIP
        public const int NON_TURN = 0;		// 不翻转
        public const int TURN = 1;		// 翻转

        // 控制板卡的跳行采集工作参数，对应WORK_SKIP, 即对于隔行信号一帧中偶奇场的存储是按帧方式还是按先偶场后奇场
        public const int FLATNESS = 0; // 一帧中偶奇场的存储是按偶场后奇场
        public const int INTERLUDE = 1; // 一帧中偶奇场的存储是按帧方式


        // 控制板卡的同步信号的来源, 对应WORK_SYNC
        public const int SYN_RED = 0; // 红路信号带复合同步;
        public const int SYN_GREEN = 1; // 绿路信号带复合同步;
        public const int SYN_BLUE = 2; // 兰路信号带复合同步;
        public const int SYN_OUTSIDE = 3;// 外同步；
        public const int SYN_RESERVE = 4; // 保留不使用;
        public const int SYN_SEPARATE = 5; // 同步信号行场分离;
        public const int SYN_INSIDE1 = 6; // 内同步1
        public const int SYN_INSIDE2 = 7; // 内同步2

        // 控制板卡的信号种类, 对应WORK_INTERLACE
        public const int LINE_BY_LINE = 0;		// 逐行
        public const int INTERLEAVED = 1;		// 隔行

        // 控制板卡在采集信号时对灰度级的范围, 对应WORK_ISBLACK, 该类型仅对M10，RGB10，M20，RGB20系列卡有效，
        public const int BOGUS_COLOR = 0;		// 伪彩采集
        public const int FULL_COLOR = 1;		// 全灰阶采集。

        // 控制板卡在采集信号时场或按帧采集, 对应WORK_FIELD
        public const int COLLECTION_FRAME = 0;		// 按帧采集
        public const int COLLECTION_FIELD = 1;		// 按场采集

        // 控制板卡的OSD模式, 对应OSD_MODE。该类型仅对V3、V5系列卡有效
        public const int OSD_NON = 0;			// 无OSD
        public const int OSD_ZERO = 1;			// 0屏蔽OSD
        public const int OSD_ONE = 2;			// 1屏蔽OSD

        public const int B_CHANNEL = 1;
        public const int G_CHANNEL = 2;
        public const int R_CHANNEL = 4;

        public delegate bool CALLBACKFUNC(IntPtr pData,ref MV_IMAGEINFO pImageInfo, IntPtr pUserData, uint Index);
        public delegate void PTRIGGEROUTINE(uint UniquelyID, uint Reson, IntPtr pContext);
        public delegate void CONTINUEGARBMECHANISM(IntPtr pData,ref MV_IMAGEINFO pImage, uint ImageNumber,
                                                      uint wholeLength, IntPtr pUserData);

        public delegate void GDIOPERATIONFUNC(IntPtr pOper, IntPtr pVal1, IntPtr pVal2, IntPtr pVal3);


        #endregion

        #region 板卡的类型, 对应GET_BOARD_TYPE时的返回
        public const int LEVIN_M10 = 0x00006010;
        public const int LEVIN_M20 = 0x00006020;
        public const int LEVIN_RGB10 = 0x00009010;
        public const int LEVIN_RGB20 = 0x00009020;
        public const int LEVIN_VGA100 = 0x00009030;
        public const int LEVIN_VGA170 = 0x00009040;
        public const int V3A = 0x71100000;
        public const int V300 = 0x71140058;
        public const int V500 = 0x56353030;
        public const int V510 = 0x56353130;
        public const int V520 = 0x56353230;
        public const int V200 = 0x33714d56;
        public const int V120 = 0x33084d56;
        public const int V110 = 0x43504d56;
        public const int V130 = 0x33604d56;
        public const int V112 = 0x33A04d56;

        public const int V410 = 0x01324d56;
        public const int V411 = 0x21324d56;
        public const int S451 = 0x11324d56;
        public const int V412 = 0x22324d56;

        public const int S100 = 0x43204d56;
        public const int S450 = 0x118c4d56;
        public const int S400S420 = 0x54404d56;
        public const int S401 = 0x33104d56;

        public const int S211 = 0x31104d56;
        public const int S251 = 0x21314d56;

        public const int V8T = 0x00084d56;

        public const int V400 = 0x32024d56;
        public const int V401 = 0x43104d56;

        public const int V211 = 0x21104d56;
        public const int V221 = 0x21214d56;

        public const int MOKAC10 = 0x73104d56;
        public const int MOKAC20 = 0x73304d56;
        public const int MOKAC40 = 0x72104d56;
        public const int MOKAC41 = 0x11354d56;

        public const int X400 = 0x32404d56;
        //public const int X800 = 0xB1004d56;

        public const int E450 = 0x118e4d56;
        public const int E410 = 0x018e4d56;
        public const int E400 = 0x108e4d56;
        public const int E412 = 0x218e4d56;

        public const int MP200 = 0x70134d56;
        public const int MP210 = 0x74134d56;

        public const int MP220 = 0x22134d56;
        public const int MP230 = 0x23134d56;

        public const int MP110 = 0x10104d56;
        public const int MP240 = 0x12104d56;

        public const int S260 = 0x35254d56;

        #endregion

        public CALLBACKFUNC seq;

        // 错误提示
        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]	
        public static extern uint MV_GetLastError(bool bDisplayErrorStyring);

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern uint MV_GetDeviceNumber();   //板卡数

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern int MV_OpenDevice(uint Index, bool bRelese);  //创建设备

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern void MV_CloseDevice(int hDevice);  //删除设备

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern int MV_OperateDevice(int hDevice, int Oper);   //操纵设备

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern bool MV_SetDeviceParameter(int hDevice, int Oper, uint Val); //设置设备属性

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern int MV_GetDeviceParameter(int hDevice, int Oper); //读取设备属性

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern bool MV_SaveDeviceParam(int hDevice); //储存设备属性

        [DllImport("mvapi.dll", CharSet = CharSet.Auto)]
        public static extern bool MV_ResetDeviceParam(int hDevice); //重置设备属性

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 捕获一帧
        public static extern IntPtr MV_CaptureSingle(int hDevice, bool IsProcess, int Buffer, int Bufflen, ref MV_IMAGEINFO pinfo);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 保存文件
        public static extern bool MV_SaveFile([MarshalAs(UnmanagedType.LPStr)] String FileName, int FileType, IntPtr pImageData, ref MV_IMAGEINFO pinfo, int ImageTotal, bool IsUpDown, bool ColororNot, int Quality, bool m_bRGB15);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 保存文件
        public static extern int MV_ReadPixel(ref MV_IMAGEINFO pinfo, IntPtr pImageData, ref Point pt, byte[] pVal);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]
        public static extern bool MV_SaveFile([MarshalAs(UnmanagedType.LPStr)] String FileName, int FileType, IntPtr pImageData, ref MV_IMAGEINFO pinfo, uint ImageTotal, bool IsUpDown, bool ColororNot, int Quality);

        [DllImport("MVAPI.dll", CallingConvention = CallingConvention.StdCall)] // 设置设备的回调
        public static extern bool MV_SetCallBack(int hDevice, CALLBACKFUNC pCallBack, IntPtr pUserData, int CallType);
        //	MVAPI BOOL    WINAPI MV_SetCallBack( HANDLE hDevice, CALLBACKFUNC pCallBack, PVOID pUserData, CALLBACKTYPE CallType );

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 输出控制
        public static extern bool MV_SetOutputState(int hDevice, uint Index, uint HorL);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  //输入状态读取
        public static extern uint MV_GetInputState(int hDevice, uint Index);

        [DllImport("MVAPI.dll", CallingConvention = CallingConvention.StdCall)]  // 输入触发控制
        public static extern bool MV_SetInputCallBack(int hDevice, uint Index, uint UniquelyID, PTRIGGEROUTINE pTirggerCall, IntPtr pContext);
        //	MVAPI BOOL  WINAPI MV_SetInputCallBack( HANDLE hDevice, ULONG Index, ULONG UniquelyID, PTRIGGEROUTINE pTirggerCall, PVOID pContext );


        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 对设备分配大帧存
        public static extern bool MV_AllocSequenceFrameMemory(int hDevice, uint Action, uint Number, int MemoryType);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 对设备释放大帧存
        public static extern bool MV_FreeSequenceFrameMemory(int hDevice);

        [DllImport("MVAPI.dll", CallingConvention = CallingConvention.StdCall)]  // 对大帧存开始连续捕获
        public static extern bool MV_StartSequenceCapture(int hDevice, CONTINUEGARBMECHANISM pContinueCall, IntPtr pContext);
        //MVAPI BOOL WINAPI MV_StartSequenceCapture( HANDLE hDevice, CONTINUEGARBMECHANISM pContinueCall, PVOID pContext );

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 对大帧存停止连续捕获
        public static extern int MV_StopSequenceCapture(int hDevice);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]  // 根据FrameNo返回帧号地址和帧属性
        public static extern void MV_GetSequenceFrameAddress(int hDevice, uint FrameNo, ref MV_IMAGEINFO pProperty);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)] // 按OsdMode模式使能OSD(掩码)功能:
        public static extern bool MV_SetMaskFunction(int hDevice, uint OsdMode);

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)] // 将OSD图案发送到设备
        public static extern bool MV_SetMaskBit(int hDevice, Rect MaskArea, // byte* pBitPattern );
                                                [MarshalAs(UnmanagedType.LPArray)] byte[] pBitPattern);
        //MVAPI BOOL   WINAPI MV_SetMaskBit( HANDLE hDevice, RECT MaskArea, LPBYTE pBitPattern );

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)]
        // public delegate byte[]  MV_MakeMaskBit( int hDevice, IntPtr hWnd, Rect Area, int color );
        public static extern byte[] MV_MakeMaskBit(int hDevice, IntPtr hWnd, Rect Area, int color);
        //public static extern byte*  MV_MakeMaskBit( int hDevice, IntPtr hWnd, Rect Area, int color );
        //MVAPI LPBYTE WINAPI MV_MakeMaskBit( HANDLE hDevice, HWND hWnd, RECT Area, COLORREF Color );

        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)] // 侦测信号
        public static extern bool MV_TestSignal(int hDevice, uint XSize, uint YSize);

        // 获得参数
        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)] 
        public static extern bool MV_GetSignalParam(int hDevice, int Signal, IntPtr FloatVal, IntPtr IntVal);
        // 保存到配置文件。
        [DllImport("MVAPI.dll", CharSet = CharSet.Auto)] 
        public static extern bool MV_SaveSignalParamToIni(int hDevice);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_InitDisplay(uint WinID, IntPtr hWnd, uint dwWidth, uint dwHeight, int ColorFmt, int DispFlip);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_SetDispSourceRect(uint WinID, Rect rcSrc);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_SetDispDestRect(uint WinID, Rect rcSrc);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_SetDispGDIText(uint WinID, uint StrNo, uint PosX, uint PosY, uint TextColor, IntPtr pStr, IntPtr TextFont);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_SetDispGDIGraph(uint WinID, uint GraphNo, int Line_Arc, uint Pos0X, uint Pos0Y, uint Pos1X, uint Pos1Y, IntPtr GDIPen);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_SetDispGDICanCalOne(uint WinID, int Line_Arc, uint No);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_SetDispCanCalAll(uint WinID, int Line_Arc);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_FiniDisplay(uint WinID);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_DisplayData(uint WinID, IntPtr buffer, uint BufSize, Rect rcDest, uint GDIMODE);

        [DllImport("MVCDISPFUN.dll", CharSet = CharSet.Auto)]
        public static extern bool MVD_GetOSDData(uint WinID, IntPtr buffer, uint BufSize);

        [DllImport("mvavi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool MV_AVIFileOpen(int index, byte[] lpszFileName, ref SIS_Function.Win32API.bitmapinfo alpb, ushort wSkipRate, int CompressType);

        [DllImport("mvavi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void MV_AVIFileInit(uint filetype, short framerate);

        [DllImport("mvavi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void MV_AVIFileFini();

        [DllImport("mvavi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool MV_AVIFileAddFrame(int index, ref SIS_Function.Win32API.bitmapinfo alpb, IntPtr alpImageBits, bool keyframe);

    }
}
