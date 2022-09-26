namespace MailContainerTest.Application.Interfaces;

using System.Collections.Generic;
using System.Linq;

public struct ValidationResult
{
    public ValidationResult()
    {
        Errors = new List<string>();
    }

    public bool Success => !Errors.Any();

    public List<string> Errors { get; }
}
