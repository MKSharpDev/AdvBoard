using AdvBoard.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Authorization.Service
{
    public interface IUserService
    {
        Task<string> RegisterAsync(UserUpdateRequest tDto, CancellationToken cancellationToken);
        Task<string> LoginAsync(AuthDto auth, CancellationToken cancellationToken);

        //Task<UserDto> GetUserInfoAsync(AuthDto auth, CancellationToken cancellationToken);
    }
}
