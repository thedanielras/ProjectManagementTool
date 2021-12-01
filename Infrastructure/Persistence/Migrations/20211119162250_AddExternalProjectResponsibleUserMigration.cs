using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddExternalProjectResponsibleUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_User_UserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "ForeignResponsibleUserId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsibleUserId",
                table: "Projects",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"),
                column: "ResponsibleUserId",
                value: new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"),
                column: "ResponsibleUserId",
                value: new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ResponsibleUserId",
                table: "Projects",
                column: "ResponsibleUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_User_ResponsibleUserId",
                table: "Projects",
                column: "ResponsibleUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_User_ResponsibleUserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ResponsibleUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ForeignResponsibleUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ResponsibleUserId",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"),
                column: "UserId",
                value: new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"),
                column: "UserId",
                value: new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_User_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
