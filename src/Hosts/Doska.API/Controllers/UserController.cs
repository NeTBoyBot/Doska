
using Doska.AppServices.Services.User;
using Doska.Contracts.UserDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doska.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("/allusers")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoUserResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip)
        {
            var result = await _userService.GetAll(take, skip);

            return Ok(result);
        }

        [HttpPost("/createUser")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoUserResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUser(RegisterRequest request)
        {
            var result = await _userService.CreateUserAsync(request);

            return Created("", result);
        }

        [HttpPut("/updateUser/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoUserResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser(Guid id, RegisterRequest request)
        {
            var result = await _userService.EditUserAsync(id, request);

            return Ok(result);
        }

        [HttpDelete("/deleteUser/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteUser(Guid id, RegisterRequest request)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
