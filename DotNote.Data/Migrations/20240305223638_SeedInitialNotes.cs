using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNote.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("262e9be7-da53-4d1b-802b-30c23e41eda0"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("802ace80-dcd2-4d32-a503-46f8480935c5"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("ba517941-dca0-4749-86d0-c4e0a93c5c63"));

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedAt", "FolderId", "IsActive", "Subtitle", "Text", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("114065b3-438d-4645-8a31-9047c7e38e79"), new DateTime(2024, 3, 5, 22, 36, 37, 791, DateTimeKind.Utc).AddTicks(2294), null, true, "This is the subtitle for the second note", "This is the content of the second note.", "Second Note", new Guid("442f7e99-7581-42c1-9a4e-890e69ff1b9b") },
                    { new Guid("2ad10056-a064-4374-a6e6-3c55e938262b"), new DateTime(2024, 3, 5, 22, 36, 37, 791, DateTimeKind.Utc).AddTicks(2298), null, true, "This is the subtitle for the third note", "This is the content of the third note.", "Third Note", new Guid("442f7e99-7581-42c1-9a4e-890e69ff1b9b") },
                    { new Guid("5dda0193-8a3b-4de2-8d73-bc656a654a4c"), new DateTime(2024, 3, 5, 22, 36, 37, 791, DateTimeKind.Utc).AddTicks(2273), null, true, "This is the subtitle for the first note", "This is the content of the first note.", "First Note", new Guid("442f7e99-7581-42c1-9a4e-890e69ff1b9b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("114065b3-438d-4645-8a31-9047c7e38e79"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("2ad10056-a064-4374-a6e6-3c55e938262b"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("5dda0193-8a3b-4de2-8d73-bc656a654a4c"));

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedAt", "FolderId", "IsActive", "Subtitle", "Text", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("262e9be7-da53-4d1b-802b-30c23e41eda0"), new DateTime(2024, 3, 5, 22, 30, 12, 632, DateTimeKind.Utc).AddTicks(7598), null, true, "This is the subtitle for the second note", "This is the content of the second note.", "Second Note", new Guid("442f7e99-7581-42c1-9a4e-890e69ff1b9b") },
                    { new Guid("802ace80-dcd2-4d32-a503-46f8480935c5"), new DateTime(2024, 3, 5, 22, 30, 12, 632, DateTimeKind.Utc).AddTicks(7581), null, true, "This is the subtitle for the first note", "This is the content of the first note.", "First Note", new Guid("442f7e99-7581-42c1-9a4e-890e69ff1b9b") },
                    { new Guid("ba517941-dca0-4749-86d0-c4e0a93c5c63"), new DateTime(2024, 3, 5, 22, 30, 12, 632, DateTimeKind.Utc).AddTicks(7603), null, true, "This is the subtitle for the third note", "This is the content of the third note.", "Third Note", new Guid("442f7e99-7581-42c1-9a4e-890e69ff1b9b") }
                });
        }
    }
}
