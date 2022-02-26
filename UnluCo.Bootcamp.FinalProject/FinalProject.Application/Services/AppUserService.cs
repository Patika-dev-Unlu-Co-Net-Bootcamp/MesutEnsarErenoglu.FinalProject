using AutoMapper;
using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Application.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppUserService(UserManager<AppUser> userManager,IMapper mapper, RoleManager<IdentityRole> roleManager) 
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<string> Add(AppUserDto entity)
        {
            try
            {
                var appUser = _mapper.Map<AppUser>(entity);
                appUser.Id = Guid.NewGuid().ToString();
                appUser.ActivationKey = Guid.NewGuid();
                appUser.Phone = appUser.PhoneNumber;
                appUser.IsActive = true;
                var result = await _userManager.CreateAsync(appUser,entity.Password);
                if (result.Succeeded)
                {
                    return "İşlem Tamamlandı!";
                }
                return "İşlem Başarısız!";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AnybyEmail(string email)
        {
            try
            {
                var appUser = await _userManager.FindByEmailAsync(email);
                if (appUser == null)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AnybyId(string id)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(id);
                if (appUser == null)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> ChangePassword(string email, string newPassword)
        {
            try
            {
                var user = await  _userManager.FindByEmailAsync(email);
                var reponse = await _userManager.RemovePasswordAsync(user);
                if (!reponse.Succeeded)
                {
                    throw new InvalidOperationException("Bir hata oluştu!");
                }
                var result = await _userManager.AddPasswordAsync(user, newPassword);
                if (result.Succeeded)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> CheckPassword(string email, string password)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                var result = await _userManager.CheckPasswordAsync(user,password);
                if (result)
                {
                    return result;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> DeletebyEmail(string email)
        {
            try
            {
                var appUser = await _userManager.FindByEmailAsync(email);
                if (appUser == null)
                {
                    throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı!");
                }
                appUser.IsActive = false;
                var result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    return "İşlem tamamlandı!";
                }
                return "Silme işlemi başarısız!";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> DeletebyId(string id)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(id);
                if (appUser == null)
                {
                    throw new InvalidOperationException("Bu id ile bir kullanıcı bulunamadı!");
                }
                appUser.IsActive = false;
                var result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    return "İşlem tamamlandı!";
                }
                return "Silme işlemi başarısız!";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public List<AppUserDto> GetAllActive()
        {
            try
            {
                var users = _userManager.Users.Where(x => x.IsActive == true).ToList();
                var list = _mapper.Map<List<AppUserDto>>(users);
                return list;
            }
            catch (Exception ex )
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AppUserDto> GetbyEmail(string email)
        {
            try
            {
                var appUser = await _userManager.FindByEmailAsync(email);
                if (appUser == null)
                {
                    throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı!");
                }
                var appUserDto = _mapper.Map<AppUserDto>(appUser);

                return appUserDto;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task<AppUserDto> GetbyId(string Id)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(Id);
                if (appUser == null)
                {
                    throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı!");
                }
                var appUserDto = _mapper.Map<AppUserDto>(appUser);

                return appUserDto;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public AppUserDto GetbyKey(Guid key)
        {
            try
            {
                var user = _userManager.Users.SingleOrDefault(x => x.ActivationKey == key);
                if (user != null)
                {
                    return _mapper.Map<AppUserDto>(user);
                }
                throw new InvalidOperationException("Böyle bir kullanıcı bulunmamaktadır!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<Guid> GetUsersKey(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    return user.ActivationKey;
                }
                throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> RemoveFromDb(string id)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(id);
                if (appUser == null)
                {
                    throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı!");
                }
                var result = await _userManager.DeleteAsync(appUser);
                if (result.Succeeded)
                {
                    return "İşlem tamamlandı!";
                }
                return "Silme işlemi başarısız!";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public Task Update(AppUserDto entity)
        {
            // Todo : User güncelleme tamamla
            throw new NotImplementedException();
        }

    }
}
