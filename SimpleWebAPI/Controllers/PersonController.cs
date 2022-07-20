namespace SimpleWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SimpleWebAPI.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string? query = null)
        {
            var people = new List<Person>()
            {
                new Person() { Id = 1, Name = "Tim" },
                new Person() { Id = 2 }
            };

            return Ok(people.FirstOrDefault(x => x.Name == query));
        }
    }
}
