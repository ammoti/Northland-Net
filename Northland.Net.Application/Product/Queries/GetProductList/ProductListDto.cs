using AutoMapper;
using Northland.Net.Application.Common.Mappings;
using Northland.Net.Domain;
using Entities = Northland.Net.Domain;

namespace Northland.Net.Application.Product.Queries.GetProductList
{
    public class ProductListDto : IMapFrom<Entities.Product>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public float UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
        public long SupplierId { get; set; }
        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Product, ProductListDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.ProductName))
            .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
            .ForMember(d => d.UnitPrice, opt => opt.MapFrom(s => s.UnitPrice))
            .ForMember(d => d.Package, opt => opt.MapFrom(s => s.Package))
            .ForMember(d => d.IsDiscontinued, opt => opt.MapFrom(s => s.IsDiscontinued))
            .ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.SupplierId))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status));
        }
    }
}