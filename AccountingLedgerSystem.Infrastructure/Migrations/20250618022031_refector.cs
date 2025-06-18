using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_JournalEntry_JournalEntryId",
                table: "JournalEntryLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntryLine",
                table: "JournalEntryLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntry",
                table: "JournalEntry");

            migrationBuilder.RenameTable(
                name: "JournalEntryLine",
                newName: "JournalEntryLines");

            migrationBuilder.RenameTable(
                name: "JournalEntry",
                newName: "JournalEntries");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryLine_JournalEntryId",
                table: "JournalEntryLines",
                newName: "IX_JournalEntryLines_JournalEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntryLines",
                table: "JournalEntryLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntries",
                table: "JournalEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLines_JournalEntries_JournalEntryId",
                table: "JournalEntryLines",
                column: "JournalEntryId",
                principalTable: "JournalEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLines_JournalEntries_JournalEntryId",
                table: "JournalEntryLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntryLines",
                table: "JournalEntryLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntries",
                table: "JournalEntries");

            migrationBuilder.RenameTable(
                name: "JournalEntryLines",
                newName: "JournalEntryLine");

            migrationBuilder.RenameTable(
                name: "JournalEntries",
                newName: "JournalEntry");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryLines_JournalEntryId",
                table: "JournalEntryLine",
                newName: "IX_JournalEntryLine_JournalEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntryLine",
                table: "JournalEntryLine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntry",
                table: "JournalEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_JournalEntry_JournalEntryId",
                table: "JournalEntryLine",
                column: "JournalEntryId",
                principalTable: "JournalEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
