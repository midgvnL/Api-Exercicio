using Exercicios.Data;
using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Repositorios
{
    public class RCategoria : ICategoria
    {
        private readonly SistemaPedidoDbcontext _dbContext;

        public RCategoria(SistemaPedidoDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Categoria> Adicionar(Categoria categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            var categoria = await BuscarPorId(id);
            if (categoria == null)
                throw new Exception($"Categoria com ID: {id} não encontrada.");

            _dbContext.Categorias.Remove(categoria);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Categoria> Atualizar(Categoria categoria, int id)
        {
            var categoriaDb = await BuscarPorId(id);
            if (categoriaDb == null)
                throw new Exception($"Categoria com ID: {id} não encontrada.");

            categoriaDb.Nome = categoria.Nome;
            categoriaDb.Status = categoria.Status;

            _dbContext.Categorias.Update(categoriaDb);
            await _dbContext.SaveChangesAsync();
            return categoriaDb;
        }

        public async Task<Categoria> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Categoria>> BuscarTodos()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
    }

}
