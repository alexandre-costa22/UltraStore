using System.ComponentModel.DataAnnotations;
using UltraStore.Enums;

namespace UltraStore.Models
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

        [Required(ErrorMessage = "O desenvolvedor é obrigatório.")]
        [Display(Name = "Desenvolvedor")]
        public Developer? Developer { get; set; }

        [Required(ErrorMessage = "A publisher é obrigatória.")]
        [Display(Name = "Publisher")]
        public Publisher? Publisher { get; set; }

        [Required(ErrorMessage = "A franquia é obrigatória.")]
        [Display(Name = "Franquia")]
        public Franchise? Franchise { get; set; }

        [Required(ErrorMessage = "A plataforma é obrigatória.")]
        [Display(Name = "Plataforma")]
        public Software? Platforms { get; set; }

        [Required(ErrorMessage = "O ID do desenvolvedor é obrigatório.")]
        [Display(Name = "ID do desenvolvedor")]
        public int DeveloperId { get; set; }

        [Required(ErrorMessage = "O ID da publisher é obrigatório.")]
        [Display(Name = "ID da publisher")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "O ID da franquia é obrigatório.")]
        [Display(Name = "ID da franquia")]
        public int FranchiseId { get; set; }

        [Required(ErrorMessage = "O ID da plataforma é obrigatório.")]
        [Display(Name = "ID da plataforma")]
        public int PlatformsId { get; set; }

        [Required(ErrorMessage = "A classificação indicativa é obrigatória.")]
        [Display(Name = "Classificação indicativa")]
        public Rating Rating { get; set; }

        // [Display(Name = "Línguas disponíveis")]
        // public List<int> Languages { get; set; } = new List<int>(); TODO

        [Required(ErrorMessage = "A informação sobre o multiplayer é obrigatória.")]
        [Display(Name = "Multiplayer")]
        public bool IsMultiplayer { get; set; }
    }
}
