using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_employee_assignment_assignment_id",
                table: "assignment_employee");

            migrationBuilder.DropForeignKey(
                name: "FK_assignment_employee_employee_employee_id",
                table: "assignment_employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee",
                table: "employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assignment_employee",
                table: "assignment_employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assignment",
                table: "assignment");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "assignment_employee",
                newName: "AssignmentEmployees");

            migrationBuilder.RenameTable(
                name: "assignment",
                newName: "Assignments");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Employees",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Employees",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "assignment_role",
                table: "AssignmentEmployees",
                newName: "AssignmentRole");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "AssignmentEmployees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "assignment_id",
                table: "AssignmentEmployees",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_employee_employee_id",
                table: "AssignmentEmployees",
                newName: "IX_AssignmentEmployees_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Assignments",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "Assignments",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Assignments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Assignments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "project_id",
                table: "Assignments",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "deadline_utc",
                table: "Assignments",
                newName: "DeadlineUtc");

            migrationBuilder.RenameColumn(
                name: "created_at_utc",
                table: "Assignments",
                newName: "CreatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "assignment_status",
                table: "Assignments",
                newName: "AssignmentStatus");

            migrationBuilder.RenameColumn(
                name: "assignment_group_id",
                table: "Assignments",
                newName: "AssignmentGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentEmployees",
                table: "AssignmentEmployees",
                columns: new[] { "AssignmentId", "EmployeeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AssignmentGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AssignmentGroup",
                column: "Id",
                values: new object[]
                {
                    new Guid("11111111-1111-1111-1111-111111111111"),
                    new Guid("11111111-1111-1111-1111-111111111112"),
                    new Guid("11111111-1111-1111-1111-111111111113"),
                    new Guid("11111111-1111-1111-1111-111111111114"),
                    new Guid("11111111-1111-1111-1111-111111111115"),
                    new Guid("11111111-1111-1111-1111-111111111116"),
                    new Guid("11111111-1111-1111-1111-111111111117"),
                    new Guid("11111111-1111-1111-1111-111111111118"),
                    new Guid("11111111-1111-1111-1111-111111111119"),
                    new Guid("11111111-1111-1111-1111-111111111120"),
                    new Guid("11111111-1111-1111-1111-111111111121"),
                    new Guid("11111111-1111-1111-1111-111111111122"),
                    new Guid("11111111-1111-1111-1111-111111111123"),
                    new Guid("11111111-1111-1111-1111-111111111124"),
                    new Guid("11111111-1111-1111-1111-111111111125"),
                    new Guid("11111111-1111-1111-1111-111111111126"),
                    new Guid("11111111-1111-1111-1111-111111111127"),
                    new Guid("11111111-1111-1111-1111-111111111128"),
                    new Guid("11111111-1111-1111-1111-111111111129"),
                    new Guid("11111111-1111-1111-1111-111111111130")
                });

            migrationBuilder.InsertData(
                table: "Project",
                column: "Id",
                values: new object[]
                {
                    new Guid("22222222-2222-2222-2222-222222222201"),
                    new Guid("22222222-2222-2222-2222-222222222202"),
                    new Guid("22222222-2222-2222-2222-222222222203"),
                    new Guid("22222222-2222-2222-2222-222222222204"),
                    new Guid("22222222-2222-2222-2222-222222222205"),
                    new Guid("22222222-2222-2222-2222-222222222206"),
                    new Guid("22222222-2222-2222-2222-222222222207"),
                    new Guid("22222222-2222-2222-2222-222222222208"),
                    new Guid("22222222-2222-2222-2222-222222222209"),
                    new Guid("22222222-2222-2222-2222-222222222210"),
                    new Guid("22222222-2222-2222-2222-222222222211"),
                    new Guid("22222222-2222-2222-2222-222222222212"),
                    new Guid("22222222-2222-2222-2222-222222222213"),
                    new Guid("22222222-2222-2222-2222-222222222214"),
                    new Guid("22222222-2222-2222-2222-222222222215"),
                    new Guid("22222222-2222-2222-2222-222222222216"),
                    new Guid("22222222-2222-2222-2222-222222222217"),
                    new Guid("22222222-2222-2222-2222-222222222218"),
                    new Guid("22222222-2222-2222-2222-222222222219"),
                    new Guid("22222222-2222-2222-2222-222222222220")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentEmployees_Assignments_AssignmentId",
                table: "AssignmentEmployees",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentEmployees_Employees_EmployeeId",
                table: "AssignmentEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentEmployees_Assignments_AssignmentId",
                table: "AssignmentEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentEmployees_Employees_EmployeeId",
                table: "AssignmentEmployees");

            migrationBuilder.DropTable(
                name: "AssignmentGroup");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentEmployees",
                table: "AssignmentEmployees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employee");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "assignment");

            migrationBuilder.RenameTable(
                name: "AssignmentEmployees",
                newName: "assignment_employee");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "employee",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "employee",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employee",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "assignment",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "assignment",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "assignment",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "assignment",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "assignment",
                newName: "project_id");

            migrationBuilder.RenameColumn(
                name: "DeadlineUtc",
                table: "assignment",
                newName: "deadline_utc");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                table: "assignment",
                newName: "created_at_utc");

            migrationBuilder.RenameColumn(
                name: "AssignmentStatus",
                table: "assignment",
                newName: "assignment_status");

            migrationBuilder.RenameColumn(
                name: "AssignmentGroupId",
                table: "assignment",
                newName: "assignment_group_id");

            migrationBuilder.RenameColumn(
                name: "AssignmentRole",
                table: "assignment_employee",
                newName: "assignment_role");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "assignment_employee",
                newName: "employee_id");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "assignment_employee",
                newName: "assignment_id");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentEmployees_EmployeeId",
                table: "assignment_employee",
                newName: "IX_assignment_employee_employee_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee",
                table: "employee",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignment",
                table: "assignment",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignment_employee",
                table: "assignment_employee",
                columns: new[] { "assignment_id", "employee_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_employee_assignment_assignment_id",
                table: "assignment_employee",
                column: "assignment_id",
                principalTable: "assignment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_employee_employee_employee_id",
                table: "assignment_employee",
                column: "employee_id",
                principalTable: "employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
