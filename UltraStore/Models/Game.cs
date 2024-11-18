namespace UltraStore.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Franchise { get; set; }
        public Developer Developer { get; set; }
        public Publisher Publisher { get; set; }
        public double Price { get; set; }
    }
}
