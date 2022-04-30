using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsoleLib.DTO;
using LibraryConsoleUI.CRUD;

namespace LibraryConsoleUI.CRUD
{
    internal class UpdateMethods
    {
        DataHandler Data;
        public UpdateMethods(DataHandler data)
        {
            Data = data;
        }
        public void UpdateSelector(UserDTO user)
        {
            if (user.Role == Roles.Administrator)
            {
                AdminUpdate(user);
            }
            else
            {
                UserUpdate(user, false);
            }
        }

        public void AdminUpdate(UserDTO user)
        {
            int page = 0;
            int pageSize = 10;
            string input = "";
            while (input != "ex")
            {
                Console.WriteLine($"Select User to update\n  Page: {page+1}\n");
                for (int i = page* pageSize; i < (page* pageSize) + pageSize; i++)
                {
                    if (i < Data.Users.Count)
                    {
                        Console.WriteLine($"  {i+1}. {Data.Users[i].UserName}\t{Data.Users[i].Role}");
                    }
                }
                Console.WriteLine("\n  1-10 Select User\t p - Previous Page\t n - Next Page\t ex - Exit");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        UserUpdate(Data.Users[page * pageSize], true);
                        break;
                    case "2":
                        UserUpdate(Data.Users[(page * pageSize)+1], true);
                        break;
                    case "3":
                        UserUpdate(Data.Users[(page * pageSize) + 2], true);
                        break;
                    case "4":
                        UserUpdate(Data.Users[(page * pageSize) + 3], true);
                        break;
                    case "5":
                        UserUpdate(Data.Users[(page * pageSize) + 4], true);
                        break;
                    case "6":
                        UserUpdate(Data.Users[(page * pageSize) + 5], true);
                        break;
                    case "7":
                        UserUpdate(Data.Users[(page * pageSize) + 6], true);
                        break;
                    case "8":
                        UserUpdate(Data.Users[(page * pageSize) + 7], true);
                        break;
                    case "9":
                        UserUpdate(Data.Users[(page * pageSize) + 8], true);
                        break;
                    case "10":
                        UserUpdate(Data.Users[(page * pageSize) + 9], true);
                        break;
                    case "p":
                        if (page > 0)
                        {
                            page--;
                        }
                        break;
                    case "n":
                        page++;
                        break;
                    case "ex":
                        break;
                    default:
                        break;
                }
            }
        }

        public void UserUpdate(UserDTO user, bool Admin)
        {
            string input = "";
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string password = user.Password;
            Roles role = user.Role;
            while (input.ToLower() != "ex")
            {
                Console.Write("\n  1. First Name\n  2. Last Name\n");
                if (Admin)
                {
                    Console.WriteLine("  3. Role");
                }
                else
                {
                    Console.WriteLine("  3. Password");
                }
                Console.WriteLine("   4. Save and Exit");
                Console.WriteLine("   ex - Exit");
                Console.WriteLine($"  {firstName}, {lastName}, {user.UserName}, {user.Role}");
                Console.WriteLine("Select Option");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        Console.WriteLine("New First Name");
                        firstName = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("New Last Name");
                        lastName = Console.ReadLine();
                        break;
                    case "3":
                        if (Admin)
                        {
                            ReadMethods _temp = new ReadMethods();
                            Console.WriteLine(_temp.ReadRoles());
                            Console.WriteLine($"type 1-{Data.CurrentRoles.Count} to select a new role.");
                            input = Console.ReadLine();
                            if (Enum.TryParse(_temp.ReadRoles(), out role))
                            {
                                role = (Roles)Enum.Parse(typeof(Roles), input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Role selected.");
                            }
                        }
                        else
                        {

                        }
                        break;
                    case "4":
                        Console.WriteLine($"Confirm changes to {user.UserName}? y/n");
                        input = Console.ReadLine();
                        input.ToLower();
                        if (input == "y")
                        {
                            user.Role = role;
                            user.FirstName = firstName;
                            user.UserName = lastName;
                            user.Password = password;
                            Data.DBUsers.Update(user);
                            input = "ex";
                        }
                        break;
                    case "ex":
                        input = "ex";
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
