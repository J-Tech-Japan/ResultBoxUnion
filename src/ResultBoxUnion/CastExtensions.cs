namespace ResultBoxUnion;

public static class CastExtensions
{
    public static ResultBox<TCasted> Cast<TOriginal, TCasted>(this ResultBox<TOriginal> resultBox)
        where TCasted : notnull where TOriginal : notnull
        => resultBox switch
        {
            TOriginal v => v is TCasted castedValue
                ? (ResultBox<TCasted>)castedValue
                : new InvalidCastException($"Cannot cast value to {typeof(TCasted).Name}"),
            Exception e => e,
            null => new ResultValueNullException()
        };

    public static async Task<ResultBox<TCasted>> Cast<TOriginal, TCasted>(
        this Task<ResultBox<TOriginal>> resultBoxTask)
        where TCasted : notnull where TOriginal : notnull
        => (await resultBoxTask).Cast<TOriginal, TCasted>();
}
