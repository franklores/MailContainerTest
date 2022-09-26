namespace MailContainerTest.Application.Services;

using MailContainerTest.Application.Interfaces;
using MailContainerTest.Infrastructure.Services;

using Microsoft.Extensions.Configuration;

public class MailContainerDataStoreFactory
{
    public IMailContainerDataStore CreateContainerDataStore(IConfiguration configuration)
    => configuration.GetValue<string>("DataStoreType") switch
    {
        "Backup" => new BackupMailContainerDataStore(),
        _ => new MailContainerDataStore(),
    };
}
