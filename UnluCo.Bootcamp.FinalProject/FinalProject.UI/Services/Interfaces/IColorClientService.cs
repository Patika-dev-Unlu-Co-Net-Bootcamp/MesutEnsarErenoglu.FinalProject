

using FinalProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.UI.Services.Interfaces
{
    public interface IColorClientService
    {
        Task<List<ColorDto>> GetAllActive();

        Task<ColorDto> GetbyId(int id);
    }
}
