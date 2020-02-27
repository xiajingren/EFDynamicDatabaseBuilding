using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHZNL.EFDynamicDatabaseBuilding.Common
{
    public class AppConfig
    {
        /// <summary>
        /// 数据库配置DataSource
        /// </summary>
        public readonly static string DB_DataSource = ConfigurationManager.AppSettings["DB_DataSource"];

        /// <summary>
        /// 数据库配置Port
        /// </summary>
        public readonly static string DB_Port = ConfigurationManager.AppSettings["DB_Port"];

        /// <summary>
        /// 数据库配置UserID
        /// </summary>
        public readonly static string DB_UserID = ConfigurationManager.AppSettings["DB_UserID"];

        /// <summary>
        /// 数据库配置Password
        /// </summary>
        public readonly static string DB_Password = ConfigurationManager.AppSettings["DB_Password"];
    }
}
