namespace MailContainerTest.Tests;

using MailContainerTest.Application.Models;
using MailContainerTest.Application.Validators;

using Xunit;

public class MakeMailTransferRequestValidatorUnitTests
{
    [Fact]
    public void RequestWithInvalidSourceContainerNumberShouldFail()
    {
        //arrange
        var request = new MakeMailTransferRequest();
        var sut = new MakeMailTransferRequestValidator();

        //act
        var result = sut.Validate(request);

        //assert
        Assert.False(result.Success);
        Assert.Contains("SourceMailContainerNumber can't be null or empty", result.Errors);
    }

    [Fact]
    public void RequestWithInvalidDestinationContainerNumberShouldFail()
    {
        //arrange
        var request = new MakeMailTransferRequest();
        var sut = new MakeMailTransferRequestValidator();

        //act
        var result = sut.Validate(request);

        //assert
        Assert.False(result.Success);
        Assert.Contains("DestinationMailContainerNumber can't be null or empty", result.Errors);
    }

    [Fact]
    public void RequestWithValidContainerNumberShouldSucceed()
    {
        //arrange
        var request = new MakeMailTransferRequest() { SourceMailContainerNumber = "1", DestinationMailContainerNumber = "2" };

        var sut = new MakeMailTransferRequestValidator();

        //act
        var result = sut.Validate(request);

        //assert
        Assert.True(result.Success);
        Assert.Empty(result.Errors);
    }
}