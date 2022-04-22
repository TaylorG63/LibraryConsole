using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsoleLib.DTO;
using LibraryConsoleDBController.DB_controller;

namespace LibraryConsoleUI.CRUD
{
    public class ReadMethods
    {
        public DataHandler Data; 
        public ReadMethods()
        {
            Data = new DataHandler();
        }

        public ReadMethods(DataHandler data)
        {
            Data = data;
        }

        //public void PrintAuthor()
        //{
        //    List<AuthorDTO> authors = Authors.Get();
        //    int firstNameSpace = 10;
        //    int lastNameSpace = 9;
        //    int birthLocationSpace = 14;
        //    for (int i = 0; i < authors.Count; i++)
        //    {
        //        if (authors[i].FirstName.Length >= firstNameSpace)
        //        {
        //            firstNameSpace = authors[i].FirstName.Length +3;
        //        }
        //        if (authors[i].LastName.Length >= lastNameSpace)
        //        {
        //            lastNameSpace = authors[i].LastName.Length+3;
        //        }
        //        if (authors[i].BirthLocation.Length >= birthLocationSpace)
        //        {
        //            birthLocationSpace = authors[i].BirthLocation.Length+3;
        //        }
        //    }
        //    Console.WriteLine("First Name".PadRight(firstNameSpace, ' ')+"Last Name".PadRight(lastNameSpace, ' ')+"Birth Location".PadRight(birthLocationSpace, ' ') + "Bio");
        //    foreach (AuthorDTO _author in authors)
        //    {
        //        Console.WriteLine($"{_author.FirstName}".PadRight(firstNameSpace - _author.FirstName.Length, ' ')+$"{_author.LastName}".PadRight(lastNameSpace - _author.LastName.Length, ' ')+$"{_author.BirthLocation}".PadRight(birthLocationSpace - _author.BirthLocation.Length, ' ')+$"{_author.Bio}");
        //    }
        //}
        public string ReadRoles() 
        {
            List<RoleDTO> role = Data.GetCurrentRoles();
            string output = "Current Roles\n";
            //Console.WriteLine("Current Roles\n");
            for(int i = 0; i < role.Count; i++)
            {
                output+= $"\n{role[i].RoleName}";
            }
            return output;
        }
        public string ReadUsers()
        {
            string output = "";
            List<UserDTO> users = Data.GetUsers();
            int userNameSpace = 14;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].FirstName.Length > userNameSpace)
                {
                    userNameSpace = users[i].FirstName.Length + 5;
                }
                if (users[i].LastName.Length > userNameSpace)
                {
                    userNameSpace = users[i].LastName.Length + 5;
                }
            }
            output = "   First Name".PadRight(userNameSpace - 1, ' ');
            for (int i = 0; i < users.Count; i++)
            {
                output += $"\n{i + 1}. {users[i].UserName}".PadRight(userNameSpace, ' ');
            }
            return output;
        }
        public string ReadProfiles()
        {
            string output = "";
            List<UserDTO> users = Data.GetUsers();
            int firstNameSpace = 14;
            int lastNameSpace = 14;
            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].FirstName.Length > firstNameSpace)
                {
                    firstNameSpace = users[i].FirstName.Length + 5;
                }
                if (users[i].LastName.Length > lastNameSpace)
                {
                    lastNameSpace = users[i].LastName.Length + 5;
                }
            }
            output = "   First Name".PadRight(firstNameSpace-1, ' ') + "Last Name".PadRight(lastNameSpace, ' ') +"Role";
            for (int i = 0; i < users.Count; i++)
            {
                output+= $"\n{i+1}. {users[i].FirstName}".PadRight(firstNameSpace, ' ') + $"{users[i].LastName}".PadRight(lastNameSpace, ' ')+ $"{users[i].Role}";
            }
            return output;
        }
        public UserDTO ReadLogin(UserDTO user)
        {
            for (int i = 0; i < Data.Users.Count; i++)
            {
                if (Data.Users[i].UserName == user.UserName && Data.Users[i].Password == user.Password)
                {
                    return Data.Users[i];
                }
            }
            return user;
        }
    }
}
