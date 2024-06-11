using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Multipledirectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director_FirstName",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "Director_LastName",
                table: "MotionPictures");

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    MovieItemKey = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => new { x.MovieItemKey, x.Id });
                    table.ForeignKey(
                        name: "FK_Director_MotionPictures_MovieItemKey",
                        column: x => x.MovieItemKey,
                        principalTable: "MotionPictures",
                        principalColumn: "ItemKey",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.AddColumn<string>(
                name: "Director_FirstName",
                table: "MotionPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director_LastName",
                table: "MotionPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
