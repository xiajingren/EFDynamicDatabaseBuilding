using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace XHZNL.EFDynamicDatabaseBuilding.Common
{
    public class CommonHelper
    {
        public static readonly CommonHelper Instance = new CommonHelper();

        private CommonHelper() { }


        /// <summary>
        /// 获取当前数据库
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDBName()
        {
            var key = "CurrentDBName";

            string name = null;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session != null)
            {
                name = System.Web.HttpContext.Current.Session[key].ToString();
            }
            else
            {
                name = CallContext.GetData(key).ToString();
            }

            if (string.IsNullOrEmpty(name))
                throw new Exception("CurrentDBName异常");

            return name;
        }

        /// <summary>
        /// 设置当前数据库
        /// </summary>
        /// <param name="name"></param>
        public void SetCurrentDBName(string name)
        {
            var key = "CurrentDBName";

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session != null)
            {
                System.Web.HttpContext.Current.Session[key] = name;
            }
            else
            {
                CallContext.SetData(key, name);
            }
        }
    }
}
