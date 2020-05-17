using AutoMapper;
using Northland.Net.Application.Common.Mappings;
using Entities = Northland.Net.Domain;

namespace Northland.Net.Application.User.Queries.UserLogin
{
    public class UserLoginDto : IMapFrom<Entities.User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.User, UserLoginDto>()
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Password));
        }
    }
}