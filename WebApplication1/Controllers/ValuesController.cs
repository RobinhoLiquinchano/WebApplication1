using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotosController : ControllerBase
    {
        // Ruta para probar: https://tu-url.onrender.com/api/votos
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new
            {
                mensaje = "¡API de Votación funcionando en Render!",
                fecha = DateTime.Now,
                version = ".NET 10"
            });
        }
    }
}
