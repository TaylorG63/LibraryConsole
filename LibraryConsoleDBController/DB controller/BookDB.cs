using LibraryConsoleLib.DTO;

namespace LibraryConsoleDBController.DB_controller
{
    public class BookDB : DBController<BookDTO>
    {
        internal List<BookDTO> Books;
        public BookDB() { Books = new List<BookDTO>(); }
        public BookDB(List<BookDTO> books) { Books = books; }
        public override void Add(BookDTO add)
        {
            Books.Add(add);
        }

        public override void Delete(BookDTO delete)
        {
            Books.Remove(delete);
        }

        public override List<BookDTO> Get()
        {
            return Books;
        }

        public override void Update(BookDTO update)
        {
            throw new NotImplementedException();
        }
    }
}
