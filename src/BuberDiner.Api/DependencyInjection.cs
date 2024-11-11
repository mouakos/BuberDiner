using BuberDiner.Api.Common.Errors;
using BuberDiner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDiner.Api;

public static class DependencyInjection
{
    #region Public methods declaration

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        services.AddMapper();
        return services;
    }

    #endregion
}