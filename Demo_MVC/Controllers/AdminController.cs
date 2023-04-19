using Demo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Data.Entity;
using System.IO;

namespace Demo_MVC.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private DemoContext _context = new DemoContext();

        // GET: Employee
        public ActionResult Index(string search, int? i)
        {

            var str = _context.Products
         .Where(x => x.Name.StartsWith(search) || x.Name.StartsWith(search) || search == null)
         .OrderBy(x => x.Name)
         .ToList()
         .ToPagedList(i ?? 1, 3);


            return View(str);

        }



        public ActionResult Delete(int Id)
        {

            var Deleterow = _context.Products.Where(x => x.Id == Id).FirstOrDefault();

            return View(Deleterow);
        }

        [HttpPost]
        public ActionResult Delete(Product Prop)
        {
            _context.Entry(Prop).State = EntityState.Deleted;
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public ActionResult Details(int Id)
        {
            var DetailsById = _context.Products.Where(x => x.Id == Id).FirstOrDefault();

            return View(DetailsById);

        }
    }
}