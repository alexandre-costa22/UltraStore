using System.ComponentModel.DataAnnotations;
using UltraStore.Models;

namespace UltraStore.Models
{
    public class Software
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do software é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do software deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do software")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O fabricante do software é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do fabricante deve ter no máximo 100 caracteres.")]
        [Display(Name = "Fabricante")]
        public string Manufacturer { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A geração deve ser um número positivo.")]
        [Display(Name = "Geração")]
        public int Generation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de lançamento")]
        public DateTime ReleaseDate { get; set; }
    }
}
