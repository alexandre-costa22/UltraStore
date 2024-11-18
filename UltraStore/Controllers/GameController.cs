using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraStore.Data;
using UltraStore.Models;
using UltraStore.Models.ViewModels;

namespace UltraStore.Controllers
{
    public class GameController : Controller
    {
        private readonly UltraStoreContext _context;

        public GameController(UltraStoreContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            //List<Seller> sellers = _context.Seller.ToList();
            var games = _context.Game.Include("Game").ToList();

            ////Filtra os vendedores que ganham menos de 10k
            //var trainees = sellers.Where(s => s.Salary <= 10000);

            //Filtra a lista e ordena em ordem CRESCENTE
            //por nome e depois por salario
            var GameName =
                games.OrderBy(s => s.Name);

            return View(GameName);
        }

        public IActionResult Create()
        {
            //Instanciar um SellerFormViewModel
            //Essa instância vai ter 2 propriedades
            //um vendedor e uma lista de departmamentos
            var viewModel = new SellerFormViewModel();
            //carregando os departamentos do banco
            viewModel.Client = _context.Client.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {

            //Testa se foi passado um vendedor
            if (game == null)
            {
                //Retorna página não encontrada
                return NotFound();
            }
            //seller.Department = _context.Department.FirstOrDefault();
            //seller.DepartmentId = seller.Department.Id;

            //Adicionar o objeto vendedor ao banco
            _context.Add(game);
            //Confirma/Persiste as alterações na base de dados
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            //Veifica se foi passado um id como parâmetro
            if (id == null)
            {
                return NotFound();
            }

            Seller game = _context.Seller.Include("Name").FirstOrDefault(x => x.Id == id);

            //Se não localizou um vendedor com esse ID, vai para página de erro
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Game game = _context.Game
                .Include("Name")
                .FirstOrDefault(s => s.Id == id);

            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Game game = _context.Game
                .FirstOrDefault(s => s.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            _context.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult Edit(int id)
        //{
        //    //Verificar se existe um vendedor com o id passado por parâmetro
        //    var game = _context.Game.First(s => s.Id == id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    //Cria uma lista de departamentos
        //    List<Game> departments = _context.Game.ToList();

        //    //Cria uma instância do viewmodel
        //    SellerFormViewModel viewModel = new SellerFormViewModel();
        //    viewModel = ;
        //    //viewModel.Client = departments;

        //    return View(viewModel);
        //}

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            //_context.Seller.Update(seller);
            _context.Update(game);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

//        public IActionResult Report()
//        {
//            //Popular a lista de objetos vendedores,
//            //trazendo as informações
//            //do departamento de cada vendedor
//            //List<Seller> sellers
//            var sellers = _context.Seller.Include("Department").ToList();

//''            ViewData["TotalFolhaPagamento"] = sellers.Sum(s => s.Salary);

//            ViewData["Maior"] = sellers.Max(s => s.Salary);

//            ViewData["Menor"] = sellers.Min(s => s.Salary);

//            ViewData["Media"] = sellers.Average(s => s.Salary);

//            ViewData["Ricos"] = sellers.Count(s => s.Salary >= 30000);

//            return View();
//        }
    }
}
