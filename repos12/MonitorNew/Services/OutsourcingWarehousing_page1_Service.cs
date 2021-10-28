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
    /// 委外入库page1数据交互
    /// </summary>
    public class OutsourcingWarehousing_page1_Service : BaseService
    {
        public static string InsertOutsourcingWarehousing_page1()
        {
            // 1、查询odoo  委外入库page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->正在查询OdooHelper().GetOutsourcingWarehousing_page1()" + DateTime.Now);
            List<OutsourcingWarehousing_page1> dt = new OdooHelper().GetOutsourcingWarehousing_page1();
            if (dt == null)
                return "no,没有查到odoo委外入库page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->OdooHelper().GetOutsourcingWarehousing_page1()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                OutsourcingWarehousing_page1 item = dt[i];

                #region 获取t_Supplier  FEntrySupply的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取t_Supplier的代码开始 FName" + item.res_partner_commercial_company_name + DateTime.Now);
                int FEntrySupply = 0;
                object t_SupplierSearchByFNameResult = SearchByColumnName("FItemID", "t_Supplier", "FName", item.res_partner_commercial_company_name);
                if (string.IsNullOrEmpty("*******") || t_SupplierSearchByFNameResult == null)
                {
                    #region 此系统辅助资料在金蝶中不存在，以下为将此系统辅助资料插入金蝶的代码
                    t_Supplier t_Supplier_entity = new t_Supplier()
                    {
                        FName = item.res_partner_commercial_company_name,
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Supplier"),
                        //FNumber =
                    };
                    new SqlHelper().SqlPour(t_SupplierFormat.sql_t_Supplier(t_Supplier_entity), null);
                    FEntrySupply = t_Supplier_entity.FItemID;
                    #endregion
                }
                if (FEntrySupply == 0 && t_SupplierSearchByFNameResult != null)
                {
                    FEntrySupply = Convert.ToInt32(t_SupplierSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取t_Supplier的代码结束 FName" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取职员Id的代码开始 FName" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取职员Id的代码结束  FName" + "*******" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取系统用户Id的代码开始 FName" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取系统用户Id的代码结束 FName" + "*******" + DateTime.Now);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取辅助资料Id的代码开始 *******" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取辅助资料Id的代码结束 *******" + "*******" + DateTime.Now);
                #endregion

                #region 获取t_AccountId的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取t_AccountId的代码开始 FName" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->获取t_AccountId的代码开始 FName" + "*******" + DateTime.Now);
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

                // (1) 插入金蝶 ICStockBill表   ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->插入金蝶 ICStockBill表的代码开始 FName" + "*******" + DateTime.Now);
                ICStockBill iCStockBill = new ICStockBill()
                {
                    FCheckDate = item.audit_data,
                    FDate = item.stock_picking_date_done,
                    FBillerID = t_Base_User_FUserID,//******
                    //FBillNo = item.,
                    FCheckerID = t_Base_User_FUserID,//******
                    //FBrID = ,
                    //FROB = ,
                    //FTranType = item.,
                    //FInterID = ,
                    FSupplyID = FEntrySupply,
                    FPurposeID = t_SubMessage_FInterID,
                    FFManagerID = t_Base_Emp_FItemID,//*******
                    FSManagerID = t_Base_Emp_FItemID,//********
                    //FSelTranType = item.stock_picking_type_name,
                    FCussentAcctID = FCussentAcctID,
                    //FManageType = FManageType,
                    //FSettleDate = ,
                    //FRelateBrID = ,
                    //FPOOrdBillNo = ,
                    //FPrintCount = ,
                    //FVchInterID =
                };
                new SqlHelper().SqlPour(ICStockBillFormat.sql_ICStockBill(iCStockBill), null);
                // (2) 插入金蝶 t_Supplier表 ***

                // (3) 插入金蝶 t_Base_Emp表 ***

                // (4) 插入金蝶 t_Base_User表

                // (5) 插入金蝶 t_SubMessage 表 ***

                // (6) 插入金蝶 t_Account 表 ***

                // (7) 插入金蝶 t_BaseBondedManageType 表 ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->插入金蝶 ICStockBill表的代码结束" + DateTime.Now);
                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
