using Crud.API.Domain.Models;

namespace Crud.API.Domain.Services.Communication
{
    public class ClothResponse : BaseResponse<Cloth>
    {
        public ClothResponse(Cloth resource) : base(resource)
        {
        }

        public ClothResponse(string message) : base(message)
        {
        }
    }
}