namespace Crud.API.Resources
{
    public class OrderDetailResource
    {
        public int Id { get; set; }
        public OrderResource Order { get; set; }
    }
}