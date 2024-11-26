using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task <ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuariosU = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuariosU);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuariosU = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuariosU);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.AdicionarUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.IdUsuario = id;
            UsuarioModel usuario = await _usuarioRepositorio.AtualizarUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> ExcluirUsuario(int id)
        {
            Boolean idUser = await _usuarioRepositorio.ExcluirUsuario(id);
            return Ok(idUser);
        }
        [HttpGet("nome/{nomeUsuario}/permissoes")]
        public async Task<ActionResult<List<PermissaoModel>>> ObterPermissoesPorNome(string nomeUsuario)
        {
            var permissoes = await _usuarioRepositorio.BuscarPermissoesPorNome(nomeUsuario);
            if (permissoes == null || !permissoes.Any())
            {
                return NotFound($"Nenhuma permissão encontrada para o usuário com o nome '{nomeUsuario}'.");
            }
            return Ok(permissoes);
        }

    }
}
