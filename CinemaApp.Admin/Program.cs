using CinemaApi.Models;
using CinemaApp.Admin.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Admin
{
    class Program
    {

        static void Main(string[] args)
        {
            CreateFunction CreateData = new CreateFunction();

            PrintDataFunction PrintData = new PrintDataFunction();

            HttpResponseMessage response;
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
                        Console.Clear();
                        response = GlobalVariables.WebApiClient.DeleteAsync("Cinema/DeleteAll").Result;
                        Console.WriteLine("Delete Done");
                        break;
                    case "0":
                        IEnumerable<User> AllUsers;
                        response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetUser").Result;
                        AllUsers = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                        if (AllUsers.Count() == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("    Add User Start");
                            CreateData.CreateUser();
                            Console.WriteLine("    Add User Done");

                            Console.WriteLine("    Add Movie Start");
                            CreateData.CreateMovie();
                            Console.WriteLine("    Add Movie Done");

                            Console.WriteLine("    Add Hall Start");
                            CreateData.CreateHall();
                            Console.WriteLine("    Add Hall Done");

                            Console.WriteLine("    Add Showing Movie Start");
                            CreateData.CreateShowingMovie();
                            Console.WriteLine("    Add Showing Movie Done");

                            Console.WriteLine("    Add MovieSeat Start");
                            CreateData.CreateMovieSeat("NoStatus");
                            Console.WriteLine("    Add MovieSeat Done");
                        }
                        break;



                    //case "0a":
                    //    Console.Clear();
                    //    Console.WriteLine("    Add User Done");
                    //    CreateData.CreateUser();
                    //    Console.WriteLine("    Add User Done");
                    //    break;
                    //case "0b":
                    //    Console.Clear();
                    //    Console.WriteLine("    Add Movie Start");
                    //    CreateData.CreateMovie();
                    //    Console.WriteLine("    Add Movie Done");
                    //    break;
                    //case "0c":
                    //    Console.WriteLine("    Add Hall Start");
                    //    CreateData.CreateHall();
                    //    Console.WriteLine("    Add Hall Done");
                    //    break;
                    //case "0d":
                    //    Console.Clear();
                    //    Console.WriteLine("    Add Showing Movie Start");
                    //    CreateData.CreateShowingMovie();
                    //    break;
                    //case "0e":
                    //    Console.Clear();
                    //    Console.WriteLine("    Add MovieSeat Start");
                    //    CreateData.CreateMovieSeat("NoStatus");
                    //    Console.WriteLine("    Add MovieSeat Done");
                    //    break;



                    case "1":
                        Console.Clear();
                        Console.WriteLine("     Movie Seat Status Start");
                        CreateData.CreateMovieSeat("GetStatus");
                        Console.WriteLine("     Movie Seat Status Done");
                        Console.WriteLine("\n\n");
                        Console.WriteLine("All Movie Hall Detail Data");
                        PrintData.PrintMovieSeat();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("All User Data");
                        PrintData.PrintAllUsers();
                        Console.WriteLine("\n\n");
                        Console.WriteLine("All Movie Data");
                        PrintData.PrintAllMovie();
                        Console.WriteLine("\n\n");
                        Console.WriteLine("All Hall Data");
                        PrintData.PrintHallDetail();
                        Console.WriteLine("\n\n");
                        Console.WriteLine("All Movie Hall Data");
                        PrintData.PrintMovieHall();
                        Console.WriteLine("\n\n");
                        Console.WriteLine("All Movie Hall Detail Data");
                        PrintData.PrintMovieSeat();
                        break;
                    case "2a":
                        Console.Clear();
                        Console.WriteLine("All User Data");
                        PrintData.PrintAllUsers();
                        break;
                    case "2b":
                        Console.Clear();
                        Console.WriteLine("All Movie Data");
                        PrintData.PrintAllMovie();
                        break;
                    case "2c":
                        Console.Clear();
                        Console.WriteLine("All Hall Data");
                        PrintData.PrintHallDetail();
                        break;
                    case "2d":
                        Console.Clear();
                        Console.WriteLine("All Movie Hall Data");
                        PrintData.PrintMovieHall();
                        break;
                    case "2e":
                        Console.Clear();
                        Console.WriteLine("All Movie Hall Detail Data");
                        PrintData.PrintMovieSeat();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please Enter Option In List");
                        break;
                }
            }
        }
    }
}
