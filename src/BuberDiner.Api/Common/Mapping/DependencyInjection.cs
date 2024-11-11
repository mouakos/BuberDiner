﻿using Mapster;
using MapsterMapper;
using System.Reflection;

namespace BuberDiner.Api.Common.Mapping
{
    public static class DependencyInjection
    {
        #region Public methods declaration

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }

        #endregion
    }
}