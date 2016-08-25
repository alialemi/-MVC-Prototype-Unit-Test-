using HRSA.Core.DataAccess.DataModel;
using HRSA.Core.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prototyped_MVC_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageService pageService;

        public HomeController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        public ActionResult Index()
        {
            ViewBag.Page = pageService.GetPageByName("Index");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}