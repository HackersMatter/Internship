using System;
using System.Collections.Generic;
using System.Linq;
using static System.String;
using ImdbConsole.Domain;

namespace ImdbConsole
{
    class Print
    {
        public static void ActorsList(List<Actors> listActors)
        {
            Console.WriteLine("\n-------------------------------------------------------\n" +
                              " Sr no. | Actors\n" +
                              "-------------------------------------------------------");
            foreach (var actor in listActors)
            {
                Console.WriteLine("      {0} : {1}", actor.Id, actor.Name);
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public static void ProducersList(List<Producers> listProducers)
        {
            Console.WriteLine("\n-------------------------------------------------------\n" +
                              " Sr no. | Producers\n" +
                              "-------------------------------------------------------");
            foreach (var producer in listProducers)
            {
                Console.WriteLine("      {0} : {1}", producer.Id, producer.Name);
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public static void MoviesList(List<Movies> listMovies)
        {
            Console.WriteLine("-------------------------------------------------------\n" +
                              " Id | Movies\n" +
                              "-------------------------------------------------------");
            if (listMovies.Count != 0)
            {
                foreach (var movie in listMovies)
                {
                    Console.WriteLine("  {0} | Name       : {1} ({2})\n" +
                                      "    | Description: {3}\n" +
                                      "    | Actors     : {4}\n" +
                                      "    | Producer   : {5}\n" +
                                      "-------------------------------------------------------",
                        movie.Id,
                        movie.Title,
                        movie.Year,
                        movie.Description,
                        Join(", ", movie.ActorsList.Select(actor => actor.Name).ToList()),
                        movie.Producer.Name);
                }
            }
            else
            {
                Console.WriteLine("  - | Empty List\n" +
                                  "-------------------------------------------------------");
            }
        }

        public static void Welcome()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                              "                Welcome to IMDB Console\n" +
                              "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }

        public static void ListOperations()
        {
            Console.Write("List of operations:\n" +
                          "1) List Movies\n" +
                          "2) Add Movie\n" +
                          "3) Add Actor\n" +
                          "4) Add Producer\n" +
                          "5) Delete Movie\n" +
                          "6) Exit\n\n" +
                          "Operation: ");
        }
    }
}
