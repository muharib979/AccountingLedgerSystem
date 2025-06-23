using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTrialBalanceDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "JournalEntryLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountName",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountName",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 3,
                column: "AccountName",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 4,
                column: "AccountName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "JournalEntryLines");
        }
    }
}
