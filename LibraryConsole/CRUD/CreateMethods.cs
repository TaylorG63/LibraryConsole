using LibraryConsoleDBController.DB_controller;
using LibraryConsoleLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsoleLib;

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
            Hasher hasher = new Hasher();
            string[] passSalt = hasher.HashSalt(password);
            UserDTO newUser = new UserDTO() { FirstName = firstName, LastName = lastName, UserName = userName, Password = passSalt[0], Salt = passSalt[1], Role = role };
            userDB.Add(newUser);
            data.Users.Add(new UserDTO() { FirstName = firstName, LastName = lastName, UserName = userName, Password = passSalt[0], Salt=passSalt[1], Role = role });
        }
        public void CreateBook(DataHandler data)
        {
            BookDTO book;
            string title, description;
            decimal price;
            bool isPaperBack;
            DateTime publishDate;
            AuthorDTO author = new AuthorDTO();
            GenreDTO genre = new GenreDTO();
            PublisherDTO publisher = new PublisherDTO();
            string _temp;

            Console.WriteLine("\nCreate new book\n\nTitle?");
            title = Console.ReadLine();
            Console.WriteLine("\nDescription?");
            description = Console.ReadLine();
            Console.WriteLine("Price of Book?");
            _temp = Console.ReadLine();
            while (decimal.TryParse(_temp.Trim('$'), out price))
            {
                Console.WriteLine("Invalid price");
                _temp = Console.ReadLine();
            }
            Console.WriteLine("Paperback? y/n");
            _temp = Console.ReadLine();
            while (_temp.ToLower() != "y" || _temp.ToLower() != "n")
            {
                Console.WriteLine("Incorrect Format. y/n");
                _temp = Console.ReadLine();
            }
            if (_temp.ToLower() == "y")
            {
                isPaperBack = true;
            }
            else
            {
                isPaperBack = false;
            }
            Console.WriteLine("Publish Date, Format: Month day, year");
            _temp = Console.ReadLine();
            while (DateTime.TryParse(_temp, out _))
            {
                Console.WriteLine("Incorrect Format, ex: Jan 1, 2000");
                _temp = Console.ReadLine();
            }
            publishDate = DateTime.Parse(_temp);
            int page;
            int pageSize = 10;
            _temp = "";
            while (int.TryParse(_temp, out _))
            {
                Console.Clear();
                page = 0;
                Console.WriteLine($"Select Author\n  Page: {page + 1}\n");
                for (int i = page * pageSize; i < (page * pageSize) + pageSize; i++)
                {
                    if (i < data.Authors.Count)
                    {
                        Console.WriteLine($"  {i + 1}. {data.Authors[i].FirstName}\t{data.Authors[i].LastName}\t{data.Authors[i].DateOfBirth}");
                    }
                }
                Console.WriteLine("\n  1-10 Select Author\t p - Previous Page\t n - Next Page");
                _temp = Console.ReadLine();
                switch (_temp.ToLower())
                {
                    case "1":
                        author = data.Authors[page * pageSize];
                        break;
                    case "2":
                        author = (data.Authors[(page * pageSize) + 1]);
                        break;
                    case "3":
                        author = (data.Authors[(page * pageSize) + 2]);
                        break;
                    case "4":
                        author = (data.Authors[(page * pageSize) + 3]);
                        break;
                    case "5":
                        author = (data.Authors[(page * pageSize) + 4]);
                        break;
                    case "6":
                        author = (data.Authors[(page * pageSize) + 5]);
                        break;
                    case "7":
                        author = (data.Authors[(page * pageSize) + 6]);
                        break;
                    case "8":
                        author = (data.Authors[(page * pageSize) + 7]);
                        break;
                    case "9":
                        author = (data.Authors[(page * pageSize) + 8]);
                        break;
                    case "10":
                        author = (data.Authors[(page * pageSize) + 9]);
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
                    default:
                        break;
                }
            }//Get and Add Author
            while (int.TryParse(_temp, out _))
            {
                Console.Clear();
                page = 0;
                Console.WriteLine($"Select Genre\n  Page: {page + 1}\n");
                for (int i = page * pageSize; i < (page * pageSize) + pageSize; i++)
                {
                    if (i < data.Genres.Count)
                    {
                        Console.WriteLine($"  {i + 1}. {data.Genres[i].Name}");
                    }
                }
                Console.WriteLine("\n  1-10 Select Genres\t p - Previous Page\t n - Next Page");
                _temp = Console.ReadLine();
                switch (_temp.ToLower())
                {
                    case "1":
                        genre = (data.Genres[page * pageSize]);
                        break;
                    case "2":
                        genre = (data.Genres[(page * pageSize) + 1]);
                        break;
                    case "3":
                        genre = (data.Genres[(page * pageSize) + 2]);
                        break;
                    case "4":
                        genre = (data.Genres[(page * pageSize) + 3]);
                        break;
                    case "5":
                        genre = (data.Genres[(page * pageSize) + 4]);
                        break;
                    case "6":
                        genre = (data.Genres[(page * pageSize) + 5]);
                        break;
                    case "7":
                        genre = (data.Genres[(page * pageSize) + 6]);
                        break;
                    case "8":
                        genre = (data.Genres[(page * pageSize) + 7]);
                        break;
                    case "9":
                        genre = (data.Genres[(page * pageSize) + 8]);
                        break;
                    case "10":
                        genre = (data.Genres[(page * pageSize) + 9]);
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
                    default:
                        break;
                }
            }//Get and Add Genre
            while (int.TryParse(_temp, out _))
            {
                Console.Clear();
                page = 0;
                Console.WriteLine($"Select Publisher\n  Page: {page + 1}\n");
                for (int i = page * pageSize; i < (page * pageSize) + pageSize; i++)
                {
                    if (i < data.Genres.Count)
                    {
                        Console.WriteLine($"  {i + 1}. {data.Publishers[i].Name}\t{data.Publishers[i].Address}, {data.Publishers[i].City}, {data.Publishers[i].State}");
                    }
                }
                Console.WriteLine("\n  1-10 Select Publisher\t p - Previous Page\t n - Next Page");
                _temp = Console.ReadLine();
                switch (_temp.ToLower())
                {
                    case "1":
                        publisher = (data.Publishers[page * pageSize]);
                        break;
                    case "2":
                        publisher = (data.Publishers[(page * pageSize) + 1]);
                        break;
                    case "3":
                        publisher = (data.Publishers[(page * pageSize) + 2]);
                        break;
                    case "4":
                        publisher = (data.Publishers[(page * pageSize) + 3]);
                        break;
                    case "5":
                        publisher = (data.Publishers[(page * pageSize) + 4]);
                        break;
                    case "6":
                        publisher = (data.Publishers[(page * pageSize) + 5]);
                        break;
                    case "7":
                        publisher = (data.Publishers[(page * pageSize) + 6]);
                        break;
                    case "8":
                        publisher = (data.Publishers[(page * pageSize) + 7]);
                        break;
                    case "9":
                        publisher = (data.Publishers[(page * pageSize) + 8]);
                        break;
                    case "10":
                        publisher = (data.Publishers[(page * pageSize) + 9]);
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
                    default:
                        break;
                }
            }//Get and Add Publisher
            book = new BookDTO() { Title = title, Description = description, Price = price, Author = author, Genre = genre, IsPaperBack = isPaperBack, PublishDate = publishDate, Publisher = publisher };
            if (author==null || publisher == null || genre == null)
            {
                throw new Exception("author, publisher, or genre are null");
            }
            data.DBBooks.Add(book);
        }
    }
}
