using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Busniess.Factories;
using Xunit;
using Busniess.Helpers;

namespace UppgiftSeeSharp.Tests.Helpers;

public class ErrorLogger_Tests
{
    /* With the help of chatgpt 4 i made a test for my ErrorLogger,
     * first initiate the errorLogger class and set the test message,
     * then intitate the stringWriter, TextWriterTraceListener catches the output sent to it,
     * then using the errorlogger it compares it to the output from the stringwriter */
    [Fact]
    public void ErrorMessage_ShouldReturnDebugOutput()
    {
        // arrange
        var errorLogger = new ErrorLogger();
        var errorMessage = "Testing Error Message";

        var stringWriter = new StringWriter();
        var debugListener = new TextWriterTraceListener(stringWriter);
        Trace.Listeners.Add(debugListener);

        // act
        errorLogger.ErrorMessage(errorMessage);

        // assert
        debugListener.Flush();
        var output = stringWriter.ToString().Trim();
        Assert.Equal(errorMessage, output);
        Trace.Listeners.Remove(debugListener);
    }
}
