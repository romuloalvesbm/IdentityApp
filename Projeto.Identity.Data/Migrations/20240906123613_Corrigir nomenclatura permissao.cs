using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Identity.Data.Migrations
{
    /// <inheritdoc />
    public partial class Corrigirnomenclaturapermissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("648717f2-97d3-42b2-8242-a2dba4d43d4d"),
                column: "ChaveAutorizacao",
                value: "EditarUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("648717f2-97d3-42b2-8242-a2dba4d43d4d"),
                column: "ChaveAutorizacao",
                value: "Editar Usuario");
        }
    }
}
