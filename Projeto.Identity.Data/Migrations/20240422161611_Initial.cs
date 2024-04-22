using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto.Identity.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ChaveAutorizacao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SistemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => new { x.Id, x.SistemaId });
                    table.ForeignKey(
                        name: "FK_Perfil_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilxPermissao",
                columns: table => new
                {
                    IdPerfilPermissao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SistemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilxPermissao", x => x.IdPerfilPermissao);
                    table.ForeignKey(
                        name: "FK_PerfilxPermissao_Perfil_PerfilId_SistemaId",
                        columns: x => new { x.PerfilId, x.SistemaId },
                        principalTable: "Perfil",
                        principalColumns: new[] { "Id", "SistemaId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilxPermissao_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioxPerfilxSistema",
                columns: table => new
                {
                    IdUsuarioPerfilSistema = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SistemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioxPerfilxSistema", x => x.IdUsuarioPerfilSistema);
                    table.ForeignKey(
                        name: "FK_UsuarioxPerfilxSistema_Perfil_PerfilId_SistemaId",
                        columns: x => new { x.PerfilId, x.SistemaId },
                        principalTable: "Perfil",
                        principalColumns: new[] { "Id", "SistemaId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioxPerfilxSistema_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissao",
                columns: new[] { "Id", "ChaveAutorizacao", "Descricao" },
                values: new object[,]
                {
                    { new Guid("09f6869b-c36a-44d2-99df-c6b47556fb8b"), "EditarPermissao", "Editar Permissao" },
                    { new Guid("13c017c3-b8a2-4534-bf6d-253c11216ad5"), "EditarPerfil", "Editar Perfil" },
                    { new Guid("167324b1-e5aa-41ce-b8a8-4d9c33e9839d"), "ListarSistema", "Listar Sistema" },
                    { new Guid("295e726d-a499-496a-bbb0-052d5dd2342a"), "CadastrarSistema", "Cadastrar Sistema" },
                    { new Guid("3352ea24-409a-4d15-99fe-f2c813162537"), "ObterPorIdPerfil", "Obter Por Id Perfil" },
                    { new Guid("341cfb71-b67c-40da-ac16-cbc2e33ef1df"), "ListarFiltroPerfil", "Listar Filtro Perfil" },
                    { new Guid("3e6126c4-d927-4db6-a65f-d123a9baf0f9"), "ListarPerfilPermissao", "Listar Perfil Permissao" },
                    { new Guid("42610841-0f94-4130-bd22-5180344e2a14"), "ListarUsuario", "Listar Usuario" },
                    { new Guid("6379def6-d59a-4177-8449-509bd590beca"), "CadastrarPerfil", "Cadastrar Perfil" },
                    { new Guid("648717f2-97d3-42b2-8242-a2dba4d43d4d"), "Editar Usuario", "Editar Usuario" },
                    { new Guid("6fecb76a-e5fe-4c04-8db5-71fbc5c87d9e"), "ListarFiltroUsuario", "Listar Filtro Usuario" },
                    { new Guid("713c70a4-3f9a-4d17-a086-e6d6278281fa"), "CadastrarUsuarioPerfilSistema", "Cadastrar Usuario Perfil Sistema" },
                    { new Guid("722abbe6-0d22-4403-8006-3b128e5197dc"), "ExcluirSistema", "Excluir Sistema" },
                    { new Guid("7242b1bd-1bea-4a8d-ab6b-e54e024c919e"), "CadastrarPermissao", "Cadastrar Permissao" },
                    { new Guid("7aefa33c-3f72-479b-a2ce-bdd67796772c"), "EditarSistema", "Editar Sistema" },
                    { new Guid("81e5c09e-3ec2-465c-94b8-72ce5a810f68"), "ExcluirPerfilPermissao", "Excluir Perfil Permissao" },
                    { new Guid("86991fc1-2ef8-4130-8fd4-8306c561b88f"), "ListarPerfil", "Listar Perfil" },
                    { new Guid("8d9afc47-c1ea-4169-a1cc-ca9764f995b2"), "ListarFiltroPermissao", "Listar Filtro Permissao" },
                    { new Guid("971b0c25-b4d2-4f6a-b053-0bd06aa7cb10"), "ExcluirPerfil", "Excluir Perfil" },
                    { new Guid("a9fe837b-1c01-4a0d-9452-e0f7ddca0d43"), "ListarPermissao", "Listar Permissao" },
                    { new Guid("aba4f16b-28d6-41dc-ba69-e047ca6789ef"), "ObterPorIdPermissao", "Obter Por Id Permissao" },
                    { new Guid("ace0f930-6c44-4fef-aa8a-5a92a1fc8402"), "ListarUsuarioPerfilSistema", "Listar Usuario Perfil Sistema" },
                    { new Guid("ad9d76a4-9970-440f-a948-130b650092ac"), "ObterPorIdSistema", "Obter Por Id Sistema" },
                    { new Guid("b6168204-00d8-460c-8185-866c2fd993a4"), "ExcluirUsuario", "Excluir Usuario" },
                    { new Guid("c06ece55-d006-457c-bc8b-f7a6cf89b157"), "CadastrarUsuario", "Cadastrar Usuario" },
                    { new Guid("cf770f57-0819-4002-88ad-3f58aa9b905a"), "ExcluirUsuarioPerfilSistema", "Excluir Usuario Perfil Sistema" },
                    { new Guid("d96fc8a0-a114-4a14-81c2-eba4950aa25c"), "ListarFiltroSistema", "Listar Filtro Sistema" },
                    { new Guid("e7064c92-3cac-4dbc-811d-f5bc80a2acef"), "ObterPorIdUsuario", "Obter Por Id Usuario" },
                    { new Guid("e732be1c-dede-4283-884a-08e5bd39e671"), "ExcluirPermissao", "Excluir Permissao" },
                    { new Guid("f8609b69-6362-485d-b61c-a6e93e8ad7e1"), "CadastrarPerfilPermissao", "Cadastrar Perfil Permissao" }
                });

            migrationBuilder.InsertData(
                table: "Sistema",
                columns: new[] { "Id", "Nome", "Versao" },
                values: new object[] { new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"), "Plataforma de Gerenciamento de Acesso Multissistema", "Versão 1.0" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataCriacao", "Email", "Nome", "Senha" },
                values: new object[] { new Guid("91a19d9a-f4c3-4ebf-9de0-f2eaef912419"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminSystem33@gmail.com", "Administrador", "AQAAAAIAAYagAAAAEGZMezxOyRmyPezB01hbD6ZLmtKezSljyncwfdzovX7GhkZqyn4qYMc21qUO8X+0lw==" });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "SistemaId", "Nome" },
                values: new object[] { new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"), "Administrador" });

            migrationBuilder.InsertData(
                table: "PerfilxPermissao",
                columns: new[] { "IdPerfilPermissao", "PerfilId", "PermissaoId", "SistemaId" },
                values: new object[,]
                {
                    { new Guid("039439cc-98e7-41dd-bafa-cb5482b56685"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("cf770f57-0819-4002-88ad-3f58aa9b905a"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("04fd5046-33ac-46ed-946e-118872f2c3ee"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("a9fe837b-1c01-4a0d-9452-e0f7ddca0d43"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("1e8ace90-b253-44bb-ac04-cdf769f9a13f"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("6379def6-d59a-4177-8449-509bd590beca"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("208488a9-d262-48f3-a31f-ec68e12148d8"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("d96fc8a0-a114-4a14-81c2-eba4950aa25c"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("25befaa8-0fe1-4523-b109-753cd0f51a71"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("713c70a4-3f9a-4d17-a086-e6d6278281fa"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("28122c68-fe1e-423d-b197-93d8dcc07894"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("722abbe6-0d22-4403-8006-3b128e5197dc"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("281de7cc-5522-45ea-a5f2-17ab372e20b6"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("341cfb71-b67c-40da-ac16-cbc2e33ef1df"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("283238fa-f134-44bb-a825-96db518a33ab"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("f8609b69-6362-485d-b61c-a6e93e8ad7e1"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("2dcc2913-182e-4dc4-8c14-7163865aa117"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("81e5c09e-3ec2-465c-94b8-72ce5a810f68"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("33e3468a-d90b-44ec-9fc7-fbd4fdd297fb"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("ad9d76a4-9970-440f-a948-130b650092ac"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("4a089131-0f56-42bd-b1a1-879c84eac049"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("86991fc1-2ef8-4130-8fd4-8306c561b88f"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("4fd68888-46a3-4356-ad2b-866104fcde07"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("7aefa33c-3f72-479b-a2ce-bdd67796772c"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("585fc39f-3c00-4c9d-a94d-472046a28b03"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("42610841-0f94-4130-bd22-5180344e2a14"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("59af7ee6-24c6-45a9-9a00-611a77d03584"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("971b0c25-b4d2-4f6a-b053-0bd06aa7cb10"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("5fc5e2c7-50a0-45a4-ab30-3af38599a20d"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("8d9afc47-c1ea-4169-a1cc-ca9764f995b2"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("693fb084-5389-4d76-b864-74b50448e52c"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("c06ece55-d006-457c-bc8b-f7a6cf89b157"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("6b98ed13-1d92-4124-b5b9-a27662de861f"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("b6168204-00d8-460c-8185-866c2fd993a4"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("77cfc277-b1ac-49c1-aa58-2f351cd70c0d"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("aba4f16b-28d6-41dc-ba69-e047ca6789ef"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("7b8f482d-98e5-4fc5-be55-0645e22ea8e0"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("13c017c3-b8a2-4534-bf6d-253c11216ad5"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("89c77bed-8aac-454e-8d75-3aee0e25880d"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("648717f2-97d3-42b2-8242-a2dba4d43d4d"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("8cf6fb22-4d86-4cf8-aac3-903d3045b2f7"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("e7064c92-3cac-4dbc-811d-f5bc80a2acef"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("92b99cc0-9d43-46d0-a079-8fe3358979f7"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("e732be1c-dede-4283-884a-08e5bd39e671"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("9af4791d-b572-4cd4-aeba-cda85ae55154"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("09f6869b-c36a-44d2-99df-c6b47556fb8b"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("a8fb92fc-29ba-499c-b93a-3645583575e8"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("3e6126c4-d927-4db6-a65f-d123a9baf0f9"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("c2920dfd-6bcd-4c07-b52a-7126ef15b126"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("295e726d-a499-496a-bbb0-052d5dd2342a"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("cf442999-2f9a-4e64-8e71-163897554a39"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("3352ea24-409a-4d15-99fe-f2c813162537"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("dd5675da-3c41-4a34-b008-a9192012beb8"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("ace0f930-6c44-4fef-aa8a-5a92a1fc8402"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("e1f2c33d-d5c2-4383-9c1c-bf3d633af711"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("6fecb76a-e5fe-4c04-8db5-71fbc5c87d9e"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("e85b112c-ba6b-4659-af80-acb12e3fc4c1"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("167324b1-e5aa-41ce-b8a8-4d9c33e9839d"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") },
                    { new Guid("fb94adc1-767f-4f11-a8a9-a90084a153d0"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("7242b1bd-1bea-4a8d-ab6b-e54e024c919e"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") }
                });

            migrationBuilder.InsertData(
                table: "UsuarioxPerfilxSistema",
                columns: new[] { "IdUsuarioPerfilSistema", "PerfilId", "SistemaId", "UsuarioId" },
                values: new object[] { new Guid("2c05440a-da63-4d52-9479-5599be9953e3"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3"), new Guid("91a19d9a-f4c3-4ebf-9de0-f2eaef912419") });

            migrationBuilder.CreateIndex(
                name: "IDX_SistemaId_NomePerfil",
                table: "Perfil",
                columns: new[] { "SistemaId", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_SistemaId_PerfilId_PermissaoId",
                table: "PerfilxPermissao",
                columns: new[] { "SistemaId", "PerfilId", "PermissaoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilxPermissao_PerfilId_SistemaId",
                table: "PerfilxPermissao",
                columns: new[] { "PerfilId", "SistemaId" });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilxPermissao_PermissaoId",
                table: "PerfilxPermissao",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_ChaveAutorizacao",
                table: "Permissao",
                column: "ChaveAutorizacao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sistema_Nome",
                table: "Sistema",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_SistemaId_UsuarioId",
                table: "UsuarioxPerfilxSistema",
                columns: new[] { "SistemaId", "UsuarioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioxPerfilxSistema_PerfilId_SistemaId",
                table: "UsuarioxPerfilxSistema",
                columns: new[] { "PerfilId", "SistemaId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioxPerfilxSistema_UsuarioId",
                table: "UsuarioxPerfilxSistema",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilxPermissao");

            migrationBuilder.DropTable(
                name: "UsuarioxPerfilxSistema");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Sistema");
        }
    }
}
