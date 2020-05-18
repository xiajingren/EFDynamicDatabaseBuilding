using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHZNL.EFDynamicDatabaseBuilding.Common;

namespace XHZNL.EFDynamicDatabaseBuilding.MasterEntity.Services
{
    public class BaseService
    {
        /// <summary>
        /// 获取context
        /// </summary>
        /// <returns></returns>
        internal MasterDBContext GetDBContext()
        {
            try
            {
                var context = new MasterDBContext();

                if (!context.Database.Exists())
                {
                    context.Database.Create();

                    var dbInitializer = new MigrateDatabaseToLatestVersion<MasterDBContext, Migrations.Configuration>(true);
                    dbInitializer.InitializeDatabase(context);
                }

                if (!context.Database.CompatibleWithModel(false))
                {
                    var dbInitializer = new MigrateDatabaseToLatestVersion<MasterDBContext, Migrations.Configuration>(true);
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
