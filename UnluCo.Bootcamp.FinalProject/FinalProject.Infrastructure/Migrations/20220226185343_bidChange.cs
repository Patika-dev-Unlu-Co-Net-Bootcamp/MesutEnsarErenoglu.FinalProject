using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Infrastructure.Migrations
{
    public partial class bidChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BidAcceptDate",
                table: "Bids",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Bids",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BidAcceptDate",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Bids");
        }
    }
}
