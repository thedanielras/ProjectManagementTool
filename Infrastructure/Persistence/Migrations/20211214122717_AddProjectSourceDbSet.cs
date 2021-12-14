using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddProjectSourceDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSource_Projects_ProjectId",
                table: "ProjectSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSource",
                table: "ProjectSource");

            migrationBuilder.RenameTable(
                name: "ProjectSource",
                newName: "ProjectSources");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectSource_ProjectId",
                table: "ProjectSources",
                newName: "IX_ProjectSources_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSources",
                table: "ProjectSources",
                column: "ProjectSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSources_Projects_ProjectId",
                table: "ProjectSources",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSources_Projects_ProjectId",
                table: "ProjectSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSources",
                table: "ProjectSources");

            migrationBuilder.RenameTable(
                name: "ProjectSources",
                newName: "ProjectSource");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectSources_ProjectId",
                table: "ProjectSource",
                newName: "IX_ProjectSource_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSource",
                table: "ProjectSource",
                column: "ProjectSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSource_Projects_ProjectId",
                table: "ProjectSource",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
