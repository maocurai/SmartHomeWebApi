using SmartHomeWebApi.Services.DBFactory;

namespace SmartHomeWebApi.Services;

public static class ApplicationServiceProvider
{
    public static IServiceCollection AddDbFactory(this IServiceCollection services)
    {
        return services.AddScoped<IDbFactory, DbFactory>();
    }
}