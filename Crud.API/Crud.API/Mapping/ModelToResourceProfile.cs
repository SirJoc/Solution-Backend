using AutoMapper;
using Crud.API.Domain.Models;
using Crud.API.Domain.Services;
using Crud.API.Resources;

namespace Crud.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Cloth, ClothResource>(); 
            CreateMap<OrderDetail, OrderDetailResource>();
            CreateMap<Order, OrderResource>();
        }

        
    }
}