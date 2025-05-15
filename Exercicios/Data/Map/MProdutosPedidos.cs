using Exercicios.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Data.Map
{
    public class MProdutosPedidos : IEntityTypeConfiguration<PedidoProdutos>
    {
            public void Configure(EntityTypeBuilder<PedidoProdutos> builder)
            {
                builder.HasKey(pp => pp.Id);

                builder.Property(pp => pp.Quantidade)
                       .IsRequired();

                builder.Property(pp => pp.PrecoUnitario)
                       .HasColumnType("decimal(10,2)");
            }
        }
}
