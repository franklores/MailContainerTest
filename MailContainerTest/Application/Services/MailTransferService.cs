namespace MailContainerTest.Application.Services;

using MailContainerTest.Application.ExtensionMethods;
using MailContainerTest.Application.Interfaces;
using MailContainerTest.Application.Models;
using MailContainerTest.Domain.Enums;

public class MailTransferService : IMailTransferService
{
    private readonly IMailContainerDataStore _mailContainerDataStore;
    private readonly IValidator<MakeMailTransferRequest> _validator;

    public MailTransferService(IMailContainerDataStore mailContainerDataStore, IValidator<MakeMailTransferRequest> validator)
    {
        _mailContainerDataStore = mailContainerDataStore;
        _validator = validator;
    }

    public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
    {
        //validate incoming request
        var validationResult = _validator.Validate(request);

        if (!validationResult.Success)
            return new MakeMailTransferResult() { Success = validationResult.Success };

        //check if containers exists
        var mailContainer = _mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

        if (mailContainer is null)
            return new MakeMailTransferResult() { Success = false };

        if (!mailContainer.AcceptsMailType(request.MailType))
            return new MakeMailTransferResult() { Success = false };



        var result = new MakeMailTransferResult();

        switch (request.MailType)
        {
            case MailType.StandardLetter:
                break;

            case MailType.LargeLetter:
                if (mailContainer.Capacity < request.NumberOfMailItems)
                {
                    result.Success = false;
                }
                break;

            case MailType.SmallParcel:
                if (mailContainer.Status != MailContainerStatus.Operational)
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