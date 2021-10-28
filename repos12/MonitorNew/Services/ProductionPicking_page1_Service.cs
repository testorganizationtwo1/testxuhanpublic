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
    /// 生产领料page1数据交互
    /// </summary>
    public class ProductionPicking_page1_Service : BaseService
    {
        public static string InsertProductionPicking_page1()
        {
            // 1、查询odoo  生产领料page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->正在查询OdooHelper().GetProductionPicking_page1()" + DateTime.Now);
            List<ProductionPicking_page1> dt = new OdooHelper().GetProductionPicking_page1();
            if (dt == null)
                return "no,没有查到odoo生产领料page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->查询OdooHelper().GetProductionPicking_page1()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                ProductionPicking_page1 item = dt[i];

                #region 获取部门Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取部门Id开始 FName" + item.picking_user + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取部门Id结束 FName" + item.picking_user + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取职员Id开始 FName" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取职员Id结束 FName" + "*******" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取系统用户Id开始 FName" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取系统用户Id结束 FName" + "*******" + DateTime.Now);
                #endregion

                #region 获取t_AccountId的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取t_AccountId开始 FName" + "*******" + DateTime.Now);
                int FCussentAcctID = 0;
                object t_AccountSearchByFNameResult = SearchByColumnName("FAccountID", "t_Account", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_AccountSearchByFNameResult == null)
                {
                    #region 此系统辅助资料在金蝶中不存在，以下为将此系统辅助资料插入金蝶的代码
                    t_Account t_Account_entity = new t_Account()
                    {
                        FAccountID = new SqlHelper().GetMaxId("FAccountID", "t_Account"),
                        //FNumber = ,
                        //FName = item.,
                        //FLevel = ,
                        //FDetail = ,
                        //FGroupID = ,
                        //FDC =
                    };
                    new SqlHelper().SqlPour(t_AccountFormat.sql_t_Account(t_Account_entity), null);
                    FCussentAcctID = t_Account_entity.FAccountID;
                    #endregion
                }
                if (FCussentAcctID == 0 && t_AccountSearchByFNameResult != null)
                {
                    FCussentAcctID = Convert.ToInt32(t_AccountSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取t_AccountId结束 FName" + "*******" + DateTime.Now);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取辅助资料Id开始 *******" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->获取辅助资料Id结束 *******" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->插入金蝶 ICStockBill表开始" + DateTime.Now);
                // (1) 插入金蝶 ICStockBill表   ***
                ICStockBill iCStockBill = new ICStockBill()
                {
                    FDate = item.stock_picking_date_done,
                    FCheckerID = t_Base_User_FUserID,//*****
                    //FCancellation = item.,
                    FUse = item.stock_picking_picking_use,
                    //FBillNo = item.,
                    //FBackFlushed = ,
                    //FBrNo = ,
                    //FInterID = ,
                    //FStatus = ,
                    //FCheckDate = item.,
                    //FROB = ,
                    //FTranType = item.,
                    //FSelTranType = item.stock_picking_type_name,
                    //FPrintCount = ,,
                    //FVchInterID = item.,
                    FBillerID = t_Base_User_FUserID,//*****
                    //FBrID = ,
                    FDeptID = t_Department_FItemID,
                    FFManagerID = t_Base_Emp_FItemID,//*****
                    FSManagerID = t_Base_Emp_FItemID,//*****
                    //FManageType = FManageType,
                    //FPOStyle = item.,
                    //FSupplyID = item.,
                    //FRelateBrID = item.,
                    //FOrgBillInterID = item.,
                    //FExplanation = ,
                    //FManagerID = item.,
                    //FEmpID = item.,
                    FCussentAcctID = FCussentAcctID,
                    //FSettleDate = ,
                    //FRefType = ,
                    FPurposeID = t_SubMessage_FInterID,
                    //FPOOrdBillNo = ,
                    //FBillTypeID = ,
                    //FObjectItem =
                };
                new SqlHelper().SqlPour(ICStockBillFormat.sql_ICStockBill(iCStockBill), null);
                // (2) 插入金蝶 t_Department表 ***

                // (3) 插入金蝶 t_Base_Emp表 ***

                // (4) 插入金蝶 t_Base_User表 ***

                //(5)插入金蝶 t_Account 表 ***

                //(6) 插入金蝶 t_SubMessage 表 ***

                //(7)插入金蝶 t_BaseBondedManageType 表 ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->插入金蝶 ICStockBill表结束" + DateTime.Now);
                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
