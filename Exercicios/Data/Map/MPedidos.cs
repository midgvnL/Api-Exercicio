using Exercicios.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Data.Map
{
   
    public class MPedidos : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.UId);

            builder.Property(x => x.Endereco)
                   .IsRequired();

            builder.Property(x => x.Status)
                   .HasConversion<string>();

            builder.Property(x => x.MetodoPagamento)
                   .IsRequired();

           

        }
    }
    
}

