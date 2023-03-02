using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.Contracts.AdDto;
using Doska.Contracts.UserDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.User
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IAdRepository _adRepository;
        public readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper,IAdRepository adRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _adRepository = adRepository;
        }

        public async Task<Guid> CreateUserAsync(RegisterRequest registerUser)
        {
            var newUser = _mapper.Map<Domain.User>(registerUser);
            await _userRepository.AddAsync(newUser);

            return newUser.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingUser = await _userRepository.FindById(id);
            await _userRepository.DeleteAsync(existingUser);
        }

        public async Task<InfoUserResponse> EditUserAsync(Guid Id, RegisterRequest editUser)
        {
            var existingUser = await _userRepository.FindById(Id);
            await _userRepository.EditUserAsync(_mapper.Map(editUser, existingUser));

            return _mapper.Map<InfoUserResponse>(editUser);
        }

        public async Task<IReadOnlyCollection<InfoUserResponse>> GetAll(int take, int skip)
        {
            return await _userRepository.GetAll()
                .Select(a => new InfoUserResponse
                {
                    Id = a.Id,
                    Name = a.Name
                }).OrderBy(a => a.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoUserResponse> GetByIdAsync(Guid id)
        {
            var existingUser = await _userRepository.FindById(id);
            return _mapper.Map<InfoUserResponse>(existingUser);
        }
    }
}
