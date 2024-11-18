using System.ComponentModel.DataAnnotations;

namespace UltraStore.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome da Publisher")]
        [StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 characteres")]
        public string Name { get; set; }
        [Display(Name = "Foundation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FoundationDate { get; set; }
        public List<Developer> Developers { get; set; }
            = new List<Developer>();
    }
}
