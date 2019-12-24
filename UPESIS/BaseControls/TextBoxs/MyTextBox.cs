using System; 
using System.ComponentModel; 
using System.Collections; 
using System.Diagnostics; 
using System.Windows.Forms; 
using System.Drawing; 
using System.Drawing.Drawing2D;

namespace BaseControls
{ 

    [ToolboxItem(true)]
    public partial class MyTextBox : System.Windows.Forms.TextBox 
    { 
        /// <summary> 
        /// ��õ�ǰ���̣��Ա��ػ�ؼ� 
        /// </summary> 
        /// <param name="hWnd"></param> 
        /// <returns></returns> 
        [System.Runtime.InteropServices.DllImport("user32.dll")] 
        static extern IntPtr GetWindowDC(IntPtr hWnd); 
        [System.Runtime.InteropServices.DllImport("user32.dll")] 
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC); 

        /// <summary> 
        /// �Ƿ������ȵ�Ч�� 
        /// </summary> 
        private bool _HotTrack = true ; 

        /// <summary> 
        /// �߿���ɫ 
        /// </summary> 
        private Color _BorderColor = Color.FromArgb(0xA7,0xA6,0xAA); 

        /// <summary> 
        /// �ȵ�߿���ɫ 
        /// </summary> 
        private Color _HotColor = Color.FromArgb(0x33,0x5E,0xA8); 

        /// <summary> 
        /// �Ƿ����MouseOver״̬ 
        /// </summary> 
        private bool _IsMouseOver = false ; 
         
        #region ���� 
        /// <summary> 
        /// �Ƿ������ȵ�Ч�� 
        /// </summary> 
        [ Category("��Ϊ"), 
        Description("��û�����һ��ֵ��ָʾ����꾭���ؼ�ʱ�ؼ��߿��Ƿ����仯��ֻ�ڿؼ���BorderStyleΪFixedSingleʱ��Ч"), 
        DefaultValue(true)] 
        public bool HotTrack 
        { 
            get 
            { 
                return this._HotTrack ; 
            } 
            set 
            { 
                this._HotTrack = value ; 
                //�ڸ�ֵ�����仯ʱ�ػ�ؼ�����ͬ 
                //�����ģʽ�£����ĸ�����ʱ����������ø���䣬 
                //�����������������ͼ�иÿؼ���Ӧ�ı仯 
                this.Invalidate();  
            } 
        } 
        /// <summary> 
        /// �߿���ɫ 
        /// </summary> 
        [ Category("���"), 
        Description("��û����ÿؼ��ı߿���ɫ"), 
        DefaultValue(typeof(Color),"#A7A6AA")] 
        public Color BorderColor 
        { 
            get 
            {  
                return this._BorderColor;  
            } 
            set 
            {  
                this._BorderColor = value;  
                this.Invalidate();  
            } 
        }    
        /// <summary> 
        /// �ȵ�ʱ�߿���ɫ 
        /// </summary> 
        [ Category("���"), 
        Description("��û����õ���꾭���ؼ�ʱ�ؼ��ı߿���ɫ��ֻ�ڿؼ���BorderStyleΪFixedSingleʱ��Ч"), 
        DefaultValue(typeof(Color),"#335EA8")] 
        public Color HotColor 
        { 
            get 
            {  
                return this._HotColor;  
            } 
            set 
            {  
                this._HotColor = value;  
                this.Invalidate();  
            } 
        }    
        #endregion ���� 

        /// <summary> 
        ///  
        /// </summary> 
        public MyTextBox():base() 
        {             
        } 

        /// <summary> 
        /// ����ƶ����ÿؼ���ʱ 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnMouseMove(MouseEventArgs e) 
        { 
            //���״̬ 
            this._IsMouseOver = true ; 
            //�������HotTrack����ʼ�ػ� 
            //��������ж����ﲻ���жϣ��򵱲�����HotTrack�� 
            //����ڿؼ����ƶ�ʱ���ؼ��߿�᲻���ػ棬 
            //���¿ؼ��߿���˸����ͬ 
            //˭�и��õİ취��Please tell me , Thanks�� 
            if(this._HotTrack) 
            { 
                //�ػ� 
                this.Invalidate(); 
            } 
            base.OnMouseMove (e); 
        } 
        /// <summary> 
        /// �����Ӹÿؼ��ƿ�ʱ 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnMouseLeave(EventArgs e) 
        { 
            this._IsMouseOver = false ; 

            if(this._HotTrack) 
            { 
                //�ػ� 
                this.Invalidate(); 
            } 
            base.OnMouseLeave (e); 
        } 
         
        /// <summary> 
        /// ���ÿؼ���ý���ʱ 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnGotFocus(EventArgs e) 
        { 

            if(this._HotTrack) 
            { 
                //�ػ� 
                this.Invalidate(); 
            } 
            base.OnGotFocus (e); 
        } 
        /// <summary> 
        /// ���ÿؼ�ʧȥ����ʱ 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnLostFocus(EventArgs e) 
        { 
            if(this._HotTrack) 
            { 
                //�ػ� 
                this.Invalidate(); 
            } 
            base.OnLostFocus (e); 
        } 

        /// <summary> 
        /// ��ò���ϵͳ��Ϣ 
        /// </summary> 
        /// <param name="m"></param> 
        protected override void WndProc(ref Message m) 
        { 

            base.WndProc (ref m); 
            if (m.Msg==0xf || m.Msg==0x133) 
            { 
                //����ϵͳ��Ϣ����õ�ǰ�ؼ������Ա��ػ档 
                //һЩ�ؼ�����TextBox��Button�ȣ�����ϵͳ���̻��ƣ�����OnPaint��������������. 
                //�������ﲢû��ʹ������OnPaint��������TextBox�߿� 
                // 
                //MSDN:��д OnPaint ����ֹ�޸����пؼ�����ۡ� 
                //��Щ�� Windows ��������л�ͼ�Ŀؼ������� Textbox���Ӳ��������ǵ� OnPaint ������ 
                //��˽���Զ����ʹ���Զ�����롣��μ���Ҫ�޸ĵ��ض��ؼ����ĵ��� 
                //�鿴 OnPaint �����Ƿ���á����ĳ���ؼ�δ�� OnPaint ��Ϊ��Ա�����г��� 
                //�����޷�ͨ����д�˷����ı�����ۡ� 
                // 
                //MSDN:Ҫ�˽���õ� Message.Msg��Message.LParam �� Message.WParam ֵ�� 
                //��ο�λ�� MSDN Library �е� Platform SDK �ĵ��ο������� Platform SDK����Core SDK��һ�ڣ� 
                //�����а����� windows.h ͷ�ļ����ҵ�ʵ�ʳ���ֵ�����ļ�Ҳ���� MSDN ���ҵ��� 
                IntPtr hDC = GetWindowDC(m.HWnd);  
                if (hDC.ToInt32() == 0)  
                {  
                    return;  
                }  

                //ֻ���ڱ߿���ʽΪFixedSingleʱ�Զ���߿���ʽ����Ч 
                if(this.BorderStyle == BorderStyle.FixedSingle) 
                {                 
                    //�߿�WidthΪ1������ 
                    System.Drawing.Pen pen = new Pen(this._BorderColor,1) ;; 
                 
                    if(this._HotTrack) 
                    {                         
                        if(this.Focused) 
                        { 
                            pen.Color = this._HotColor ; 
                        } 
                        else 
                        { 
                            if(this._IsMouseOver) 
                            { 
                                pen.Color=this._HotColor; 
                            } 
                            else 
                            { 
                                pen.Color = this._BorderColor ; 
                            } 
                        }                         
                    } 
                    //���Ʊ߿� 
                    System.Drawing.Graphics g  = Graphics.FromHdc(hDC);  
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;       
                    g.DrawRectangle(pen,0,0,this.Width-1, this.Height-1) ; 
                    pen.Dispose(); 
                } 
                //���ؽ�� 
                m.Result = IntPtr.Zero;  
                //�ͷ� 
                ReleaseDC(m.HWnd,hDC); 
            } 
        } 

    } 
} 
