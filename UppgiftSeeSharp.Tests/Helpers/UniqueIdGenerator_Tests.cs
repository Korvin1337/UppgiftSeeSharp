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

        // act
        string result = UniqueIdGenerator.GenerateUniqueId();

        // assert
        Assert.True(Guid.TryParse(result, out _));
        Assert.False(string.IsNullOrEmpty(result));

    }

}
