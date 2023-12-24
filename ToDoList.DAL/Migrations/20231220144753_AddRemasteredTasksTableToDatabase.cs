using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DAL.Migrations
{
    public partial class AddRemasteredTasksTableToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoTasks",
                table: "ToDoTasks");

            migrationBuilder.RenameTable(
                name: "ToDoTasks",
                newName: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskTitle",
                table: "Tasks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TaskStartTime",
                table: "Tasks",
                newName: "Start time");

            migrationBuilder.RenameColumn(
                name: "TaskEndTime",
                table: "Tasks",
                newName: "End time");

            migrationBuilder.RenameColumn(
                name: "AdditionalDescription",
                table: "Tasks",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "Done", new DateTime(2023, 12, 21, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3848), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "In progress", new DateTime(2023, 12, 21, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3858), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "In progress", new DateTime(2023, 12, 21, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3864), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "To do", new DateTime(2023, 12, 22, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "To do", new DateTime(2023, 12, 23, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3875), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3873) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "ToDoTasks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ToDoTasks",
                newName: "TaskTitle");

            migrationBuilder.RenameColumn(
                name: "Start time",
                table: "ToDoTasks",
                newName: "TaskStartTime");

            migrationBuilder.RenameColumn(
                name: "End time",
                table: "ToDoTasks",
                newName: "TaskEndTime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ToDoTasks",
                newName: "AdditionalDescription");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ToDoTasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoTasks",
                table: "ToDoTasks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Status", "TaskEndTime", "TaskStartTime" },
                values: new object[] { 2, new DateTime(2023, 12, 21, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2754), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2712) });

            migrationBuilder.UpdateData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Status", "TaskEndTime", "TaskStartTime" },
                values: new object[] { 1, new DateTime(2023, 12, 21, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2760), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Status", "TaskEndTime", "TaskStartTime" },
                values: new object[] { 1, new DateTime(2023, 12, 21, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2764), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2762) });

            migrationBuilder.UpdateData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Status", "TaskEndTime", "TaskStartTime" },
                values: new object[] { 0, new DateTime(2023, 12, 22, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2769), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2767) });

            migrationBuilder.UpdateData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Status", "TaskEndTime", "TaskStartTime" },
                values: new object[] { 0, new DateTime(2023, 12, 23, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2773), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2771) });
        }
    }
}
