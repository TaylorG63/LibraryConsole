using LibraryConsoleLib.DTO;

namespace LibraryConsoleDBController.DB_controller
{
    public class UserDB : DBController<UserDTO>
    {
        internal List<UserDTO> Users { get; set; }

        public UserDB()
        {
            Users = new List<UserDTO>()
            {
                new UserDTO(){FirstName = "Bob", LastName = "Ross", UserName = "BobRoss", Password = "123", Role = Roles.Librarian },
                new UserDTO(){FirstName = "Jane", LastName = "Doe", UserName = "JaneDoe", Password = "456", Role = Roles.Guest },
                new UserDTO(){FirstName = "supercalifragilisticexpialidocious", LastName = "supercalifragilisticexpialidocious", UserName = "supercalifragilisticexpialidocious", Password = "456", Role = Roles.Administrator },
                new UserDTO(){FirstName = "Jim", LastName = "Carry", UserName = "Jimmy555", Password = "78910", Role = Roles.Patron}
            };
        }

        public UserDB(List<UserDTO> users)
        {
            Users = users;
        }

        //CRUD
        public override void Add(UserDTO add) { Users.Add(add); }

        // delete SQL
        public override void Delete(UserDTO delete) { Users.Remove(delete); }
        // TODO: Edit   Update .. SQL

        //Read ... SELECT
        public override List<UserDTO> Get()
        {
            return Users;
        }

        public override void Update(UserDTO update)
        {
            int index = 0;
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName == update.UserName)
                {
                    index = i;
                    break;
                }
                if (i == Users.Count && Users[i].UserName != update.UserName)
                {
                    throw new Exception("User Not Found");
                }
            }

            Users[index] = update;
            //call an update SQL query
        }
    }
}