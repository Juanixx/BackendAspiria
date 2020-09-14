using System;
using System.Configuration;

namespace Repository.Connections
{
    public static class DatabaseConnection
    {

        public static string getDbConnection()
        {
            string connection = "";

            try
            {
                connection = ConfigurationManager.ConnectionStrings["AspiriaConnection"].ConnectionString;
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
