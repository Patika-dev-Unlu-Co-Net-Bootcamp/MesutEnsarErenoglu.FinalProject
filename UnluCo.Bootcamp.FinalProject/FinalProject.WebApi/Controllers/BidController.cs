using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.WebApi.Models.Bid;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/bids")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;
        private readonly IProductService _productService;
        private readonly IAppUserService _userService;

        public BidController(IBidService bidService,IProductService productService,IAppUserService userService)
        {
            _bidService = bidService;
            _productService = productService;
            _userService = userService;
        }

        [HttpPost("createbid")]
        public async Task<IActionResult> CreateBid([FromBody] AddBidModel bidModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resultUser = await _userService.AnybyId(bidModel.BidderUserId);
                    if (!resultUser)
                    {
                        return BadRequest("Böyle bir kullanıcı bulunamadı!");
                    }
                    var productResult = await _productService.IsOfferdable(bidModel.ProductId);
                    if (!productResult)
                    {
                        return BadRequest("Teklife uygun böyle bir ürün bulunamadı!");
                    }
                    BidDto newBid = new BidDto();
                    newBid.ProductId = bidModel.ProductId;
                    newBid.BidderUserId = bidModel.BidderUserId;
                    newBid.BidPrice = bidModel.BidPrice;
                    newBid.Quantity = bidModel.Quantity;
                    newBid.BidDate = DateTime.Now;
                    newBid.IsActive = true;
                    newBid.IsSold = false;
                    await _bidService.Add(newBid);

                    return Ok("Teklif oluşturuldu!");
                }
                return BadRequest("Teklif uygun değil!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPost("buyproduct/{id}")]
        public async Task<IActionResult> BuyProduct(int id,[FromBody] SoldModel bidModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resultUser = await _userService.AnybyId(bidModel.BidderUserId);
                    if (!resultUser)
                    {
                        return BadRequest("Böyle bir kullanıcı bulunamadı!");
                    }
                    var product = await _productService.GetbyId(id);
                    if (product == null)
                    {
                        return BadRequest("Böyle bir ürün bulunamadı!");
                    }
                    BidDto newBid = new BidDto();
                    newBid.ProductId = product.Id;
                    newBid.BidderUserId = bidModel.BidderUserId;
                    newBid.BidPrice = product.Price;
                    newBid.Quantity = bidModel.Quantity;
                    newBid.BidDate = DateTime.Now;
                    newBid.IsActive = false;
                    newBid.IsSold = true;
                    newBid.SoldDate = DateTime.Now;
                    await _bidService.Add(newBid);

                    return Ok("Ürün satışı gerçekleşti!");
                }
                return BadRequest("Ürün satışa uygun değil!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("updatebid/{id}")]
        public async Task<IActionResult> UpdateBid(int id,[FromBody] UpdateBidModel bidModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var bid = await _bidService.GetbyId(id);
                    bid.BidPrice = bidModel.BidPrice;
                    bid.Quantity = bidModel.Quantity;

                    await _bidService.Update(bid);

                    return Ok("Teklif güncellendi!");
                }
                return BadRequest("Teklif uygun değil!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("makebidinactive/{id}")]
        public async Task<IActionResult> MakeBidInActive(int id)
        {
            try
            {
                var result = await _bidService.Any(id);
                if (result)
                {

                    await _bidService.MakeBidInActive(id, false);

                    return Ok("Teklif iptal edildi!");
                }
                return BadRequest("Teklif uygun değil!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("makebidaccepted/{id}")]
        public async Task<IActionResult> MakeBidAccepted(int id)
        {
            try
            {
                var result = await _bidService.Any(id);
                if (result)
                {
                    await _bidService.MakeBidAccepted(id, true);

                    return Ok("Teklif kabul edildi!");
                }
                return BadRequest("Teklif uygun değil!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPut("makebidsold/{id}")]
        public async Task<IActionResult> MakeBidSold(int id)
        {
            try
            {
                var result = await _bidService.Any(id);
                if (result)
                {

                    await _bidService.MakeBidSold(id, true);

                    return Ok("Satış Gerçekleşti!");
                }
                return BadRequest("Teklif uygun değil!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var bids = await _bidService.GetAll();
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                var bids = await _bidService.GetAllActive();
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        [HttpGet("getallinactive")]
        public async Task<IActionResult> GetAllInActive()
        {
            try
            {
                var bids = await _bidService.GetAllInActive();
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getbidsbyproductownerid/{id}")]
        public async Task<IActionResult> GetBidsbyProductOwnerId(string id)
        {
            try
            {
                var bids = await _bidService.GetBidsbyProductOwnerId(id);
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("getbidsbyproductid/{id}")]
        public async Task<IActionResult> GetBidsbyProductId(int id)
        {
            try
            {
                var bids = await _bidService.GetBidsbyProductId(id);
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        [HttpGet("getbidsbybidderid/{id}")]
        public async Task<IActionResult> GetBidsbyBidderId(string id)
        {
            try
            {
                var bids = await _bidService.GetBidsbyBidderId(id);
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        [HttpGet("getsoldbids")]
        public async Task<IActionResult> GetSoldBids()
        {
            try
            {
                var bids = await _bidService.SoldBids();
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("soldbidsbyproductownerid/{id}")]
        public async Task<IActionResult> GetSoldBidsbyProductOwnerId(string id)
        {
            try
            {
                var bids = await _bidService.SoldBidsbyProductOwnerId(id);
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpGet("soldbidsbybidderid/{id}")]
        public async Task<IActionResult> GetSoldBidsbyBidderId(string id)
        {
            try
            {
                var bids = await _bidService.SoldBidsbyBidderId(id);
                return Ok(bids);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
