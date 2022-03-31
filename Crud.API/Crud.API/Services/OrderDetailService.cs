using System;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Persistence.Repositories;
using Crud.API.Domain.Services;
using Crud.API.Domain.Services.Communication;

namespace Crud.API.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IClothRepository _clothRepository;
        
        public OrderDetailService(IUnitOfWork unitOfWork, 
            IOrderDetailRepository orderDetailRepository, 
            IOrderRepository orderRepository, 
            IClothRepository clothRepository)
        {
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _clothRepository = clothRepository;
        }
        
        public async Task<OrderDetailResponse> AssignOrderDetailAsync(int orderId, int clothId)
        {
            var existingOrder = await _orderRepository.FindById(orderId);
            var existingCloth = await _clothRepository.FindById(clothId);

            if (existingOrder == null || existingCloth == null)
                return new OrderDetailResponse("orderId or clothId not found");

            try
            {
                var orderDetail = new OrderDetail();
                orderDetail.OrderId = existingOrder.Id;
                orderDetail.ClothId = existingCloth.Id;

                await _orderDetailRepository.AddAsync(orderDetail);
                await _unitOfWork.CompleteAsync();
                return new OrderDetailResponse(orderDetail);
            }
            catch (Exception e)
            {
                return new OrderDetailResponse($"Has ocurred an error assign the order detail: {e.Message}");
            }
        }

        public async Task<OrderDetailResponse> UnassignOrderDetailAsync(int orderId, int clothId)
        {
            var existingOrderDetail = await _orderDetailRepository.FindByOrderIdAndClothId(orderId, clothId);
            if (existingOrderDetail == null)
                return new OrderDetailResponse("OrderDetail not found");

            try
            {
                _orderDetailRepository.Remove(existingOrderDetail);
                await _unitOfWork.CompleteAsync();
                return new OrderDetailResponse(existingOrderDetail);
            }
            catch (Exception e)
            {
                return new OrderDetailResponse($"Has ocurred an error unassign the order detail: {e.Message}");
            }
        }
    }
}