using UltraStore.Models;

namespace UltraStore.Models
{
    public class Nota
    {
        //public int Id { get; set; }
        //public DateTime DataEmissao { get; set; }
        //public double ValorVenda { get; set; }
        //public int ClienteId { get; set; }
        //public Client Cliente { get; set; }
        //public int VendedorId { get; set; }
        //public Seller Vendedor { get; set; }
        //public List<Game> Carrinho { get; set; }
        //    = new List<Game>();
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ClientId { get; set; }
        public Clients? Clients { get; set; } 
        public int SellerId { get; set; }
        public Seller? Seller { get; set; } 
        public ICollection<Game>? Games { get; set; } 
        public decimal TotalPrice { get; set; }
    }
}