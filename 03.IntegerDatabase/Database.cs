using System.Collections.Generic;
using System.Linq;

namespace _03.IntegerDatabase
{
    using System;

    public class Database
    {
        private const int ArrayCapacity = 16;
        private int[] data;
        private int currentIndex;

        public Database(IEnumerable<int> data)
        {
            this.AddInitialArray(data.ToArray());
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
        }

        private void AddInitialArray(int[] data)
        {
            if (data.Length > 16)
            {
                throw new InvalidOperationException("Array lenght must be less or equal to 16!");
            }

            this.data = new int[ArrayCapacity];

            for (int i = 0; i < data.Length; i++)
            {
                this.data[i] = data[i];
                this.currentIndex++;
            }
        }

        public void Add(int num)
        {
            if (this.currentIndex > 15)
            {
                throw new InvalidOperationException("Cannot add more than 16 elements in the database!");
            }
            
            this.data[this.currentIndex] = num;
            this.currentIndex++;
        }

        public void Remove()
        {
            this.currentIndex--;
        }

        public int[] Fetch()
        {
            int[] data = new int[this.currentIndex + 1];
            for (int i = 0; i <= this.currentIndex; i++)
            {
                data[i] = this.data[i];
            }

            return data;
        }
    }
}
