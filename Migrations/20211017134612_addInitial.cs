using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoviesAPI.Migrations
{
    public partial class addInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "moviesContext",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieName = table.Column<string>(type: "text", nullable: true),
                    ReleaseDate = table.Column<string>(type: "text", nullable: true),
                    MovieBio = table.Column<string>(type: "text", nullable: true),
                    Actors = table.Column<string[]>(type: "text[]", nullable: true),
                    Producer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moviesContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "actorsContext",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActorName = table.Column<string>(type: "text", nullable: true),
                    MoviesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actorsContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_actorsContext_moviesContext_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "moviesContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "producerContext",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProducerName = table.Column<string>(type: "text", nullable: true),
                    MoviesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producerContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producerContext_moviesContext_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "moviesContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "actorsContext",
                columns: new[] { "Id", "ActorName", "MoviesId" },
                values: new object[,]
                {
                    { 1, "Tom Hanks", null },
                    { 2, "Johnny Depp", null },
                    { 3, "Morgan Freeman", null },
                    { 4, "Clancy Brown", null },
                    { 5, "Mark Ruffalo", null },
                    { 6, "Jim Carrey", null }
                });

            migrationBuilder.InsertData(
                table: "moviesContext",
                columns: new[] { "Id", "Actors", "MovieBio", "MovieName", "Producer", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, new[] { "3", "4" }, "In 1947 Portland, Maine, banker Andy Dufresne is convicted of murdering his wife and her lover and is sentenced to two consecutive life sentences at the Shawshank State Prison.", "The Shawshank Redemption", "3", "1994-09-22" },
                    { 2, new[] { "3", "5" }, "Now You See Me is a 2013 American heist thriller film directed by Louis Leterrier from a screenplay by Ed Solomon, Boaz Yakin, and Edward Ricourt and a story by Yakin and Ricourt. It is the first installment in the Now You See Me series. The film features an ensemble cast of Jesse Eisenberg, Mark Ruffalo, Woody Harrelson, Isla Fisher, Dave Franco, Mélanie Laurent, Michael Caine, and Morgan Freeman. ", "Now You See Me", "4", "2013-05-31" },
                    { 3, new[] { "3", "6" }, "A military dog that helped American Marines in Afghanistan returns to the United States and is adopted by his handler's family after suffering a traumatic experience.", "Max", "4", "2015-06-26" }
                });

            migrationBuilder.InsertData(
                table: "producerContext",
                columns: new[] { "Id", "MoviesId", "ProducerName" },
                values: new object[,]
                {
                    { 1, null, "David Heyman" },
                    { 2, null, "Quentin Tarantino" },
                    { 3, null, "Niki Marvin" },
                    { 4, null, "Boaz Yakin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_actorsContext_MoviesId",
                table: "actorsContext",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_producerContext_MoviesId",
                table: "producerContext",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actorsContext");

            migrationBuilder.DropTable(
                name: "producerContext");

            migrationBuilder.DropTable(
                name: "moviesContext");
        }
    }
}
