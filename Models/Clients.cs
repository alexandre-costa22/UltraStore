using System.ComponentModel.DataAnnotations;

namespace UltraStore.Models
{
    public class Clients
    {
        //public int Id { get; set; }
        //[Required]
        //[Display(Name = "Nome do Cliente")]
        //[StringLength(30, ErrorMessage = "O nome deve ter no máximo 50 characteres")]
        //public string Name { get; set; }
        //[EmailAddress(ErrorMessage = "E-mail Inválido")]
        //public string Email { get; set; }
        //[Display(Name = "Birth Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime BirthDate { get; set; }
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:F2}")]
        //public Decimal AmoutSpent { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
