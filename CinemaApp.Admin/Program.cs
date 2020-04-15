using CinemaApp.Admin.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFunction create = new CreateFunction();
            while (true)
            {
                Console.WriteLine("-1 .Clear All Data");
                Console.WriteLine("0. Initialize Data");
                Console.WriteLine("     0a. Create Customer Data");
                Console.WriteLine("     0b. Create All Movie Data");
                Console.WriteLine("     0c. Create Hall Data");
                Console.WriteLine("     0d. Create Movie Hall Data");
                Console.WriteLine("     0e. Create Movie Hall Seat");
                Console.WriteLine("1. Generate Sample Taken Seats");
                Console.WriteLine("2. Print data");
                Console.WriteLine("     2a. Print All Users");
                Console.WriteLine("     2b. Print All Movie");
                Console.WriteLine("     2c. Print All Halls");
                Console.WriteLine("     2d. Print All Movie Halls");
                Console.WriteLine("     2e. Print All Movie Halls Details");
                Console.Write("Enter Option : ");   
                string Option = Console.ReadLine();

                switch (Option)
                {
                    case "-1":
                        break;
                    case "0":
                        break;
                    case "0a":
                        Console.Clear();
                        create.CreateUser();
                        Console.WriteLine("OK");
                        break;
                    case "0b":
                        Console.Clear();
                        create.CreateMovie();
                        Console.WriteLine("OK");
                        break;
                    case "0c":
                        break;
                    case "0d":
                        break;
                    case "0e":
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "2a":
                        break;
                    case "2b":
                        break;
                    case "2c":
                        break;
                    case "2d":
                        break;
                    case "2e":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
