

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
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(ColorDto entity)
        {
            try
            {
                var color = _mapper.Map<Color>(entity);
                await _unitOfWork.ColorRepository.Add(color);
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
                return await _unitOfWork.ColorRepository.Any(x => x.Id == id);
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
                await _unitOfWork.ColorRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ColorDto>> GetAll()
        {
            try
            {
                var colors = await _unitOfWork.ColorRepository.GetAll();
                var colorDtos = _mapper.Map<List<ColorDto>>(colors);
                return colorDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ColorDto>> GetAllActive()
        {
            try
            {
                var colors = await _unitOfWork.ColorRepository.GetAllActive();
                var colorDtos = _mapper.Map<List<ColorDto>>(colors);
                return colorDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ColorDto>> GetAllInActive()
        {
            try
            {
                var colors = await _unitOfWork.ColorRepository.GetAllInActive();
                var colorDtos = _mapper.Map<List<ColorDto>>(colors);
                return colorDtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ColorDto>> GetbyFilter(Expression<Func<ColorDto, bool>> filter)
        {
            try
            {
                var expression = _mapper.Map<Expression<Func<Color, bool>>>(filter);
                var colors = await _unitOfWork.ColorRepository.GetbyFilter(expression);
                var list = _mapper.Map<List<ColorDto>>(colors);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<ColorDto> GetbyId(int Id)
        {
            try
            {
                var color = await _unitOfWork.ColorRepository.GetbyId(Id);
                var result = _mapper.Map<ColorDto>(color);
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
                await _unitOfWork.ColorRepository.RemoveFromDb(id);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Update(ColorDto entity)
        {
            try
            {
                var color = await _unitOfWork.ColorRepository.GetbyId(entity.Id);

                color.IsActive = entity.IsActive;
                color.Name = entity.Name;
                color.Hex = entity.Hex;
                _unitOfWork.ColorRepository.Update(color);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
