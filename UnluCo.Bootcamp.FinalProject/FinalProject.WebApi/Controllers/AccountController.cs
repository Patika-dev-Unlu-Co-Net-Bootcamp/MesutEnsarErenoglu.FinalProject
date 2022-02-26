﻿using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.Application.Token;
using FinalProject.WebApi.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserService _userService;
        private readonly TokenGenerator _tokenGenerator;

        public AccountController(IAppUserService userService, TokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AddAppUserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.AnybyEmail(userModel.Email);

                    if (!result)
                    {
                        return BadRequest("Bu emaile sahip bir kullanıcı bulunuyor!");
                    }

                    AppUserDto newUser = new AppUserDto();
                    newUser.FirstName = userModel.FirstName;
                    newUser.LastName = userModel.LastName;
                    newUser.Email = userModel.Email;
                    newUser.Password = userModel.Password;
                    newUser.PhoneNumber = userModel.PhoneNumber;
                    newUser.Address = userModel.Address;
                    newUser.BirthDate = userModel.BirthDate;
                    newUser.City = userModel.City;
                    newUser.Gender = userModel.Gender;
                    newUser.Region = userModel.Region;
                    newUser.UserName = userModel.Email;

                    await _userService.Add(newUser);
                    return Ok();
                }
                return BadRequest(userModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userResult =await _userService.AnybyEmail(userModel.Email);
                    if (!userResult)
                    {
                        return BadRequest("Böyle bir kullanıcı bulunamadı!");
                    }
                    var passwordCheck = await _userService.CheckPassword(userModel.Email, userModel.Password);
                    if (!passwordCheck)
                    {
                        return BadRequest("Mail adresiniz ve şifreniz uyumsuz!");
                    }
                    var user = await _userService.GetbyEmail(userModel.Email);
                    var token = _tokenGenerator.CreateToken(user.Id);
                    return Ok(token);
                }
                return BadRequest("Kullanıcı bilgileri hatalı!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}