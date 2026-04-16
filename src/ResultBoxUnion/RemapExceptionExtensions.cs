namespace ResultBoxUnion;

public static class RemapExceptionExtensions
{
    public static ResultBox<TValue> RemapException<TValue>(
        this ResultBox<TValue> current,
        Func<Exception, Exception> remapExceptionFunc)
        where TValue : notnull
        => current switch
        {
            Exception e => remapExceptionFunc(e),
            TValue v => v,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValue>> RemapException<TValue>(
        this ResultBox<TValue> current,
        Func<Exception, Task<Exception>> remapExceptionFuncAsync)
        where TValue : notnull
        => current switch
        {
            Exception e => await remapExceptionFuncAsync(e),
            TValue v => v,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValue>> RemapException<TValue>(
        this Task<ResultBox<TValue>> current,
        Func<Exception, Exception> remapExceptionFunc)
        where TValue : notnull
        => (await current).RemapException(remapExceptionFunc);

    public static async Task<ResultBox<TValue>> RemapException<TValue>(
        this Task<ResultBox<TValue>> current,
        Func<Exception, Task<Exception>> remapExceptionFuncAsync)
        where TValue : notnull
        => await (await current).RemapException(remapExceptionFuncAsync);
}
