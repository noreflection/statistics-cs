using Microsoft.EntityFrameworkCore.Migrations;

namespace Statistics.Server.Migrations
{
    public partial class updateExTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Exercises",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Exercises",
                newName: "User");
        }
    }
}
