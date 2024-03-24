using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNote.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("0a86f0d7-7952-4dd1-9177-eda0870b43a1"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("63d20bb8-cd29-4fb5-baae-4b149de7817d"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("8e86a5bf-cdf8-4d22-9af4-099be190bc25"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 24, 3, 49, 54, 329, DateTimeKind.Utc).AddTicks(6009),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedAt", "FolderId", "IsActive", "Subtitle", "Text", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("72c8061d-e225-4fd6-80b3-49e96df78cbd"), new DateTime(2024, 3, 24, 3, 49, 54, 329, DateTimeKind.Utc).AddTicks(2788), null, true, "This is the subtitle for the second note", "This is the content of the second note.", "Second Note", new Guid("0f129c2a-ada6-452c-a557-d5b11e9373e2") },
                    { new Guid("863686f6-8ab1-47c4-aa23-4f58f4ae3b70"), new DateTime(2024, 3, 24, 3, 49, 54, 329, DateTimeKind.Utc).AddTicks(2791), null, true, "This is the subtitle for the third note", "This is the content of the third note.", "Third Note", new Guid("0f129c2a-ada6-452c-a557-d5b11e9373e2") },
                    { new Guid("fbe5cdf7-138d-480a-bd10-06d611b71485"), new DateTime(2024, 3, 24, 3, 49, 54, 329, DateTimeKind.Utc).AddTicks(2764), null, true, "This is the subtitle for the first note", "This is the content of the first note.", "First Note", new Guid("0f129c2a-ada6-452c-a557-d5b11e9373e2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("72c8061d-e225-4fd6-80b3-49e96df78cbd"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("863686f6-8ab1-47c4-aa23-4f58f4ae3b70"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("fbe5cdf7-138d-480a-bd10-06d611b71485"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 3, 24, 3, 49, 54, 329, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedAt", "FolderId", "IsActive", "Subtitle", "Text", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a86f0d7-7952-4dd1-9177-eda0870b43a1"), new DateTime(2024, 3, 14, 16, 7, 32, 653, DateTimeKind.Utc).AddTicks(3430), null, true, "This is the subtitle for the third note", "This is the content of the third note.", "Third Note", new Guid("0f129c2a-ada6-452c-a557-d5b11e9373e2") },
                    { new Guid("63d20bb8-cd29-4fb5-baae-4b149de7817d"), new DateTime(2024, 3, 14, 16, 7, 32, 653, DateTimeKind.Utc).AddTicks(3409), null, true, "This is the subtitle for the first note", "This is the content of the first note.", "First Note", new Guid("0f129c2a-ada6-452c-a557-d5b11e9373e2") },
                    { new Guid("8e86a5bf-cdf8-4d22-9af4-099be190bc25"), new DateTime(2024, 3, 14, 16, 7, 32, 653, DateTimeKind.Utc).AddTicks(3427), null, true, "This is the subtitle for the second note", "This is the content of the second note.", "Second Note", new Guid("0f129c2a-ada6-452c-a557-d5b11e9373e2") }
                });
        }
    }
}
