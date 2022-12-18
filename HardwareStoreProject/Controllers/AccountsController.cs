using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HardwareStoreProject.Models;
using Microsoft.Ajax.Utilities;

namespace HardwareStoreProject.Controllers
{
    public class AccountsController : Controller
    {

        HARDWARE_DBEntities entity = new HARDWARE_DBEntities();
       
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = entity.UsersTbls.Any(x => x.Email == credentials.Email && x.Passcode == credentials.Password);
            UsersTbl u = entity.UsersTbls.FirstOrDefault(x => x.Email == credentials.Email && x.Passcode == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password is wrong or User is not registered");
            return View();
        }

        [HttpPost]
        public ActionResult Signup(UsersTbl userinfo, LoginViewModel credentials)
        {
            if (string.IsNullOrEmpty(userinfo.Username))
            {
                ModelState.AddModelError("", "Please fill every field");
                return View();
            }

            entity.UsersTbls.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
            return View();
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
            return View();
        }
    }
}