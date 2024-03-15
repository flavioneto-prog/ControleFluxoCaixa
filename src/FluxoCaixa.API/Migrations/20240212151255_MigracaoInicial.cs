using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.API.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONTROLE_LANCAMENTO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLancamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipoLancamento = table.Column<string>(type: "varchar(60)", nullable: false),
                    varchar60 = table.Column<string>(name: "varchar(60)", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTROLE_LANCAMENTO", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONTROLE_LANCAMENTO");
        }
    }
}
