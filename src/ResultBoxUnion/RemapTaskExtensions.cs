namespace ResultBoxUnion;

public static class RemapTaskExtensions
{
    public static async Task<ResultBox<TValueResult>> Remap<TValueOriginal, TValueResult>(
        this Task<ResultBox<TValueOriginal>> current,
        Func<TValueOriginal, TValueResult> valueFunc)
        where TValueOriginal : notnull where TValueResult : notnull
        => (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<TValueOriginal, TValueResult>(
        this Task<ResultBox<TValueOriginal>> current,
        Func<TValueOriginal, Task<TValueResult>> valueFunc)
        where TValueOriginal : notnull where TValueResult : notnull
        => await (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, TValueResult>(
        this Task<ResultBox<TwoValues<T1, T2>>> current,
        Func<T1, T2, TValueResult> valueFunc)
        where T1 : notnull where T2 : notnull where TValueResult : notnull
        => (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, TValueResult>(
        this Task<ResultBox<TwoValues<T1, T2>>> current,
        Func<T1, T2, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where TValueResult : notnull
        => await (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, TValueResult>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current,
        Func<T1, T2, T3, TValueResult> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, TValueResult>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current,
        Func<T1, T2, T3, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => await (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, T4, TValueResult>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current,
        Func<T1, T2, T3, T4, TValueResult> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, T4, TValueResult>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current,
        Func<T1, T2, T3, T4, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => await (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, T4, T5, TValueResult>(
        this Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> current,
        Func<T1, T2, T3, T4, T5, TValueResult> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => (await current).Remap(valueFunc);

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, T4, T5, TValueResult>(
        this Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> current,
        Func<T1, T2, T3, T4, T5, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => await (await current).Remap(valueFunc);
}
