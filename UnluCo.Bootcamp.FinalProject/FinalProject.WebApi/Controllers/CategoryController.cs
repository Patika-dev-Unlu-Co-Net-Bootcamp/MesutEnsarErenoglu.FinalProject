using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.WebApi.Models.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        public CategoryController(ICategoryService categoryService,ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActiveCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllActive();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallinactive")]
        public async Task<IActionResult> GetAllInActiveCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllInActive();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                if (id>0)
                {
                    var category = await _categoryService.GetbyId(id);
                    if (category != null)
                    {
                        return Ok(category);
                    }
                    return BadRequest(new { message = "Böyle bir kategori bulunmuyor!" });
                }
                else
                {
                    return BadRequest(new {message = "Böyle bir id bulunmuyor!" });
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                if (id>0)
                {
                    var result = await _categoryService.Any(id);
                    if (result)
                    {
                        await _categoryService.Delete(id);
                        return Ok(new { message = "Silme işlemi gerçekleşti!" });
                    }
                    return BadRequest(new { message = "Böyle bir kategori bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("removecategory/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _categoryService.Any(id);
                    if (result)
                    {
                        await _categoryService.RemoveFromDb(id);
                        return Ok(new { message = "Kayıtlardan tamamen silindi!" });
                    }
                    return BadRequest(new { message = "Böyle bir kategori bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryModel categoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryDto newCategory = new CategoryDto();
                    newCategory.CategoryName = categoryModel.CategoryName;
                    newCategory.Description = categoryModel.Description;
                    await _categoryService.Add(newCategory);
                    return Ok();
                }
                return BadRequest(categoryModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryModel categoryModel)
        {
            try
            {
                CategoryDto category;
                
                if (id>0)
                {
                    var result = await _categoryService.Any(id);
                    if (!result)
                    {
                        return BadRequest(new { message = "Böyle bir kategori bulunmamaktadır!" });
                    }
                    if (ModelState.IsValid)
                    {
                        category = await _categoryService.GetbyId(id);

                        if (categoryModel.SubCategories.Length > 0 )
                        {
                            List<SubCategoryDto> subCategories = new List<SubCategoryDto>();
                            category.SubCategories.Clear();

                            foreach (var item in categoryModel.SubCategories)
                            {
                                var subCategory = await _subCategoryService.GetbyId(item);
                                if (subCategory != null)
                                {
                                    subCategories.Add(subCategory);
                                }
                                else
                                {
                                    return BadRequest(new { message = "Böyle bir alt kategori bulunmamaktadır!" });
                                }
                            }
                            category.SubCategories.AddRange(subCategories);
                        }
                        category.CategoryName = categoryModel.CategoryName;
                        category.Description = categoryModel.Description;
                        
                        await _categoryService.Update(category);
                        return Ok(new { message = $"{categoryModel.CategoryName} güncellendi" });

                    }
                    return BadRequest(categoryModel);
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getproductsbycategoryid/{id}")]
        public IActionResult GetProductsbyCategoryId(int id)
        {
            try
            {
                var products =  _categoryService.GetProductsbyCategoryId(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
