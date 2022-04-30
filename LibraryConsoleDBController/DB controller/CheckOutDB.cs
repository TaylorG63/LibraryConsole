using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsoleLib.DTO;

namespace LibraryConsoleDBController.DB_controller
{
    internal class CheckOutDB : DBController<CheckOutDTO>
    {
        public override void Add(CheckOutDTO add)
        {
            Conn = new SqlConnection(ConnectionString);
            string query = "INSERT INTO [dbo].[CheckOut] (ID, UserID, BookID, CheckOut, CheckIn, DueDate)";
            try
            {
                query += $"VALUES('{(int)add.ID}', '{(int)add.UserID}', '{(int)add.BookID}', '{add.CheckOut}', '{add.CheckIn}', '{add.DueDate}')";
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Log.Add("CheckOutDB", "Add", err);
            }
            Conn.Close();
            Conn.Dispose();
        }

        public override void Delete(CheckOutDTO delete)
        {
            Conn = new SqlConnection(ConnectionString);
            string query = $"DELETE FROM [dbo].[CheckOut] WHERE [dbo].[CheckOut].Id = {delete.ID}";
            try
            {
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Log.Add("CheckOutDB", "Delete", err);
            }
            Conn.Close();
            Conn.Dispose();
        }

        public override List<CheckOutDTO> Get()
        {
            Conn = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM [dbo].[CheckOut]";
            List<CheckOutDTO> _checkOut = new List<CheckOutDTO>();
            try
            {
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    _checkOut.Add(new CheckOutDTO()
                    {
                        ID = (int)reader.GetValue(0),
                        UserID = (int)reader.GetValue(1),
                        BookID = (int)reader.GetValue(2),
                        CheckOut = (DateTime)reader.GetValue(3),
                        CheckIn = (DateTime)reader.GetValue(4),
                        DueDate = (DateTime)reader.GetValue(5)
                    });
                }
            }
            catch (Exception err)
            {
                Log.Add("CheckOutDB", "Get", err);
            }
            Conn.Close();
            Conn.Dispose();
            return _checkOut;
        }

        public override void Update(CheckOutDTO update)
        {
            Conn = new SqlConnection(ConnectionString);
            string query = $"UPDATE [dbo].[CheckOut]" +
                $"SET UserID={(int)update.UserID}, BookID='{update.BookID}', CheckIn='{update.CheckIn}'" +
                $"WHERE ID={update.ID}";
            try
            {
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Log.Add("CheckOutDB", "Update", err);
            }
            Conn.Close();
            Conn.Dispose();
        }
    }
}
