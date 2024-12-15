using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Busniess.Helpers;
using Busniess.Models;

namespace UppgiftSeeSharp.Tests.Helpers;

/* UniqueIdGenerator Tests made with the help of chatgpt 4o */
public class UniqueIdGenerator_Tests
{
    /* Creates a string with the UniqueIdGenerator and asserts it trying to parse the string back to a guid and check if null or empty */
    [Fact]
    public void GenerateUniqueId_ShouldReturnStringOfTypeGuid()
    {

        // arrange (create instance of object because of code update, chat gpt 4o suggestion */
        var uniqueIdGenerator = new UniqueIdGenerator();

        // act
        string result = uniqueIdGenerator.GenerateUniqueId();

        // assert
        Assert.True(Guid.TryParse(result, out _));
        Assert.False(string.IsNullOrEmpty(result));

    }

}
