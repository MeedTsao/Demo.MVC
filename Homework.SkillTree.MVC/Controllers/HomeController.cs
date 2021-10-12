using Homework.SkillTree.Models;
using Homework.SkillTree.MVC.Service;
using ServiceLayer_SkillTree.Areas.WithServiceAndLogInUnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AccountBooksService _accountBookService;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
            _accountBookService = new AccountBooksService(_unitOfWork);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewData.Model = _accountBookService.Lookup();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            CategoriesViewModel model = new CategoriesViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CategoriesViewModel categories)
        {
            if (ModelState.IsValid)
            {
                _accountBookService.Add(categories);
                _unitOfWork.Commit();
                return RedirectToAction("About");
            }
            return View(categories);
        }
    }
}