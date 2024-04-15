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
    public class UsuarioPerfilSistemaMap : IEntityTypeConfiguration<UsuarioPerfilSistema>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfilSistema> builder)
        {
            builder.ToTable("UsuarioxPerfilxSistema");

            builder.HasKey(c => c.IdUsuarioPerfilSistema);

            builder.Property(c => c.IdUsuarioPerfilSistema)
                .HasColumnName("IdUsuarioPerfilSistema");

            builder.Property(c => c.UsuarioId)
             .HasColumnName("UsuarioId")
             .IsRequired();

            builder.Property(c => c.PerfilId)
               .HasColumnName("PerfilId")
               .IsRequired();

            builder.Property(c => c.SistemaId)
              .HasColumnName("SistemaId")
              .IsRequired();

            #region Relacionamentos

            builder.HasOne(up => up.Usuario)
                   .WithMany(u => u.UsuarioxPerfilxSistemas)
                   .HasForeignKey(up => up.UsuarioId);

            builder.HasOne(up => up.Perfil)
                   .WithMany(u => u.UsuarioxPerfilxSistemas)
                   .HasForeignKey(up => new { up.PerfilId, up.SistemaId });
            //.OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(up => up.Sistema)
            //       .WithMany(u => u.UsuarioxPerfilxSistemas)
            //       .HasForeignKey(up => up.SistemaId);                   

            #endregion
        }
    }
}

