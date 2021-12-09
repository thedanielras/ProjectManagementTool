using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddUserRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ProjectSource",
                nullable: false,
                defaultValue: 3,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.UpdateData(
                table: "ProjectSource",
                keyColumn: "ProjectSourceId",
                keyValue: new Guid("12c74e66-d8d1-4966-9c88-18f3666740e8"),
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProjectSource",
                keyColumn: "ProjectSourceId",
                keyValue: new Guid("3b3c7093-d954-488b-930a-4ad6eadd2987"),
                column: "Type",
                value: 1);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { new Guid("703cccc6-2a7d-4d31-93be-0809c77b7ebf"), "user" },
                    { new Guid("ede5e059-6960-410c-8164-224660d6705b"), "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"),
                column: "RoleId",
                value: new Guid("ede5e059-6960-410c-8164-224660d6705b"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ProjectSource",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldDefaultValue: 3);

            migrationBuilder.UpdateData(
                table: "ProjectSource",
                keyColumn: "ProjectSourceId",
                keyValue: new Guid("12c74e66-d8d1-4966-9c88-18f3666740e8"),
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProjectSource",
                keyColumn: "ProjectSourceId",
                keyValue: new Guid("3b3c7093-d954-488b-930a-4ad6eadd2987"),
                column: "Type",
                value: 0);
        }
    }
}
