using LibraryConsoleLib.DTO;
using System.Data;
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
                byte[] varhashedBytes;
                var rng = new RNGCryptoServiceProvider();
                var salt = new byte[32];
                rng.GetBytes(salt);
                byte[] hashedBytes = Encoding.UTF8.GetBytes(add.Password + Convert.ToBase64String(salt));
                SHA256Managed hashString = new SHA256Managed();
                byte[] hashed = hashString.ComputeHash(hashedBytes);
                string bytestring = Convert.ToHexString(hashed);
                query += $"VALUES('{(int)add.Role}', '{add.FirstName}', '{add.LastName}', '{add.UserName}', '{bytestring}', '{Convert.ToBase64String(salt)}')";
                Conn.Open();
                Command = new SqlCommand(query, Conn);
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
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
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
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
                        Role=(Roles)reader.GetValue(1), 
                        FirstName=(string)reader.GetValue(2), 
                        LastName=(string)reader.GetValue(3), 
                        UserName=(string)reader.GetValue(4), 
                        Password=(string)reader.GetValue(5) 
                    });
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
            Conn.Close();
            Conn.Dispose();
            return _users;
        }

        public override void Update(UserDTO update)
        {
            Conn = new SqlConnection(ConnectionString);
            string query = $"UPDATE [dbo].[User]" +
                $"SET Role={(int)update.Role}, FirstName={update.FirstName}, LastName={update.LastName}, Password={update.Password}" +
                $"WHERE Id={update.Id}";
            try
            {
                Conn.Open();
                Command = new SqlCommand(query, Conn);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
            Conn.Close();
            Conn.Dispose();
        }
    }
}