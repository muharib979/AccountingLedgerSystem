﻿// <auto-generated />
using System;
using AccountingLedgerSystem.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Entities.Account.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cash",
                            Type = "Asset"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sales Revenue",
                            Type = "Income"
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.Journal.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JournalEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Initial cash deposit"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sold products for cash"
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.Journal.JournalEntryLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Credit")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Debit")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JournalEntryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JournalEntryId");

                    b.ToTable("JournalEntryLines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Credit = 0m,
                            Debit = 1000m,
                            JournalEntryId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 2,
                            Credit = 1000m,
                            Debit = 0m,
                            JournalEntryId = 1
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 1,
                            Credit = 0m,
                            Debit = 500m,
                            JournalEntryId = 2
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 3,
                            Credit = 500m,
                            Debit = 0m,
                            JournalEntryId = 2
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.TrialBalance.TrialBalance", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NetBalance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalCredit")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDebit")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Journal.JournalEntryLine", b =>
                {
                    b.HasOne("Core.Domain.Entities.Journal.JournalEntry", null)
                        .WithMany("Lines")
                        .HasForeignKey("JournalEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Entities.Journal.JournalEntry", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}
