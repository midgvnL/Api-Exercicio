using Exercicios.Models;

namespace Exercicios.Repositorios.Interface
{
    public interface IPedido
    {
        Task<List<Pedido>> BuscarTodos();
        Task<Pedido> BuscarPorId(int id);
        Task<Pedido> Adicionar(Pedido pedido);
        Task<Pedido> Atualizar(Pedido pedido, int id);
        Task<bool> Apagar(int id);
    }

}
