﻿using Doska.AppServices.Services.Ad;
using Doska.AppServices.Services.Categories;
using Doska.Contracts.AdDto;
using Doska.Contracts.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doska.API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("/allCategories")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoCategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip)
        {
            var result = await _categoryService.GetAll(take, skip);

            return Ok(result);
        }

        [HttpPost("/createCategory")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoCategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAd(string categoryname)
        {
            var result = await _categoryService.CreateCategoryAsync(categoryname);

            return Created("", result);
        }

        [HttpPut("/updateCategory/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoCategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateAd(Guid id, string categoryname)
        {
            var result = await _categoryService.EditCategoryAsync(id, categoryname);

            return Ok(result);
        }

        [HttpDelete("/deleteCategory/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAd(Guid id, string categoryname)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
