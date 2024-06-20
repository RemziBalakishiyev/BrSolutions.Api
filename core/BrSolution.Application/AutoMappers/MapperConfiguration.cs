using AutoMapper;
using System.Reflection;

namespace BrSolution.Application.AutoMappers;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var mapsFrom = LoadCustomMappings(assembly);
        var mapsTo = LoadStandardMappings(assembly);
        foreach (var map in mapsFrom)
        {
            map.CreateMappings(this);
        }
        foreach (var map in mapsTo)
        {
            CreateMap(map.Source, map.Destination).ReverseMap();
        }
    }



    private static IList<MapModel> LoadStandardMappings(Assembly rootAssembly)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        return types
            .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
            .Select(x => new MapModel(x, x
                         .GetInterfaces()
                         .First(i => i.IsGenericType
                                     && i.GetGenericTypeDefinition() ==
                                     typeof(IMapTo<>)).GenericTypeArguments[0]))
            .ToList();

        
    }


    private static IList<ICustomMapping> LoadCustomMappings(Assembly rootAssembly)
    {
        var types = rootAssembly.GetExportedTypes();

        var mapsFrom = (
            from type in types
            from instance in type.GetInterfaces()
            where
                typeof(ICustomMapping).IsAssignableFrom(type) &&
                !type.IsAbstract &&
                !type.IsInterface
            select (ICustomMapping)Activator.CreateInstance(type)).ToList();

        return mapsFrom;
    }
}
