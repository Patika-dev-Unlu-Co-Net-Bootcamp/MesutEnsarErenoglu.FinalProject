using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.WebApi.Models.Bid;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPut("updatebid/{id}")]
        public async Task<IActionResult> UpdateBid(int id,[FromBody] AddBidModel bidModel)
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



    }
}
