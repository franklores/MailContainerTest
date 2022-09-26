namespace MailContainerTest.Tests;

using MailContainerTest.Application.Services;
using MailContainerTest.Infrastructure.Services;

using Microsoft.Extensions.Configuration;

using Xunit;

public class MailContainerDataStoreFactoryUnitTests
{
    [Fact]
    public void FactoryShouldReturnBackupMailContainerDataStoreWhenConfigurationsIsBackup()
    {
        //arrange
        var inMemorySettings = new Dictionary<string, string> { { "DataStoreType", "Backup" } };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var factory = new MailContainerDataStoreFactory(configuration);

        //act
        var result = factory.CreateContainerDataStore();

        //assert
        Assert.IsType<BackupMailContainerDataStore>(result);
    }

    [Fact]
    public void FactoryShouldReturnMailContainerDataStoreWhenConfigurationsIsNotBackup()
    {
        //arrange
        var inMemorySettings = new Dictionary<string, string> { { "DataStoreType", "SomeValue" } };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var factory = new MailContainerDataStoreFactory(configuration);

        //act
        var result = factory.CreateContainerDataStore();

        //assert
        Assert.IsType<MailContainerDataStore>(result);
    }
}