using Exercicios.Data;
using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Repositorios
{
    public class RPedidos : IPedido
    {
        private readonly SistemaPedidoDbcontext _dbContext;

        public RPedidos(SistemaPedidoDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pedido> Adicionar(Pedido pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            var pedido = await BuscarPorId(id);
            if (pedido == null)
                throw new Exception($"Pedido com ID: {id} não encontrado.");

            _dbContext.Pedidos.Remove(pedido);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Pedido> Atualizar(Pedido pedido, int id)
        {
            var pedidoDb = await BuscarPorId(id);
            if (pedidoDb == null)
                throw new Exception($"Pedido com ID: {id} não encontrado.");

            pedidoDb.UId = pedido.UId;
            pedidoDb.Endereco= pedido.Endereco;
            pedidoDb.Status = pedido.Status;
            pedidoDb.MetodoPagamento = pedido.MetodoPagamento;

            _dbContext.Pedidos.Update(pedidoDb);
            await _dbContext.SaveChangesAsync();
            return pedidoDb;
        }

        public async Task<Pedido> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(p => p.UId == id);
        }

        public async Task<List<Pedido>> BuscarTodos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }
    }


}
