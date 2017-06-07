using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoldPlease.Migrations
{
    public partial class _00000000000000_CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clientId = table.Column<int>(nullable: false),
                    endAt = table.Column<DateTime>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    serviceProviderId = table.Column<int>(nullable: false),
                    startAt = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
