using System;
using System.Collections.Generic;

namespace ContactsApp
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Contact(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}


namespace ContactsApp
{
    class Program
    {
        delegate bool ContactFilter(Contact contact, string searchTerm, int? minAge, int? maxAge);

        static void Main(string[] args)
        {
            List<Contact> contacts = GetTestContacts();

            Console.WriteLine("Welcome to the Contacts App!");

            while (true)
            {
                Console.WriteLine("Choose a filter:");
                Console.WriteLine("1. Search by first name (not exact match)");
                Console.WriteLine("2. Search by last name (not exact match)");
                Console.WriteLine("3. Search by first and last name (inexact matching)");
                Console.WriteLine("4. Search by age (age range)");
                Console.WriteLine("5. Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }

                if (option == 5)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                ContactFilter filter = null;
                string searchTerm;
                int? minAge = null;
                int? maxAge = null;

                switch (option)
                {
                    case 1:
                        filter = FilterByFirstName;
                        Console.WriteLine("Enter the first name to search:");
                        searchTerm = Console.ReadLine();
                        break;
                    case 2:
                        filter = FilterByLastName;
                        Console.WriteLine("Enter the last name to search:");
                        searchTerm = Console.ReadLine();
                        break;
                    case 3:
                        filter = FilterByFirstAndLastName;
                        Console.WriteLine("Enter the first name to search:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name to search:");
                        string lastName = Console.ReadLine();
                        searchTerm = $"{firstName} {lastName}";
                        break;
                    case 4:
                        filter = FilterByAge;
                        Console.WriteLine("Enter the minimum age:");
                        if (!int.TryParse(Console.ReadLine(), out int min))
                        {
                            Console.WriteLine("Invalid input for minimum age. Using default value: 0.");
                            minAge = 0;
                        }
                        else
                        {
                            minAge = min;
                        }

                        Console.WriteLine("Enter the maximum age:");
                        if (!int.TryParse(Console.ReadLine(), out int max))
                        {
                            Console.WriteLine("Invalid input for maximum age. Using default value: 100.");
                            maxAge = 100;
                        }
                        else
                        {
                            maxAge = max;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        continue;
                }

                Console.WriteLine("Filtered Contacts:");
                foreach (var contact in contacts)
                {
                    if (filter(contact, searchTerm, minAge, maxAge))
                    {
                        Console.WriteLine($"{contact.FirstName} {contact.LastName}, Age: {contact.Age}");
                    }
                }
            }
        }

        static bool FilterByFirstName(Contact contact, string searchTerm, int? minAge, int? maxAge)
        {
            return contact.FirstName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 &&
                   FilterByAge(contact, null, minAge, maxAge);
        }

        static bool FilterByLastName(Contact contact, string searchTerm, int? minAge, int? maxAge)
        {
            return contact.LastName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 &&
                   FilterByAge(contact, null, minAge, maxAge);
        }

        static bool FilterByFirstAndLastName(Contact contact, string searchTerm, int? minAge, int? maxAge)
        {
            string fullName = $"{contact.FirstName} {contact.LastName}";
            return fullName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 &&
                   FilterByAge(contact, null, minAge, maxAge);
        }

        static bool FilterByAge(Contact contact, string searchTerm, int? minAge, int? maxAge)
        {
            return (!minAge.HasValue || contact.Age >= minAge.Value) &&
                   (!maxAge.HasValue || contact.Age <= maxAge.Value);
        }

        static List<Contact> GetTestContacts()
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact("John", "Doe", 25),
                new Contact("Jane", "Smith", 30),
                new Contact("Alice", "Johnson", 28),
                new Contact("Bob", "Williams", 22),
                new Contact("Michael", "Brown", 35),
            };
            return contacts;
        }
    }
}