using System.Collections.Generic;

namespace Crud.API.Domain.Models
{
    public class Cloth
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public IList<OrderDetail> OrdersDetails { get; set; }
    }
}