﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyJWTApp.Back.Persistance.Migrations
{
    public partial class Usernameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AppUsers");
        }
    }
}
