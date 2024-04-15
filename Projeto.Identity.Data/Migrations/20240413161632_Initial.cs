using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
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
                    Senha = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IDX_SistemaId_NomePerfil",
                table: "Perfil",
                columns: new[] { "SistemaId", "Nome" },
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
                name: "IX_Permissao_Descricao",
                table: "Permissao",
                column: "Descricao",
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
