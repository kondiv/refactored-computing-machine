using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssignmentGroupManagemetService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssignmentGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Name1" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Name2" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Name3" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), "Name4" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), "Name5" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), "Name6" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), "Name7" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), "Name8" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), "Name9" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), "Name10" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), "Name11" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), "Name12" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), "Name13" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), "Name14" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), "Name15" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), "Name16" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), "Name17" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), "Name18" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), "Name19" },
                    { new Guid("11111111-1111-1111-1111-111111111130"), "Name20" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssignmentGroupId", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("11111111-1111-1111-1111-111111111113"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), new Guid("11111111-1111-1111-1111-111111111113"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), new Guid("11111111-1111-1111-1111-111111111114"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), new Guid("11111111-1111-1111-1111-111111111115"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111130"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "AssignmentGroups",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"));
        }
    }
}
