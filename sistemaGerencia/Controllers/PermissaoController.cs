using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissaoController : ControllerBase
    {
        private readonly IPermissaoRepositorio _permissaoRepositorio;
        public PermissaoController(IPermissaoRepositorio permissaoRepositorio)
        {
            _permissaoRepositorio = permissaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PermissaoModel>>> BuscarTodosPermissao()
        {
            List<PermissaoModel> permisaao = await _permissaoRepositorio.BuscarTodosPermissao();
            return Ok(permisaao);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissaoModel>> BuscarPorId(int id)
        {
            PermissaoModel permisaao = await _permissaoRepositorio.BuscarPorId(id);
            return Ok(permisaao);
        }

        [HttpPost]
        public async Task<ActionResult<PermissaoModel>> AdicionarPermissao([FromBody] PermissaoModel permissaoModel)
        {
            PermissaoModel permisaao = await _permissaoRepositorio.AdicionarPermissao(permissaoModel);
            return Ok(permisaao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PermissaoModel>> AtualizarPermissao([FromBody] PermissaoModel permissaoModel, int id)
        {
            permissaoModel.IdPermissao = id;
            PermissaoModel permisaao = await _permissaoRepositorio.AtualizarPermissao(permissaoModel, id);
            return Ok(permisaao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PermissaoModel>> ExcluirPermissao(int id)
        {
            Boolean idUser = await _permissaoRepositorio.ExcluirPermissao(id);
            return Ok(idUser);
        }
    }
}
