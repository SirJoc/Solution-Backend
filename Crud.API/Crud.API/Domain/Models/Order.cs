using System.Collections.Generic;

namespace Crud.API.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
        public Cloth Cloth { get; set; }
        public int ClothId { get; set; }
    }
}