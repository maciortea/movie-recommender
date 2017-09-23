using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MovieRecommender.Infrastructure.Migrations
{
    public partial class ChangeColumnNameFromScoreToRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "MovieRatings");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "MovieRatings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MovieRatings");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "MovieRatings",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
