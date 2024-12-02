using System.ComponentModel.DataAnnotations;

namespace LvlUp.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Display(Name = "Comentário")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        [Display(Name = "ID do Cliente")]
        public int ClientId { get; set; }
        [Display(Name = "Cliente")]
        public Client? Client { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e hora de criação da avaliação")]
        public DateTime ReviewedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O jogo é obrigatório.")]
        [Display(Name = "Jogo que está sendo avaliado")]
        public Game Game { get; set; }
    }
}
