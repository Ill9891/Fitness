using Fitness.BL.Controller;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This is Fitness app");

            Console.WriteLine("Enter a user name:");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter a gender:");
                var gender = Console.ReadLine();

                DateTime birthDate;
                double weight;
                double height;

                while (true)
                {
                    Console.WriteLine("Enter a date of birth (dd.MM.yyyy):");
                    if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong date of birth format.");
                    }
                }

                //Console.WriteLine("Enter a weight:");
                //var weight = double.Parse(Console.ReadLine());

                //Console.WriteLine("Enter a height:");
                //var height = double.Parse(Console.ReadLine());

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static double ParseDouble<T>(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter a {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong {name} format.");
                }
            }
        }
    }
}
