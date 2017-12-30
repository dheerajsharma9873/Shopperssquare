using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoppers_Square.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }
              [HttpPost]
        public ActionResult Signup(Users userDetails)
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                if (db.userDetail.Any(x => x.Username == userDetails.Username))
                {
                    ModelState.AddModelError("Username", "Username is already exist!");

                }
                if (ModelState.IsValid)

                {

                    db.userDetail.Add(userDetails);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = " Thank you! You are Successfully Registered! with Shoppers Square Mall";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users userDetails)
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                var usr = db.userDetail.Single(u => u.Username == userDetails.Username && u.Password == userDetails.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("UserHomePage");

                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                }
            }
            return View();

        }

        public ActionResult UserHomePage()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("Username");
            return RedirectToAction("index", "Home");
        }
    }

}