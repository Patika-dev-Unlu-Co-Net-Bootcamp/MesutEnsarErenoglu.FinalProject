using AutoMapper;
using FinalProject.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService _userService;

        public UserController(IAppUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var appUser = await _userService.GetbyId(id);
                    if (appUser != null)
                    {
                        return Ok(appUser);
                    }
                    return BadRequest(new { message = "Böyle bir kullanıcı bulunmuyor!" });
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
        [HttpGet("getbyemail")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var appUser = await _userService.GetbyEmail(email);
                    if (appUser != null)
                    {
                        return Ok(appUser);
                    }
                    return BadRequest(new { message = "Böyle bir kullanıcı bulunmuyor!" });
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
        public async Task<IActionResult> DeleteUserbyId(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var result = await _userService.DeletebyId(id);
                    return Ok(new { message = $"{result}" });

                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("deletebyemail")]
        public async Task<IActionResult> DeleteUserbyEmail([FromQuery] string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var result = await _userService.DeletebyId(email);
                    return Ok(new { message = $"{result}" });

                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("removeuser/{id}")]
        public async Task<IActionResult> RemoveUser(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var result = await _userService.RemoveFromDb(id);
                    return Ok(new { message = $"{result}" });
                }
                return BadRequest(new { message = "Böyle bir id bulunmuyor!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("activeusers")]
        public IActionResult GetActiveUsers()
        {
            try
            {
                var users = _userService.GetAllActive();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor(int id, [FromBody] UpdateColorModel colorModel)
        {
            try
            {
                AppUserDto appUser;

                if (id > 0)
                {
                    var result = await _userService.Any(id);
                    if (!result)
                    {
                        return BadRequest(new { message = "Böyle bir renk bulunmamaktadır!" });
                    }
                    if (ModelState.IsValid)
                    {
                        appUser = await _userService.GetbyId(id);
                        if (appUser != null)
                        {
                            appUser.Name = colorModel.Name;
                            appUser.Hex = colorModel.Hex;
                            await _userService.Update(appUser);
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
        */

    }
}
