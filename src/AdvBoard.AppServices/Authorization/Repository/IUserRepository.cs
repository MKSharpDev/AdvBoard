using AdvBoard.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Authorization.Repository
{
    public interface IUserRepository
    {
        Task<bool> RegisterAsync(UserDto tDto, CancellationToken cancellationToken);
        //Task UpdateAsync(UserUpdateRequest updateReques, CancellationToken cancellationToken);
        Task<AuthDto> GetUserAuthAsync (string login, CancellationToken cancellationToken);
        Task<UserDto> GetUserInfoAsync(string login, CancellationToken cancellationToken);
        Task<bool> LoginaAilabilityСheckAsync(string login, CancellationToken cancellationToken);
    }
}
