using System;
using System.Web.Mvc;

namespace Homework.SkillTree.MVC.Controllers
{
    public class ValidateController : Controller
    {
        public JsonResult CheckDate(DateTime date)
        {
            var result = date.CompareTo(DateTime.Now);
            if (result > 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}