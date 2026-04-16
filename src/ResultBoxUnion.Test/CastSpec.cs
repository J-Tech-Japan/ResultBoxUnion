namespace ResultBoxUnion.Test;

public class CastSpec
{
    [Fact]
    public async Task TestCode()
    {
        await Task.CompletedTask;
        var castedResultBox = ResultBox<ITest>.FromValue(new Test()).Cast<ITest, Test>();
        Assert.True(castedResultBox.IsSuccess);

        var resultBoxTask = Task.FromResult(ResultBox<ITest>.FromValue(new Test()));
        var castedResultBox2 = await resultBoxTask.Cast<ITest, Test>();
        Assert.True(castedResultBox2.IsSuccess);
    }

    [Fact]
    public void TestCode2()
    {
        var resultBox = ResultBox<ITest>.FromValue(new Test());
        var castedResultBox = resultBox.Cast<ITest, Test>();
        Assert.True(castedResultBox.IsSuccess);
    }

    public interface ITest { }
    public record Test : ITest;
}
