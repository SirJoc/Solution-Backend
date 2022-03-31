namespace Crud.API.Domain.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ClothId { get; set; }
        public Cloth Cloth { get; set; }
    }
}