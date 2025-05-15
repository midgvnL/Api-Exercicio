using Exercicios.Data;
using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Repositorios
{
    public class RProdutos : IProduto
    {
        private readonly SistemaPedidoDbcontext _dbContext;

        public RProdutos(SistemaPedidoDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Produtos> Adicionar(Produtos produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            var produto = await BuscarPorId(id);
            if (produto == null)
                throw new Exception($"Produto com ID: {id} não encontrado.");

            _dbContext.Produtos.Remove(produto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Produtos> Atualizar(Produtos produto, int id)
        {
            var produtoDb = await BuscarPorId(id);
            if (produtoDb == null)
                throw new Exception($"Produto com ID: {id} não encontrado.");

            produtoDb.Nome = produto.Nome;
            produtoDb.Descricao = produto.Descricao;
            produtoDb.PrecoUnitario = produto.PrecoUnitario;
            produtoDb.Id = produto.Id; 

            _dbContext.Produtos.Update(produtoDb);
            await _dbContext.SaveChangesAsync();
            return produtoDb;
        }

        public async Task<Produtos> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync
                (p => p.Id == id);
        }

        public async Task<List<Produtos>> BuscarTodos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
    }

}
