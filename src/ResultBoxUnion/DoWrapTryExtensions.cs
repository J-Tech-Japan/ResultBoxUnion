namespace ResultBoxUnion;

public static class DoWrapTryExtensions
{
    public static ResultBox<TValue> DoWrapTry<TValue>(
        this ResultBox<TValue> result, Action action) where TValue : notnull
        => result.ConveyorWrapTry(value => { action(); return value; });

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue>(
        this ResultBox<TValue> result, Func<Task> actionAsync) where TValue : notnull
        => await result.ConveyorWrapTry(async value => { await actionAsync(); return value; });

    public static ResultBox<TValue> DoWrapTry<TValue, TValueToIgnore>(
        this ResultBox<TValue> result, Func<TValueToIgnore> action) where TValue : notnull
        => result.ConveyorWrapTry(value => { action(); return value; });

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue, TValueToIgnore>(
        this ResultBox<TValue> result, Func<Task<TValueToIgnore>> actionAsync) where TValue : notnull
        => await result.ConveyorWrapTry(async value => { await actionAsync(); return value; });

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue>(
        this Task<ResultBox<TValue>> result, Action action) where TValue : notnull
        => (await result).DoWrapTry(action);

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue>(
        this Task<ResultBox<TValue>> result, Func<Task> actionAsync) where TValue : notnull
        => await (await result).DoWrapTry(actionAsync);

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue, TValueToIgnore>(
        this Task<ResultBox<TValue>> result, Func<TValueToIgnore> action) where TValue : notnull
        => (await result).DoWrapTry(action);

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue, TValueToIgnore>(
        this Task<ResultBox<TValue>> result, Func<Task<TValueToIgnore>> actionAsync) where TValue : notnull
        => await (await result).DoWrapTry(actionAsync);

    public static ResultBox<TValue> DoWrapTry<TValue>(
        this ResultBox<TValue> result, Action<TValue> action) where TValue : notnull
        => result.ConveyorWrapTry(value => { action(value); return value; });

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue>(
        this ResultBox<TValue> result, Func<TValue, Task> actionAsync) where TValue : notnull
        => await result.ConveyorWrapTry(async value => { await actionAsync(value); return value; });

    public static ResultBox<TValue> DoWrapTry<TValue, TValueToIgnore>(
        this ResultBox<TValue> result, Func<TValue, TValueToIgnore> action) where TValue : notnull
        => result.ConveyorWrapTry(value => { action(value); return value; });

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue>(
        this Task<ResultBox<TValue>> result, Action<TValue> action) where TValue : notnull
        => (await result).DoWrapTry(action);

    public static async Task<ResultBox<TValue>> DoWrapTry<TValue>(
        this Task<ResultBox<TValue>> result, Func<TValue, Task> actionAsync) where TValue : notnull
        => await (await result).DoWrapTry(actionAsync);
}
