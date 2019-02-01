using CoffeeMachine.Application.BadgeLastOrders.Commands;
using CoffeeMachine.Application.BadgeLastOrders.Queries;
using CoffeeMachine.Persistence;
using CoffeeMachine.WebUi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoffeeMachine.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoffeeMachineDbContext _context;

        public HomeController(CoffeeMachineDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> OrderCoffee(string BadgeNo)
        {
            if (!ModelState.IsValid)
                return View();

            if (string.IsNullOrWhiteSpace(BadgeNo))

                return RedirectToAction("Index", "Home");
            var rtn = new GetBadgeLastOrderQuery(_context);

            BadgeLastOrderPreviewModel ViewModel = await rtn.GetAsync(BadgeNo);
            ViewModel.BadgeNo = BadgeNo;
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(BadgeLastOrderPreviewModel _Model)
        {
            var rtn = new CreateOrderBadgeLastOrderCommand(_context);
            int x = await rtn.SaveAsync(_Model);

         
            return RedirectToAction("OrderCompleted", "Home");
        }

        public IActionResult OrderCompleted()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}