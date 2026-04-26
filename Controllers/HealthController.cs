using Microsoft.AspNetCore.Mvc;

namespace Majnuntol.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    // GET: api/health
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "Healthy",
            App = "Majnuntol Agro Marketplace",
            Version = "1.0.0",
            Time = DateTime.UtcNow
        });
    }
}
