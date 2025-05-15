using Exercicios.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Data.Map
{
    public class MProdutos : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasMaxLength(255);

            builder.Property(x => x.PrecoUnitario)
                   .HasColumnType("decimal(10,2)");

           
        }
    }
}
