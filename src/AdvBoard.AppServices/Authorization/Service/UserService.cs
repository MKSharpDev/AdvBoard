using AdvBoard.AppServices.Authorization.Repository;
using AdvBoard.AppServices.Helpers;
using AdvBoard.Contracts.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.AppServices.Authorization.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
        }


        public async Task<string> RegisterAsync(UserUpdateRequest userRegisterRequest, CancellationToken cancellationToken)
        {
            string result;
            //Проверяем есть ли пользователь с таким логином, потом прикрутить проверку на почту
            bool loginaAilability = await _userRepository.LoginaAilabilityСheckAsync(userRegisterRequest.Login, cancellationToken);

            if (loginaAilability)
            {
                result = "такой логин уже зарегистрирован выберете другой!";
                return result;
            }

            UserDto userDto = _mapper.Map<UserDto>(userRegisterRequest);

            bool register = await _userRepository.RegisterAsync(userDto, cancellationToken);

            if (!register)
            {
                throw new Exception("Ошибка регистрации");
            }

            result = "Пользователь зарегистрирован";

            return result;
        }
        
        public async Task<string> LoginAsync(AuthDto auth, CancellationToken cancellationToken)
        {
            string result = "не верный логин или пароль!";
            //Проверяем есть ли пользователь с таким логином
            bool loginaAilability = await _userRepository.LoginaAilabilityСheckAsync(auth.Login, cancellationToken);

            //если нет такого логина возвращаем заглушку
            if (!loginaAilability)
            {
                return result;
            }

            var userFromDb = await _userRepository.GetUserInfoAsync(auth.Login, cancellationToken);

            //сделать хэширование в контроллере (сюда уже будет приходить хэш)
            var pass = auth.Password;

            //проверяем пароль и если он не верен возвращаем заглушку
            if (pass != userFromDb.Password)
            {
                return result;
            }

            // генерим Jwt токен и возвращаем в контроллер
            result =  _jwtProvider.GenerateToken(userFromDb);

            return result;
        }
    }
}
