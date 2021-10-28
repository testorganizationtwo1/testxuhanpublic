using Monitor.DatabaseHelper;

namespace MonitorNew.Services
{
    public class BaseService
    {
        /// <summary>
        /// 指定列、值返回指定列的数据   For Kingdee
        /// </summary>
        /// <param name="returnColumnName">需要返回的列值</param>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">where条件中指定的列名</param>
        /// <param name="valueStr">where条件中指定列对应的指定数据</param>
        /// <returns>查询结果</returns>
        protected static object SearchByColumnName(string returnColumnName,string tableName,string columnName,string valueStr)
        {
            return new SqlHelper().SearchBySql(string.Format("select {0} from {1} where {2}='{3}'", returnColumnName,tableName, columnName,valueStr.Trim()));
        }
        /// <summary>
        /// 指定列、值返回指定列的数据   For Odoo
        /// </summary>
        /// <param name="returnColumnName">需要返回的列值</param>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">where条件中指定的列名</param>
        /// <param name="valueStr">where条件中指定列对应的指定数据</param>
        /// <returns>查询结果</returns>
        protected static object PgSqlSearchByColumnName(string returnColumnName, string tableName, string columnName, string valueStr)
        {
            return new PgsqlHelper().SearchByPgSql(string.Format("select {0} from {1} where {2}='{3}'", returnColumnName, tableName, columnName, valueStr.Trim()));
        }
    }
}
