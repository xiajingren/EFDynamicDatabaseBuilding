using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHZNL.EFDynamicDatabaseBuilding.MasterEntity
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))] //使用mysql时需要这个
    public class MasterDBContext : DbContext
    {
        public MasterDBContext() : base("name=MasterDB")
        {
            Database.SetInitializer<MasterDBContext>(null);
        }

        /// <summary>
        /// 企业
        /// </summary>
        public DbSet<Enterprise> Enterprises { get; set; }

    }
}
