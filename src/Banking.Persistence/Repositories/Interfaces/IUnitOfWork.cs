using System.Threading.Tasks;

namespace Banking.Persistence.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}