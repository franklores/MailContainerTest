namespace MailContainerTest.Application.Interfaces;

using MailContainerTest.Application.Models;

public interface IMailTransferService
{
    MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request);
}