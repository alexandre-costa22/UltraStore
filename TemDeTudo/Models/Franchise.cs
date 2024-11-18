using System.ComponentModel.DataAnnotations;

namespace UltraStore.Models

{
    public class Franchise
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Título da Franquia")]
        [StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 characteres")]
        public string Name { get; set; }
        [Display(Name = "Data do primeiro lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FirstTitleLaunch { get; set; }
        public List<Developer> Developers { get; set; }
            = new List<Developer>();
        public List<Publisher> Publisher { get; set; } 
            = new List<Publisher>();
        public List<Game> Games { get; set; } 
            = new List<Game>();
    }
}
