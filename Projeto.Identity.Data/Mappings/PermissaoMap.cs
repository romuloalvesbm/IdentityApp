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
    public class PermissaoMap : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("Permissao");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.ChaveAutorizacao)
                .HasColumnName("ChaveAutorizacao")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
