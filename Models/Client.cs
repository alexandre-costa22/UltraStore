using System;
using System.ComponentModel.DataAnnotations;
using UltraStore.Enums;

namespace UltraStore.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do cliente")] 
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
        [Display(Name = "E-mail")] 
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        [StringLength(15, ErrorMessage = "O número de telefone não pode ter mais que 15 caracteres.")]
        [Display(Name = "Número de telefone")] 
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")] 
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de registro")] 
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [EnumDataType(typeof(Gender), ErrorMessage = "O gênero selecionado é inválido.")]
        [Display(Name = "Gênero")] 
        public Gender Gender { get; set; } = Gender.Other;
    }
}
