using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[] { new Guid("e3e81151-2092-4921-8f8c-e0fe3800fa4d"), "Java" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[] { new Guid("6d0484d4-b777-439c-8174-eb2b213349b8"), ".NET" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Name", "Password" },
                values: new object[] { new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"), "admin", "password" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "Name", "UserId" },
                values: new object[] { new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"), new Guid("e3e81151-2092-4921-8f8c-e0fe3800fa4d"), "Aquilla", new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697") });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "Name", "UserId" },
                values: new object[] { new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"), new Guid("6d0484d4-b777-439c-8174-eb2b213349b8"), "PWS", new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697") });

            migrationBuilder.InsertData(
                table: "ProjectSource",
                columns: new[] { "ProjectSourceId", "ProjectId", "SourceUrl" },
                values: new object[] { new Guid("12c74e66-d8d1-4966-9c88-18f3666740e8"), new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"), "https://github.com/topics/java" });

            migrationBuilder.InsertData(
                table: "ProjectSource",
                columns: new[] { "ProjectSourceId", "ProjectId", "SourceUrl" },
                values: new object[] { new Guid("3b3c7093-d954-488b-930a-4ad6eadd2987"), new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"), "https://github.com/topics/dotnet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectSource",
                keyColumn: "ProjectSourceId",
                keyValue: new Guid("12c74e66-d8d1-4966-9c88-18f3666740e8"));

            migrationBuilder.DeleteData(
                table: "ProjectSource",
                keyColumn: "ProjectSourceId",
                keyValue: new Guid("3b3c7093-d954-488b-930a-4ad6eadd2987"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentId",
                keyValue: new Guid("6d0484d4-b777-439c-8174-eb2b213349b8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentId",
                keyValue: new Guid("e3e81151-2092-4921-8f8c-e0fe3800fa4d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"));
        }
    }
}
