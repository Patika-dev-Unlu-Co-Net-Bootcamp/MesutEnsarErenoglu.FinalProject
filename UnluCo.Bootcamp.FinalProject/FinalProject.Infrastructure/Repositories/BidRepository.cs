
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;

namespace FinalProject.Infrastructure.Repositories
{
    public class BidRepository:BaseRepository<Bid>,IBidRepository
    {
        public BidRepository(AppDbContext context):base (context)
        {

        }
    }
}
