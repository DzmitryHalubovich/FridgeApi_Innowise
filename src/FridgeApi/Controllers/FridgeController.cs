using FrigeApi.ApplocationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : Controller
    {
        private readonly FridgeDbContext _dbContext;

        public FridgeController(FridgeDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allFridges = _dbContext.Fridges.ToListAsync();

            return Ok(allFridges);
        }
    }
}
