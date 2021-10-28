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
    /// 产品入库page1数据交互
    /// </summary>
    public class ProductStorage_page1_Service : BaseService
    {
        public static string InsertProductStorage_page1()
        {
            // 1、查询odoo  产品入库page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->正在查询OdooHelper().GetProductStorage_page1()" + DateTime.Now);
            List<ProductStorage_page1> dt = new OdooHelper().GetProductStorage_page1();
            if (dt == null)
                return "no,没有查到odoo产品入库page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->查询OdooHelper().GetProductStorage_page1(结束)" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                ProductStorage_page1 item = dt[i];

                #region 获取部门Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取部门Id的代码开始 FName" + item.stock_picking_delivery_department + DateTime.Now);
                int t_Department_FItemID = 0;
                object t_DepartmentSearchByFNameResult = SearchByColumnName("FItemID", "t_Department", "FName", item.stock_picking_delivery_department);
                if (string.IsNullOrEmpty(item.stock_picking_delivery_department) || t_DepartmentSearchByFNameResult == null)
                {
                    #region 此部门在金蝶中不存在，以下为将此部门插入金蝶的代码
                    t_Department t_Department_entity = new t_Department()
                    {
                        //FNumber = item.,
                        FName = item.stock_picking_delivery_department,
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取部门Id的代码结束 FName" + item.stock_picking_delivery_department + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取职员Id的代码开始 FName" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取职员Id的代码结束 FName" + "*******" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取系统用户Id的代码开始 FName" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取系统用户Id的代码结束 FName" + "*******" + DateTime.Now);
                #endregion

                #region 获取t_BaseBondedManageType Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取t_BaseBondedManageTypeId的代码开始 FName" + "*******" + DateTime.Now);
                int t_BaseBondedManageType_FID = 0;
                object t_BaseBondedManageTypeSearchByFNameResult = SearchByColumnName("FID", "t_BaseBondedManageType", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_BaseBondedManageTypeSearchByFNameResult == null)
                {
                    #region 此保税监管类型在金蝶中不存在，以下为将此保税监管类型插入金蝶的代码
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取t_BaseBondedManageTypeId的代码结束 FName" + "*******" + DateTime.Now);
                #endregion

                // (1) 插入金蝶ICStockBill表   ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取插入金蝶ICStockBill表开始" + DateTime.Now);
                ICStockBill iCStockBill = new ICStockBill()
                {
                    FDate = item.stock_picking_date_done,
                    FCheckerID = t_Base_User_FUserID,//******
                    //FCancellation = ,
                    //FUse = ,
                    //FBillNo = item.,
                    //FBackFlushed = ,
                    //FBrNo = ,
                    //FInterID = ,
                    //FStatus = item.,
                    FCheckDate = item.audit_data,
                    //FROB = ,
                    //FTranType = item.,
                    //FSelTranType = ,
                    //FPrintCount = ,
                    //FVchInterID = ,
                    FBillerID = t_Base_User_FUserID,//******
                    //FBrID = ,
                    FDeptID = t_Department_FItemID,
                    FFManagerID = t_Base_Emp_FItemID,//******
                    FSManagerID = t_Base_Emp_FItemID,//******
                    //FManageType = t_BaseBondedManageType_FID,
                    //FPOStyle = item.,
                    //FSupplyID = item.,
                    //FRelateBrID = item.,
                    //FOrgBillInterID = item.,
                    //FExplanation = ,
                    //FManagerID = item.,
                    //FEmpID = item.,
                    //FCussentAcctID = ,
                    //FSettleDate = item.,
                    //FRefType = item.,
                    //FPurposeID = item.,
                    //FPOOrdBillNo = ,
                    //FBillTypeID = item.stock_picking_type_name,
                    //FObjectItem =
                };
                new SqlHelper().SqlPour(ICStockBillFormat.sql_ICStockBill(iCStockBill), null);
                // (2) 插入金蝶 t_Department表 ***

                // (3) 插入金蝶 t_Base_Emp表 ***

                // (4) 插入金蝶 t_Base_User表 ***

                //(5)插入金蝶 t_BaseBondedManageType 表 ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->获取插入金蝶ICStockBill表结束" + DateTime.Now);
                #endregion 
            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}