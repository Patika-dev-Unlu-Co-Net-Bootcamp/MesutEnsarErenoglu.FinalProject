using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.WebApi.Models.Brand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/brands")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetBrands()
        {
            try
            {
                var brands = await _brandService.GetAll();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActiveBrands()
        {
            try
            {
                var brands = await _brandService.GetAllActive();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallinactive")]
        public async Task<IActionResult> GetAllInActiveBrands()
        {
            try
            {
                var brands = await _brandService.GetAllInActive();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var brand = await _brandService.GetbyId(id);
                    if (brand != null)
                    {
                        return Ok(brand);
                    }
                    return BadRequest(new { message = "Böyle bir marka bulunmuyor!" });
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

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _brandService.Any(id);
                    if (result)
                    {
                        await _brandService.Delete(id);
                        return Ok(new { message = "Silme işlemi gerçekleşti!" });
                    }
                    return BadRequest(new { message = "Böyle bir marka bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("removebrand/{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _brandService.Any(id);
                    if (result)
                    {
                        await _brandService.RemoveFromDb(id);
                        return Ok(new { message = "Kayıtlardan tamamen silindi!" });
                    }
                    return BadRequest(new { message = "Böyle bir marka bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] AddBrandModel brandModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BrandDto newColor = new BrandDto();
                    newColor.Name = brandModel.Name;
                    newColor.Description = brandModel.Description;
                    await _brandService.Add(newColor);
                    return Ok();
                }
                return BadRequest(brandModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandModel brandModel)
        {
            try
            {
                BrandDto brand;

                if (id > 0)
                {
                    var result = await _brandService.Any(id);
                    if (!result)
                    {
                        return BadRequest(new { message = "Böyle bir marka bulunmamaktadır!" });
                    }
                    if (ModelState.IsValid)
                    {
                        brand = await _brandService.GetbyId(id);
                        if (brand != null)
                        {
                            brand.Name = brandModel.Name;
                            brand.Description = brandModel.Description;
                            await _brandService.Update(brand);
                            return Ok(new { message = $"{brandModel.Name} güncellendi" });
                        }
                        return BadRequest(new { message = "Böyle bir marka bulunmuyor!" });

                    }
                    return BadRequest(brandModel);
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
