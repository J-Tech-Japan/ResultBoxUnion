namespace ResultBoxUnion.Test;

public class UnwrapTest
{
    [Fact]
    public void UnwrapSpec()
    {
        var sut = ResultBox.FromValue(2)
            .UnwrapBox(v => v + 1);
        Assert.Equal(3, sut);
    }

    [Fact]
    public void UnwrapSpecThrows()
    {
        Assert.Throws<ApplicationException>(() =>
        {
            ResultBox<int>.FromException(new ApplicationException("test")).UnwrapBox();
        });
    }

    [Fact]
    public async Task UnwrapTaskSpec1()
    {
        var sut = await Task.FromResult(ResultBox.FromValue(2)).UnwrapBox(v => v + 1);
        Assert.Equal(3, sut);
    }

    [Fact]
    public async Task UnwrapTaskSpec2()
    {
        var sut = await Task.FromResult(ResultBox.FromValue(2))
            .UnwrapBox(async v => await Task.FromResult(v + 1));
        Assert.Equal(3, sut);
    }

    [Fact]
    public async Task UnwrapTaskSpec3()
    {
        var sut = await Task.FromResult(ResultBox.FromValue(2)).UnwrapBox();
        Assert.Equal(2, sut);
    }

    [Fact]
    public async Task UnwrapTaskSpec3Throws()
    {
        await Assert.ThrowsAsync<ApplicationException>(async () =>
        {
            await Task.FromResult(ResultBox<int>.FromException(new ApplicationException("test")))
                .UnwrapBox();
        });
    }
}
