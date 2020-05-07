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

            Console.WriteLine("Enter a gender:");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter a date of birth:");
            var birthDate = DateTime.Parse(Console.ReadLine()); //TODO rewrite

            Console.WriteLine("Enter a weight:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter a height:");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
