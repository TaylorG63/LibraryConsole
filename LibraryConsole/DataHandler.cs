using LibraryConsoleDBController.DB_controller;
using LibraryConsoleLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleUI
{
    public class DataHandler
    {
        public List<AuthorDTO> Authors;
        public List<BookDTO> Books;
        public List<GenreDTO> Genres;
        public List<PublisherDTO> Publishers;
        public List<RoleDTO> CurrentRoles;
        public List<UserDTO> Users;
        public UserDTO CurrentUser;
        public UserDB DBUsers = new UserDB();
        public RoleDB DBRoles = new RoleDB();
        public PublisherDB DBPublishers = new PublisherDB();
        public GenreDB DBGenre = new GenreDB();
        public BookDB DBBooks = new BookDB();
        public AuthorDB DBAuthors = new AuthorDB();

        public DataHandler() {
            
            Authors = new AuthorDB().Get();
            Books = new BookDB().Get();
            Genres = new GenreDB().Get();
            Publishers = new PublisherDB().Get();
            CurrentRoles = new RoleDB().Get();
            Users = new UserDB().Get();
            CurrentUser = new UserDTO() { Role = Roles.Guest };
        }

        public List<AuthorDTO> GetAuthors() { Authors = new AuthorDB().Get(); return Authors; }
        public List<BookDTO> GetBooks() { Books = new BookDB().Get(); return Books; }
        public List<GenreDTO> GetGenres() { Genres = new GenreDB().Get(); return Genres; }
        public List<PublisherDTO> GetPublishers() { Publishers = new PublisherDB().Get(); return Publishers; }
        public List<RoleDTO> GetCurrentRoles() { CurrentRoles = new RoleDB().Get(); return CurrentRoles; }
        public List<UserDTO> GetUsers() { Users = new UserDB().Get(); return Users; }
        public UserDTO GetCurrentUser() { return CurrentUser; }
    }
}
