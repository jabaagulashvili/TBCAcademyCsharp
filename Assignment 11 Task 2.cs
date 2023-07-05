using System;
using System.Collections.Generic;

class Storage<T>
{
    private List<T> items;

    public Storage()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
        Console.WriteLine("Item added: " + item);
    }

    public void Remove(T item)
    {
        if (items.Remove(item))
        {
            Console.WriteLine("Item removed: " + item);
        }
        else
        {
            Console.WriteLine("Item not found: " + item);
        }
    }

    public void Update(T oldItem, T newItem)
    {
        int index = items.IndexOf(oldItem);
        if (index != -1)
        {
            items[index] = newItem;
            Console.WriteLine("Item updated: " + oldItem + " -> " + newItem);
        }
        else
        {
            Console.WriteLine("Item not found: " + oldItem);
        }
    }

    public void PrintItems()
    {
        Console.WriteLine("Items in storage:");
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }
}

class Assignment
{
    static void Main()
    {

        Storage<int> intStorage = new Storage<int>();
        intStorage.Add(100);
        intStorage.Add(200);
        intStorage.Add(300);
        intStorage.PrintItems();

        intStorage.Remove(200);
        intStorage.Update(300, 400);
        intStorage.PrintItems();


        Storage<string> stringStorage = new Storage<string>();
        stringStorage.Add("Apple");
        stringStorage.Add("Kiwi");
        stringStorage.PrintItems();

        stringStorage.Remove("Orange");
        stringStorage.Update("Kiwi", "Banana");
        stringStorage.PrintItems();
    }
}
