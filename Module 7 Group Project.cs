using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nDictionary Operations:");
            Console.WriteLine("1. Populate Dictionary");
            Console.WriteLine("2. Display Dictionary Contents");
            Console.WriteLine("3. Remove a Key");
            Console.WriteLine("4. Add a New Key and Value");
            Console.WriteLine("5. Add a Value to an Existing Key");
            Console.WriteLine("6. Sort the Keys");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option (1-7): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PopulateDictionary(myDictionary);
                    break;
                case "2":
                    DisplayDictionary(myDictionary);
                    break;
                case "3":
                    RemoveKey(myDictionary);
                    break;
                case "4":
                    AddNewKeyValue(myDictionary);
                    break;
                case "5":
                    AddValueToExistingKey(myDictionary);
                    break;
                case "6":
                    SortDictionaryKeys(myDictionary);
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 7.");
                    break;
            }
        }
    }

    static void PopulateDictionary(Dictionary<string, List<string>> dict)
    {
        dict.Clear(); // Clear existing data before populating
        dict["Fruits"] = new List<string> { "Apple", "Banana", "Orange" };
        dict["Animals"] = new List<string> { "Dog", "Cat", "Elephant" };
        dict["Countries"] = new List<string> { "USA", "Canada", "UK" };
        Console.WriteLine("Dictionary populated with sample data.");
    }

    static void DisplayDictionary(Dictionary<string, List<string>> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("The dictionary is empty.");
            return;
        }

        Console.WriteLine("\nDictionary Contents:");
        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }
    }

    static void RemoveKey(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter the key to remove: ");
        string key = Console.ReadLine();

        if (dict.Remove(key))
        {
            Console.WriteLine($"Key '{key}' removed successfully.");
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found.");
        }
    }

    static void AddNewKeyValue(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter the new key: ");
        string key = Console.ReadLine();

        if (dict.ContainsKey(key))
        {
            Console.WriteLine("Key already exists. Use option 5 to add a value.");
        }
        else
        {
            Console.Write("Enter the value: ");
            string value = Console.ReadLine();
            dict[key] = new List<string> { value };
            Console.WriteLine($"New key '{key}' added with value '{value}'.");
        }
    }

    static void AddValueToExistingKey(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter the key to add a value to: ");
        string key = Console.ReadLine();

        if (dict.ContainsKey(key))
        {
            Console.Write("Enter the value to add: ");
            string value = Console.ReadLine();
            dict[key].Add(value);
            Console.WriteLine($"Value '{value}' added to key '{key}'.");
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found.");
        }
    }

    static void SortDictionaryKeys(Dictionary<string, List<string>> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("The dictionary is empty.");
            return;
        }

        var sortedDict = dict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        Console.WriteLine("\nSorted Dictionary Contents:");
        foreach (var kvp in sortedDict)
        {
            Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }
    }
}
