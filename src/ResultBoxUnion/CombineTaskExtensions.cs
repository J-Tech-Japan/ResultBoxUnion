namespace ResultBoxUnion;

public static class CombineTaskExtensions
{
    public static async Task<ResultBox<TwoValues<T1, T2>>> Combine<T1, T2>(
        this Task<ResultBox<T1>> current, ResultBox<T2> secondValue)
        where T1 : notnull where T2 : notnull
        => (await current).Combine(secondValue);

    public static async Task<ResultBox<TwoValues<T1, T2>>> Combine<T1, T2>(
        this Task<ResultBox<T1>> current, Func<T1, ResultBox<T2>> secondValueFunc)
        where T1 : notnull where T2 : notnull
        => (await current).Combine(secondValueFunc);

    public static async Task<ResultBox<TwoValues<T1, T2>>> Combine<T1, T2>(
        this Task<ResultBox<T1>> current, Func<Task<ResultBox<T2>>> secondValueFunc)
        where T1 : notnull where T2 : notnull
        => await (await current).Combine(secondValueFunc);

    public static async Task<ResultBox<TwoValues<T1, T2>>> Combine<T1, T2>(
        this Task<ResultBox<T1>> current, Func<T1, Task<ResultBox<T2>>> secondValueFunc)
        where T1 : notnull where T2 : notnull
        => await (await current).Combine(secondValueFunc);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Combine<T1, T2, T3>(
        this Task<ResultBox<TwoValues<T1, T2>>> current, ResultBox<T3> addingResult)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => (await current).Combine(addingResult);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Combine<T1, T2, T3>(
        this Task<ResultBox<TwoValues<T1, T2>>> current, Func<T1, T2, ResultBox<T3>> addingFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => (await current).Combine(addingFunc);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Combine<T1, T2, T3>(
        this Task<ResultBox<TwoValues<T1, T2>>> current, Func<Task<ResultBox<T3>>> combiningFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => await (await current).Combine(combiningFunc);

    public static async Task<ResultBox<ThreeValues<T1, T2, T3>>> Combine<T1, T2, T3>(
        this Task<ResultBox<TwoValues<T1, T2>>> current, Func<T1, T2, Task<ResultBox<T3>>> combiningFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull
        => await (await current).Combine(combiningFunc);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Combine<T1, T2, T3, T4>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current, ResultBox<T4> addingResult)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => (await current).Combine(addingResult);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Combine<T1, T2, T3, T4>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current,
        Func<T1, T2, T3, ResultBox<T4>> addingFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => (await current).Combine(addingFunc);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Combine<T1, T2, T3, T4>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current, Func<Task<ResultBox<T4>>> combiningFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => await (await current).Combine(combiningFunc);

    public static async Task<ResultBox<FourValues<T1, T2, T3, T4>>> Combine<T1, T2, T3, T4>(
        this Task<ResultBox<ThreeValues<T1, T2, T3>>> current,
        Func<T1, T2, T3, Task<ResultBox<T4>>> combiningFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => await (await current).Combine(combiningFunc);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Combine<T1, T2, T3, T4, T5>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current, ResultBox<T5> addingResult)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => (await current).Combine(addingResult);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Combine<T1, T2, T3, T4, T5>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current,
        Func<T1, T2, T3, T4, ResultBox<T5>> addingFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => (await current).Combine(addingFunc);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Combine<T1, T2, T3, T4, T5>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current,
        Func<Task<ResultBox<T5>>> combiningFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => await (await current).Combine(combiningFunc);

    public static async Task<ResultBox<FiveValues<T1, T2, T3, T4, T5>>> Combine<T1, T2, T3, T4, T5>(
        this Task<ResultBox<FourValues<T1, T2, T3, T4>>> current,
        Func<T1, T2, T3, T4, Task<ResultBox<T5>>> combiningFunc)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => await (await current).Combine(combiningFunc);
}
