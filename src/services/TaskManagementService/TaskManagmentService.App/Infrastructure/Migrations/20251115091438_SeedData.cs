using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagmentService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "assignment",
                columns: new[] { "id", "assignment_group_id", "assignment_status", "created_at_utc", "deadline_utc", "description", "priority", "project_id", "title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 0, 5, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Description1", "Medium", new Guid("11111111-1111-1111-1111-111111111111"), "Title1" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 0, 10, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Description2", "Medium", new Guid("11111111-1111-1111-1111-111111111111"), "Title2" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 0, 15, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Description3", "Medium", new Guid("11111111-1111-1111-1111-111111111111"), "Title3" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 0, 20, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Description4", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title4" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 0, 25, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Description5", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title5" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 0, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Description6", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title6" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 0, 35, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Description7", "Medium", new Guid("11111111-1111-1111-1111-111111111115"), "Title7" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 0, 40, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Description8", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title8" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 0, 45, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Description9", "Medium", new Guid("11111111-1111-1111-1111-111111111111"), "Title9" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("11111111-1111-1111-1111-111111111113"), "Backlog", new DateTime(2025, 11, 15, 0, 50, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Description10", "Medium", new Guid("11111111-1111-1111-1111-111111111113"), "Title10" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 0, 55, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Description11", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title11" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 1, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Description12", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title12" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), new Guid("11111111-1111-1111-1111-111111111113"), "Backlog", new DateTime(2025, 11, 15, 1, 5, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Description13", "Medium", new Guid("11111111-1111-1111-1111-111111111114"), "Title13" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), new Guid("11111111-1111-1111-1111-111111111114"), "Backlog", new DateTime(2025, 11, 15, 1, 10, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Description14", "Medium", new Guid("11111111-1111-1111-1111-111111111111"), "Title14" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), new Guid("11111111-1111-1111-1111-111111111115"), "Backlog", new DateTime(2025, 11, 15, 1, 15, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Description15", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title15" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 1, 20, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description16", "Medium", new Guid("11111111-1111-1111-1111-111111111113"), "Title16" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), new Guid("11111111-1111-1111-1111-111111111112"), "Backlog", new DateTime(2025, 11, 15, 1, 25, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Description17", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title17" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 1, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Description18", "Medium", new Guid("11111111-1111-1111-1111-111111111113"), "Title18" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 1, 35, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Description19", "Medium", new Guid("11111111-1111-1111-1111-111111111113"), "Title19" },
                    { new Guid("11111111-1111-1111-1111-111111111130"), new Guid("11111111-1111-1111-1111-111111111111"), "Backlog", new DateTime(2025, 11, 15, 1, 40, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Description20", "Medium", new Guid("11111111-1111-1111-1111-111111111112"), "Title20" }
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "role", "username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "MANAGER", "ivanov.ap" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "MANAGER", "petrova.ms" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "MANAGER", "sidorov.di" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), "ANALYST", "kozlova.av" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), "ANALYST", "fedorov.mo" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), "ANALYST", "nikitina.ed" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), "ANALYST", "orlov.sv" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), "DEVELOPER", "volkov.aa" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), "DEVELOPER", "zaitseva.oi" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), "DEVELOPER", "pavlov.is" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), "DEVELOPER", "semenova.tp" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), "DEVELOPER", "morozov.av" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), "DEVELOPER", "alekseev.vn" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), "DEVELOPER", "kovaleva.ya" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), "QA", "grigorev.po" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), "QA", "belova.nv" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), "QA", "kiselev.ad" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), "QA", "sokolova.ia" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), "QA", "titov.rm" },
                    { new Guid("11111111-1111-1111-1111-111111111130"), "QA", "medvedeva.sg" }
                });

            migrationBuilder.InsertData(
                table: "assignment_employee",
                columns: new[] { "assignment_id", "employee_id", "assignment_role" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111114"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111118"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111119"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111115"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111120"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111116"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111121"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111117"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111122"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111125"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("11111111-1111-1111-1111-111111111123"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("11111111-1111-1111-1111-111111111126"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), new Guid("11111111-1111-1111-1111-111111111124"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("11111111-1111-1111-1111-111111111127"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("11111111-1111-1111-1111-111111111128"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("11111111-1111-1111-1111-111111111129"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("11111111-1111-1111-1111-111111111118"), "Observer" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("11111111-1111-1111-1111-111111111130"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("11111111-1111-1111-1111-111111111119"), "Executor" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("11111111-1111-1111-1111-111111111120"), "Observer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"));

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111114") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111118") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111119") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111115") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111120") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111116") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111121") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111117") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111122") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111125") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("11111111-1111-1111-1111-111111111123") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("11111111-1111-1111-1111-111111111126") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111116"), new Guid("11111111-1111-1111-1111-111111111124") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("11111111-1111-1111-1111-111111111127") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("11111111-1111-1111-1111-111111111128") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("11111111-1111-1111-1111-111111111129") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("11111111-1111-1111-1111-111111111118") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("11111111-1111-1111-1111-111111111130") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("11111111-1111-1111-1111-111111111119") });

            migrationBuilder.DeleteData(
                table: "assignment_employee",
                keyColumns: new[] { "assignment_id", "employee_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("11111111-1111-1111-1111-111111111120") });

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"));

            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"));

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"));
        }
    }
}
