using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHZNL.EFDynamicDatabaseBuilding.Common;

namespace XHZNL.EFDynamicDatabaseBuilding.BusinessEntity.Services
{
    public class BaseService
    {
        /// <summary>
        /// 获取context
        /// </summary>
        /// <returns></returns>
        internal BusinessDBContext GetDBContext()
        {
            try
            {
                //mysql连接字符串
                var connectionString = $"Data Source={AppConfig.DB_DataSource};port={AppConfig.DB_Port};Initial Catalog={CommonHelper.Instance.GetCurrentDBName()};user id={AppConfig.DB_UserID};password={AppConfig.DB_Password};";
                var context = new BusinessDBContext(connectionString);

                if (!context.Database.Exists())
                {
                    context.Database.Create();

                    var dbInitializer = new MigrateDatabaseToLatestVersion<BusinessDBContext, Migrations.Configuration>(true);
                    dbInitializer.InitializeDatabase(context);
                }

                if (!context.Database.CompatibleWithModel(false))
                {
                    var dbInitializer = new MigrateDatabaseToLatestVersion<BusinessDBContext, Migrations.Configuration>(true);
                    dbInitializer.InitializeDatabase(context);
                }

                return context;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
