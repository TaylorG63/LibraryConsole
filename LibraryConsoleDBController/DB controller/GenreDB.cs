using LibraryConsoleLib.DTO;

namespace LibraryConsoleDBController.DB_controller
{
    public class GenreDB : DBController<GenreDTO>
    {
        internal List<GenreDTO> Genres;
        public GenreDB() { Genres = new List<GenreDTO>(); }
        public GenreDB(List<GenreDTO> genres)
        {
            Genres = genres;
        }
        public override void Add(GenreDTO add)
        {
            Genres.Add(add);
        }

        public override void Delete(GenreDTO delete)
        {
            Genres.Remove(delete);
        }

        public override List<GenreDTO> Get()
        {
            return Genres;
        }

        public override void Update(GenreDTO update)
        {
            Log.Add("Genres", "Update", new NotImplementedException());
        }
    }
}
