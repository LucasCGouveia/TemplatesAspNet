using Default_Template_MVC.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Default_Template_MVC.Controllers
{
    public class HomeController : absPaginaBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}