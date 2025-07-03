using System;

namespace Library.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            char choice;

            do
            {
                CreateMenu();
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case 'A':
                        Console.WriteLine("Hi!");
                        break;
                    default:
                        Console.WriteLine("This choice does not exist");
                        break;
                }
            } while (choice.ToString().ToUpper() != "Q");

            Console.ReadKey();
        }

        public static void CreateMenu()
        {
            Console.WriteLine("------------------- Info Library - Test -------------------");
            Console.WriteLine("\n");
            Console.WriteLine("A - Get all users");
            Console.WriteLine("B - Get user by id");
            Console.WriteLine("C - Create user");
            Console.WriteLine("D - Delete user");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Q - Exit");
            Console.WriteLine("\nEnter a choice: ");
        }
    }
}
