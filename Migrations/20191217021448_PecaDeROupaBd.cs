using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaDS2Denner.Migrations
{
    public partial class PecaDeROupaBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PecaDeRoupa",
                columns: table => new
                {
                    PecaDeRoupaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeRoupa = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecaDeRoupa", x => x.PecaDeRoupaId);
                });

            migrationBuilder.CreateTable(
                name: "Confeccao",
                columns: table => new
                {
                    ConfeccaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PecaDeRoupaId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confeccao", x => x.ConfeccaoId);
                    table.ForeignKey(
                        name: "FK_Confeccao_PecaDeRoupa_PecaDeRoupaId",
                        column: x => x.PecaDeRoupaId,
                        principalTable: "PecaDeRoupa",
                        principalColumn: "PecaDeRoupaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confeccao_PecaDeRoupaId",
                table: "Confeccao",
                column: "PecaDeRoupaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confeccao");

            migrationBuilder.DropTable(
                name: "PecaDeRoupa");
        }
    }
}
