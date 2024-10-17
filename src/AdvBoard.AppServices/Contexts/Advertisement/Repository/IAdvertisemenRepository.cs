using AdvBoard.AppServices.BaseRepository;
using AdvBoard.Contracts.Advertisement;
using AdvBoard.Contracts.Advertisement.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Advertisement.Repository
{
    public interface IAdvertisemenRepository: IRepository<AdvertisementDto>
    {
        Task<ICollection<AdvertisementDto>> GetByCategoryIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<ICollection<AdvertisementDto>> SearchAdvertsAsync(SearchAdvertRequest request, CancellationToken cancellationToken);
    }
}
