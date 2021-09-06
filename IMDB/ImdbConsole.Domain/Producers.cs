using System;

namespace ImdbConsole.Domain
{
    public class Producers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }

        public Producers(string name, string dob)
        {
            Name = name;
            Dob = dob;
        }
    }
}