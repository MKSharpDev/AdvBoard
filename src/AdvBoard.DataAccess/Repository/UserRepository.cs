using AdvBoard.AppServices.Authorization.Repository;
using AdvBoard.Contracts.User;
using AdvBoard.Domain;
using AdvBoard.Infrastructure.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.DataAccess.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly IRepository<User, AdvDbContext> _repository;
        private readonly IMapper _mapper;


        public UserRepository(IRepository<User, AdvDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthDto> GetUserAuthAsync(string login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

        }

        public async Task<UserDto> GetUserInfoAsync(string login, CancellationToken cancellationToken)
        {
            Expression<Func<User, bool>> predicate =
               usr => usr.Login == login;

            var result = _repository.GetByPredicate(predicate);
            var user = await result.FirstOrDefaultAsync(cancellationToken);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> LoginaAilabilityСheckAsync(string login, CancellationToken cancellationToken)
        {
            Expression<Func<User, bool>> predicate =
               usr => usr.Login == login;

            var result = _repository.GetByPredicate(predicate);
            var user = await result.FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> RegisterAsync(UserDto tDto, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<User>(tDto);

            await _repository.AddAsync(user, cancellationToken);

            return true;
        }
    }
}
