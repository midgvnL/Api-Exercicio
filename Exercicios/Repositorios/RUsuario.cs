using Exercicios.Data;
using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Repositorios
{
    public class RUsuario : IUsuario
    {
        private readonly SistemaPedidoDbcontext _dbContext;

        public RUsuario(SistemaPedidoDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuario = await BuscarPorId(id);
            if (usuario == null)
                throw new Exception($"Usuário com ID: {id} não encontrado.");

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            var usuarioDb = await BuscarPorId(id);
            if (usuarioDb == null)
                throw new Exception($"Usuário com ID: {id} não encontrado.");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.DataNascimento = usuario.DataNascimento;

            _dbContext.Usuarios.Update(usuarioDb);
            await _dbContext.SaveChangesAsync();
            return usuarioDb;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.UId == id);
        }

        public async Task<List<Usuario>> BuscarTodos()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

    }
}
    

