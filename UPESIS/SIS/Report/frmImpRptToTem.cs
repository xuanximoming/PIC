using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_Model;
using SIS_BLL;

namespace SIS
{
    public partial class frmImpRptToTem : Form
    {
        private int ParentId = -1;
        private string ClinicOfficeCode = "";
        public MReportTempDict[] NewTems;//新增的节点

        public frmImpRptToTem(WordClass.Template tem, MReportTempDict ParentTem)
        {
            InitializeComponent();
            this.txt_Description.Text = tem.Description;
            this.txt_ExamPara.Text = tem.ExamPara;
            this.txt_Impression.Text = tem.Impression;
            this.txt_Recommendation.Text = tem.Recommendation;
            this.txt_NodeName.Text = ParentTem.NODE_NAME;
            this.cmb_IsPrivate.SelectedIndex = Convert.ToInt32(ParentTem.IS_PRIVATE);
            this.cmb_IsPrivate.Enabled = ParentTem.IS_PRIVATE == 0 ? true : false;
            this.ParentId = Convert.ToInt32(ParentTem.NODE_ID);
            this.ClinicOfficeCode = ParentTem.EXAM_CLASS;
        }
        public frmImpRptToTem(MReportTempDict ParentTem)
        {
            InitializeComponent();
           // this.txt_Description.Text = tem.Description;
           // this.txt_ExamPara.Text = tem.ExamPara;
           // this.txt_Impression.Text = tem.Impression;
           // this.txt_Recommendation.Text = tem.Recommendation;
            this.txt_NodeName.Text = ParentTem.NODE_NAME;
            this.cmb_IsPrivate.SelectedIndex = Convert.ToInt32(ParentTem.IS_PRIVATE);
            this.cmb_IsPrivate.Enabled = ParentTem.IS_PRIVATE == 0 ? true : false;
            this.ParentId = Convert.ToInt32(ParentTem.NODE_ID);
            this.ClinicOfficeCode = ParentTem.EXAM_CLASS;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_YNodeName.Text.ToString().Trim() == "")
            {
                MessageBoxEx.Show("典型病历名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BReportTempDict btem = new BReportTempDict();
            NewTems = new MReportTempDict[3];
            
            NewTems[0] = NewTem("Y", this.ParentId);
            NewTems[1] = NewTem("1", Convert.ToInt32(NewTems[0].NODE_ID));
            NewTems[2] = NewTem("2", Convert.ToInt32(NewTems[0].NODE_ID));
            //NewTems[3] = NewTem("3", Convert.ToInt32(NewTems[0].NODE_ID));
            //NewTems[4] = NewTem("4", Convert.ToInt32(NewTems[0].NODE_ID));
            //for (int j = 1; j < NewTems.Length; j++)
            //{
            //    //if(NewTems[i].NODE_SIGN=="1" || NewTems[i].NODE_SIGN=="2"
            //}
            int i = btem.AddMore(NewTems);
            if (i > 0)
            {
                MessageBoxEx.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBoxEx.Show("保存失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private MReportTempDict NewTem(string NodeSign, int ParentId)
        {
            MReportTempDict tem = new MReportTempDict();
            BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_REPORT_TEMPLATE_NODE_ID");
            tem.NODE_ID = Convert.ToInt32(ID.GetSeqValue());
            tem.NODE_SIGN = NodeSign;
            tem.NODE_PARENT_ID = ParentId;
            if (this.txt_SortFlag.Text != "")
                tem.SORT_FLAG = Convert.ToInt32(this.txt_SortFlag.Text);
            tem.ICD10_CODE = this.txt_Icdcode.Text;
            tem.IS_PRIVATE = this.cmb_IsPrivate.SelectedIndex;
            tem.EXAM_CLASS = this.ClinicOfficeCode;
            if (tem.IS_PRIVATE == 1)
                tem.DOCTOR_ID = ((SIS_Model.MUser)frmMainForm.iUser).DOCTOR_ID;
            switch (NodeSign)
            {
                case "Y":
                    tem.NODE_NAME = this.txt_YNodeName.Text.ToString().Trim();
                    tem.NODE_DEPICT = "";
                    break;
                case "1":
                    tem.NODE_NAME = "检查所见";
                    tem.NODE_DEPICT = this.txt_Description.Text;
                    break;
                case "2":
                    tem.NODE_NAME = "诊断意见";
                    tem.NODE_DEPICT = this.txt_Impression.Text;
                    break;
                case "3":
                    tem.NODE_NAME = "检查内容";
                    tem.NODE_DEPICT = this.txt_ExamPara.Text;
                    break;
                case "4":
                    tem.NODE_NAME = "附注";
                    tem.NODE_DEPICT = this.txt_Recommendation.Text;
                    break;
            }
            return tem;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmImpRptToTem_Load(object sender, EventArgs e)
        {
            clsIme.SetIme(this);
        }
    }
}