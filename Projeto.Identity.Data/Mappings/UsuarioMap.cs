using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Projeto.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Email)
               .HasColumnName("Email")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(c => c.Senha)
              .HasColumnName("Senha")
              .HasMaxLength(10)
              .IsRequired();

            builder.Property(c => c.DataCriacao)
             .HasColumnName("DataCriacao")
             .IsRequired();
        }
    }
}
