using System;
using System.Linq;
using static System.String;

namespace ImdbConsole
{
    public class Program
    {
        static void Main()
        {
            var services = new Services();
            
            services.AddActor("Matt Damon", "8/10/1970");
            services.AddActor("Christian Bale", "30/1/1974");
            services.AddActor("Siddhart Malhotra", "17/1/1985");
            services.AddActor("Kiara Advani", "31/7/1992");
            services.AddProducer("James Mangold", "16/12/1963");
            services.AddProducer("Apoorva Mehta", "22/5/1978");
            services.AddMovie("Ford v Ferrari", "2019",
                "xyz",
                new[] { "1", "2" },
                "1");
            services.AddMovie("Shershaah", "2021",
                "xyz",
                new[] { "3", "4" },
                "2");

            Print.Welcome();
            Print.ListOperations();

            var inputOperation = Console.ReadLine();

            while (inputOperation != "6")
            {
                switch (inputOperation)
                {
                    case "1":
                    Print.MoviesList(services.ListMovies());
                    break;

                    case "2":
                    if (services.ListActors().Count != 0 && services.ListProducers().Count != 0)
                    {
                        Console.Write("\nTitle: ");
                        var title = Console.ReadLine();
                        while (IsNullOrWhiteSpace(title))
                        {
                            Console.Write("Please enter valid title: ");
                            title = Console.ReadLine();
                        }

                        Console.Write("Year of release: ");
                        var year = Console.ReadLine();
                        while (!Validate.Year(year))
                        {
                            Console.Write("Please enter valid release year: ");
                            year = Console.ReadLine();
                        }

                        Console.Write("Description: ");
                        var description = Console.ReadLine();
                            
                        Print.ActorsList(services.ListActors());
                        Console.Write("Choose actor(s): ");
                        var actorList = Console.ReadLine()?.Trim().Split();
                        while (!Validate.NumberList(actorList) || !services.ActorElement(actorList.Select(int.Parse).ToList()))
                        {
                            Console.Write("Please enter valid Id(s): ");
                            actorList = Console.ReadLine()?.Trim().Split();
                        }
                        
                        Print.ProducersList(services.ListProducers());
                        Console.Write("Choose producer: ");
                        var producerIndex = Console.ReadLine();
                        while (!Validate.ProducerIndex(producerIndex) || !services.ProducerElement(Convert.ToInt32(producerIndex)))
                        {
                            Console.Write("Please enter valid Id: ");
                            producerIndex = Console.ReadLine();
                        }

                        services.AddMovie(title, year, description, actorList, producerIndex);
                        Console.WriteLine("Movie added successfully...\n");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Data\n" + 
                                          "Total Actors: {0}\n" +
                                          "Total Producers: {1}\n",
                                          services.ListActors().Count,services.ListProducers().Count);
                    }

                    break;

                    case "3":
                    Console.Write("\nName of the Actor: ");
                    var actorName = Console.ReadLine();
                    while (IsNullOrWhiteSpace(actorName))
                    {
                        Console.Write("Please enter Valid name: ");
                        actorName = Console.ReadLine();
                    }
                    
                    Console.Write("DOB (dd/mm/yyyy): ");
                    var actorDob = Console.ReadLine();
                    while (!Validate.Date(actorDob))
                    {
                        Console.Write("Please enter valid DOB:");
                        actorDob = Console.ReadLine();
                    }

                    services.AddActor(actorName, actorDob);
                    Console.WriteLine("Actor added successfully....\n");
                    break;

                    case "4":
                    Console.Write("\nName of the Producer: ");
                    var producerName = Console.ReadLine();
                    while (IsNullOrWhiteSpace(producerName))
                    {
                        Console.Write("Please enter Valid name: ");
                        producerName = Console.ReadLine();
                    }

                    Console.Write("DOB (dd/mm/yyyy): ");
                    var producerDob = Console.ReadLine();
                    while (!Validate.Date(producerDob))
                    {
                        Console.Write("Please enter valid DOB:");
                        producerDob = Console.ReadLine();
                    }

                    services.AddProducer(producerName, producerDob);
                    Console.WriteLine("Producer added successfully....\n");
                    break;

                    case "5":
                    Print.MoviesList(services.ListMovies());
                    if (services.ListMovies().Count != 0)
                    {
                        Console.Write("Movie Id: ");
                        var movieIndex = Console.ReadLine();
                        while (!Validate.MovieIndex(movieIndex) || !services.MovieElement(Convert.ToInt32(movieIndex)))
                        {
                            Console.Write("Please enter valid Id: ");
                            movieIndex = Console.ReadLine();
                        }

                        services.DeleteMovie(movieIndex);
                        Console.WriteLine("Movie Deleted.....\n");
                    }
                    break;

                    case "6":
                    break;

                    default:
                    Console.WriteLine("Enter valid number.....\n");
                    break;
                }

                Console.WriteLine();
                Print.ListOperations();
                inputOperation = Console.ReadLine();
            }
        }
    }
}
