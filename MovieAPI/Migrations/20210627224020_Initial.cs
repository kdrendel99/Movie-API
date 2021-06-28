using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Genre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Director = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    OscarWinner = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                    table.ForeignKey(
                        name: "FK_Actors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "Genre", "Name", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, "Simon West", "Action", "Con Air", 7.0, 1997 },
                    { 2, "Dominic Sena", "Action", "Gone in 60 Seconds", 6.7000000000000002, 2000 },
                    { 3, "Sam Mendes", "Action", "Skyfall", 7.7000000000000002, 2012 },
                    { 4, "Sam Mendes", "Drama", "1917", 7.7999999999999998, 2020 },
                    { 5, "Michael Bay", "Action", "The Rock", 7.5, 1996 },
                    { 6, "Boaz Yakin", "Drama", "Remember The Titans", 8.0, 2000 },
                    { 7, "Michael Showalter", "Romantic Comedy", "The Big Sick", 7.7000000000000002, 2017 },
                    { 8, "Adam McKay", "Drama", "The Big Short", 8.0, 2015 },
                    { 9, "Christian Gudegast", "Action", "Den of Thieves", 7.0, 2018 },
                    { 10, "Justin Lin", "Action", "Fast Five", 7.5, 2011 }
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "Age", "MovieId", "Name", "OscarWinner" },
                values: new object[,]
                {
                    { 1, 57, 1, "Nicolas Cage", true },
                    { 15, 43, 9, "Pablo Schreiber", false },
                    { 14, 51, 9, "Gerard Butler", false },
                    { 13, 40, 8, "Ryan Gosling", true },
                    { 12, 58, 8, "Steve Carell", true },
                    { 11, 31, 7, "Zoe Kazan", true },
                    { 10, 43, 7, "Kumail Nanjiani", false },
                    { 16, 53, 10, "Vin Diesel", false },
                    { 9, 48, 6, "Ryan Hurst", true },
                    { 7, 70, 5, "Ed Harris", true },
                    { 6, 90, 5, "Sean Connery", true },
                    { 5, 86, 3, "Judi Dench", true },
                    { 4, 53, 3, "Daniel Craig", true },
                    { 3, 46, 2, "Angelina Jolie", true },
                    { 2, 67, 1, "John Malkovich", true },
                    { 8, 66, 6, "Denzel Washington", true },
                    { 17, 40, 10, "Paul Walker", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                table: "Actors",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
