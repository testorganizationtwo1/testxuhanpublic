using KingdeeEntity;
using Monitor.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Tools
{
    public class SqlStringFormat
    {
        public static string sql_iCStockBillEntry(ICStockBillEntry t_ICStockBillEntry)
        {
            string sql_ICStockBillEntry = new SqlHelper().GetSqlForKingdeeSql("ICStockBillEntry.sql");
            return string.Format(
                sql_ICStockBillEntry, 
                t_ICStockBillEntry.FQtyMust, 
                t_ICStockBillEntry.FAuxQty, 
                t_ICStockBillEntry.FAuxPrice, 
                t_ICStockBillEntry.Famount, 
                t_ICStockBillEntry.FBatchNo, 
                t_ICStockBillEntry.FNote, 
                t_ICStockBillEntry.FSourceBillNo, 
                t_ICStockBillEntry.FSourceTranType, 
                t_ICStockBillEntry.FQty, 
                t_ICStockBillEntry.FAuxPlanPrice, 
                t_ICStockBillEntry.FPlanAmount, 
                t_ICStockBillEntry.FKFPeriod, 
                t_ICStockBillEntry.FKFDate, 
                t_ICStockBillEntry.FPositionNo, 
                t_ICStockBillEntry.FItemSize, 
                t_ICStockBillEntry.FItemSuite, 
                t_ICStockBillEntry.FBrNo, 
                t_ICStockBillEntry.FInterID, 
                t_ICStockBillEntry.FEntryID,
                t_ICStockBillEntry.FConsignPrice,
                t_ICStockBillEntry.FConsignAmount,
                t_ICStockBillEntry.FProcessCost,
                t_ICStockBillEntry.FProcessPrice,
                t_ICStockBillEntry.FAuxQtyMust);
        }
    }
}
