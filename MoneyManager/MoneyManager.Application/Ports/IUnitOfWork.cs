using System.Threading.Tasks;

namespace MoneyManager.Application.Ports
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
