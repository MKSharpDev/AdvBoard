using AdvBoard.Contracts.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Advertisement.Service
{
    public interface IAdvertisemenService
    {
        Task<ICollection<AdvertResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(AdvertRequest request, CancellationToken cancellationToken);
        Task DeletedAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Подумать над тем, что оно должно принеимать ибо еще нужен id, может нужен AdvertWithIdRequest ???
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ICollection<AdvertResponse>> UpdatedAsync(AdverWithIdRequest request, CancellationToken cancellationToken);
    }
}
