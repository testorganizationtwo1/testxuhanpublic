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
    /// 虚仓出库page1数据交互
    /// </summary>
    public class VirtualWarehouseDelivery_page1_Service : BaseService
    {
        public static string InsertVirtualWarehouseDelivery_page1()
        {
            // 1、查询odoo  虚仓出库page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入OdooHelper().GetVirtualWarehouseDelivery_page1()" + DateTime.Now);
            List<VirtualWarehouseDelivery_page1> dt = new OdooHelper().GetVirtualWarehouseDelivery_page1();
            if (dt == null)
                return "no,没有查到odoo虚仓出库page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->插入OdooHelper().GetVirtualWarehouseDelivery_page1()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                VirtualWarehouseDelivery_page1 item = dt[i];
                #region 获取部门Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入部门表 t_Department FName=" + item.hr_department_name + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->部门表 t_Department 插入结束 FName=" + item.hr_department_name + DateTime.Now);
                #endregion

                #region 获取供应商Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入供应商表 t_Supplier FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                int t_Supplier_FItemID = 0;//供应商Id
                object t_SupplierSearchByFNameResult = SearchByColumnName("FItemID", "t_Supplier", "FName", item.res_partner_commercial_company_name);
                if (string.IsNullOrEmpty(item.res_partner_commercial_company_name) || t_SupplierSearchByFNameResult == null)
                {
                    #region 此供应商在金蝶中不存在，以下为将此客户插入金蝶的代码
                    t_Supplier t_Supplier_entity = new t_Supplier()
                    {
                        FItemID =  new SqlHelper().GetMaxId("FItemID", "t_Supplier"),
                        FNumber = !string.IsNullOrEmpty(item.res_partner_commercial_company_name) ? item.res_partner_commercial_company_name : item.res_partner_id,
                        FName = item.res_partner_commercial_company_name
                    };
                    new SqlHelper().SqlPour(t_SupplierFormat.sql_t_Supplier(t_Supplier_entity), null);
                    t_Supplier_FItemID = t_Supplier_entity.FItemID;
                    #endregion
                }
                if (t_Supplier_FItemID == 0 && t_SupplierSearchByFNameResult != null)
                {
                    t_Supplier_FItemID = Convert.ToInt32(t_SupplierSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->供应商表 插入结束 t_Supplier FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 获取客户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入客户表 t_Organization FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                int t_Organization_FItemID = 0;//客户Id
                object t_OrganizationSearchByFNameResult = SearchByColumnName("FItemID", "t_Organization", "FName", item.res_partner_commercial_company_name);
                if (string.IsNullOrEmpty(item.res_partner_commercial_company_name) || t_OrganizationSearchByFNameResult == null)
                {
                    #region 此客户在金蝶中不存在，以下为将此客户插入金蝶的代码
                    t_Organization t_Organization_entity = new t_Organization()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Organization"),
                        FNumber = !string.IsNullOrEmpty(item.res_partner_commercial_company_name) ? item.res_partner_commercial_company_name : item.res_partner_id,
                        FName = item.res_partner_commercial_company_name
                    };
                    new SqlHelper().SqlPour(t_OrganizationFormat.sql_t_Organization(t_Organization_entity), null);
                    t_Organization_FItemID = t_Organization_entity.FItemID;
                    #endregion
                }
                if (t_Organization_FItemID == 0 && t_OrganizationSearchByFNameResult != null)
                {
                    t_Organization_FItemID = Convert.ToInt32(t_OrganizationSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->客户表 插入结束 t_Organization FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入职员表 t_Base_Emp FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->职员表 插入结束 t_Base_Emp FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入系统用户表 t_Base_User FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->系统用户表 插入结束  t_Base_User FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入辅助资料表 t_SubMessage FName=" + "********" + DateTime.Now);
                int t_SubMessage_FInterID = 0;
                object t_SubMessageSearchByFNameResult = SearchByColumnName("FInterID", "t_SubMessage", "FName", "********");
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->辅助资料表 插入结束  t_SubMessage FName=" + "********" + DateTime.Now);
                #endregion
              
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->正在插入虚仓出入库单据表 ZPStockBill" + DateTime.Now);
                // (1) 插入金蝶 ZPStockBill表   
                ZPStockBill zPStockBill = new ZPStockBill() {
                    //FInterID = item.,
                    //FTranType = item.,
                    //FROB = item.,
                    //FDate = item.stock_picking_date_done,
                    FBillNo = item.stock_picking_name,
                    //FCheckerID = item.stock_picking_audit,
                    //FFManagerID = item.stock_picking_picker_picking,
                    //FSManagerID = item.,
                    //FBillerID = item.stock_picking_maker,
                    //FDeptID = item.hr_department_id,
                    //FCustID = item.res_partner_commercial_company_name,
                    //FSupplyID = item.res_partner_id,
                    //FCheckDate = item.,
                    //FEmpID = item.stock_picking_business_user,
                    FExplanation = item.stock_picking_summary,
                    //FManagerID = item.,
                    //FSelTranType = item.stock_picking_type_name,
                    //FBillTypeID = item.,
                    //FBrID = item.,
                    //FPrintCount = item.
                };
                new SqlHelper().SqlPour(ZPStockBillFormat.sql_ZPStockBill(zPStockBill), null);
                // (2) 插入金蝶 t_Department表 ***

                // (3) 插入金蝶 t_Supplier表 ***

                // (4) 插入金蝶 t_Organization表   ***

                // (5) 插入金蝶 t_Base_Emp表   ***

                // (6) 插入金蝶 t_Base_User表   ***

                // (7) 插入金蝶 t_SubMessage 表 ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->虚仓出入库单据表 ZPStockBill 插入结束" + DateTime.Now);
                #endregion
            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
