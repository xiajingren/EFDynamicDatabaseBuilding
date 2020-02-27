namespace XHZNL.EFDynamicDatabaseBuilding.MasterEntity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<XHZNL.EFDynamicDatabaseBuilding.MasterEntity.MasterDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());//sqlserver时不需要这个
        }

        protected override void Seed(XHZNL.EFDynamicDatabaseBuilding.MasterEntity.MasterDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
