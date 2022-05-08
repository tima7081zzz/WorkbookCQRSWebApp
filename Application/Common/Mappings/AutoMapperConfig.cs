using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Common.Mappings;

public static class AutoMapperConfig
{
    public static Action<IMapperConfigurationExpression> RegisterMappers(
        Action<IMapperConfigurationExpression>? localConfigAction)
    {
        Action<IMapperConfigurationExpression> globalConfigAction = cfg =>
        {
            GenerateDtoMappings(cfg);
        };

        return localConfigAction == null ? globalConfigAction : globalConfigAction + localConfigAction;
    }

    private static void GenerateDtoMappings(IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<NoteBook, NoteBookLookupDto>();
    }
}