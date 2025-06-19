using AccountingLedgerSystem.Infrastructure.Persistence.Context;
using Core.Application.Interfaces.Journal;
using Core.Domain.Entities.Journal;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Journal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Repositories.Journal
{
    public class JournalEntryRepository : IJournalEntryRepository
    {

        private readonly ApplicationDbContext _context;

        public JournalEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateJournalEntryAsync(JournalEntry journalEntry, List<JournalEntryLineDto> lines)
        {
            var resultParam = new SqlParameter
            {
                ParameterName = "@Result",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var linesTable = new DataTable();
            linesTable.Columns.Add("AccountId", typeof(int));
            linesTable.Columns.Add("Debit", typeof(decimal));
            linesTable.Columns.Add("Credit", typeof(decimal));

            foreach (var line in lines)
            {
                linesTable.Rows.Add(line.AccountId, line.Debit, line.Credit);
            }

            var parameters = new[]
            {
        new SqlParameter("@Date", journalEntry.Date),
        new SqlParameter("@Description", journalEntry.Description),
        new SqlParameter("@Lines", linesTable) { SqlDbType = SqlDbType.Structured, TypeName = "dbo.JournalEntryLineType" },
        resultParam
    };

            await _context.Database.ExecuteSqlRawAsync("EXEC SP_CreateJournalEntry @Date, @Description, @Lines, @Result OUTPUT", parameters);

            return (int)resultParam.Value > 0;
        }

        public async Task<List<JournalEntry>> GetAllJournalEntriesAsync()
        {

            using var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var command = conn.CreateCommand();
            command.CommandText = "SP_GetAllJournalEntries";
            command.CommandType = CommandType.StoredProcedure;

            var entries = new List<JournalEntry>();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var entryId = reader.GetInt32(reader.GetOrdinal("JournalEntryId"));
                var existing = entries.FirstOrDefault(e => e.Id == entryId);

                if (existing == null)
                {
                    existing = new JournalEntry
                    {
                        Id = entryId,
                        Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        Lines = new List<JournalEntryLine>()
                    };
                    entries.Add(existing);
                }

                existing.Lines.Add(new JournalEntryLine
                {
                    Id = reader.GetInt32(reader.GetOrdinal("LineId")),
                    AccountId = reader.GetInt32(reader.GetOrdinal("AccountId")),
                    Debit = reader.GetDecimal(reader.GetOrdinal("Debit")),
                    Credit = reader.GetDecimal(reader.GetOrdinal("Credit"))
                });
            }

            return entries;
        }
    }
}
