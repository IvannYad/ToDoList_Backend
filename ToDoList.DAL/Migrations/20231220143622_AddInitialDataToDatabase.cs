using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DAL.Migrations
{
    public partial class AddInitialDataToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "AdditionalDescription", "Status", "TaskEndTime", "TaskStartTime", "TaskTitle" },
                values: new object[,]
                {
                    { 1, "Just do nothing", 2, new DateTime(2023, 12, 21, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2754), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2712), "Do nothing1" },
                    { 2, "Just do nothing", 1, new DateTime(2023, 12, 21, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2760), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2758), "Do nothing2" },
                    { 3, "Just do nothing", 1, new DateTime(2023, 12, 21, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2764), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2762), "Do nothing3" },
                    { 4, "Just do nothing", 0, new DateTime(2023, 12, 22, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2769), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2767), "Do nothing4" },
                    { 5, "Just do nothing", 0, new DateTime(2023, 12, 23, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2773), new DateTime(2023, 12, 20, 16, 36, 21, 890, DateTimeKind.Local).AddTicks(2771), "Do nothing5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
