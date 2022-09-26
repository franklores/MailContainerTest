namespace MailContainerTest.Domain;

using MailContainerTest.Domain.Enums;

public class MailContainer
{
    public AllowedMailType AllowedMailType { get; set; }

    public int Capacity { get; set; }

    public string MailContainerNumber { get; set; }

    public MailContainerStatus Status { get; set; }
}