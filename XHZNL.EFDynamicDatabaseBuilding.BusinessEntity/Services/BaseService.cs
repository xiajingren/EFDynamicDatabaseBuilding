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
                //var connectionString = $"Data Source={AppConfig.DB_DataSource};Port={AppConfig.DB_Port};Initial Catalog={CommonHelper.Instance.GetCurrentDBName()};User ID={AppConfig.DB_UserID};Password={AppConfig.DB_Password};";

                //sqlserver连接字符串
                var connectionString = $"Data Source={AppConfig.DB_DataSource},{AppConfig.DB_Port};Initial Catalog={CommonHelper.Instance.GetCurrentDBName()};User ID={AppConfig.DB_UserID};Password={AppConfig.DB_Password};";

                var context = new BusinessDBContext(connectionString);

                //数据库是否存在 不存在则创建
                if (!context.Database.Exists())
                {
                    context.Database.Create();

                    var dbInitializer = new MigrateDatabaseToLatestVersion<BusinessDBContext, Migrations.Configuration>(true);
                    dbInitializer.InitializeDatabase(context);
                }

                //数据库接口是否和模型一致 不一致则更新
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
