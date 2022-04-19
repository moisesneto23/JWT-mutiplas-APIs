using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuarioToken.Model;
using UsuarioToken.Servico;

namespace UsuarioToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        
        UsuarioModel alguem2 = new UsuarioModel() { id=2, nome="moises", funcao="moises"};
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return Ok(Token.GerarToken(alguem2));
        }

        [HttpGet]
        [Authorize(Roles ="moises")]
        public IActionResult Get()
        {
            return Ok(new { messagem = "authorize fuincionando" });
        }

        [HttpGet("/teste")]
        [AllowAnonymous]
        public IActionResult Teste()
        {
            return Ok(new { message = "rota testada" });
        }
    }
}
