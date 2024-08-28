using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Identity.Data.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacaodados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissao",
                columns: new[] { "Id", "ChaveAutorizacao", "Descricao" },
                values: new object[] { new Guid("cb50c0dd-76e0-4763-b997-5344e5dc84e4"), "ObterPermissaoUsuarioNoSistema", "Obter Permissões do Usuário no Sistema" });

            migrationBuilder.InsertData(
                table: "PerfilxPermissao",
                columns: new[] { "IdPerfilPermissao", "PerfilId", "PermissaoId", "SistemaId" },
                values: new object[] { new Guid("3d1cbee5-1243-4f23-92de-1ab7c3fab496"), new Guid("e6d4582c-cce8-45c4-a633-08cae8d80aef"), new Guid("cb50c0dd-76e0-4763-b997-5344e5dc84e4"), new Guid("6a88cdcc-d445-44d1-8ca3-7dd60ddc1af3") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PerfilxPermissao",
                keyColumn: "IdPerfilPermissao",
                keyValue: new Guid("3d1cbee5-1243-4f23-92de-1ab7c3fab496"));

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("cb50c0dd-76e0-4763-b997-5344e5dc84e4"));
        }
    }
}
