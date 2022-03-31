using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Persistence.Repositories;
using Crud.API.Domain.Services;
using Crud.API.Domain.Services.Communication;

namespace Crud.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IClothRepository _clothRepository;
        
        public OrderService(IUnitOfWork unitOfWork, 
            IOrderRepository orderRepository, 
            IClothRepository clothRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _clothRepository = clothRepository;
        }
        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _orderRepository.ListAsync();
        }

        public async Task<IEnumerable<Order>> ListByClothIdAsync(int clothId)
        {
            return await _orderRepository.ListByClothIdAsync(clothId);
        }

        public async Task<OrderResponse> GetByIdAsync(int id)
        {
            var existingOrder = await _orderRepository.FindById(id);
            if (existingOrder == null)
                return new OrderResponse("Order not found");
            return new OrderResponse(existingOrder);
        }

        public async Task<OrderResponse> SaveAsync(int clothId, Order order)
        {
            var existingCloth = await _clothRepository.FindById(order.ClothId);
            // Foreign key not found  --> dependiendo del numero de keys dentro de Order
            if (existingCloth == null)
                return new OrderResponse("Cloth not found.");
            try
            {
                order.ClothId = clothId;
                await _orderRepository.AddAsync(order);
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(order);
            }
            catch (Exception e)
            {
                return new OrderResponse("Has ocurred an error saving the order " + e.Message);
            }
        }

        public async Task<OrderResponse> UpdateAsync(int id, Order order)
        {
            var existingOrder = await _orderRepository.FindById(id);
            if (existingOrder == null)
                return new OrderResponse("Order not found");

            try
            {
                existingOrder.Cloth = order.Cloth;
                existingOrder.ClothId = order.ClothId;
                _orderRepository.Update(existingOrder);
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(existingOrder);
            }
            catch (Exception e)
            {
                return new OrderResponse("Has ocurred an error updating the order " + e.Message);
            }
        }
        

        public async Task<OrderResponse> DeleteAsync(int id)
        {
            var existingOrder = await _orderRepository.FindById(id);
            if (existingOrder == null)
                return new OrderResponse("Order not found");
            try
            {
                _orderRepository.Remove(existingOrder);
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(existingOrder);
            }
            catch (Exception e)
            {
                return new OrderResponse("Has ocurred an error deleting the order " + e.Message);
            }
        }
    }
}