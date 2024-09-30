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

        public Task<ICollection<AdvertResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
