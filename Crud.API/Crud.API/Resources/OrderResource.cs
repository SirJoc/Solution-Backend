using Crud.API.Domain.Models;

namespace Crud.API.Resources
{
    public class OrderResource
    {
        public int Id { get; set; }
        public ClothResource Cloth { get; set; }
    }
}