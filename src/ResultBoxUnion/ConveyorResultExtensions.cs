namespace ResultBoxUnion;

public static class ConveyorResultExtensions
{
    public static ResultBox<TValueResult> ConveyorResult<TValue, TValueResult>(
        this ResultBox<TValue> current,
        Func<ResultBox<TValue>, ResultBox<TValueResult>> valueFunc)
        where TValue : notnull where TValueResult : notnull
        => current switch
        {
            Exception e => e,
            TValue => valueFunc(current),
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValueResult>> ConveyorResult<TValue, TValueResult>(
        this ResultBox<TValue> current,
        Func<ResultBox<TValue>, Task<ResultBox<TValueResult>>> valueFunc)
        where TValue : notnull where TValueResult : notnull
        => current switch
        {
            Exception e => e,
            TValue => await valueFunc(current),
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValueResult>> ConveyorResult<TValue, TValueResult>(
        this Task<ResultBox<TValue>> currentTask,
        Func<ResultBox<TValue>, ResultBox<TValueResult>> valueFunc)
        where TValue : notnull where TValueResult : notnull
        => (await currentTask).ConveyorResult(valueFunc);

    public static async Task<ResultBox<TValueResult>> ConveyorResult<TValue, TValueResult>(
        this Task<ResultBox<TValue>> currentTask,
        Func<ResultBox<TValue>, Task<ResultBox<TValueResult>>> valueFunc)
        where TValue : notnull where TValueResult : notnull
        => await (await currentTask).ConveyorResult(valueFunc);
}
