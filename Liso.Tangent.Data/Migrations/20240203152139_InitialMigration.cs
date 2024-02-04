using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Liso.Tangent.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroId = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    RawData = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourite");
        }
    }
}
