
namespace LibraryConsoleDBController.DB_controller
{
    public abstract class DBController<T>
    {
        //Add will add to the local internal list and run an insert command on the respective database
        public abstract void Add(T add);
        //Delete will remove the variable from the internal list and delete it from the database ... possibly add a confirm before execution??
        public abstract void Delete(T delete);

        //Get will run a select statement and return DTO objects
        public abstract List<T> Get();

        public abstract void Update(T update);
    }
}
