using AutoMapper;
using ArticulosAPI.Modelos;
using ArticulosAPI.Dto;

public class MappingConfiguration {
 public static MapperConfiguration RegisterMaps()
{
    var mappingConfig = new MapperConfiguration(config =>
    {
        config.CreateMap<ArticuloDto, Articulo>();
        config.CreateMap<Articulo, ArticuloDto>();
    });
    return mappingConfig;
}
}