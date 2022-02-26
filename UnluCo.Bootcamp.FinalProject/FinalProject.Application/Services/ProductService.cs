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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(ProductDto entity)
        {
            try
            {
                var product = _mapper.Map<Product>(entity);
                await _unitOfWork.ProductRepository.Add(product);
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
                return await _unitOfWork.ProductRepository.Any(x => x.Id == id);
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
                await _unitOfWork.ProductRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ProductDto>> GetAll()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAll();
                var productDtos = _mapper.Map<List<ProductDto>>(products);
                return productDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ProductDto>> GetAllActive()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllActive();
                var productDtos = _mapper.Map<List<ProductDto>>(products);
                return productDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ProductDto>> GetAllInActive()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllInActive();
                var productDtos = _mapper.Map<List<ProductDto>>(products);
                return productDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ProductDto>> GetAllOfferdable()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllOfferdable();
                var list = _mapper.Map<List<ProductDto>>(products);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ProductDto>> GetbyFilter(Expression<Func<ProductDto, bool>> filter)
        {
            try
            {
                var expression = _mapper.Map<Expression<Func<Product, bool>>>(filter);
                var products = await _unitOfWork.ProductRepository.GetbyFilter(expression);
                var list = _mapper.Map<List<ProductDto>>(products);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<ProductDto> GetbyId(int Id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetbyId(Id);
                var result = _mapper.Map<ProductDto>(product);
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ProductDto>> GetbyUserId(string id)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetbyUserId(id);
                var list = _mapper.Map<List<ProductDto>>(products);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> IsOfferdable(int id)
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.IsOfferdable(id);
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
                await _unitOfWork.ProductRepository.RemoveFromDb(id);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Update(ProductDto entity)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetbyId(entity.Id);

                product.ProductName = entity.ProductName;
                product.Description = entity.Description;
                product.IsOfferdable = entity.IsOfferdable;
                product.Price = entity.Price;
                product.SubCategoryId = entity.SubCategoryId;
                product.UnitsInStock = entity.UnitsInStock;
                product.UsageStatus = entity.UsageStatus;

                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task UpdateProductImage(ProductDto entity)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetbyId(entity.Id);
                product.ImagePath = entity.ImagePath;
                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
