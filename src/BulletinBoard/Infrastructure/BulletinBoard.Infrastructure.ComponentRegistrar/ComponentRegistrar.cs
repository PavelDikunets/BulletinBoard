using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.AppServices.Contexts.Announcements.Services;
using BulletinBoard.Infrastructure.DataAccess.Contexts.Announcements.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BulletinBoard.Infrastructure.ComponentRegistrar;

public static class ComponentRegistrar
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<IAnnouncementService, AnnouncementService>();
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IAnnouncementRepository, AnnouncementRepository>();

        return services;
    }
}