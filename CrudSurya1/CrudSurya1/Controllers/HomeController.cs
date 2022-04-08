using CrudSurya1.Db_ConnectEF;
using CrudSurya1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudSurya1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            suryaEntities objtbl = new suryaEntities();
            List<RegForm> objmod = new List<RegForm>();
            var res=objtbl.tbl_reg.ToList();
            foreach (var item in res)
            {
                objmod.Add(new RegForm
                {
                    id=item.id,
                    name=item.name,
                    email=item.email,
                    mobile=item.mobile
                });

            }
            return View(objmod);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(RegForm regobj)
        {
            suryaEntities objtbl = new suryaEntities();
            tbl_reg tblobj = new tbl_reg();
            tblobj.id = regobj.id;
            tblobj.name = regobj.name;
            tblobj.email = regobj.email;
            tblobj.mobile = regobj.mobile;


            if (regobj.id == 0)
            {
                objtbl.tbl_reg.Add(tblobj);
                objtbl.SaveChanges();
            }
            else
            {
                objtbl.Entry(tblobj).State = System.Data.Entity.EntityState.Modified;
                objtbl.SaveChanges();
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete( int id)
        {
            suryaEntities objtbl = new suryaEntities();
            var del = objtbl.tbl_reg.Where(m => m.id == id).First();
            objtbl.tbl_reg.Remove(del);
            objtbl.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            suryaEntities objtbl = new suryaEntities();
            RegForm objmod = new RegForm();
            var edit = objtbl.tbl_reg.Where(m => m.id == id).First();
            objmod.id = edit.id;
            objmod.name = edit.name;
            objmod.email = edit.email;
            objmod.mobile = edit.mobile;
            ViewBag.id = edit.id;
            return View("Contact", objmod);
        }
    }
}