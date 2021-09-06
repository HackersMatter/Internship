using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using ImdbConsole;
using ImdbConsole.Domain;
using TechTalk.SpecFlow.Assist;

namespace ConsoleTest
{
    [Binding]
    public class ImdbConsoleSteps
    {
        private readonly Services _services;
        private List<Movies> _movies;
        private string _title, _year, _description, _producer;
        private string[] _actorList;

        public ImdbConsoleSteps()
        {
            _services = new Services();
        }

        [Given(@"I have movie repository")]
        public void GivenIHaveMovieRepository()
        {
        }
        
        [When(@"I fetch the repository")]
        public void WhenIFetchTheRepository()
        {
            _movies = _services.ListMovies();
        }
        
        [Then(@"I get result")]
        public void ThenIGetResult(Table table)
        {
            table.CompareToSet(_movies);
        }

        [Then(@"Actor list is")]
        public void ThenActorListIs(Table table)
        {
            var actorlist = new List<Actors>();
            actorlist = _movies.Select(movie => movie.ActorsList).ToList().Aggregate(actorlist, (current, movie) => current.Concat(movie).ToList());
            table.CompareToSet(actorlist);
        }

        [Then(@"Producer is")]
        public void ThenProducerIs(Table table)
        {
            table.CompareToSet(_movies.Select(movie => movie.Producer).ToList());
        }

        [Given(@"I have title ""(.*)""")]
        public void GivenIHaveTitle(string title)
        {
            _title = title;
        }

        [Given(@"I have release year ""(.*)""")]
        public void GivenIHaveReleaseYear(string year)
        {
            _year = year;
        }

        [Given(@"I have description ""(.*)""")]
        public void GivenIHaveDescription(string description)
        {
            _description = description;
        }

        [Given(@"Actors are ""(.*)""")]
        public void GivenActorsAre(string actorsList)
        {
            _actorList = actorsList.Split();
        }

        [Given(@"Producer is ""(.*)""")]
        public void GivenProducerIs(string producer)
        {
            _producer = producer;
        }

        [When(@"I add the movie")]
        public void WhenIAddTheMovie()
        {
            _services.AddMovie(_title, _year, _description, _actorList, _producer);
            _movies = _services.ListMovies();
        }

        [BeforeScenario("listmovies")]
        public void AddSamplemovie()
        {
            _services.AddActor("Matt Damon", "8/10/1970");
            _services.AddActor("Christian Bale", "30/1/1974");
            _services.AddProducer("James Mangold", "16/12/1963");
            _services.AddMovie("Ford v Ferrari", "2019",
                "xyz",
                new[] { "1", "2" },
                "1");
        }

        [BeforeScenario("addmovie")]
        public void AddActors()
        {
            _services.AddActor("Matt Damon", "8/10/1970");
            _services.AddActor("Christian Bale", "30/1/1974");
            _services.AddActor("Siddhart Malhotra", "17/1/1985");
            _services.AddActor("Kiara Advani", "31/7/1992");
            _services.AddProducer("James Mangold", "16/12/1963");
            _services.AddProducer("Apoorva Mehta", "22/5/1978");
            _services.AddMovie("Ford v Ferrari", "2019",
                "xyz",
                new[] { "1", "2" },
                "1");
        }
    }
}
