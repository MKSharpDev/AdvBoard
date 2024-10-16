using AdvBoard.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Helpers
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto user);
    }
}
