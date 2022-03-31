using AutoMapper;
using Crud.API.Domain.Models;
using Crud.API.Resources;

namespace Crud.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveClothResource, Cloth>();
            CreateMap<SaveOrderResource, Order>();
        }
    }
}