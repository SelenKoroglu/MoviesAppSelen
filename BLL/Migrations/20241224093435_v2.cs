using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesGenres_Genres_GenreId1",
                table: "MoviesGenres");

            migrationBuilder.DropIndex(
                name: "IX_MoviesGenres_GenreId1",
                table: "MoviesGenres");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "MoviesGenres");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "MoviesGenres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesGenres_GenreId",
                table: "MoviesGenres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesGenres_Genres_GenreId",
                table: "MoviesGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesGenres_Genres_GenreId",
                table: "MoviesGenres");

            migrationBuilder.DropIndex(
                name: "IX_MoviesGenres_GenreId",
                table: "MoviesGenres");

            migrationBuilder.AlterColumn<string>(
                name: "GenreId",
                table: "MoviesGenres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GenreId1",
                table: "MoviesGenres",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesGenres_GenreId1",
                table: "MoviesGenres",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesGenres_Genres_GenreId1",
                table: "MoviesGenres",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
