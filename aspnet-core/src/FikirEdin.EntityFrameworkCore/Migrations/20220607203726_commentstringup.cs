using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FikirEdin.Migrations
{
    public partial class commentstringup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "modelString",
                table: "productCommentTable",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modelString",
                table: "productCommentTable");
        }
    }
}
