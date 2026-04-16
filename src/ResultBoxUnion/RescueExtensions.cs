namespace ResultBoxUnion;

public static class RescueExtensions
{
    public static ResultBox<TValue> Rescue<TValue>(
        this ResultBox<TValue> current,
        Func<Exception, ValueOrException<TValue>> remapExceptionFunc)
        where TValue : notnull
        => current switch
        {
            Exception e => remapExceptionFunc(e) switch
            {
                ExceptionMarker => (ResultBox<TValue>)e,
                TValue v => v,
                null => (ResultBox<TValue>)e
            },
            TValue v => v,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValue>> Rescue<TValue>(
        this ResultBox<TValue> current,
        Func<Exception, Task<ValueOrException<TValue>>> remapExceptionFunc)
        where TValue : notnull
        => current switch
        {
            Exception e => await remapExceptionFunc(e) switch
            {
                ExceptionMarker => (ResultBox<TValue>)e,
                TValue v => v,
                null => (ResultBox<TValue>)e
            },
            TValue v => v,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValue>> Rescue<TValue>(
        this Task<ResultBox<TValue>> current,
        Func<Exception, ValueOrException<TValue>> remapExceptionFunc)
        where TValue : notnull
        => (await current).Rescue(remapExceptionFunc);

    public static async Task<ResultBox<TValue>> Rescue<TValue>(
        this Task<ResultBox<TValue>> current,
        Func<Exception, Task<ValueOrException<TValue>>> remapExceptionFunc)
        where TValue : notnull
        => await (await current).Rescue(remapExceptionFunc);
}
