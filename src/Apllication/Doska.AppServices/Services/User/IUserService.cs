using Doska.Contracts.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="registerRequest"> Дто с логином, паролем, почтой и регионом</param>
        /// <returns></returns>
        public Task<Guid> Register(RegisterRequest registerRequest,CancellationToken cancellationToken);

        /// <summary>
        /// Логин пользователя
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>Токен</returns>
        public Task<string> Login(LoginRequest loginRequest, CancellationToken cancellationToken);

        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        /// <returns></returns>
        Task<InfoUserResponse> GetCurrentUser(CancellationToken cancellationToken);

        Task<Guid> GetCurrentUserId(CancellationToken cancellationToken);

        Task<InfoUserResponse> GetByIdAsync(Guid id);

        Task<Guid> CreateUserAsync(RegisterRequest registerUser);

        Task<IReadOnlyCollection<InfoUserResponse>> GetAll(int take, int skip);

        Task DeleteAsync(Guid id);

        Task<InfoUserResponse> EditUserAsync(Guid Id, RegisterRequest editAd);


    }
}
