using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PimEstoque.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarMovimentacaoEnderecoTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Movimentacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Movimentacoes");
        }
    }
}
