using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTptInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxOfficeRevenue",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "NetworkFirstAiredOn",
                table: "MotionPictures");

            migrationBuilder.CreateTable(
                name: "CinemaMovies",
                columns: table => new
                {
                    ItemKey = table.Column<int>(type: "int", nullable: false),
                    BoxOfficeRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovies", x => x.ItemKey);
                    table.ForeignKey(
                        name: "FK_CinemaMovies_MotionPictures_ItemKey",
                        column: x => x.ItemKey,
                        principalTable: "MotionPictures",
                        principalColumn: "ItemKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelevisionMovies",
                columns: table => new
                {
                    ItemKey = table.Column<int>(type: "int", nullable: false),
                    NetworkFirstAiredOn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionMovies", x => x.ItemKey);
                    table.ForeignKey(
                        name: "FK_TelevisionMovies_MotionPictures_ItemKey",
                        column: x => x.ItemKey,
                        principalTable: "MotionPictures",
                        principalColumn: "ItemKey",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaMovies");

            migrationBuilder.DropTable(
                name: "TelevisionMovies");

            migrationBuilder.AddColumn<decimal>(
                name: "BoxOfficeRevenue",
                table: "MotionPictures",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MotionPictures",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NetworkFirstAiredOn",
                table: "MotionPictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
