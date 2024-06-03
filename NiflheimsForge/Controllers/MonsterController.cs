using Microsoft.AspNetCore.Mvc;

namespace NiflheimsForge.Controllers;

[ApiController]
public class MonsterController : ControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}
