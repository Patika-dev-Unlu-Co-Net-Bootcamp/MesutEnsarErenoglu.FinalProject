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
    public class SubCategoryClientService : ISubCategoryClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProtectedLocalStorage _localStorage;

        public SubCategoryClientService(IHttpClientFactory httpClientFactory, ProtectedLocalStorage localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _localStorage = localStorage;
        }
        public async Task<List<SubCategoryDto>> GetAllActive()
        {

            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get("https://localhost:44353/api/subcategories/getallactive");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var subCategoryDtos = await JsonSerializer.DeserializeAsync
                    <List<SubCategoryDto>>(responseStream);
                return subCategoryDtos;
            }
            else
            {
                return null;
            }
        }

        public async Task<SubCategoryDto> GetbyId(int id)
        {

            var url = "https://localhost:44353/api/subcategories/" + $"{id}";

            ApiCallService apiCallService = new ApiCallService(_httpClientFactory, _localStorage);

            var response = await apiCallService.Get(url);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var subCategoryDto = await JsonSerializer.DeserializeAsync
                    <SubCategoryDto>(responseStream);

                return subCategoryDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProductDto>> GetProductsbySubCategory(int id)
        {   
            var url = "https://localhost:44353/api/categories/getproductsbysubcategory" + $"{id}";

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
