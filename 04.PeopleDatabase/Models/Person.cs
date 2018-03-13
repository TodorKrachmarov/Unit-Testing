namespace _04.PeopleDatabase.Models
{
    using Interfaces;

    public class Person : IPerson
    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.id = id;
            this.username = username;
        }

        public long Id { get { return this.id; } }

        public string UserName { get { return this.username; } }
    }
}
