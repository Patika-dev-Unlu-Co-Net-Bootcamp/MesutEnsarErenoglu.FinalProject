using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.Application.Token;
using FinalProject.Common.Email;
using FinalProject.Common.RabbitMQ;
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
        public async Task<IActionResult> Register([FromBody] RegisterModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.AnybyEmail(userModel.Email);

                    if (result)
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
                    newUser.Region = userModel.Region;
                    newUser.UserName = userModel.Email;

                    await _userService.Add(newUser);

                    EmailModel emailModel = new EmailModel();
                    emailModel.SenderEmail = "unlucofinalprojectmee@gmail.com";
                    emailModel.ReceiverEmail = newUser.Email;
                    emailModel.SenderTitle = "UnluCoFinalProject";
                    emailModel.Subject = "Sitemize Hoşgeldiniz!";
                    emailModel.Body = $"Sayın {newUser.FullName}, Üyeliğiniz başarıyla gerçekleştirilmiş olup iyi alışverişler dileriz.";
                    RabbitMQReceiver rabbitMQReceiver = new RabbitMQReceiver();
                    rabbitMQReceiver.Send(emailModel);

                    return Ok(new {message = "Kullanıcı kaydı başarılı!" });
                    
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
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            try
            {
                var result = await _userService.AnybyEmail(model.Email);
                if (result)
                {
                    string key = await _userService.GetUsersKey(model.Email);

                    EmailModel emailModel = new EmailModel();
                    emailModel.SenderEmail = "unlucofinalprojectmee@gmail.com";
                    emailModel.ReceiverEmail = model.Email;
                    emailModel.SenderTitle = "UnluCoFinalProject";
                    emailModel.Subject = "Şifre Yenileme";
                    emailModel.Body =  $"Sayın üyemiz, şifrenizi yenilemek için bağlantıya tıklayınız {model.URL}{key}";
                    RabbitMQReceiver rabbitMQReceiver = new RabbitMQReceiver();
                    rabbitMQReceiver.Send(emailModel);

                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        [HttpPost("changepassword/{key}")]
        public async Task<IActionResult> ChangeUserPassword(Guid key,[FromBody] ChangeUserPassword userModel)
        {
            try
            {
                var user = _userService.GetbyKey(key);
                if (user == null)
                {
                    return BadRequest("Böyle bir kullanıcı bulunamadı!");
                }
                if (ModelState.IsValid)
                {
                    var result = await _userService.ChangePassword(user.Email, userModel.newPassword);

                    if (result)
                    {
                        return Ok("Şifreniz başarıyla değiştirildi!");
                    }
                    return BadRequest("İşlem sırasında bir hata oluştu!");
                }
                return BadRequest("Giriş yapılan şifreler birbiriyle aynı olmalıdır!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
