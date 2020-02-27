using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHZNL.EFDynamicDatabaseBuilding.BusinessEntity
{

    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]//使用mysql时需要这个
    internal class BusinessDBContext : DbContext
    {
        public BusinessDBContext() : base("name=BusinessDB")
        {
            Database.SetInitializer<BusinessDBContext>(null);
        }

        //修改上下文默认构造函数  
        public BusinessDBContext(string connectionString)
            : base(connectionString)
        {

        }

        /// <summary>
        /// 员工
        /// </summary>
        public DbSet<Staff> Staffs { get; set; }
    }
}

