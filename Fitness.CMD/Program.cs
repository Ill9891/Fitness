using Fitness.BL.Controller;
using Fitness.BL.Model;
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
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter a gender:");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E - enter the eating");
            var key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }                
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter a product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var prots = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydrates");

            var weight = ParseDouble("weight of portion");
            var product = new Food(food, calories, prots, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
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

            return birthDate;
        }

        private static double ParseDouble(string name)
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
                    Console.WriteLine($"Wrong {name} format of field.");
                }
            }
        }
    }
}
