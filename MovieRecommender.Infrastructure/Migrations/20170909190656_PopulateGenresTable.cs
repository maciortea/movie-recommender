using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MovieRecommender.Infrastructure.Migrations
{
    public partial class PopulateGenresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (2, 'Adventure')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (3, 'Animation')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (4, 'Children')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (5, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (6, 'Crime')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (7, 'Documentary')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (8, 'Drama')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (9, 'Fantasy')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (10, 'Film-Noir')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (11, 'Horror')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (12, 'Musical')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (13, 'Mystery')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (14, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (15, 'Sci-Fi')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (16, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (17, 'War')");
            migrationBuilder.Sql("INSERT INTO Genres (GenreId, Name) VALUES (18, 'Western')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres");
        }
    }
}
