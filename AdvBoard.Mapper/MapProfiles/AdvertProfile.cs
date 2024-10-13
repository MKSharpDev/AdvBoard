using AutoMapper;
using AdvBoard.Contracts.Advertisement;
using AdvBoard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.Mapper.MapProfiles
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            CreateMap<AdvertRequest, AdvertisementDto>(MemberList.None);

            CreateMap<AdvertisementDto, AdvertResponse>(MemberList.None);

            CreateMap<Advertisement, AdvertisementDto>(MemberList.None).ReverseMap(); ;
        }
    }
}
