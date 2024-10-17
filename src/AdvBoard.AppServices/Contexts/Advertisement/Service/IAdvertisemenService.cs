using AdvBoard.Contracts.Advertisement;
using AdvBoard.Contracts.Advertisement.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Advertisement.Service
{
    public interface IAdvertisemenService
    {
        Task<AdvertResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(AdvertRequest request, CancellationToken cancellationToken);
        Task DeletedAsync(Guid id, CancellationToken cancellationToken);

        Task<AdvertResponse> UpdatedAsync(AdverWithIdRequest request, CancellationToken cancellationToken);

        Task<ICollection<AdvertResponse>> GetByCategoryIdAsync(Guid Id, CancellationToken cancellationToken);

        Task<ICollection<AdvertResponse>> SearchAdvertsAsync(SearchAdvertRequest request, CancellationToken cancellationToken);

    }
}
