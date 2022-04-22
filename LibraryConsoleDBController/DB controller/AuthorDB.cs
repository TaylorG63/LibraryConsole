using LibraryConsoleLib.DTO;


namespace LibraryConsoleDBController.DB_controller
{
    public class AuthorDB : DBController<AuthorDTO>
    {
        internal List<AuthorDTO> AuthorList;
        public AuthorDB() { AuthorList = new List<AuthorDTO>(); }
        public AuthorDB(List<AuthorDTO> authors) { AuthorList = authors; }
        public override void Add(AuthorDTO add)
        {
            AuthorList.Add(add);
        }

        public override void Delete(AuthorDTO delete)
        {
            AuthorList.Remove(delete);
        }

        public override List<AuthorDTO> Get()
        {           
            return AuthorList;
        }

        public override void Update(AuthorDTO update)
        {
            throw new NotImplementedException();
        }
    }
}
