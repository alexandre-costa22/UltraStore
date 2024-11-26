using System.ComponentModel.DataAnnotations;

namespace UltraStore.Models
{
    public class Franchise
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da franquia é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da franquia deve ter no máximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "A descrição deve ter no máximo 2000 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de lançamento do primeiro título é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FirstTitleReleaseDate { get; set; }

        [Required(ErrorMessage = "A data de lançamento do último título é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastTitleReleaseDate { get; set; }
    }
}
