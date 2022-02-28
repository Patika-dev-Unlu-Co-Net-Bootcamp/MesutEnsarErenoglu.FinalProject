using FinalProject.Application.Token;
using FinalProject.UI.Authentication;
using FinalProject.UI.Services.Interfaces;
using FinalProject.WebApi.Models.User;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinalProject.UI.Services
{
    public class AccountClientService : IAccountClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProtectedLocalStorage _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AccountClientService(IHttpClientFactory httpClientFactory, ProtectedLocalStorage localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClientFactory = httpClientFactory;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }
        public async Task<bool> ChangeUserPassword(string key, ChangeUserPassword userModel)
        {
            var client = _httpClientFactory.CreateClient();

            var url = $"https://localhost:44353/api/accounts/changepassword/{key}";
            
            var response = await client.PostAsJsonAsync(url, userModel);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            var client = _httpClientFactory.CreateClient();

            var url = "https://localhost:44353/api/accounts/forgotpassword";
            
            var response = await client.PostAsJsonAsync(url, forgotPasswordModel);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Login(LoginUserModel loginModel)
        {
            var client = _httpClientFactory.CreateClient();

            var url = "https://localhost:44353/api/accounts/login";
            

            var response = await client.PostAsJsonAsync(url, loginModel);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync
                    <Token>(responseStream);

                await _localStorage.SetAsync("token", result.AccessToken);
                await _localStorage.SetAsync("tokenExpiration", result.TokenExpiration);
                await _localStorage.SetAsync("tokenRefreshToken", result.RefreshToken);
                await _localStorage.SetAsync("tokenRefreshTokenExpiration", result.RefreshTokenExpireDate);
                ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.AccessToken);
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);

                return true;
            }
            return false;
        }

        public async Task<bool> Logout()
        {

            try
            {
                await _localStorage.DeleteAsync("token");
                await _localStorage.DeleteAsync("tokenExpiration");
                await _localStorage.DeleteAsync("tokenRefreshToken");
                await _localStorage.DeleteAsync("tokenRefreshTokenExpiration");
                ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = null;

                return true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            
        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            var client = _httpClientFactory.CreateClient();

            var url = "https://localhost:44353/api/accounts/register";
            
            var response = await client.PostAsJsonAsync(url, registerModel);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }


    }
}
