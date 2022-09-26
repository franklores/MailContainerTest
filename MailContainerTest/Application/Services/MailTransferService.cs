namespace MailContainerTest.Application.Services;

using MailContainerTest.Application.ExtensionMethods;
using MailContainerTest.Application.Interfaces;
using MailContainerTest.Application.Models;
using MailContainerTest.Domain;
using MailContainerTest.Domain.Enums;

using Microsoft.Extensions.Logging;

public class MailTransferService : IMailTransferService
{
    private readonly ILogger<MailTransferService> _logger;
    private readonly IMailContainerDataStore _mailContainerDataStore;
    private readonly IValidator<MakeMailTransferRequest> _validator;

    public MailTransferService(IMailContainerDataStore mailContainerDataStore, IValidator<MakeMailTransferRequest> validator, ILogger<MailTransferService> logger)
    {
        _mailContainerDataStore = mailContainerDataStore;
        _validator = validator;
        _logger = logger;
    }

    public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
    {
        //validate incoming request
        var validationResult = _validator.Validate(request);

        if (!validationResult.Success)
            return new MakeMailTransferResult() { Success = validationResult.Success };

        var sourceMailContainer = _mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);
        var destinationMailContainer = _mailContainerDataStore.GetMailContainer(request.DestinationMailContainerNumber);

        var containersValidationResult = ValidateContainers(request, sourceMailContainer, destinationMailContainer);

        if (!containersValidationResult)
            return new MakeMailTransferResult() { Success = false };

        try
        {
            sourceMailContainer.Capacity -= request.NumberOfMailItems;
            _mailContainerDataStore.UpdateMailContainer(sourceMailContainer);

            destinationMailContainer.Capacity += request.NumberOfMailItems;
            _mailContainerDataStore.UpdateMailContainer(destinationMailContainer);

            return new MakeMailTransferResult() { Success = true };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred");

            return new MakeMailTransferResult() { Success = false };
        }
    }

    private static bool ValidateContainers(MakeMailTransferRequest request, MailContainer source, MailContainer destination)
    {
        if (source is null || destination is null)
            return false;

        if (!destination.AcceptsMailType(request.MailType))
            return false;

        switch (request.MailType)
        {
            case MailType.StandardLetter:
                break;

            case MailType.LargeLetter:
                return destination.HasCapacity(request.NumberOfMailItems);

            case MailType.SmallParcel:
                return destination.IsOperational();

            default:
                break;
        }

        return true;
    }
}