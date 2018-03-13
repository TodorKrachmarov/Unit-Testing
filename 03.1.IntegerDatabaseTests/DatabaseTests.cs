namespace _03._1.IntegerDatabaseTests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _03.IntegerDatabase;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(4)]
        [TestCase(10)]
        [TestCase(16)]
        public void TestConstructorWithDiferentValidParameters(int count)
        {
            // Arrange
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            // Act
            Database data = new Database(list);

            // Assert
            Assert.AreEqual(count, data.CurrentIndex);
        }

        [Test]
        public void TestConstructorWithInvalidParameter()
        {
            // Arrange
            List<int> list = new List<int>();
            for (int i = 0; i < 17; i++)
            {
                list.Add(i);
            }
            

            // Assert
            Assert.Throws<InvalidOperationException>(() => new Database(list));
        }

        [Test]
        public void DatebaseContructorDoesntAcceptNullObject()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Database(null), "Database cannot be initilized with null");
        }
    }
}
