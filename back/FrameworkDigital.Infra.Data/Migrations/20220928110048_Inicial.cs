using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrameworkDigital.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactFirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactLastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContactEmail = table.Column<string>(type: "varchar(100)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Suburb = table.Column<string>(type: "varchar(200)", nullable: false),
                    Category = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lead");
        }
    }
}
