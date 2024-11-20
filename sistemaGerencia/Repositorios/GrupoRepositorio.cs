using Microsoft.EntityFrameworkCore;
using sistemaGerencia.Data;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Repositorios
{
    public class GrupoRepositorio : IGrupoRepositorio
    {
        private readonly SistemaGerenciamentoDBContext _dbContext;
        public GrupoRepositorio(SistemaGerenciamentoDBContext sistemaGerenciamentoDBContext)
        {
            _dbContext = sistemaGerenciamentoDBContext;
        }

        public async Task<GrupoModel> AdicionarGrupo(GrupoModel grupo)
        {
            await _dbContext.grupo.AddAsync(grupo);
            await _dbContext.SaveChangesAsync();

            return grupo;
        }

        public async Task<GrupoModel> AtualizarGrupo(GrupoModel grupo, int id)
        {
            GrupoModel userPorId = await BuscarPorId(id);

            if (userPorId == null)
            {
                throw new Exception($"Grupo para o ID: {id} não foi encontrado!");
            }

            userPorId.NomeGrupo = grupo.NomeGrupo;
            userPorId.DescricaoGrupo = grupo.DescricaoGrupo;

            _dbContext.grupo.Update(userPorId);
            await _dbContext.SaveChangesAsync();

            return userPorId;
        }

        public async Task<GrupoModel> BuscarPorId(int id)
        {
            return await _dbContext.grupo.FirstOrDefaultAsync(x => x.IdGrupo == id);
        }

        public async Task<List<GrupoModel>> BuscarTodosGrupos()
        {
            return await _dbContext.grupo.ToListAsync();
        }

        public async Task<bool> ExcluirGrupo(int id)
        {
            GrupoModel userPorId = await BuscarPorId(id);

            if (userPorId == null)
            {
                throw new Exception($"Grupo para o ID: {id} não foi encontrado!");
            }

            _dbContext.grupo.Remove(userPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
