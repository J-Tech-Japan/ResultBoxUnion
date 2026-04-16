namespace ResultBoxUnion;

public record FiveValues<TValue1, TValue2, TValue3, TValue4, TValue5>(
    TValue1 Value1, TValue2 Value2, TValue3 Value3, TValue4 Value4, TValue5 Value5)
    where TValue1 : notnull
    where TValue2 : notnull
    where TValue3 : notnull
    where TValue4 : notnull
    where TValue5 : notnull
{
    public ResultBox<TValue6> Call<TValue6>(
        Func<TValue1, TValue2, TValue3, TValue4, TValue5, ResultBox<TValue6>> addingFunc)
        where TValue6 : notnull
        => addingFunc(Value1, Value2, Value3, Value4, Value5);

    public Task<ResultBox<TValue6>> Call<TValue6>(
        Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task<ResultBox<TValue6>>> addingFunc)
        where TValue6 : notnull
        => addingFunc(Value1, Value2, Value3, Value4, Value5);

    public TValue6 Call<TValue6>(
        Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6> addingFunc) where TValue6 : notnull
        => addingFunc(Value1, Value2, Value3, Value4, Value5);

    public Task<TValue6> Call<TValue6>(
        Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task<TValue6>> addingFunc)
        where TValue6 : notnull
        => addingFunc(Value1, Value2, Value3, Value4, Value5);

    public void CallAction(Action<TValue1, TValue2, TValue3, TValue4, TValue5> action)
        => action(Value1, Value2, Value3, Value4, Value5);

    public async Task CallAction(Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task> action)
        => await action(Value1, Value2, Value3, Value4, Value5);
}

public static class FiveValues
{
    public static FiveValues<TValue1, TValue2, TValue3, TValue4, TValue5>
        FromValues<TValue1, TValue2, TValue3, TValue4, TValue5>(
            TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5)
        where TValue1 : notnull
        where TValue2 : notnull
        where TValue3 : notnull
        where TValue4 : notnull
        where TValue5 : notnull
        => new(value1, value2, value3, value4, value5);

    public static ResultBox<FiveValues<TValue1, TValue2, TValue3, TValue4, TValue5>>
        FromResult<TValue1, TValue2, TValue3, TValue4, TValue5>(
            ResultBox<TValue1> box1, ResultBox<TValue2> box2,
            ResultBox<TValue3> box3, ResultBox<TValue4> box4, ResultBox<TValue5> box5)
        where TValue1 : notnull
        where TValue2 : notnull
        where TValue3 : notnull
        where TValue4 : notnull
        where TValue5 : notnull
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
                        TValue4 v4 => box5 switch
                        {
                            Exception e => e,
                            TValue5 v5 => new FiveValues<TValue1, TValue2, TValue3, TValue4, TValue5>(v1, v2, v3, v4, v5),
                            _ => new ResultValueNullException()
                        },
                        _ => new ResultValueNullException()
                    },
                    _ => new ResultValueNullException()
                },
                _ => new ResultValueNullException()
            },
            _ => new ResultValueNullException()
        };
}
