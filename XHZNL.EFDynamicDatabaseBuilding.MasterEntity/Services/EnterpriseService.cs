using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHZNL.EFDynamicDatabaseBuilding.Common;

namespace XHZNL.EFDynamicDatabaseBuilding.MasterEntity.Services
{
    /// <summary>
    /// 企业服务
    /// </summary>
    public class EnterpriseService : BaseService
    {
        public static readonly EnterpriseService Instance = new EnterpriseService();

        private EnterpriseService() { }

        /// <summary>
        /// 根据账号密码 获取 企业
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Enterprise Get(string account, string password)
        {
            try
            {
                using (var context = GetDBContext())
                {
                    var model = context.Enterprises.FirstOrDefault(m => m.AdminAccount == account && m.AdminPassword == password);
                    if (model != null)
                    {
                        //设置当前业务数据库
                        CommonHelper.Instance.SetCurrentDBName(model.DBName);
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加企业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Add(Enterprise enterprise)
        {
            try
            {
                using (var context = GetDBContext())
                {
                    enterprise.ID = Guid.NewGuid();
                    enterprise.DBName = "BusinessDB" + DateTime.Now.Ticks;
                    context.Enterprises.Add(enterprise);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
