﻿namespace MailContainerTest.Application.ExtensionMethods;

using MailContainerTest.Domain;
using MailContainerTest.Domain.Enums;

public static class MailContainerExtensionMethods
{
    public static bool AcceptsMailType(this MailContainer mailContainer, MailType mailType)
    => mailType switch
    {
        MailType.StandardLetter => mailContainer.AllowedMailType.HasFlag(AllowedMailType.StandardLetter),
        MailType.LargeLetter => mailContainer.AllowedMailType.HasFlag(AllowedMailType.LargeLetter),
        MailType.SmallParcel => mailContainer.AllowedMailType.HasFlag(AllowedMailType.SmallParcel),
        _ => false,
    };

    public static bool IsOperational(this MailContainer mailContainer)
    => mailContainer.Status == MailContainerStatus.Operational;

    public static bool HasCapacity(this MailContainer mailContainer, int items)
    => mailContainer.Capacity >= items;
}
