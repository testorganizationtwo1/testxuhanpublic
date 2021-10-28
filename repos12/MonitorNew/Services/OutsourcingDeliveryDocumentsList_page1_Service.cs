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
    /// 委外加工出库page1数据交互
    /// </summary>
    public class OutsourcingDeliveryDocumentsList_page1_Service : BaseService
    {
        public static string InsertOutsourcingDeliveryDocumentsList_page1()
        {
            // 1、查询odoo  委外加工出库page1.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->正在查询OdooHelper().GetOutsourcingDeliveryDocumentsList_page1" + DateTime.Now);
            List<OutsourcingDeliveryDocumentsList_page1> dt = new OdooHelper().GetOutsourcingDeliveryDocumentsList_page1();
            if (dt == null)
                return "no,没有查到odoo委外加工出库page1数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->查询OdooHelper().GetOutsourcingDeliveryDocumentsList_page1" + DateTime.Now);

            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                OutsourcingDeliveryDocumentsList_page1 item = dt[i];
                #region 获取t_Supplier  FEntrySupply的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->正在插入供应商表 t_Supplier FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                int FEntrySupply = 0; //供应商
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->供应商表 插入结束 t_Supplier FName=" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 获取职员Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->正在插入职员表 t_Base_Emp FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->职员表 插入结束 t_Base_Emp FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取系统用户Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->正在插入系统用户表 t_Base_User FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->系统用户表 插入结束  t_Base_User FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->正在插入辅助资料表 t_SubMessage FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->辅助资料表 插入结束  t_SubMessage FName=" + "********" + DateTime.Now);
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

                #region 插入金蝶 ICStockBill表
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->正在插入出入库单据表 ICStockBill" + DateTime.Now);
                // (1) 插入金蝶 ICStockBill表 ***
                ICStockBill iCStockBill = new ICStockBill()
                {
                    FCheckDate = item.audit_data,
                    //FDate = ,
                    FBillerID = t_Base_User_FUserID,
                    //FBillNo = item.,
                    //FCheckerID = t_Base_User_FUserID,
                    //FBrID = ,
                    //FROB = ,
                    //FTranType = ,
                    //FInterID = ,
                    FSupplyID = FEntrySupply,
                    FPurposeID = t_SubMessage_FInterID,
                    //FNote = ,
                    FSManagerID = t_Base_Emp_FItemID,
                    FFManagerID = t_Base_Emp_FItemID,
                    //FSelTranType = ,
                    //FBackFlushed = ,
                    //FManageType = FManageType,
                    //FRelateBrID = ,
                    //FPOOrdBillNo = ,
                    //FPrintCount = ,
                    //FVchInterID =
                };
                new SqlHelper().SqlPour(ICStockBillFormat.sql_ICStockBill(iCStockBill), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->出入库单据表 ICStockBill 插入结束" + DateTime.Now);
                #endregion
                // (2) 插入金蝶 t_Supplier表 *** ====顶端已判断，按需插入

                // (3) 插入金蝶 t_Base_Emp表 *** ====顶端已判断，按需插入

                // (4) 插入金蝶 t_Base_User表 *** ====顶端已判断，按需插入

                //(5) 插入金蝶 t_SubMessage 表 *** ====顶端已判断，按需插入

                // (6) 插入金蝶 t_BaseBondedManageType 表 *** ====顶端已判断，按需插入


                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
