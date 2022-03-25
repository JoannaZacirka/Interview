using System.Collections.Generic;
using NUnit.Framework;

namespace SumLists
{
    public class LinkedListWithInit<T> : LinkedList<T>
    {
        public void Add(T item)
        {
            ((ICollection<T>)this).Add(item);
        }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SumListsTest()
        {
            // given
            LinkedList<int> number1 = new LinkedListWithInit<int> {7, 1, 6};
            LinkedList<int> number2 = new LinkedListWithInit<int> {5, 9, 2};

            // when
            var result = Solution.SumLists(number1, number2);

            // then
            Assert.AreEqual(3, result.Count);
            var enumerator = result.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(2, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(9, enumerator.Current);
        }
    }


    
}