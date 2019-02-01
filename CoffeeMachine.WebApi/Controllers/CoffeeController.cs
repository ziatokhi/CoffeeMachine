using CoffeeMachine.Application.BadgeLastOrders.Queries;
using CoffeeMachine.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoffeeMachine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeMachineDbContext _context;

        public CoffeeController(CoffeeMachineDbContext context)
        {
            _context = context;
        }

        // GET: api/Coffee
        [HttpGet]
        //public IEnumerable<BadgeLastOrderPreviewModel> Get()
        //{
        //    return
        //}

        // GET: api/Coffee/5
        [HttpGet("{BadgeNo}", Name = "Get")]
        public async Task<BadgeLastOrderPreviewModel> GetAsync(string BadgeNo)
        {
            var rtn = new GetBadgeLastOrderQuery(_context);

            return await rtn.GetAsync(BadgeNo);
        }

        // POST: api/Coffee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Coffee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}