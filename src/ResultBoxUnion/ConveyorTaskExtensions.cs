namespace ResultBoxUnion;

public static class ConveyorTaskExtensions
{
    #region SingleValue

    public static async Task<ResultBox<TValue2>> Conveyor<TValue, TValue2>(
        this Task<ResultBox<TValue>> current,
        Func<TValue, ResultBox<TValue2>> handleValueFunc)
        where TValue : notnull where TValue2 : notnull
        => (await current).Conveyor(handleValueFunc);

    public static async Task<ResultBox<TValue2>> Conveyor<TValue, TValue2>(
        this Task<ResultBox<TValue>> current,
        Func<ResultBox<TValue2>> handleValueFunc)
        where TValue : notnull where TValue2 : notnull
        => (await current).Conveyor(handleValueFunc);

    public static async Task<ResultBox<TValue2>> Conveyor<TValue, TValue2>(
        this Task<ResultBox<TValue>> current,
        Func<TValue, Task<ResultBox<TValue2>>> handleValueFunc)
        where TValue : notnull where TValue2 : notnull
        => await (await current).Conveyor(handleValueFunc);

    public static async Task<ResultBox<TValue2>> Conveyor<TValue, TValue2>(
        this Task<ResultBox<TValue>> current,
        Func<Task<ResultBox<TValue2>>> handleValueFunc)
        where TValue : notnull where TValue2 : notnull
        => await (await current).Conveyor(handleValueFunc);

    #endregion

    #region TwoValues

    public static async Task<ResultBox<TValue3>> Conveyor<T1, T2, TValue3>(
        this Task<ResultBox<TwoValues<T1, T2>>> current,
        Func<T1, T2, ResultBox<TValue3>> handleValueFunc)
        where T1 : notnull where T2 : notnull where TValue3 : notnull
        => (await current).Conveyor(handleValueFunc);

    public static async Task<ResultBox<TValue3>> Conveyor<T1, T2, TValue3>(
        this Task<ResultBox<TwoValues<T1, T2>>> current,
        Func<T1, T2, Task<ResultBox<TValue3>>> handleValueFunc)
        where T1 : notnull where T2 : notnull where TValue3 : notnull
        => await (await current).Conveyor(handleValueFunc);

    #endregion

    #region ThreeValues

    public static async Task<ResultBox<TValueResult>> Conveyor<T1, T2, T3, TValueResult>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current,
        Func<T1, T2, T3, ResultBox<TValueResult>> handleValueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => (await current).Conveyor(handleValueFunc);

    public static async Task<ResultBox<TValueResult>> Conveyor<T1, T2, T3, TValueResult>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current,
        Func<T1, T2, T3, Task<ResultBox<TValueResult>>> handleValueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => await (await current).Conveyor(handleValueFunc);

    #endregion

    #region FourValues

    public static async Task<ResultBox<TValueResult>> Conveyor<T1, T2, T3, T4, TValueResult>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current,
        Func<T1, T2, T3, T4, ResultBox<TValueResult>> handleValueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => (await current).Conveyor(handleValueFunc);

    public static async Task<ResultBox<TValueResult>> Conveyor<T1, T2, T3, T4, TValueResult>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current,
        Func<T1, T2, T3, T4, Task<ResultBox<TValueResult>>> handleValueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => await (await current).Conveyor(handleValueFunc);

    #endregion

    #region FiveValues

    public static async Task<ResultBox<TValueResult>> Conveyor<T1, T2, T3, T4, T5, TValueResult>(
        this Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> current,
        Func<T1, T2, T3, T4, T5, ResultBox<TValueResult>> handleValueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => (await current).Conveyor(handleValueFunc);

    public static async Task<ResultBox<TValueResult>> Conveyor<T1, T2, T3, T4, T5, TValueResult>(
        this Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> current,
        Func<T1, T2, T3, T4, T5, Task<ResultBox<TValueResult>>> handleValueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => await (await current).Conveyor(handleValueFunc);

    #endregion
}
