﻿using LibraryConsoleLib.DTO;
using LibraryConsoleUI.CRUD;

namespace LibraryConsoleUI
{
    internal class Program
    {
        public static DataHandler Data = new DataHandler();
        public static CreateMethods CRUDCreate = new CreateMethods();
        public static ReadMethods CRUDRead = new ReadMethods(Data);
        public static UpdateMethods CRUDUpdate = new UpdateMethods(Data);
        public static DeleteMethods CRUDDelete = new DeleteMethods();
        static void Main(string[] args)
        {
            EntryMenu();
        }

        public static void EntryMenu()
        {
            string Input = "test";
            
            while (Input.ToLower() != "ex")
            {
                Console.Clear();
                Console.WriteLine("\n      ~~~~Welcome~~~~\nType option and hit Enter to select\n");
                Console.WriteLine("  g - use program as a guest\n  r - register as a new guest\n  l - login\n  ex - exit program\n");
                Input = Console.ReadLine()!;
                switch (Input)
                {
                    case "g":
                        Console.WriteLine("Continuing as guest\n");
                        CRUDRead.Data.CurrentUser = new UserDTO() { Role = Roles.Guest };
                        MainMenu();
                        break;
                    case "r":
                        Console.WriteLine("Registering a new user\n");
                        CRUDCreate.CreateUser(Data);
                        break;
                    case "l":
                        Console.WriteLine("Logging in\n");
                        LogIn();
                        break;
                    case "ex":
                        Console.WriteLine("Exiting program.0\n");
                        break;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
                
                Console.WriteLine();
            }
        }
        public static void MainMenu()
        {
            string Input = "test";

            Console.WriteLine("\n      ~~~~Main Menu~~~~\nType option and hit Enter to select\n");
            Console.WriteLine("\n  o - logout\n  pp - print profile\n  pr - print roles\n  pu - print users\n  eu - edit user");
            while (Input.ToLower() != "o")
            {
                Console.WriteLine("\nType option to continue");
                Input = Console.ReadLine()!;
                Console.Clear();
                Console.WriteLine("\n      ~~~~Main Menu~~~~\nType option and hit Enter to select\n");
                Console.WriteLine("\n  o - logout\n  pp - print profile\n  pr - print roles\n  pu - print users\n");
                Console.WriteLine();
                switch (Input)
                {
                    case "o":
                        Console.WriteLine("Logging out\n");
                        CRUDRead.Data.CurrentUser = new UserDTO() { Role = Roles.Guest };
                        break;
                    case "pp":
                        Console.WriteLine("Printing Profile\n");
                        Console.WriteLine(CRUDRead.ReadProfiles());
                        break;
                    case "pr":
                        Console.WriteLine("Printing Roles\n");
                        Console.WriteLine(CRUDRead.ReadRoles());
                        break;
                    case "pu":
                        Console.WriteLine("Printing Users\n");
                        Console.WriteLine(CRUDRead.ReadUsers());
                        break;
                    case "eu":
                        Console.WriteLine("Editing User");
                        
                        break;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }
        }
        public static void LogIn()
        {
            string _userName;
            string _password;
            UserDTO _guest;
            UserDTO _user;
            Console.Write("\nUser Name: ");
            _userName = Console.ReadLine()!;
            Console.Write("\nPassword: ");
            _password = Console.ReadLine()!;
            _guest = new UserDTO() { UserName = _userName, Password = _password };
            _user = CRUDRead.ReadLogin(_guest);
            if (_user != _guest)
            {
                Data.CurrentUser = _user;
                Console.WriteLine($"Login successful, Welcome {Data.CurrentUser.UserName}");
                MainMenu();
            }
            else
            {
                Console.WriteLine("User Name/Password does not match, please check spelling and try again.");
            }
        }
    }
}
