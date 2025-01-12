using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_Galchis_Cristian.Migrations
{
    /// <inheritdoc />
    public partial class AdStilOb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StilID",
                table: "Obiectiv",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stil", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obiectiv_StilID",
                table: "Obiectiv",
                column: "StilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obiectiv_Stil_StilID",
                table: "Obiectiv",
                column: "StilID",
                principalTable: "Stil",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obiectiv_Stil_StilID",
                table: "Obiectiv");

            migrationBuilder.DropTable(
                name: "Stil");

            migrationBuilder.DropIndex(
                name: "IX_Obiectiv_StilID",
                table: "Obiectiv");

            migrationBuilder.DropColumn(
                name: "StilID",
                table: "Obiectiv");
        }
    }
}
