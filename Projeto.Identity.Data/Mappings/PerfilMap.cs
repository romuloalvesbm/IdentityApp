using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");

            builder.HasKey(c => new { c.Id, c.SistemaId });

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.SistemaId)
               .HasColumnName("SistemaId")
               .IsRequired();

            builder.Property(c => c.Nome)
               .HasColumnName("Nome")
               .HasMaxLength(150)
               .IsRequired();

            #region Relacionamentos

            builder.HasOne(up => up.Sistema)
           .WithMany(u => u.Perfils)
           .HasForeignKey(up => up.SistemaId)
           .HasPrincipalKey(s => s.Id);

            #endregion

        }
    }
}
