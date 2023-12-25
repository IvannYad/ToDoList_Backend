using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DAL.Migrations
{
    public partial class ChangeValuesForStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "done", new DateTime(2023, 12, 26, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5582), new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5542) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "in-progress", new DateTime(2023, 12, 26, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5592), new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5588) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "in-progress", new DateTime(2023, 12, 26, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5600), new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5596) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "to-do", new DateTime(2023, 12, 27, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5608), new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "to-do", new DateTime(2023, 12, 28, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5615), new DateTime(2023, 12, 25, 12, 2, 47, 624, DateTimeKind.Local).AddTicks(5612) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "Done", new DateTime(2023, 12, 25, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3858), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3804) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "In progress", new DateTime(2023, 12, 25, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3866) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "In progress", new DateTime(2023, 12, 25, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3879), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3875) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "To do", new DateTime(2023, 12, 26, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3886), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Status", "End time", "Start time" },
                values: new object[] { "To do", new DateTime(2023, 12, 27, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3898), new DateTime(2023, 12, 24, 23, 52, 16, 756, DateTimeKind.Local).AddTicks(3896) });
        }
    }
}
