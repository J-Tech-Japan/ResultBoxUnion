using Xunit;
using UnionTest;

namespace UnionTest;

public class Union500Tests
{
    [Fact]
    public void Case501_AssignAndPatternMatch()
    {
        Union500 u = new Case501(501);
        var result = u.Value switch
        {
            Case501 c => c.Value,
            _ => -1
        };
        Assert.Equal(501, result);
    }

    [Fact]
    public void Case750_AssignAndPatternMatch()
    {
        Union500 u = new Case750(750);
        var result = u.Value switch
        {
            Case750 c => c.Value,
            _ => -1
        };
        Assert.Equal(750, result);
    }

    [Fact]
    public void Case1000_AssignAndPatternMatch()
    {
        Union500 u = new Case1000(1000);
        var result = u.Value switch
        {
            Case1000 c => c.Value,
            _ => -1
        };
        Assert.Equal(1000, result);
    }

    [Theory]
    [InlineData(501)]
    [InlineData(600)]
    [InlineData(700)]
    [InlineData(800)]
    [InlineData(900)]
    [InlineData(1000)]
    public void SampleCases_AssignAndVerifyValue(int value)
    {
        Union500 u = value switch
        {
            501 => new Case501(value),
            600 => new Case600(value),
            700 => new Case700(value),
            800 => new Case800(value),
            900 => new Case900(value),
            1000 => new Case1000(value),
            _ => throw new InvalidOperationException()
        };

        var matched = u.Value switch
        {
            Case501 c => c.Value,
            Case600 c => c.Value,
            Case700 c => c.Value,
            Case800 c => c.Value,
            Case900 c => c.Value,
            Case1000 c => c.Value,
            _ => -1
        };

        Assert.Equal(value, matched);
    }
}
