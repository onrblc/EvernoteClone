using EvernoteClone.Entity.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvernoteClone.WEB.Models
{
    public class CurrentSession
    {
        public static User User
        {
            get
            {
                return Get<User>("login");
            }
        }

        private static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
            }
            else
            {
                return default(T);
            }
        }

        public static void Set<T> (string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        public static string GetOnlineUser()
        {
            string result = "";
            result = string.Format("{0} {1}", User.Name, User.Surname);
            return result;
        }
    }
}