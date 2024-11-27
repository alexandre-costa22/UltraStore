using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraStore.Data;
using UltraStore.Models;

namespace UltraStore.Controllers
{
    public class CartController : Controller
    {
        private readonly UltraStoreContext _context;

        public CartController(UltraStoreContext context)
        {
            _context = context;
        }

        // Adicionar ao carrinho
        public IActionResult AddToCart(int gameId, int quantity)
        {
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;

            var cart = GetCart(userId); // Método que busca o carrinho do usuário (ou cria um novo)

            var game = _context.Game.Find(gameId);
            var cartItem = cart.Items.FirstOrDefault(item => item.GameId == gameId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity; // Atualiza a quantidade
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    GameId = gameId,
                    Quantity = quantity,
                    Cart = cart
                });
            }

            _context.SaveChanges();

            return RedirectToAction("Index"); // Redireciona para a página do carrinho
        }

        // Método para buscar o carrinho (criar novo se necessário)
        private Cart GetCart(string userId)
        {
            if (userId == null)
            {
                // Lógica para carrinho de visitante (sessão)
                return new Cart { Items = new List<CartItem>() }; // Simples exemplo, você pode usar sessão aqui
            }

            var cart = _context.Cart.Include(c => c.Items)
                                     .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId, Items = new List<CartItem>() };
                _context.Cart.Add(cart);
                _context.SaveChanges();
            }

            return cart;
        }
    }

}
