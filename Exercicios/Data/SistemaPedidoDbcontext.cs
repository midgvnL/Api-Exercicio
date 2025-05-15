using Exercicios.Data.Map;
using Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Data
{
    public class SistemaPedidoDbcontext : DbContext
    {
        public SistemaPedidoDbcontext(DbContextOptions<SistemaPedidoDbcontext> options)
            : base(options)
        { }
          public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<PedidoProdutos> PedidoProdutos { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MCategoria());
            modelBuilder.ApplyConfiguration(new MProdutos());
            modelBuilder.ApplyConfiguration(new MUsuario());
            modelBuilder.ApplyConfiguration(new MProdutosPedidos());
            modelBuilder.ApplyConfiguration(new MPedidos());
        }
    }
}

