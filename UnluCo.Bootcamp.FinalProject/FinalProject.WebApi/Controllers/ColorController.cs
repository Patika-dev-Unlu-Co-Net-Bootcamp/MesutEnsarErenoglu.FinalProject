using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.WebApi.Models.Color;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/colors")]
    [ApiController]
    [Authorize]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetColors()
        {
            try
            {
                var colors = await _colorService.GetAll();
                return Ok(colors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActiveColors()
        {
            try
            {
                var colors = await _colorService.GetAllActive();
                return Ok(colors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallinactive")]
        public async Task<IActionResult> GetAllInActiveColors()
        {
            try
            {
                var colors = await _colorService.GetAllInActive();
                return Ok(colors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var color = await _colorService.GetbyId(id);
                    if (color != null)
                    {
                        return Ok(color);
                    }
                    return BadRequest(new { message = "Böyle bir renk bulunmuyor!" });
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
        public async Task<IActionResult> DeleteColor(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _colorService.Any(id);
                    if (result)
                    {
                        await _colorService.Delete(id);
                        return Ok(new { message = "Silme işlemi gerçekleşti!" });
                    }
                    return BadRequest(new { message = "Böyle bir renk bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("removecolor/{id}")]
        public async Task<IActionResult> RemoveColor(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _colorService.Any(id);
                    if (result)
                    {
                        await _colorService.RemoveFromDb(id);
                        return Ok(new { message = "Kayıtlardan tamamen silindi!" });
                    }
                    return BadRequest(new { message = "Böyle bir renk bulunmuyor!" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] AddColorModel colorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ColorDto newColor = new ColorDto();
                    newColor.Name = colorModel.Name;
                    newColor.Hex = colorModel.Hex;
                    await _colorService.Add(newColor);
                    return Ok();
                }
                return BadRequest(colorModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor(int id, [FromBody] UpdateColorModel colorModel)
        {
            try
            {
                ColorDto color;

                if (id > 0)
                {
                    var result = await _colorService.Any(id);
                    if (!result)
                    {
                        return BadRequest(new { message = "Böyle bir renk bulunmamaktadır!" });
                    }
                    if (ModelState.IsValid)
                    {
                        color = await _colorService.GetbyId(id);
                        if (color != null)
                        {
                            color.Name = colorModel.Name;
                            color.Hex = colorModel.Hex;
                            await _colorService.Update(color);
                            return Ok(new { message = $"{colorModel.Name} güncellendi" });
                        }
                        return BadRequest(new { message = "Böyle bir renk bulunmuyor!" });

                    }
                    return BadRequest(colorModel);
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
