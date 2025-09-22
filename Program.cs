using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");
        Console.WriteLine("After removing Apple:");
        manager.PrintAllItems();

        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        Console.WriteLine("\n--- Generic Item Manager with Fruits ---");
        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();
        fruitManager.AddItem(new Fruit("Apple", "Red"));
        fruitManager.AddItem(new Fruit("Banana", "Yellow"));
        fruitManager.AddItem(new Fruit("Grape", "Purple"));
        
        fruitManager.PrintAllItems();

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        Console.WriteLine("\n--- Using Interface ---");
        IItemManager<string> interfaceManager = new ItemManager();
        interfaceManager.AddItem("Item via Interface");
        interfaceManager.PrintAllItems();
    }
}

// Part Four: Interface implementation
public interface IItemManager<T>
{
    void AddItem(T item);
    void RemoveItem(T item);
    void PrintAllItems();
    void ClearAllItems();
}

// Part One: Fix NullReferenceException by initializing the list
public class ItemManager : IItemManager<string>
{
    private List<string> items;

    public ItemManager()
    {
        items = new List<string>();
    }

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items to display.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Part Two: Implement the RemoveItem method
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"Removed: {item}");
        }
        else
        {
            Console.WriteLine($"Item not found: {item}");
        }
    }

    public void ClearAllItems()
    {
        items.Clear();
        Console.WriteLine("All items cleared.");
    }
}

// Part Three: Fruit class
public class Fruit
{
    public string Name { get; set; }
    public string Color { get; set; }

    public Fruit(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Name} ({Color})";
    }
}

// Generic ItemManager with proper initialization
public class ItemManager<T> : IItemManager<T>
{
    private List<T> items;

    public ItemManager()
    {
        items = new List<T>();
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items to display.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine(item?.ToString() ?? "null");
        }
    }

    public void RemoveItem(T item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"Removed: {item}");
        }
        else
        {
            Console.WriteLine($"Item not found: {item}");
        }
    }

    public void ClearAllItems()
    {
        items.Clear();
        Console.WriteLine("All items cleared.");
    }
}
