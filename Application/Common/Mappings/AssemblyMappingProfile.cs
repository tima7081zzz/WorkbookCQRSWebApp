using System.Reflection;
using AutoMapper;

namespace Application.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly)
    {
        ApplyMappingFromAssembly(assembly);
    }

    private void ApplyMappingFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes().Where(x =>
            x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IMapWith<>)));

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var method = type.GetMethod("Mapping");
            method?.Invoke(instance, new object?[] { this });
        }
    }
}