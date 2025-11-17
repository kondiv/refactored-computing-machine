using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentService.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentGroup",
                table: "AssignmentGroup");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "AssignmentGroup",
                newName: "AssignmentGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentGroups",
                table: "AssignmentGroups",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentGroupId",
                table: "Assignments",
                column: "AssignmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ProjectId",
                table: "Assignments",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AssignmentGroups_AssignmentGroupId",
                table: "Assignments",
                column: "AssignmentGroupId",
                principalTable: "AssignmentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Projects_ProjectId",
                table: "Assignments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AssignmentGroups_AssignmentGroupId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Projects_ProjectId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AssignmentGroupId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_ProjectId",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentGroups",
                table: "AssignmentGroups");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "AssignmentGroups",
                newName: "AssignmentGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentGroup",
                table: "AssignmentGroup",
                column: "Id");
        }
    }
}
