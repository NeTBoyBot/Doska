using Doska.AppServices.Services.Chat;
using Doska.AppServices.Services.Message;
using Doska.Contracts.Chat;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doska.API.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpGet("/allChats")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoChatResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip)
        {
            var result = await _chatService.GetAll(take, skip);

            return Ok(result);
        }

        [HttpPost("/createChat")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoChatResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateСhat(CreateChatRequest request)
        {
            var result = await _chatService.CreateChatAsync(request);

            return Created("", result);
        }


        [HttpDelete("/deleteChat/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAd(Guid id)
        {
            await _chatService.DeleteAsync(id);
            return Ok();
        }
    }
}
