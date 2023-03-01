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
        Task<InfoUserResponse> GetByIdAsync(Guid id);

        Task<Guid> CreateUserAsync(RegisterRequest registerUser);

        Task<IReadOnlyCollection<InfoUserResponse>> GetAll(int take, int skip);

        Task DeleteAsync(Guid id);

        Task<InfoUserResponse> EditUserAsync(Guid Id, RegisterRequest editAd);
    }
}
