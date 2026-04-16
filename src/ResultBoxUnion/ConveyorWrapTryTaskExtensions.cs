namespace ResultBoxUnion;

public static class ConveyorWrapTryTaskExtensions
{
    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<TValue, TValueResult>(
        this Task<ResultBox<TValue>> current,
        Func<TValue, TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => (await current).ConveyorWrapTry(handleValueFunc, exceptionMapper);

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<TValue, TValueResult>(
        this Task<ResultBox<TValue>> current,
        Func<TValue, Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => await (await current).ConveyorWrapTry(handleValueFunc, exceptionMapper);

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<TValue, TValueResult>(
        this Task<ResultBox<TValue>> current,
        Func<TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => (await current).ConveyorWrapTry(handleValueFunc, exceptionMapper);

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<TValue, TValueResult>(
        this Task<ResultBox<TValue>> current,
        Func<Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => await (await current).ConveyorWrapTry(handleValueFunc, exceptionMapper);
}
