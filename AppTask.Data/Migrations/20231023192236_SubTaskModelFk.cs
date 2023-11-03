using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubTaskModelFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTasks_Tasks_TaskModelId",
                table: "SubTasks");

            migrationBuilder.DropIndex(
                name: "IX_SubTasks_TaskModelId",
                table: "SubTasks");

            migrationBuilder.DropColumn(
                name: "TaskModelId",
                table: "SubTasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "SubTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubTasks_TaskId",
                table: "SubTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTasks_Tasks_TaskId",
                table: "SubTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTasks_Tasks_TaskId",
                table: "SubTasks");

            migrationBuilder.DropIndex(
                name: "IX_SubTasks_TaskId",
                table: "SubTasks");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "SubTasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskModelId",
                table: "SubTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubTasks_TaskModelId",
                table: "SubTasks",
                column: "TaskModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTasks_Tasks_TaskModelId",
                table: "SubTasks",
                column: "TaskModelId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
