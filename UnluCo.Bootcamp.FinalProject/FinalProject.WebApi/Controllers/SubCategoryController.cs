
using AutoMapper;
using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.WebApi.Models.SubCategory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService,IMapper mapper,ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetSubCategories()
        {
            try
            {
                var subCategories = await _subCategoryService.GetAll();
                return Ok(subCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActiveSubCategories()
        {
            try
            {
                var subCategories = await _subCategoryService.GetAllActive();
                return Ok(subCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallinactive")]
        public async Task<IActionResult> GetAllInActiveSubCategories()
        {
            try
            {
                var subCategories = await _subCategoryService.GetAllInActive();
                return Ok(subCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var subCategory = await _subCategoryService.GetbyId(id);
                    if (subCategory != null)
                    {
                        return Ok(subCategory);
                    }
                    return BadRequest(new { message = "Böyle bir alt kategori bulunmuyor!" });
                }
                else
                {
                    return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _subCategoryService.Any(id);
                    if (result)
                    {
                        await _subCategoryService.Delete(id);
                        return Ok(new { message= "Silme işlemi gerçekleşti!" });
                    }

                    return BadRequest(new { message = "Böyle bir alt kategori bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("removesubcategory/{id}")]
        public async Task<IActionResult> RemoveSubCategory(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _subCategoryService.Any(id);

                    if (result)
                    {
                        await _subCategoryService.RemoveFromDb(id);
                        return Ok(new { message = "Kayıtlardan silme işlemi gerçekleşti!" });
                    }
                    return BadRequest(new { message = "Böyle bir alt kategori bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddSubCategory([FromBody] AddSubCategoryModel subCategoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubCategoryDto newSubCategory = new SubCategoryDto();
                    newSubCategory.SubCategoryName = subCategoryModel.SubCategoryName;
                    newSubCategory.Description = subCategoryModel.Description;

                    var categoryDto = await _categoryService.GetbyId(subCategoryModel.CategoryId);
                    if (categoryDto!=null)
                    {
                        newSubCategory.CategoryId = categoryDto.Id;
                    }
                    else
                    {
                        return BadRequest(new { message = "Böyle bir kategori bulunamadı!" });
                    }

                    await _subCategoryService.Add(newSubCategory);

                    return Ok();
                }
                return BadRequest(subCategoryModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSubCategory(int id, [FromBody] UpdateSubCategoryModel Model)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _subCategoryService.Any(id);

                    if (!result)
                    {
                        return BadRequest(new { message = "Böyle bir alt kategori bulunmamaktadır!" });
                    }

                    var resultCategory = await _categoryService.Any(Model.CategoryId);

                    if (!resultCategory)
                    {
                        return BadRequest(new { message = "Böyle bir kategori bulunmamaktadır!" });
                    }

                    var subCategoryDto = await _subCategoryService.GetbyId(id);

                    subCategoryDto.SubCategoryName = Model.SubCategoryName;
                    subCategoryDto.Description = Model.Description;
                    subCategoryDto.CategoryId = Model.CategoryId;

                    await _subCategoryService.Update(subCategoryDto);
                    return Ok(new {message = $"{Model.SubCategoryName} güncellendi!" });
                }
                return BadRequest(new { message = "Böyle bir alt kategori bulunmamaktadır!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getproductsbysubcategory/{id}")]
        public async Task<IActionResult> GetProductsbySubCategory(int id)
        {
            try
            {
                var result = await _subCategoryService.Any(id);
                if (result)
                {
                    var products =  _subCategoryService.GetProductsbySubCategoryId(id);
                    return Ok(products);
                }
                return BadRequest(new { message = "Böyle bir alt kategori bulunmamaktadır!" });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
