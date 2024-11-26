﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraStore.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Display(Name = "Data da Compra")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "O CPF do cliente é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter apenas números.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        public int ClientId { get; set; }
        public Client? Clients { get; set; }

        [Required(ErrorMessage = "O Vendedor é obrigatório.")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

        [Required(ErrorMessage = "Os jogos são obrigatórios.")]
        public ICollection<Game>? Games { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço total deve ser maior que zero.")]
        [Display(Name = "Preço Total")]
        public decimal TotalPrice { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Hora de Criação")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}