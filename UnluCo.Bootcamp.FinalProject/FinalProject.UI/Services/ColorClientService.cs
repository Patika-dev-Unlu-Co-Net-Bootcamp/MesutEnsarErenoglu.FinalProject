

using FinalProject.Application.DTOs;
using FinalProject.UI.RequestOperations;
using FinalProject.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinalProject.UI.Services
{
    public class ColorClientService : IColorClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProtectedLocalStorage _localStorage;

        public ColorClientService(IHttpClientFactory httpClientFactory, ProtectedLocalStorage localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _localStorage = localStorage;
        }

        public async Task<List<ColorDto>> GetAllActive()
        {
            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get("https://localhost:44353/api/colors/getallactive");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var colorDtos = await JsonSerializer.DeserializeAsync
                    <List<ColorDto>>(responseStream);
                return colorDtos;
            }
            else
            {
                return null;
            }
        }

        public async Task<ColorDto> GetbyId(int id)
        {
            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get($"https://localhost:44353/api/colors/{id}");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var colorDto = await JsonSerializer.DeserializeAsync
                    <ColorDto>(responseStream);
                return colorDto;
            }
            else
            {
                return null;
            }
        }
    }
}
