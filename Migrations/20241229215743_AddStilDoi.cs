using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_Galchis_Cristian.Migrations
{
    /// <inheritdoc />
    public partial class AddStilDoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stil",
                table: "Obiectiv");

            migrationBuilder.AddColumn<int>(
                name: "StilID",
                table: "Obiectiv",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Stil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
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
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AddColumn<string>(
                name: "Stil",
                table: "Obiectiv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
