namespace MailContainerTest.Application.Services;

using MailContainerTest.Application.Interfaces;
using MailContainerTest.Infrastructure.Services;

using Microsoft.Extensions.Configuration;

public class MailContainerDataStoreFactory : IMailContainerDataStoreFactory
{
    private readonly IConfiguration _configuration;

    public MailContainerDataStoreFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IMailContainerDataStore CreateContainerDataStore()
    => _configuration.GetValue<string>("DataStoreType") switch
    {
        "Backup" => new BackupMailContainerDataStore(),
        _ => new MailContainerDataStore(),
    };
}
