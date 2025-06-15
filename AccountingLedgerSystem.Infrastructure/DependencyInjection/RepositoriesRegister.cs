using AccountingLedgerSystem.Infrastructure.Persistence.Context;
using AccountingLedgerSystem.Infrastructure.Persistence.Repositories.Accounts;
using Core.Application.Commands.Accounts;
using Core.Application.Common.Mapper.Accounts;
using Core.Application.Interfaces.Accounts;
using FluentValidation;
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
            services.AddAutoMapper(typeof(AccountProfile)); 
            services.AddValidatorsFromAssemblyContaining<CreateAccountValidator>();
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining<CreateAccountCommand>());
        }
    }
}
