using Microsoft.Extensions.DependencyInjection;
using RickAndMortyBlazorV1.Service;

namespace RickAndMortyBlazorV1;
public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient(_ => new HttpClient());
        services.AddSingleton<IRickAndMortyService, RickAndMortyService>();

    }
}
