using UltraStore.Models;

namespace UltraStore.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorVenda { get; set; }
        public int ClienteId { get; set; }
        public Client Cliente { get; set; }
        public int VendedorId { get; set; }
        public Seller Vendedor { get; set; }
        public List<Game> Carrinho { get; set; }
            = new List<Game>();
    }
}