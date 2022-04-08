using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surya.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            suryaEntities dbobj = new suryaEntities();
            return View();
        }
 
    }
}