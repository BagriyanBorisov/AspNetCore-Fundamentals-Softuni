using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class SeedAndConfigurationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 20, 16, 7, 36, 134, DateTimeKind.Local).AddTicks(8432), "Implement better styling for all public pages", "2916587f-6c8e-4494-949c-c2e79b95beb7", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 1, 8, 16, 7, 36, 134, DateTimeKind.Local).AddTicks(8476), "Create Android client app for the TaskBoard RESTful API", "502a30c1-3b34-487c-b18a-f0154358a22d", "Android Client app" },
                    { 3, 2, new DateTime(2023, 6, 7, 16, 7, 36, 134, DateTimeKind.Local).AddTicks(8481), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "502a30c1-3b34-487c-b18a-f0154358a22d", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 8, 16, 7, 36, 134, DateTimeKind.Local).AddTicks(8484), "Implement [Create Task] page for adding new tasks", "2916587f-6c8e-4494-949c-c2e79b95beb7", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
