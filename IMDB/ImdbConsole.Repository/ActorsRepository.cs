using System.Collections.Generic;
using System.Linq;
using ImdbConsole.Domain;

namespace ImdbConsole.Repository
{
    public class ActorsRepository
    {
        private readonly List<Actors> _actors;

        public ActorsRepository()
        {
            _actors = new List<Actors>();
        }

        public void Add(Actors actors)
        {
            actors.Id = _actors.Count == 0 ? 1 : _actors.Last().Id + 1;
            _actors.Add(actors);
        }

        public List<Actors> Get()
        {
            return _actors;
        }

        public Actors Get(int index)
        {
            return _actors.First(actor=>actor.Id == index);
        }

        public bool IsPresent(int id)
        {
            return _actors.Select(producer => producer.Id).ToList().Contains(id);
        }
    }
}