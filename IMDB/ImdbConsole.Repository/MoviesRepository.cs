using System.Collections.Generic;
using System.Linq;
using ImdbConsole.Domain;

namespace ImdbConsole.Repository
{
    public class MoviesRepository
    {
        private readonly List<Movies> _movies;

        public MoviesRepository()
        {
            _movies = new List<Movies>();
        }

        public void Add(Movies movie)
        {
            movie.Id = _movies.Count == 0 ? 1 : _movies.Last().Id + 1;
            _movies.Add(movie);
        }

        public void Delete(int index)
        {
            _movies.RemoveAt(_movies.FindIndex(movie => movie.Id == index));
        }

        public List<Movies> Get()
        {
            return _movies;
        }

        public bool IsPresent(int id)
        {
            return _movies.Select(producer => producer.Id).ToList().Contains(id);
        }
    }
}