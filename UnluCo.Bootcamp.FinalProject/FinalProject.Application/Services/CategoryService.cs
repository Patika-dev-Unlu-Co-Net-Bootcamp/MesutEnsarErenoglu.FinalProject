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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(CategoryDto entity)
        {
            var category = _mapper.Map<Category>(entity);
            await _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Any(int id)
        {
            try
            {
                return await _unitOfWork.CategoryRepository.Any(x => x.Id == id);
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

                await _unitOfWork.CategoryRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAll();
                var list = _mapper.Map<List<CategoryDto>>(categories);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CategoryDto>> GetAllActive()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllActive();
                var list = _mapper.Map<List<CategoryDto>>(categories);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CategoryDto>> GetAllInActive()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllInActive();
                var list = _mapper.Map<List<CategoryDto>>(categories);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<CategoryDto>> GetbyFilter(Expression<Func<CategoryDto, bool>> filter)
        {
            try
            {
                var expression = _mapper.Map<Expression<Func<Category, bool>>>(filter);
                var categories = await _unitOfWork.CategoryRepository.GetbyFilter(expression);
                var list = _mapper.Map<List<CategoryDto>>(categories);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<CategoryDto> GetbyId(int Id)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetbyId(Id);
                var result = _mapper.Map<CategoryDto>(category);
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public List<ProductDto> GetProductsbyCategoryId(int id)
        {
            try
            {
                var products = _unitOfWork.CategoryRepository.GetProductsbyCategoryId(id);
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
                await _unitOfWork.CategoryRepository.RemoveFromDb(id);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            
        }

        public async Task Update(CategoryDto entity)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetbyId(entity.Id);

                category.CategoryName = entity.CategoryName;
                category.Description = entity.Description;
                category.IsActive = entity.IsActive;

                category.SubCategories.Clear();
                List<SubCategory> subCategories = new List<SubCategory>();

                for (int i = 0; i < entity.SubCategories.Count; i++)
                {
                    var subCategory = await _unitOfWork.SubCategoryRepository.GetbyId(entity.SubCategories[i].Id);
                    subCategories.Add(subCategory);
                }

                category.SubCategories.AddRange(subCategories);

                _unitOfWork.CategoryRepository.Update(category);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        
    }
}
