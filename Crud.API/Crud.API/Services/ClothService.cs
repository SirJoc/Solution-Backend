using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Persistence.Repositories;
using Crud.API.Domain.Services;
using Crud.API.Domain.Services.Communication;

namespace Crud.API.Services
{
    public class ClothService : IClothService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClothRepository _clothRepository;

        public ClothService(IUnitOfWork unitOfWork, IClothRepository clothRepository)
        {
            _unitOfWork = unitOfWork;
            _clothRepository = clothRepository;
        }
        
        public async Task<IEnumerable<Cloth>> ListAsync()
        {
            return await _clothRepository.ListAsync();
        }

        public async Task<ClothResponse> GetByIdAsync(int id)
        {
            var existingCloth = await _clothRepository.FindById(id);
            if (existingCloth == null)
                return new ClothResponse("Cloth not found");
            return new ClothResponse(existingCloth);
        }

        public async Task<ClothResponse> SaveAsync(Cloth cloth)
        {
            try
            {
                await _clothRepository.AddAsync(cloth);
                await _unitOfWork.CompleteAsync();
                return new ClothResponse(cloth);
            }
            catch (Exception e)
            {
                return new ClothResponse($"An error ocurred while saving the cloth: {e.Message}");
            }
        }

        public async Task<ClothResponse> UpdateAsync(int id, Cloth cloth)
        {
            var existingCloth = await _clothRepository.FindById(id);
            if (existingCloth == null)
                return new ClothResponse("Cloth not found");
            existingCloth.Brand = cloth.Brand;
            existingCloth.Color = cloth.Color;
            try
            {
                _clothRepository.Update(existingCloth);
                await _unitOfWork.CompleteAsync();
                return new ClothResponse(existingCloth);
            }
            catch (Exception e)
            {
                return new ClothResponse($"An error ocurred while updating the cloth: {e.Message}");

            }
        }

        public async Task<ClothResponse> DeleteAsync(int id)
        {
            var existingCloth = await _clothRepository.FindById(id);
            if (existingCloth == null)
                return new ClothResponse("Cloth not found");
            try
            {
                _clothRepository.Remove(existingCloth);
                await _unitOfWork.CompleteAsync();
                return new ClothResponse(existingCloth);
            }
            catch (Exception e)
            {
                return new ClothResponse("Has ocurred an error deleting the cloth " + e.Message);
            }
        }
    }
}