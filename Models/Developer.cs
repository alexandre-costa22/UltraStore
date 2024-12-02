using System.ComponentModel.DataAnnotations;
using LvlUp.Enums;

namespace LvlUp.Models
{
    public class Developer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do desenvolvedor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do desenvolvedor deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do desenvolvedor")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de fundação é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de fundação")]
        public DateTime FoundationDate { get; set; }

        [Required(ErrorMessage = "O tipo de desenvolvedor é obrigatório.")]
        [Display(Name = "Tipo de desenvolvedor")]
        public DeveloperType DeveloperType { get; set; }

        [StringLength(200, ErrorMessage = "A localização deve ter no máximo 200 caracteres.")]
        [Display(Name = "Localização")]
        public string Location { get; set; } = string.Empty;
    }
}
