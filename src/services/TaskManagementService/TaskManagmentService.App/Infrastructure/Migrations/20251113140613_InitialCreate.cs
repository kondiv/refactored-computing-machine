using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assignment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assignment_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deadline_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    assignment_status = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    role = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assignment_employee",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assignment_role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment_employee", x => new { x.assignment_id, x.employee_id });
                    table.ForeignKey(
                        name: "FK_assignment_employee_assignment_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "assignment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assignment_employee_employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignment_employee_employee_id",
                table: "assignment_employee",
                column: "employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignment_employee");

            migrationBuilder.DropTable(
                name: "assignment");

            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
