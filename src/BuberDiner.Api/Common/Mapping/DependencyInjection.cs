using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BuberDiner.Api.Common.Mapping;

public static class DependencyInjection
{
    #region Public methods declaration

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }

    #endregion
}