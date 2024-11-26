using System.ComponentModel.DataAnnotations;

namespace UltraStore.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do vendedor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do vendedor deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do vendedor")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail do vendedor é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail do vendedor deve ter no máximo 100 caracteres.")]
        [Display(Name = "E-mail do vendedor")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento do vendedor é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [Phone(ErrorMessage = "Número de telefone inválido.")]
        [StringLength(15, ErrorMessage = "O número de telefone deve ter no máximo 15 caracteres.")]
        [Display(Name = "Número de telefone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de registro")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
