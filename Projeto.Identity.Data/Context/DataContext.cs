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

            modelBuilder.Entity<PerfilPermissao>(entity =>
            {
                entity.HasIndex(f => new { f.SistemaId, f.PerfilId, f.PermissaoId })
                      .HasDatabaseName("IDX_SistemaId_PerfilId_PermissaoId")
                      .IsUnique();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasIndex(p => p.ChaveAutorizacao).IsUnique();
            });

            modelBuilder.Entity<Sistema>(entity =>
            {
                entity.HasIndex(p => p.Nome).IsUnique();
            });

            //Criar Usuário Administrador
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
               Id = Guid.Parse("91a19d9a-f4c3-4ebf-9de0-f2eaef912419"),
               Nome = "Administrador",
               Email = "adminSystem33@gmail.com",
               Senha = "AQAAAAIAAYagAAAAEGZMezxOyRmyPezB01hbD6ZLmtKezSljyncwfdzovX7GhkZqyn4qYMc21qUO8X+0lw=="

            });

            //Criar Permissao

            modelBuilder.Entity<Permissao>().HasData(
                new Permissao
                {
                   Id = Guid.Parse("6379def6-d59a-4177-8449-509bd590beca"),
                    Descricao = "Cadastrar Perfil",
                    ChaveAutorizacao = "CadastrarPerfil",
                },
                new Permissao
                {
                   Id = Guid.Parse("13c017c3-b8a2-4534-bf6d-253c11216ad5"),
                    Descricao = "Editar Perfil",
                    ChaveAutorizacao = "EditarPerfil",
                },
                new Permissao
                {
                   Id = Guid.Parse("971b0c25-b4d2-4f6a-b053-0bd06aa7cb10"),
                    Descricao = "Excluir Perfil",
                    ChaveAutorizacao = "ExcluirPerfil",
                },
                new Permissao
                {
                   Id = Guid.Parse("86991fc1-2ef8-4130-8fd4-8306c561b88f"),
                    Descricao = "Listar Perfil",
                    ChaveAutorizacao = "ListarPerfil",
                },
                new Permissao
                {
                   Id = Guid.Parse("341cfb71-b67c-40da-ac16-cbc2e33ef1df"),
                    Descricao = "Listar Filtro Perfil",
                    ChaveAutorizacao = "ListarFiltroPerfil",
                },
                new Permissao
                {
                   Id = Guid.Parse("3352ea24-409a-4d15-99fe-f2c813162537"),
                    Descricao = "Obter Por Id Perfil",
                    ChaveAutorizacao = "ObterPorIdPerfil",
                },
                new Permissao
                {
                   Id = Guid.Parse("f8609b69-6362-485d-b61c-a6e93e8ad7e1"),
                    Descricao = "Cadastrar Perfil Permissao",
                    ChaveAutorizacao = "CadastrarPerfilPermissao",
                },
                new Permissao
                {
                   Id = Guid.Parse("81e5c09e-3ec2-465c-94b8-72ce5a810f68"),
                    Descricao = "Excluir Perfil Permissao",
                    ChaveAutorizacao = "ExcluirPerfilPermissao",
                },
                new Permissao
                {
                   Id = Guid.Parse("3e6126c4-d927-4db6-a65f-d123a9baf0f9"),
                    Descricao = "Listar Perfil Permissao",
                    ChaveAutorizacao = "ListarPerfilPermissao",
                },
                new Permissao
                {
                   Id = Guid.Parse("7242b1bd-1bea-4a8d-ab6b-e54e024c919e"),
                    Descricao = "Cadastrar Permissao",
                    ChaveAutorizacao = "CadastrarPermissao",
                },
                new Permissao
                {
                   Id = Guid.Parse("09f6869b-c36a-44d2-99df-c6b47556fb8b"),
                    Descricao = "Editar Permissao",
                    ChaveAutorizacao = "EditarPermissao",
                },
                new Permissao
                {
                   Id = Guid.Parse("e732be1c-dede-4283-884a-08e5bd39e671"),
                    Descricao = "Excluir Permissao",
                    ChaveAutorizacao = "ExcluirPermissao",
                },
                new Permissao
                {
                   Id = Guid.Parse("a9fe837b-1c01-4a0d-9452-e0f7ddca0d43"),
                    Descricao = "Listar Permissao",
                    ChaveAutorizacao = "ListarPermissao",
                },
                 new Permissao
                 {
                     Id = Guid.Parse("8d9afc47-c1ea-4169-a1cc-ca9764f995b2"),
                     Descricao = "Listar Filtro Permissao",
                     ChaveAutorizacao = "ListarFiltroPermissao",
                 },
                new Permissao
                {
                   Id = Guid.Parse("aba4f16b-28d6-41dc-ba69-e047ca6789ef"),
                    Descricao = "Obter Por Id Permissao",
                    ChaveAutorizacao = "ObterPorIdPermissao",
                },
                new Permissao
                {
                   Id = Guid.Parse("295e726d-a499-496a-bbb0-052d5dd2342a"),
                    Descricao = "Cadastrar Sistema",
                    ChaveAutorizacao = "CadastrarSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("7aefa33c-3f72-479b-a2ce-bdd67796772c"),
                    Descricao = "Editar Sistema",
                    ChaveAutorizacao = "EditarSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("722abbe6-0d22-4403-8006-3b128e5197dc"),
                    Descricao = "Excluir Sistema",
                    ChaveAutorizacao = "ExcluirSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("167324b1-e5aa-41ce-b8a8-4d9c33e9839d"),
                    Descricao = "Listar Sistema",
                    ChaveAutorizacao = "ListarSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("d96fc8a0-a114-4a14-81c2-eba4950aa25c"),
                    Descricao = "Listar Filtro Sistema",
                    ChaveAutorizacao = "ListarFiltroSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("ad9d76a4-9970-440f-a948-130b650092ac"),
                    Descricao = "Obter Por Id Sistema",
                    ChaveAutorizacao = "ObterPorIdSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("ace0f930-6c44-4fef-aa8a-5a92a1fc8402"),
                    Descricao = "Listar Usuario Perfil Sistema",
                    ChaveAutorizacao = "ListarUsuarioPerfilSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("cf770f57-0819-4002-88ad-3f58aa9b905a"),
                    Descricao = "Excluir Usuario Perfil Sistema",
                    ChaveAutorizacao = "ExcluirUsuarioPerfilSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("713c70a4-3f9a-4d17-a086-e6d6278281fa"),
                    Descricao = "Cadastrar Usuario Perfil Sistema",
                    ChaveAutorizacao = "CadastrarUsuarioPerfilSistema",
                },
                new Permissao
                {
                   Id = Guid.Parse("c06ece55-d006-457c-bc8b-f7a6cf89b157"),
                    Descricao = "Cadastrar Usuario",
                    ChaveAutorizacao = "CadastrarUsuario",
                },
                new Permissao
                {
                   Id = Guid.Parse("648717f2-97d3-42b2-8242-a2dba4d43d4d"),
                    Descricao = "Editar Usuario",
                    ChaveAutorizacao = "Editar Usuario",
                },
                new Permissao
                {
                   Id = Guid.Parse("b6168204-00d8-460c-8185-866c2fd993a4"),
                    Descricao = "Excluir Usuario",
                    ChaveAutorizacao = "ExcluirUsuario",
                },
                new Permissao
                {
                   Id = Guid.Parse("42610841-0f94-4130-bd22-5180344e2a14"),
                    Descricao = "Listar Usuario",
                    ChaveAutorizacao = "ListarUsuario",
                },
                new Permissao
                {
                   Id = Guid.Parse("6fecb76a-e5fe-4c04-8db5-71fbc5c87d9e"),
                    Descricao = "Listar Filtro Usuario",
                    ChaveAutorizacao = "ListarFiltroUsuario",
                },
                new Permissao
                {
                   Id = Guid.Parse("e7064c92-3cac-4dbc-811d-f5bc80a2acef"),
                    Descricao = "Obter Por Id Usuario",
                    ChaveAutorizacao = "ObterPorIdUsuario",
                }
            );

            //Criar Sistema
            modelBuilder.Entity<Sistema>().HasData(new Sistema
            {
                Id = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                Nome = "Plataforma de Gerenciamento de Acesso Multissistema",
                Versao = "Versão 1.0"
            });

            //Criar Perfil
            modelBuilder.Entity<Perfil>().HasData(new Perfil
            {
                Id = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                Nome = "Administrador",
                SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
            });

            modelBuilder.Entity<PerfilPermissao>().HasData(
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("1e8ace90-b253-44bb-ac04-cdf769f9a13f"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("6379def6-d59a-4177-8449-509bd590beca")
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("7b8f482d-98e5-4fc5-be55-0645e22ea8e0"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("13c017c3-b8a2-4534-bf6d-253c11216ad5"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("59af7ee6-24c6-45a9-9a00-611a77d03584"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("971b0c25-b4d2-4f6a-b053-0bd06aa7cb10"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("4a089131-0f56-42bd-b1a1-879c84eac049"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("86991fc1-2ef8-4130-8fd4-8306c561b88f"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("281de7cc-5522-45ea-a5f2-17ab372e20b6"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("341cfb71-b67c-40da-ac16-cbc2e33ef1df"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("cf442999-2f9a-4e64-8e71-163897554a39"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("3352ea24-409a-4d15-99fe-f2c813162537"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("283238fa-f134-44bb-a825-96db518a33ab"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("f8609b69-6362-485d-b61c-a6e93e8ad7e1"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("2dcc2913-182e-4dc4-8c14-7163865aa117"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("81e5c09e-3ec2-465c-94b8-72ce5a810f68"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("a8fb92fc-29ba-499c-b93a-3645583575e8"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("3e6126c4-d927-4db6-a65f-d123a9baf0f9"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("fb94adc1-767f-4f11-a8a9-a90084a153d0"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("7242b1bd-1bea-4a8d-ab6b-e54e024c919e"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("9af4791d-b572-4cd4-aeba-cda85ae55154"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("09f6869b-c36a-44d2-99df-c6b47556fb8b"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("92b99cc0-9d43-46d0-a079-8fe3358979f7"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("e732be1c-dede-4283-884a-08e5bd39e671"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("04fd5046-33ac-46ed-946e-118872f2c3ee"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("a9fe837b-1c01-4a0d-9452-e0f7ddca0d43"),
                    },
                     new PerfilPermissao
                     {
                         IdPerfilPermissao = Guid.Parse("5fc5e2c7-50a0-45a4-ab30-3af38599a20d"),
                         PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                         SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                         PermissaoId = Guid.Parse("8d9afc47-c1ea-4169-a1cc-ca9764f995b2"),
                     },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("77cfc277-b1ac-49c1-aa58-2f351cd70c0d"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("aba4f16b-28d6-41dc-ba69-e047ca6789ef"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("c2920dfd-6bcd-4c07-b52a-7126ef15b126"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("295e726d-a499-496a-bbb0-052d5dd2342a"),
                    }
                    ,
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("4fd68888-46a3-4356-ad2b-866104fcde07"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("7aefa33c-3f72-479b-a2ce-bdd67796772c"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("28122c68-fe1e-423d-b197-93d8dcc07894"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("722abbe6-0d22-4403-8006-3b128e5197dc"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("e85b112c-ba6b-4659-af80-acb12e3fc4c1"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("167324b1-e5aa-41ce-b8a8-4d9c33e9839d"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("208488a9-d262-48f3-a31f-ec68e12148d8"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("d96fc8a0-a114-4a14-81c2-eba4950aa25c"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("33e3468a-d90b-44ec-9fc7-fbd4fdd297fb"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("ad9d76a4-9970-440f-a948-130b650092ac"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("dd5675da-3c41-4a34-b008-a9192012beb8"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("ace0f930-6c44-4fef-aa8a-5a92a1fc8402"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("039439cc-98e7-41dd-bafa-cb5482b56685"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("cf770f57-0819-4002-88ad-3f58aa9b905a"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("25befaa8-0fe1-4523-b109-753cd0f51a71"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("713c70a4-3f9a-4d17-a086-e6d6278281fa"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("693fb084-5389-4d76-b864-74b50448e52c"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("c06ece55-d006-457c-bc8b-f7a6cf89b157"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("89c77bed-8aac-454e-8d75-3aee0e25880d"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("648717f2-97d3-42b2-8242-a2dba4d43d4d"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("6b98ed13-1d92-4124-b5b9-a27662de861f"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("b6168204-00d8-460c-8185-866c2fd993a4"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("585fc39f-3c00-4c9d-a94d-472046a28b03"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("42610841-0f94-4130-bd22-5180344e2a14"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("e1f2c33d-d5c2-4383-9c1c-bf3d633af711"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("6fecb76a-e5fe-4c04-8db5-71fbc5c87d9e"),
                    },
                    new PerfilPermissao
                    {
                        IdPerfilPermissao = Guid.Parse("8cf6fb22-4d86-4cf8-aac3-903d3045b2f7"),
                        PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                        SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                        PermissaoId = Guid.Parse("e7064c92-3cac-4dbc-811d-f5bc80a2acef"),
                    }
                    );

            modelBuilder.Entity<UsuarioPerfilSistema>().HasData(new UsuarioPerfilSistema
            {
                IdUsuarioPerfilSistema = Guid.Parse("2c05440a-da63-4d52-9479-5599be9953e3"),
                SistemaId = Guid.Parse("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"),
                PerfilId = Guid.Parse("e6d4582c-cce8-45c4-a633-08cae8d80aef"),
                UsuarioId = Guid.Parse("91a19d9a-f4c3-4ebf-9de0-f2eaef912419")
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