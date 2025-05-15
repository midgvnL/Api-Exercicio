using Exercicios.Models;

namespace Exercicios.Repositorios.Interface
{
    public interface IProduto
    {
        Task<List<Produtos>> BuscarTodos();
        Task<Produtos> BuscarPorId(int id);
        Task<Produtos> Adicionar(Produtos produto);
        Task<Produtos> Atualizar(Produtos produto, int id);
        Task<bool> Apagar(int id);
    }

}
