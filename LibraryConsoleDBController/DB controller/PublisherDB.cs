using LibraryConsoleLib.DTO;

namespace LibraryConsoleDBController.DB_controller
{
    public class PublisherDB : DBController<PublisherDTO>
    {
        internal List<PublisherDTO> PublisherList;
        public PublisherDB() { PublisherList = new List<PublisherDTO>(); }
        public override void Add(PublisherDTO add)
        {
            PublisherList.Add(add);
        }

        public override void Delete(PublisherDTO delete)
        {
            PublisherList.Remove(delete);
        }

        public override List<PublisherDTO> Get()
        {
            return PublisherList;
        }

        public override void Update(PublisherDTO update)
        {
            throw new NotImplementedException();
        }
    }
}
