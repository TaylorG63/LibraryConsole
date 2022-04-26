﻿using LibraryConsoleDBController.DB_controller;
using LibraryConsoleLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleUI
{
    public class CreateMethods
    {
        public void CreateUser(DataHandler data)
        {
            UserDB userDB = new UserDB();
            string firstName;
            string lastName;
            string userName;
            string password;
            Roles role = Roles.Guest;
            Console.WriteLine("\nCreate new user\n\nFirst Name?");
            firstName = Console.ReadLine();
            Console.WriteLine("\nLast Name?");
            lastName = Console.ReadLine();
            Console.WriteLine("User Name?");
            userName = Console.ReadLine();
            Console.WriteLine("Password?");
            password = Console.ReadLine();
            UserDTO newUser = new UserDTO() { FirstName = firstName, LastName = lastName, UserName = userName, Password = password, Role = role };
            userDB.Add(newUser);
            data.Users.Add(new UserDTO() { FirstName = firstName, LastName = lastName, UserName = userName, Password = password, Role = role });
        }
    }
}
