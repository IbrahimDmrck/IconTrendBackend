using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class congressTableRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CongressCity",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "CongressPlace",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "CongressPresidentId",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "RegulatoryBoardId",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "ScienceBoardId",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Congresses");

         

            migrationBuilder.AddColumn<string>(
                name: "CongressAdress",
                table: "Congresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CongressPresidentName",
                table: "Congresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegulatoryBoard",
                table: "Congresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScienceBoard",
                table: "Congresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Congresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Univercity",
                table: "Congresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CongressStatus",
                table: "Kongres");

            migrationBuilder.DropColumn(
                name: "Univercity",
                table: "Kongres");

            migrationBuilder.DropColumn(
                name: "CongressAdress",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "CongressPresidentName",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "RegulatoryBoard",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "ScienceBoard",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Congresses");

            migrationBuilder.DropColumn(
                name: "Univercity",
                table: "Congresses");

            migrationBuilder.AddColumn<string>(
                name: "CongressCity",
                table: "Congresses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CongressPlace",
                table: "Congresses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CongressPresidentId",
                table: "Congresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegulatoryBoardId",
                table: "Congresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScienceBoardId",
                table: "Congresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Congresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
