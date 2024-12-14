using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Busniess.Helpers;
using Busniess.Models;

namespace UppgiftSeeSharp.Tests.Helpers;

public class UniqueIdGenerator_Tests
{

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
