namespace MailContainerTest.Application.Interfaces;
public interface IValidator<T>
{
    ValidationResult Validate(T model);
}
