
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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(SubCategoryDto entity)
        {
            await _unitOfWork.SubCategoryRepository.Add(_mapper.Map<SubCategory>(entity));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Any(int id)
        {
            var result = await _unitOfWork.SubCategoryRepository.Any(x => x.Id == id);
            return result;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.SubCategoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<SubCategoryDto>> GetAll()
        {
            
            try
            {
                var subcategories = await _unitOfWork.SubCategoryRepository.GetAll();
                return _mapper.Map<List<SubCategoryDto>>(subcategories);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<SubCategoryDto>> GetAllActive()
        {
            try
            {
                var subcategories = await _unitOfWork.SubCategoryRepository.GetAllActive();
                return _mapper.Map<List<SubCategoryDto>>(subcategories);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<SubCategoryDto>> GetAllInActive()
        {
            try
            {
                var subcategories = await _unitOfWork.SubCategoryRepository.GetAllInActive();
                return _mapper.Map<List<SubCategoryDto>>(subcategories);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<SubCategoryDto>> GetbyFilter(Expression<Func<SubCategoryDto, bool>> filter)
        {
            
            try
            {
                var expression = _mapper.Map<Expression<Func<SubCategory, bool>>>(filter);
                var subcategories = await _unitOfWork.SubCategoryRepository.GetbyFilter(expression);
                return _mapper.Map<List<SubCategoryDto>>(subcategories);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<SubCategoryDto> GetbyId(int Id)
        {
            try
            {
                var subcategory = await _unitOfWork.SubCategoryRepository.GetbyId(Id);
                return _mapper.Map<SubCategoryDto>(subcategory);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public List<ProductDto> GetProductsbySubCategoryId(int id)
        {
            try
            {
                var products = _unitOfWork.SubCategoryRepository.GetProductsbySubCategoryId(id);
                var productDtos = _mapper.Map<List<ProductDto>>(products);

                return productDtos; 
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
                await _unitOfWork.SubCategoryRepository.RemoveFromDb(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Update(SubCategoryDto entity)
        {
            try
            {
                var subCategory = await _unitOfWork.SubCategoryRepository.GetbyId(entity.Id);
                subCategory.SubCategoryName = entity.SubCategoryName;
                subCategory.Description = entity.Description;
                subCategory.CategoryId = entity.CategoryId;
                subCategory.IsActive = entity.IsActive;
                _unitOfWork.SubCategoryRepository.Update(subCategory);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
