using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleLib.DTO
{
    public class AuthorDTO
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Bio { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string? BirthLocation { get; init; }
    }
}
