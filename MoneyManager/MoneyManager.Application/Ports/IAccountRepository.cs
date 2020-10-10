using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Domain;

namespace MoneyManager.Application.Ports
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
    }
}
