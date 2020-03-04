using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "EmailMessages",
                table => new
                {
                    Id = table.Column<Guid>(),
                    ToRecipients = table.Column<string>(nullable: true),
                    Status = table.Column<int>(),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_EmailMessages", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "EmailMessages");
        }
    }
}