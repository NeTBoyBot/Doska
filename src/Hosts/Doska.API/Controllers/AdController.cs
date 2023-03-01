using Doska.AppServices.Services.Ad;
using Doska.Contracts.AdDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doska.API.Controllers
{
    [ApiController]
    public class AdController : ControllerBase
    {
        IAdService _adService;
        public AdController(IAdService adService)
        {
            _adService = adService;
        }
        [HttpGet("/all")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAdResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip)
        {
            var result = await _adService.GetAll(take, skip);

            return Ok(result);
        }

        [HttpPost("/createAd")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAdResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAd(CreateOrUpdateAdRequest request)
        {
            var result = await _adService.CreateAdAsync(request);

            return Created("",result);
        }

        [HttpPut("/updateAd/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAdResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateAd(Guid id,CreateOrUpdateAdRequest request)
        {
            var result = await _adService.EditAdAsync(id,request);

            return Ok(result);
        }

        [HttpDelete("/deleteAd/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAd(Guid id, CreateOrUpdateAdRequest request)
        {
            await _adService.DeleteAsync(id);
            return Ok();
        }
    }
}
