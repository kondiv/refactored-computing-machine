using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagementService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FillTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_project",
                table: "project");

            migrationBuilder.RenameTable(
                name: "project",
                newName: "Projects");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "supervisor_id",
                table: "Projects",
                newName: "SupervisorId");

            migrationBuilder.RenameColumn(
                name: "manager_id",
                table: "Projects",
                newName: "ManagerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Role = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Role", "Username" },
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
                table: "Projects",
                columns: new[] { "Id", "Description", "ManagerId", "Name", "SupervisorId" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222201"), "Description1", new Guid("11111111-1111-1111-1111-111111111112"), "Name1", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222202"), "Description2", new Guid("11111111-1111-1111-1111-111111111111"), "Name2", new Guid("11111111-1111-1111-1111-111111111113") },
                    { new Guid("22222222-2222-2222-2222-222222222203"), "Description3", new Guid("11111111-1111-1111-1111-111111111113"), "Name3", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222204"), "Description4", new Guid("11111111-1111-1111-1111-111111111113"), "Name4", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222205"), "Description5", new Guid("11111111-1111-1111-1111-111111111111"), "Name5", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222206"), "Description6", new Guid("11111111-1111-1111-1111-111111111112"), "Name6", new Guid("11111111-1111-1111-1111-111111111113") },
                    { new Guid("22222222-2222-2222-2222-222222222207"), "Description7", new Guid("11111111-1111-1111-1111-111111111112"), "Name7", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222208"), "Description8", new Guid("11111111-1111-1111-1111-111111111113"), "Name8", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222209"), "Description9", new Guid("11111111-1111-1111-1111-111111111111"), "Name9", new Guid("11111111-1111-1111-1111-111111111113") },
                    { new Guid("22222222-2222-2222-2222-222222222210"), "Description10", new Guid("11111111-1111-1111-1111-111111111113"), "Name10", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222211"), "Description11", new Guid("11111111-1111-1111-1111-111111111111"), "Name11", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222212"), "Description12", new Guid("11111111-1111-1111-1111-111111111112"), "Name12", new Guid("11111111-1111-1111-1111-111111111113") },
                    { new Guid("22222222-2222-2222-2222-222222222213"), "Description13", new Guid("11111111-1111-1111-1111-111111111112"), "Name13", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222214"), "Description14", new Guid("11111111-1111-1111-1111-111111111113"), "Name14", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222215"), "Description15", new Guid("11111111-1111-1111-1111-111111111111"), "Name15", new Guid("11111111-1111-1111-1111-111111111113") },
                    { new Guid("22222222-2222-2222-2222-222222222216"), "Description16", new Guid("11111111-1111-1111-1111-111111111113"), "Name16", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222217"), "Description17", new Guid("11111111-1111-1111-1111-111111111111"), "Name17", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222218"), "Description18", new Guid("11111111-1111-1111-1111-111111111112"), "Name18", new Guid("11111111-1111-1111-1111-111111111113") },
                    { new Guid("22222222-2222-2222-2222-222222222219"), "Description19", new Guid("11111111-1111-1111-1111-111111111112"), "Name19", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222220"), "Description20", new Guid("11111111-1111-1111-1111-111111111113"), "Name20", new Guid("11111111-1111-1111-1111-111111111112") }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ProjectId", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("22222222-2222-2222-2222-222222222201"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("22222222-2222-2222-2222-222222222201"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("22222222-2222-2222-2222-222222222201"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("22222222-2222-2222-2222-222222222205"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("22222222-2222-2222-2222-222222222201"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("22222222-2222-2222-2222-222222222203"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), new Guid("22222222-2222-2222-2222-222222222204"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), new Guid("22222222-2222-2222-2222-222222222201"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), new Guid("22222222-2222-2222-2222-222222222203"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), new Guid("22222222-2222-2222-2222-222222222203"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), new Guid("22222222-2222-2222-2222-222222222203"), "Backlog" },
                    { new Guid("11111111-1111-1111-1111-111111111130"), new Guid("22222222-2222-2222-2222-222222222202"), "Backlog" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ManagerId",
                table: "Projects",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SupervisorId",
                table: "Projects",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ProjectId",
                table: "Assignments",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_ManagerId",
                table: "Projects",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_SupervisorId",
                table: "Projects",
                column: "SupervisorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_ManagerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_SupervisorId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_SupervisorId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222204"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222205"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222206"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222207"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222208"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222209"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222210"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222211"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222212"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222213"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222214"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222215"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222216"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222217"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222218"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222219"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222220"));

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "project");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "project",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "project",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "project",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "project",
                newName: "supervisor_id");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "project",
                newName: "manager_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_project",
                table: "project",
                column: "id");
        }
    }
}
