using Microsoft.EntityFrameworkCore;
using sistemaGerencia.Data;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Repositorios
{
    public class SistemaRepositorio : ISistemaRepositorio
    {
        private readonly SistemaGerenciamentoDBContext _dbContext;
        public SistemaRepositorio(SistemaGerenciamentoDBContext sistemaGerenciamentoDBContext)
        {
            _dbContext = sistemaGerenciamentoDBContext;
        }
        public async Task<SistemaModel> BuscarPorId(int id)
        {
            return await _dbContext.sistema.FirstOrDefaultAsync(x => x.IdSistema == id);
        }

        public async Task<List<SistemaModel>> BuscarTodosSistemas()
        {
            return await _dbContext.sistema.ToListAsync();
        }

        public async Task<SistemaModel> AdicionarSistemas(SistemaModel sistemas)
        {
            await _dbContext.sistema.AddAsync(sistemas);
            await _dbContext.SaveChangesAsync();

            return sistemas;
        }

        public async Task<SistemaModel> AtualizarSistemas(SistemaModel sistemas, int id)
        {
            SistemaModel porId = await BuscarPorId(id);

            if (porId == null)
            {
                throw new Exception($"Sistema para o ID: {id} não foi encontrado!");
            }

            porId.NomeSistema = sistemas.NomeSistema;
            porId.DescricaoSistema = sistemas.DescricaoSistema;

            _dbContext.sistema.Update(porId);
            await _dbContext.SaveChangesAsync();

            return porId;
        }

        public async Task<bool> ExcluirSistemas(int id)
        {
            SistemaModel porId = await BuscarPorId(id);

            if (porId == null)
            {
                throw new Exception($"Sistema para o ID: {id} não foi encontrado!");
            }

            _dbContext.sistema.Remove(porId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
