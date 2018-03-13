namespace _04.PeopleDatabase.Interfaces
{
    public interface IDatabase
    {
        void Add(IPerson person);

        void Remove();

        IPerson[] Fetch();

        IPerson FindByUsername(string username);

        IPerson FindById(long id);
    }
}

