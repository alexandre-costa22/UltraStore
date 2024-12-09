using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LvlUp.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O CPF do cliente é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter apenas números.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        [Display(Name = "ID do Cliente")]
        public int ClientId { get; set; }
        [Display(Name = "Cliente")]
        public Client? Clients { get; set; }

        [Required(ErrorMessage = "O Vendedor é obrigatório.")]
        [Display(Name = "ID do Vendedor")]
        public int SellerId { get; set; }
        [Display(Name = "Vendedor")]
        public Seller? Seller { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço total deve ser maior que zero.")]
        [Display(Name = "Preço total")]
        public decimal TotalPrice { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e hora de criação")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
