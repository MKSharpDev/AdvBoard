using AdvBoard.Contracts.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Advertisement.Service
{
    public class AdvertisemenService : IAdvertisemenService
    {
        public AdvertisemenService() { }

        public Task CreateAsync(AdvertRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeletedAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AdvertResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AdvertResponse>> UpdatedAsync(AdverWithIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
