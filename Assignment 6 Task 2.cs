using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class CustomList<T>
    {
        private List<T> elements;

        public CustomList()
        {
            elements = new List<T>();
        }

        public void AddElement(T element)
        {
            elements.Add(element);
        }

        public void AddList(List<T> list)
        {
            elements.AddRange(list);
        }

        public bool InsertElement(int index, T element)
        {
            if (index >= 0 && index <= elements.Count)
            {
                elements.Insert(index, element);
                return true;
            }
            return false;
        }

        public bool InsertList(int index, List<T> list)
        {
            if (index >= 0 && index <= elements.Count)
            {
                elements.InsertRange(index, list);
                return true;
            }
            return false;
        }

        public bool GetElement(int index, out T element)
        {
            if (index >= 0 && index < elements.Count)
            {
                element = elements[index];
                return true;
            }
            element = default(T);
            return false;
        }

        public bool GetList(int index, int count, out List<T> subList)
        {
            if (index >= 0 && index + count <= elements.Count)
            {
                subList = elements.GetRange(index, count);
                return true;
            }
            subList = null;
            return false;
        }

        public bool RemoveElement(T element)
        {
            return elements.Remove(element);
        }

        public void RemoveList(List<T> list)
        {
            foreach (T element in list)
            {
                elements.Remove(element);
            }
        }

        public void Clear()
        {
            elements.Clear();
        }

        public T Find(Predicate<T> match)
        {
            return elements.Find(match);
        }

        public int Count
        {
            get { return elements.Count; }
        }

        public T this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }
    }
}

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> stringList = new CustomList<string>();

            // Add elements in list
            stringList.AddElement("Element 1");
            stringList.AddElement("Element 2");
            stringList.AddElement("Element 3");

            // Insert an element in any specific position
            stringList.InsertElement(1, "New Element");

            // Get an element in any specific position
            if (stringList.GetElement(2, out string element))
            {
                Console.WriteLine("Element at position 2: " + element);
            }
            else
            {
                Console.WriteLine("Invalid position");
            }

            // Get sublist
            if (stringList.GetList(1, 3, out List<string> subList))
            {
                Console.WriteLine("Sublist from position 1 to 3:");
                foreach (string item in subList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Invalid range");
            }

            // Element Removal
            bool removed = stringList.RemoveElement("Element 2");
            Console.WriteLine("Element removed: " + removed);

            // Element Count
            Console.WriteLine("Number of elements in the list: " + stringList.Count);

            // Access elements using indexer
            Console.WriteLine("Element at index 0: " + stringList[0]);
            Console.WriteLine("Element at index 1: " + stringList[1]);

            Console.ReadLine();
        }
    }
}