namespace MailContainerTest.Application.Interfaces;
public interface IMailContainerDataStoreFactory
{
    IMailContainerDataStore CreateContainerDataStore();
}