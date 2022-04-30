using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleDBController.DB_controller
{
    public class LoggingDB
    {
        public void Add(string Controller, string Method, Exception e)
        {
            SqlConnection Conn = new SqlConnection();
            SqlCommand Command;
            string ConnectionString = ConfigurationManager.ConnectionStrings["LibraryConsoleConnString"].ConnectionString;
            Conn = new SqlConnection(ConnectionString);
            string Query = $"INSERT INTO [DBO].[Logging] (Controller, Method, Log) VALUES('{Controller}', '{Method}', '{e}')";
            Command = new SqlCommand(Query,Conn);
            Conn.Open();
            Command.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
        }
    }
}
