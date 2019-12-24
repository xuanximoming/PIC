using System;
using System.Collections.Generic;
using System.Text;

namespace ILL
{
    /// <summary>
    /// 构造where条件子句
    /// </summary>
    public class WhereNode
    {
        List<string> LogicOptrs = new List<string>(); //存放条件之间逻辑符号的字符串数组
        List<WhereNode> SubNodes = new List<WhereNode>();//存放子结点对象引用的对象数组
        string Condition = "";   //条件字符串

        /// <summary>
        /// 判断该结点是否为叶子结点
        /// </summary>
        public bool IsLeaf 
        {
            get
            {
                if (Condition != "" && SubNodes.Count == 0)
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// 判断该结点是否还没有初始化
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (Condition == "" && SubNodes.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public void SetConditionString(string Cond)
        {
            this.Condition = Cond;
        }

        /// <summary>
        /// 返回该结点所表示的条件表达式
        /// </summary>
        /// <returns></returns>
        public string GetConditionString()
        {
            string GetConditionString;
            if (IsLeaf) //如果是简单条件结点,直接返回 Conditions的值
                GetConditionString = this.Condition;
            if (GetSubNodeCount() == 1)//如果有一个子结点,则返回该子结点的条件表达式
                GetConditionString = this.SubNodes[0].GetConditionString();
            else
            {
                if (this.SubNodes[0].IsLeaf)
                    GetConditionString = this.SubNodes[0].GetConditionString();
                else
                    GetConditionString = "(" + this.SubNodes[0].GetConditionString() + ")";
                for (int i = 1; i < this.SubNodes.Count; i++)
                {
                    if (this.SubNodes[i].IsLeaf)
                        GetConditionString = GetConditionString + " " + this.LogicOptrs[i - 1] + " " + this.SubNodes[i].GetConditionString();
                    else
                        GetConditionString = GetConditionString + " " + this.LogicOptrs[i - 1] + "(" + this.SubNodes[i].GetConditionString() + ")";
                }
            }
            return GetConditionString;
        }

        /// <summary>
        /// 获取子节点数目
        /// </summary>
        /// <returns></returns>
        public int GetSubNodeCount()
        {
            return this.SubNodes.Count;
        }

        public bool AddSubNode(WhereNode newNode, string sLogicOptr)
        {
            if (sLogicOptr == "")//如果sLogicOpt r 为零长度字符串,则表示加入的是第一个结点;如果已有子结点,又未提供逻辑符号,则产生错误
                if (this.GetSubNodeCount() > 0)
                    return false;
                else
                    this.SubNodes[0] = newNode;
            else
                if (this.GetSubNodeCount() == 0)
                    AddSubNode(newNode, "");
                else
                {
                    this.SubNodes[this.SubNodes.Count + 1] = newNode;
                    this.LogicOptrs[this.SubNodes.Count - 1] = sLogicOptr;
                }
            return true;
        }
    }
}
