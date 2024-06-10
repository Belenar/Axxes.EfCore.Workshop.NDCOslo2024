using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class DoubleNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotionPictures_Genres_GenreId",
                table: "MotionPictures");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "MotionPictures",
                newName: "MainGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_MotionPictures_GenreId",
                table: "MotionPictures",
                newName: "IX_MotionPictures_MainGenreId");

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
                name: "FK_MotionPictures_Genres_MainGenreId",
                table: "MotionPictures",
                column: "MainGenreId",
                principalTable: "Genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MotionPictures_Genres_SecondaryGenreId",
                table: "MotionPictures",
                column: "SecondaryGenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotionPictures_Genres_MainGenreId",
                table: "MotionPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_MotionPictures_Genres_SecondaryGenreId",
                table: "MotionPictures");

            migrationBuilder.DropIndex(
                name: "IX_MotionPictures_SecondaryGenreId",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "SecondaryGenreId",
                table: "MotionPictures");

            migrationBuilder.RenameColumn(
                name: "MainGenreId",
                table: "MotionPictures",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_MotionPictures_MainGenreId",
                table: "MotionPictures",
                newName: "IX_MotionPictures_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotionPictures_Genres_GenreId",
                table: "MotionPictures",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
