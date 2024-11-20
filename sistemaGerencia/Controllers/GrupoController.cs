using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;
        public GrupoController(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<GrupoModel>>> BuscarTodosGrupo()
        {
            List<GrupoModel> permisaao = await _grupoRepositorio.BuscarTodosGrupos();
            return Ok(permisaao);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoModel>> BuscarPorId(int id)
        {
            GrupoModel permisaao = await _grupoRepositorio.BuscarPorId(id);
            return Ok(permisaao);
        }

        [HttpPost]
        public async Task<ActionResult<GrupoModel>> AdicionarGrupo([FromBody] GrupoModel grupoModel)
        {
            GrupoModel permisaao = await _grupoRepositorio.AdicionarGrupo(grupoModel);
            return Ok(permisaao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GrupoModel>> AtualizarGrupo([FromBody] GrupoModel grupoModel, int id)
        {
            grupoModel.IdGrupo = id;
            GrupoModel permisaao = await _grupoRepositorio.AtualizarGrupo(grupoModel, id);
            return Ok(permisaao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GrupoModel>> ExcluirPermissao(int id)
        {
            Boolean idUser = await _grupoRepositorio.ExcluirGrupo(id);
            return Ok(idUser);
        }
    }
}
