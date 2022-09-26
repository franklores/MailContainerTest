namespace MailContainerTest.Application.Services;

using MailContainerTest.Application.Interfaces;
using MailContainerTest.Application.Models;
using MailContainerTest.Domain.Enums;

public class MailTransferService : IMailTransferService
{
    private readonly IMailContainerDataStore _mailContainerDataStore;

    public MailTransferService(IMailContainerDataStore mailContainerDataStore)
    {
        _mailContainerDataStore = mailContainerDataStore;
    }

    public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
    {
        var mailContainer = _mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

        var result = new MakeMailTransferResult();

        switch (request.MailType)
        {
            case MailType.StandardLetter:
                if (mailContainer == null)
                {
                    result.Success = false;
                }
                else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.StandardLetter))
                {
                    result.Success = false;
                }
                break;

            case MailType.LargeLetter:
                if (mailContainer == null)
                {
                    result.Success = false;
                }
                else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.LargeLetter))
                {
                    result.Success = false;
                }
                else if (mailContainer.Capacity < request.NumberOfMailItems)
                {
                    result.Success = false;
                }
                break;

            case MailType.SmallParcel:
                if (mailContainer == null)
                {
                    result.Success = false;
                }
                else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
                {
                    result.Success = false;
                }
                else if (mailContainer.Status != MailContainerStatus.Operational)
                {
                    result.Success = false;
                }
                break;
        }

        if (result.Success)
        {
            mailContainer.Capacity -= request.NumberOfMailItems;

            _mailContainerDataStore.UpdateMailContainer(mailContainer);
        }

        return result;
    }
}