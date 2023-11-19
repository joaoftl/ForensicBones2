using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForensicBones2.Migrations
{
    public partial class M03AddTableInventarioEsqueleto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventariosEsqueleto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatorioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventariosEsqueleto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventariosEsqueleto_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventariosEsqueleto_RelatorioId",
                table: "InventariosEsqueleto",
                column: "RelatorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventariosEsqueleto");
        }
    }
}
