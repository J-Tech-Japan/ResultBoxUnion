namespace ResultBoxUnion;

public static class VerifyExtensions
{
    public static ResultBox<TValue> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<TValue, ExceptionOrNone> predicate)
        where TValue : notnull
        => result.Conveyor(value => predicate(value) switch
        {
            Exception error => ResultBox<TValue>.FromException(error),
            _ => result
        });

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, ExceptionOrNone> predicate)
        where TValue : notnull
        => (await result).Verify(predicate);

    public static Task<ResultBox<TValue>> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<TValue, Task<ExceptionOrNone>> predicate)
        where TValue : notnull
        => result.Conveyor(async value => await predicate(value) switch
        {
            Exception error => ResultBox<TValue>.FromException(error),
            _ => result
        });

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, Task<ExceptionOrNone>> predicate)
        where TValue : notnull
        => await (await result).Verify(predicate);

    public static ResultBox<TValue> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<ExceptionOrNone> predicate)
        where TValue : notnull
        => result.Conveyor(value => predicate() switch
        {
            Exception error => ResultBox<TValue>.FromException(error),
            _ => result
        });

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<ExceptionOrNone> predicate)
        where TValue : notnull
        => (await result).Verify(predicate);

    public static Task<ResultBox<TValue>> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<Task<ExceptionOrNone>> predicate)
        where TValue : notnull
        => result.Conveyor(async value => await predicate() switch
        {
            Exception error => ResultBox<TValue>.FromException(error),
            _ => result
        });

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<Task<ExceptionOrNone>> predicate)
        where TValue : notnull
        => await (await result).Verify(predicate);

    public static ResultBox<TValue> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<TValue, ResultBox<ExceptionOrNone>> predicate)
        where TValue : notnull
        => result.Conveyor(predicate)
            .Conveyor(exceptionOrNone => exceptionOrNone switch
            {
                Exception error => ResultBox<TValue>.FromException(error),
                _ => result
            });

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, ResultBox<ExceptionOrNone>> predicate)
        where TValue : notnull
        => await (await result)
            .Combine(predicate)
            .Conveyor((value, exceptionOrNone) => Task.FromResult(exceptionOrNone switch
            {
                Exception error => ResultBox<TValue>.FromException(error),
                _ => (ResultBox<TValue>)value
            }));

    public static Task<ResultBox<TValue>> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<TValue, Task<ResultBox<ExceptionOrNone>>> predicate)
        where TValue : notnull
        => result.Conveyor(predicate)
            .Conveyor(exceptionOrNone => exceptionOrNone switch
            {
                Exception error => ResultBox<TValue>.FromException(error),
                _ => result
            });

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<TValue, Task<ResultBox<ExceptionOrNone>>> predicate)
        where TValue : notnull
        => await (await result)
            .Combine(predicate)
            .Conveyor((value, exceptionOrNone) => Task.FromResult(exceptionOrNone switch
            {
                Exception error => ResultBox<TValue>.FromException(error),
                _ => (ResultBox<TValue>)value
            }));

    public static ResultBox<TValue> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<ResultBox<ExceptionOrNone>> predicate)
        where TValue : notnull
        => result.Conveyor(predicate)
            .Conveyor(exceptionOrNone => exceptionOrNone switch
            {
                Exception error => ResultBox<TValue>.FromException(error),
                _ => result
            });

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<ResultBox<ExceptionOrNone>> predicate)
        where TValue : notnull
    {
        var res = await result;
        return res.Verify(predicate);
    }

    public static Task<ResultBox<TValue>> Verify<TValue>(
        this ResultBox<TValue> result,
        Func<Task<ResultBox<ExceptionOrNone>>> predicate)
        where TValue : notnull
        => result.Combine(predicate)
            .Conveyor((value, exceptionOrNone) => Task.FromResult(exceptionOrNone switch
            {
                Exception error => ResultBox<TValue>.FromException(error),
                _ => (ResultBox<TValue>)value
            }));

    public static async Task<ResultBox<TValue>> Verify<TValue>(
        this Task<ResultBox<TValue>> result,
        Func<Task<ResultBox<ExceptionOrNone>>> predicate)
        where TValue : notnull
        => await (await result).Verify(predicate);
}
