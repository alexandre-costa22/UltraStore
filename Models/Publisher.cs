using System.ComponentModel.DataAnnotations;

namespace LvlUp.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da publisher é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da publisher deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome da publisher")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O país da publisher é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do país deve ter no máximo 100 caracteres.")]
        [Display(Name = "País da publisher")]
        public string Country { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "O e-mail comercial é obrigatório.")]
        [StringLength(100, ErrorMessage = "O e-mail comercial deve ter no máximo 100 caracteres.")]
        [Display(Name = "E-mail comercial")]
        public string ComercialEmail { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
        [Display(Name = "Endereço")]
        public string Address { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de fundação")]
        public DateTime FoundationDate { get; set; }
    }
}
