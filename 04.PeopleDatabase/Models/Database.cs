using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PeopleDatabase.Models
{
    using Interfaces;

    public class Database : IDatabase
    {
        private const int ArrayCapacity = 16;
        private IPerson[] data;
        private int currentIndex;

        public Database(IEnumerable<IPerson> data)
        {
            this.AddInitialArray(data.ToArray());
            this.currentIndex = -1;
        }

        private void AddInitialArray(IPerson[] data)
        {
            if (data.Length > 16)
            {
                throw new InvalidOperationException("Array lenght must be less or equal to 16!");
            }

            this.data = new IPerson[ArrayCapacity];
            
            for (int i = 0; i < data.Length; i++)
            {
                if (!this.data.Any(p => p.Id == data[i].Id || p.UserName == data[i].UserName))
                {
                    this.currentIndex++;
                    this.data[this.currentIndex] = data[i];
                }
            }
        }

        public void Add(IPerson person)
        {
            if (this.data.Any(p => p.Id == person.Id || p.UserName == person.UserName))
            {
                throw new InvalidOperationException("In database already exist a person with the same Id/Username!");
            }
            if (this.currentIndex >= 15)
            {
                throw new InvalidOperationException("Cannot add more than 16 elements in the database!");
            }

            this.currentIndex++;
            this.data[this.currentIndex] = person;
        }

        public void Remove()
        {
            this.data[this.currentIndex] = default(IPerson);
            this.currentIndex--;
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Entered username cannot be null!");
            }
            if (!this.data.Any(p => p.UserName == username))
            {
                throw new InvalidOperationException("No user is present by this username!");
            }

            return this.data.First(p => p.UserName == username);
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Entered id cannot be negative!");
            }
            if (!this.data.Any(p => p.Id == id))
            {
                throw new InvalidOperationException("No user is present by this id!");
            }

            return this.data.First(p => p.Id == id);
        }

        public IPerson[] Fetch()
        {
            IPerson[] data = new IPerson[this.currentIndex + 1];
            for (int i = 0; i <= this.currentIndex; i++)
            {
                data[i] = this.data[i];
            }

            return data;
        }
    }
}
