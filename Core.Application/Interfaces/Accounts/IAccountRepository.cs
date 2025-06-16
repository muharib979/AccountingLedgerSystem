using Core.Domain.Entities.Account;


namespace Core.Application.Interfaces.Accounts
{
    public interface IAccountRepository
    {
        Task<int> CreateAccount(Account account);
        Task<List<Account>> GetAllAccounts();
    }
}
