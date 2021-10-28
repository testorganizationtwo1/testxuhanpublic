using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    /// <summary>
    /// 全局常量
    /// </summary>
    public class GlobalConstant
    {
        /// <summary>
        /// 运行速度（毫秒）
        /// </summary>
        public static int Speed = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Speed"]);
    }
}
