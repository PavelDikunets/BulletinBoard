using AutoMapper;
using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.AppServices.Contexts.Announcements.Services;
using BulletinBoard.Infrastructure.ComponentRegistrar.MapProfiles;
using BulletinBoard.Infrastructure.DataAccess.Contexts.Announcements.Repositories;
using BulletinBoard.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BulletinBoard.Infrastructure.ComponentRegistrar;

public static class ComponentRegistrar
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<IAnnouncementService, AnnouncementService>();
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

        return services;
    }

    
    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AnnouncementProfile>();
            }
        );
        configuration.AssertConfigurationIsValid();
        return configuration;
    }
}