namespace MailContainerTest.Application.Validators;

using MailContainerTest.Application.Interfaces;
using MailContainerTest.Application.Models;

public class MakeMailTransferRequestValidator : IValidator<MakeMailTransferRequest>
{

    public ValidationResult Validate(MakeMailTransferRequest model)
    {
        var validationResult = new ValidationResult();

        if (model is null)
        {
            validationResult.Errors.Add("Model can't be null");
            return validationResult;
        }

        if (string.IsNullOrEmpty(model.SourceMailContainerNumber))
            validationResult.Errors.Add("SourceMailContainerNumber can't be null or empty");

        if (string.IsNullOrEmpty(model.DestinationMailContainerNumber))
            validationResult.Errors.Add("DestinationMailContainerNumber can't be null or empty");

        return validationResult;
    }
}