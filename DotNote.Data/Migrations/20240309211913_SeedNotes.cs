using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNote.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedAt", "FolderId", "IsActive", "Subtitle", "Text", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("78976161-641a-43db-a3fb-eee0da21ce7a"), new DateTime(2024, 3, 9, 21, 19, 12, 402, DateTimeKind.Utc).AddTicks(805), null, true, "This is the subtitle for the third note", "This is the content of the third note.", "Third Note", new Guid("008db7ef-8ad6-4346-a7f6-c7b4297aa1ee") },
                    { new Guid("a3eba7a6-7779-4b50-b814-74b61a8b551a"), new DateTime(2024, 3, 9, 21, 19, 12, 402, DateTimeKind.Utc).AddTicks(772), null, true, "This is the subtitle for the first note", "This is the content of the first note.", "First Note", new Guid("008db7ef-8ad6-4346-a7f6-c7b4297aa1ee") },
                    { new Guid("fefcf92b-d1bf-4306-a33b-ccbfdcb86150"), new DateTime(2024, 3, 9, 21, 19, 12, 402, DateTimeKind.Utc).AddTicks(797), null, true, "This is the subtitle for the second note", "This is the content of the second note.", "Second Note", new Guid("008db7ef-8ad6-4346-a7f6-c7b4297aa1ee") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("78976161-641a-43db-a3fb-eee0da21ce7a"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("a3eba7a6-7779-4b50-b814-74b61a8b551a"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("fefcf92b-d1bf-4306-a33b-ccbfdcb86150"));
        }
    }
}
