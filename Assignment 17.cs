using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListApp
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public MyList()
        {
            items = new T[4];
            count = 0;
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[count] = item;
            count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Remove(item);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                items[index] = value;
            }
        }

        public int Count => count;

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public T Single()
        {
            if (count != 1)
            {
                throw new InvalidOperationException("The list does not contain exactly one element.");
            }

            return items[0];
        }

        public T SingleOrDefault()
        {
            if (count == 0)
            {
                return default;
            }
            else if (count == 1)
            {
                return items[0];
            }
            else
            {
                throw new InvalidOperationException("The list contains more than one element.");
            }
        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                {
                    return items[i];
                }
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            for (int i = 0; i < count; i++)
            {
                if (predicate(items[i]))
                {
                    yield return items[i];
                }
            }
        }

        private int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


namespace MyListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();

            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            myList.Add(50);

            Console.WriteLine("MyList elements:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"MyList Count: {myList.Count}");

            Console.WriteLine($"Element at index 2: {myList[2]}");

            myList[2] = 35;
            Console.WriteLine($"Updated element at index 2: {myList[2]}");

            Console.WriteLine($"Is 25 present in MyList? {myList.Contains(25)}");

            Console.WriteLine("Using Single() and SingleOrDefault():");
            try
            {
                Console.WriteLine($"Single element: {myList.Single()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine($"SingleOrDefault element: {myList.SingleOrDefault()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Using Find() and Where():");
            try
            {
                int element = myList.Find(x => x > 30);
                Console.WriteLine($"Find: {element}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Elements greater than 20 using Where():");
            foreach (var item in myList.Where(x => x > 20))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Removing elements using Remove() and RemoveRange():");
            myList.Remove(35);
            myList.RemoveRange(new[] { 10, 50 });

            Console.WriteLine("MyList elements after removal:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
