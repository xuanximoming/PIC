using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;

using SIS_BLL;
using SIS_Model;
using SIS.Function;
using DALFactory;
using ILL;

namespace SIS
{
    /// <summary>
    /// ��¼���棬���ڵ�¼ϵͳ����������
    /// </summary>
    public partial class frmLogin : Form
    {
        private BImgEquipment BImgEqu = new BImgEquipment();
        private DataTable dt = new DataTable();
        private MImgEquipment MimgEqu = (MImgEquipment)Model.CreateMImgEquipment();
        public IModel user;
        public bool isAutoLock = true;

        //�޿����ƶ�����windows ��API������ӦMouseMove�¼�
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

    
        /// <summary>
        /// ���ã�˫����¼ͼ�꣬��ʾ�ĵ�¼�����ʼ��,���캯��1������������
        /// ˼·��SIS���󶨼���豸��PACS�������豸ѡ�����ͱ�ǩ������������λ�á�
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            this.lbHospitalName.Text = GetConfig.HospitalName;
            this.user =Model.CreateMUser();
            if (GetConfig.DALAndModel == "SIS")
                BindCbMachineName();
            else
            {
                this.txt_Pwd.Location = new Point(this.txt_Pwd.Location.X, this.txt_Pwd.Location.Y + 15);
                this.l_Pwd.Location = new Point(this.l_Pwd.Location.X, this.l_Pwd.Location.Y + 15);
                this.cmb_ImgEquipment.Visible = false;
                this.l_ImgEquipment.Visible = false;
            }
        }

        /// <summary>
        /// ���ã��û������������������ťʱ��ģʽ��ʾ�Ľ��������ʼ�������캯��2��������IUSER�����û���
        /// ˼·������ʾ��������������������λ�ã������豸����ҽ��IDΪֻ������ʾ���ѵ�¼������ʾ������壻���ص�¼��壻��ʾҽ��ID��
        /// </summary>
        /// <param name="iuser"></param>
        public frmLogin(IModel iuser)
        {
            InitializeComponent();
            this.lbHospitalName.Text = GetConfig.HospitalName;
            this.ShowInTaskbar = false;
            this.txt_Pwd.Location = new Point(this.txt_Pwd.Location.X, this.txt_Pwd.Location.Y + 15);
            this.l_Pwd.Location = new Point(this.l_Pwd.Location.X, this.l_Pwd.Location.Y + 15);
            this.cmb_ImgEquipment.Visible = false;
            this.l_ImgEquipment.Visible = false;
            this.txt_DoctorId.ReadOnly = true;
            this.l_Notice.Visible = true;
            this.p_Lock.Visible = true;
            this.p_LoginButtons.Visible = false;
            this.initData(iuser);
        }

        /// <summary>
        /// ���ã��û�����������������ð�ť�����������Զ������������ó�ʼ�������캯��3��
        /// ˼·������ʾ��������������������λ�ã������豸����ҽ��IDΪֻ������ʾ���ѵ�¼������ʾ������壻���ص�¼��壻��ʾҽ��ID��
        /// </summary>
        /// <param name="iuser"></param>
        /// <param name="ShowValidity"></param>
        public frmLogin(IModel iuser,bool ShowValidity)
        {
            InitializeComponent();
            this.lbHospitalName.Text = GetConfig.HospitalName;
            this.ShowInTaskbar = false;
            this.txt_Pwd.Location = new Point(this.txt_Pwd.Location.X, this.txt_Pwd.Location.Y + 15);
            this.l_Pwd.Location = new Point(this.l_Pwd.Location.X, this.l_Pwd.Location.Y + 15);
            this.cmb_ImgEquipment.Visible = false;
            this.l_ImgEquipment.Visible = false;
            this.txt_DoctorId.ReadOnly = true;
            this.l_Notice.Visible = true;
            this.p_Validity.Visible = true;
            this.p_LoginButtons.Visible = false;
            this.initData(iuser);
        }

        /// <summary>
        /// ���ã�������������󣬶Թ��ź�����ĳ�ʼ����
        /// ˼·������ǰ��¼�û���ID��ֵ��������ա�
        /// </summary>
        /// <param name="iuser"></param>
        public void initData(IModel iuser)
        {
            this.user = iuser;
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MUser muser = (SIS_Model.MUser)iuser;
                this.txt_DoctorId.Text = muser.DOCTOR_ID;
            }
            else
            {
                PACS_Model.MUser muser = (PACS_Model.MUser)iuser;
                this.txt_DoctorId.Text = muser.DB_USER;
            }
            this.txt_Pwd.Text = "";
        }

        /// <summary>
        /// ���ã��ڵ�¼����,��Ӱ���������
        /// ˼·�����������ļ��ļ����Ҵ��룬��ȡ�ÿ��������豸����ʾ��Ϊ�豸��������Ϊ�豸ID��
        /// </summary>
        private void BindCbMachineName()
        {    
            try
            {
                dt = BImgEqu.GetList(" CLINIC_OFFICE_CODE = '" + GetConfig.ExamDeptCode + "'");
                this.cmb_ImgEquipment.DataSource = dt;
                this.cmb_ImgEquipment.DisplayMember = "IMG_EQUIPMENT_NAME";
                this.cmb_ImgEquipment.ValueMember = "IMG_EQUIPMENT_ID";               
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
            if (dt == null)
            {
                MessageBoxEx.Show("�����������ӣ�");     //����޷���ȡ���Ҵ��룬��Ϊ�������⣬��ʾ����
                this.Close();
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["IMG_EQUIPMENT_NAME"].ToString() == GetConfig.ImgEquipment)     //ѡ��Ĭ�ϵĻ�����
                {
                    this.cmb_ImgEquipment.SelectedIndex = i;
                    break;
                }
                else
                    this.cmb_ImgEquipment.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// ���ã���������¼����ĵ�¼��ť����Ӧ�¼���
        /// ˼·������û���ݺϷ���������¼���رյ�ǰ���沢�������棻������ʾ�û������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                if (this.cmb_ImgEquipment.Text.ToString() != GetConfig.ImgEquipment)
                {
                   GetConfig.SetImgEquipment(this.cmb_ImgEquipment.Text.ToString());        //��д�����ļ�Ĭ�ϵĻ�����
                   GetConfig.ImgEquipment = this.cmb_ImgEquipment.Text.ToString();
                }
                if (CheckUser())
                {
                    try
                    {
                        BUser buser = new BUser();
                        this.user = buser.GetModel(this.txt_DoctorId.Text.Trim().ToString());    //��ȡ���û���Ϣ
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.Show(ex.Message);
                    }
                    this.Visible = false;
                    frmMainForm fp = new frmMainForm(this.user);
                    fp.Show();
                }
                else
                {
                    MessageBoxEx.Show("�û��������벻��ȷ�����������룡","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    this.txt_Pwd.Text = "";
                    this.txt_Pwd.Focus();
                }
            }
        }

        /// <summary>
        ///  ���ã�����û�������Ϣ��
        /// ˼·��������Ϊ�գ�����ʾ���棬�������Ϊ�յ������ı��򣻲����ء�
        /// </summary>
        /// <returns></returns>

        private bool  CheckText()
        {
            if (this.txt_DoctorId.Text == "")
            {
                MessageBoxEx.Show("���Ų���Ϊ�գ����������룡","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.txt_DoctorId.Focus();
                return false;
            }
            if (this.txt_Pwd.Text == "")
            {
                MessageBoxEx.Show("���벻��Ϊ�գ����������룡","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.txt_Pwd.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ���ã��Ե�¼�û��������֤��
        /// ˼·����������û����ź����룬ʵ����һ���û�������ѯ���ݿ��û���
        /// </summary>
        /// <returns></returns>
        private bool CheckUser()
        {
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MUser muser = (SIS_Model.MUser)user;
                muser.DOCTOR_ID = this.txt_DoctorId.Text.Trim().ToString();
                muser.DOCTOR_PWD = this.txt_Pwd.Text.Trim().ToString();
            }
            else
            {
                PACS_Model.MUser muser = (PACS_Model.MUser)user;
                muser.DB_USER = this.txt_DoctorId.Text.Trim().ToString();
                muser.USER_PWD = this.txt_Pwd.Text.Trim().ToString();
            }
            try
            {
                return new BUser().Exists(user);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ���ã��û�����ȡ����ť����Ӧ�����¼���
        /// ˼·���Թ��ź���������ݽ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txt_DoctorId.Text = "";
            this.txt_Pwd.Text = "";
            
        }

        /// <summary>
        /// ���ã����������£����ƶ�����Ӧ�����ƶ���
        /// ˼·������API��ʵ���޿����ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        /// <summary>
        /// ������豸�����س��¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        /// <summary>
        /// ���ã��������ð�ť�����ֽ��档
        /// ˼·�����ص�¼����������������������ʾ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_LockSetting_Click(object sender, EventArgs e)
        {
            this.p_LoginMain.Visible = false;
            this.p_Lock.Visible = false;
            this.p_Setting.Visible = true;
            this.txt_Minute.Enabled = false;
            if (GetConfig.LS_AutoLock)
            {
                this.cb_AutoLock.Checked = true;
                this.txt_Minute.Text = GetConfig.LS_LockMinute.ToString();
            }
            else
                this.cb_AutoLock.Checked = false;
        }

        /// <summary>
        /// ���ã������˳���ť���˳���¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// ���ã�����������ť��ִ�н�����֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UnLock_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        /// <summary>
        /// ���ã�ִ�н�����֤��
        /// ˼·������¼�ɹ����û���Ϣ������������жϡ�
        /// </summary>
        private void Check()
        {
            string pwd = "";
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MUser muser = (SIS_Model.MUser)user;
                pwd = muser.DOCTOR_PWD;
            }
            else
            {
                PACS_Model.MUser muser = (PACS_Model.MUser)user;
                pwd = muser.USER_PWD;
            }
            if (this.txt_Pwd.Text == pwd)
                this.DialogResult = DialogResult.OK;
            else
                MessageBoxEx.Show("�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// ���ã������ϽǵĹرհ�ť�������رհ�ť���˳�ϵͳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ���ã��������水ť��ִ�ж������Զ����������ı��档
        /// ˼·������ɹ�������ʾ��¼��������������������������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cb_AutoLock.Checked)
                {
                    GetConfig.SetLS_AutoLock(true);
                    GetConfig.SetLS_LockMinute(int.Parse(this.txt_Minute.Text.ToString()));
                    this.isAutoLock = true;
                }
                else
                {
                    GetConfig.SetLS_AutoLock(false);
                    GetConfig.SetLS_LockMinute(0);
                    this.isAutoLock = false;
                }
                MessageBoxEx.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.p_Setting.Visible = false;
                this.p_LoginMain.Visible = true;
                this.p_Lock.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message.ToString(), "�쳣", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ���ã�����������ȡ����ť������������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.p_Setting.Visible = false;
            this.p_LoginMain.Visible = true;
            this.p_Lock.Visible = true;
        }

        /// <summary>
        /// ���ã���Ӧ�Զ�������ѡ���ѡ���¼� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_AutoLock_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_AutoLock.Checked)
                this.txt_Minute.Enabled = true;
            else
                this.txt_Minute.Enabled = false;
        }

        /// <summary>
        /// ���ã���¼������ʾʱ������䵽���������ı�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.txt_DoctorId.Focus();
        }

        //��½��ť
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        //ȡ����ť
        private void btn_Cancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �����޸����붯̬���ӣ�ģʽ���޸��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llb_ChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePwd pwd = new frmChangePwd();
            pwd.ShowDialog();
        }
    }
}