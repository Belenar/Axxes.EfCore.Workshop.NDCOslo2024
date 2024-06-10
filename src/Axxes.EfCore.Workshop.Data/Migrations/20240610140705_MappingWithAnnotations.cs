using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingWithAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Pictures");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Pictures",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Movies");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movies",
                newName: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");
        }
    }
}
