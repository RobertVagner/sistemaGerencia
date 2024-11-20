using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaRepositorio _sistemaRepositorio;
        public SistemaController(ISistemaRepositorio sistemaRepositorio)
        {
            _sistemaRepositorio = sistemaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<SistemaModel>>> BuscarTodosSistemas()
        {
            List<SistemaModel> sistemasU = await _sistemaRepositorio.BuscarTodosSistemas();
            return Ok(sistemasU);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SistemaModel>> BuscarPorId(int id)
        {
            SistemaModel sistemaU = await _sistemaRepositorio.BuscarPorId(id);
            return Ok(sistemaU);
        }

        [HttpPost]
        public async Task<ActionResult<SistemaModel>> AdicionarSistema([FromBody] SistemaModel sistemaModel)
        {
            SistemaModel sistema = await _sistemaRepositorio.AdicionarSistemas(sistemaModel);
            return Ok(sistema);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SistemaModel>> AtualizarUsuario([FromBody] SistemaModel sistemaModel, int id)
        {
            sistemaModel.IdSistema = id;
            SistemaModel sistema = await _sistemaRepositorio.AtualizarSistemas(sistemaModel, id);
            return Ok(sistema);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SistemaModel>> ExcluirSistema(int id)
        {
            Boolean idSistema = await _sistemaRepositorio.ExcluirSistemas(id);
            return Ok(idSistema);
        }
    }
}
