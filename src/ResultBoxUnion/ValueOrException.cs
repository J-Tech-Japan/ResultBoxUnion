namespace ResultBoxUnion;

public union ValueOrException<TValue>(TValue, ExceptionMarker) where TValue : notnull
{
    public bool IsException => this is ExceptionMarker;

    public static ValueOrException<TValue> FromValue(TValue value) => value;
    public static ValueOrException<TValue> Exception => new ExceptionMarker();

    public TValue GetValue() => this switch
    {
        TValue v => v,
        ExceptionMarker => throw new ResultsInvalidOperationException(),
        null => throw new ResultsInvalidOperationException()
    };
}

public record ExceptionMarker;

public static class ValueOrException
{
    public static readonly ExceptionMarker Exception = new();

    public static ValueOrException<TValue> FromValue<TValue>(TValue value) where TValue : notnull =>
        value;
}
