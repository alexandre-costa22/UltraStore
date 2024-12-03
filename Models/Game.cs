using System.ComponentModel.DataAnnotations;
using LvlUp.Enums;

namespace LvlUp.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do jogo é obrigatório.")]
        [StringLength(150, ErrorMessage = "O título do jogo deve ter no máximo 150 caracteres.")]
        [Display(Name = "Título do jogo")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [MaxLength(2000, ErrorMessage = "A descrição deve ter no máximo 2000 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de lançamento é obrigatória.")]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Display(Name = "Desenvolvedor")]
        public Developer? Developer { get; set; }

        [Display(Name = "Publisher")]
        public Publisher? Publisher { get; set; }

        [Display(Name = "Franquia")]
        public Franchise? Franchise { get; set; }

        [Display(Name = "Software")]
        public Software? Software { get; set; }

        [Required(ErrorMessage = "O ID do desenvolvedor é obrigatório.")]
        [Display(Name = "ID do desenvolvedor")]
        public int DeveloperId { get; set; }

        [Required(ErrorMessage = "O ID da publisher é obrigatório.")]
        [Display(Name = "ID da publisher")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "O ID da franquia é obrigatório.")]
        [Display(Name = "ID da franquia")]
        public int FranchiseId { get; set; }

        [Required(ErrorMessage = "O ID da software é obrigatório.")]
        [Display(Name = "ID da plataforma")]
        public int SoftwareId { get; set; }

        [Required(ErrorMessage = "A classificação indicativa é obrigatória.")]
        [Display(Name = "Classificação indicativa")]
        public Rating Rating { get; set; }

        [Required(ErrorMessage = "A informação sobre o multiplayer é obrigatória.")]
        [Display(Name = "Multiplayer")]
        public bool IsMultiplayer { get; set; }

        [Display(Name = "Imagem do jogo")]
        public string? ImagePath { get; set; }

    }
    
}
