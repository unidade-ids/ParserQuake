using System.Threading.Tasks;

namespace Treinee.Quake.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task CreateTransaction();
        Task Commit();
        Task RollBack();
        Task Save();
    }
}
