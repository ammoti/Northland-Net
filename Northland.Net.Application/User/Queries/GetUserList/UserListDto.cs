using AutoMapper;
using Northland.Net.Application.Common.Mappings;
using Entities = Northland.Net.Domain;

namespace Northland.Net.Application.User.Queries.GetUserList
{
    public class UserListDto : IMapFrom<Entities.User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.User, UserListDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ToString()))
            .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl));
        }
    }
}