using Demo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Demo_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Demo demo)
        {
            using (var context = new DemoContext())
            {
                //bool isValid = context.Demos.Any(x => x.Username == demo.Username && x.Password == demo.Password);
                Demo demo1 = context.Demos.FirstOrDefault(x => x.Username == demo.Username && x.Password == demo.Password);
                if (demo1 != null)
                {
                    if (demo1.Role == "Admin")
                    {
                      /*  Session["Username"] = demo1.Username;*/
                        FormsAuthentication.SetAuthCookie(demo1.Username, false);
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (demo1.Role == "Employee")
                    {
                        Session["Id"] = demo1.Id;
                   /*     Session["Username"] = demo1.Username;*/
                        FormsAuthentication.SetAuthCookie(demo1.Username, false);
                        return RedirectToAction("Index", "Employee");
                    }
                }

                ModelState.AddModelError("", "invalid username and password");
                return View();
            }

        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Demo demo)
        {
            using (var context = new DemoContext())
            {
                demo.Role = "Employee";
                context.Demos.Add(demo);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}