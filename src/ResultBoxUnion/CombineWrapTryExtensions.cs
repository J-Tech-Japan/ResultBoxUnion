namespace ResultBoxUnion;

public static class CombineWrapTryExtensions
{
    public static ResultBox<TwoValues<TValue, TValue2>> CombineWrapTry<TValue, TValue2>(
        this ResultBox<TValue> current,
        Func<TValue2> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValue2 : notnull
        => current.ConveyorResult(c => ResultBox.WrapTry(secondValueFunc, exceptionMapper).Conveyor(current.Append));

    public static ResultBox<TwoValues<TValue1, TValue2>> CombineWrapTry<TValue1, TValue2>(
        this ResultBox<TValue1> current,
        Func<TValue1, TValue2> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue1 : notnull where TValue2 : notnull
        => current.ConveyorResult(c => ResultBox.WrapTry(() => secondValueFunc(c.GetValue()), exceptionMapper).Conveyor(current.Append));

    public static async Task<ResultBox<TwoValues<TValue1, TValue2>>> CombineWrapTry<TValue1, TValue2>(
        this ResultBox<TValue1> current,
        Func<Task<TValue2>> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue1 : notnull where TValue2 : notnull
        => await current.ConveyorResult(async first =>
            (await ResultBox.WrapTry(secondValueFunc, exceptionMapper)).Conveyor(first.Append));

    public static async Task<ResultBox<TwoValues<TValue1, TValue2>>> CombineWrapTry<TValue1, TValue2>(
        this ResultBox<TValue1> current,
        Func<TValue1, Task<TValue2>> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue1 : notnull where TValue2 : notnull
        => await current.ConveyorResult(async first =>
            (await ResultBox.WrapTry(async () => await secondValueFunc(first.GetValue()), exceptionMapper)).Conveyor(first.Append));

    // Task extensions
    public static async Task<ResultBox<TwoValues<TValue1, TValue2>>> CombineWrapTry<TValue1, TValue2>(
        this Task<ResultBox<TValue1>> current,
        Func<TValue2> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue1 : notnull where TValue2 : notnull
        => (await current).CombineWrapTry(secondValueFunc, exceptionMapper);

    public static async Task<ResultBox<TwoValues<TValue1, TValue2>>> CombineWrapTry<TValue1, TValue2>(
        this Task<ResultBox<TValue1>> current,
        Func<TValue1, TValue2> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue1 : notnull where TValue2 : notnull
        => (await current).CombineWrapTry(secondValueFunc, exceptionMapper);

    public static async Task<ResultBox<TwoValues<TValue1, TValue2>>> CombineWrapTry<TValue1, TValue2>(
        this Task<ResultBox<TValue1>> current,
        Func<Task<TValue2>> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue1 : notnull where TValue2 : notnull
        => await (await current).CombineWrapTry(secondValueFunc, exceptionMapper);

    public static async Task<ResultBox<TwoValues<TValue1, TValue2>>> CombineWrapTry<TValue1, TValue2>(
        this Task<ResultBox<TValue1>> current,
        Func<TValue1, Task<TValue2>> secondValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue1 : notnull where TValue2 : notnull
        => await (await current).CombineWrapTry(secondValueFunc, exceptionMapper);
}
