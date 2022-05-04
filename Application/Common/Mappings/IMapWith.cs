namespace Application.Common.Mappings;
using AutoMapper;
public interface IMapWith<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}