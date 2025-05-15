using Exercicios.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exercicios.Data.Map
{
    public class MUsuario : IEntityTypeConfiguration<Usuario>
    {
            public void Configure(EntityTypeBuilder<Usuario> builder)
            {
                builder.HasKey(x => x.UId);

                builder.Property(x => x.Nome)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(x => x.Email)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(x => x.DataNascimento)
                       .HasColumnType("date");


            }
    }
}
