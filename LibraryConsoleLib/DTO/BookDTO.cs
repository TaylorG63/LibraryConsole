using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleLib.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public decimal? Price { get; init; }
        public bool IsPaperBack { get; init; }
        public DateTime PublishDate { get; init; }
        public AuthorDTO? Author { get; init; }
        public GenreDTO? Genre { get; init; }
        public PublisherDTO? Publisher { get; init; }

    }
}
