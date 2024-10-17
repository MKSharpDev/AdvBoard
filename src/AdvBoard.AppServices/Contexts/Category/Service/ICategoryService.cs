using AdvBoard.Contracts.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Category.Service
{
    public interface ICategoryService
    {
        Task<CategoryResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CategoryRequest request, CancellationToken cancellationToken);
        Task DeletedAsync(Guid id, CancellationToken cancellationToken);
        Task<CategoryResponse> UpdatedAsync(CategoryWithIdRequest request, CancellationToken cancellationToken);
        Task<ICollection<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);

    }
}
