using System;
using System.Web.Mvc;

namespace Homework.SkillTree.MVC.Controllers
{
    public class ValidateController : Controller
    {
        public JsonResult CheckDate(DateTime date)
        {
            var result = date.CompareTo(DateTime.Now);
            return Json(result < 0, JsonRequestBehavior.AllowGet);
        }
    }
}