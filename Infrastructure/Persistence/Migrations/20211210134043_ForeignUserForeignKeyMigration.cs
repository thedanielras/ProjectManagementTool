using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class ForeignUserForeignKeyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_ForeignResponsibleUserId",
                table: "Projects",
                column: "ForeignResponsibleUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ForeignResponsibleUserId",
                table: "Projects",
                column: "ForeignResponsibleUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ForeignResponsibleUserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ForeignResponsibleUserId",
                table: "Projects");
        }
    }
}
