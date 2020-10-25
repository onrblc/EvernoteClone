using System.Configuration;
using System.Data.Entity;

namespace EvernoteClone.Entity.Context
{
    class DataContext : DbContext
    {

        public DataContext() : base(ConnectionString())
        {

        }


        public static string ConnectionString () {

            var conStr = ConfigurationManager.ConnectionStrings["DbConStr"].ConnectionString;
        
            return conStr.ToString();
        }
    }
}
