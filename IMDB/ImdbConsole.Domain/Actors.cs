namespace ImdbConsole.Domain
{
    public class Actors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }

        public Actors(string name, string dob)
        {
            Name = name;
            Dob = dob;
        }
    }
}