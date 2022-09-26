namespace MailContainerTest.Tests;

using MailContainerTest.Application.ExtensionMethods;
using MailContainerTest.Domain;
using MailContainerTest.Domain.Enums;

using Xunit;

public class MailContainerUnitTests
{
    [Theory]
    [InlineData(AllowedMailType.LargeLetter, MailType.StandardLetter)]
    [InlineData(AllowedMailType.LargeLetter, MailType.SmallParcel)]
    [InlineData(AllowedMailType.StandardLetter, MailType.LargeLetter)]
    [InlineData(AllowedMailType.StandardLetter, MailType.SmallParcel)]
    public void MailContainerAcceptsMailTypeReturnsFalseWhenMailTypeIsNotInAllowedTypes(AllowedMailType allowedMailType, MailType mailType)
    {
        //arrange
        var sut = new MailContainer() { AllowedMailType = allowedMailType };

        //act
        var result = sut.AcceptsMailType(mailType);

        //assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(AllowedMailType.SmallParcel, MailType.StandardLetter)]
    [InlineData(AllowedMailType.SmallParcel, MailType.LargeLetter)]
    [InlineData(AllowedMailType.SmallParcel, MailType.SmallParcel)]
    [InlineData(AllowedMailType.LargeLetter, MailType.LargeLetter)]
    [InlineData(AllowedMailType.StandardLetter, MailType.StandardLetter)]
    public void MailContainerAcceptsMailTypeReturnsTrueWhenMailTypeIsInAllowedTypes(AllowedMailType allowedMailType, MailType mailType)
    {
        //arrange
        var sut = new MailContainer() { AllowedMailType = allowedMailType };

        //act
        var result = sut.AcceptsMailType(mailType);

        //assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(MailContainerStatus.Operational, true)]
    [InlineData(MailContainerStatus.NoTransfersIn, false)]
    [InlineData(MailContainerStatus.OutOfService, false)]
    public void MailContainerIsOperationalReturnsTrueWhenContainerStatusIsOperational(MailContainerStatus status, bool expected)
    {
        //arrange
        var sut = new MailContainer() { Status = status };

        //act
        var result = sut.IsOperational();

        //assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, true)]
    [InlineData(20, false)]
    public void MailContainerHasCapacityReturnsTrueWhenContainerCapacityEqualsOrExceedsNoOfItemsToAdd(int noOfItemsToAdd, bool expected)
    {
        //arrange
        var sut = new MailContainer() { Capacity = 15 };

        //act
        var result = sut.HasCapacity(noOfItemsToAdd);

        //assert
        Assert.Equal(expected, result);
    }


}