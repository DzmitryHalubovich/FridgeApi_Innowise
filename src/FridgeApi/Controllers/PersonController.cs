using Microsoft.AspNetCore.Mvc;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
         private static List<Person> persons = new List<Person>
            {
                new Person { Id = 1, Name = "Max" },
                new Person { Id = 2, Name = "Peter"},
                new Person { Id = 3, Name = "Fred"},
                new Person { Id = 4, Name = "Chester"}
            };

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(persons);
        }
    }
}
