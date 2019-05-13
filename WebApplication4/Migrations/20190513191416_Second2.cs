using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebApplication4.Migrations
{
    public partial class Second2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
             name: "RESULT_DATE2",
             table: "Result",
             nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
