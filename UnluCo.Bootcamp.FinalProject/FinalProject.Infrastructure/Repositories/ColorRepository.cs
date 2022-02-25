
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;

namespace FinalProject.Infrastructure.Repositories
{
    public class ColorRepository: BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context):base(context)
        {

        }
    }
}
