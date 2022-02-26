using AutoMapper;
using FinalProject.Application.DTOs;
using FinalProject.Application.Interfaces;
using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Application.Services
{
    public class BidService : IBidService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BidService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(BidDto entity)
        {
            try
            {
                var bid = _mapper.Map<Bid>(entity);
                await _unitOfWork.BidRepository.Add(bid);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> Any(int id)
        {
            try
            {
                return await _unitOfWork.BidRepository.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _unitOfWork.BidRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BidDto>> GetAll()
        {
            try
            {
                var bids = await _unitOfWork.BidRepository.GetAll();
                var bidDtos = _mapper.Map<List<BidDto>>(bids);
                return bidDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BidDto>> GetAllActive()
        {
            try
            {
                var bids = await _unitOfWork.BidRepository.GetAllActive();
                var bidDtos = _mapper.Map<List<BidDto>>(bids);
                return bidDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BidDto>> GetAllInActive()
        {
            try
            {
                var bids = await _unitOfWork.BidRepository.GetAllInActive();
                var bidDtos = _mapper.Map<List<BidDto>>(bids);
                return bidDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BidDto>> GetbyFilter(Expression<Func<BidDto, bool>> filter)
        {
            try
            {
                var expression = _mapper.Map<Expression<Func<Bid, bool>>>(filter);
                var bids = await _unitOfWork.BidRepository.GetbyFilter(expression);
                var list = _mapper.Map<List<BidDto>>(bids);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<BidDto> GetbyId(int Id)
        {
            try
            {
                var Bid = await _unitOfWork.BidRepository.GetbyId(Id);
                var result = _mapper.Map<BidDto>(Bid);
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task RemoveFromDb(int id)
        {
            try
            {
                await _unitOfWork.BidRepository.RemoveFromDb(id);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Update(BidDto entity)
        {
            try
            {
                var bid = await _unitOfWork.BidRepository.GetbyId(entity.Id);
                bid.BidPrice = entity.BidPrice;
                bid.Quantity = entity.Quantity;
                
                _unitOfWork.BidRepository.Update(bid);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task MakeBidInActive(int id, bool status)
        {
            try
            {
                var bid = await _unitOfWork.BidRepository.GetbyId(id);
                bid.IsActive = status;

                _unitOfWork.BidRepository.Update(bid);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task MakeBidAccepted(int id, bool status)
        {
            try
            {
                var bid = await _unitOfWork.BidRepository.GetbyId(id);
                bid.BidAcceptDate = DateTime.Now;
                bid.IsAccepted = true;

                _unitOfWork.BidRepository.Update(bid);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task MakeBidSold(int id, bool status)
        {
            try
            {
                var bid = await _unitOfWork.BidRepository.GetbyId(id);
                bid.IsSold = status;
                bid.SoldDate = DateTime.Now;

                bid.IsAccepted = bid.IsAccepted == true ? bid.IsAccepted : true;
                bid.BidAcceptDate = bid.BidAcceptDate == null ? DateTime.Now : bid.BidAcceptDate;

                _unitOfWork.BidRepository.Update(bid);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
