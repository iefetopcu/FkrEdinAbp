using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FikirEdin.Migrations
{
    public partial class commentsettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productCommentLike",
                table: "productCommentTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "productCommentName",
                table: "productCommentTable",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productCommentLike",
                table: "productCommentTable");

            migrationBuilder.DropColumn(
                name: "productCommentName",
                table: "productCommentTable");
        }
    }
}
