using AdvBoard.AppServices.Contexts.Advertisement.Repository;
using AdvBoard.AppServices.Contexts.Category.Repository;
using AdvBoard.Contracts.Advertisement;
using AdvBoard.Contracts.Category;
using AdvBoard.Domain;
using AdvBoard.Infrastructure.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.DataAccess.Repository
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Category, AdvDbContext> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AdvertRepository"/>.
        /// </summary>
        public CategoryRepository(IRepository<Category, AdvDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateAsync(CategoryDto tDto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(tDto);

            await _repository.AddAsync(category, cancellationToken);

            return category.Id;
        }

        public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(Id, cancellationToken);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            var advert = await _repository.GetByIdAsync(Id, cancellationToken);

            return _mapper.Map<CategoryDto>(advert);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto tDto, CancellationToken cancellationToken)
        {
            var сategory = _mapper.Map<Category>(tDto);

            await _repository.UpdateAsync(сategory, cancellationToken);

            //это не совсем правильно и слишком много запросов в бд, но пока пусть так
            var сategoryResult = await _repository.GetByIdAsync(tDto.Id, cancellationToken);

            return _mapper.Map<CategoryDto>(сategoryResult);
        }
    }
}
