
using FinalProject.Application.DTOs;
using FinalProject.WebApi.Models.Product;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.UI.Services.Interfaces
{
    public interface IProductClientService
    {
        Task<List<ProductDto>> GetAllActive();
        Task<ProductDto> GetbyId(int id);
        Task<List<ProductDto>> GetProductsbyCategory(int id);
        Task<List<ProductDto>> GetProductsbyUser(string id);
        Task<bool> AddProduct(AddProductModel productModel);
        Task<bool> UploadProductImage(int id, IFormFile formFile);
        Task<bool> DeleteProductImage(int id, IFormFile formFile);
        Task<bool> UpdateProduct(int id, IFormFile formFile);
        

    }
}
