using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHZNL.EFDynamicDatabaseBuilding.BusinessEntity.Services
{
    /// <summary>
    /// 员工服务
    /// </summary>
    public class StaffService : BaseService
    {
        public static readonly StaffService Instance = new StaffService();

        private StaffService() { }

        /// <summary>
        /// 获取单个员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Staff Get(Guid id)
        {
            try
            {
                using (var context = GetDBContext())
                {
                    var model = context.Staffs.FirstOrDefault(m => m.ID == id);
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取所有员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Staff> Get()
        {
            try
            {
                using (var context = GetDBContext())
                {
                    var list = context.Staffs.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Add(Staff staff)
        {
            try
            {
                using (var context = GetDBContext())
                {
                    staff.ID = Guid.NewGuid();
                    context.Staffs.Add(staff);
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
