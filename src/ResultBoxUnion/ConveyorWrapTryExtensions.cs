namespace ResultBoxUnion;

public static class ConveyorWrapTryExtensions
{
    #region SingleValue

    public static ResultBox<TValueResult> ConveyorWrapTry<TValue, TValueResult>(
        this ResultBox<TValue> current,
        Func<TValue, TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => current.Conveyor(value => ResultBox.WrapTry(() => handleValueFunc(value), exceptionMapper));

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<TValue, TValueResult>(
        this ResultBox<TValue> current,
        Func<TValue, Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => await current.Conveyor(value => ResultBox.WrapTry(async () => await handleValueFunc(value), exceptionMapper));

    public static ResultBox<TValueResult> ConveyorWrapTry<TValue, TValueResult>(
        this ResultBox<TValue> current,
        Func<TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => current.Conveyor(_ => ResultBox.WrapTry(handleValueFunc, exceptionMapper));

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<TValue, TValueResult>(
        this ResultBox<TValue> current,
        Func<Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where TValue : notnull where TValueResult : notnull
        => await current.Conveyor(_ => ResultBox.WrapTry(async () => await handleValueFunc(), exceptionMapper));

    #endregion

    #region TwoValues

    public static ResultBox<TValueResult> ConveyorWrapTry<T1, T2, TValueResult>(
        this ResultBox<TwoValues<T1, T2>> firstValue,
        Func<T1, T2, TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where TValueResult : notnull
        => firstValue.Conveyor(values => ResultBox.WrapTry(() => values.Call(handleValueFunc), exceptionMapper));

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<T1, T2, TValueResult>(
        this ResultBox<TwoValues<T1, T2>> firstValue,
        Func<T1, T2, Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where TValueResult : notnull
        => await firstValue.Conveyor(async values =>
            await ResultBox.WrapTry(async () => await values.Call(handleValueFunc), exceptionMapper));

    #endregion

    #region ThreeValues

    public static ResultBox<TValueResult> ConveyorWrapTry<T1, T2, T3, TValueResult>(
        this ResultBox<ThreeValues<T1, T2, T3>> firstValue,
        Func<T1, T2, T3, TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => firstValue.Conveyor(values => ResultBox.WrapTry(() => values.Call(handleValueFunc), exceptionMapper));

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<T1, T2, T3, TValueResult>(
        this ResultBox<ThreeValues<T1, T2, T3>> firstValue,
        Func<T1, T2, T3, Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => await firstValue.Conveyor(async values =>
            await ResultBox.WrapTry(async () => await values.Call(handleValueFunc), exceptionMapper));

    #endregion

    #region FourValues

    public static ResultBox<TValueResult> ConveyorWrapTry<T1, T2, T3, T4, TValueResult>(
        this ResultBox<FourValues<T1, T2, T3, T4>> firstValue,
        Func<T1, T2, T3, T4, TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => firstValue.Conveyor(values => ResultBox.WrapTry(() => values.Call(handleValueFunc), exceptionMapper));

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<T1, T2, T3, T4, TValueResult>(
        this ResultBox<FourValues<T1, T2, T3, T4>> firstValue,
        Func<T1, T2, T3, T4, Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => await firstValue.Conveyor(async values =>
            await ResultBox.WrapTry(async () => await values.Call(handleValueFunc), exceptionMapper));

    #endregion

    #region FiveValues

    public static ResultBox<TValueResult> ConveyorWrapTry<T1, T2, T3, T4, T5, TValueResult>(
        this ResultBox<FiveValues<T1, T2, T3, T4, T5>> firstValue,
        Func<T1, T2, T3, T4, T5, TValueResult> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => firstValue.Conveyor(values => ResultBox.WrapTry(() => values.Call(handleValueFunc), exceptionMapper));

    public static async Task<ResultBox<TValueResult>> ConveyorWrapTry<T1, T2, T3, T4, T5, TValueResult>(
        this ResultBox<FiveValues<T1, T2, T3, T4, T5>> firstValue,
        Func<T1, T2, T3, T4, T5, Task<TValueResult>> handleValueFunc,
        Func<Exception, Exception>? exceptionMapper = null)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => await firstValue.Conveyor(async values =>
            await ResultBox.WrapTry(async () => await values.Call(handleValueFunc), exceptionMapper));

    #endregion
}
