using AdvBoard.AppServices.BaseRepository;
using AdvBoard.Contracts.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Category.Repository
{
    public interface ICategoryRepository : IRepository<CategoryDto>
    {
        Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
