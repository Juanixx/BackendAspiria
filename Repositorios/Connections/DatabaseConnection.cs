using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Repositorios.Connections
{
    public static class DatabaseConnection
    {

        public static string getDbConnection()
        {
            string connection = "";

            try
            {
                connection = WebConfigurationManager.ConnectionStrings["AspiriaConnection"].ConnectionString;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error ***********************++")
                ;
            }

            return connection;
        }
    }
}
