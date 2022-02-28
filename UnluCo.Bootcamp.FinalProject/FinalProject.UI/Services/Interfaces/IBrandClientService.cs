
using FinalProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.UI.Services.Interfaces
{
    public interface IBrandClientService
    {
        Task<List<BrandDto>> GetAllActive();

        Task<BrandDto> GetbyId(int id);

    }
}
