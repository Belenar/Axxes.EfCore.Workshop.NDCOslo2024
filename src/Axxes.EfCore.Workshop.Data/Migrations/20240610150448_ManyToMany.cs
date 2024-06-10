using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotionPictures_Genres_SecondaryGenreId",
                table: "MotionPictures");

            migrationBuilder.DropIndex(
                name: "IX_MotionPictures_SecondaryGenreId",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "SecondaryGenreId",
                table: "MotionPictures");

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    SecondaryGenresId = table.Column<int>(type: "int", nullable: false),
                    SecondaryMoviesItemKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.SecondaryGenresId, x.SecondaryMoviesItemKey });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_SecondaryGenresId",
                        column: x => x.SecondaryGenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_MotionPictures_SecondaryMoviesItemKey",
                        column: x => x.SecondaryMoviesItemKey,
                        principalTable: "MotionPictures",
                        principalColumn: "ItemKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_SecondaryMoviesItemKey",
                table: "GenreMovie",
                column: "SecondaryMoviesItemKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.AddColumn<int>(
                name: "SecondaryGenreId",
                table: "MotionPictures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotionPictures_SecondaryGenreId",
                table: "MotionPictures",
                column: "SecondaryGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotionPictures_Genres_SecondaryGenreId",
                table: "MotionPictures",
                column: "SecondaryGenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
