using System;
using AutoMapper;
using Northland.Net.Application.Common.Mappings;
using Northland.Net.Domain;
using Entities = Northland.Net.Domain;

namespace Northland.Net.Application.Order.Queries.GetOrderList
{
    public class OrderListDto : IMapFrom<Entities.Order>
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public float TotalAmount { get; set; }
        public long UserId { get; set; }
        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Order, OrderListDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate))
            .ForMember(d => d.OrderNumber, opt => opt.MapFrom(s => s.OrderNumber))
            .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.TotalAmount))
            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status));
        }
    }
}