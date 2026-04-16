namespace ResultBoxUnion;

public static class RemapExtensions
{
    public static ResultBox<TValueResult> Remap<TValueOriginal, TValueResult>(
        this ResultBox<TValueOriginal> current,
        Func<TValueOriginal, TValueResult> valueFunc)
        where TValueOriginal : notnull where TValueResult : notnull
        => current switch
        {
            TValueOriginal v => valueFunc(v),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static ResultBox<TValueResult> Remap<TValueOriginal1, TValueOriginal2, TValueResult>(
        this ResultBox<TwoValues<TValueOriginal1, TValueOriginal2>> current,
        Func<TValueOriginal1, TValueOriginal2, TValueResult> valueFunc)
        where TValueOriginal1 : notnull where TValueOriginal2 : notnull where TValueResult : notnull
        => current switch
        {
            TwoValues<TValueOriginal1, TValueOriginal2> v => v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static ResultBox<TValueResult> Remap<T1, T2, T3, TValueResult>(
        this ResultBox<ThreeValues<T1, T2, T3>> current,
        Func<T1, T2, T3, TValueResult> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => current switch
        {
            ThreeValues<T1, T2, T3> v => v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static ResultBox<TValueResult> Remap<T1, T2, T3, T4, TValueResult>(
        this ResultBox<FourValues<T1, T2, T3, T4>> current,
        Func<T1, T2, T3, T4, TValueResult> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => current switch
        {
            FourValues<T1, T2, T3, T4> v => v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static ResultBox<TValueResult> Remap<T1, T2, T3, T4, T5, TValueResult>(
        this ResultBox<FiveValues<T1, T2, T3, T4, T5>> current,
        Func<T1, T2, T3, T4, T5, TValueResult> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => current switch
        {
            FiveValues<T1, T2, T3, T4, T5> v => v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };

    // Async variants

    public static async Task<ResultBox<TValueResult>> Remap<TValueOriginal, TValueResult>(
        this ResultBox<TValueOriginal> current,
        Func<TValueOriginal, Task<TValueResult>> valueFunc)
        where TValueOriginal : notnull where TValueResult : notnull
        => current switch
        {
            TValueOriginal v => await valueFunc(v),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, TValueResult>(
        this ResultBox<TwoValues<T1, T2>> current,
        Func<T1, T2, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where TValueResult : notnull
        => current switch
        {
            TwoValues<T1, T2> v => await v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, TValueResult>(
        this ResultBox<ThreeValues<T1, T2, T3>> current,
        Func<T1, T2, T3, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where TValueResult : notnull
        => current switch
        {
            ThreeValues<T1, T2, T3> v => await v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, T4, TValueResult>(
        this ResultBox<FourValues<T1, T2, T3, T4>> current,
        Func<T1, T2, T3, T4, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where TValueResult : notnull
        => current switch
        {
            FourValues<T1, T2, T3, T4> v => await v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TValueResult>> Remap<T1, T2, T3, T4, T5, TValueResult>(
        this ResultBox<FiveValues<T1, T2, T3, T4, T5>> current,
        Func<T1, T2, T3, T4, T5, Task<TValueResult>> valueFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        where T4 : notnull where T5 : notnull where TValueResult : notnull
        => current switch
        {
            FiveValues<T1, T2, T3, T4, T5> v => await v.Call(valueFunc),
            Exception e => e,
            null => new ResultValueNullException()
        };
}
