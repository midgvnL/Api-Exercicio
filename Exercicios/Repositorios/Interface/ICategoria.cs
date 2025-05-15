using Exercicios.Models;

namespace Exercicios.Repositorios.Interface
{
    public interface ICategoria
    {
        Task<List<Categoria>> BuscarTodos();
        Task<Categoria> BuscarPorId(int id);
        Task<Categoria> Adicionar(Categoria categoria);
        Task<Categoria> Atualizar(Categoria categoria, int id);
        Task<bool> Apagar(int id);
    }

}
