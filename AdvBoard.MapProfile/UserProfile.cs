using AdvBoard.Contracts.Advertisement;
using AdvBoard.Contracts.User;
using AdvBoard.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.MapProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>(MemberList.None);
            CreateMap<UserDto, User>(MemberList.None);


            CreateMap<UserDto, UserUpdateRequest>(MemberList.None).ReverseMap();

        }
    }
}
