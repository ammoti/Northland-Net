using AutoMapper;

namespace Northland.Net.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mappings(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}