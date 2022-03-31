using System.Threading.Tasks;
using Crud.API.Domain.Services.Communication;

namespace Crud.API.Domain.Services
{
    public interface IOrderDetailService
    {
        Task<OrderDetailResponse> AssignOrderDetailAsync(int orderId, int clothId);
        Task<OrderDetailResponse> UnassignOrderDetailAsync(int orderId, int clothId);
    }
}