namespace ResultBoxUnion.Test;

public class IsSuccessSpec
{
    [Fact]
    public void IsSuccess_ReturnsTrue_WhenResultIsSuccess()
    {
        var result = ResultBox<string>.FromValue("Success");
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void IsSuccess_ReturnsFalse_WhenException()
    {
        var result = ResultBox<string>.FromException(new ApplicationException("test"));
        Assert.False(result.IsSuccess);
    }
}
