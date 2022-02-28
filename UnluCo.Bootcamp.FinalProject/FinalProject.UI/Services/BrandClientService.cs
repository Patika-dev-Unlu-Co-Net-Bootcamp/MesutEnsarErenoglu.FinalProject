

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
    public class BrandClientService : IBrandClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProtectedLocalStorage _localStorage;

        public BrandClientService(IHttpClientFactory httpClientFactory,ProtectedLocalStorage localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _localStorage = localStorage;
        }
        public async Task<List<BrandDto>> GetAllActive()
        {
            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get("https://localhost:44353/api/brands/getallactive");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var brandDtos = await JsonSerializer.DeserializeAsync
                    <List<BrandDto>>(responseStream);
                return brandDtos;
            }
            else
            {
                return null;
            }
        }

        public async Task<BrandDto> GetbyId(int id)
        {
            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get($"https://localhost:44353/api/brands/{id}");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var brandDto = await JsonSerializer.DeserializeAsync
                    <BrandDto>(responseStream);
                return brandDto;
            }
            else
            {
                return null;
            }

        }
    }
}
