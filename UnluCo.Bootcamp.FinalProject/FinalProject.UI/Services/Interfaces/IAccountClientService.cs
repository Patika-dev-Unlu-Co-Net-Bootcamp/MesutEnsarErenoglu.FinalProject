using FinalProject.WebApi.Models.User;
using System.Threading.Tasks;

namespace FinalProject.UI.Services.Interfaces
{
    public interface IAccountClientService
    {
        //Post
        Task<bool> Register(RegisterModel registerModel);
        //Post
        Task<bool> Login(LoginUserModel loginModel);
        //Post
        Task<bool> ForgotPassword(ForgotPasswordModel forgotPasswordModel);
        //Post
        Task<bool> ChangeUserPassword(string key, ChangeUserPassword userModel);

        Task<bool> Logout();

    }
}
