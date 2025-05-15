using Exercicios.Models;

namespace Exercicios.Repositorios.Interface
{
  
    
        public interface IUsuario
        {
            Task<List<Usuario>> BuscarTodos();
            Task<Usuario> BuscarPorId(int id);
            Task<Usuario> Adicionar(Usuario usuario);
            Task<Usuario> Atualizar(Usuario usuario, int id);
            Task<bool> Apagar(int id);
        }

    
}
