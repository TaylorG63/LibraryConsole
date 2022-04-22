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
        public void UpdateUser(UserDTO user)
        {
            int choice = 0;
            string _input = "";
            UserDTO _tempUser = user;
            if (Data.CurrentUser.Role == Roles.Administrator)
            {
                while (choice !=4 && (_input.ToLower() == "y" || _input.ToLower() == "yes"))
                {
                    Console.WriteLine($" Updating {user.UserName} profile");
                    Console.WriteLine($" 1.First Name: {user.FirstName}\n 2.Last Name: {user.LastName}\n 3.Role: {user.Role}\n 4.Finish");
                    _input = Console.ReadLine()!;
                    while (!int.TryParse(_input, out choice) || choice < 1 || choice > 4)
                    {
                        Console.WriteLine("Invalid input, choose a number between 1 and 4");
                        _input = Console.ReadLine()!;
                    }
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("New first name?");
                            _input = Console.ReadLine()!;
                            _tempUser.FirstName = _input;
                            break;
                        case 2:
                            Console.WriteLine("New last name?");
                            _input = Console.ReadLine()!;
                            _tempUser.LastName = _input;
                            break;
                        case 3:
                            Console.WriteLine("New role?");
                            Console.WriteLine(new ReadMethods(Data).ReadRoles());
                            _input = Console.ReadLine()!;
                            int _tempNum;
                            while (!int.TryParse(_input, out _tempNum) || _tempNum < 1 || _tempNum > Enum.GetValues<Roles>().Length)
                            {
                                Console.WriteLine("Invalid chouce, select a roll by entering a valid number.");
                                _input = Console.ReadLine();
                            }
                            _tempUser.Role = (Roles)_tempNum;
                            break;
                        case 4:
                            Console.WriteLine($"Confirm changes to {user.UserName}?\n Y/Yes");
                            _input = Console.ReadLine()!;
                            if (_input.ToLower() == "y" || _input.ToLower() == "yes")
                            {
                                try
                                {
                                    //Data.Users.Update(_tempUser);
                                    Console.WriteLine($"{user.UserName} updated successfully");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

            }
            else if(Data.CurrentUser.UserName == user.UserName)
            {
                string _input1 = "";
                string _input2 = "";
                Console.WriteLine(" Change Password");
                Console.Write("New Password: ");
                _input1 = Console.ReadLine()!;
                Console.Write("Confirm Password");
                _input2 = Console.ReadLine()!;
                while (_input1 != _input2)
                {
                    Console.WriteLine("Password does not match");
                    Console.Write("New Password: ");
                    _input1 = Console.ReadLine()!;
                    Console.Write("Confirm Password");
                    _input2 = Console.ReadLine()!;
                }

                _tempUser.Password = _input1;
                try
                {
                    Data.CurrentUser = _tempUser ;
                    Console.WriteLine($"{user.UserName} Password successfully changed");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Invalid permission, please contact an Administrator for assistance.");
            }
        }
    }
}
