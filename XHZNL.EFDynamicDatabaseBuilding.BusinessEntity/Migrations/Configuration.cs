namespace XHZNL.EFDynamicDatabaseBuilding.BusinessEntity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<XHZNL.EFDynamicDatabaseBuilding.BusinessEntity.BusinessDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());//sqlserver时不需要这个
        }

        protected override void Seed(XHZNL.EFDynamicDatabaseBuilding.BusinessEntity.BusinessDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var staff = new Staff() { ID = Guid.Parse("212cf53c-6801-4c00-b36b-996ac9809e04"), Name = "初始员工" };
            context.Staffs.AddOrUpdate(staff);
            context.SaveChanges();
        }
    }
}
