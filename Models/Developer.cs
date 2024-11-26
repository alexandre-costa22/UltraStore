using System.ComponentModel.DataAnnotations;
using UltraStore.Enums;

namespace UltraStore.Models
{
    public class Developer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do desenvolvedor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do desenvolvedor deve ter no máximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de fundação é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FoundationDate { get; set; }

        [Required(ErrorMessage = "O tipo de desenvolvedor é obrigatório.")]
        public DeveloperType DeveloperType { get; set; }

        [StringLength(200, ErrorMessage = "A localização deve ter no máximo 200 caracteres.")]
        public string Location { get; set; } = string.Empty;
    }
}
