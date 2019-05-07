using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class First2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "ID_USER",
        table: "Result");
            migrationBuilder.AddColumn<string>(
              name: "ID_USER",
              table: "Result",
              nullable: false,
              maxLength: 450);
            migrationBuilder.AddForeignKey(
           name: "FK_Result_User_QUESTION",
           table: "Result",
           column: "ID_USER",
           principalTable: "AspNetUsers",
           principalColumn: "Id",
           onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
