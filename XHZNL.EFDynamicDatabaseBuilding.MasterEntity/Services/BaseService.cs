using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new MasterDBContext();
        }
    }
}
