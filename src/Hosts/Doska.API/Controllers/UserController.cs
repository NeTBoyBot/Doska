
using Doska.AppServices.Services.User;
using Doska.Contracts.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doska.API.Controllers
{
    [AllowAnonymous]
    //[ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(RegisterRequest request,IFormFile file, CancellationToken token)
        {
            byte[] photo;
            await using (var ms = new MemoryStream())
            await using (var fs = file.OpenReadStream())
            {
                await fs.CopyToAsync(ms);
                photo = ms.ToArray();
            }
            var user = await _userService.Register(request,photo, token);
            return Created("",user);
        }

        [HttpPost("/Login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> login(LoginRequest request, CancellationToken Canctoken)
        {
            var token = await _userService.Login(request, Canctoken);
            return Created("", token);
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

        [HttpGet("/CurrentUser")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoUserResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCurentUser(CancellationToken token)
        {
            var result = await _userService.GetCurrentUser(token);

            return Ok(result);
        }

        [HttpGet("/CurrentUserId")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCurentUserId(CancellationToken token)
        {
            var result = await _userService.GetCurrentUserId(token);

            return Ok(result);
        }
    }
}
