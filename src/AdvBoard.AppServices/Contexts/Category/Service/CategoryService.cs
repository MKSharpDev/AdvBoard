using AdvBoard.AppServices.Contexts.Category.Repository;
using AdvBoard.Contracts.Category;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Contexts.Category.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
             ICategoryRepository categoryRepository,
             IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CategoryRequest request, CancellationToken cancellationToken)
        {
            var categorytDto = _mapper.Map<CategoryDto>(request);
            var id = await _categoryRepository.CreateAsync(categorytDto, cancellationToken);
            return id;

        }

        public async Task DeletedAsync(Guid id, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<CategoryResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<CategoryResponse>(category);
        }


        //в путе надо добавить проверку на наличие записи перед её редактированием
        public async Task<CategoryResponse> UpdatedAsync(CategoryWithIdRequest request, CancellationToken cancellationToken)
        {
            var advertDto = _mapper.Map<CategoryDto>(request);

            var advert = await _categoryRepository.UpdateAsync(advertDto, cancellationToken);
            return _mapper.Map<CategoryResponse>(advert);
        }
    }

}
