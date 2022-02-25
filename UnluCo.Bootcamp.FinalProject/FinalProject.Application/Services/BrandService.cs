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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(BrandDto entity)
        {
            try
            {
                var brand = _mapper.Map<Brand>(entity);
                await _unitOfWork.BrandRepository.Add(brand);
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
                return await _unitOfWork.BrandRepository.Any(x => x.Id == id);
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
                await _unitOfWork.BrandRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BrandDto>> GetAll()
        {
            try
            {
                var brands = await _unitOfWork.BrandRepository.GetAll();
                var brandDtos = _mapper.Map<List<BrandDto>>(brands);
                return brandDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BrandDto>> GetAllActive()
        {
            try
            {
                var brands = await _unitOfWork.BrandRepository.GetAllActive();
                var brandDtos = _mapper.Map<List<BrandDto>>(brands);
                return brandDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BrandDto>> GetAllInActive()
        {
            try
            {
                var brands = await _unitOfWork.BrandRepository.GetAllInActive();
                var brandDtos = _mapper.Map<List<BrandDto>>(brands);
                return brandDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<BrandDto>> GetbyFilter(Expression<Func<BrandDto, bool>> filter)
        {
            try
            {
                var expression = _mapper.Map<Expression<Func<Brand, bool>>>(filter);
                var brands = await _unitOfWork.BrandRepository.GetbyFilter(expression);
                var list = _mapper.Map<List<BrandDto>>(brands);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<BrandDto> GetbyId(int Id)
        {
            try
            {
                var Brand = await _unitOfWork.BrandRepository.GetbyId(Id);
                var result = _mapper.Map<BrandDto>(Brand);
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
                await _unitOfWork.BrandRepository.RemoveFromDb(id);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Update(BrandDto entity)
        {
            try
            {
                var brand = await _unitOfWork.BrandRepository.GetbyId(entity.Id);

                brand.Name = entity.Name;
                brand.Description = entity.Description;
                brand.IsActive = entity.IsActive;
                _unitOfWork.BrandRepository.Update(brand);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
