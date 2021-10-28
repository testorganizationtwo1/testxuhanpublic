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
    /// 其他出库page1数据交互
    /// </summary>
    public class OtherExWarehouse_page1_Service : BaseService
    {
        public static string InsertOtherExWarehouse_page1()
        {
            // 1、查询odoo  其他出库page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->正在查询OdooHelper().GetOtherExWarehouse_page1()" + DateTime.Now);
            List<OtherExWarehouse_page1> dt = new OdooHelper().GetOtherExWarehouse_page1();
            if (dt == null)
                return "no,没有查到odoo其他出库page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->查询OdooHelper().GetOtherExWarehouse_page1()结束" + DateTime.Now);

            Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                OtherExWarehouse_page1 item = dt[i];
                #region 循环插入金蝶
                #region 获取客户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->正在插入客户表 t_Organization FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                int t_Organization_FItemID = 0;
                object t_OrganizationSearchByFNameResult = SearchByColumnName("FItemID", "t_Organization", "FName", item.res_partner_commercial_company_name);
                if (string.IsNullOrEmpty(item.res_partner_commercial_company_name) || t_OrganizationSearchByFNameResult == null)
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->客户表 插入结束 t_Organization FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->正在插入职员表 t_Base_Emp FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->职员表 插入结束 t_Base_Emp FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->正在插入系统用户表 t_Base_User FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->系统用户表 插入结束  t_Base_User FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取部门Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->正在插入部门表 t_Department FName=" + item.picking_user + DateTime.Now);
                int t_Department_FItemID = 0;
                object t_DepartmentSearchByFNameResult = SearchByColumnName("FItemID", "t_Department", "FName", item.picking_user);
                if (string.IsNullOrEmpty(item.picking_user) || t_DepartmentSearchByFNameResult == null)
                {
                    #region 此部门在金蝶中不存在，以下为将此部门插入金蝶的代码
                    t_Department t_Department_entity = new t_Department()
                    {
                        //FNumber = item.,
                        FName = item.picking_user,
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->部门表 t_Department 插入结束 FName=" + item.picking_user + DateTime.Now);
                #endregion

                #region 获取单据类型Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->正在插入单据类型表  ICBillType FName= ******" + "******" + DateTime.Now);
                int ICBillType_FID = 0;
                object ICBillTypeSearchByFNameResult = SearchByColumnName("FID", "ICBillType", "******", "******");
                if (string.IsNullOrEmpty("******") || ICBillTypeSearchByFNameResult == null)
                {
                    #region 此单据类型在金蝶中不存在，以下为将此单据类型插入金蝶的代码
                    ICBillType iCBillType_entity = new ICBillType()
                    {
                        FID = new SqlHelper().GetMaxId("FID", "ICBillType"),
                        //FNumber = ,
                        //FName = ,
                        //FAcctID = ,
                        //FNote = item.,
                        //FSystemic =
                    };
                    new SqlHelper().SqlPour(ICBillTypeFormat.sql_ICBillType(iCBillType_entity), null);
                    ICBillType_FID = iCBillType_entity.FID;
                    #endregion
                }
                if (ICBillType_FID == 0 && ICBillTypeSearchByFNameResult != null)
                {
                    ICBillType_FID = Convert.ToInt32(ICBillTypeSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->单据类型表 插入结束 ICBillType FName= ******" + "******" + DateTime.Now);
                #endregion

                #region 获取t_BaseBondedManageType Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取t_BaseBondedManageType Id开始" + DateTime.Now);
                int t_BaseBondedManageType_FID = 0;
                object t_BaseBondedManageTypeSearchByFNameResult = SearchByColumnName("FID", "t_BaseBondedManageType", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_BaseBondedManageTypeSearchByFNameResult == null)
                {
                    #region 此保税监管类型在金蝶中不存在，以下为将此保税监管类型插入金蝶的代码
                    t_BaseBondedManageType t_BaseBondedManageType_entity = new t_BaseBondedManageType()
                    {
                        FID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore"),
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取t_BaseBondedManageType Id结束" + DateTime.Now);
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select FItemID,FNumber,FName,FItemClassID from t_Item)
                t_Item t_Item_entity = new t_Item()
                {
                    //FItemID = ,
                    //FItemClassID = ,
                    //FNumber = item.,
                    //FParentID = ,
                    //FName = item.,
                    //FDetail =
                };
                #endregion


                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->正在插入出入库单据表 ICStockBill" + DateTime.Now);
                // (1) 插入金蝶 ICStockBill表   ***
                ICStockBill iCStockBill = new ICStockBill()
                {
                    FCheckDate = item.audit_data,
                    FDate = item.stock_picking_date_done,
                    FBillerID = t_Base_User_FUserID,
                    //FBillNo = item.,
                    //FCheckerID = item.,
                    //FBrID = ,
                    //FROB = ,
                    //FTranType = item.,
                    //FInterID = ,
                    FDeptID = t_Department_FItemID,
                    FUse = item.stock_picking_picking_use,
                    FFManagerID = t_Base_Emp_FItemID,
                    FSManagerID = t_Base_Emp_FItemID,
                    FSupplyID = t_Organization_FItemID,
                    FBillTypeID = ICBillType_FID,
                    //FPOOrdBillNo = ,
                    //FRelateBrID = ,
                    //FSelTranType = item.stock_picking_type_name,
                    //FManagerID = item.,
                    //FEmpID = ,
                    //FManageType = FManageType,
                    //FPrintCount = ,
                    //FObjectItem = ,
                    //FVchInterID =
                };
                new SqlHelper().SqlPour(ICStockBillFormat.sql_ICStockBill(iCStockBill), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->出入库单据表 ICStockBill 插入结束" + DateTime.Now);
                // (2) 插入金蝶 t_Organization表 *** ====顶端已判断，按需插入

                // (3) 插入金蝶 t_Base_Emp表 *** ====顶端已判断，按需插入

                // (4) 插入金蝶 t_Base_User表 *** ====顶端已判断，按需插入

                // (5)插入金蝶 t_Department 表 *** ====顶端已判断，按需插入

                // (6) 插入金蝶 ICBillType 表 *** ====顶端已判断，按需插入

                // (7) 插入金蝶 t_BaseBondedManageType 表 *** ====顶端已判断，按需插入

                // (8) 插入金蝶  t_Item 表 *** ====顶端已判断，按需插入



                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
