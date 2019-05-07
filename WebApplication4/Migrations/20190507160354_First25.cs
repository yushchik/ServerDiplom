using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class First25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
       name: "User_ID",
       table: "UserProgress");
            migrationBuilder.AddColumn<string>(
              name: "User_ID",
              table: "UserProgress",
              nullable: false,
              maxLength: 450);
            migrationBuilder.AddForeignKey(
           name: "FK_useprog_userid_User",
           table: "UserProgress",
           column: "User_ID",
           principalTable: "AspNetUsers",
           principalColumn: "Id",
           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
           name: "FK_useprog_lessonid_Lesson",
           table: "UserProgress",
           column: "Id_Lesson_Learned",
           principalTable: "Lesson",
           principalColumn: "ID_LESSON",
           onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
