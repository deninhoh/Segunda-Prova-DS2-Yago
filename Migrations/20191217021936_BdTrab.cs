using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaDS2Denner.Migrations
{
    public partial class BdTrab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoDeRoupa",
                table: "PecaDeRoupa",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoDeRoupa",
                table: "PecaDeRoupa",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
