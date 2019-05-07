using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class First24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "UserProgress",
               columns: table => new
               {
                   ProgressId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   User_ID = table.Column<string>(nullable: true),
                   Id_Lesson_Learned = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_UseProgress", x => x.ProgressId);

               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
