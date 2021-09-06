using System.Collections.Generic;

namespace ImdbConsole.Domain
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public List<Actors> ActorsList { get; set; } = new List<Actors>();
        public Producers Producer { get; set; }

        public Movies(string title, int year, string description, Producers producer)
        {
            Title = title;
            Year = year;
            Description = description;
            Producer = producer;
        }

        public void AddActor(Actors actors)
        {
            ActorsList.Add(actors);
        }
    }
}
