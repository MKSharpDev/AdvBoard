using AdvBoard.Contracts.Advertisement;
using AdvBoard.Contracts.Category;
using AdvBoard.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.MapProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequest, CategoryDto>(MemberList.None);
            CreateMap<CategoryWithIdRequest, CategoryDto>(MemberList.None);

            CreateMap<CategoryDto, CategoryResponse>(MemberList.None);

            CreateMap<Category, CategoryDto>(MemberList.None).ReverseMap(); ;
        }
    }
}
