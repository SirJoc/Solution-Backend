using Crud.API.Domain.Models;

namespace Crud.API.Domain.Services.Communication
{
    public class OrderDetailResponse: BaseResponse<OrderDetail>
    {
        public OrderDetailResponse(OrderDetail resource) : base(resource)
        {
        }

        public OrderDetailResponse(string message) : base(message)
        {
        }
    }
}