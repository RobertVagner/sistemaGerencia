using Microsoft.EntityFrameworkCore;
using sistemaGerencia.Data;
using sistemaGerencia.Models;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia.Repositorios
{
    public class PermissaoRepositorio : IPermissaoRepositorio
    {
        private readonly SistemaGerenciamentoDBContext _dbContext;
        public PermissaoRepositorio(SistemaGerenciamentoDBContext sistemaGerenciamentoDBContext)
        {
            _dbContext = sistemaGerenciamentoDBContext;
        }

        public async Task<PermissaoModel> AdicionarPermissao(PermissaoModel permissao)
        {
            await _dbContext.permissao.AddAsync(permissao);
            await _dbContext.SaveChangesAsync();

            return permissao;
        }

        public async Task<PermissaoModel> AtualizarPermissao(PermissaoModel permissao, int id)
        {
            PermissaoModel userPorId = await BuscarPorId(id);

            if (userPorId == null)
            {
                throw new Exception($"Permissão para o ID: {id} não foi encontrado!");
            }

            userPorId.NomePermissão = permissao.NomePermissão;
            userPorId.DescricaoPermissao = permissao.DescricaoPermissao;

            _dbContext.permissao.Update(userPorId);
            await _dbContext.SaveChangesAsync();

            return userPorId;
        }

        public async Task<PermissaoModel> BuscarPorId(int id)
        {
            return await _dbContext.permissao.FirstOrDefaultAsync(x => x.IdPermissao == id);
        }

        public async Task<List<PermissaoModel>> BuscarTodosPermissao()
        {
            return await _dbContext.permissao.ToListAsync();
        }

        public async Task<bool> ExcluirPermissao(int id)
        {
            PermissaoModel userPorId = await BuscarPorId(id);

            if (userPorId == null)
            {
                throw new Exception($"Permissão para o ID: {id} não foi encontrado!");
            }

            _dbContext.permissao.Remove(userPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
