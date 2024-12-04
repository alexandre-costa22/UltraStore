using LvlUp.Data;
using LvlUp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LvlUp.Controllers
{
    public class CartController : Controller
    {
        private readonly LvlUpContext _context;

        public CartController(LvlUpContext context)
        {
            _context = context;
        }

        // Adiciona um item ao carrinho
        [HttpGet]
        public async Task<IActionResult> AddToCart(int gameId)
        {
            // Verifica o usuário logado
            var userId = User.Identity.Name; // Assumindo que o nome de usuário é o ID. Caso contrário, ajuste conforme necessário.

            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");

            }

            // Encontra o carrinho do usuário ou cria um novo
            var cart = await _context.Cart
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>()
                };
                _context.Cart.Add(cart);
                await _context.SaveChangesAsync();
            }

            // Verifica se o item já existe no carrinho
            var cartItem = cart.Items.FirstOrDefault(item => item.GameId == gameId);

            if (cartItem != null)
            {
                // Se o item já existe no carrinho, aumenta a quantidade
                cartItem.Quantity++;
            }
            else
            {
                // Se o item não existe, adiciona um novo item ao carrinho
                cart.Items.Add(new CartItem
                {
                    GameId = gameId,
                    Quantity = 1
                });
            }

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Redireciona o usuário para a página do carrinho
            return RedirectToAction("Index");
        }

        // Exibe o carrinho
        public IActionResult Index()
        {
            var userId = User.Identity.Name;
            var cart = _context.Cart
                .Include(c => c.Items)
                    .ThenInclude(i => i.Game)
                .FirstOrDefault(c => c.UserId == userId);

            // Garantir que Items nunca seja null
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>() // Inicia Items como uma lista vazia
                };
            }

            return View(cart); // Retorna a view com o carrinho do usuário
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var userId = User.Identity.Name;

            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            // Encontra o carrinho do usuário
            var cart = await _context.Cart
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                // Se o carrinho não existir, redireciona para a página do carrinho
                return RedirectToAction("Index");
            }

            // Encontra o item do carrinho com o cartItemId
            var cartItem = cart.Items.FirstOrDefault(item => item.Id == cartItemId);

            if (cartItem != null)
            {
                // Remove o item do carrinho
                cart.Items.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            // Redireciona para a página do carrinho após a remoção
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
        {
            var userId = User.Identity.Name;

            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            var cart = await _context.Cart
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            var cartItem = cart.Items.FirstOrDefault(item => item.Id == cartItemId);

            if (cartItem != null)
            {
                // Atualiza a quantidade do item no carrinho
                cartItem.Quantity = quantity;
                await _context.SaveChangesAsync();
            }

            return Json(new { success = true });
        }


    }
}
