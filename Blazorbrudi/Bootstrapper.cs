using Microsoft.Extensions.DependencyInjection;

namespace Blazorbrudi;

public static class Bootstrapper
{
    public static void AddBlazorbrudi(this IServiceCollection services)
    {
        /* Interop Services */
        services.AddTransient<SplitViewInterop>();
    }
}
