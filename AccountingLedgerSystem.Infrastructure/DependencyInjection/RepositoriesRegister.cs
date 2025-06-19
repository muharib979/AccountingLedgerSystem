using AccountingLedgerSystem.Infrastructure.Persistence.Context;
using AccountingLedgerSystem.Infrastructure.Persistence.Repositories.Accounts;
using AccountingLedgerSystem.Infrastructure.Persistence.Repositories.Journal;
using AccountingLedgerSystem.Infrastructure.Persistence.Repositories.TrialBalance;
using Core.Application.Commands.Accounts;
using Core.Application.Common.Behaviors;
using Core.Application.Common.Mapper.Accounts;
using Core.Application.Common.Mapper.Accounts.Journal;
using Core.Application.Interfaces.Accounts;
using Core.Application.Interfaces.Journal;
using Core.Application.Interfaces.TrailBalance;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingLedgerSystem.Infrastructure.DependencyInjection
{
    public static class RepositoriesRegister
    {
        public static void AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
        
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IJournalEntryRepository, JournalEntryRepository>();
            services.AddScoped<ITrialBalanceRepository, TrialBalanceRepository>();
            services.AddAutoMapper(typeof(AccountProfile), typeof(JournalEntryProfile));
            services.AddValidatorsFromAssemblyContaining<CreateAccountValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining<CreateAccountCommand>());
            
        }
    }
}
