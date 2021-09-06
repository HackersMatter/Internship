using System;
using System.Collections.Generic;
using System.Globalization;
using ImdbConsole.Domain;
using ImdbConsole.Repository;
using System.Linq;

namespace ImdbConsole
{
    public class Services
    {
        private readonly ActorsRepository _actorsRepository;
        private readonly MoviesRepository _moviesRepository;
        private readonly ProducersRepository _producersRepository;

        public Services()
        {
            _moviesRepository = new MoviesRepository();
            _producersRepository = new ProducersRepository();
            _actorsRepository = new ActorsRepository();
        }

        public List<Movies> ListMovies()
        {
            return _moviesRepository.Get();
        }

        public List<Actors> ListActors()
        {
            return _actorsRepository.Get();
        }

        public List<Producers> ListProducers()
        {
            return _producersRepository.Get();
        }

        public void AddMovie(string title, string year, string description, string[] actorList, string producerIndex)
        {
            var movie = new Movies(title,
                Convert.ToInt32(year),
                string.IsNullOrWhiteSpace(description) ? "-" : description,
                _producersRepository.Get(Convert.ToInt32(producerIndex)));

            foreach (var index in actorList.Select(int.Parse).ToList())
            {
                movie.AddActor(_actorsRepository.Get(index));
            }
            _moviesRepository.Add(movie);
        }

        public void AddActor(string name, string dob)
        {
            var actor = new Actors(name, Convert.ToDateTime(dob, new CultureInfo("es-ES")).ToString("d/M/yyyy"));
            _actorsRepository.Add(actor);
        }

        public void AddProducer(string name, string dob)
        {
            var producer = new Producers(name, Convert.ToDateTime(dob, new CultureInfo("es-ES")).ToString("d/M/yyyy"));
            _producersRepository.Add(producer);
        }

        public void DeleteMovie(string movieIndex)
        {
            _moviesRepository.Delete(Convert.ToInt32(movieIndex));
        }

        public bool ProducerElement(int id)
        {
            return _producersRepository.IsPresent(id);
        }

        public bool MovieElement(int id)
        {
            return _moviesRepository.IsPresent(id);
        }

        public bool ActorElement(List<int> actorIndex)
        {
            foreach (var index in actorIndex)
            {
                if (!_actorsRepository.IsPresent(index))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
