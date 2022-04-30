using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsoleLib.DTO;

namespace LibraryConsoleUI
{
    public class DeleteMethods
    {
        DataHandler Data = new DataHandler();

        public DeleteMethods(DataHandler data) { Data = data; }

        public void DeleteUser(UserDTO user)
        {
            Data.DBUsers.Delete(user);
        }
    }
}
