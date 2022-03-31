using System.ComponentModel.DataAnnotations;

namespace Crud.API.Resources
{
    public class SaveOrderResource
    {
        [Required]
        public int ClothId { get; set; }
    }
}