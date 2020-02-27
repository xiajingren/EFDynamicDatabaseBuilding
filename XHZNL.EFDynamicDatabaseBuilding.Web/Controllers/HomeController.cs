using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XHZNL.EFDynamicDatabaseBuilding.BusinessEntity;
using XHZNL.EFDynamicDatabaseBuilding.BusinessEntity.Services;
using XHZNL.EFDynamicDatabaseBuilding.MasterEntity;
using XHZNL.EFDynamicDatabaseBuilding.MasterEntity.Services;

namespace XHZNL.EFDynamicDatabaseBuilding.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Enterprise"] == null)
                return Redirect("/Home/Login");

            var enterprise = Session["Enterprise"] as Enterprise;
            ViewBag.Name = enterprise.Name;
            ViewBag.DBName = enterprise.DBName;

            return View();
        }

        /// <summary>
        /// 获取员工
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStaff()
        {
            var list = StaffService.Instance.Get();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddStaff(string name)
        {
            var r = StaffService.Instance.Add(new Staff() { Name = name });
            return Json(r);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 企业注册
        /// </summary>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Register(string name, string username, string password)
        {
            var r = EnterpriseService.Instance.Add(new Enterprise() { Name = name, AdminAccount = username, AdminPassword = password });
            return Json(r);
        }

        /// <summary>
        /// 企业登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            var r = EnterpriseService.Instance.Get(username, password);
            if (r != null)
            {
                Session["Enterprise"] = r;
                return Json(true);
            }
            return Json(false);
        }

    }
}