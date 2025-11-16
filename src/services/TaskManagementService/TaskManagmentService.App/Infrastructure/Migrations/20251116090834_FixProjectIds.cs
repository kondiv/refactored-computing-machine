using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixProjectIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222205"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222204"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "project_id",
                value: new Guid("22222222-2222-2222-2222-222222222202"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111115"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.UpdateData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "project_id",
                value: new Guid("11111111-1111-1111-1111-111111111112"));
        }
    }
}
