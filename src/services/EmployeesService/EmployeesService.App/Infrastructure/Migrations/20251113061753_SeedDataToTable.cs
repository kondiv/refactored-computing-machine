using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeesService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "name", "patronymic", "role", "surname", "username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Алексей", "Петрович", "MANAGER", "Иванов", "ivanov.ap" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Мария", "Сергеевна", "MANAGER", "Петрова", "petrova.ms" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Дмитрий", "Игоревич", "MANAGER", "Сидоров", "sidorov.di" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), "Анна", "Владимировна", "ANALYST", "Козлова", "kozlova.av" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), "Михаил", "Олегович", "ANALYST", "Федоров", "fedorov.mo" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), "Елена", "Дмитриевна", "ANALYST", "Никитина", "nikitina.ed" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), "Сергей", "Викторович", "ANALYST", "Орлов", "orlov.sv" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), "Андрей", "Александрович", "DEVELOPER", "Волков", "volkov.aa" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), "Ольга", "Ивановна", "DEVELOPER", "Зайцева", "zaitseva.oi" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), "Игорь", "Сергеевич", "DEVELOPER", "Павлов", "pavlov.is" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), "Татьяна", "Петровна", "DEVELOPER", "Семенова", "semenova.tp" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), "Артем", "Вадимович", "DEVELOPER", "Морозов", "morozov.av" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), "Владимир", "Николаевич", "DEVELOPER", "Алексеев", "alekseev.vn" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), "Юлия", "Андреевна", "DEVELOPER", "Ковалева", "kovaleva.ya" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), "Павел", "Олегович", "QA", "Григорьев", "grigorev.po" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), "Наталья", "Викторовна", "QA", "Белова", "belova.nv" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), "Антон", "Денисович", "QA", "Киселев", "kiselev.ad" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), "Ирина", "Алексеевна", "QA", "Соколова", "sokolova.ia" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), "Роман", "Михайлович", "QA", "Титов", "titov.rm" },
                    { new Guid("11111111-1111-1111-1111-111111111130"), "Светлана", "Геннадьевна", "QA", "Медведева", "medvedeva.sg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
