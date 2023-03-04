using Doska.AppServices.Services.Comment;
using Doska.Contracts.CommentDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doska.API.Controllers
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("/allComments")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoCommentResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip)
        {
            var result = await _commentService.GetAll(take, skip);

            return Ok(result);
        }

        [HttpPost("/createComment")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoCommentResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAd(CreateCommentRequest request)
        {
            var result = await _commentService.CreateCommentAsync(request);

            return Created("", result);
        }

        [HttpDelete("/deleteComment/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            await _commentService.DeleteAsync(id);
            return Ok();
        }
    }
}
