using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JournalEntryLine",
                columns: new[] { "Id", "AccountId", "Credit", "Debit", "JournalEntryId" },
                values: new object[,]
                {
                    { 1, 1, 0m, 1000m, 1 },
                    { 2, 2, 1000m, 0m, 1 },
                    { 3, 1, 0m, 500m, 2 },
                    { 4, 3, 500m, 0m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JournalEntryLine",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JournalEntryLine",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JournalEntryLine",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JournalEntryLine",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
