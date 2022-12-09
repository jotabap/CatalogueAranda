using AutoMapper;
using CatalogueAranda.Entity.Entities;
using CatalogueAranda.Models.DTOs;

namespace CatalogueAranda.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductInsertDTO, Product>();
        }
    }
}
