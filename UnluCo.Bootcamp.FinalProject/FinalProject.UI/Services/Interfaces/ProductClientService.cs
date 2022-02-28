

using FinalProject.Application.DTOs;
using FinalProject.WebApi.Models.Product;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinalProject.UI.Services.Interfaces
{
    public class ProductClientService : IProductClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProtectedLocalStorage _localStorage;

        public ProductClientService(IHttpClientFactory httpClientFactory, ProtectedLocalStorage localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _localStorage = localStorage;
        }
        public async Task<bool> AddProduct(AddProductModel productModel)
        {
            var client = _httpClientFactory.CreateClient();

            var url = "https://localhost:44353/api/accounts/register";

            var token = await _localStorage.GetAsync<string>("token");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer" , token.Value);

            var response = await client.PostAsJsonAsync(url, productModel);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteProductImage(int id, IFormFile formFile)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllActive()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductDto> GetbyId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsbyCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsbyUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateProduct(int id, IFormFile formFile)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UploadProductImage(int id, IFormFile formFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
