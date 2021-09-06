using System.Collections.Generic;
using System.Linq;
using ImdbConsole.Domain;

namespace ImdbConsole.Repository
{
    public class ProducersRepository
    {
        private readonly List<Producers> _producers;

        public ProducersRepository()
        {
            _producers = new List<Producers>();
        }

        public void Add(Producers producers)
        {
            producers.Id = _producers.Count == 0 ? 1 : _producers.Last().Id + 1;
            _producers.Add(producers);
        }

        public List<Producers> Get()
        {
            return _producers;
        }

        public Producers Get(int index)
        {
            return _producers.Find(producer => producer.Id == index);
        }

        public bool IsPresent(int id)
        {
            return _producers.Select(producer => producer.Id).ToList().Contains(id);
        }
    }
}