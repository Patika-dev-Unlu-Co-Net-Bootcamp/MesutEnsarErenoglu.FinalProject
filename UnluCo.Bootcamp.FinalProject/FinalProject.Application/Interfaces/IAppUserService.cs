using FinalProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces
{
    public interface IAppUserService
    {
        Task<string> Add(AppUserDto entity);
        Task<string> DeletebyId(string id);
        Task<string> DeletebyEmail(string email);
        Task<string> RemoveFromDb(string id);
        Task Update(AppUserDto entity);
        Task<AppUserDto> GetbyId(string Id);
        Task<AppUserDto> GetbyEmail(string email);
        AppUserDto GetbyKey(Guid key);
        Task<bool> AnybyEmail(string email);
        Task<bool> AnybyId(string id);
        List<AppUserDto> GetAllActive();
        Task<bool> CheckPassword(string email, string password);
        Task<bool> ChangePassword(string email, string newPassword);
        Task<string> GetUsersKey(string email);


    }
}
