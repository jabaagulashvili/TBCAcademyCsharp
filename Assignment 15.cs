using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApp
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}


namespace ConsoleApp
{
    public class StringUtils
    {
        public string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public int CountWords(string input)
        {
            string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public string ConcatenateStrings(string[] strings)
        {
            return string.Join(" ", strings);
        }
    }
}


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Console Application!");

            while (true)
            {
                Console.WriteLine("Choose a class to create:");
                Console.WriteLine("1. Calculator");
                Console.WriteLine("2. StringUtils");
                Console.WriteLine("3. Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }

                if (option == 1)
                {
                    CreateAndInvokeClass<Calculator>();
                }
                else if (option == 2)
                {
                    CreateAndInvokeClass<StringUtils>();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

        static void CreateAndInvokeClass<T>() where T : class, new()
        {
            T instance = new T();
            Type type = typeof(T);

            Console.WriteLine($"Class {type.Name} has been created.");

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.GetParameters().Length > 0).ToArray();

            Console.WriteLine("Available methods:");
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {methods[i].Name}");
            }

            Console.WriteLine("Choose a method to invoke (enter the number):");
            int methodIndex;
            if (!int.TryParse(Console.ReadLine(), out methodIndex) || methodIndex < 1 || methodIndex > methods.Length)
            {
                Console.WriteLine("Invalid method selection. Please try again.");
                return;
            }

            MethodInfo selectedMethod = methods[methodIndex - 1];
            ParameterInfo[] parameters = selectedMethod.GetParameters();
            object[] arguments = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                Console.WriteLine($"Enter a value for parameter '{parameters[i].Name}' of type '{parameters[i].ParameterType.Name}':");
                string value = Console.ReadLine();

                try
                {
                    arguments[i] = Convert.ChangeType(value, parameters[i].ParameterType);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input for parameter. Please try again.");
                    return;
                }
            }

            try
         {
                object result = selectedMethod.Invoke(instance, arguments);
                Console.WriteLine($"Method '{selectedMethod.Name}' returned: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error invoking the method: {ex.Message}");
            }
        }
    }
}
