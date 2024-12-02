using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LvlUp.Data;
using LvlUp.Models;

namespace LvlUp.Controllers
{
    public class CartController : Controller
    {
        private readonly LvlUpContext _context;

        public CartController(LvlUpContext context)
        {
            _context = context;
        }

        // Adicionar ao carrinho
        public IActionResult AddToCart(int gameId, int quantity)
        {
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;

            var cart = GetOrCreateCart(userId); // Método que busca o carrinho do usuário (ou cria um novo)

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
        private Cart GetOrCreateCart(string userId)
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

        public IActionResult Index()
        {
            var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            var cart = GetOrCreateCart(userId);

            return View(cart);
        }
    }

}
