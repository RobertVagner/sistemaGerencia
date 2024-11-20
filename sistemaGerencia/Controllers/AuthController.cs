using Microsoft.AspNetCore.Mvc;
using sistemaGerencia.Repositorios;
using sistemaGerencia.Repositorios.Interfaces;
using sistemaGerencia.Services;

namespace sistemaGerencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AuthController(TokenService tokenService, IUsuarioRepositorio usuarioRepositorio)
        {
            _tokenService = tokenService;
            _usuarioRepositorio = usuarioRepositorio;
        }

        // Endpoint para login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var usuario = await _usuarioRepositorio.BuscarPorCredenciais(request.Username);

            if (usuario == null)
            {
                return Unauthorized("Usuário não encontrado.");
            }

            var token = _tokenService.GenerateToken(usuario.IdUsuario.ToString(), "User");

            return Ok(new { Token = token });
        }

        // Modelo de solicitação para login
        public class LoginRequest
        {
            public string Username { get; set; }
        }
    }
}
