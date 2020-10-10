using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyManager.Application.Ports;
using MoneyManager.Domain;

namespace MoneyManager.Application.UnitTests.Ports
{
    public class FakeAccountRepository : IAccountRepository
    {
        private readonly List<Account> accounts;

        public FakeAccountRepository()
        {
            accounts = new List<Account>();
        }

        public void Add(Account account) => accounts.Add(account);

        public Task<IEnumerable<Account>> GetAllAsync() => Task.FromResult(accounts.AsEnumerable());
    }
}
