using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleLib.DTO
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
    }
}
