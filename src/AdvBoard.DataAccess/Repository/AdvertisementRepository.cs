using AdvBoard.AppServices.Contexts.Advertisement.Repository;
using AdvBoard.Contracts.Advertisement;
using AdvBoard.Domain;
using AdvBoard.Infrastructure.Repository;
using AutoMapper;
using AdvBoard.DataAccess;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using AdvBoard.Contracts.Advertisement.Specifications;

namespace AdvBoard.DataAccess.Repository
{
    public class AdvertisementRepository : IAdvertisemenRepository
    {
        private readonly IRepository<Advertisement, AdvDbContext> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AdvertRepository"/>.
        /// </summary>
        public AdvertisementRepository(IRepository<Advertisement, AdvDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateAsync(AdvertisementDto tDto, CancellationToken cancellationToken)
        {
            var advert = _mapper.Map<Advertisement>(tDto);

            await _repository.AddAsync(advert, cancellationToken);

            return advert.Id;
        }

        public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(Id, cancellationToken);
        }

        public async Task<ICollection<AdvertisementDto>> GetByCategoryIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByPredicate(x => x.CategoryId == Id).ToListAsync(cancellationToken);
            return _mapper.Map<ICollection<AdvertisementDto>>(result);
        }

        public async Task<AdvertisementDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            var advert = await _repository.GetByIdAsync(Id, cancellationToken);

            return _mapper.Map<AdvertisementDto>(advert);
        }

        public async Task<AdvertisementDto> UpdateAsync(AdvertisementDto tDto, CancellationToken cancellationToken)
        {
            var advert = _mapper.Map<Advertisement>(tDto);

            await _repository.UpdateAsync(advert, cancellationToken);

            //это не совсем правильно и слишком много запросов в бд, но пока пусть так
            var advertResult = await _repository.GetByIdAsync(tDto.Id, cancellationToken);

            return _mapper.Map<AdvertisementDto>(advertResult);
        }


        public async Task<ICollection<AdvertisementDto>> SearchAdvertsAsync (SearchAdvertRequest request, CancellationToken cancellationToken)
        {

            string searchString = request.Search;

            //ищем попадание строки
            Expression<Func<Advertisement, bool>> predicate =
                 adv => adv.Name.ToLower().Contains(searchString.ToLower()) ||
                    adv.Description.ToLower().Contains(searchString.ToLower());

            var result = _repository.GetByPredicate(predicate);

            //если есть условие по макс цене
            if (request.MaxPrice.HasValue)
            {
                var maxPrice = request.MaxPrice.Value;

                //в нашем квери делаем выборку
                result = result.Where(adv => adv.Price <= maxPrice);
            }

            //если есть условие по мин цене
            if (request.MinPrice.HasValue)
            {
                var minPrice = request.MinPrice.Value;
                result = result.Where(adv => adv.Price >= minPrice);
            }

            //тут формируентся запрос к бд
            await result.ToListAsync(cancellationToken);

            return _mapper.Map<ICollection<AdvertisementDto>>(result);
        }
    }
}
