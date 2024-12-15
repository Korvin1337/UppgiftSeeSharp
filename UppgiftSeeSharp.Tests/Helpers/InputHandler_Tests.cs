using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Helpers;
using Busniess.Helpers;
using Moq;

namespace UppgiftSeeSharp.Tests.Helpers;

/* InputHandler Tests made with the help of chatgpt 4o */
public class InputHandler_Tests
{
    /* Writing a test for GetInput method with the help of my consolewrapper which executes readline and write methods
     * This makes them mockable
     * ChatGpt 4 help me with this logic aswell as inspiration of previous tests made */
    /* Creates a consolewrapper and a testPrompt. Mocks the ReadLine and Write methods
     * Users InputHandler wuth the testPrompt and then compares it with the expected "Test Input" using asssert
     * Finally checks if the Write and ReadLine methods has been run once */
    [Fact]
    public void GetInput_ShouldReturnUserInput()
    {
        // arrange /* Mock the console, use a testprompt */
        var mockConsoleWrapper = new Mock<ConsoleWrapper>();
        var testPrompt = "Test Input";

        /* Mock the readline and write methods and compaare/verify them */
        mockConsoleWrapper.Setup(cw => cw.ReadLine()).Returns("Test Input");
        mockConsoleWrapper.Setup(cw => cw.Write(It.IsAny<String>())).Verifiable();
        
        /* initiate the inputHandler with the mock object */
        var inputHandler = new InputHandler(mockConsoleWrapper.Object);

        // act Get a result to compare to the "Test Input" */
        var result = inputHandler.GetInput(testPrompt);

        // assert
        Assert.Equal("Test Input", result);
        mockConsoleWrapper.Verify(cw => cw.Write(testPrompt), Times.Once());
        mockConsoleWrapper.Verify(cw => cw.ReadLine(), Times.Once());
    }
}
