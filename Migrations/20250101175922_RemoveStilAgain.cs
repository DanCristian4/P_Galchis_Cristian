using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_Galchis_Cristian.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStilAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stil",
                table: "Obiectiv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stil",
                table: "Obiectiv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
