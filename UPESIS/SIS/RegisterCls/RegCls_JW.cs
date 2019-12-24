using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Windows.Forms;
using SIS_BLL;

namespace SIS.RegisterCls
{
    public class RegCls_JW : DBControl 
    {
        public RegCls_JW()
            : base(GetConfig.GetHisConnStr())
        {
        }

        /// <summary>
        /// 绑定申请科室
        /// </summary>
        /// <param name="cmb_ReferDept"></param>
        public System.Data.DataTable Bind_ReferDept(ComboBox cmb_ReferDept)
        {
            string sql = "select distinct a.GROUP_CODE as DEPT_CODE,a.GROUP_NAME as DEPT_NAME,a.INPUT_CODE from STAFF_GROUP_DICT a,STAFF_VS_GROUP b  where (b.group_class= '科室医生' or  b.group_class='病区医生')  and a.GROUP_CODE=b.GROUP_CODE";
            //string Xml = DBoperate.ini.IniReadValue("SettingFiles", "DeptDict");
            //System.Data.DataSet ds = new System.Data.DataSet();
            //ds.ReadXml(Application.StartupPath + "\\" + Xml);
            //dt_DeptCode = ds.Tables[1];
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            System.Data.DataRow[] drs = dt.Select("DEPT_NAME like '%门诊%'");
            System.Data.DataSet Result = new System.Data.DataSet();
            Result.Merge(drs);
            drs = dt.Select("DEPT_NAME like '%病房%'");
            Result.Merge(drs);
            drs = dt.Select("DEPT_NAME not like '%病房%' and DEPT_NAME not like '%门诊%'");
            Result.Merge(drs);
            cmb_ReferDept.DataSource = Result.Tables[0].DefaultView;
            cmb_ReferDept.DisplayMember = Result.Tables[0].Columns["DEPT_NAME"].ColumnName;
            cmb_ReferDept.ValueMember = Result.Tables[0].Columns["DEPT_CODE"].ColumnName;
            return Result.Tables[0];
        }

        /// <summary>
        /// 绑定费别
        /// </summary>
        /// <param name="cmb_ChargeType"></param>
        public void Bind_ChargeType(ComboBox cmb_ChargeType)
        {
            string sql = "select SERIAL_NO as CHARGE_TYPE_CODE,CHARGE_TYPE_NAME from CHARGE_TYPE_DICT";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            cmb_ChargeType.DataSource = dt;
            cmb_ChargeType.DisplayMember = dt.Columns["CHARGE_TYPE_NAME"].ColumnName;
            cmb_ChargeType.ValueMember = dt.Columns["CHARGE_TYPE_CODE"].ColumnName;
            //this.charge_ratio = 0;
            //Get_Charges();//当前选中的费别率×费用
        }

        /// <summary>
        /// 绑定申请医生
        /// </summary>
        /// <param name="cmb_ChargeType"></param>
        public void Bind_ReferDoctor(string ReferDept, ComboBox cmb_ReferDoctor)
        {
            string sql = "select distinct b.USER_NAME,b.name from STAFF_VS_GROUP a, STAFF_DICT b " +
                          "where a.emp_no =b.emp_no and GROUP_CODE = '" + ReferDept + "'";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            cmb_ReferDoctor.DataSource = dt;
            cmb_ReferDoctor.DisplayMember = dt.Columns["NAME"].ColumnName;
            //}
        }


        /// <summary>
        /// 检查类别、检查子类检索表EXAM_ITEM_DICT得到数据集绑定至检查项目列表中
        /// </summary>
        public System.Data.DataTable Bind_ExamItem(string ExamClass, string ExamSubClass, ComboBox cmb_ExamItem)
        {
            string sql = "select DESCRIPTION as EXAM_ITEM_NAME,DESCRIPTION_CODE as EXAM_ITEM_CODE ,INPUT_CODE from EXAM_RPT_PATTERN where EXAM_CLASS='" + ExamClass + "' and EXAM_SUB_CLASS='" + ExamSubClass + "' and DESC_ITEM = '检查项目'";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            if (GetConfig.RM_ExamItemSort)
            {
                ExamItemSorter examItemSorter = new ExamItemSorter("");
                dt = examItemSorter.ExamItemSort(ExamClass, ExamSubClass,dt);
            }
            cmb_ExamItem.DataSource = dt.DefaultView;
            cmb_ExamItem.DisplayMember = dt.Columns["EXAM_ITEM_NAME"].ColumnName;
            cmb_ExamItem.ValueMember = dt.Columns["EXAM_ITEM_CODE"].ColumnName;
            return dt;
        }

        public decimal GetChargeRatio(string ChargeType)
        {
            string sql = "select PRICE_COEFF_NUMERATOR,PRICE_COEFF_DENOMINATOR from CHARGE_PRICE_SCHEDULE where CHARGE_TYPE = '" + ChargeType + "'";
            System.Data.DataTable dt_ChargeTtype = GetDataSet(sql).Tables[0];
            string price_coeff_numerator = dt_ChargeTtype.Rows[0]["PRICE_COEFF_NUMERATOR"].ToString();
            string price_coeff_denominator = dt_ChargeTtype.Rows[0]["PRICE_COEFF_DENOMINATOR"].ToString();
            if (price_coeff_numerator == "" && price_coeff_denominator == "")
                return 0;
            else
                return decimal.Parse(price_coeff_numerator) / decimal.Parse(price_coeff_denominator);
        }

        /// <summary>
        /// 绑定诊疗项目与价表项目对照
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable Bind_ClinicVsCharge()
        {
            string sql = "select " +
                          "CLINIC_ITEM_CLASS," +
                          "CLINIC_ITEM_CODE as EXAM_ITEM_CODE," +
                          "CHARGE_ITEM_NO," +
                          "AMOUNT," +
                          "CHARGE_ITEM_CLASS," +
                          "CHARGE_ITEM_CODE," +
                          "CHARGE_ITEM_SPEC," +
                          "UNITS " +
                          "from CLINIC_VS_CHARGE "; 
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 绑定当前价表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable Bind_CurrentPriceList()
        {
            string sql = "select " +
                          "c.INPUT_CODE, " +
                          "b.CLASS_NAME," +
                          "a.ITEM_NAME," +
                          "a.ITEM_CODE," +
                          "a.ITEM_CLASS, " +
                          "a.ITEM_SPEC," +
                          "a.UNITS," +
                          "a.PRICE " +
                          "from CURRENT_PRICE_LIST a,BILL_ITEM_CLASS_DICT b,PRICE_ITEM_NAME_DICT c where  a.ITEM_CLASS =b.CLASS_CODE and a.ITEM_CLASS=c.ITEM_CLASS and a.ITEM_CODE=c.ITEM_CODE and STD_INDICATOR =1 ";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 关联两表CHARGE_ITEM_DICT_VIEW和EXAM_VS_CHARGE取得数据集并填充Datatable
        /// </summary>
        public System.Data.DataTable Bind_ExamVsCharge()
        {
            System.Data.DataTable dt_ClinicVsCharge = Bind_ClinicVsCharge();
            System.Data.DataTable dt_CurrentPriceList = Bind_CurrentPriceList();
            System.Data.DataTable dt = new System.Data.DataTable();
            int i = 0;
            dt.Columns.Add(new System.Data.DataColumn("CLASS_NAME", dt_CurrentPriceList.Columns["CLASS_NAME"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_CLASS", dt_CurrentPriceList.Columns["ITEM_CLASS"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_NAME", dt_CurrentPriceList.Columns["ITEM_NAME"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_SPEC", dt_CurrentPriceList.Columns["ITEM_SPEC"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("AMOUNT", dt_ClinicVsCharge.Columns["AMOUNT"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("UNITS", dt_CurrentPriceList.Columns["UNITS"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("PRICE", dt_CurrentPriceList.Columns["PRICE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("EXAM_ITEM_CODE", dt_ClinicVsCharge.Columns["EXAM_ITEM_CODE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_CODE", dt_CurrentPriceList.Columns["ITEM_CODE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("COSTS", dt_CurrentPriceList.Columns["PRICE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("CHARGES", dt_CurrentPriceList.Columns["PRICE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("CHARGE_ITEM_NO", dt_ClinicVsCharge.Columns["CHARGE_ITEM_NO"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("INPUT_CODE", dt_CurrentPriceList.Columns["INPUT_CODE"].DataType));
            System.Data.DataRow[] Rows;
            for (i = 0; i < dt_ClinicVsCharge.Rows.Count; i++)
            {
                Rows = dt_CurrentPriceList.Select("ITEM_CODE='" + dt_ClinicVsCharge.Rows[i]["CHARGE_ITEM_CODE"].ToString() + "' and ITEM_SPEC = '" + dt_ClinicVsCharge.Rows[i]["CHARGE_ITEM_SPEC"].ToString() + "' and UNITS ='" + dt_ClinicVsCharge.Rows[i]["UNITS"].ToString() + "'");
                foreach (System.Data.DataRow drow in Rows)
                {
                    decimal amount = dt_ClinicVsCharge.Rows[i]["AMOUNT"].ToString() == "" ? 0 : decimal.Parse(dt_ClinicVsCharge.Rows[i]["AMOUNT"].ToString());
                    decimal costs = amount * decimal.Parse(drow["PRICE"].ToString());
                    dt.Rows.Add(new object[] { drow["CLASS_NAME"], drow["ITEM_CLASS"], drow["ITEM_NAME"], drow["ITEM_SPEC"], dt_ClinicVsCharge.Rows[i]["AMOUNT"], drow["UNITS"], drow["PRICE"], dt_ClinicVsCharge.Rows[i]["EXAM_ITEM_CODE"], drow["ITEM_CODE"], costs, costs, dt_ClinicVsCharge.Rows[i]["CHARGE_ITEM_NO"], drow["INPUT_CODE"] });
                }
            }
            return dt;
        }

        /// <summary>
        /// 判断病人档案中是否有该病人资料
        /// </summary>
        /// <returns></returns>
        public bool CheckPatientIDInHIS(string PatientId)
        {
            string sql = "select Patient_ID from PAT_MASTER_INDEX where PATIENT_ID='" + PatientId + "'";
            return recordIsExist(sql);
        }

        /// <summary>
        /// 删除EXAM_APPOINTS表记录
        /// </summary>
        public bool DeleteExamAppoints(string EXAM_NO)
        {
            string sql = "delete from EXAM_APPOINTS where EXAM_NO ='" + EXAM_NO + "'";
            bool issuccess = ExecuteSql(sql) > 0 ? true : false;
            return issuccess;
        }

        /// <summary>
        /// 插入INP_BILL_DETAIL表数据
        /// </summary>
        public bool AddInpBillDetail(List<System.Data.DataTable> Now_DT_VS_Group, int ChargeItemNo, string EXAM_DEPT, string REFER_DEPT, decimal chargeRatio, string PatientId, int? VisitId, string UserId)
        {
            string sql = "";
            bool issuccess = true;
            int i = 0, item_no = ChargeItemNo;
            for (i = 0; i < Now_DT_VS_Group.Count; i++)
            {
                if (Now_DT_VS_Group[i] != null)
                {
                    for (int j = 0; j < Now_DT_VS_Group[i].Rows.Count; j++)
                    {
                        sql = this.SqlInsertINP_BILL_DETAILOdbc(Now_DT_VS_Group[i], j, item_no.ToString(), EXAM_DEPT, REFER_DEPT, chargeRatio, PatientId, VisitId, UserId);
                        issuccess &= ExecuteSql(sql) > 0 ? true : false;
                        item_no++;
                    }
                }
            }
            return issuccess;
        }

        /// <summary>
        /// 住院病人费用明细表中ITEM_NO下一个值
        /// </summary>
        public int GetChargeItemNo(string PatientId, int? VisitId)
        {
            string sql = " select max(ITEM_NO) from INP_BILL_DETAIL where PATIENT_ID = '" + PatientId + "' and VISIT_ID = " + VisitId.ToString();
            string item_no = ExecuteScalar(sql);
            int ChargeItemNo = item_no == "" ? 1 : Convert.ToInt32(item_no) + 1;//住院病人费用明细表中ITEM_NO的下一个值
            return ChargeItemNo;
        }

        /// <summary>
        /// 插入INP_BILL_DETAIL表SQl语句
        /// </summary>
        /// <param name="DT"></param>
        /// <param name="NO"></param>
        /// <param name="ITEM_NO"></param>
        /// <param name="EXAM_DEPT"></param>
        /// <param name="REFER_DEPT"></param>
        /// <param name="chargeRatio"></param>
        /// <param name="PatientId"></param>
        /// <param name="VisitId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        private string SqlInsertINP_BILL_DETAILOdbc(System.Data.DataTable DT, int NO, string ITEM_NO, string EXAM_DEPT, string REFER_DEPT, decimal chargeRatio,string PatientId,int? VisitId,string UserId)
        {
            string EXAM_CONFIRM_TIME = " to_date('" + DateTime.Now.ToString() + "','YYYY-MM-DD HH24:MI:SS')";
            string CHARGE_ITEM_CODE = DT.Rows[NO]["ITEM_CODE"].ToString();
            string CHARGE_ITEM_SPEC = DT.Rows[NO]["ITEM_SPEC"].ToString();
            string AMOUNT = DT.Rows[NO]["AMOUNT"].ToString();
            string UNITS = DT.Rows[NO]["UNITS"].ToString();
            string ITEM_CLASS = DT.Rows[NO]["ITEM_CLASS"].ToString();
            string CHARGE_ITEM_NAME = DT.Rows[NO]["ITEM_NAME"].ToString();
            string COSTS = DT.Rows[NO]["COSTS"].ToString();
            decimal CHARGE = decimal.Parse(DT.Rows[NO]["COSTS"].ToString()) * chargeRatio;
            string Sqlstr = "insert into INP_BILL_DETAIL (PATIENT_ID," +
                                             "VISIT_ID," +
                                             "ITEM_NO," +
                                             "ITEM_CLASS," +
                                             "ITEM_NAME," +
                                             "ITEM_CODE," +
                                             "ITEM_SPEC," +
                                             "AMOUNT," +
                                             "UNITS," +
                                             "ORDERED_BY," +
                                             "PERFORMED_BY," +
                                             "COSTS," +
                                             "CHARGES," +
                                             "BILLING_DATE_TIME," +
                                             "OPERATOR_NO" +
                //"RCPT_NO "+
                                             ") values ('" +
                                             PatientId + "','" +
                                             VisitId.ToString() + "'," +
                                             ITEM_NO + ",'" +
                                             ITEM_CLASS + "','" +
                                             CHARGE_ITEM_NAME + "','" +
                                             CHARGE_ITEM_CODE + "','" +
                                             CHARGE_ITEM_SPEC + "','" +
                                             AMOUNT + "','" +
                                             UNITS + "','" +
                                             REFER_DEPT + "','" +
                                             EXAM_DEPT + "','" +
                                             COSTS + "','" +
                                             CHARGE + "'," +
                                             EXAM_CONFIRM_TIME + ",'" +
                                             UserId + "')";
            return Sqlstr;
        }


        #region 更新住院病人检查费用明细表记录

        //private bool SetINP_BILL_DETAILOdbc(string PATIENT_ID, string VISIT_ID)
        //{
        //    int i;
        //    bool success = true;
        //    string EXAM_DEPT = "";
        //    string EXAM_ACCESSION_NUM = this.sch_worklistInf.EXAM_ACCESSION_NUM;
        //    if (comb_EXAM_DEPT.SelectedIndex != -1)
        //    {
        //        EXAM_DEPT = comb_EXAM_DEPT.SelectedValue == null ? "" : comb_EXAM_DEPT.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        EXAM_DEPT = comb_EXAM_DEPT.Text.ToString();
        //    }
        //    string REFER_DEPT = "";
        //    if (comb_APPLY_DEPT.SelectedIndex != -1)
        //    {
        //        REFER_DEPT = comb_APPLY_DEPT.SelectedValue == null ? "" : comb_APPLY_DEPT.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        REFER_DEPT = comb_APPLY_DEPT.Text.ToString();
        //    }
        //    for (i = 0; i < this.Now_DT_VS.Rows.Count; i++)
        //    {
        //        string Sqlstr = this.DeleteINP_BILL_DETAILOdbc(PATIENT_ID, VISIT_ID, this.Now_DT_VS.Rows[i]["ITEM_NO"].ToString());
        //        success = DBoperate.OdbcUpdate(Sqlstr, this.connOdbc);
        //        if (!success)
        //        {
        //            break;
        //        }
        //    }
        //    for (i = 0; i < this.Now_DT_VS_Group.Length; i++)
        //    {
        //        if (this.Now_DT_VS_Group[i] != null)
        //        {
        //            for (int j = 0; j < this.Now_DT_VS_Group[i].Rows.Count; j++)
        //            {
        //                string Sqlstr = this.SqlInsertINP_BILL_DETAILOdbc(this.Now_DT_VS_Group[i], j, this.Now_DT_VS_Group[i].Rows[j]["ITEM_NO"].ToString(), EXAM_DEPT, REFER_DEPT);
        //                success = DBoperate.OdbcUpdate(Sqlstr, this.connOdbc);
        //                if (!success)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return success;

        //}

        public string DeleteInpBillDetail(string PATIENT_ID, string VISIT_ID, string ITEM_NO)
        {
            string sql = "delete from INP_BILL_DETAIL where PATIENT_ID = '" + PATIENT_ID + "' and VISIT_ID = " + VISIT_ID + " and ITEM_NO = " + ITEM_NO;
            return sql;
        }

        #endregion

        public System.Data.DataTable SelectExamAppoints(string ExamClass,string where)
        {
            string sql = "select f.PATIENT_ID,f.NAME,f.NAME_PHONETIC,f.SEX,f.DATE_OF_BIRTH,f.REQ_DATE_TIME,f.EXAM_CLASS,f.EXAM_SUB_CLASS,f.CHARGE_TYPE,f.COSTS,f.CHARGES," +
                            "f.PATIENT_LOCAL_ID,b.PATIENT_SOURCE_NAME,e.DEPT_NAME as REQ_DEPT_NAME,f.REQ_PHYSICIAN,d.DEPT_NAME as PERFORMED_BY_NAME," +
                            "f.EXAM_NO,f.VISIT_ID,f.LOCAL_ID_CLASS,f.IDENTITY,f.MAILING_ADDRESS,f.ZIP_CODE,f.PHONE_NUMBER,f.CLIN_SYMP," +
                            "f.PHYS_SIGN,f.RELEVANT_LAB_TEST,f.RELEVANT_DIAG,f.CLIN_DIAG,f.EXAM_MODE,f.EXAM_GROUP,f.PERFORMED_BY," +
                            "f.PATIENT_SOURCE,f.FACILITY,f.REQ_DEPT,f.REQ_MEMO,f.SCHEDULED_DATE,f.NOTICE,f.BIRTH_PLACE," +
                            "c.AREA_NAME from EXAM_APPOINTS f,PATIENT_SOURCE_DICT b,AREA_DICT c,DEPT_DICT d,DEPT_DICT e,pat_master_index a "+
                            "where f.PATIENT_SOURCE=b.PATIENT_SOURCE_CODE(+) and f.BIRTH_PLACE=c.AREA_CODE(+) and  f.REQ_DEPT=e.DEPT_CODE(+) and f.PERFORMED_BY=d.DEPT_CODE(+) and f.PATIENT_ID=a.PATIENT_ID " +
                            ExamClass + where;
            //"and a.EXAM_CLASS in (" + this.ExamClass + ") and a.PATIENT_SOURCE in ( " + PatientSource + ")";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        public System.Data.DataTable SelectPatMasterIndex(string where)
        {
            string sql = "select PATIENT_ID,INP_NO,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,CHARGE_TYPE,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP," +
                            "NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE,LAST_VISIT_DATE,VIP_INDICATOR,CREATE_DATE,OPERATOR,b.AREA_NAME from PAT_MASTER_INDEX a, AREA_DICT b  where a.BIRTH_PLACE =b.AREA_CODE(+) " + where;
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        public System.Data.DataTable SelectPatsInHospital(string where)
        {
            string sql = "Select SETTLED_INDICATOR,TOTAL_COSTS,TOTAL_CHARGES,BED_NO from PATS_IN_HOSPITAL where " + where;
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        public System.Data.DataTable SelectExamItems(string EXAM_NO)
        {
            string sql = "Select distinct EXAM_ITEM_CODE,EXAM_ITEM_NO,EXAM_ITEM,COSTS from EXAM_ITEMS where EXAM_NO = '" + EXAM_NO + "'";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        public string SelectInp(string patient_id)
        {
            string sql = "select inp_no from pat_master_index where patient_id ='" + patient_id + "'";
           return ExecuteScalar(sql);
        }

        public string SelectBed(string patient_id)
        {
            string sql = "select bed_no from pats_in_hospital where patient_id = '" + patient_id + "'";
            return ExecuteScalar(sql);
        }


        public System.Data.DataTable SelectOutpOrderDesc(string where)
        {
            string sql = "select b.ordered_by_dept,b.ordered_by_doctor,c.dept_name from outp_bill_items a,outp_order_desc b,dept_dict c where b.ordered_by_dept = c.dept_code and a.rcpt_no=b.rcpt_no and a.visit_date between trunc(sysdate) and trunc(sysdate+1) and " + where + " order by a.visit_no desc";
            //string Sqlstr = "select a.ORDERED_BY_DEPT,a.ORDERED_BY_DOCTOR,b.DEPT_NAME from OUTP_ORDER_DESC a,DEPT_DICT b where a.ORDERED_BY_DEPT = b.DEPT_CODE and a.PATIENT_ID ='" + patient_id + "' and a.VISIT_DATE = ? ";
            System.Data.DataTable dt =  GetDataSet(sql).Tables[0];
            return dt;
        }

        public string GetExamNo()
        {
            BGetSeqValue bGetSeqValue = new BGetSeqValue("HIS", "exam_no_seq");
            return bGetSeqValue.GetSeqValue();
        }
    }
}
