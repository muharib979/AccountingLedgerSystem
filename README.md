💼 A Modular Accounting Ledger System

A Modular Accounting System built with ASP.NET Core (Clean Architecture, CQRS, EF Core, Stored Procedure) and React.js (Vite + TailwindCSS).

🚀 Features

Create Accounts

View Account List

Create Journal Entries (with Debit = Credit validation)

View Journal Entries

View Trial Balance

Stored Procedure 

AutoMapper, MediatR, FluentValidation

📷 Screenshots

### 🏠 Home Page

![Home Page](screenshots/Home.png)


### 📥 Create Account
![Create Account](screenshots/create-account.png)
![Create List](screenshots/account-list.png)


### 📄 Journal Entries
![Journal Entries](screenshots/journal-entries.png)
![Journal Entry List](screenshots/journalEntry-list.png)

### 📊 Trial Balance

![Trial Balance](screenshots/trial-balance.png)


⚒️ Tech Stack

Backend: ASP.NET Core 8, EF Core, MediatR, FluentValidation

DB: SQL Server with Stored Procedures

🧲 Sample Test Entries

1. Account

{
  "name": "Cash",
  "type": "Asset"
}

2. Journal Entry

{
  "date": "2025-06-22",
  "description": "Opening Balance",
  "lines": [
    { "accountId": 1, "debit": 1000, "credit": 0 },
    { "accountId": 2, "debit": 0, "credit": 1000 }
  ]
}

▶️ Run Instructions

🧩 Backend (.NET Core)

Clone the repo:

git clone https://github.com/muharib979/AccountingLedgerSystem.git

Navigate to API:

cd AccountingLedgerSystem.API

dotnet ef database update --project ../AccountingLedgerSystem.Infrastructure --startup-project .

Run the backend:

dotnet run

 [View on GitHub](https://github.com/muharib979/AccountingLedgerSystem/blob/main/AccountingLedgerSystem.Infrastructure/Persistence/Context/Database_Scripts_StoreProcedure/AccountingLedgerSystem.sql) 

