namespace ResultBoxUnion;

public record FourValues<TValue1, TValue2, TValue3, TValue4>(
    TValue1 Value1, TValue2 Value2, TValue3 Value3, TValue4 Value4)
    where TValue1 : notnull where TValue2 : notnull where TValue3 : notnull where TValue4 : notnull
{
    public FiveValues<TValue1, TValue2, TValue3, TValue4, TValue5> Append<TValue5>(TValue5 value5)
        where TValue5 : notnull
        => new(Value1, Value2, Value3, Value4, value5);

    public ResultBox<TValue5> Call<TValue5>(
        Func<TValue1, TValue2, TValue3, TValue4, ResultBox<TValue5>> addingFunc) where TValue5 : notnull
        => addingFunc(Value1, Value2, Value3, Value4);

    public Task<ResultBox<TValue5>> Call<TValue5>(
        Func<TValue1, TValue2, TValue3, TValue4, Task<ResultBox<TValue5>>> addingFunc) where TValue5 : notnull
        => addingFunc(Value1, Value2, Value3, Value4);

    public TValue5 Call<TValue5>(Func<TValue1, TValue2, TValue3, TValue4, TValue5> addingFunc)
        where TValue5 : notnull
        => addingFunc(Value1, Value2, Value3, Value4);

    public Task<TValue5> Call<TValue5>(
        Func<TValue1, TValue2, TValue3, TValue4, Task<TValue5>> addingFunc) where TValue5 : notnull
        => addingFunc(Value1, Value2, Value3, Value4);

    public void CallAction(Action<TValue1, TValue2, TValue3, TValue4> action)
        => action(Value1, Value2, Value3, Value4);

    public async Task CallAction(Func<TValue1, TValue2, TValue3, TValue4, Task> action)
        => await action(Value1, Value2, Value3, Value4);

    public static ResultBox<FourValues<TValue1, TValue2, TValue3, TValue4>> FromResults(
        ResultBox<TValue1> box1, ResultBox<TValue2> box2,
        ResultBox<TValue3> box3, ResultBox<TValue4> box4)
        => FourValues.FromResults(box1, box2, box3, box4);
}

public static class FourValues
{
    public static FourValues<TValue1, TValue2, TValue3, TValue4> FromValues<TValue1, TValue2, TValue3, TValue4>(
        TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4)
        where TValue1 : notnull where TValue2 : notnull where TValue3 : notnull where TValue4 : notnull
        => new(value1, value2, value3, value4);

    public static ResultBox<FourValues<TValue1, TValue2, TValue3, TValue4>> FromResults<TValue1, TValue2, TValue3, TValue4>(
        ResultBox<TValue1> box1, ResultBox<TValue2> box2,
        ResultBox<TValue3> box3, ResultBox<TValue4> box4)
        where TValue1 : notnull where TValue2 : notnull where TValue3 : notnull where TValue4 : notnull
        => box1 switch
        {
            Exception e => e,
            TValue1 v1 => box2 switch
            {
                Exception e => e,
                TValue2 v2 => box3 switch
                {
                    Exception e => e,
                    TValue3 v3 => box4 switch
                    {
                        Exception e => e,
                        TValue4 v4 => new FourValues<TValue1, TValue2, TValue3, TValue4>(v1, v2, v3, v4),
                        _ => new ResultValueNullException()
                    },
                    _ => new ResultValueNullException()
                },
                _ => new ResultValueNullException()
            },
            _ => new ResultValueNullException()
        };
}
