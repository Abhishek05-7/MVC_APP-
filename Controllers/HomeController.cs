using MVC_app1.DB_connection;
using MVC_app1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_app1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AbhishekEntities db = new AbhishekEntities();
            var store = db.Employees.ToList();

            List<emp> emplist = new List<emp>();

            foreach (var item in store)
            {
                emplist.Add(new emp
                {
                    name = item.Name,
                    id = item.id,
                    email = item.Email,
                    branch = item.Branch,
                    sal = (int)item.Sal,
                });
                
            }
            return View(emplist);
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

        public ActionResult Delete( int Id)
        {

            AbhishekEntities db = new AbhishekEntities();
            var col = db.Employees.Where(a => a.id == Id).First();
            db.Employees.Remove(col);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Add(int Id)
        {

            AbhishekEntities db = new AbhishekEntities();
            var col = db.Employees.Where(a => a.id == Id).First();
            db.Employees.Add(col);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}