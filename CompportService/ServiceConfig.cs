using CompportService.Interfaces;
using CompportService.Services;
using CompportService.Services.Account;
using CompportService.Services.Privileges;
using Microsoft.Extensions.DependencyInjection;

namespace CompportService;

public static class ServiceConfig
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthanticationService, AuthanticationService>();
        services.AddScoped<IAccountManagementService, AccountManagementService>();
        services.AddScoped<IDeviceManagementService, DeviceManagementService>();
        services.AddScoped<IComplaintManagementService, ComplaintManagementService>();

        return services;
    }
}
