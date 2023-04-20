using Demo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Runtime.Remoting.Contexts;

namespace Demo_MVC.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private DemoContext _context = new DemoContext();

        // GET: Employee
        public ActionResult Index(string search , int ? i)
        {

            Guid Id1 = (Guid)Session["Id"];
            var userData = (from user in _context.Products
                            where user.PostedBy == Id1
                            select user).ToList();

           /* userData
          .Where(x => x.Name.StartsWith(search) || x.Name.StartsWith(search) || search == null)
         .OrderBy(x => x.Name)
         .ToList()
         .ToPagedList(i ?? 1, 3);*/
            return View (userData);
       
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Product prop)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(file.FileName);


            string path = Path.Combine(Server.MapPath("~/Images/"), filename);
            prop.Image = "~/Images/" + filename;

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                prop.PostedBy = (Guid)Session["Id"];
                _context.Products.Add(prop);
                _context.SaveChanges();

                file.SaveAs(path);
                ModelState.Clear();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.msg = "Invalid File Type";
            }
            return View();
        }


        public ActionResult Edit(int Id)
        {
            var row = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
            return View(row);
        }


        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, Product Prop)
        {
            string filename = Path.GetFileName(file.FileName);
       /*     string _filename = DateTime.Now.ToString("yymmssfff") + filename;*/
            string extension = Path.GetExtension(file.FileName);

            string path = Path.Combine(Server.MapPath("~/Images/"), filename);
            Prop.Image = "~/Images/" + filename;
            
            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                Prop.PostedBy = (Guid)Session["Id"];
                _context.Entry(Prop).State = EntityState.Modified;
      
                _context.SaveChanges();

                file.SaveAs(path);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.msg = "Invalid File Type";
            }


            return View();
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

     
        /*public ActionResult Details(int Id)
        {
            var DetailsById = _context.Products.Where(x => x.Id == Id).FirstOrDefault();

            return View(DetailsById);

        }*/
    }
}