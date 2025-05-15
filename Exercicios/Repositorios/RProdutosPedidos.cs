using Exercicios.Data;
using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Repositorios
{
    public class RProdutosPedidos : IProdutosPedidos
    {
        private readonly SistemaPedidoDbcontext _dbContext;

        public RProdutosPedidos(SistemaPedidoDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidoProdutos> Adicionar(PedidoProdutos item)
        {
            await _dbContext.PedidoProdutos.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Apagar(int id)
        {
            var item = await BuscarPorId(id);
            if (item == null)
                throw new Exception($"Item com ID: {id} não encontrado.");

            _dbContext.PedidoProdutos.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoProdutos> Atualizar(PedidoProdutos item, int id)
        {
            var itemDb = await BuscarPorId(id);
            if (itemDb == null)
                throw new Exception($"Item com ID: {id} não encontrado.");

            itemDb.PedidoId = item.PedidoId;
            itemDb.ProdutoId = item.ProdutoId;
            itemDb.Quantidade = item.Quantidade;
            itemDb.PrecoUnitario = item.PrecoUnitario;

            _dbContext.PedidoProdutos.Update(itemDb);
            await _dbContext.SaveChangesAsync();
            return itemDb;
        }

        public async Task<PedidoProdutos> BuscarPorId(int id)
        {
            return await _dbContext.PedidoProdutos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PedidoProdutos>> BuscarTodos()
        {
            return await _dbContext.PedidoProdutos.ToListAsync();
        }
    }

}
