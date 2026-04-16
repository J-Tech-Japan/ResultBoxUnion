namespace ResultBoxUnion;

public record ThreeValues<TValue1, TValue2, TValue3>(TValue1 Value1, TValue2 Value2, TValue3 Value3)
    where TValue1 : notnull where TValue2 : notnull where TValue3 : notnull
{
    public FourValues<TValue1, TValue2, TValue3, TValue4> Append<TValue4>(TValue4 value4)
        where TValue4 : notnull
        => new(Value1, Value2, Value3, value4);

    public ResultBox<TValue4> Call<TValue4>(
        Func<TValue1, TValue2, TValue3, ResultBox<TValue4>> addingFunc) where TValue4 : notnull
        => addingFunc(Value1, Value2, Value3);

    public Task<ResultBox<TValue4>> Call<TValue4>(
        Func<TValue1, TValue2, TValue3, Task<ResultBox<TValue4>>> addingFunc) where TValue4 : notnull
        => addingFunc(Value1, Value2, Value3);

    public TValue4 Call<TValue4>(Func<TValue1, TValue2, TValue3, TValue4> addingFunc)
        where TValue4 : notnull
        => addingFunc(Value1, Value2, Value3);

    public Task<TValue4> Call<TValue4>(Func<TValue1, TValue2, TValue3, Task<TValue4>> addingFunc)
        where TValue4 : notnull
        => addingFunc(Value1, Value2, Value3);

    public void CallAction(Action<TValue1, TValue2, TValue3> action)
        => action(Value1, Value2, Value3);

    public async Task CallAction(Func<TValue1, TValue2, TValue3, Task> action)
        => await action(Value1, Value2, Value3);
}

public static class ThreeValues
{
    public static ThreeValues<TValue1, TValue2, TValue3> FromValues<TValue1, TValue2, TValue3>(
        TValue1 value1, TValue2 value2, TValue3 value3)
        where TValue1 : notnull where TValue2 : notnull where TValue3 : notnull
        => new(value1, value2, value3);

    public static ResultBox<ThreeValues<TValue1, TValue2, TValue3>> FromResults<TValue1, TValue2, TValue3>(
        ResultBox<TValue1> box1, ResultBox<TValue2> box2, ResultBox<TValue3> box3)
        where TValue1 : notnull where TValue2 : notnull where TValue3 : notnull
        => box1 switch
        {
            Exception e => e,
            TValue1 v1 => box2 switch
            {
                Exception e => e,
                TValue2 v2 => box3 switch
                {
                    Exception e => e,
                    TValue3 v3 => new ThreeValues<TValue1, TValue2, TValue3>(v1, v2, v3),
                    _ => new ResultValueNullException()
                },
                _ => new ResultValueNullException()
            },
            _ => new ResultValueNullException()
        };
}
