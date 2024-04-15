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
    public class PerfilPermissaoMap : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.ToTable("PerfilxPermissao");

            builder.HasKey(c => c.IdPerfilPermissao);

            builder.Property(c => c.IdPerfilPermissao)
                .HasColumnName("IdPerfilPermissao");

            builder.Property(c => c.PerfilId)
               .HasColumnName("PerfilId")
               .IsRequired();

            builder.Property(c => c.SistemaId)
              .HasColumnName("SistemaId")
              .IsRequired();

            builder.Property(c => c.PermissaoId)
              .HasColumnName("PermissaoId")
              .IsRequired();

            #region Relacionamentos

            builder.HasOne(up => up.Perfil)
                   .WithMany(u => u.PerfilxPermissoes)
                   .HasForeignKey(up => new { up.PerfilId, up.SistemaId });

            builder.HasOne(up => up.Permissao)
                   .WithMany(u => u.PerfilxPermissoes)
                   .HasForeignKey(up => up.PermissaoId);

            #endregion
        }
    }
}

