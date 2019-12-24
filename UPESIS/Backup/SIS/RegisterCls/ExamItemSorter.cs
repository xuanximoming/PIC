using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace SIS.RegisterCls
{
    class ExamItemSorter:DBControl
    {
        public ExamItemSorter()
            : base(GetConfig.GetSisConnStr())
        {
        }
        public ExamItemSorter(bool isPacs)
            : base(GetConfig.GetPacsConnStr())
        {
        }
        public ExamItemSorter(string isHis)
            : base(GetConfig.GetHisConnStr())
        {
        }

        private struct ExamItemStruct
        {
            public string ExamItemName;
            public int ExamItemCount;
        }

        public System.Data.DataTable ExamItemSort(string ExamClass,string ExamSubClass,System.Data.DataTable dt_Item)
        {
            int sortdays = GetConfig.RM_SortDays;
            string sql = "select EXAM_ITEMS from worklist where EXAM_CLASS = '" + ExamClass +
                "' and exam_sub_class = '" + ExamSubClass + 
                "' and req_date_time between to_date('" + System.DateTime.Now.AddDays(-Convert.ToInt32(sortdays)).ToShortDateString() + 
                "','yyyy-mm-dd') and to_date('" + System.DateTime.Now.ToShortDateString() + "','yyyy-mm-dd') ";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                System.Collections.ArrayList exam_items = new System.Collections.ArrayList();
                ExamItemStruct[] examstruct = new ExamItemStruct[dt_Item.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[] items = dt.Rows[i]["EXAM_ITEMS"].ToString().Split(';');
                    for (int j = 0; j < items.Length; j++)
                    {
                        exam_items.Add(items[j]);
                    }
                }
                for (int i = 0; i < dt_Item.Rows.Count; i++)
                {
                    int count = 0;
                    for (int j = 0; j < exam_items.Count; j++)
                    {
                        if (dt_Item.Rows[i]["EXAM_ITEM_NAME"].ToString() == exam_items[j].ToString())
                        {
                            count--;
                        }
                    }
                    examstruct[i] = new ExamItemStruct();
                    examstruct[i].ExamItemName = dt_Item.Rows[i]["EXAM_ITEM_NAME"].ToString();
                    examstruct[i].ExamItemCount = count;
                    //exam_items_count[i] = count;
                }
                this.ShellSorter(ref examstruct);
                System.Data.DataTable Exam_Item_New = new System.Data.DataTable();
                Exam_Item_New.Columns.Add("EXAM_ITEM_NAME", typeof(string));
                Exam_Item_New.Columns.Add("EXAM_ITEM_CODE", typeof(string));
                for (int i = 0; i < examstruct.Length; i++)
                {
                    for (int j = 0; j < dt_Item.Rows.Count; j++)
                    {
                        if (examstruct[i].ExamItemName == dt_Item.Rows[j]["EXAM_ITEM_NAME"].ToString())
                        {
                            Exam_Item_New.Rows.Add(new object[] { dt_Item.Rows[j]["EXAM_ITEM_NAME"].ToString(), dt_Item.Rows[j]["EXAM_ITEM_CODE"].ToString() });
                        }
                    }
                }
                return Exam_Item_New;
            }
            else
            {
                return dt_Item;
            }
        }

        private void ShellSorter(ref ExamItemStruct[] arr)
        {
            int inc;
            for (inc = 1; inc <= arr.Length / 9; inc = 3 * inc + 1) ;
            for (; inc > 0; inc /= 3)
            {
                for (int i = inc + 1; i <= arr.Length; i += inc)
                {
                    ExamItemStruct e = arr[i - 1];
                    int t = arr[i - 1].ExamItemCount;
                    int j = i;
                    while ((j > inc) && (arr[j - inc - 1].ExamItemCount > t))
                    {
                        arr[j - 1] = arr[j - inc - 1];
                        j -= inc;
                    }
                    arr[j - 1] = e;
                }
            }
        }

    }
}
