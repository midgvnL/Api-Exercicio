using Exercicios.Models;

namespace Exercicios.Repositorios.Interface
{
    public interface IProdutosPedidos
    {
        Task<List<PedidoProdutos>> BuscarTodos();
        Task<PedidoProdutos> BuscarPorId(int id);
        Task<PedidoProdutos> Adicionar(PedidoProdutos item);
        Task<PedidoProdutos> Atualizar(PedidoProdutos item, int id);
        Task<bool> Apagar(int id);
    }

}
