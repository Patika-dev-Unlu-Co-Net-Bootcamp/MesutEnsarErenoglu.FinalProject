
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Repositories
{
    public class BidRepository:BaseRepository<Bid>,IBidRepository
    {
        public BidRepository(AppDbContext context):base (context)
        {

        }

        public Task<List<Bid>> GetBidsbyBidderId(string id)
        {
            var bids = _context.Bids.Where(x => x.BidderUserId == id && x.IsActive == true).ToListAsync();
            return bids;
        }

        public Task<List<Bid>> GetBidsbyProductId(int id)
        {
            var bids = _context.Bids.Where(x => x.ProductId ==id && x.IsActive == true).ToListAsync();
            return bids;
        }

        public Task<List<Bid>> GetBidsbyProductOwnerId(string id)
        {
            var bids = _context.Bids.Where(x => x.Product.AppUserId == id && x.IsActive == true).ToListAsync();
            return bids;
        }

        public Task<List<Bid>> SoldBids()
        {
            var bids = _context.Bids.Where(x => x.IsSold == true && x.IsActive == false).ToListAsync();
            return bids;
        }

        public Task<List<Bid>> SoldBidsbyBidderId(string id)
        {
            var bids = _context.Bids.Where(x => x.IsSold == true && x.IsActive == false && x.BidderUserId ==id).ToListAsync();
            return bids;
        }

        public Task<List<Bid>> SoldBidsbyProductOwnerId(string id)
        {
            var bids = _context.Bids.Where(x => x.IsSold == true && x.IsActive == false && x.Product.AppUserId == id).ToListAsync();
            return bids;
        }
    }
}
