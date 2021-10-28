using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using MonitorNew.Tools;
using OdooEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Services
{
    /// <summary>
    /// 调拨单page1数据交互
    /// </summary>
    public class Allocation_page1_Service : BaseService
    {
        public static string InsertAllocation_page1()
        {
            // 1、查询odoo  调拨单page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->正在查询OdooHelper().GetAllocation_page1()" + DateTime.Now);
            List<Allocation_page1> dt = new OdooHelper().GetAllocation_page1();
            if (dt == null)
                return "no,没有查到odoo调拨单page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->查询OdooHelper().GetAllocation_page1()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                Allocation_page1 item = dt[i];
                #region 循环插入金蝶
                #region 获取部门Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->获取部门Id的代码开始 FName" + item.hr_department_name + DateTime.Now);
                int t_Department_FItemID = 0;
                object t_DepartmentSearchByFNameResult = SearchByColumnName("FItemID", "t_Department", "FName", item.hr_department_name);
                if (string.IsNullOrEmpty(item.hr_department_name) || t_DepartmentSearchByFNameResult == null)
                {
                    #region 此部门在金蝶中不存在，以下为将此部门插入金蝶的代码
                    t_Department t_Department_entity = new t_Department()
                    {
                        //FNumber = item.,
                        FName = item.hr_department_name,
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Department")
                    };
                    new SqlHelper().SqlPour(t_DepartmentFormat.sql_t_Department(t_Department_entity), null);
                    t_Department_FItemID = t_Department_entity.FItemID;
                   
                    #endregion
                }
                if (t_Department_FItemID == 0 && t_DepartmentSearchByFNameResult != null)
                {
                    t_Department_FItemID = Convert.ToInt32(t_DepartmentSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->部门表 t_Department 插入结束 FName=" + item.hr_department_name + DateTime.Now);
                #endregion

                #region 获取客户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->正在插入客户表 t_Organization FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                int t_Organization_FItemID = 0;
                object t_OrganizationSearchByFNameResult = SearchByColumnName("FItemID", "t_Organization", "FName", item.res_partner_commercial_company_name);
                if (string.IsNullOrEmpty(item.hr_department_name) || t_OrganizationSearchByFNameResult == null)
                {
                    #region 此客户在金蝶中不存在，以下为将此客户插入金蝶的代码
                    t_Organization t_Organization_entity = new t_Organization()
                    {
                        //FNumber = ,
                        FName = item.res_partner_commercial_company_name,
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Organization")

                    };
                    new SqlHelper().SqlPour(t_OrganizationFormat.sql_t_Organization(t_Organization_entity), null);
                    t_Organization_FItemID = t_Organization_entity.FItemID;
                    #endregion
                }
                if (t_Organization_FItemID == 0 && t_OrganizationSearchByFNameResult != null)
                {
                    t_Organization_FItemID = Convert.ToInt32(t_OrganizationSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->客户表 插入结束 t_Organization FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->正在插入职员表 t_Base_Emp FName=" + "********" + DateTime.Now);
                int t_Base_Emp_FItemID = 0;
                object t_Base_EmpSearchByFNameResult = SearchByColumnName("FItemID", "t_Base_Emp", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_Base_EmpSearchByFNameResult == null)
                {
                    #region 此职员在金蝶中不存在，以下为将此职员插入金蝶的代码
                    t_Base_Emp t_Base_Emp_entity = new t_Base_Emp()
                    {
                        //FNumber = ,
                        //FName = ,
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Base_Emp")
                    };
                    new SqlHelper().SqlPour(t_Base_EmpFormat.sql_t_Base_Emp(t_Base_Emp_entity), null);
                    t_Base_Emp_FItemID = t_Base_Emp_entity.FItemID;
                    #endregion
                }
                if (t_Base_Emp_FItemID == 0 && t_Base_EmpSearchByFNameResult != null)
                {
                    t_Base_Emp_FItemID = Convert.ToInt32(t_Base_EmpSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->职员表 插入结束 t_Base_Emp FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->正在插入系统用户表 t_Base_User FName=" + "********" + DateTime.Now);
                int t_Base_User_FUserID = 0;
                object t_Base_UserSearchByFNameResult = SearchByColumnName("FUserID", "t_Base_User", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_Base_UserSearchByFNameResult == null)
                {
                    #region 此系统用户在金蝶中不存在，以下为将此系统用户插入金蝶的代码
                    t_Base_User t_Base_User_entity = new t_Base_User()
                    {
                        FUserID = new SqlHelper().GetMaxId("FUserID", "t_Base_User"),
                        //FPrimaryGroup = ,
                        //FName = item.

                    };
                    new SqlHelper().SqlPour(t_Base_UserFormat.sql_t_Base_User(t_Base_User_entity), null);
                    t_Base_User_FUserID = t_Base_User_entity.FUserID;
                    #endregion
                }
                if (t_Base_User_FUserID == 0 && t_Base_UserSearchByFNameResult != null)
                {
                    t_Base_User_FUserID = Convert.ToInt32(t_Base_UserSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->系统用户表 插入结束  t_Base_User FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->正在插入辅助资料表 t_SubMessage FName=" + "********" + DateTime.Now);
                int t_SubMessage_FInterID = 0;
                object t_SubMessageSearchByFNameResult = SearchByColumnName("FInterID", "t_SubMessage", "*******", "*******");
                if (string.IsNullOrEmpty("*******") || t_SubMessageSearchByFNameResult == null)
                {
                    #region 此系统辅助资料在金蝶中不存在，以下为将此系统辅助资料插入金蝶的代码
                    t_SubMessage t_SubMessage_entity = new t_SubMessage()
                    {
                        //FBrNo = ,
                        FInterID = new SqlHelper().GetMaxId("FInterID", "t_SubMessage") ,
                        //FID = ,
                        //FParentID = ,
                        //FName = item.,
                        //FTypeID = ,
                        //FDetail = ,
                        //FDeleted = ,
                        //FSystemType = ,
                        //FSpec =               //未定义

                    };
                    new SqlHelper().SqlPour(t_SubMessageFormat.sql_t_SubMessage(t_SubMessage_entity), null);
                    t_SubMessage_FInterID = t_SubMessage_entity.FInterID;
                    #endregion
                }
                if (t_SubMessage_FInterID == 0 && t_SubMessageSearchByFNameResult != null)
                {
                    t_SubMessage_FInterID = Convert.ToInt32(t_SubMessageSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->辅助资料表 插入结束  t_SubMessage FName=" + "********" + DateTime.Now);
                #endregion

                // (1) 插入金蝶 ICStockBill 表***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->正在插入出入库单据表 ICStockBill" + DateTime.Now);
                ICStockBill iCStockBill = new ICStockBill()
                {
                    FCheckDate = item.audit_data,
                    FDate = item.stock_picking_date_done,
                    //FBillerID = item.stock_picking_maker,
                    //FBillNo = item.,
                    FCheckerID = t_Base_User_FUserID ,
                    //FBrID = ,
                    //FTranType = item.,
                    //FInterID = ,
                    FFManagerID = t_Base_Emp_FItemID ,
                    FSManagerID = t_Base_Emp_FItemID ,
                    //FSelTranType = item.stock_picking_type_name,
                    FDeptID = t_Department_FItemID ,
                    //FEmpID = item.stock_picking_business_user,
                    FRefType = t_SubMessage_FInterID,
                    //FPrintCount = item.,
                    //FVchInterID = item.
                };
                new SqlHelper().SqlPour(ICStockBillFormat.sql_ICStockBill(iCStockBill), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->出入库单据表 ICStockBill 插入结束" + DateTime.Now);
                // (2) 插入金蝶 t_Department 表***  ====顶端已判断，按需插入

                // (3) 插入金蝶 t_Organization 表*** ====顶端已判断，按需插入

                // (4) 插入金蝶 t_Base_Emp 表*** ====顶端已判断，按需插入

                // (5) 插入金蝶 t_Base_User 表*** ====顶端已判断，按需插入

                //(6) 插入金蝶 t_SubMessage 表*** ====顶端已判断，按需插入

                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
