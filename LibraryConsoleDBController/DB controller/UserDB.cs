using LibraryConsoleLib.DTO;
using LibraryConsoleLib;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace LibraryConsoleDBController.DB_controller
{
    public class UserDB : DBController<UserDTO>
    {

        //CRUD
        public override void Add(UserDTO add)
        {
            Conn = new SqlConnection(ConnectionString);
            string query = "INSERT INTO [dbo].[User] (Role, FirstName, LastName, UserName, Password, Salt)";
            try
            {
                query += $"VALUES('{(int)add.Role}', '{add.FirstName}', '{add.LastName}', '{add.UserName}', '{add.Password}', '{add.Salt}')";
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Log.Add("UserDB", "Add", err);
            }
            Conn.Close();
            Conn.Dispose();
        }

        // delete SQL
        public override void Delete(UserDTO delete)
        {
            Conn = new SqlConnection(ConnectionString);
            string query = $"DELETE FROM [dbo].[User] WHERE [dbo].[User].Id = {delete.Id}";
            try
            {
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Log.Add("UserDB", "Delete", err);
            }
            Conn.Close();
            Conn.Dispose();
        }
        // TODO: Edit   Update .. SQL

        //Read ... SELECT
        public override List<UserDTO> Get()
        {
            Conn = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM [dbo].[User]";
            List<UserDTO> _users = new List<UserDTO>();
            try
            {
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    _users.Add(new UserDTO()
                    {
                        Id = (int)reader.GetValue(0),
                        Role = (Roles)reader.GetValue(1),
                        FirstName = (string)reader.GetValue(2),
                        LastName = (string)reader.GetValue(3),
                        UserName = (string)reader.GetValue(4),
                        Password = (string)reader.GetValue(5),
                        Salt = (string)reader.GetValue(6)
                    });
                }
            }
            catch (Exception err)
            {
                Log.Add("UserDB", "Get", err);
            }
            Conn.Close();
            Conn.Dispose();
            return _users;
        }

        public override void Update(UserDTO update)
        {
            Conn = new SqlConnection(ConnectionString);
            string query = $"UPDATE [dbo].[User]" +
                $"SET Role={(int)update.Role}, FirstName='{update.FirstName}', LastName='{update.LastName}', Password='{update.Password}'" +
                $"WHERE Id={update.Id}";
            try
            {
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Log.Add("UserDB", "Update", err);
            }
            Conn.Close();
            Conn.Dispose();
        }
    }
}