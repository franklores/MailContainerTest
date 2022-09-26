namespace MailContainerTest.Application.Models;

using MailContainerTest.Domain.Enums;

public class MakeMailTransferRequest
{
    public string SourceMailContainerNumber { get; set; } = string.Empty;

    public string DestinationMailContainerNumber { get; set; } = string.Empty;

    public MailType MailType { get; set; }

    public int NumberOfMailItems { get; set; }

    public DateTime TransferDate { get; set; }
}