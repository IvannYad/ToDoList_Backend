using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DAL.Migrations
{
    public partial class AddTypeColumnToToDoTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End time", "Start time", "Type" },
                values: new object[] { new DateTime(2023, 12, 25, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3858), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3804), "feature" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End time", "Start time", "Type" },
                values: new object[] { new DateTime(2023, 12, 25, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3866), "bug" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End time", "Start time", "Type" },
                values: new object[] { new DateTime(2023, 12, 25, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3879), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3875), "feature" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End time", "Start time", "Type" },
                values: new object[] { new DateTime(2023, 12, 26, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3886), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3882), "bug" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End time", "Start time", "Type" },
                values: new object[] { new DateTime(2023, 12, 27, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3898), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3896), "feature" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End time", "Start time" },
                values: new object[] { new DateTime(2023, 12, 21, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3848), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End time", "Start time" },
                values: new object[] { new DateTime(2023, 12, 21, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3858), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End time", "Start time" },
                values: new object[] { new DateTime(2023, 12, 21, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3864), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End time", "Start time" },
                values: new object[] { new DateTime(2023, 12, 22, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End time", "Start time" },
                values: new object[] { new DateTime(2023, 12, 23, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3875), new DateTime(2023, 12, 20, 16, 47, 53, 532, DateTimeKind.Local).AddTicks(3873) });
        }
    }
}
