using System.ComponentModel.DataAnnotations;

namespace UltraStore.Models

{
    public class Seller
    {
        //public int Id { get; set; }
        //[Required]
        //[Display(Name = "Nome do Vendedor")]
        //[StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 characteres")]
        //public string Name { get; set; }
        //[EmailAddress(ErrorMessage = "E-mail Inválido")]
        //public string Email { get; set; }
        //[Display(Name = "Birth Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime BirthDate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}
