using Microsoft.EntityFrameworkCore;
using Projeto.Identity.Data.Mappings;
using Projeto.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new PerfilPermissaoMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new SistemaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioPerfilSistemaMap());

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasIndex(f => new { f.SistemaId, f.Nome })
                      .HasDatabaseName("IDX_SistemaId_NomePerfil")
                      .IsUnique();
            });

            modelBuilder.Entity<UsuarioPerfilSistema>(entity =>
            {
                entity.HasIndex(f => new { f.SistemaId, f.UsuarioId })
                      .HasDatabaseName("IDX_SistemaId_UsuarioId")
                      .IsUnique();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasIndex(p => p.Descricao).IsUnique();
            });

            modelBuilder.Entity<Sistema>(entity =>
            {
                entity.HasIndex(p => p.Nome).IsUnique();
            });
        }

        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<PerfilPermissao> PerfilPermissoes { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Sistema> Sistemas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfilSistema> UsuarioPerfilSistemas { get; set; }
    }
}