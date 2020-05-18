using AutoMapper;
using Northland.Net.Application.Common.Mappings;
using Northland.Net.Domain;
using Entities = Northland.Net.Domain;

namespace Northland.Net.Application.Supplier.Queries.GetSupplierList
{
    public class SupplierListDto : IMapFrom<Entities.Supplier>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public Status Status { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Supplier, SupplierListDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
            .ForMember(d => d.ContactTitle, opt => opt.MapFrom(s => s.ContactTitle))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status));
        }
    }
}