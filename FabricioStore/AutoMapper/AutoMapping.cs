using AutoMapper;
using FabricioStore.Models;
using FabricioStore.ViewModels;

namespace FabricioStore.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
