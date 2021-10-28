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
    /// 采购订单page1数据交互
    /// </summary>
    public class PurchaseOrder_page1_Service : BaseService
    {
        public static string InsertPurchaseOrder_page1()
        {
            // 1、查询odoo  采购订单page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在查询OdooHelper().GetPurchaseOrder_page1()" + DateTime.Now);
            List<PurchaseOrder_page1> dt = new OdooHelper().GetPurchaseOrder_page1();
            if (dt == null)
                return "no,没有查到odoo采购订单page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->查询OdooHelper().GetPurchaseOrder_page1()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                PurchaseOrder_page1 item = dt[i];

                #region 获取部门Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入部门表 t_Department FName=" + item.hr_department_name + DateTime.Now);
                int t_Department_FItemID = 0;//部门Id
                object t_DepartmentSearchByFNameResult = SearchByColumnName("FItemID", "t_Department", "FName", item.hr_department_name);
                if (string.IsNullOrEmpty(item.hr_department_name) || t_DepartmentSearchByFNameResult == null)
                {
                    #region 此部门在金蝶中不存在，以下为将此部门插入金蝶的代码
                    t_Department t_Department_entity = new t_Department()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Department"),
                        FNumber = !string.IsNullOrEmpty(item.hr_department_name) ? item.hr_department_name : item.hr_department_id,
                        FName = item.hr_department_name
                    };
                    new SqlHelper().SqlPour(t_DepartmentFormat.sql_t_Department(t_Department_entity), null);
                    t_Department_FItemID = t_Department_entity.FItemID;
                    #endregion
                }
                if (t_Department_FItemID == 0 && t_DepartmentSearchByFNameResult != null)
                {
                    t_Department_FItemID = Convert.ToInt32(t_DepartmentSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->部门表 t_Department 插入结束 FName=" + item.hr_department_name + DateTime.Now);
                #endregion

                #region 获取供应商Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入供应商表 t_Supplier FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                int t_Supplier_FItemID = 0;//供应商Id
                object t_SupplierSearchByFNameResult = SearchByColumnName("FItemID", "t_Supplier", "FName", item.res_partner_commercial_company_name);
                if (string.IsNullOrEmpty(item.res_partner_commercial_company_name) || t_SupplierSearchByFNameResult == null)
                {
                    #region 此供应商在金蝶中不存在，以下为将此客户插入金蝶的代码
                    t_Supplier t_Supplier_entity = new t_Supplier()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Supplier"),
                        FNumber = !string.IsNullOrEmpty(item.res_partner_commercial_company_name) ? item.res_partner_commercial_company_name : item.res_partner_id,
                        FName = item.res_partner_commercial_company_name
                    };
                    new SqlHelper().SqlPour(t_SupplierFormat.sql_t_Supplier(t_Supplier_entity), null);
                    t_Supplier_FItemID = t_Supplier_entity.FItemID;
                    #endregion
                }
                if (t_Department_FItemID == 0 && t_DepartmentSearchByFNameResult != null)
                {
                    t_Department_FItemID = Convert.ToInt32(t_DepartmentSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->供应商表 插入结束 t_Supplier FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入职员表 t_Base_Emp FName=" + "********" + DateTime.Now);
                int t_Base_Emp_FItemID = 0;//职员Id
                object t_Base_EmpSearchByFNameResult = SearchByColumnName("FItemID", "t_Base_Emp", "FName", "********");
                if (string.IsNullOrEmpty("********") || t_Base_EmpSearchByFNameResult == null)
                {
                    #region 此职员在金蝶中不存在，以下为将此职员插入金蝶的代码
                    t_Base_Emp t_Base_Emp_entity = new t_Base_Emp()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Base_Emp"),
                        FNumber = !string.IsNullOrEmpty("********") ? "********" : "********",
                        FName = "********"
                    };
                    new SqlHelper().SqlPour(t_Base_EmpFormat.sql_t_Base_Emp(t_Base_Emp_entity), null);
                    t_Base_Emp_FItemID = t_Base_Emp_entity.FItemID;
                    #endregion
                }
                if (t_Base_Emp_FItemID == 0 && t_Base_EmpSearchByFNameResult != null)
                {
                    t_Base_Emp_FItemID = Convert.ToInt32(t_Base_EmpSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->职员表 插入结束 t_Base_Emp FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入系统用户表 t_Base_User FName=" + "********" + DateTime.Now);
                int t_Base_User_FItemID = 0;//系统用户Id
                object t_Base_UserSearchByFNameResult = SearchByColumnName("FUserID", "t_Base_User", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_Base_UserSearchByFNameResult == null)
                {
                    #region 此系统用户在金蝶中不存在，以下为将此系统用户插入金蝶的代码
                    t_Base_User t_Base_User_entity = new t_Base_User()
                    {
                        FUserID = new SqlHelper().GetMaxId("FUserID", "t_Base_User"),
                        FPrimaryGroup = !string.IsNullOrEmpty("********") ? "********" : "********",
                        FName = "********"
                    };
                    new SqlHelper().SqlPour(t_Base_UserFormat.sql_t_Base_User(t_Base_User_entity), null);
                    t_Base_User_FItemID = t_Base_User_entity.FUserID;
                    #endregion
                }
                if (t_Base_User_FItemID == 0 && t_Base_UserSearchByFNameResult != null)
                {
                    t_Base_User_FItemID = Convert.ToInt32(t_Base_UserSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->系统用户表 插入结束  t_Base_User FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取币别Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入币别表 t_Currency FName=" + "********" + DateTime.Now);
                int t_Currency_FCurrencyID = 0;//币别Id
                object t_CurrencySearchByFNameResult = SearchByColumnName("FCurrencyID", "t_Currency", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_CurrencySearchByFNameResult == null)
                {
                    #region 此币别在金蝶中不存在，以下为将此币别插入金蝶的代码
                    t_Currency t_Currency_entity = new t_Currency()
                    {
                        FCurrencyID = new SqlHelper().GetMaxId("FCurrencyID", "t_Currency"),
                        //FNumber = ,
                        //FName = ,
                        //FOperator = ,
                        //FExchangeRate = ,
                        //FScale = ,
                        //FFixRate = ,
                        //FBrNo = ,
                        //FControl =,
                        //FDeleted = ,
                        //FSystemType = ,
                        //FClassTypeID =
                    };
                    new SqlHelper().SqlPour(t_CurrencyFormat.sql_t_Currency(t_Currency_entity), null);
                    t_Currency_FCurrencyID = t_Currency_entity.FCurrencyID;
                    #endregion
                }
                if (t_Currency_FCurrencyID == 0 && t_CurrencySearchByFNameResult != null)
                {
                    t_Currency_FCurrencyID = Convert.ToInt32(t_CurrencySearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->币别表 插入结束  t_Currency FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入辅助资料表 t_SubMessage FName=" + "********" + DateTime.Now);
                int t_SubMessage_FInterID = 0;
                object t_SubMessageSearchByFNameResult = SearchByColumnName("FInterID", "t_SubMessage", "*******", "*******");
                if (string.IsNullOrEmpty("*******") || t_SubMessageSearchByFNameResult == null)
                {
                    #region 此系统辅助资料在金蝶中不存在，以下为将此系统辅助资料插入金蝶的代码
                    t_SubMessage t_SubMessage_entity = new t_SubMessage()
                    {
                        //FBrNo = ,
                        FInterID = new SqlHelper().GetMaxId("FInterID", "t_SubMessage"),
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->辅助资料表 插入结束  t_SubMessage FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取结算方式Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入结算方式表 t_Settle *******" + "*******" + DateTime.Now);
                int t_Settle_FItemID = 0;
                object t_SettleSearchByFNameResult = SearchByColumnName("FItemID", "t_SubMessage", "*******", "*******");
                if (string.IsNullOrEmpty("*******") || t_SettleSearchByFNameResult == null)
                {
                    #region 此结算方式在金蝶中不存在，以下为将此结算方式插入金蝶的代码
                    t_Settle t_Settle_entity = new t_Settle()
                    {
                        //FBrNo = ,
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Settle"),
                        //FName = ,
                        //FNumber =
                    };
                    new SqlHelper().SqlPour(t_SettleFormat.sql_t_Settle(t_Settle_entity), null);
                    t_Settle_FItemID = t_Settle_entity.FItemID;
                    #endregion
                }
                if (t_Settle_FItemID == 0 && t_SettleSearchByFNameResult != null)
                {
                    t_Settle_FItemID = Convert.ToInt32(t_SettleSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->结算方式表 插入结束  t_Settle *******" + "*******" + DateTime.Now);
                #endregion

                #region 获取保税监管类型Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入保税监管类型表 t_BaseBondedManageType FName" + "*******" + DateTime.Now);
                int t_BaseBondedManageType_FID = 0; //保税监管类型
                object t_BaseBondedManageTypeSearchByFNameResult = SearchByColumnName("FID", "t_BaseBondedManageType", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_BaseBondedManageTypeSearchByFNameResult == null)
                {
                    #region 此保税监管类型在金蝶中不存在，以下为将此系统保税监管类型插入金蝶的代码
                    t_BaseBondedManageType t_BaseBondedManageType_entity = new t_BaseBondedManageType()
                    {
                        FID = new SqlHelper().GetMaxId("FID", "t_BaseBondedManageType"),
                        //FName = ,
                        //FNumber = item.,
                        //FParentID = ,
                        //FLogic = ,
                        //FDetail = ,
                        //FDiscontinued = ,
                        //FLevels = ,
                        //FFullNumber = ,
                        //FClassTypeID =
                    };
                    new SqlHelper().SqlPour(t_BaseBondedManageTypeFormat.sql_t_BaseBondedManageType(t_BaseBondedManageType_entity), null);
                    t_BaseBondedManageType_FID = t_BaseBondedManageType_entity.FID;
                    #endregion
                }
                if (t_BaseBondedManageType_FID == 0 && t_BaseBondedManageTypeSearchByFNameResult != null)
                {
                    t_BaseBondedManageType_FID = Convert.ToInt32(t_BaseBondedManageTypeSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入保税监管类型表 插入结束 t_BaseBondedManageType FName" + "*******" + DateTime.Now);
                #endregion

                // (1) 插入金蝶 POOrder表
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->正在插入采购订单表 POOrder "  + DateTime.Now);
                POOrder pOOrder = new POOrder() {
                    //FTranType = item.,
                    //FInterID = ,
                    FBillNo = item.stock_picking_name,
                    //FSupplyID = item.res_partner_id,
                    FDate = item.stock_picking_date_done,
                    //FEmpID = item.stock_picking_business_user,
                    //FDeptID = item.hr_department_id,
                    //FCurrencyID = item.,
                    //FCheckerID = item.stock_picking_audit,
                    //FBillerID = item.stock_picking_maker,
                    //FMangerID = item.,
                    //FPOStyle = item.,
                    //FRelateBrID = item.res_partner_id,
                    FCheckDate = item.audit_data,
                    //FExplanation = item.,
                    //FSettleDate = item.,
                    //FSettleID = item.,
                    //FSelTranType = item.stock_picking_type_name,
                    //FBrID = item.,
                    //FPOOrdBillNo = item.,
                    //FAreaPS = item.,
                    //FManageType = ,
                    //FSysStatus = ,
                    //FValidaterName = ,
                    //FConsignee = ,
                    //FPrintCount = ,
                    //FExchangeRateType = ,
                    //FDeliveryPlace = item.,
                    //FAccessoryCount = ,
                    //FPOMode = item.,
                    //FPlanCategory = item.,
                    //FLastAlterBillNo = ,
                };
                new SqlHelper().SqlPour(POOrderFormat.sql_POOrder(pOOrder), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->采购订单表 POOrder  插入结束 " +  DateTime.Now);
                // (2) 插入金蝶 t_Department表 ***

                // (3) 插入金蝶 t_Supplier表 ***

                // (4) 插入金蝶 t_Base_Emp表 ***

                // (5) 插入金蝶 t_Base_User表 ***

                // (6) 插入金蝶 t_Currency 表 ***

                // (7) 插入金蝶 t_SubMessage 表 ***

                // (8) 插入金蝶 t_Settle 表 ***

                // (9)插入金蝶 t_BaseBondedManageType 表 ***

                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
