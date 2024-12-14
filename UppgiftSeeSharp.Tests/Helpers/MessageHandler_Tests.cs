using Busniess.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Busniess.Helpers;
using Business.Helpers;
using Moq;

namespace UppgiftSeeSharp.Tests.Helpers;

public class MessageHandler_Tests
{

    [Fact]
    public void ShowMessage_ShouldReturnAStringMessage()
    {
        // arrange after changing my messagehandler by adding a consolewrapper class helper i can now mock the consolewrapper */
        var mockConsoleWrapper = new Mock<ConsoleWrapper>();
        mockConsoleWrapper.Setup(cw => cw.Clear()).Verifiable();
        mockConsoleWrapper.Setup(cw => cw.ReadKey()).Verifiable();

        var messageHandler = new MessageHandler(mockConsoleWrapper.Object);
        var testStringMessage = "Test string message";

        /* Suggestion of chatgpt 4 to be able to test my string message and compare the output from showmessage */
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Suggestion of chatgpt 4, wanna mock the readkey during the test
        var pressKey = new StringReader("x");
        Console.SetIn(pressKey);

        try
        {
            // act
            messageHandler.ShowMessage(testStringMessage);
            var actualOutput = stringWriter.ToString().Trim();

            // assert
            Assert.Equal(testStringMessage, actualOutput);
            /* Testing to clear and readkey mocking methods */
            mockConsoleWrapper.Verify(cw => cw.Clear(), Times.Once);
            mockConsoleWrapper.Verify(cw => cw.ReadKey(), Times.Once);
        } finally
        {
            /* By suggestion of chatgpt to ensure the streams are restored after the test has run for future tests */
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
    }

    [Fact]
    public void FormatUserDetails_ShouldReturnAFormattedUser()
    {
        // arrange
        var consoleWrapper = new ConsoleWrapper();
        var messageHandler = new MessageHandler(consoleWrapper);
        var testUser = new User()
        {
            Id = "1",
            FirstName = "Test",
            LastName = "Testsson",
            Email = "Test@Testsson.email.com",
            PhoneNumber = "0760432212",
            Address = "Testgatan 24",
            PostalNumber = "523 21",
            City = "TestStaden"
        };

        // Suggestion of gpt i should compare the testUser to an actual expected outcome */
        var testFormattedUser =
            "Id: 1\n" +
            "Name: Test Testsson\n" +
            "Email: Test@Testsson.email.com\n" +
            "PhoneNumber: 0760432212\n" +
            "Address: Testgatan 24 523 21 TestStaden\n";

        // act
        var formattedUser = messageHandler.FormatUserDetails(testUser);

        // assert
        Assert.Equal(testFormattedUser, formattedUser);
    }

    [Fact]
    public void ShowUser_ShouldReturnConsoleWriteLineOfUser()
    {
        // arrange
        var consoleWrapper = new ConsoleWrapper();
        var messageHandler = new MessageHandler(consoleWrapper);
        var testUser = new User()
        {
            Id = "1",
            FirstName = "Test",
            LastName = "Testsson",
            Email = "Test@Testsson.email.com",
            PhoneNumber = "0760432212",
            Address = "Testgatan 24",
            PostalNumber = "523 21",
            City = "TestStaden"
        };

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var testFormattedUser =
            "Id: 1\n" +
            "Name: Test Testsson\n" +
            "Email: Test@Testsson.email.com\n" +
            "PhoneNumber: 0760432212\n" +
            "Address: Testgatan 24 523 21 TestStaden";

        // act suggestion of chatgpt4 i need to call my showuser method here to test the output of the console.writeline => expected
        messageHandler.ShowUser(testUser);

        // assert
        var actualOutput = stringWriter.ToString().Trim();
        Assert.Equal(testFormattedUser, actualOutput);
    }

}
