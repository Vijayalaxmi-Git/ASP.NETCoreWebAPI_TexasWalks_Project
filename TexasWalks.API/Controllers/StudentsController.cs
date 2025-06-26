using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TexasWalks.API.Controllers
{
    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "John", "James", "Mark", "Emily", "David" };
            return Ok(studentNames);

        }
    }
}
