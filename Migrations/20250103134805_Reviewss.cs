using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_Galchis_Cristian.Migrations
{
    /// <inheritdoc />
    public partial class Reviewss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzie_Obiectiv_ObiectivID",
                table: "Recenzie");

            migrationBuilder.AlterColumn<int>(
                name: "ObiectivID",
                table: "Recenzie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Continut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ObiectivID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_Obiectiv_ObiectivID",
                        column: x => x.ObiectivID,
                        principalTable: "Obiectiv",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ObiectivID",
                table: "Review",
                column: "ObiectivID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzie_Obiectiv_ObiectivID",
                table: "Recenzie",
                column: "ObiectivID",
                principalTable: "Obiectiv",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzie_Obiectiv_ObiectivID",
                table: "Recenzie");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "ObiectivID",
                table: "Recenzie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzie_Obiectiv_ObiectivID",
                table: "Recenzie",
                column: "ObiectivID",
                principalTable: "Obiectiv",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
