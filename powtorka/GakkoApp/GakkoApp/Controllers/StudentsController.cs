using Microsoft.AspNetCore.Mvc;
namespace GakkoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    public StudentsController()
    {
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok();
    }
}