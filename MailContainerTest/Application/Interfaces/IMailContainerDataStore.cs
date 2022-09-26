namespace MailContainerTest.Application.Interfaces;

using MailContainerTest.Domain;

public interface IMailContainerDataStore
{
    MailContainer GetMailContainer(string mailContainerNumber);

    void UpdateMailContainer(MailContainer mailContainer);
}