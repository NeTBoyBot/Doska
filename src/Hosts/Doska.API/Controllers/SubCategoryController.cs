using Doska.AppServices.Services.Ad;
using Doska.AppServices.Services.Categories;
using Doska.AppServices.Services.SubCategories;
using Doska.Contracts.AdDto;
using Doska.Contracts.CategoryDto;
using Doska.Contracts.SubCategoryDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doska.API.Controllers
{
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        ISubCategoryService _subcategoryService;
        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }
        [HttpGet("/allSubCategories")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoSubCategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip)
        {
            var result = await _subcategoryService.GetAll(take, skip);

            return Ok(result);
        }

        [HttpPost("/createSubCategory")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoSubCategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateSubCategory(string categoryname, Guid? CategoryId)
        {
            var result = await _subcategoryService.CreateSubCategoryAsync(categoryname,(Guid)CategoryId);
            

            return Created("", result);
        }

        [HttpPut("/updateSubCategory/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoSubCategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateSubCategory(Guid id, string categoryname,Guid? CategoryId)
        {
            var result = await _subcategoryService.EditSubCategoryAsync(id, categoryname,CategoryId);

            return Ok(result);
        }

        [HttpDelete("/deleteSubCategory/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteSubCategory(Guid id, string categoryname)
        {
            await _subcategoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
