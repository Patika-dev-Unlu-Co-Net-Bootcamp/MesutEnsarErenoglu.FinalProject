

using FinalProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.UI.Services.Interfaces
{
    public interface ICategoryClientService
    {
        Task<List<CategoryDto>> GetAllActive();
        Task<CategoryDto> GetbyId(int id);
        Task<List<ProductDto>> GetProductsbyCategory(int id);
    }
}
