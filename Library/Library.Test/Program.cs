using System;
using System.Collections.Generic;

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
                Console.WriteLine();

                switch (choice)
                {
                    case 'A':
                        var users = GetAllUsers();

                        foreach (var user in users)
                            Console.WriteLine(user);
                        break;
                    default:
                        Console.WriteLine("This choice does not exist");
                        break;
                }
                Console.ReadKey();
            } while (choice.ToString().ToUpper() != "Q");

            Console.ReadKey();
        }

        public static void CreateMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------- Info Library - Test -------------------");
            Console.WriteLine("\n");
            Console.WriteLine("A - Get all users");
            Console.WriteLine("B - Get user by id");
            Console.WriteLine("C - Create user");
            Console.WriteLine("D - Delete user");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Q - Exit");
            Console.Write("\nEnter a choice: ");
        }
    }
}
