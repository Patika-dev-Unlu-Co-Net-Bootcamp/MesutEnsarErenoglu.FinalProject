using FinalProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Domain.Interfaces
{
    public interface IBidRepository:IRepository<Bid>
    {
        Task<List<Bid>> GetBidsbyProductOwnerId(string id);
        Task<List<Bid>> GetBidsbyProductId(int id);
        Task<List<Bid>> GetBidsbyBidderId(string id);
        Task<List<Bid>> SoldBids();
        Task<List<Bid>> SoldBidsbyProductOwnerId(string id);
        Task<List<Bid>> SoldBidsbyBidderId(string id);
    }
}
