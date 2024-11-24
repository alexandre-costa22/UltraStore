using Microsoft.CodeAnalysis;

namespace UltraStore.Models
{
    public class Game
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Franchise { get; set; }
        //public Developer Developer { get; set; }
        //public Publisher Publisher { get; set; }
        //public double Price { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; } 
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; } 
        public ICollection<Platforms> Platforms { get; set; } = new List<Platforms>();
        public DateTime ReleaseDate { get; set; }
        public Platform? Platform { get; set; }
        public int PlatformId { get; set; } 
    }
}
