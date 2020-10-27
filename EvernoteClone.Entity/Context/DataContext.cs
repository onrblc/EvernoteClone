using EvernoteClone.Entity.NoteClasses;
using EvernoteClone.Entity.NotificationClasses;
using EvernoteClone.Entity.UserClasses;
using System.Configuration;
using System.Data.Entity;

namespace EvernoteClone.Entity.Context
{
    public class DataContext : DbContext
    {

        public DataContext() : base(ConnectionString())
        {

        }


        public static string ConnectionString () {

            var conStr = ConfigurationManager.ConnectionStrings["DbConStr"].ConnectionString;
        
            return conStr.ToString();
        }


        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<Notification> Notification { get; set; }


    }
}
