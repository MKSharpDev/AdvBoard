using AdvBoard.AppServices.Contexts.Advertisement.Repository;
using AdvBoard.Contracts.Advertisement;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Advertisement.Service
{
    public class AdvertisemenService : IAdvertisemenService
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisemenRepository _advertRepository;

        public AdvertisemenService(
             IAdvertisemenRepository advertRepository,
             IMapper mapper
            ) 
        { 
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(AdvertRequest request, CancellationToken cancellationToken)
        {
            var advertDto = _mapper.Map<AdvertisementDto>(request);
            var id = await _advertRepository.CreateAsync(advertDto, cancellationToken);
            return id;

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
