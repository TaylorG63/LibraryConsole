using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryConsoleDBController.DB_controller;
using LibraryConsoleLib.DTO;
using System.Collections.Generic;
using LibraryConsoleUI;
using LibraryConsoleUI.CRUD;

namespace LibraryConsoleUnitTest
{
    [TestClass]
    public class DBTesters
    {
        [TestMethod]
        public void GetUsers()
        {
            UserDB userdb = new UserDB();
            List<UserDTO> users = userdb.Get();
            Assert.IsTrue(users.Count > 0);
            //will fail if userdb sends a list of 0 in length
        }

        [TestMethod]
        public void AddUser()
        {
            UserDB userdb = new UserDB();
            List<UserDTO> users = userdb.Get();
            int count = users.Count;
            System.Console.WriteLine("users.Count: " + users.Count);
            List<UserDTO> newusers = userdb.Get();
            userdb.Add(users[0]);
            newusers = userdb.Get();
            System.Console.WriteLine("newusers.Count: " + newusers.Count);
            System.Console.WriteLine($"newusers.Count: {newusers.Count} > users.Count: {users.Count}");
            Assert.IsTrue(newusers.Count > count);
        }
        [TestMethod]
        public void DeleteUser()
        {
            UserDB userdb = new UserDB();
            List<UserDTO> users = userdb.Get();
            int count = users.Count;
            userdb.Delete(users[0]);
            users = userdb.Get();
            Assert.IsTrue(users.Count < count);
        }
        [TestMethod]
        public void UpdateUser()
        {
            UserDB userdb = new UserDB();
            List<UserDTO> users = userdb.Get();
            UserDTO saveuser = users[0];
            string _testString = "abcdefgfedcba";
            userdb.Update(new UserDTO() { FirstName = _testString, LastName = _testString, UserName = users[0].UserName, Password = users[0].Password, Role = users[0].Role });
            Assert.IsFalse(users[0] == saveuser);
            userdb.Update(saveuser);
        }

    }
    [TestClass]
    public class DataHandlerTesters
    {
        [TestMethod]
        public void GetUsersfromDataHandler()
        {
            UserDB userdb = new UserDB();
            List<UserDTO> users = userdb.Get();
            DataHandler datahandler = new DataHandler();
            List<UserDTO> usersFromDataHandler = datahandler.GetUsers();
            System.Console.WriteLine(usersFromDataHandler);
            System.Console.WriteLine(users);
            Assert.IsTrue(usersFromDataHandler == users);
        }
        [TestMethod]
        public void GetCurrentRolesfromDataHandler() { }
    }
    [TestClass]
    public class CRUD_ReadMethods
    {
        [TestMethod]
        public void ReadLoginFailedLoginTester()
        {
            UserDTO test = new UserDTO() { UserName = "Test", Password = "7777"};
            ReadMethods reader = new ReadMethods();

            Assert.IsTrue(reader.ReadLogin(test)==test);
        }
    }
}