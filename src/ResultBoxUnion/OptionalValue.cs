namespace ResultBoxUnion;

public union OptionalValue<TValue>(TValue, NoneValue) where TValue : notnull
{
    public bool HasValue => this is TValue;

    public static OptionalValue<TValue> Empty => new NoneValue();
    public static OptionalValue<TValue> Null => new NoneValue();
    public static OptionalValue<TValue> None => new NoneValue();

    public TValue GetValue() => this switch
    {
        TValue v => v,
        NoneValue => throw new ResultsInvalidOperationException("no value"),
        null => throw new ResultsInvalidOperationException("no value")
    };

    public static OptionalValue<TValue> FromValue(TValue value) => value;

    public TResult Match<TResult>(Func<TValue, TResult> some, Func<TResult> none) =>
        this switch
        {
            TValue v => some(v),
            _ => none()
        };

    public async Task<TResult> Match<TResult>(Func<TValue, Task<TResult>> some, Func<Task<TResult>> none) =>
        this switch
        {
            TValue v => await some(v),
            _ => await none()
        };

    public async Task<TResult> Match<TResult>(Func<TValue, TResult> some, Func<Task<TResult>> none) =>
        this switch
        {
            TValue v => some(v),
            _ => await none()
        };

    public async Task<TResult> Match<TResult>(Func<TValue, Task<TResult>> some, Func<TResult> none) =>
        this switch
        {
            TValue v => await some(v),
            _ => none()
        };

    public TResult Match<TResult>(Func<TValue, TResult> some, TResult none) =>
        this switch
        {
            TValue v => some(v),
            _ => none
        };

    public async Task<TResult> Match<TResult>(Func<TValue, Task<TResult>> some, Task<TResult> none) =>
        this switch
        {
            TValue v => await some(v),
            _ => await none
        };

    public async Task<TResult> Match<TResult>(Func<TValue, TResult> some, Task<TResult> none) =>
        this switch
        {
            TValue v => some(v),
            _ => await none
        };

    public async Task<TResult> Match<TResult>(Func<TValue, Task<TResult>> some, TResult none) =>
        this switch
        {
            TValue v => await some(v),
            _ => none
        };
}

public record NoneValue;

public static class OptionalValue
{
    public static OptionalValue<TValue> FromValue<TValue>(TValue value) where TValue : notnull => value;

    public static OptionalValue<TValueRemapped> Remap<TValue, TValueRemapped>(
        this OptionalValue<TValue> value,
        Func<TValue, TValueRemapped> remapFunc)
        where TValue : notnull
        where TValueRemapped : notnull =>
        value switch
        {
            TValue v => remapFunc(v),
            _ => OptionalValue<TValueRemapped>.None
        };

    public static async Task<OptionalValue<TValueRemapped>> Remap<TValue, TValueRemapped>(
        this OptionalValue<TValue> value,
        Func<TValue, Task<TValueRemapped>> remapFunc)
        where TValue : notnull
        where TValueRemapped : notnull =>
        value switch
        {
            TValue v => await remapFunc(v),
            _ => OptionalValue<TValueRemapped>.None
        };

    public static async Task<OptionalValue<TValueRemapped>> Remap<TValue, TValueRemapped>(
        this Task<OptionalValue<TValue>> value,
        Func<TValue, TValueRemapped> remapFunc)
        where TValue : notnull
        where TValueRemapped : notnull =>
        Remap(await value, remapFunc);

    public static async Task<OptionalValue<TValueRemapped>> Remap<TValue, TValueRemapped>(
        this Task<OptionalValue<TValue>> value,
        Func<TValue, Task<TValueRemapped>> remapFunc)
        where TValue : notnull
        where TValueRemapped : notnull =>
        await Remap(await value, remapFunc);

    public static async Task<OptionalValue<TValue>> FromValue<TValue>(Task<TValue> value)
        where TValue : notnull => await value;

    public static OptionalValue<TValue> FromNullableValue<TValue>(TValue? value)
        where TValue : notnull =>
        value is null ? OptionalValue<TValue>.Null : (OptionalValue<TValue>)value;

    public static async Task<OptionalValue<TValue>> FromNullableValue<TValue>(Task<TValue?> value)
        where TValue : notnull =>
        FromNullableValue(await value);

    public static OptionalValue<TValue> FromNullableValue<TValue>(TValue? value)
        where TValue : struct =>
        value.HasValue ? (OptionalValue<TValue>)value.Value : OptionalValue<TValue>.Null;

    public static async Task<OptionalValue<TValue>> FromNullableValue<TValue>(Task<TValue?> value)
        where TValue : struct =>
        FromNullableValue(await value);

    public static ResultBox<TValue> GetValueResult<TValue>(this OptionalValue<TValue> optional)
        where TValue : notnull =>
        optional switch
        {
            TValue v => v,
            _ => (ResultBox<TValue>)new ResultsInvalidOperationException("no value")
        };

    public static async Task<TResult> Match<TValue, TResult>(
        this Task<OptionalValue<TValue>> optional,
        Func<TValue, TResult> some,
        Func<TResult> none)
        where TValue : notnull =>
        (await optional).Match(some, none);
}
