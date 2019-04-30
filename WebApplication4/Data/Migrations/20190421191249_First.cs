using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BIRTHDAY",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CITY",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SURNAME",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    ID_ANSWER = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_QUESTION = table.Column<int>(nullable: false),
                    ANSWER = table.Column<string>(nullable: true),
                    ISTRUE_ANSWER = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.ID_ANSWER);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    ID_LESSON = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TITLE_LESSON = table.Column<string>(nullable: true),
                    ID_SECTION = table.Column<int>(nullable: false),
                    INFORMATION = table.Column<string>(nullable: true),
                    VIDEO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.ID_LESSON);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID_QUESTION = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_TEST = table.Column<int>(nullable: false),
                    TITLE_QUESTION = table.Column<string>(nullable: true),
                    COST = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID_QUESTION);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ID_RESULT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_USER = table.Column<int>(nullable: false),
                    ID_TEST = table.Column<int>(nullable: false),
                    RESULT = table.Column<float>(nullable: false),
                    RESULT_DATE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ID_RESULT);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    ID_TEST = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME_TEST = table.Column<string>(nullable: true),
                    ID_LESSON = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.ID_TEST);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropColumn(
                name: "BIRTHDAY",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CITY",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SURNAME",
                table: "AspNetUsers");
        }
    }
}
