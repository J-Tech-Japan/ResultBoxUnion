namespace ResultBoxUnion;

public static class LogExtensions
{
    public static ResultBox<TValue> LogResult<TValue>(this ResultBox<TValue> result)
        where TValue : notnull => result.LogResult("");

    public static ResultBox<TValue> LogResult<TValue>(this ResultBox<TValue> result, string marking)
        where TValue : notnull
    {
        var prefix = string.IsNullOrWhiteSpace(marking) ? "" : marking + " ";
        switch (result)
        {
            case TValue v:
                Console.WriteLine(prefix + "Value: " + v);
                break;
            case Exception e:
                Console.WriteLine(prefix + "Error: " + e.Message);
                break;
        }
        return result;
    }

    public static async Task<ResultBox<TValue>> LogResult<TValue>(
        this Task<ResultBox<TValue>> resultTask) where TValue : notnull
        => (await resultTask).LogResult("");

    public static async Task<ResultBox<TValue>> LogResult<TValue>(
        this Task<ResultBox<TValue>> resultTask, string marking) where TValue : notnull
        => (await resultTask).LogResult(marking);
}
