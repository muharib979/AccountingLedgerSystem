﻿using Core.Domain.Entities.Account;
using Core.Domain.Entities.Journal;
using Core.Domain.Entities.TrialBalance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<JournalEntryLine> JournalEntryLines { get; set; }
        public DbSet<TrialBalance> TrialBalances { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JournalEntryLine>()
                .Property(j => j.Debit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<JournalEntryLine>()
                .Property(j => j.Credit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TrialBalance>().HasNoKey(); 
            modelBuilder.Entity<TrialBalance>().ToView(null);

            modelBuilder.Entity<TrialBalance>(entity =>
            {
                entity.Property(e => e.TotalDebit).HasPrecision(18, 2);
                entity.Property(e => e.TotalCredit).HasPrecision(18, 2);
                entity.Property(e => e.NetBalance).HasPrecision(18, 2);
            });


            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Name = "Cash", Type = "Asset" },
                new Account { Id = 2, Name = "Sales Revenue", Type = "Income" }
            );

            modelBuilder.Entity<JournalEntry>().HasData(
            new JournalEntry
            {
                Id = 1,
                Date = new DateTime(2024, 01, 01),
                Description = "Initial cash deposit"
            },
            new JournalEntry
            {
                Id = 2,
                Date = new DateTime(2024, 02, 15),
                Description = "Sold products for cash"
            }
        );
            modelBuilder.Entity<JournalEntryLine>().HasData(
    // Journal Entry 1
    new JournalEntryLine
    {
        Id = 1,
        JournalEntryId = 1,
        AccountId = 1,         
        Debit = 1000,
        Credit = 0
    },
    new JournalEntryLine
    {
        Id = 2,
        JournalEntryId = 1,
        AccountId = 2,        
        Debit = 0,
        Credit = 1000
    },

 
    new JournalEntryLine
    {
        Id = 3,
        JournalEntryId = 2,
        AccountId = 1,       
        Debit = 500,
        Credit = 0
    },
    new JournalEntryLine
    {
        Id = 4,
        JournalEntryId = 2,
        AccountId = 3,         
        Debit = 0,
        Credit = 500
    }
);
        }
    }
}