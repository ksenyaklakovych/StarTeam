using System.Threading;
using System.Threading.Tasks;

namespace StarForum.Domain.Abstract
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsnyc(CancellationToken cancellationToken = default);
    }
}