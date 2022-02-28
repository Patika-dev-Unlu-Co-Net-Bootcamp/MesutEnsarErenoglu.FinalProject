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
    public class CategoryClientService : ICategoryClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProtectedLocalStorage _localStorage;

        public CategoryClientService(IHttpClientFactory httpClientFactory, ProtectedLocalStorage localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _localStorage = localStorage;
        }
        public async Task<List<CategoryDto>> GetAllActive()
        {
            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get("https://localhost:44353/api/categories/getallactive");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var categoryDtos = await JsonSerializer.DeserializeAsync
                    <List<CategoryDto>>(responseStream);
                return categoryDtos;
            }
            else
            {
                return null;
            }
        }

        public async Task<CategoryDto> GetbyId(int id)
        {
            
            var url = "https://localhost:44353/api/categories/" + $"{id}";
        
            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get(url);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var categoryDto = await JsonSerializer.DeserializeAsync
                    <CategoryDto>(responseStream);

                return categoryDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProductDto>> GetProductsbyCategory(int id)
        {

            var url = "https://localhost:44353/api/categories/getproductsbycategoryid" + $"{id}";
            

            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get(url);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var productDtos = await JsonSerializer.DeserializeAsync
                    <List<ProductDto>>(responseStream);

                return productDtos;
            }
            else
            {
                return null;
            }
        }

    }
}
