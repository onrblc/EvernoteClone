using EvernoteClone.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvernoteClone.Entity.Context;
using EvernoteClone.Entity.UserClasses;
using EvernoteClone.Entity.NoteClasses;

namespace EvernoteClone.WEB.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            //TEMSİLİ AÇILIŞ SAYFASI

            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel userModel)
        {
            if (userModel == null)
            {
                ViewBag.Message = "Giriş yapınız.";
                return RedirectToAction("Login");
            }

            var user = db.User.FirstOrDefault(t => t.UserName == userModel.UserName && t.Password == userModel.Password);

            if (user == null)
            {
                ViewBag.Message = "Kullanıcı adı ya da şifreniz hatalı.";

                return View(userModel);
            }
            else
            {
                if (user.ObjectStatus != Entity.Enum.ObjectStatus.Deleted && user.Status != Entity.Enum.Status.Passive)
                {
                    CurrentSession.Set<User>("login", user);

                    //db.UserDetail.Add(new UserDetail
                    //{
                    //    SessionDate = DateTime.Now,
                    //    UserId = CurrentSession.User.Id,
                    //    SessionTime = 
                    //});

                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Message = "Kullanıcı pasif ya da silinmiş.";
                return View(userModel);

            }
        }

        public ActionResult LogOut()
        {
            CurrentSession.ClearSession();

            return RedirectToAction("/");
        }


    }
}