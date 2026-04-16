namespace ResultBoxUnion;

public static class MatchExtensions
{
    public static TUnionResult Match<TValue, TUnionResult>(
        this ResultBox<TValue> result,
        Func<TValue, TUnionResult> successFunc,
        Func<Exception, TUnionResult> errorFunc)
        where TValue : notnull
        => result switch
        {
            TValue v => successFunc(v),
            Exception e => errorFunc(e),
            null => errorFunc(new ResultValueNullException())
        };

    public static async Task<TUnionResult> Match<TValue, TUnionResult>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, TUnionResult> successFunc,
        Func<Exception, TUnionResult> errorFunc)
        where TValue : notnull
        => (await result).Match(successFunc, errorFunc);
}
