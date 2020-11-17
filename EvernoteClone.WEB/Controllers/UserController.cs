using EvernoteClone.Entity.Context;
using EvernoteClone.Entity.UserClasses;
using EvernoteClone.WEB.Filters;
using EvernoteClone.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvernoteClone.WEB.Controllers
{
    public class UserController : Controller
    {
        private DataContext db = new DataContext();

        [Auth]
        public ActionResult Index()
        {
            ViewBag.ActiveUsers = db.User.Where(t => t.ObjectStatus == Entity.Enum.ObjectStatus.NonDeleted && t.Status == Entity.Enum.Status.Active).Count();

            var result = db.User.Where(t => t.ObjectStatus == Entity.Enum.ObjectStatus.NonDeleted && t.Status == Entity.Enum.Status.Active).ToList();
            return View(result);
        }

        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "User");
            }

            var result = db.User.Find(id);

            if (result == null)
            {
                return RedirectToAction("Index", "User");
            }

            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var result = db.User.Where(t => t.Id == user.Id).FirstOrDefault();

                    result.CreatedBy = CurrentSession.GetOnlineUser();
                    result.CreatedOn = DateTime.Now;
                    result.DayOfBirth = user.DayOfBirth;
                    result.Department = user.Department;
                    result.Email = user.Email;
                    result.LastModifiedBy = CurrentSession.GetOnlineUser();
                    result.LastModifiedOn = DateTime.Now;
                    result.Name = user.Name;
                    result.Password = user.Password;
                    result.Surname = user.Surname;
                    result.UserName = user.UserName;
                    result.ObjectStatus = Entity.Enum.ObjectStatus.NonDeleted;
                    result.Status = Entity.Enum.Status.Active;

                    db.Entry(result).State = EntityState.Modified;

                    db.SaveChanges();

                    return Redirect("/User/Index");
                    //return RedirectToAction("Index", "User");
                }

                return View(user);
            }

            return View(user);
        }


        [HttpPost]
        public JsonResult Delete(int? id)
        {
            ValidationModel vm = new ValidationModel();

            try
            {
                User userResult = db.User.Where(t => t.Id == id).FirstOrDefault();

                userResult.LastModifiedBy = CurrentSession.GetOnlineUser();
                userResult.LastModifiedOn = DateTime.Now;
                userResult.ObjectStatus = Entity.Enum.ObjectStatus.Deleted;
                userResult.Status = Entity.Enum.Status.Passive;

                db.Entry(userResult).State = EntityState.Modified;

                if (db.SaveChanges() > 0)
                {
                    vm.Type = "success";
                    vm.Message = "Silme Başarılı";
                }

            }
            catch (Exception hata)
            {

                vm.Type = "error";
                vm.Message = "Silme Başarısız";
            }


            return Json(vm, JsonRequestBehavior.AllowGet);

        }


        //public ActionResult Delete(int? Id)
        //{
        //    User userResult = db.User.Where(t => t.Id == Id).FirstOrDefault();

        //    return View(userResult);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(User user)
        //{
        //    ValidationModel vm = new ValidationModel();

        //    try
        //    {
        //        User userResult = db.User.Where(t => t.Id == user.Id).FirstOrDefault();

        //        userResult.LastModifiedBy = CurrentSession.GetOnlineUser();
        //        userResult.LastModifiedOn = DateTime.Now;
        //        userResult.ObjectStatus = Entity.Enum.ObjectStatus.Deleted;
        //        userResult.Status = Entity.Enum.Status.Passive;

        //        db.Entry(userResult).State = EntityState.Modified;

        //        if (db.SaveChanges() > 0)
        //        {
        //            vm.Type = "success";
        //            vm.Message = "Silme Başarılı";
        //        }

        //    }
        //    catch (Exception hata)
        //    {

        //        vm.Type = "error";
        //        vm.Message = "Silme Başarısız";
        //    }


        //    return Redirect("/User/Index");

        //}





        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (user == null)
            {
                return Redirect("/User/Index");
            }

            if (ModelState.IsValid)
            {
                //SWEETALERT EKLE!!

                var result = new User()
                {
                    CreatedBy = CurrentSession.GetOnlineUser(),
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = CurrentSession.GetOnlineUser(),
                    LastModifiedOn = DateTime.Now,
                    DayOfBirth = user.DayOfBirth,
                    Department = user.Department,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    Password = user.Password,
                    UserName = user.UserName,
                    ObjectStatus = user.ObjectStatus,
                    Status = user.Status
                };

                db.User.Add(result);
                db.SaveChanges();
            }
            else
            {
                return View(user);
            }

            return Redirect("/User/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }


    }
}