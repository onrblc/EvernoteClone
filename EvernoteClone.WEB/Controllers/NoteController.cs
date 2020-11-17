using EvernoteClone.Entity.Context;
using EvernoteClone.Entity.NoteClasses;
using EvernoteClone.WEB.Filters;
using EvernoteClone.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvernoteClone.WEB.Controllers
{
    public class NoteController : Controller
    {
        private DataContext db = new DataContext();

        [Auth]
        public ActionResult AllNotes()
        {
            ViewBag.IdList = db.Note.Where(t => t.UserId == CurrentSession.User.Id && t.ObjectStatus == Entity.Enum.ObjectStatus.NonDeleted && t.Status == Entity.Enum.Status.Active)
                .Select(t => t.Id)
                .ToList();

            var model = db.Note
                .Where(t => t.UserId == CurrentSession.User.Id && t.ObjectStatus == Entity.Enum.ObjectStatus.NonDeleted && t.Status == Entity.Enum.Status.Active)
                .Select(t => t.Description.Substring(0, 50))
                .ToList();

            return View(model);
        }

        [Auth]
        public ActionResult OldNotes(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            ViewBag.Error = "";

            Note note = db.Note.Find(id); //tekli veri.

            if (note == null)
                return RedirectToAction("Index");

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OldNotes(Note note)
        {
            try
            {
                if (note == null)
                {
                    return RedirectToAction("AllNotes", "Note");
                }


                if (ModelState.IsValid)
                {
                    var result = db.Note.Where(t => t.Id == note.Id).FirstOrDefault();

                    result.Description = note.Description;
                    result.LastModifiedBy = CurrentSession.GetOnlineUser();
                    result.LastModifiedOn = DateTime.Now;
                    // result.User = CurrentSession.User;
                    result.UserId = CurrentSession.User.Id;
                    result.ObjectStatus = Entity.Enum.ObjectStatus.NonDeleted;
                    result.Status = Entity.Enum.Status.Active;

                    db.Entry(result).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("AllNotes", "Note");
                }
                else
                {
                    ViewBag.Error = "Bir hata oluştu";
                    return View(note);
                }

            }
            catch (Exception exception)
            {
                ViewBag.Error = "Bir hata oluştu";
                return View(note);
            }

        }

        [Auth]
        public ActionResult NewNotes()
        {
            ViewBag.Error = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewNotes(Note note)
        {
            try
            {
                if (note == null)
                {
                    return RedirectToAction("AllNotes", "Note");
                }

                if (ModelState.IsValid)
                {
                    var result = new Note();

                    result.CreatedBy = CurrentSession.GetOnlineUser();
                    result.Description = note.Description;
                    result.LastModifiedBy = CurrentSession.GetOnlineUser();
                    result.LastModifiedOn = DateTime.Now;
                    // result.User = CurrentSession.User;
                    result.UserId = CurrentSession.User.Id;
                    result.ObjectStatus = Entity.Enum.ObjectStatus.NonDeleted;
                    result.Status = Entity.Enum.Status.Active;

                    db.Note.Add(result);

                    db.SaveChanges();

                    return RedirectToAction("AllNotes", "Note");
                }
                else
                {
                    ViewBag.Error = "Bir hata oluştu";
                    return View(note);
                }

            }
            catch (Exception exception)
            {
                ViewBag.Error = "Bir hata oluştu";
                return View(note);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<int?> Id)
        {
            using (var db = new DataContext())
            {
                foreach (var id in Id)
                {
                    var result = db.Note.Find(id);
                    result.ObjectStatus = Entity.Enum.ObjectStatus.Deleted;
                    result.Status = Entity.Enum.Status.Passive;
                    result.LastModifiedBy = CurrentSession.GetOnlineUser();
                    result.LastModifiedOn = DateTime.Now;

                    db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("AllNotes");
        }

    }
}