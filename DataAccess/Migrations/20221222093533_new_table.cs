using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccess.Migrations
{
    public partial class new_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "kongres",
               columns: table => new
               {
                   KongreId = table.Column<int>(nullable: false)
                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                   KongreBaskani = table.Column<string>(nullable: true),
                   KongreDuzenlemeKurulu = table.Column<string>(nullable: true),
                   BilimKurulu = table.Column<string>(nullable: true),
                   KongreKonusu = table.Column<string>(nullable: true),
                   KongreAdi = table.Column<string>(nullable: true),
                   KongreHakkinda = table.Column<string>(nullable: true),
                   KongreAdresi = table.Column<string>(nullable: true),
                   KongreTarihi = table.Column<DateTime>(nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Contacts", x => x.KongreId);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
