using System.ComponentModel.DataAnnotations;

namespace Crud.API.Resources
{
    public class SaveClothResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}