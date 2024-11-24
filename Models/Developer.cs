using System.ComponentModel.DataAnnotations;

namespace UltraStore.Models

{
    public class Developer
    {
        //public int Id { get; set; }
        //[Required]
        //[Display(Name = "Nome da Developer")]
        //[StringLength(30, ErrorMessage = "O nome deve ter no máximo 50 characteres")]
        //public string Name { get; set; }
        //[Display(Name = "Foundation Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime FoundationDate { get; set; }
        //public List<Game> DevelopedGames { get; set; }
        //    = new List<Game>();
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public ICollection<Game>? Games { get; set; } 
    }
}
