namespace MailContainerTest;

using MailContainerTest.Application.Interfaces;
using MailContainerTest.Application.Models;
using MailContainerTest.Application.Services;
using MailContainerTest.Application.Validators;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddMailContainerTest(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMailContainerDataStoreFactory, MailContainerDataStoreFactory>();
        services.AddScoped<IValidator<MakeMailTransferRequest>, MakeMailTransferRequestValidator>();
        services.AddScoped(svc => svc.GetRequiredService<IMailContainerDataStoreFactory>().CreateContainerDataStore());
        services.AddScoped<IMailTransferService, MailTransferService>();

        return services;
    }
}