using EvernoteClone.Entity.Context;
using EvernoteClone.Entity.UserClasses;
using EvernoteClone.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvernoteClone.WEB.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.User == null)
                filterContext.Result = new RedirectResult("/Home/Login");
            else
            {
                DataContext db = new DataContext();
                var result = db.User.Where(t => t.Id == CurrentSession.User.Id).FirstOrDefault();

                CurrentSession.ClearSession();
                CurrentSession.Set<User>("login", result);
            }

        }
    }
}