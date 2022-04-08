using crudsurya2.Db_Connect_EF;
using crudsurya2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudsurya2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        [HttpPost]
        public ActionResult About(Suryamodel objmod)
        {
            suryaEntities dbobj = new suryaEntities();//this object is a database object
            userinfo tblobj = new userinfo();//this object is the table ocject
            tblobj.id = objmod.id;
            tblobj.name = objmod.name;
            tblobj.email = objmod.email;
            tblobj.mobile = objmod.mobile;
            tblobj.password = objmod.password;
            dbobj.userinfoes.Add(tblobj);
            dbobj.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Contact()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Contact(Suryamodel objmod)
        {
            suryaEntities dbobj = new suryaEntities();//this object is a database object
            var resdata = dbobj.userinfoes.Where(m=>m.email==objmod.email).FirstOrDefault();
            if(resdata==null)
            {
                TempData["invalid"] = "Invalid Email or user";
            }
            else
            {
                if(resdata.email==objmod.email && resdata.password==objmod.password)
                {
                    Session["name"] = resdata.name;
                    Session["email"] = resdata.email;
                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    TempData["invalidpass"] = "Invalid password";
                }
            }
            return View();
        }
    }
}