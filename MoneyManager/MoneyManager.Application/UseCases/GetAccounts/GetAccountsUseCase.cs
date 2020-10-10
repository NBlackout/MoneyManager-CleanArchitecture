using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyManager.Application.Ports;
using MoneyManager.Domain;

namespace MoneyManager.Application.UseCases.GetAccounts
{
    public class GetAccountsUseCase
    {
        private readonly IAccountRepository accountRepository;

        public GetAccountsUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<IEnumerable<GetAccountsResult>> ExecuteAsync()
        {
            IEnumerable<Account> accounts = await accountRepository.GetAllAsync();

            return accounts.Select(a => new GetAccountsResult { Label = a.Label });
        }
    }
}
