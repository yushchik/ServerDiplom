using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class First7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
           name: "FK_quest_choice_QUESTION",
           table: "UserChoices",
           column: "ID_QUESTION",
           principalTable: "Question",
           principalColumn: "ID_QUESTION",
           onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
