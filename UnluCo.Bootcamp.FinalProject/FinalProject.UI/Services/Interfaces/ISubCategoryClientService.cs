

using FinalProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.UI.Services.Interfaces
{
    public interface ISubCategoryClientService
    {
        Task<List<SubCategoryDto>> GetAllActive();
        Task<SubCategoryDto> GetbyId(int id);
        Task<List<ProductDto>> GetProductsbySubCategory(int id);
    }
}
