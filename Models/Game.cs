using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Data do primeiro lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public Developer? Developer { get; set; }
        public Publisher? Publisher { get; set; } 
        public Franchise? Franchise { get; set; } 
        public Platforms? Platforms { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
        public int FranchiseId { get; set; }
        public int PlatformsId { get; set; }
    }
}
